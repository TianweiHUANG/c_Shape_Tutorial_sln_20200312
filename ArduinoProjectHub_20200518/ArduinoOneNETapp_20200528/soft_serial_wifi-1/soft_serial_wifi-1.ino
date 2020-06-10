/*
   采用外接电源单独供电，2 3口作为软串口接PC机作为调试端
   1 0为串口，连接WIFI模块
*/
#include <Wire.h>
#include <SoftwareSerial.h>
#include "edp.c"


// GY-30
// BH1750FVI 光照传感器
// in ADDR 'L' mode 7bit addr
#define ADDR 0b0100011

#define KEY  "ogCJe19clnmc6KAqv9mPru8dtPc="    //APIkey
#define ID   "680792"                          //设备ID
//#define PUSH_ID "680788"
#define PUSH_ID NULL

// 串口
#define _baudrate   115200
#define _rxpin      3
#define _txpin      2
#define WIFI_UART   Serial
#define DBG_UART    dbgSerial   //调试打印串口

SoftwareSerial dbgSerial( _rxpin, _txpin ); // 软串口，调试打印
edp_pkt *pkt;

/*
 * doCmdOk
 * 发送命令至模块，从回复中获取期待的关键字
 * keyword: 所期待的关键字
 * 成功找到关键字返回true，否则返回false
 */
bool doCmdOk(String data, char *keyword)
{
  bool result = false;
  if (data != "")   //对于tcp连接命令，直接等待第二次回复
  {
    WIFI_UART.println(data);   //发送AT指令
    DBG_UART.print("SEND: ");
    DBG_UART.println(data);
  }
  if (data == "AT")   //检查模块存在
    delay(2000);
  else
    while (!WIFI_UART.available());   // 等待模块回复

  delay(200);
  if (WIFI_UART.find(keyword))   //返回值判断
  {
    DBG_UART.println("do cmd OK");
    result = true;
  }
  else
  {
    DBG_UART.println("do cmd ERROR");
    result = false;
  }
  while (WIFI_UART.available()) WIFI_UART.read();   //清空串口接收缓存
  delay(500);   //指令时间间隔
  return result;
}

void setup()
{
  //char buf[100] = {0};
  //int tmp;

  pinMode(13, OUTPUT);   //WIFI模块指示灯
  pinMode(8, OUTPUT);    //用于连接EDP控制的发光二极管

  WIFI_UART.begin( _baudrate );
  DBG_UART.begin( _baudrate );
  WIFI_UART.setTimeout(3000);    //设置find超时时间
  delay(3000);
  DBG_UART.println("hello world!");

  // 光照传感器初始化
  Wire.begin();
  Wire.beginTransmission(ADDR);
  Wire.write(0b00000001);
  Wire.endTransmission();

  delay(2000);
  while (!doCmdOk("AT", "OK"));
  digitalWrite(13, HIGH);   // 使Led亮

  while (!doCmdOk("AT+CWMODE=3", "OK"));            //工作模式
  while (!doCmdOk("AT+CWJAP=\"360\",\"12345678\"", "OK"));
  while (!doCmdOk("AT+CIPSTART=\"TCP\",\"183.230.40.39\",876", "Linked"));
  while (!doCmdOk("AT+CIPMODE=1", "OK"));           //透传模式
  while (!doCmdOk("AT+CIPSEND", ">"));              //开始发送
}

void loop()
{
  static int edp_connect = 0;
  bool trigger = false;
  edp_pkt rcv_pkt;
  unsigned char pkt_type;
  int i, tmp;
  char num[10];

  /* EDP 连接 */
  if (!edp_connect)
  {
    while (WIFI_UART.available()) WIFI_UART.read(); //清空串口接收缓存
    packetSend(packetConnect(ID, KEY));             //发送EPD连接包
    while (!WIFI_UART.available());                 //等待EDP连接应答
    if ((tmp = WIFI_UART.readBytes(rcv_pkt.data, sizeof(rcv_pkt.data))) > 0 )
    {
      rcvDebug(rcv_pkt.data, tmp);
      if (rcv_pkt.data[0] == 0x20 && rcv_pkt.data[2] == 0x00 && rcv_pkt.data[3] == 0x00)
      {
        edp_connect = 1;
        DBG_UART.println("EDP connected.");
      }
      else
        DBG_UART.println("EDP connect error.");
    }
    packetClear(&rcv_pkt);
  }

  trigger = readGY_30(num);
  if (edp_connect && trigger)
  {
    DBG_UART.print("GY_30: ");
    DBG_UART.println(num);
    packetSend(packetDataSaveTrans(PUSH_ID, "light intensity", num));  //发送数据存储包
                                                                       //当PUSH_ID不为NULL时转发至PUSH_ID
  }

  while (WIFI_UART.available())
  {
    readEdpPkt(&rcv_pkt);
    if (isEdpPkt(&rcv_pkt))
    {
      pkt_type = rcv_pkt.data[0];
      switch (pkt_type)
      {
        case CMDREQ:
          char edp_command[50];
          char edp_cmd_id[40];
          long id_len, cmd_len, rm_len;
          char datastr[20];
          char val[10];
          memset(edp_command, 0, sizeof(edp_command));
          memset(edp_cmd_id, 0, sizeof(edp_cmd_id));
          edpCommandReqParse(&rcv_pkt, edp_cmd_id, edp_command, &rm_len, &id_len, &cmd_len);
          DBG_UART.print("rm_len: ");
          DBG_UART.println(rm_len, DEC);
          delay(10);
          DBG_UART.print("id_len: ");
          DBG_UART.println(id_len, DEC);
          delay(10);
          DBG_UART.print("cmd_len: ");
          DBG_UART.println(cmd_len, DEC);
          delay(10);
          DBG_UART.print("id: ");
          DBG_UART.println(edp_cmd_id);
          delay(10);
          DBG_UART.print("cmd: ");
          DBG_UART.println(edp_command);

          //数据处理与应用中EDP命令内容对应
          //本例中格式为  datastream:[1/0] 
          sscanf(edp_command, "%[^:]:%s", datastr, val);
          if (atoi(val) == 1)
            digitalWrite(8, HIGH);   // 使Led亮
          else
            digitalWrite(8, LOW);   // 使Led灭

          packetSend(packetDataSaveTrans(NULL, datastr, val)); //将新数据值上传至数据流
          break;
        default:
          DBG_UART.print("unknown type: ");
          DBG_UART.println(pkt_type, HEX);
          break;
      }
    }
    //delay(4);
  }
  if (rcv_pkt.len > 0)
    packetClear(&rcv_pkt);
  delay(150);
}

/*
 * readEdpPkt
 * 从串口缓存中读数据到接收缓存
 */
bool readEdpPkt(edp_pkt *p)
{
  int tmp;
  if ((tmp = WIFI_UART.readBytes(p->data + p->len, sizeof(p->data))) > 0 )
  {
    rcvDebug(p->data + p->len, tmp);
    p->len += tmp;
  }
  return true;
}

/*
 * packetSend
 * 将待发数据发送至串口，并释放到动态分配的内存
 */
void packetSend(edp_pkt* pkt)
{
  if (pkt != NULL)
  {
    WIFI_UART.write(pkt->data, pkt->len);    //串口发送
    WIFI_UART.flush();
    free(pkt);              //回收内存
  }
}

void rcvDebug(unsigned char *rcv, int len)
{
  int i;

  DBG_UART.print("rcv len: ");
  DBG_UART.println(len, DEC);
  for (i = 0; i < len; i++)
  {
    DBG_UART.print(rcv[i], HEX);
    DBG_UART.print(" ");
  }
  DBG_UART.println("");
}

bool readGY_30(char *num)
{
  static int val = 0, count = 10;;
  int tmp;
  // reset
  Wire.beginTransmission(ADDR);
  Wire.write(0b00000111);
  Wire.endTransmission();
  delay(100);

  Wire.beginTransmission(ADDR);
  Wire.write(0b00100000);
  Wire.endTransmission();

  // typical read delay 120ms
  delay(120);
  Wire.requestFrom(ADDR, 2); // 2byte every time
  while (Wire.available())
  {
    char c = Wire.read();
    //DBG_UART.println(c, HEX);
    tmp = (tmp << 8) + (c & 0xFF);
  }

  tmp = tmp / 1.2;
  sprintf(num, "%d", tmp);

  if (--count == 0)
  {
    count = 10;
    return true;
  }
  return false;
}

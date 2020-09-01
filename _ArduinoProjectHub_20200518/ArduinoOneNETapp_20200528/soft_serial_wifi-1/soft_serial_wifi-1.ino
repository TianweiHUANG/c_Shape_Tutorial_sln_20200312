#include <Wire.h>
#define GY_30Addr 0b0100011

#define DBG_UART    Serial
#include <SoftwareSerial.h>
#define _rxpin      3
#define _txpin      2
SoftwareSerial      wifiSerial( _rxpin, _txpin );
#define WIFI_UART   wifiSerial
#define _baudrate   9600

#include "edp.c"
#define deviceID    "600131852"                    //deviceID
#define apiKEY      "zmUGR6kASJ4XDso=qswx9v6KW=o=" //apiKEY 
#define PUSH_ID     NULL

/* *** *** *** *** *** *** 1/7 bool doCmdOk(String data, char *keyword) *** *** *** *** *** *** */
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

/* *** *** *** *** *** *** 2/7 void setup() *** *** *** *** *** *** */
void setup()
{
  pinMode(8, OUTPUT);    //用于连接EDP控制的发光二极管
  pinMode(13, OUTPUT);   //WIFI模块指示灯

  WIFI_UART.begin( _baudrate );
  DBG_UART.begin( _baudrate );
  WIFI_UART.setTimeout(3000);    //设置find超时时间
  delay(3000);
  //DBG_UART.println("hello world!");
  DBG_UART.println("The DBG_UART is connected!");

  //光照传感器初始化
  Wire.begin();
  Wire.beginTransmission(GY_30Addr);
  Wire.write(0b00000001);
  Wire.endTransmission();

  delay(2000);
  while (!doCmdOk("AT", "OK"));
  digitalWrite(13, HIGH);;// Led_pin13 HIGH //"The WIFI_UART is connected!"

  while (!doCmdOk("AT+CWMODE=3", "OK"));            //工作模式
  while (!doCmdOk("AT+CWJAP=\"FAST_TianweiHUANG\",\"ad&28%5ty93qe4f82#br\"", "OK"));
  //while (!doCmdOk("AT+CIPSTART=\"TCP\",\"jjfaedp.hedevice.com\",876", "OK"));
  while (!doCmdOk("AT+CIPSTART=\"TCP\",\"183.230.40.39\",876", "OK"));
  while (!doCmdOk("AT+CIPMODE=1", "OK"));           //透传模式
  while (!doCmdOk("AT+CIPSEND", ">"));              //开始发送
}

/* *** *** *** *** *** *** 3/7 void loop()? *** *** *** *** *** *** */
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
    packetSend(packetConnect(deviceID, apiKEY));             //发送EPD连接包// func
    while (!WIFI_UART.available());                 //等待EDP连接应答
    if ((tmp = WIFI_UART.readBytes(rcv_pkt.data, sizeof(rcv_pkt.data))) > 0 )
    {
      rcvDebug(rcv_pkt.data, tmp);// func
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

  trigger = readGY_30(num);// func
  if (edp_connect && trigger)
  {
    DBG_UART.print("GY_30: ");
    DBG_UART.println(num);
    packetSend(packetDataSaveTrans(PUSH_ID, "light intensity", num));  //发送数据存储包// func
                                                                       //当PUSH_ID不为NULL时转发至PUSH_ID
  }

  while (WIFI_UART.available())
  {
    readEdpPkt(&rcv_pkt);// func
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
            digitalWrite(12, HIGH);   // 使Led亮
          else
            digitalWrite(12, LOW);   // 使Led灭

          packetSend(packetDataSaveTrans(NULL, datastr, val)); //将新数据值上传至数据流// func
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

/* *** *** *** *** *** *** 4/7 bool readEdpPkt(edp_pkt *p) *** *** *** *** *** *** */
/*
 * readEdpPkt
 * 从串口缓存中读数据到接收缓存
 */
bool readEdpPkt(edp_pkt *p)
{
  int tmp;
  if ((tmp = WIFI_UART.readBytes(p->data + p->len, sizeof(p->data))) > 0 )
  {
    rcvDebug(p->data + p->len, tmp);// func
    p->len += tmp;
  }
  return true;
}

/* *** *** *** *** *** *** 5/7 void packetSend(edp_pkt* pkt) *** *** *** *** *** *** */
/*
 * packetSend
 * 将待发数据发送至串口，并释放到动态分配的内存
 */
void packetSend(edp_pkt* pkt)
{
  if (pkt != NULL)
  {
    WIFI_UART.write(pkt->data, pkt->len);   //串口发送
    WIFI_UART.flush();
    free(pkt);   //回收内存
  }
}

/* *** *** *** *** *** *** 6/7 void rcvDebug(unsigned char *rcv, int len) *** *** *** *** *** *** */
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

/* *** *** *** *** *** *** 7/7 bool readGY_30(char *num) *** *** *** *** *** *** */
bool readGY_30(char *num)
{
  static int val = 0, count = 10;;
  int tmp;
  // reset
  Wire.beginTransmission(GY_30Addr);
  Wire.write(0b00000111);
  Wire.endTransmission();
  delay(100);

  Wire.beginTransmission(GY_30Addr);
  Wire.write(0b00100000);
  Wire.endTransmission();

  // typical read delay 120ms
  delay(120);
  Wire.requestFrom(GY_30Addr, 2); // 2byte every time
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

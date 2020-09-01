/***********************************************************
File name:  ESP8266_EDP.ino
Description:  ESP8266 realizes remote control via ONENet
Website: www.gewbot.com
E-mail: support@adeept.com
Author: Tom
Date: 2017/07/12 
***********************************************************/
#include "DHT11.h"
#define DHT11_Pin 4 
DHT11 dht11;
int DHT11_temperature,DHT11_humidity;
char DataFlow_dashboard1[20],DataFlow_dashboard2[20];
int DHT11_Flag = 1;
int DHT11_Counter = 0;

#include "edp.c"
edp_pkt rcv_pkt;
static int edp_connect = 0;
unsigned char pkt_type;

//#define WIFI_UART Serial
#include<SoftwareSerial.h>
#define _rxpin      3
#define _txpin      2
SoftwareSerial wifiSerial( _rxpin, _txpin ); 
#define WIFI_UART   wifiSerial
#define _baudrate   9600

#define deviceID    "600131852"                    //deviceID
#define apiKEY      "zmUGR6kASJ4XDso=qswx9v6KW=o=" //apiKEY 

const int stbPin = 7; //the segment display module STB pin connected to digital pin 7
const int dioPin = 8; //the segment display module DIO pin connected to digital pin 8
const int clkPin = 9; //the segment display module CLK pin connected to digital pin 9
uint8_t digits[] = { 0x3f, 0x06, 0x5b, 0x4f, 0x66, 0x6d, 0x7d, 0x07, 0x7f, 0x6f };

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
  if (data != "")//对于tcp连接命令，直接等待第二次回复
  {
    WIFI_UART.println(data);//发送AT指令
  }
  if (data == "AT")//检查模块存在  //if?
    delay(2000);
  else
    while (!WIFI_UART.available());//等待模块回复
   
  delay(200);
  if (WIFI_UART.find(keyword))//返回值判断
  {  
    result = true;
  }
  else
  {
    result = false;
  }
  while (WIFI_UART.available()) WIFI_UART.read();//清空串口接收缓存
  delay(500);//指令时间间隔
  return result;
}

/* *** *** *** *** *** *** 2/7 void sendCommand(uint8_t value) *** *** *** *** *** *** */ 
void sendCommand(uint8_t value) 
{ 
   digitalWrite(stbPin, LOW);                  //pin low.  To begin receiving data
   shiftOut(dioPin, clkPin, LSBFIRST, value);  //send data(value) to the segment display module
   digitalWrite(stbPin, HIGH);                 //pin high.  Stop receiving data
} 

/* *** *** *** *** *** *** 3/7 void setup()? *** *** *** *** *** *** */  
void setup()
{
  pinMode(12, OUTPUT);   //用于连接EDP控制的发光二极管
  pinMode(13, OUTPUT);   //WIFI模块指示灯
  
  pinMode(stbPin, OUTPUT); //initialize the stbPin as an output
  pinMode(clkPin, OUTPUT); //initialize the clkPin as an output
  pinMode(dioPin, OUTPUT); //initialize the dioPin as an output
  sendCommand(0x8f);       //activate
   
  WIFI_UART.begin( _baudrate ); 
  WIFI_UART.setTimeout(3000);//设置find超时时间
  delay(3000);
  //Serial.setTimeout(100);
  //delay(2000); 
  
  while (!doCmdOk("AT", "OK"));
  digitalWrite(13, HIGH);// Led_pin13 HIGH
  while (!doCmdOk("AT+CWMODE=3", "OK"));    //工作模式
  while (!doCmdOk("AT+CWJAP=\"FAST_TianweiHUANG\",\"ad&28%5ty93qe4f82#br\"", "OK"));
  //while (!doCmdOk("AT+CIPSTART=\"TCP\",\"jjfaedp.hedevice.com\",876", "OK"));
  while (!doCmdOk("AT+CIPSTART=\"TCP\",\"183.230.40.39\",876", "OK"));
  while (!doCmdOk("AT+CIPMODE=1", "OK"));   //透传模式
  while (!doCmdOk("AT+CIPSEND", ">"));      //开始发送
}

/* *** *** *** *** *** *** 4/7 void loop()? *** *** *** *** *** *** */
void loop()
{    
    /*** EDP连接 ***/
    if (!edp_connect)
    {
      int tmp;
      
      while (WIFI_UART.available()) WIFI_UART.read(); //清空串口接收缓存
      packetSend(packetConnect(deviceID, apiKEY));    //发送EPD连接包
      while (!WIFI_UART.available());                 //等待EDP连接应答
      
      if ((tmp = WIFI_UART.readBytes(rcv_pkt.data, sizeof(rcv_pkt.data))) > 0 )
      {
        rcvDebug(rcv_pkt.data, tmp); 
        if (rcv_pkt.data[0] == 0x20 && rcv_pkt.data[2] == 0x00 && rcv_pkt.data[3] == 0x00)  //if?
        //if (rcv_pkt.data[0] == 0x20 && rcv_pkt.data[1] == 0x02 && rcv_pkt.data[2] == 0x00 && rcv_pkt.data[3] == 0x00)  //if?
        {
          digitalWrite(13, LOW);// Led_pin13 LOW
          edp_connect = 1;
        }
        else
          ;
      }
      
      packetClear(&rcv_pkt);
    }
    
    if(DHT11_Flag == 1)
    {
      dht11.read(DHT11_Pin);
      DHT11_temperature = dht11.temperature;
      DHT11_humidity = dht11.humidity;
      sprintf(DataFlow_dashboard1,"%d",DHT11_temperature); //int型转换为char型
      sprintf(DataFlow_dashboard2,"%d",DHT11_humidity); //int型转换为char型
      
      delay(500);
      packetSend(packetDataSaveTrans(NULL, "DataFlow_dashboard1", DataFlow_dashboard1)); //将刷新的数据值上传至数据流
      delay(500);
      packetSend(packetDataSaveTrans(NULL, "DataFlow_dashboard2", DataFlow_dashboard2)); //将刷新的数据值上传至数据流
      delay(500);
    
      DHT11_Counter = 0;
      DHT11_Flag = 0;
    } 
       
    DHT11_Counter++;
    
    if(DHT11_Counter > 150&&edp_connect)
    {
      dht11.read(DHT11_Pin);
      DHT11_temperature = dht11.temperature;
      DHT11_humidity = dht11.humidity;
      sprintf(DataFlow_dashboard1,"%d",DHT11_temperature); //int型转换为char型
      sprintf(DataFlow_dashboard2,"%d",DHT11_humidity); //int型转换为char型
      
      delay(500);
      packetSend(packetDataSaveTrans(NULL, "DataFlow_dashboard1", DataFlow_dashboard1)); //将刷新的数据值上传至数据流
      delay(500);
      packetSend(packetDataSaveTrans(NULL, "DataFlow_dashboard2", DataFlow_dashboard2)); //将刷新的数据值上传至数据流
      delay(500);
    
      DHT11_Counter = 0;
    }
    //?
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
                    
                    //数据处理与应用中EDP命令内容对应
                    //本例中格式为  datastream:[1/0] 
                    sscanf(edp_command, "%[^:]:%s", datastr, val);
                    
                    if (atoi(val) == 1)
                      digitalWrite(12, HIGH);// Led_pin12 HIGH
                    else
                      digitalWrite(12, LOW);// Led_pin12 LOW
                    
                    if(atoi(val) > 1)
                    {
                       sendCommand(0x40);                        //setting the Write Data Command,using automatic address genuine.
                       digitalWrite(stbPin, LOW);                //pin low. To begin receiving data
                       shiftOut(dioPin, clkPin, LSBFIRST, 0xc0); //Set the start address 0C0H
                       
                       if(atoi(val) >= 100 && atoi(val) <=1000)
                       {   
                         shiftOut(dioPin, clkPin, LSBFIRST, digits[0]);                //thousand data
                         shiftOut(dioPin, clkPin, LSBFIRST, 0x00);                     //filling high 8-bit data  
                         shiftOut(dioPin, clkPin, LSBFIRST, digits[atoi(val)/100%10]); //hundred data
                         shiftOut(dioPin, clkPin, LSBFIRST, 0x00);                     //filling high 8-bit data 
                         shiftOut(dioPin, clkPin, LSBFIRST, digits[atoi(val)/10%10]);  //ten data
                         shiftOut(dioPin, clkPin, LSBFIRST, 0x00);                     //filling high 8-bit data
                         shiftOut(dioPin, clkPin, LSBFIRST, digits[atoi(val)%10]);     //bit data
                         shiftOut(dioPin, clkPin, LSBFIRST, 0x00);                     //filling high 8-bit data 
                       }
                     
                       else  if(atoi(val) >= 10 && atoi(val) <=100)
                       {  
                          shiftOut(dioPin, clkPin, LSBFIRST, digits[0]);//thousand data
                         shiftOut(dioPin, clkPin, LSBFIRST, 0x00);                //filling high 8-bit data  
                         shiftOut(dioPin, clkPin, LSBFIRST, digits[0]); //hundred data
                         shiftOut(dioPin, clkPin, LSBFIRST, 0x00);                //filling high 8-bit data 
                         shiftOut(dioPin, clkPin, LSBFIRST, digits[atoi(val)/10%10]);  //ten data
                         shiftOut(dioPin, clkPin, LSBFIRST, 0x00);                //filling high 8-bit data
                         shiftOut(dioPin, clkPin, LSBFIRST, digits[atoi(val)%10]);     //bit data
                         shiftOut(dioPin, clkPin, LSBFIRST, 0x00);                //filling high 8-bit data 
                       }
                      
                       else  if(atoi(val) > 0 && atoi(val) <=10)
                       {
                         shiftOut(dioPin, clkPin, LSBFIRST, digits[0]);//thousand data
                         shiftOut(dioPin, clkPin, LSBFIRST, 0x00);                //filling high 8-bit data  
                         shiftOut(dioPin, clkPin, LSBFIRST, digits[0]); //hundred data
                         shiftOut(dioPin, clkPin, LSBFIRST, 0x00);                //filling high 8-bit data 
                         shiftOut(dioPin, clkPin, LSBFIRST, digits[0]);  //ten data
                         shiftOut(dioPin, clkPin, LSBFIRST, 0x00);                //filling high 8-bit data
                         shiftOut(dioPin, clkPin, LSBFIRST, digits[atoi(val)%10]);     //bit data
                         shiftOut(dioPin, clkPin, LSBFIRST, 0x00);                //filling high 8-bit data  
                       }
                       
                       digitalWrite(stbPin, HIGH);//pin high. Stop receiving data
                       delay(500);  
                    } 
                    
                    packetSend(packetDataSaveTrans(NULL, datastr, val)); //将刷新的数据值上传至数据流
                
                    break;
                
                default:
                    ;
                    break;
            }
        }
        //delay(4);
    }
    
    if (rcv_pkt.len > 0)  //if?
      packetClear(&rcv_pkt);
    delay(150);
}

/* *** *** *** *** *** *** 5/7 bool readEdpPkt(edp_pkt *p) *** *** *** *** *** *** */ 
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

/* *** *** *** *** *** *** 6/7 void packetSend(edp_pkt* pkt) *** *** *** *** *** *** */ 
/*
* packetSend
* 将待发数据发送至串口，并释放到动态分配的内存
*/
void packetSend(edp_pkt *pkt)
{
  if (pkt != NULL)
  {
    WIFI_UART.write(pkt->data, pkt->len);//串口发送
    WIFI_UART.flush();
    free(pkt);//回收内存
  }
}

/* *** *** *** *** *** *** 7/7 void rcvDebug(unsigned char *rcv, int len) *** *** *** *** *** *** */ 
void rcvDebug(unsigned char *rcv, int len)
{
  int i;
}

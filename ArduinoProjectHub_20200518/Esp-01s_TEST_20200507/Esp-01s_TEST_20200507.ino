#include<SoftwareSerial.h>
SoftwareSerial mySerial(3, 2);//RxD,TxD

void setup() {
  Serial.begin(9600); 
  while (!Serial) {;}
  Serial.println("hardware serial!");
  //mySerial.begin(115200);
  mySerial.begin(9600);
  mySerial.println("software serial!");
}

void loop() {
  if(mySerial.available())
    Serial.write(mySerial.read());
  if(Serial.available())
    mySerial.write(Serial.read());
}

//*** *** *** *** *** esp8266_at_command_examples_cn.pdf *** *** *** *** ***
// 
//01$.测试AT启动；AT
//02$.重启模块；AT+RST
//03$.配置串口通讯参数；AT+UART=9600,8,1,0,0
//
//04$.配置WiFi模式；AT+CWMODE=3
//05$.连接路由器；AT+CWJAP="FAST_76F2","ad&28%5ty93qe4f82#br" 
//06$.查询ESP8266设备的IP地址；AT+CIFSR
//07$.断开与路由器的连接；AT+CWQAP
//
//08$.服务器设定端口60000，启动监听；
//09$.ESP8266设备作为客户端，设定服务器IP地址192.168.1.102，端口60000，连接到服务器；
//    AT+CIPSTART="TCP","192.168.1.102",60000
//10$.向服务器发送数据；
//    AT+CIPSEND=4
//    >test
//11$.接收服务器的数据；
//12$.断开与服务器的连接；AT+CIPCLOSEMODE,AT+CIPCLOSE
//13$.随时查询ESP8266设备与路由器及与服务器的连接状态；AT+CIPSTATUS
//
//14$.建立TCP服务器；AT+CIPSERVER=1,333,关闭TCP服务器；AT+CIPSERVER=0
//
//(* 禁止保存透传到Flash；AT+SAVETRANSLINK *)
//2018.04.24补充：此时若无USB转TTL工具，不要使用AT+SAVETRANSLINK指令，
//该指令会将当前设置存储到RAM中去，ESP8266通电后自动进入连接模式，
//除非使用USB转TTL进行烧写，否则将无法恢复到调试模式（无法使用AT指令）。
//本人掉坑，后USB转TTL烧写版本后，才恢复正常。 
//*** *** *** *** *** *** *** *** *** *** *** *** *** *** *** *** *** ***  

//#include<SoftwareSerial.h>
//SoftwareSerial wifiSerial(3, 2);//RxD,TxD
//int ledPin13 = 13;
//String wifiSerialRead = "";
//
//void setup() 
//{
//  pinMode(ledPin13, OUTPUT);
//  
//  wifiSerial.begin(9600);
//  delay(2000);
//  //String wifiSerial_TCP = "AT+CIPSTART="TCP","192.168.1.102",60000\r\n";
//  wifiSerial.println("AT+CIPSTART=\"TCP\",\"192.168.1.102\",60000\r\n"); // -?
//  delay(2000);
//  wifiSerial.println("AT+CIPSEND=30\r\n");
//  delay(500);
//  wifiSerial.println("Arduino_Esp8266-01s_Connected!");
//  delay(2000);
//}
//
//void loop() 
//{ 
//  while (wifiSerial.available() > 0)
//  {
//    wifiSerialRead += char(wifiSerial.read());
//    delay(5);
//  } 
//   
//  if (wifiSerialRead.length() > 0)
//  {
//    //wifiSerial.println("AT+CIPSEND=100\r\n");
//    //delay(500);
//    //wifiSerial.println("wifiSerialRead:="+wifiSerialRead);
//    //delay(500);
//    
//    if (wifiSerialRead=="\r\n+IPD,5:start")
//    { 
//      //wifiSerial.println("AT+CIPSEND=100\r\n");
//      //delay(500);
//      //wifiSerial.println("wifiSerialRead:="+wifiSerialRead);
//      //delay(500);
//    
//      wifiSerial.println("AT+CIPSEND=11\r\n");
//      delay(500);
//      wifiSerial.println("Blinking..."); 
//      delay(500);
//      
//      digitalWrite(ledPin13, HIGH);   
//      delay(1000);                      
//      digitalWrite(ledPin13, LOW);  
//      delay(1000); 
//      digitalWrite(ledPin13, HIGH);   
//      delay(1000);                       
//      digitalWrite(ledPin13, LOW);  
//      delay(1000); 
//      digitalWrite(ledPin13, HIGH);  
//      delay(1000);                    
//      digitalWrite(ledPin13, LOW);
//
//      wifiSerial.println("AT+CIPSEND=8\r\n");
//      delay(500);
//      wifiSerial.println("Blinked!"); 
//      delay(500);           
//    }
//    
//    wifiSerialRead = "";
//  }
//}

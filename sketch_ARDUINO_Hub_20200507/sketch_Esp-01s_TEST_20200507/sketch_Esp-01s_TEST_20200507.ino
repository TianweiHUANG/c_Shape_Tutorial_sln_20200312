//#include<SoftwareSerial.h>
//SoftwareSerial mySerial(3, 2);//RxD,TxD
//
//void setup() 
//{
//  Serial.begin(9600); 
//  while (!Serial) {;}
//  Serial.println("hardware serial!");
//  //mySerial.begin(115200);
//  mySerial.begin(9600);
//  mySerial.println("software serial!");
//}
//
//void loop() 
//{
//  if(mySerial.available())
//    Serial.write(mySerial.read());
//  if(Serial.available())
//    mySerial.write(Serial.read());
//}
#include<SoftwareSerial.h>
SoftwareSerial wifiSerial(3, 2);//RxD,TxD
int ledPin13 = 13;
String wifiSerialRead = "";

void setup() 
{
  pinMode(ledPin13, OUTPUT);
  
  wifiSerial.begin(9600);
  delay(2000);
  //String wifiSerial_TCP = "AT+CIPSTART="TCP","192.168.1.102",60000\r\n";
  wifiSerial.println("AT+CIPSTART=\"TCP\",\"192.168.1.102\",60000\r\n");//-?
  delay(2000);
  wifiSerial.println("AT+CIPSEND=30\r\n");
  delay(500);
  wifiSerial.println("Arduino_Esp8266-01s_Connected!");
  delay(2000);
}

void loop() 
{ 
  while (wifiSerial.available() > 0)
  {
    wifiSerialRead += char(wifiSerial.read());
    delay(5);
  } 
   
  if (wifiSerialRead.length() > 0)
  {
    //wifiSerial.println("AT+CIPSEND=18\r\n");
    //delay(500);
    //wifiSerial.println("wifiSerial_Readed!");
    //delay(500);
    
    if (wifiSerialRead=="\r\n+IPD,5:start")
    { 
      //wifiSerial.println("AT+CIPSEND=11\r\n");
      //delay(500);
      //wifiSerial.println("Blinking..."); 
      //delay(500);
      
      digitalWrite(ledPin13, HIGH);   
      delay(1000);                      
      digitalWrite(ledPin13, LOW);  
      delay(1000); 
      digitalWrite(ledPin13, HIGH);   
      delay(1000);                       
      digitalWrite(ledPin13, LOW);  
      delay(1000); 
      digitalWrite(ledPin13, HIGH);  
      delay(1000);                    
      digitalWrite(ledPin13, LOW);

      //wifiSerial.println("AT+CIPSEND=8\r\n");
      //delay(500);
      //wifiSerial.println("Blinked!"); 
      //delay(500);           
    }
    
    wifiSerialRead = "";
  }
}

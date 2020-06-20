#include<SoftwareSerial.h>
SoftwareSerial wifiSerial(3, 2);//RxD,TxD

void setup() {
  Serial.begin(9600); 
  while (!Serial) {;}
  Serial.println("The Serial is opened...");
  wifiSerial.begin(9600);//wifiSerial.begin(115200);
  while (!wifiSerial) {;}
  wifiSerial.println("The wifiSerial is opened...");
}

void loop() {
  if(wifiSerial.available())
    Serial.write(wifiSerial.read());
  if(Serial.available())
    wifiSerial.write(Serial.read());
}

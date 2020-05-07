#include<SoftwareSerial.h>
SoftwareSerial mySerial(3, 2);//RxD,TxD

void setup() 
{
  Serial.begin(9600); 
  while (!Serial) {;}
  Serial.println("hardware serial!");
  mySerial.begin(115200);
  mySerial.println("software serial!");
}

void loop() 
{
  if(mySerial.available())
    Serial.write(mySerial.read());
  if(Serial.available())
    mySerial.write(Serial.read());
}

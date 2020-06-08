//#include <Arduino.h>
//#include <Wire.h>
#include <U8g2lib.h>
U8G2_SSD1306_128X64_NONAME_1_SW_I2C u8g2(U8G2_R0, /* clock=*/ SCL, /* data=*/ SDA, /* reset=*/ U8X8_PIN_NONE);

#include "DHT.h"
#define DHT_Pin  4
#define DHT_Type DHT11
DHT dht(DHT_Pin, DHT_Type);

float Humidity;
float Temperature;
char Humidity_str[3];
char Temperature_str[3];

void setup() 
{
  u8g2.begin();//Arduino环境的显示器的简化设置过程。请参见设置指南，以选择合适的U8g2构造函数。
  dht.begin();
  Serial.begin(9600);
  Serial.println("The DHT11 is Monitoring ...");
}

void loop() {
  //float Humidity = dht.readHumidity();
  //float Temperature = dht.readTemperature();
  Humidity = dht.readHumidity();
  Temperature = dht.readTemperature();
  //char Humidity_str[3];
  //char Temperature_str[3];
  
  //strcpy(p, p1): 复制字符串
  strcpy(Humidity_str, u8x8_u8toa(Humidity, 2));          /* convert Humidity to a string with two digits */
  strcpy(Temperature_str, u8x8_u8toa(Temperature, 2));    /* convert Temperature to a string with two digits */

  u8g2.firstPage();//该命令是（图片）循环的一部分，该循环呈现显示内容。该命令必须与nextPage一起使用。
  do//do...while: do循环与while循环使用相同方式工作，不同的是条件是在循环的末尾被测试的，所以 do 循环总是至少会运行一次。
  {
    //u8g2Dispaly_1();
    u8g2Dispaly_2();
  } while ( u8g2.nextPage() );//该命令是（图片）循环的一部分，该循环呈现显示内容。此命令必须与firstPage一起使用。

  Serial.print("Humidity:");
  Serial.print(Humidity);
  Serial.print("% Temperature:");
  Serial.print(Temperature);
  Serial.println("℃");
  delay(1000);
}

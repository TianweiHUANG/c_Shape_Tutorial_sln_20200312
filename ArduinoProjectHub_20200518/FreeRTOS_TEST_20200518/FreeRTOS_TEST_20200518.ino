#include <Arduino_FreeRTOS.h>
void Task1_func(void *param); //声明任务1
void Task2_func(void *param); //声明任务2
//void Task3_func(void *param); //声明任务3
//void Task4_func(void *param); //声明任务4

int buttonPin07 = 7;
int ledPin12 =  12;
int ledPin13 =  13;  
int buttonPin07State = 0; 
String serialRead = "";

//#include <Wire.h>
//#include <Adafruit_GFX.h>
//#include <Adafruit_SSD1306.h>
//#define OLED_RESET 4
//Adafruit_SSD1306 display(128, 64, &Wire, OLED_RESET);
//String OLEDdisplay = "";
//String OLEDdisplay_TEMP = "";

void setup() 
{
  pinMode(buttonPin07, INPUT_PULLUP);
  pinMode(ledPin12, OUTPUT);  
  pinMode(ledPin13, OUTPUT);  
  Serial.begin(9600,SERIAL_8N1);
  while (!Serial);

  //display.begin(SSD1306_SWITCHCAPVCC, 0x3C);
  //display.setTextColor(WHITE);//打开像素点发光
  //display.setTextSize(2);//设置字体大小  
  //display.setCursor(15, 30);//设置显示位置
        
  xTaskCreate(Task1_func, "Task1", 100, NULL, 1, NULL); //创建任务1
  xTaskCreate(Task2_func, "Task2", 100, NULL, 1, NULL); //创建任务2
  //xTaskCreate(Task3_func, "Task3", 100, NULL, 1, NULL); //创建任务3
  //xTaskCreate(Task4_func, "Task4", 100, NULL, 1, NULL); //创建任务4
  vTaskStartScheduler(); //启动任务调度
}

void Task1_func(void *param)
{
  while (1)
  { 
    buttonPin07State = digitalRead(buttonPin07); 
    if (buttonPin07State == LOW) 
    { 
    vTaskDelay(50 / portTICK_PERIOD_MS );//等待0.05秒 
      if (buttonPin07State == LOW) 
      {  
        //OLEDdisplay = "The Button is pressed.";
        digitalWrite(ledPin12, HIGH); 
      }
    }
    else 
    { 
      //OLEDdisplay = "The Button is released.";  
      digitalWrite(ledPin12, LOW); 
    }    
  }
}

void Task2_func(void *param)
{
  while (1)
  {
    while (Serial.available() > 0)
    {
      serialRead += char(Serial.read());
      delay(5);
    }  
    if (serialRead.length() > 0)
    {
      Serial.println("serialRead:="+serialRead);     
      if ((serialRead=="start") or (serialRead=="start\r") or (serialRead=="start\n") or (serialRead=="start\r\n"))
      {  
        Serial.println("Blinking...");
        digitalWrite(ledPin13, HIGH);   
        vTaskDelay(1000 / portTICK_PERIOD_MS );//等待1秒                     
        digitalWrite(ledPin13, LOW);  
        vTaskDelay(1000 / portTICK_PERIOD_MS );//等待1秒 
        digitalWrite(ledPin13, HIGH);   
        vTaskDelay(1000 / portTICK_PERIOD_MS );//等待1秒                       
        digitalWrite(ledPin13, LOW);  
        vTaskDelay(1000 / portTICK_PERIOD_MS );//等待1秒 
        digitalWrite(ledPin13, HIGH);  
        vTaskDelay(1000 / portTICK_PERIOD_MS );//等待1秒                    
        digitalWrite(ledPin13, LOW);
        Serial.println("Blinked!"); 
      }      
      serialRead = "";              
    } 
  }
}

//void Task3_func(void *param)
//{
//  while (1)
//  { 
//    if (OLEDdisplay!=OLEDdisplay_TEMP)
//    { 
//      display.clearDisplay();//清除显示  
//      display.println(OLEDdisplay);         
//      display.display();//打开显示
//      OLEDdisplay=OLEDdisplay_TEMP;        
//    } 
//  }
//}

//void Task4_func(void *param)
//{
//  while (1)
//  {    
//    display.startscrollright(0x00, 0x0F);
//    vTaskDelay(5000 / portTICK_PERIOD_MS );//等待5秒
//    display.stopscroll();
//    display.startscrollleft(0x00, 0x0F);
//    vTaskDelay(1000 / portTICK_PERIOD_MS );//等待1秒
//    display.stopscroll();
//  }
//}

void loop() {
  
}

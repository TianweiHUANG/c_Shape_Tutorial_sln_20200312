/* *** *** *** *** *** *** *** *** *** *** *** *** */
String comdata = "";

void setup()
{
  Serial.begin(9600);
}

void loop()
{
  while (Serial.available() > 0)  
  {
    comdata += char(Serial.read());
    delay(2);
  }
  if (comdata.length() > 0)
  {
    Serial.println(comdata);
    comdata = "";
  }
}

///* *** *** *** *** *** *** *** *** *** *** *** *** */
//int buttonPin07 = 7;
//int ledPin12 =  12;
//int ledPin13 =  13;
//
//int buttonPin07State = 0;
//int serialRead_int = 0;
//String serialRead_str = ""; 
//
//void setup() 
//{
//  //pinMode(buttonPin07, INPUT);
//  pinMode(buttonPin07, INPUT_PULLUP);
//  pinMode(ledPin12, OUTPUT);  
//  pinMode(ledPin13, OUTPUT);
//  
//  //开启串口，通常置于setup()函数中。
//  //默认SERIAL_8N1表示8个数据位，无校验位，1个停止位。 
//  Serial.begin(9600,SERIAL_8N1);
//}
//
//void loop() 
//{
//  /* *** *** *** *** *** *** *** *** *** *** *** *** */
//  buttonPin07State = digitalRead(buttonPin07); 
//  if (buttonPin07State == LOW) 
//  { 
//    delay(50); 
//    if (buttonPin07State == LOW) 
//    {  
//      digitalWrite(ledPin12, HIGH); 
//    }
//  }
//  else 
//  {   
//    digitalWrite(ledPin12, LOW); 
//  }
////  /* *** *** *** *** *** *** *** *** *** *** *** *** */
////  if (Serial.available() > 0)//判断串口缓冲区的状态，返回从串口缓冲区读取的字节数。
////  {
////    serialRead_int = Serial.read();//读取串口数据，一次读一个字符，读完后删除已读数据。
////    if (serialRead_int == 'b')
////    {
////      Serial.println("Blinking...");//串口输出数据并换行。
////      digitalWrite(ledPin13, HIGH);   
////      delay(1000);                      
////      digitalWrite(ledPin13, LOW);  
////      delay(1000); 
////      digitalWrite(ledPin13, HIGH);   
////      delay(1000);                       
////      digitalWrite(ledPin13, LOW);  
////      delay(1000); 
////      digitalWrite(ledPin13, HIGH);  
////      delay(1000);                    
////      digitalWrite(ledPin13, LOW);
////      Serial.println("Blinked!");//串口输出数据并换行。                 
////    }  
////  }
//  /* *** *** *** *** *** *** *** *** *** *** *** *** */ 
//  while (Serial.available() > 0)//判断串口缓冲区的状态，返回从串口缓冲区读取的字节数。
//  {
//    serialRead_str += char(Serial.read());//读取串口数据，一次读一个字符，读完后删除已读数据。
//    delay(2);
//  }  
//  if (serialRead_str.length() > 0)
//  {
//    Serial.println("serialRead_str:="+serialRead_str);
//    if ((serialRead_str=="start") or (serialRead_str=="start\r") or (serialRead_str=="start\n") or (serialRead_str=="start\r\n"))
//    {  
//      Serial.println("Blinking...");//串口输出数据并换行。
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
//      Serial.println("Blinked!");//串口输出数据并换行。 
//    } 
//    serialRead_str = "";              
//  }   
//}

int buttonPin02 = 2;
int ledPin12 =  13;//-?
int ledPin13 =  12;//-?  

int buttonPin02State = 0; 
int serialRead = 0;

void setup() 
{
  pinMode(buttonPin02, INPUT_PULLUP);//-?
  //pinMode(buttonPin02, INPUT);//-? 
  pinMode(ledPin12, OUTPUT);  
  pinMode(ledPin13, OUTPUT);
  
  //开启串口，通常置于setup()函数中。
  //默认SERIAL_8N1表示8个数据位，无校验位，1个停止位。 
  Serial.begin(9600,SERIAL_8N1);  
}

void loop() 
{
  buttonPin02State = digitalRead(buttonPin02); 
  if (buttonPin02State == LOW) 
  { 
  delay(50); 
    if (buttonPin02State == LOW) 
    {  
    digitalWrite(ledPin12, HIGH); 
    }
  }
  else //buttonPin02State == HIGH
  {   
  digitalWrite(ledPin12, LOW); 
  }

  if (Serial.available() > 0)//判断串口缓冲区的状态，返回从串口缓冲区读取的字节数。
  {
    serialRead = Serial.read();//读取串口数据，一次读一个字符，读完后删除已读数据。//-?
    //Serial.readBytes(buffer, length)//-?
    if (serialRead == 'blink')
    {
      Serial.println("Blinking...");//串口输出数据并换行。
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
      Serial.println("Blinked！");//串口输出数据并换行。                 
    }  
  }
}

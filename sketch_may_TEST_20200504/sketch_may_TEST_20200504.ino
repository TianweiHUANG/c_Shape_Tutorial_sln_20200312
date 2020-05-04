int buttonPin02 = 2; 
int ledPin12 =  12;
int ledPin13 =  13;  

int buttonPin02State = 0; 
int serialRead = 0;

void setup() 
{
  pinMode(buttonPin02, INPUT_PULLUP);//-?
  pinMode(ledPin12, OUTPUT);  
  pinMode(ledPin13, OUTPUT);
    
  Serial.begin(9600); 
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
  else 
  {   
  digitalWrite(ledPin12, LOW); 
  }

  if (Serial.available() > 0)
  {
    serialRead = Serial.read();
    if (serialRead == 'b')
    {
      Serial.println("Blinking...");
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
      Serial.println("Blinked...");                       
    }  
  }
}

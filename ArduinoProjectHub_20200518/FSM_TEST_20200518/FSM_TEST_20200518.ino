const int buttonPin07 = 7;
const int ledPin12 = 12;
const int ledPin13 = 13;
volatile int stateFlag_Task1 = 0;
volatile int stateFlag_Task2 = 0;
volatile unsigned long millis_Start1_1=0;
volatile unsigned long millis_Start1_2=0;
volatile unsigned long millis_Start2_1=0;

void setup()
{
  pinMode(buttonPin07,INPUT_PULLUP);
  pinMode(ledPin12, OUTPUT);
  pinMode(ledPin13, OUTPUT);
}

void loop()
{
  //*** *** *** *** *** *** Task1 *** *** *** *** *** ***// 
  switch (stateFlag_Task1)
  {
    case 0:
      digitalWrite(ledPin12, HIGH);
      millis_Start1_1=millis();
      stateFlag_Task1=10;
      break;

    case 10:
      if (millis()-millis_Start1_1>=1000)
      {
        stateFlag_Task1=20;
      }
      break;
    
    case 20:
      digitalWrite(ledPin12, LOW);
      millis_Start1_2=millis();
      stateFlag_Task1=30;
      break;

    case 30:
      if (millis()-millis_Start1_2>=1000)
      {
        stateFlag_Task1=0;
      }
      break;
      
    default:
      break;
  }
  
  //*** *** *** *** *** *** Task2 *** *** *** *** *** ***// 
  switch (stateFlag_Task2)
  {
    case 0:
      if (digitalRead(buttonPin07) == LOW) 
      {
        millis_Start2_1=millis();
        stateFlag_Task2=10;
      }
      break;

    case 10:
      if (digitalRead(buttonPin07) == LOW)
      {
        if (millis()-millis_Start2_1>=50)
        {
          stateFlag_Task2=20;
        }
      }
      else
      {  
        stateFlag_Task2=0; 
      }
      break;
    
    case 20:
      if (digitalRead(buttonPin07) == LOW)
      {
        digitalWrite(ledPin13, HIGH);
      }
      else
      {  
        digitalWrite(ledPin13, LOW); 
        stateFlag_Task2=0; 
      }
      break;

    default:
      break;
  }
}

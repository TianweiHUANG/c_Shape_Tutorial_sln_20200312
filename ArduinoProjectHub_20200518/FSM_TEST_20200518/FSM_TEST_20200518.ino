//const int buttonPin07 = 7;
//const int ledPin12 = 12;
//volatile int stateFlag = 1;
//
//void setup()
//{
//  pinMode(buttonPin07,INPUT_PULLUP);
//  pinMode(ledPin12, OUTPUT);
//}
//
//void loop()
//{
//  switch (stateFlag)
//  {
//    case 1:
//    digitalWrite(ledPin12, HIGH);
//    if(!digitalRead(buttonPin07))stateFlag=2;
//    break;
//    
//    case 2:
//    digitalWrite(ledPin12, LOW);
//    if(!digitalRead(buttonPin07))stateFlag=3;
//    break;
//    
//    case 3:
//    LED_Blink(1000);
//    if(!digitalRead(buttonPin07))stateFlag=1;
//    break;
//    
//    default:
//    break;
//  }
//}
//
//void LED_Blink (unsigned int time_ms)
//{
//  static unsigned long int n=0;
//  static int stateLed = LOW;
//  if (millis()-n>=time_ms)
//  {
//    stateLed=!stateLed;
//    digitalWrite(ledPin12, stateLed);
//    n=millis();
//  }
//}

const int buttonPin07 = 7;
const int ledPin12 = 12;
volatile int stateFlag_Task1 = 0;
volatile unsigned long millis_Start1=0;
volatile unsigned long millis_Start2=0;

void setup()
{
  pinMode(buttonPin07,INPUT_PULLUP);
  pinMode(ledPin12, OUTPUT);
}

void loop()
{
  switch (stateFlag_Task1)
  {
    case 0:
      digitalWrite(ledPin12, HIGH);
      millis_Start1=millis();
      stateFlag_Task1=10;
      break;

    case 10:
      if (millis()-millis_Start1>=1000)
      {
        stateFlag_Task1=20;
      }
      break;
    
    case 20:
      digitalWrite(ledPin12, LOW);
      millis_Start2=millis();
      stateFlag_Task1=30;
      break;

    case 30:
      if (millis()-millis_Start2>=1000)
      {
        stateFlag_Task1=0;
      }
      break;
      
    default:
      break;
  }
}

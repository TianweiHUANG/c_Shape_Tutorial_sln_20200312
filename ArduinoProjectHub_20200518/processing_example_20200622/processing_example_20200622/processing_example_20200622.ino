void setup(){
  pinMode(11,OUTPUT);
  pinMode(12,OUTPUT);
  pinMode(13,OUTPUT); 
  Serial.begin(9600);
}
void loop(){
  if(Serial.available()){
    char val = Serial.read(); 
    if (val == 'y'){
      digitalWrite(11,HIGH);
    }  
    if (val == 'g'){
      digitalWrite(12,HIGH);
    }  
    if (val == 'r'){
      digitalWrite(13,HIGH);
    }  
    if (val == 'f'){
      digitalWrite(11,LOW);
      digitalWrite(12,LOW);
      digitalWrite(13,LOW);
    } 
  }
}

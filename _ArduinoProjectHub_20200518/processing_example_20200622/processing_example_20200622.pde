import processing.serial.*;
import controlP5.*;
Serial myPort;
ControlP5 myCP5;

void setup(){
  size(320, 480);
  myPort = new Serial(this, "COM10", 9600);
  myCP5 = new ControlP5(this);
  myCP5.addButton("yellow"). setPosition(100, 50).setSize(100, 50);
  myCP5.addButton("green"). setPosition(100, 120).setSize(100, 50);
  myCP5.addButton("red"). setPosition(100, 190).setSize(100, 50);
  myCP5.addButton("off"). setPosition(100, 260).setSize(100, 50);
}

void draw(){
  background(150, 0, 150);
  fill(0, 255, 0); 
  text("LED Control", 100, 30);
}

void yellow(){
  myPort.write("y");
}
void green(){
  myPort.write("g");
}
void red(){
  myPort.write("r");
}
void off(){
  myPort.write("f");
}

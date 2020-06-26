import processing.serial.*;
import controlP5.*;
Serial port;
ControlP5 cp5;

void setup()
{
  size(320, 480);
  port = new Serial(this, "COM10", 9600);
  cp5 = new ControlP5(this);
  cp5.addButton("red"). setPosition(100, 50).setSize(100, 50);
  cp5.addButton("green"). setPosition(100, 120).setSize(100, 50);
  cp5.addButton("yellow"). setPosition(100, 190).setSize(100, 50);
  cp5.addButton("off"). setPosition(100, 260).setSize(100, 50);
}

void draw()
{
  background(150, 0, 150);
  fill(0, 255, 0); 
  text("LED Control", 100, 30);
}

void red(){
  port.write("r");
}
void green(){
  port.write("g");
}
void yellow(){
  port.write("y");
}
void off(){
  port.write("f");
}

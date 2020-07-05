//*** *** *** *** *** *** *** *** *** *** *** *** *** *** *** *** *** *** //
//#include<Wire.h>
//const int MPU6050_addr = 0x68;
//int16_t AccX, AccY, AccZ, Temp, GyroX, GyroY, GyroZ;
//void setup() {
//  Wire.begin();
//  Wire.beginTransmission(MPU6050_addr);
//  Wire.write(0x6B);
//  Wire.write(0);
//  Wire.endTransmission(true);
//  Serial.begin(9600);
//}
//void loop() {
//  Wire.beginTransmission(MPU6050_addr);
//  Wire.write(0x3B);
//  Wire.endTransmission(false);
//  Wire.requestFrom(MPU6050_addr, 14, true);
//  AccX = Wire.read() << 8 | Wire.read();
//  AccY = Wire.read() << 8 | Wire.read();
//  AccZ = Wire.read() << 8 | Wire.read();
//  Temp = Wire.read() << 8 | Wire.read();
//  GyroX = Wire.read() << 8 | Wire.read();
//  GyroY = Wire.read() << 8 | Wire.read();
//  GyroZ = Wire.read() << 8 | Wire.read();
//  Serial.print("AccX = "); Serial.print(AccX);
//  Serial.print(" || AccY = "); Serial.print(AccY);
//  Serial.print(" || AccZ = "); Serial.print(AccZ);
//  Serial.print(" || GyroX = "); Serial.print(GyroX);
//  Serial.print(" || GyroY = "); Serial.print(GyroY);
//  Serial.print(" || GyroZ = "); Serial.print(GyroZ);
//  Serial.print(" || Temp = "); Serial.println(Temp / 340.00 + 36.53);
//  delay(500);
//}
//*** *** *** *** *** *** *** *** *** *** *** *** *** *** *** *** *** *** //
//...\i2cdevlib-master\Arduino\I2Cdev
//...\i2cdevlib-master\Arduino\MPU6050
/*
   DMP
   MPU6050姿态解算
*/

#include "I2Cdev.h"
#include "MPU6050_6Axis_MotionApps20.h"

MPU6050 mpu;
uint8_t fifoBuffer[64];
Quaternion q;
VectorFloat gravity;
float ypr[3];

void setup()
{
  Serial.begin(9600);//Serial.begin(115200);
  mpu.initialize();
  mpu.dmpInitialize();
  mpu.CalibrateAccel(6);
  mpu.CalibrateGyro(6);
  mpu.PrintActiveOffsets();
  mpu.setDMPEnabled(true);
}

void loop()
{
  if (mpu.dmpGetCurrentFIFOPacket(fifoBuffer))
  {
    mpu.dmpGetQuaternion(&q, fifoBuffer);
    mpu.dmpGetGravity(&gravity, &q);
    mpu.dmpGetYawPitchRoll(ypr, &q, &gravity);
    Serial.print("ypr\t");
    Serial.print(ypr[0] * 180 / M_PI);
    Serial.print("\t");
    Serial.print(ypr[1] * 180 / M_PI);
    Serial.print("\t");
    Serial.println(ypr[2] * 180 / M_PI);
    delay(500);
  }
}
//*** *** *** *** *** *** *** *** *** *** *** *** *** *** *** *** *** *** //

<<<<<<< HEAD
#include <Wire.h> 
#include <ESP8266WiFi.h>// 
#include "Kalman.h" 
WiFiServer server(80);// //Initialize the server on Port 80 
Kalman kalmanX; 
Kalman kalmanY; 
uint8_t IMUAddress = 0x68; 
/* IMU Data */ 
int16_t accX; 
int16_t accY; 
int16_t accZ; 
int16_t tempRaw; 
int16_t gyroX; 
int16_t gyroY; 
int16_t gyroZ; 
double accXangle; // Angle calculate using the accelerometer 
double accYangle; 
double temp; 
double gyroXangle = 180; // Angle calculate using the gyro 
double gyroYangle = 180; 
double compAngleX = 180; // Calculate the angle using a Kalman filter 
double compAngleY = 180; 
double kalAngleX; // Calculate the angle using a Kalman filter 
double kalAngleY; 
uint32_t timer; 
void setup() { 
Wire.begin(); 
Serial.begin(9600); 
i2cWrite(0x6B,0x00); // Disable sleep mode 
kalmanX.setAngle(180); // Set starting angle 
kalmanY.setAngle(180); 
timer = micros(); 
=======
#include <Wire.h>
#include <ESP8266WiFi.h>//
#include "Kalman.h"
WiFiServer server(80);//    //Initialize the server on Port 80
Kalman kalmanX;
Kalman kalmanY;
uint8_t IMUAddress = 0x68;
/* IMU Data */
int16_t accX;
int16_t accY;
int16_t accZ;
int16_t tempRaw;
int16_t gyroX;
int16_t gyroY;
int16_t gyroZ;
double gyroXrate;
double gyroYrate;
double accXangle; // Angle calculate using the accelerometer
double accYangle;
double temp;
double gyroXangle = 180; // Angle calculate using the gyro
double gyroYangle = 180;
double compAngleX = 180; // Calculate the angle using a Kalman filter
double compAngleY = 180;
double kalAngleX; // Calculate the angle using a Kalman filter
double kalAngleY;
double setupX;
double setupY;
bool first = true;

uint32_t timer;
void setup() {
  Wire.begin();
  Serial.begin(9600);
  i2cWrite(0x6B,0x00); // Disable sleep mode      
  kalmanX.setAngle(180); // Set starting angle
  kalmanY.setAngle(180);
  timer = micros();
>>>>>>> e6165fc44165dbb5c2e239f9d48765b860599602

WiFi.mode(WIFI_AP); // //Our ESP8266-12E is an AccessPoint 
WiFi.softAP("Reality_Family", "12345678"); // // Provide the (SSID, password); . 
server.begin(); // // Start the HTTP Server 

IPAddress HTTPS_ServerIP= WiFi.softAPIP(); // Obtain the IP of the Server 
Serial.print("Server IP is: "); // Print the IP to the monitor window 
<<<<<<< HEAD
Serial.println(HTTPS_ServerIP); 
} 
void loop() { 
/* Update all the values */ 
uint8_t* data = i2cRead(0x3B,14); 
accX = ((data[0]<<8) | data[1]); 
accY = ((data[2]<< 8) | data[3]); 
accZ = ((data[4]<< 8) | data[5]); 
tempRaw = ((data[6]<<8) | data[7]); 
gyroX = ((data[8] << 8) | data[9]); 
gyroY = ((data[10] << 8) | data[11]); 
gyroZ = ((data[12] << 8) | data[13]); 
/* Calculate the angls based on the different sensors and algorithm */ 
accYangle = (atan2(accX,accZ)+PI)*RAD_TO_DEG; 
accXangle = (atan2(accY,accZ)+PI)*RAD_TO_DEG; 
double gyroXrate = (double)gyroX/131.0; 
double gyroYrate = -((double)gyroY/131.0); 
gyroXangle += kalmanX.getRate()*((double)(micros()-timer)/1000000); // Calculate gyro angle using the unbiased rate 
gyroYangle += kalmanY.getRate()*((double)(micros()-timer)/1000000); 
kalAngleX = kalmanX.getAngle(accXangle, gyroXrate, (double)(micros()-timer)/1000000); // Calculate the angle using a Kalman filter 
kalAngleY = kalmanY.getAngle(accYangle, gyroYrate, (double)(micros()-timer)/1000000); 
if(kalAngleX>360){ 
kalAngleX=360; 
} 
else if (kalAngleX<0)kalAngleX=0; 
if(kalAngleY>360){ 
kalAngleY=360; 
} 
else if (kalAngleY<0)kalAngleY=0; 
=======
Serial.println(HTTPS_ServerIP);
}

void loop() {
  //if (first) delay(10000);
  /* Update all the values */
  uint8_t* data = i2cRead(0x3B,14);
  accX = ((data[0] << 8) | data[1]);
  accY = ((data[2] << 8) | data[3]);
  accZ = ((data[4] << 8) | data[5]);
  tempRaw = ((data[6] << 8) | data[7]);
  gyroX = ((data[8] << 8) | data[9]);
  gyroY = ((data[10] << 8) | data[11]);
  gyroZ = ((data[12] << 8) | data[13]);
  /* Calculate the angls based on the different sensors and algorithm */
  accYangle = (atan2(accX,accZ)+PI)*RAD_TO_DEG;
  accXangle = (atan2(accY,accZ)+PI)*RAD_TO_DEG;  
  gyroXrate = (double)gyroX/131.0;
  gyroYrate = -((double)gyroY/131.0);
  gyroXangle += kalmanX.getRate()*((double)(micros()-timer)/1000000); // Calculate gyro angle using the unbiased rate
  gyroYangle += kalmanY.getRate()*((double)(micros()-timer)/1000000);
  kalAngleX = kalmanX.getAngle(accXangle, gyroXrate, (double)(micros()-timer)/1000000); // Calculate the angle using a Kalman filter
  kalAngleY = kalmanY.getAngle(accYangle, gyroYrate, (double)(micros()-timer)/1000000);

  if (first){
    setupX = kalAngleX;
    setupY = kalAngleY;
    first = false;
    return;
    }

 /*
  if(kalAngleX>360){
    kalAngleX=360;
    }
  else if (kalAngleX<0)kalAngleX=0;
   if(kalAngleY>360){
   kalAngleY=360;
    }
   else if (kalAngleY<0)kalAngleY=0;
   */
>>>>>>> e6165fc44165dbb5c2e239f9d48765b860599602

timer = micros(); 
//Serial.println(); 
// Serial.print("X:"); 
// Serial.print(kalAngleX,0); 
// Serial.print(" "); 
// Serial.print("Y:"); 
// Serial.print(kalAngleY,0); 
// Serial.println(" "); 
// server.write(kalAngleX); 
// server.write(kalAngleY); 
//delay(1000); // 
// The accelerometer's maximum samples rate is 1kHz 

WiFiClient client = server.available(); 
if (client) { 
Serial.println("We have client"); 

//Read what the browser has sent into a String class and print the request to the monitor 
String request = client.readString(); 
//Looking under the hood 
Serial.println(request); 


<<<<<<< HEAD
if (request.indexOf("/artempidorka") != -1) 
client.print(kalAngleX,0); 
client.print("/"); 
client.print(kalAngleY,0); 
} 
//Looking under the hood 


} 
void i2cWrite(uint8_t registerAddress, uint8_t data){ 
Wire.beginTransmission(IMUAddress); 
Wire.write(registerAddress); 
Wire.write(data); 
Wire.endTransmission(); // Send stop 
} 
uint8_t* i2cRead(uint8_t registerAddress, uint8_t nbytes) { 
uint8_t data[nbytes]; 
Wire.beginTransmission(IMUAddress); 
Wire.write(registerAddress); 
Wire.endTransmission(false); // Don't release the bus 
Wire.requestFrom(IMUAddress, nbytes); // Send a repeated start and then release the bus after reading 
for(uint8_t i = 0; i < nbytes; i++) 
data [i]= Wire.read(); 
return data; 
}
=======
if (request.indexOf("/artempidorka") != -1){
 String out = String(kalAngleX,0) + "/" + String(kalAngleY,0);
 client.print(out);
} 
//Looking under the hood 
}}
void i2cWrite(uint8_t registerAddress, uint8_t data){
  Wire.beginTransmission(IMUAddress);
  Wire.write(registerAddress);
  Wire.write(data);
  Wire.endTransmission(); // Send stop
}
uint8_t* i2cRead(uint8_t registerAddress, uint8_t nbytes) {
  uint8_t data[nbytes];
  Wire.beginTransmission(IMUAddress);
  Wire.write(registerAddress);
  Wire.endTransmission(false); // Don't release the bus
  Wire.requestFrom(IMUAddress, nbytes); // Send a repeated start and then release the bus after reading
  for(uint8_t i = 0; i < nbytes; i++)
    data [i]= Wire.read();
  return data;
  }
/*
  double ReturnOnes(double Real, double Set, double Sens){
    if (Real > (Set+Sens)) return (1);
    else if (Real < (Set-Sens)) return (-1);
         else return (0);
         } */

>>>>>>> e6165fc44165dbb5c2e239f9d48765b860599602

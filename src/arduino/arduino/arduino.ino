#include <Servo.h>

Servo servoMotor;

int pos = 0;
int led = 7;

void setup() {
  pinMode(led, OUTPUT);
  servoMotor.attach(9);
  servoMotor.write(0);

  Serial.begin(9600);
  Serial.println("Comunicacao serial efetuada com sucesso com Arduino Uno!");
}

void loop() {

  char resultadoSerial = Serial.read();

  if (resultadoSerial == '1')
  {
    turnLedOn();
    openGate();
    delay(2500);
    turnLedOff();
    closeGate();
  }
  else if (resultadoSerial == '0') {
    turnLedOff();
    closeGate();
  }
}

void turnLedOn() {
  digitalWrite(led, HIGH);
  delay(50);
}

void turnLedOff() {
  digitalWrite(led, LOW);
  delay(50);
}

void openGate() {
  for (pos = 0; pos < 180; pos ++)
  {
    servoMotor.write(pos);
    delay(10);
  }
}


void closeGate() {
  for (pos = 180; pos >= 1; pos--)
  {
    servoMotor.write(pos);
    delay(10);
  }
}

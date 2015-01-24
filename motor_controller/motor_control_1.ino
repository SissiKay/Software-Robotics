
 
// Pin 13 has an LED connected on most Arduino boards.
// give it a name:
int led = 13;

// the setup routine runs once when you press reset:
void setup() {                
  // initialize the digital pin as an output.
  pinMode(led, OUTPUT);  
   // initialize serial communication at 9600 bits per second:
  Serial.begin(9600);  
  Serial1.begin(9600); //port one 
}

// the loop routine runs over and over again forever:
void loop() {
  /*
  //blink led
  digitalWrite(led, HIGH);   // turn the LED on (HIGH is the voltage level)
  delay(1000);               // wait for a second
  digitalWrite(led, LOW);    // turn the LED off by making the voltage LOW
  delay(1000);               // wait for a second
  */
  //read port 0 (computer)
  //write port 1 (motor driver)
  if (Serial.available() > 0)
  {
    /* 
    simpified serial motor mode 
    switch left to right 011100
    (0 = up)
    
    motor 1
    1 reverse 
    64 stop
    127 forward
    
    motor 2
    128 reverse
    192 stop
    255 forward
    
    0 stop all motors
    */
    int command = Serial.parseInt(); 
    
    // print out the value you read:
    Serial.println(command, DEC);
    Serial1.write(command);
  }
}

const int analogInPin = A0       

int veri = 0;        
void setup() { 
  Serial.begin(9600);  
}
void loop() {
  veri = analogRead(analogInPin);        

  Serial.print("Okunan Değer = " );                       
  Serial.println(veri);   
  delay(750);                     
}

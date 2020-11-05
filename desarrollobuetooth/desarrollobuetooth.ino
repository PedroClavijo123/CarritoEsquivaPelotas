//Incluir libreria SoftwareSerial para permitir la communicacion serial 
#include <SoftwareSerial.h>

//Configura un nuevo objeto de serie
SoftwareSerial miBT(10  ,11); //10 tx->rx 11 rx->tx

char dato=0;  // Variable para capturar el dato

//Asignar los pines del arduino
//Motor A
int ENA = 9; //velocidad motor A
int IN1 = 8; //dirección motor a borna 1
int IN2 = 7; //dirección motor a borna 2
//Motor B
int ENB = 3; //velocidad motor B
int IN3 = 5; //dirección motor b borna 1
int IN4 = 4; //dirección motor b borna 2
//Velocidad de ENA y ENB
int velocidad = 100; // PWM = 0 A 255 

void setup() 
{
  //Inicializamos la velocidad de sensor de bluetooth 9600 baudios
  miBT.begin(9600);
  // Inicializamos los puertos
  pinMode(ENA, OUTPUT);
  pinMode(ENB, OUTPUT);
  pinMode(IN1, OUTPUT);
  pinMode(IN2, OUTPUT);
  pinMode(IN3, OUTPUT);
  pinMode(IN4, OUTPUT);
  // Apagamos todos los motores - Estado inicial
  digitalWrite(IN1, LOW);
  digitalWrite(IN2, LOW);
  digitalWrite(IN3, LOW);
  digitalWrite(IN4, LOW);
  // Indicamos el voltaje del pulso trabajo PWN
  analogWrite(ENA,velocidad);
  analogWrite(ENB,velocidad);
}

void loop() 
{
  if(miBT.available()) // lee el sensor BlueTooth y lo envia al Arduino
  {
    dato=miBT.read();  // recupera lectura del sensor bluetooth
   if(dato=='w'||dato=='W'){ // si dato es w, avanzara el carro
      for (unsigned int i = 0; i <= 30000; i++)
        avanzar();
     }
   if(dato=='s'||dato=='S'){ // si dato es s, retrocede el carro
      for (unsigned int i = 0; i <= 30000; i++)
        retrocede();
     }
   if(dato=='a'||dato=='A'){ // si dato es a, gira a la izquierda el carro
      for (unsigned int i = 0; i <= 30000; i++)  
        izquierda();
     }
   if(dato=='d'||dato=='D'){ // si dato es d, gira a la derecha el carro
      for (unsigned int i = 0; i <= 30000; i++)  
        derecha();
     }
   if(dato=='i'||dato=='I'){ // girar 90 grados izquierda,  1 grado ~ 800 ciclos
      for (unsigned int i = 0; i <= 30000; i++)
        retrocede();
      for (unsigned long i = 0; i <= 72000; i++)
        izquierda();
     }
   if(dato=='o'||dato=='O'){ // girar 90 grados derecha,  1 grado ~ 800 ciclos
      for (unsigned int i = 0; i <= 30000; i++)
        retrocede();
      for (unsigned long i = 0; i <= 72000; i++)
        derecha();
     }
   if(dato=='p'||dato=='P'){ // girar 90 anti horario
      for (unsigned long i = 0; i <= 50000; i++)
        giroeneleje();
     }
  }
  detener();
}

void avanzar()
{
  digitalWrite(IN1, LOW); // gira motor A avanza
  digitalWrite(IN2, HIGH);
  digitalWrite(IN3, LOW); // gira motor B avanza
  digitalWrite(IN4, HIGH);
}
void retrocede()
{
  digitalWrite(IN1, HIGH); // gira motor A retrocede
  digitalWrite(IN2, LOW);
  digitalWrite(IN3, HIGH); // gira motor B retrocede
  digitalWrite(IN4, LOW);
}
void derecha()
{
  /*digitalWrite(IN1, LOW); // gira motor A avanza
  digitalWrite(IN2, HIGH);
  digitalWrite(IN3, LOW); // gira motor B Apagado
  digitalWrite(IN4, LOW);*/
  giroenelejeH();
  
}
void izquierda()
{
  /*digitalWrite(IN1, LOW); // gira motor A Apagado
  digitalWrite(IN2, LOW);
  digitalWrite(IN3, LOW); // gira motor B avanza
  digitalWrite(IN4, HIGH);*/
  giroenelejeAH();
  
}
void giroeneleje()
{
  digitalWrite(IN1, LOW);   // gira motor A avanza
  digitalWrite(IN2, HIGH);
  digitalWrite(IN3, HIGH);  // gira motor B retrocede
  digitalWrite(IN4, LOW);
}
void detener()
{
  digitalWrite(IN1, LOW); // gira motor A Apagado
  digitalWrite(IN2, LOW);
  digitalWrite(IN3, LOW); // gira motor B Apagado
  digitalWrite(IN4, LOW);
}
void girar30AH()
{
  for (unsigned long i = 0; i <= 13000; i++)//maso 30 6V
  {      
    giroenelejeAH();       
  }   
  detener();
  detener();
}

void girar30H()
{
  for (unsigned long i = 0; i <= 13000; i++)//maso 30 6V
  {      
    giroenelejeH();       
  }   
  detener();
  detener();
}
void giroenelejeH()
{
  digitalWrite(IN1, LOW);   // gira motor A avanza
  digitalWrite(IN2, HIGH);
  digitalWrite(IN3, HIGH);  // gira motor B retrocede
  digitalWrite(IN4, LOW);
}

void giroenelejeAH()
{
  digitalWrite(IN1, HIGH);   // gira motor A avanza
  digitalWrite(IN2, LOW);
  digitalWrite(IN3, LOW);  // gira motor B retrocede
  digitalWrite(IN4, HIGH);
}

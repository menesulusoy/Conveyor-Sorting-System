#include <Servo.h>

// --- PİN TANIMLAMALARI ---
#define IN1 33
#define IN2 35
#define IR_RENK A1 

#define S0 4
#define S1 5
#define S2 6
#define S3 7
#define COLOR_OUT 8

#define SERVO_PIN_1 12
#define SERVO_PIN_2 28
#define SERVO_PIN_3 23
#define SERVO_PIN_4 22

#define IR_UST  A3  
#define IR_ALT  A2  
#define IR_ORTA A0

Servo ayiriciServo; Servo ayiriciServo2; Servo ayiriciServo3; Servo ayiriciServo4;

// --- DEĞİŞKENLER VE EŞİK DEĞERLERİ ---
const int esikDegeri = 40; // Sensör tetiklenme sınırı
// --- Eşik Değerleri ---
const int ESIK_ALT  = 30;
const int ESIK_ORTA = 35;
const int ESIK_UST  = 37;

int rMin = 20, gMin = 20, bMin = 20; 
int rMax, gMax, bMax;

String suAnkiBoyut = "Bilinmiyor"; 

// --- FİLTRELEME FONKSİYONU ---//10 KERE DEĞER OKUYOR ORTALAMASINI ALIYOR PARAZİTLENMEDEN KAÇMAK İÇİN
int filtreliOku(int pin) {
  long toplam = 0;
  for(int i = 0; i < 10; i++) {
    toplam += analogRead(pin);
    delay(1);
  }
  return (int)(toplam / 10);
}

void setup() {
  Serial.begin(9600);
  
  pinMode(IN1, OUTPUT); pinMode(IN2, OUTPUT);

  pinMode(S0, OUTPUT); pinMode(S1, OUTPUT);
  pinMode(S2, OUTPUT); pinMode(S3, OUTPUT);
  pinMode(COLOR_OUT, INPUT);
  digitalWrite(S0, HIGH); digitalWrite(S1, LOW);

  ayiriciServo.attach(SERVO_PIN_1); ayiriciServo2.attach(SERVO_PIN_2);
  ayiriciServo3.attach(SERVO_PIN_3); ayiriciServo4.attach(SERVO_PIN_4);
  servolariSifirla();

  // Renk Kalibrasyonu
  long rToplam = 0, gToplam = 0, bToplam = 0;
  for(int i = 0; i < 20; i++) {
    rToplam += rawOkuma(LOW, LOW);   
    gToplam += rawOkuma(HIGH, HIGH); 
    bToplam += rawOkuma(LOW, HIGH);  
    delay(50);
  }
  rMax = rToplam / 20; gMax = gToplam / 20; bMax = bToplam / 20;

  motorCalistir();
}

void loop() {
  // C#'tan gelen komutları kontrol et
  if (Serial.available() > 0) {
    String komut = Serial.readStringUntil('\n');
    komut.trim();
    if (komut == "STOP") {
      motorDurdur();
    } else if (komut == "START") {
      motorCalistir();
    }
  }
  // --- 1. ADIM: BOYUT ÖLÇÜMÜ ---
  int altVal = filtreliOku(IR_ALT);
  if (altVal < ESIK_ALT) { 
    // Alt Sensör
    Serial.print("ALT tetiklenme degeri: ");
    Serial.println(altVal);
    motorDurdur(); 
    delay(500); 

    int vA0 = filtreliOku(IR_UST);
    // Üst Sensör
    Serial.print("UST tetiklenme degeri: ");
    Serial.println(vA0);

    int vA3 = filtreliOku(IR_ORTA);
    // Orta Sensör
    Serial.print("ORTA tetiklenme degeri: ");
    Serial.println(vA3);

    if (vA0 < ESIK_UST)      suAnkiBoyut = "BUYUK";
    else if (vA3 < ESIK_ORTA) suAnkiBoyut = "ORTA";
    else                       suAnkiBoyut = "KUCUK";

    delay(2000); 
    motorCalistir();
    while(filtreliOku(IR_ALT) < esikDegeri) delay(10);
  }

  // --- 2. ADIM: RENK ANALİZİ VE C# VERİ GÖNDERİMİ ---
  int renkTetikVal = filtreliOku(IR_RENK);
  if (renkTetikVal < 140) { 
    // 1. C#'a BANT DURDU bilgisini gönder 
    Serial.println("DUR");
    

    delay(250); //sensör tetiklendikten 0.2 saniye sonra dursun
    motorDurdur(); // Sensör gördüğü an motoru durdurur
    delay(2000);   // İstediğin 2 saniyelik durma süresi

    String renk = renkOku(); // Durduktan sonra rengi ölçer
    
    // 2. ANA VERİ PAKETİNİ GÖNDER 
    Serial.print(suAnkiBoyut);
    Serial.print(",");
    Serial.println(renk); 
    
    motorCalistir(); // Servo itmeden önce bandı hareketlendirir 
    // 3. BANT ÇALIŞIYOR bilgisini gönder 
    Serial.println("CALIS");
    servoKontrol(renk);

    while(filtreliOku(IR_RENK) < esikDegeri) delay(10);
  }
}

// --- YARDIMCI FONKSİYONLAR ---

long rawOkuma(int pinS2, int pinS3) {
  digitalWrite(S2, pinS2); digitalWrite(S3, pinS3);
  return pulseIn(COLOR_OUT, LOW);
}

String renkOku() {
  long rRaw = rawOkuma(LOW, LOW); delay(20);
  long gRaw = rawOkuma(HIGH, HIGH); delay(20);
  long bRaw = rawOkuma(LOW, HIGH);

  int r = constrain(map(rRaw, rMax, rMin, 0, 255), 0, 255);
  int g = constrain(map(gRaw, gMax, gMin, 0, 255), 0, 255);
  int b = constrain(map(bRaw, bMax, bMin, 0, 255), 0, 255);

  if (r > g && r > b && r > 60) return "KIRMIZI";
  if (g > r && g > b && g > 60) return "YESIL";
  if (b > r && b > g && b > 60) return "MAVI";
  return "BELIRSIZ";
}

void servoKontrol(String renk) {
    if (renk == "KIRMIZI") {
      if (suAnkiBoyut == "BUYUK") servoKirmiziBuyuk();
      else if (suAnkiBoyut == "ORTA") servoKirmiziOrta();
      else servoKirmiziKucuk();
    }
    else if (renk == "YESIL") {
      if (suAnkiBoyut == "ORTA") servoYesilOrta();
      else if (suAnkiBoyut == "KUCUK") servoYesilKucuk();
    }
    else if (renk == "MAVI") {
      if (suAnkiBoyut == "BUYUK") servoMaviBuyuk();
      else if (suAnkiBoyut == "ORTA") servoMaviOrta();
      else servoMaviKucuk();
    }
}

// --- MOTOR HIZ KONTROLÜ ---
void motorCalistir() { 
  digitalWrite(IN1, HIGH); 
  digitalWrite(IN2, LOW); 
  
}

void motorDurdur() { 
  digitalWrite(IN1, LOW); 
  digitalWrite(IN2, LOW); 
  
}

void servolariSifirla() { ayiriciServo.write(0); ayiriciServo2.write(0); ayiriciServo3.write(0); ayiriciServo4.write(0); }

// --- SERVO HAREKETLERI ---
void servoKirmiziKucuk() { delay(550); ayiriciServo.write(180);  delay(400); ayiriciServo.write(0); }
void servoKirmiziOrta()  {  delay(200); ayiriciServo.write(180); delay(400); ayiriciServo.write(0);}
void servoKirmiziBuyuk() { delay(1000); ayiriciServo4.write(180); delay(1700); ayiriciServo4.write(0); }
void servoYesilKucuk()   { delay(1300); ayiriciServo2.write(180); delay(650); ayiriciServo2.write(0); }
void servoYesilOrta()    { delay(200);  ayiriciServo2.write(180); delay(1150); ayiriciServo2.write(0); }
void servoMaviKucuk()    { delay(2100); ayiriciServo3.write(180); delay(650); ayiriciServo3.write(0); }
void servoMaviOrta()     { delay(500);  ayiriciServo3.write(180); delay(1500); ayiriciServo3.write(0); }
void servoMaviBuyuk()    { delay(2700); ayiriciServo4.write(180); delay(500); ayiriciServo4.write(0); }

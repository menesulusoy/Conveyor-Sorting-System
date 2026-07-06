[README.md](https://github.com/user-attachments/files/29699354/README.md)
# 3 Renk ve 3 Boyut Ayıran Otonom Konveyör Bant Sistemi

Bu proje, konveyör bant üzerindeki nesneleri **renk** ve **boyut** bilgilerine göre otomatik olarak sınıflandıran, Arduino tabanlı bir gömülü sistem uygulamasıdır.

Sistem; nesneleri **kırmızı, yeşil ve mavi** renklerine, ayrıca **küçük, orta ve büyük** boyutlarına göre algılar. Elde edilen bilgiler seri haberleşme üzerinden C# Windows Forms uygulamasına aktarılır, anlık olarak görüntülenir ve sütun grafiği üzerinde raporlanır.

## Projenin Amacı

Projenin amacı, üretim hatlarında kullanılabilecek temel bir otomatik ayrıştırma sisteminin prototipini geliştirmektir.

Sistem aşağıdaki işlemleri gerçekleştirir:

- Konveyör bant üzerindeki nesneyi algılar.
- Nesnenin boyutunu üç farklı sensör seviyesine göre belirler.
- Nesneyi renk sensörünün önünde durdurur.
- Kırmızı, yeşil veya mavi renk sınıflandırması yapar.
- Boyut ve renk bilgisini C# uygulamasına gönderir.
- Uygun servo motoru çalıştırarak nesneyi ilgili bölmeye yönlendirir.
- Ayrıştırılan nesnelerin sayılarını grafik üzerinde gösterir.
- Hatalı okumalarda operatörün sayaçları manuel olarak düzeltmesine izin verir.

## Sistem Özellikleri

- 3 farklı renk algılama:
  - Kırmızı
  - Yeşil
  - Mavi

- 3 farklı boyut algılama:
  - Küçük
  - Orta
  - Büyük

- Arduino Mega tabanlı kontrol sistemi
- TCS3200 renk sensörü
- TCRT5000 kızılötesi sensörlerle boyut ve konum algılama
- L298N motor sürücü ile konveyör bant kontrolü
- 4 adet SG90 servo motor ile mekanik ayrıştırma
- C# Windows Forms kullanıcı arayüzü
- Seri port üzerinden çift yönlü haberleşme
- Anlık ürün sayacı ve sütun grafik
- Manuel hata düzeltme özelliği

## Sistem Çalışma Mantığı

1. Konveyör bant çalıştırılır.
2. Nesne boyut algılama bölümüne geldiğinde alt sensör tarafından tespit edilir.
3. Orta ve üst sensörlerin durumuna göre nesne:
   - `KUCUK`
   - `ORTA`
   - `BUYUK`

   olarak etiketlenir.
4. Nesne renk sensörünün önüne geldiğinde bant kısa süreliğine durdurulur.
5. TCS3200 sensöründen kırmızı, yeşil ve mavi kanal değerleri okunur.
6. Nesnenin rengi:
   - `KIRMIZI`
   - `YESIL`
   - `MAVI`
   - `BELIRSIZ`

   olarak sınıflandırılır.
7. Arduino, sonucu aşağıdaki formatta C# uygulamasına gönderir:

```text
BOYUT,RENK
```

Örnek:

```text
ORTA,KIRMIZI
```

8. C# uygulaması ürün sayacını ve grafiği günceller.
9. Renk ve boyut kombinasyonuna göre uygun servo motor çalıştırılarak nesne ayrıştırılır.
10. Sistem bir sonraki nesneyi beklemeye devam eder.

## Donanım Bileşenleri

| Bileşen | Kullanım Amacı |
|---|---|
| Arduino Mega 2560 | Sistemin ana kontrol birimi |
| TCS3200 renk sensörü | Nesnenin rengini algılama |
| 4 adet TCRT5000 sensör | Boyut ve renk istasyonu tetikleme |
| 4 adet SG90 servo motor | Nesneleri ilgili bölmelere yönlendirme |
| L298N motor sürücü | Konveyör bant motorunu kontrol etme |
| 6V DC motor | Konveyör bandı hareket ettirme |
| 2 adet LM2596 dönüştürücü | Motor ve servo besleme gerilimlerini düzenleme |
| 12V 4A adaptör | Sistemin ana güç kaynağı |
| Konveyör bant mekanizması | Nesnelerin taşınması |

## Arduino Pin Bağlantıları

### Motor Sürücü

| Arduino Mega Pini | Bağlantı |
|---|---|
| 33 | L298N IN1 |
| 35 | L298N IN2 |

### TCS3200 Renk Sensörü

| Arduino Mega Pini | TCS3200 Pini |
|---|---|
| 4 | S0 |
| 5 | S1 |
| 6 | S2 |
| 7 | S3 |
| 8 | OUT |

### TCRT5000 Sensörleri

| Arduino Mega Pini | Görev |
|---|---|
| A0 | Orta boyut sensörü |
| A1 | Renk istasyonu tetik sensörü |
| A2 | Alt sensör |
| A3 | Üst boyut sensörü |

### Servo Motorlar

| Arduino Mega Pini | Görev |
|---|---|
| 12 | Kırmızı ürün ayrıştırma servosu |
| 28 | Yeşil ürün ayrıştırma servosu |
| 23 | Mavi ürün ayrıştırma servosu |
| 22 | Büyük ürün ayrıştırma servosu |

> Bağlantı yapılırken Arduino, sensörler, motor sürücü ve güç modüllerinin toprak hatları ortaklanmalıdır.

## Kullanılan Teknolojiler

### Gömülü Sistem

- Arduino Mega 2560
- Arduino IDE
- C / C++
- Servo kütüphanesi
- Analog sensör okuma
- Seri haberleşme

### Masaüstü Uygulaması

- C#
- .NET Windows Forms
- `System.IO.Ports`
- `System.Windows.Forms.DataVisualization.Charting`
- MSChart

## Seri Haberleşme Protokolü

Arduino ile C# uygulaması arasında `9600 baud` seri haberleşme kullanılır.

### Arduino'dan C# Uygulamasına Gönderilen Mesajlar

| Mesaj | Açıklama |
|---|---|
| `DUR` | Konveyör bandının renk ölçümü için durduğunu bildirir |
| `CALIS` | Konveyör bandının yeniden çalıştığını bildirir |
| `BOYUT,RENK` | Algılanan nesnenin sınıflandırma sonucunu gönderir |

Örnek veri paketleri:

```text
KUCUK,MAVI
ORTA,YESIL
BUYUK,KIRMIZI
```

### C# Uygulamasından Arduino'ya Gönderilen Komutlar

| Komut | Açıklama |
|---|---|
| `START` | Konveyör bandını çalıştırır |
| `STOP` | Konveyör bandını durdurur |

## Sensör Filtreleme ve Kalibrasyon

TCRT5000 sensörlerinden alınan analog değerlerde oluşabilecek parazitleri azaltmak için her sensör değeri 10 kez okunur ve ölçümlerin ortalaması kullanılır.

TCS3200 renk sensörü sistem başlangıcında kalibre edilir. Kırmızı, yeşil ve mavi kanallar için belirlenen minimum ve maksimum değerler kullanılarak ham sensör değerleri `0-255` aralığına dönüştürülür.

Renk kararı, en yüksek RGB kanalına göre verilir.

> Sensör eşik değerleri, ortam ışığına, kullanılan nesnelere ve sensörlerin konumuna göre yeniden ayarlanmalıdır.

## C# Kullanıcı Arayüzü

Windows Forms uygulaması aşağıdaki özellikleri içerir:

- Arduino seri port bağlantısı
- Konveyör bandını başlatma ve durdurma
- Sistemin çalışma durumunu renkli panel ile gösterme
- Algılanan son nesnenin renk ve boyut bilgisini gösterme
- Dokuz farklı renk-boyut kombinasyonu için sayaç tutma
- Ürün sayılarını sütun grafiğinde görüntüleme
- Hatalı ölçüm durumlarında seçilen sayacı azaltma

### Durum Renkleri

| Renk | Sistem Durumu |
|---|---|
| Yeşil | Konveyör çalışıyor |
| Sarı | Konveyör renk ölçümü için durdu |
| Kırmızı | Sistem operatör tarafından durduruldu |

## Kurulum

### 1. Arduino Kodunun Yüklenmesi

1. Arduino Mega 2560 bilgisayara bağlanır.
2. Arduino IDE açılır.
3. `Servo.h` kütüphanesinin kurulu olduğu kontrol edilir.
4. Arduino kaynak kodu açılır.
5. Kart olarak `Arduino Mega or Mega 2560` seçilir.
6. Doğru COM port seçilir.
7. Kod karta yüklenir.

### 2. C# Uygulamasının Çalıştırılması

1. Proje Visual Studio ile açılır.
2. Windows Forms ve Chart bileşenlerinin kullanılabilir olduğu kontrol edilir.
3. `Form1_Load` içerisindeki seri port adı bilgisayardaki Arduino portuna göre değiştirilir.

Örnek:

```csharp
serialPort1.PortName = "COM10";
serialPort1.BaudRate = 9600;
```

4. Proje derlenir ve çalıştırılır.
5. Arduino bağlantısı başarılıysa uygulama seri verileri okumaya başlar.

## Kullanım

1. Sistemin güç bağlantılarını kontrol edin.
2. Arduino'yu bilgisayara bağlayın.
3. C# uygulamasını çalıştırın.
4. Konveyör bandını başlatın.
5. Ayrıştırılacak nesneyi bandın başlangıç noktasına yerleştirin.
6. Nesnenin boyut ve renk algılama aşamalarını tamamlamasını bekleyin.
7. Sonuçları uygulama ekranından ve grafikten takip edin.
8. Hatalı sınıflandırma oluşursa ilgili renk ve boyut değerini seçerek sayacı azaltın.

## Önerilen Proje Klasör Yapısı

```text
.
├── Arduino/
│   └── ConveyorSortingSystem.ino
├── CSharp/
│   └── ConveyorSortingSystem.sln
├── docs/
│   ├── block-diagram.png
│   ├── flowchart.png
│   └── interface.png
└── README.md
```

## Proje Görselleri

Repo içerisine proje görselleri eklendikten sonra aşağıdaki bağlantılar kullanılabilir:

```markdown
![Sistem Blok Diyagramı](docs/block-diagram.png)

![Sistem Akış Diyagramı](docs/flowchart.png)

![C# Kullanıcı Arayüzü](docs/interface.png)
```

## Dikkat Edilmesi Gerekenler

- C# uygulamasındaki COM port değeri her bilgisayarda farklı olabilir.
- Sensör eşik değerleri fiziksel kuruluma göre kalibre edilmelidir.
- Servo motorlar doğrudan Arduino'nun 5V çıkışından beslenmemelidir.
- Servo motorlar ve DC motor için harici ve düzenlenmiş güç kaynağı kullanılmalıdır.
- Bütün sistem bileşenleri ortak GND hattına bağlanmalıdır.
- Servo gecikme süreleri konveyör bant hızına ve servo konumlarına göre ayarlanmalıdır.
- TCS3200 renk sensörü ortam ışığından etkilenebileceği için sensör bölgesi mümkün olduğunca kapalı tutulmalıdır.

## Geliştirilebilecek Özellikler

- Otomatik COM port algılama
- Sensör eşiklerinin arayüz üzerinden ayarlanması
- Ürün verilerinin veritabanına kaydedilmesi
- Günlük, haftalık ve aylık üretim raporları
- CSV veya Excel çıktısı alma
- Hata kayıt sistemi
- Acil durdurma butonu
- PWM ile konveyör hız kontrolü
- Daha gelişmiş renk kalibrasyonu
- Web tabanlı uzaktan takip paneli
- Endüstriyel sensör ve motorlarla ölçeklendirme

## Proje Sahibi

**Murat Enes Ulusoy**

Ders: **Mikroişlemciler ve Gömülü Sistemler**

Proje: **3 Renk ve 3 Boyut Ayıran Otonom Konveyör Bant Sistemi**

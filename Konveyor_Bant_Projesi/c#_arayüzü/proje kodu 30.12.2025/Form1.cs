using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports; // Port için
using System.Windows.Forms.DataVisualization.Charting; // Grafik için 

namespace proje_kodu_30._12._2025
{
    public partial class Form1 : Form
    {
        
        // Kombinasyon Sayaçları 
        int kirmiziBuyuk = 0, kirmiziOrta = 0, kirmiziKucuk = 0;
        int yesilBuyuk = 0, yesilOrta = 0, yesilKucuk = 0; 
        int maviBuyuk = 0, maviOrta = 0, maviKucuk = 0;

        private void btnAzaltin_Click(object sender, EventArgs e)
        {
           
            string secilenRenk = cmbRenk.Text.ToUpper();
            string secilenBoyut = cmbBoyut.Text.ToUpper();

            if (secilenRenk == "KIRMIZI")
            {
                if (secilenBoyut == "BUYUK" && kirmiziBuyuk > 0) kirmiziBuyuk--;
                else if (secilenBoyut == "ORTA" && kirmiziOrta > 0) kirmiziOrta--;
                else if (secilenBoyut == "KUCUK" && kirmiziKucuk > 0) kirmiziKucuk--;
            }
            else if (secilenRenk == "YESIL")
            {
                if (secilenBoyut == "BUYUK" && yesilBuyuk > 0) yesilBuyuk--;
                else if (secilenBoyut == "ORTA" && yesilOrta > 0) yesilOrta--;
                else if (secilenBoyut == "KUCUK" && yesilKucuk > 0) yesilKucuk--;
            }
            else if (secilenRenk == "MAVI")
            {
                if (secilenBoyut == "BUYUK" && maviBuyuk > 0) maviBuyuk--;
                else if (secilenBoyut == "ORTA" && maviOrta > 0) maviOrta--;
                else if (secilenBoyut == "KUCUK" && maviKucuk > 0) maviKucuk--;
            }

            GrafikGuncelle(); // Grafiği yenilemek için
        }

        private void btnMotorBaslat_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.WriteLine("START"); // Arduino tekrar çalışır
                pnlDurum.BackColor = Color.Green;

               
                btnMotorBaslat.Visible = false;
                panel1.Visible = false;
            }
        }

        private void btnMotorDurdur_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.WriteLine("STOP"); // Arduino bandı durdurur
                }

                pnlDurum.BackColor = Color.Red;

                // uyarı mesajı
                MessageBox.Show("Servo zamanlaması veya hatalı okuma gerçekleşti. \n\nLütfen ilgili hatayı seçerek grafikte azaltın.",
                                "Sistem Durduruldu", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                
                btnMotorBaslat.Visible = true;
                panel1.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    string gelen = serialPort1.ReadLine().Trim();

                    // C# arayüzünü güncellemek için 
                    this.Invoke(new MethodInvoker(delegate {
                        IslemYap(gelen);
                    }));
                }
            }
            catch (Exception ex)
            {
                // Bağlantı koptuğunda uygulamanın çökmesini engeller
                Console.WriteLine("Veri okuma hatası: " + ex.Message);
            } // Gelen satırı oku

        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnMotorBaslat.Visible = false; 
            panel1.Visible = false;
            // Arduino hangi portta
            serialPort1.PortName = "COM10";
            serialPort1.BaudRate = 9600;

            try
            {
                serialPort1.Open(); // Portu aç
            }
            catch
            {
                MessageBox.Show("Arduino'yu takmayı veya portu seçmeyi unuttun!");
            }

            // Grafik Başlangıç Ayarı
            chart1.Series.Clear();
            chart1.Series.Add("Urunler");
            chart1.Series["Urunler"].ChartType = SeriesChartType.Column; // Sütun grafiği
        }
        private void IslemYap(string veri)
        {
            veri = veri.Trim().ToUpper();
            if (string.IsNullOrEmpty(veri) || veri.Contains("BELIRSIZ")) return; // Boş veya belirsizse işlem yapma

            if (veri == "DUR") { pnlDurum.BackColor = Color.Yellow; return; } //Dur gelince sarı yap
            if (veri == "CALIS") { pnlDurum.BackColor = Color.Green; return; } //çalışırken yeşil yap

            string[] parcalar = veri.Split(',');
            if (parcalar.Length == 2)
            {
                string boyut = parcalar[0].Trim();
                string renk = parcalar[1].Trim();

                if (renk == "BELIRSIZ") { MessageBox.Show("Renk okunamadı!"); return; }

                lblBoyut.Text = "BOYUT: " + boyut;
                lblRenk.Text = "RENK: " + renk;

                

                // KIRMIZI İHTİMALLERİ
                if (renk.Contains("KIRMIZI") && boyut.Contains("BUYUK")) kirmiziBuyuk++;
                else if (renk.Contains("KIRMIZI") && boyut.Contains("ORTA")) kirmiziOrta++;
                else if (renk.Contains("KIRMIZI") && boyut.Contains("KUCUK")) kirmiziKucuk++;

                // YEŞİL İHTİMALLERİ (Güncellendi)
                else if (renk == "YESIL" && boyut == "BUYUK") yesilBuyuk++; 
                else if (renk == "YESIL" && boyut == "ORTA") yesilOrta++;
                else if (renk == "YESIL" && boyut == "KUCUK") yesilKucuk++;

                // MAVİ İHTİMALLERİ
                else if (renk.Contains("MAVI") && boyut.Contains("BUYUK")) maviBuyuk++;
                else if (renk.Contains("MAVI") && boyut.Contains("ORTA")) maviOrta++;
                else if (renk.Contains("MAVI") && boyut.Contains("KUCUK")) maviKucuk++;

                GrafikGuncelle();
            }
        }
        private void GrafikGuncelle()
        {
            chart1.Series["Urunler"].Points.Clear();

            // Kırmızı Sütunları
            chart1.Series["Urunler"].Points.AddXY("Kır-Büyük", kirmiziBuyuk);
            chart1.Series["Urunler"].Points.AddXY("Kır-Orta", kirmiziOrta);
            chart1.Series["Urunler"].Points.AddXY("Kır-Küçük", kirmiziKucuk);

            // Yeşil Sütunları (Güncellendi)
            chart1.Series["Urunler"].Points.AddXY("Yeş-Büyük", yesilBuyuk); // Bu satır eklendi
            chart1.Series["Urunler"].Points.AddXY("Yeş-Orta", yesilOrta);
            chart1.Series["Urunler"].Points.AddXY("Yeş-Küçük", yesilKucuk);

            // Mavi Sütunları
            chart1.Series["Urunler"].Points.AddXY("Mav-Büyük", maviBuyuk);
            chart1.Series["Urunler"].Points.AddXY("Mav-Orta", maviOrta);
            chart1.Series["Urunler"].Points.AddXY("Mav-Küçük", maviKucuk);

            chart1.Update();
        }
    }
}

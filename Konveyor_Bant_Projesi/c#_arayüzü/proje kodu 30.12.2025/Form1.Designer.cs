namespace proje_kodu_30._12._2025
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblBoyut = new System.Windows.Forms.Label();
            this.lblRenk = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlDurum = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.btnMotorDurdur = new System.Windows.Forms.Button();
            this.btnMotorBaslat = new System.Windows.Forms.Button();
            this.cmbRenk = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbBoyut = new System.Windows.Forms.ComboBox();
            this.btnAzaltin = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea5.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.chart1.Legends.Add(legend5);
            this.chart1.Location = new System.Drawing.Point(-1, 0);
            this.chart1.Name = "chart1";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.chart1.Series.Add(series5);
            this.chart1.Size = new System.Drawing.Size(400, 352);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // lblBoyut
            // 
            this.lblBoyut.AutoSize = true;
            this.lblBoyut.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBoyut.Location = new System.Drawing.Point(470, 115);
            this.lblBoyut.Name = "lblBoyut";
            this.lblBoyut.Size = new System.Drawing.Size(79, 29);
            this.lblBoyut.TabIndex = 1;
            this.lblBoyut.Text = "Boyut:";
            // 
            // lblRenk
            // 
            this.lblRenk.AutoSize = true;
            this.lblRenk.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblRenk.Location = new System.Drawing.Point(470, 153);
            this.lblRenk.Name = "lblRenk";
            this.lblRenk.Size = new System.Drawing.Size(75, 29);
            this.lblRenk.TabIndex = 2;
            this.lblRenk.Text = "Renk:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(470, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Bantaki ürün özellikleri";
            // 
            // pnlDurum
            // 
            this.pnlDurum.Location = new System.Drawing.Point(732, 12);
            this.pnlDurum.Name = "pnlDurum";
            this.pnlDurum.Size = new System.Drawing.Size(56, 56);
            this.pnlDurum.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(584, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Bant Durumu:";
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // btnMotorDurdur
            // 
            this.btnMotorDurdur.Location = new System.Drawing.Point(503, 277);
            this.btnMotorDurdur.Name = "btnMotorDurdur";
            this.btnMotorDurdur.Size = new System.Drawing.Size(94, 46);
            this.btnMotorDurdur.TabIndex = 6;
            this.btnMotorDurdur.Text = "MotorDurdur";
            this.btnMotorDurdur.UseVisualStyleBackColor = true;
            this.btnMotorDurdur.Click += new System.EventHandler(this.btnMotorDurdur_Click);
            // 
            // btnMotorBaslat
            // 
            this.btnMotorBaslat.Location = new System.Drawing.Point(670, 277);
            this.btnMotorBaslat.Name = "btnMotorBaslat";
            this.btnMotorBaslat.Size = new System.Drawing.Size(94, 46);
            this.btnMotorBaslat.TabIndex = 7;
            this.btnMotorBaslat.Text = "MotorBaslat";
            this.btnMotorBaslat.UseVisualStyleBackColor = true;
            this.btnMotorBaslat.Click += new System.EventHandler(this.btnMotorBaslat_Click);
            // 
            // cmbRenk
            // 
            this.cmbRenk.FormattingEnabled = true;
            this.cmbRenk.Items.AddRange(new object[] {
            "KIRMIZI",
            "MAVI",
            "YESIL"});
            this.cmbRenk.Location = new System.Drawing.Point(21, 37);
            this.cmbRenk.Name = "cmbRenk";
            this.cmbRenk.Size = new System.Drawing.Size(121, 24);
            this.cmbRenk.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Renk";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(258, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Boyut";
            // 
            // cmbBoyut
            // 
            this.cmbBoyut.FormattingEnabled = true;
            this.cmbBoyut.Items.AddRange(new object[] {
            "KUCUK",
            "ORTA",
            "BUYUK"});
            this.cmbBoyut.Location = new System.Drawing.Point(219, 37);
            this.cmbBoyut.Name = "cmbBoyut";
            this.cmbBoyut.Size = new System.Drawing.Size(121, 24);
            this.cmbBoyut.TabIndex = 11;
            // 
            // btnAzaltin
            // 
            this.btnAzaltin.Location = new System.Drawing.Point(123, 78);
            this.btnAzaltin.Name = "btnAzaltin";
            this.btnAzaltin.Size = new System.Drawing.Size(124, 41);
            this.btnAzaltin.TabIndex = 12;
            this.btnAzaltin.Text = "-1 azaltın";
            this.btnAzaltin.UseVisualStyleBackColor = true;
            this.btnAzaltin.Click += new System.EventHandler(this.btnAzaltin_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAzaltin);
            this.panel1.Controls.Add(this.cmbRenk);
            this.panel1.Controls.Add(this.cmbBoyut);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(-1, 368);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(402, 149);
            this.panel1.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(500, 336);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(360, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "!!!Sensörlerde hata çıkmadığı sürece motoru durdurmayınızz";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 529);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnMotorBaslat);
            this.Controls.Add(this.btnMotorDurdur);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pnlDurum);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblRenk);
            this.Controls.Add(this.lblBoyut);
            this.Controls.Add(this.chart1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label lblBoyut;
        private System.Windows.Forms.Label lblRenk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlDurum;
        private System.Windows.Forms.Label label2;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button btnMotorDurdur;
        private System.Windows.Forms.Button btnMotorBaslat;
        private System.Windows.Forms.ComboBox cmbRenk;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbBoyut;
        private System.Windows.Forms.Button btnAzaltin;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
    }
}


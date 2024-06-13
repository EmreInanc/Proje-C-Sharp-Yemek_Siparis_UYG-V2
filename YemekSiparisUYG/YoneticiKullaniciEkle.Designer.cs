namespace YemekSiparisUYG
{
    partial class YoneticiKullaniciEkle
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.EkleBTN = new System.Windows.Forms.Button();
            this.KullaniciAdiTXT = new System.Windows.Forms.TextBox();
            this.SifreTXT = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.TemizleBTN = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // EkleBTN
            // 
            this.EkleBTN.Location = new System.Drawing.Point(126, 170);
            this.EkleBTN.Name = "EkleBTN";
            this.EkleBTN.Size = new System.Drawing.Size(75, 23);
            this.EkleBTN.TabIndex = 0;
            this.EkleBTN.Text = "Ekle";
            this.EkleBTN.UseVisualStyleBackColor = true;
            this.EkleBTN.Click += new System.EventHandler(this.EkleBTN_Click);
            // 
            // KullaniciAdiTXT
            // 
            this.KullaniciAdiTXT.Location = new System.Drawing.Point(116, 82);
            this.KullaniciAdiTXT.Name = "KullaniciAdiTXT";
            this.KullaniciAdiTXT.Size = new System.Drawing.Size(100, 20);
            this.KullaniciAdiTXT.TabIndex = 2;
            // 
            // SifreTXT
            // 
            this.SifreTXT.Location = new System.Drawing.Point(116, 127);
            this.SifreTXT.Name = "SifreTXT";
            this.SifreTXT.Size = new System.Drawing.Size(100, 20);
            this.SifreTXT.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Yetki";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Kullanıcı Adı";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Sifre";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Personel",
            "Yonetici"});
            this.comboBox1.Location = new System.Drawing.Point(116, 31);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 7;
            // 
            // TemizleBTN
            // 
            this.TemizleBTN.Location = new System.Drawing.Point(49, 379);
            this.TemizleBTN.Name = "TemizleBTN";
            this.TemizleBTN.Size = new System.Drawing.Size(75, 23);
            this.TemizleBTN.TabIndex = 8;
            this.TemizleBTN.Text = "Temizle";
            this.TemizleBTN.UseVisualStyleBackColor = true;
            this.TemizleBTN.Click += new System.EventHandler(this.TemizleBTN_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(713, 379);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Geri Git";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // YoneticiKullaniciEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 428);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TemizleBTN);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SifreTXT);
            this.Controls.Add(this.KullaniciAdiTXT);
            this.Controls.Add(this.EkleBTN);
            this.Name = "YoneticiKullaniciEkle";
            this.Text = "YoneticiKullaniciEkle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button EkleBTN;
        private System.Windows.Forms.TextBox KullaniciAdiTXT;
        private System.Windows.Forms.TextBox SifreTXT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button TemizleBTN;
        private System.Windows.Forms.Button button1;
    }
}
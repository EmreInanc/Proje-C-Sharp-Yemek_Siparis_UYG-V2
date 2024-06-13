using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YemekSiparisUYG
{
    public partial class YoneticiKullaniciEkle : Form
    {
        public YoneticiKullaniciEkle()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }
        private string sifrele256Bit(string data)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] deger = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(data));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in deger)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        YoneticiKullanicilariDuzernle ykd = new YoneticiKullanicilariDuzernle();
        private void EkleBTN_Click(object sender, EventArgs e)
        {
            try
            {

                string yetki = comboBox1.Text;
                string kullaniciAdi = sifrele256Bit(KullaniciAdiTXT.Text);
                string sifre = sifrele256Bit(SifreTXT.Text);
                string query = $"INSERT INTO Y_yetkiler(yetki,kullanici_adi,sifre) VALUES " +
                    $"('{yetki}','{kullaniciAdi}','{sifre}');";
                SqlConnection con1 = new SqlConnection(Connection1.ConnectionString1);
                SqlCommand cmd1 = new SqlCommand(query, con1);
                cmd1.Connection.Open();
                cmd1.ExecuteNonQuery();
                cmd1.Connection.Close();
                Temizle();
                MessageBox.Show("Ekleme Başarılı");
                ykd.DataYenile();
            }
            catch(Exception ex) { MessageBox.Show("Ekleme hatası" + ex);  }
        }
        private void Temizle() 
        {
            comboBox1.SelectedIndex=0;
            KullaniciAdiTXT.Text = "";
            SifreTXT.Text = "";
        }

        private void TemizleBTN_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            YoneticiKullanicilariDuzernle openForm = Application.OpenForms.OfType<YoneticiKullanicilariDuzernle>().FirstOrDefault();
            if (openForm != null)
            {
                openForm.BringToFront();
                openForm.Focus();
                openForm.Show();
                this.Close();
            }
            else
            {
                openForm = new YoneticiKullanicilariDuzernle();
                openForm.Show();
                this.Close();
            }
        }


    }
}

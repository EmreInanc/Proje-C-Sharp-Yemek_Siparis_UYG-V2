using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Security.Policy;

namespace YemekSiparisUYG
{
    public partial class GirisFRM : Form
    {
        public GirisFRM()
        {
            InitializeComponent();
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

        private void button1_Click(object sender, EventArgs e)
        {
            string HashKD = sifrele256Bit(textBox1.Text);
            string HashSifre = sifrele256Bit(textBox2.Text);

            string query = "SELECT yetki, kullanici_adi, sifre " +
                           "FROM Y_yetkiler " +
                           "WHERE kullanici_adi = @kd AND sifre = @sifre";

            using (SqlConnection con = new SqlConnection(Connection1.ConnectionString1))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.Add("@kd", SqlDbType.VarChar).Value = HashKD;
                cmd.Parameters.Add("@sifre", SqlDbType.VarChar).Value = HashSifre;

                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string getYetki = reader["yetki"].ToString();
                        if (getYetki == "Yonetici")
                        {
                            this.Hide();
                            MessageBox.Show("Giriş Başarılı - Yönetici");
                            YoneticiUrunDuzenleFRM YonUrunDuzen = new YoneticiUrunDuzenleFRM();
                            YonUrunDuzen.Show();
                        }
                        else if (getYetki == "Personel")
                        {
                            this.Hide();
                            SiparisFRM siparisFRM = new SiparisFRM();
                            siparisFRM.Show();
                            MessageBox.Show("Giriş Başarılı - Personel");
                        }
                        else
                        {
                            MessageBox.Show("Yetkisiz giriş.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı adı veya şifre yanlış.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata var: " + ex.Message);
                }
            }
        }



        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string sonKod = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + textBox3.Text + ";Integrated Security=True;";
            Connection1.ConnectionString1 = sonKod;
            SqlConnection connection = new SqlConnection(sonKod);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Enabled == false)
            {
                textBox3.Enabled = true;
                button2.Text = "🔓";
            }
            else
            {
                textBox3.Enabled = false;
                button2.Text = "🔐";
            }
        }

        private void GirisFRM_Load(object sender, EventArgs e)
        {
            //textBox3.Text = $"C:\\ProjeFoto\\vt\\MyVt.mdf";
            textBox3.Text = $"C:\\Users\\emrec\\OneDrive\\Belgeler\\Visual Studio 2022\\YemekSiparisUYG\\MyVt.mdf";
            string sonKod = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + textBox3.Text + ";Integrated Security=True;";
            Connection1.ConnectionString1 = sonKod;
            textBox3.Enabled = false;
            textBox3.AutoSize = true;
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            string sonKod = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + textBox3.Text + ";Integrated Security=True;";
            try
            {
                SqlConnection connection = new SqlConnection(sonKod);
                connection.Open();
                MessageBox.Show("veritabanı bağlantınız başarılı");
                textBox3.Enabled = false;
                connection.Close();
            }
            catch
            {
                MessageBox.Show("veritabanı bağlantınız başarısız");
            }
        }

    }
}

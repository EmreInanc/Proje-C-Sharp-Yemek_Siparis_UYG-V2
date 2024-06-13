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
using System.Windows.Input;

namespace YemekSiparisUYG
{
    public partial class Sepet : Form
    {
        private string queryString = "SELECT COUNT(*) FROM GS_guncel_sepet";
		static string connectionString = Connection1.ConnectionString();
		SqlConnection connection = new SqlConnection(connectionString);




        private void button4_Click(object sender, EventArgs e)
        {//LİSTEYİ TEMİZLE
            try { 
            string query = "DELETE FROM GS_guncel_sepet";

            SqlCommand command = new SqlCommand(query, connection);
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
            MessageBox.Show("ürünler silindi");
            }
		    catch (Exception ex){ MessageBox.Show("hata:" +ex); }
        }








        public void Sepet_Load(object sender1, EventArgs e1)
        {

        }

        public Sepet()
        {
            InitializeComponent();

            try
            {

                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                MessageBox.Show("count değeri:" + count);
                connection.Close();


                for (int i = 0; i < count; i++)
                {
                    this.groupBox1 = new System.Windows.Forms.GroupBox();

                    GroupBox groupBox = new GroupBox();
                    groupBox.Text = "Grup" + (i + 1).ToString();
                    groupBox.Size = new System.Drawing.Size(347, 126);
                    groupBox.Location = new System.Drawing.Point(20, 20 + i * 120); // Yerleştirme işlemi

                    // Grup kutusunu forma ekleme
                    this.panel1.Controls.Add(groupBox);
                    //çalışıyor group box


                    /*satın alma butonu*/
                    // sepete ekleme butonu
                    // button1
                    // 
                    Button button0 = new Button();
                    button0.Location = new System.Drawing.Point(255, 99);
                    button0.Size = new System.Drawing.Size(91, 25);
                    button0.TabIndex = 3;
                    button0.Text = "siparişi Al";
                    button0.UseVisualStyleBackColor = true;
                    groupBox.Controls.Add(button0);

                    //çalışıyor Picture box
                    this.pictureBox1 = new System.Windows.Forms.PictureBox();
                    PictureBox pictureBox00 = new PictureBox();
                    pictureBox00.Location = new Point(12, 19);
                    pictureBox00.Size = new Size(120, 106);
                    pictureBox00.BackColor = Color.DarkGreen;
                    pictureBox00.SizeMode = PictureBoxSizeMode.StretchImage; // Resmi PictureBox boyutuna uyacak şekilde ayarlar
                                                                             //this.pictureBox1.Image = global::YemekSiparisUYG.Properties.Resources.içecekler;
                    groupBox.Controls.Add(pictureBox00);


                    // Label oluşturma ad
                    Label label0 = new Label();

                    label0.Location = new Point(150, 20); // Label'ı PictureBox'a göre konumlandırma
                    label0.AutoSize = true; // Otomatik boyutlandırma
                    groupBox.Controls.Add(label0); // Label'ı GroupBox'a ekler


                    // Label oluşturma aciklama
                    Label label00 = new Label();

                    label00.Location = new Point(150, 50); // Label'ı PictureBox'a göre konumlandırma
                    label00.AutoSize = true; // Otomatik boyutlandırma
                    groupBox.Controls.Add(label00); // Label'ı GroupBox'a ekler


                    // Label oluşturma ve fiyat
                    Label label000 = new Label();

                    label000.Location = new Point(150, 100); // Label'ı PictureBox'a göre konumlandırma
                    label000.AutoSize = true; // Otomatik boyutlandırma
                    groupBox.Controls.Add(label000); // Label'ı GroupBox'a ekler



                    // 
                    // button2+
                    // 
                    Button button00 = new Button();
                    button00.Location = new System.Drawing.Point(302, 72);
                    button00.Size = new System.Drawing.Size(19, 21);
                    button00.TabIndex = 4;
                    button00.Text = "+";
                    button00.UseVisualStyleBackColor = true;
                    // 
                    // button3-
                    // 
                    Button button000 = new Button();
                    button000.Location = new System.Drawing.Point(255, 72);
                    button000.Size = new System.Drawing.Size(19, 21);
                    button000.TabIndex = 5;
                    button000.Text = "-";
                    button000.UseVisualStyleBackColor = true;

                    groupBox.Controls.Add(button00);
                    groupBox.Controls.Add(button000);


                    TextBox textBox0 = new TextBox();
                    textBox0.Enabled = false;
                    textBox0.Location = new System.Drawing.Point(281, 72);
                    textBox0.Size = new System.Drawing.Size(15, 20);
                    textBox0.TabIndex = 6;

                    groupBox.Controls.Add(textBox0);



                    //BURADA KALDIM

                    //textbox tan + , - butonunu ayarlıcam









                    string query2 = @"SELECT GS_urun_image, GS_urun_ad, GS_urun_aciklama, GS_urun_fiyat, GS_urun_adet FROM ( SELECT GS_urun_image, GS_urun_ad, GS_urun_aciklama, GS_urun_fiyat, GS_urun_adet, ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS RowNum FROM GS_guncel_sepet ) AS TempTable WHERE RowNum = @Offset;";

                    SqlCommand Mcommand = new SqlCommand(query2, connection);

                    int offsetValue = i + 1;  // i + 1, ikinci sıradaki kaydı almak için
                    Mcommand.Parameters.AddWithValue("@Offset", offsetValue);

                    connection.Open();
                    SqlDataReader reader = Mcommand.ExecuteReader();

                    if (reader.Read())
                    {
                        // Sütunları sırasıyla al
                        string urunImage = reader["GS_urun_image"].ToString();
                        string urunAdi = reader["GS_urun_ad"].ToString();
                        string urunAciklama = reader["GS_urun_aciklama"].ToString();
                        string urunFiyat = reader["GS_urun_fiyat"].ToString();
                        string urunAdet = reader["GS_urun_adet"].ToString();

                        label000.Text = urunFiyat;
                        textBox0.Text = urunAdet.ToString();
                        pictureBox00.ImageLocation = urunImage;
                        label0.Text = urunAdi;
                        label00.Text = urunAciklama;
                    }
                    connection.Close();


                    int BirimFiyat = Convert.ToInt32(label000.Text);

                    //sepete ekleme
                    button0.Click += new System.EventHandler(Button_ListeyeEkle);

                    button00.Click += new System.EventHandler(button2_Click);
                    //+
                    button000.Click += new System.EventHandler(button3_Click);
                    //-
                    void Button_ListeyeEkle(object sender, EventArgs e)
                    {//siparişi al butonu tek ürün
                        string query8 = "INSERT INTO SL_siparis_listesi " +
                          "(SL_urun_image, SL_urun_adi, SL_urun_aciklama,SL_urun_Fiyat,SL_urun_adet) " +
                          "VALUES (@urunimage,@urunad,@urunaciklama,@urunfiyat,@urunadet);" +
                          "DELETE FROM GS_guncel_sepet WHERE GS_urun_ad=@urunad;";
                        SqlCommand Mcommand8 = new SqlCommand(query8, connection);
                        Mcommand8.Parameters.AddWithValue("@urunimage", pictureBox00.ImageLocation);
                        Mcommand8.Parameters.AddWithValue("@urunad", label0.Text);
                        Mcommand8.Parameters.AddWithValue("@urunaciklama", label00.Text);
                        Mcommand8.Parameters.AddWithValue("@urunadet", textBox0.Text);
                        Mcommand8.Parameters.AddWithValue("@urunfiyat", label000.Text);
                        Mcommand8.Connection.Open();
                        Mcommand8.ExecuteNonQuery();
                        Mcommand8.Connection.Close();

                        MessageBox.Show("başarılı");

                    }


                    void button2_Click(object sender, EventArgs e)
                    {//+

                        BirimFiyat = Convert.ToInt32(label000.Text);
                        int adet = Convert.ToInt32(textBox0.Text);
                        int SonFiyat1 = BirimFiyat / adet;
                        textBox0.Text = adet.ToString();
                        adet = adet + 1;

                        if (adet > 15)
                        {
                            MessageBox.Show("adet sayısı 15 dan büyük olamaz");
                            adet = 15;
                        }
                        else
                        {
                            int sonucFiyat = BirimFiyat + SonFiyat1;
                            label000.Text = sonucFiyat.ToString();
                            textBox0.Text = adet.ToString();

							SqlCommand Com1 = new SqlCommand("" +
								"UPDATE GS_guncel_sepet " +
								"SET GS_urun_adet = @adet , GS_urun_fiyat=@fiyat " +
								"where GS_urun_ad = @urunad ;", connection);
							Com1.Connection.Open();
							Com1.Parameters.AddWithValue("@urunad", label0.Text);
							Com1.Parameters.AddWithValue("@adet", textBox0.Text);
							Com1.Parameters.AddWithValue("@fiyat", label000.Text);
							Com1.ExecuteNonQuery();
							Com1.Connection.Close();
							MessageBox.Show("başarılı");

						}



                    }


                    /*

                            BirimFiyat = Convert.ToInt32(label000.Text);
                            int adet = Convert.ToInt32(textBox0.Text);                       
                           int SonFiyat1 = BirimFiyat / adet;
                           adet = adet + 1;
                           int sonucFiyat = BirimFiyat + SonFiyat1;
                           label000.Text = sonucFiyat.ToString();
                           textBox0.Text = adet.ToString();


                     */
                    void button3_Click(object sender, EventArgs e)
                    {//-


                        BirimFiyat = Convert.ToInt32(label000.Text);
                        int adet = Convert.ToInt32(textBox0.Text);
                        int SonFiyat1 = BirimFiyat / adet;
                        textBox0.Text = adet.ToString();
                        adet = adet - 1;

                        if (adet < 1)
                        {
                            MessageBox.Show("adet sayısı 1 den küçük olamaz");
                            adet = 15;
                        }
                        else
                        {
                            int sonucFiyat = BirimFiyat - SonFiyat1;
                            label000.Text = sonucFiyat.ToString();
                            textBox0.Text = adet.ToString();

                        }

                        SqlCommand Com1 = new SqlCommand("" +
                            "UPDATE GS_guncel_sepet " +
                            "SET GS_urun_adet = @adet , GS_urun_fiyat=@fiyat " +
                            "where GS_urun_ad = @urunad ;", connection);
                        Com1.Connection.Open();
                        Com1.Parameters.AddWithValue("@urunad", label0.Text);
						Com1.Parameters.AddWithValue("@adet", textBox0.Text);
						Com1.Parameters.AddWithValue("@fiyat", label000.Text);
						Com1.ExecuteNonQuery();
                        Com1.Connection.Close();
                        MessageBox.Show("başarılı");


                    }//buttom








                }//for
			}
			catch (Exception ex){ MessageBox.Show("hata:" +ex); }

}

		private void button1_Click(object sender, EventArgs e)
		{//sipariş i tamamla
            try { 
			string mquery = "INSERT INTO SL_siparis_listesi" +
                " (SL_urun_image, SL_urun_adi, SL_urun_aciklama, SL_urun_Fiyat, SL_urun_adet) " +
                "SELECT GS_urun_image, GS_urun_ad, GS_urun_aciklama, GS_urun_Fiyat, GS_urun_adet " +
                "FROM GS_guncel_sepet;" +
				"Delete From GS_guncel_sepet;";
			SqlCommand SqlCommand1 = new SqlCommand(mquery, connection);
			SqlCommand1.Connection.Open();
			var rowsAffected = SqlCommand1.ExecuteNonQuery();
			SqlCommand1.Connection.Close();
			MessageBox.Show("Affected rows: " + rowsAffected);
			MessageBox.Show("Sepet Temizlendi");
			}
			catch (Exception ex) 
            {
                MessageBox.Show("hata:" + ex); 
            }

		}
	}





}
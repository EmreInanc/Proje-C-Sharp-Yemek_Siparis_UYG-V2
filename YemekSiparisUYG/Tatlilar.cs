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

namespace YemekSiparisUYG
{
	public partial class Tatlilar : Form
	{
		public string queryString = "SELECT COUNT(*) FROM T_urunler";
		static string connectionString = Connection1.ConnectionString();
		//      static string dbFileName = "MyVt.mdf"; // Veritabanı dosya adı
		//      static string dataDirectory = AppDomain.CurrentDomain.BaseDirectory; // Uygulama dizini

		//static string connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={dataDirectory}{dbFileName};Integrated Security=True";
		public Tatlilar()
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
					button0.Text = "Sepete Ekle";
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



					
											
							string query2 = @"SELECT T_urun_image, T_urun_adi, T_urun_aciklama, T_urun_Fiyat, T_urun_adet FROM ( SELECT T_urun_image, T_urun_adi, T_urun_aciklama, T_urun_Fiyat, T_urun_adet, ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS RowNum FROM T_urunler ) AS TempTable WHERE RowNum = @Offset;";

							SqlCommand Mcommand = new SqlCommand(query2, connection);
						
							int offsetValue = i + 1;  // i + 1, ikinci sıradaki kaydı almak için
							Mcommand.Parameters.AddWithValue("@Offset", offsetValue);

							connection.Open();
							SqlDataReader reader = Mcommand.ExecuteReader();
							
								if (reader.Read())
								{
									// Sütunları sırasıyla al
									string urunImage = reader["T_urun_image"].ToString();
									string urunAdi = reader["T_urun_adi"].ToString();
									string urunAciklama = reader["T_urun_aciklama"].ToString();
									string urunFiyat = reader["T_urun_Fiyat"].ToString();
									string urunAdet = reader["T_urun_adet"].ToString();

									label000.Text = urunFiyat;
									textBox0.Text = urunAdet.ToString();
									pictureBox00.ImageLocation = urunImage;
									label0.Text = urunAdi;
									label00.Text = urunAciklama;
							
									connection.Close();
								}





					int BirimFiyat = Convert.ToInt32(label000.Text);
					//sepete ekleme
					button0.Click += new System.EventHandler(Button_SepeteEkle);
					//-
					button00.Click += new System.EventHandler(button2_Click);
					//+
					button000.Click += new System.EventHandler(button3_Click);

					void Button_SepeteEkle(object sender, EventArgs e)
					{
						string query8 = "INSERT INTO GS_guncel_sepet " +
						  "(GS_urun_image, GS_urun_ad, GS_urun_aciklama,GS_urun_fiyat,GS_urun_adet) " +
						  "VALUES (@urunimage,@urunad,@urunaciklama,@urunfiyat,@urunadet);";
						SqlCommand Mcommand8 = new SqlCommand(query8, connection);
						Mcommand8.Parameters.AddWithValue("@urunimage", pictureBox00.ImageLocation);
						Mcommand8.Parameters.AddWithValue("@urunad", label0.Text);
						Mcommand8.Parameters.AddWithValue("@urunaciklama", label00.Text);
						Mcommand8.Parameters.AddWithValue("@urunadet", textBox0.Text);
						Mcommand8.Parameters.AddWithValue("@urunfiyat", label000.Text);
						Mcommand8.Connection.Open();
						Mcommand8.ExecuteNonQuery();
						Mcommand8.Connection.Close();
						MessageBox.Show("Sepete Eklendi");

					}



					void button2_Click(object sender, EventArgs e)
					{


						int adet = Convert.ToInt32(textBox0.Text);


						adet = adet + 1;


						textBox0.Text = adet.ToString();
						if (adet >= 15)
						{
							MessageBox.Show("adet sayısı 15 dan büyük olamaz");
							adet = 15;
						}






						int sonuc = adet * BirimFiyat;
						label000.Text = Convert.ToString(sonuc);




					}



					void button3_Click(object sender, EventArgs e)
					{
						int adet = Convert.ToInt32(textBox0.Text);


						adet = adet - 1;


						textBox0.Text = adet.ToString();
						if (adet == 0)
						{
							MessageBox.Show("adet sayısı 0 dan dan küçük olamaz");
							adet++;

						}

						int sonuc = adet * BirimFiyat;
						label000.Text = Convert.ToString(sonuc);
						textBox0.Text = adet.ToString(); ;
					}



					//SEPETE EKLE YAPILDI ŞİMDİ SEPET SAYFASINI YAPICAM
					//KODLAR DA BİR SORUN YOOK





				}//for

			}
			catch (Exception ex)
			{ MessageBox.Show("Hata mesajı" + ex); }

		}

	}
}

 
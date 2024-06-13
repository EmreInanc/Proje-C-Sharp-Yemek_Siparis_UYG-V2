using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YemekSiparisUYG
{
	public partial class Listeleler : Form
	{
		string adLabeli;
		private string queryString = "SELECT COUNT(*) FROM SL_siparis_listesi";

		static string connectionString = Connection1.ConnectionString();
		SqlConnection connection = new SqlConnection(connectionString);
		public Listeleler()
		{
			try {
			InitializeComponent();



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
				button0.Text = "Teslim Edildi";
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
				System.Windows.Forms.Label label0 = new System.Windows.Forms.Label();

				label0.Location = new Point(150, 20); // Label'ı PictureBox'a göre konumlandırma
				label0.AutoSize = true; // Otomatik boyutlandırma
				groupBox.Controls.Add(label0); // Label'ı GroupBox'a ekler


				// Label oluşturma aciklama
				System.Windows.Forms.Label label00 = new System.Windows.Forms.Label();

				label00.Location = new Point(150, 50); // Label'ı PictureBox'a göre konumlandırma
				label00.AutoSize = true; // Otomatik boyutlandırma
				groupBox.Controls.Add(label00); // Label'ı GroupBox'a ekler


				// Label oluşturma ve fiyat
				System.Windows.Forms.Label label000 = new System.Windows.Forms.Label();

				label000.Location = new Point(150, 100); // Label'ı PictureBox'a göre konumlandırma
				label000.AutoSize = true; // Otomatik boyutlandırma
				groupBox.Controls.Add(label000); // Label'ı GroupBox'a ekler



				TextBox textBox0 = new TextBox();
				textBox0.Enabled = false;
				textBox0.Location = new System.Drawing.Point(281, 72);
				textBox0.Size = new System.Drawing.Size(15, 20);
				textBox0.TabIndex = 6;

				groupBox.Controls.Add(textBox0);

				string query2 = @"SELECT SL_urun_image, SL_urun_adi, SL_urun_aciklama, SL_urun_Fiyat, SL_urun_adet 
				FROM ( SELECT SL_urun_image, SL_urun_adi, SL_urun_aciklama, SL_urun_Fiyat, SL_urun_adet, 
				ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS RowNum FROM SL_siparis_listesi ) 
				AS TempTable WHERE RowNum = @Offset;";

				SqlCommand Mcommand = new SqlCommand(query2, connection);

				int offsetValue = i + 1; 
				Mcommand.Parameters.AddWithValue("@Offset", offsetValue);

				connection.Open();
				SqlDataReader reader = Mcommand.ExecuteReader();

				if (reader.Read())
				{

					string urunImage = reader["SL_urun_image"].ToString();
					string urunAdi = reader["SL_urun_adi"].ToString();
					string urunAciklama = reader["SL_urun_aciklama"].ToString();
					string urunFiyat = reader["SL_urun_Fiyat"].ToString();
					string urunAdet = reader["SL_urun_adet"].ToString();

					label000.Text = urunFiyat;
					textBox0.Text = urunAdet.ToString();
					pictureBox00.ImageLocation = urunImage.ToString();
					label0.Text = urunAdi.ToString();
					label00.Text = urunAciklama.ToString();
				}
				connection.Close();












				adLabeli = label0.Text;
				button0.Click += new System.EventHandler(UrunTeslemEdildi1);

				void UrunTeslemEdildi1(object sender, EventArgs e)
				{
					string query8 = "DELETE FROM SL_siparis_listesi WHERE SL_urun_adi=@urunad;";
					SqlCommand Mcommand8 = new SqlCommand(query8, connection);
					Mcommand8.Parameters.AddWithValue("@urunad", label0.Text);

					Mcommand8.Connection.Open();
					Mcommand8.ExecuteNonQuery();
					Mcommand8.Connection.Close();
					MessageBox.Show("urun teslim edildi Başarılı");
					Listeleler listeleler = new Listeleler();

				}


			}//for


			}
			catch (Exception ex){ MessageBox.Show("hata:" +ex); }
		}

		private void button4_Click(object sender, EventArgs e)
		{
			try
			{
				string query8 = "DELETE FROM SL_siparis_listesi;";
				SqlCommand Mcommand8 = new SqlCommand(query8, connection);
				Mcommand8.Parameters.AddWithValue("@urunad", adLabeli);

				Mcommand8.Connection.Open();
				Mcommand8.ExecuteNonQuery();
				Mcommand8.Connection.Close();
				MessageBox.Show("Temizleme Başarılı");
			}
			catch (Exception ex)
			{ MessageBox.Show("Hata mesajı" + ex); }
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				string query8 = "DELETE FROM SL_siparis_listesi;";
				SqlCommand Mcommand8 = new SqlCommand(query8, connection);
				Mcommand8.Parameters.AddWithValue("@urunad", adLabeli);

				Mcommand8.Connection.Open();
				Mcommand8.ExecuteNonQuery();
				Mcommand8.Connection.Close();
				MessageBox.Show("Sepetin hepsi teslim edildi");
			}
			catch (Exception ex)
			{ MessageBox.Show("Hata mesajı" + ex); }

		}

	}

}





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
    public partial class YoneticiKullanicilariDuzernle : Form
    {
        public YoneticiKullanicilariDuzernle()
        {
            InitializeComponent();
        }

        private void DTVeriSil(DataGridView dt, string table, string columnName)
        {

            if (dt.SelectedRows.Count > 0)
            {

                int rowIndex = dt.SelectedRows[0].Index;
                DataGridViewColumn ikinciSutun = dt.Columns[1];
                string ikinciSutunBasligi = ikinciSutun.HeaderText;

                string DTHeaderKullaniciID = dt.Columns[0].HeaderText;
                string a = dt.SelectedRows[0].Cells[0].Value.ToString();
                string query = $"DELETE FROM {table} WHERE {DTHeaderKullaniciID} = @columnValue;";
                using (SqlConnection connection = new SqlConnection(Connection1.ConnectionString1))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@columnValue", columnName);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            dt.Rows.RemoveAt(rowIndex);
                            DataYenile();
                        }
                        else
                        {
                            MessageBox.Show("Veri veritabanından silinemedi.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz satırı seçin.");
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string Column = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                DTVeriSil(dataGridView1, "Y_yetkiler", Column);
                DataYenile();
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz satırı seçin.");
            }
        }

        private void GeriGitBTN_Click(object sender, EventArgs e)
        {
            YoneticiUrunDuzenleFRM openForm = Application.OpenForms.OfType<YoneticiUrunDuzenleFRM>().FirstOrDefault();
            if (openForm != null)
            {
                openForm.BringToFront();
                openForm.Focus();
                openForm.Show();
            }
            else
            {
                openForm = new YoneticiUrunDuzenleFRM();
                openForm.Show();
            }
        }

        private void YoneticiKullanicilariDuzernle_Load(object sender, EventArgs e)
        {
            TabloVerisiniAl("Y_yetkiler");
            this.OnActivated(e);
            DataTable dataTable1 = TabloVerisiniAl("Y_yetkiler");
            dataGridView1.DataSource = dataTable1;
            dataGridView1.Update();

        }

        private DataTable TabloVerisiniAl(string table)
        {

            string query = "SELECT * FROM " + table;

            using (SqlConnection connection = new SqlConnection(Connection1.ConnectionString1))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }
        public void DataCellValue(object sender, DataGridViewCellEventArgs e, DataGridViewRow row, string table, DataGridView dt)
        {
            if (row != null)
            {
                string DTHeaderKullaniciID = dt.Columns[0].HeaderText;
                string DTHeaderYetki = dt.Columns[1].HeaderText;
                string DTHeaderKullaniciAdi = dt.Columns[2].HeaderText;
                string DTHeaderSifre = dt.Columns[3].HeaderText;


                string row0ID = row.Cells[0].Value.ToString();
                string row1Yetki = row.Cells[1].Value.ToString();
                string row2KullaniciAdi = row.Cells[2].Value.ToString();
                string row3Sifre = row.Cells[3].Value.ToString();

                //burda kaldım
                string query = $"UPDATE {table} SET " +
                    $"{DTHeaderYetki}=@Row1Yetki," +
                    $" {DTHeaderKullaniciAdi}=@Row2KullaniciAdi," +
                    $"{DTHeaderSifre}=@Row3Sifre" +
                    $" WHERE {DTHeaderKullaniciID}=@row0ID";


                using (SqlConnection connection = new SqlConnection(Connection1.ConnectionString1))
                {
                    connection.Open();
                    SqlCommand Com1 = new SqlCommand(query, connection);
                    Com1.Parameters.AddWithValue("@Row0ID", row0ID);
                    Com1.Parameters.AddWithValue("@Row1Yetki", row1Yetki);
                    Com1.Parameters.AddWithValue("@Row2KullaniciAdi", row2KullaniciAdi);
                    Com1.Parameters.AddWithValue("@Row3Sifre", row3Sifre);
                    if (row1Yetki == "Yonetici" || row1Yetki == "Personel")
                    {
                        Com1.ExecuteNonQuery(); MessageBox.Show("Değeri Değişti");
                    }
                    else { MessageBox.Show("lütfen yetkiyi Yönetici veya Personel olarak giriniz");  }
                    
                }


                DataYenile();
            }
            else
            {
                MessageBox.Show("Satır nesnesi boş.");
            }




        }

        public void DataYenile()
        {
            dataGridView1.DataSource = null;
            YoneticiKullanicilariDuzernle_Load(null, null);
        }




        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row= dataGridView1.Rows[e.RowIndex];
            DataCellValue(sender,e,row,"Y_yetkiler", dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataYenile();
        }

        private void EkleBTN_Click(object sender, EventArgs e)
        {
            YoneticiKullaniciEkle openForm = Application.OpenForms.OfType<YoneticiKullaniciEkle>().FirstOrDefault();
            if (openForm != null)
            {
                openForm.BringToFront();
                openForm.Focus();
                openForm.Show();
            }
            else
            {
                openForm = new YoneticiKullaniciEkle();
                openForm.Show();
            }
        }


    }
}

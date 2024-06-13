using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YemekSiparisUYG
{
    public partial class YoneticiUrunDuzenleFRM : Form
    {
        public YoneticiUrunDuzenleFRM()
        {
            InitializeComponent();
        }

        public void DataYenile()
        {
            dataGridView1_Donerler.DataSource = null;
            dataGridView2_Iskenderler.DataSource = null;
            dataGridView3_Iicecekler.DataSource = null;
            dataGridView4_Tatlilar.DataSource = null;
            YoneticiUrunDuzenleFRM_Load(null, null);
        }
        public void YoneticiUrunDuzenleFRM_Load(object sender, EventArgs e)
        {
            this.OnActivated(e);
            DataTable dataTable1 = TabloVerisiniAl("D_urunler");
            dataGridView1_Donerler.DataSource = dataTable1;

            DataTable dataTable2 = TabloVerisiniAl("Ii_urunler");
            dataGridView2_Iskenderler.DataSource = dataTable2;

            DataTable dataTable3 = TabloVerisiniAl("I_urunler");
            dataGridView3_Iicecekler.DataSource = dataTable3;


            DataTable dataTable4 = TabloVerisiniAl("T_urunler");
            dataGridView4_Tatlilar.DataSource = dataTable4;


            dataGridView1_Donerler.Update();
            dataGridView2_Iskenderler.Update();
            dataGridView3_Iicecekler.Update();
            dataGridView4_Tatlilar.Update();

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

        private void DnrSil_Click(object sender, EventArgs e)
        {
            if (dataGridView1_Donerler.SelectedRows.Count > 0)
            {
                string Column = dataGridView1_Donerler.SelectedRows[0].Cells[1].Value.ToString();
                DTVeriSil(dataGridView1_Donerler, "D_urunler", Column);
                DataYenile();
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz satırı seçin.");
            }
        }



        private void DTVeriSil(DataGridView dt, string table, string columnName)
        {

            if (dt.SelectedRows.Count > 0)
            {

                int rowIndex = dt.SelectedRows[0].Index;
                DataGridViewColumn ikinciSutun = dt.Columns[1];
                string ikinciSutunBasligi = ikinciSutun.HeaderText;
                string query = $"DELETE FROM {table} WHERE {ikinciSutunBasligi} = @columnValue;";
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
                            YoneticiUrunDuzenleFRM_Load(null, null);
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

        





        

        private void IskenderleSil_Click(object sender, EventArgs e)
        {
            if (dataGridView2_Iskenderler.SelectedRows.Count > 0)
            {
                string Column = dataGridView2_Iskenderler.SelectedRows[0].Cells[1].Value.ToString();
                DTVeriSil(dataGridView2_Iskenderler, "Ii_urunler", Column);
                DataYenile();
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz satırı seçin.");
            }

        }

        private void IceceklerSil_Click(object sender, EventArgs e)
        {//ekleBtn
            if (dataGridView3_Iicecekler.SelectedRows.Count > 0)
            {
                string Column = dataGridView3_Iicecekler.SelectedRows[0].Cells[1].Value.ToString();
                DTVeriSil(dataGridView3_Iicecekler, "I_urunler", Column);
                DataYenile();
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz satırı seçin.");
            }

        }

        private void TatlilarSil_Click(object sender, EventArgs e)
        {
            if (dataGridView4_Tatlilar.SelectedRows.Count > 0)
            {
                string Column = dataGridView4_Tatlilar.SelectedRows[0].Cells[1].Value.ToString();
                DTVeriSil(dataGridView4_Tatlilar, "T_urunler", Column);
                DataYenile();
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz satırı seçin.");
            }
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {

            YoneticiUrunEkle openForm = Application.OpenForms.OfType<YoneticiUrunEkle>().FirstOrDefault();
            if (openForm != null)
            {
                openForm.BringToFront();
                openForm.Focus();
                openForm.Show();
            }
            else
            {
                openForm = new YoneticiUrunEkle();
                openForm.Show();
            }
        }

        private void YenileBTN_Click(object sender, EventArgs e)
        {
            DataYenile();
            this.Invalidate();
            this.Refresh();

        }


        private void dataGridView1_Donerler_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1_Donerler.Rows[e.RowIndex];
            DataCellValue(sender,e, row, "D_urunler",dataGridView1_Donerler);
        }
        public void DataCellValue(object sender, DataGridViewCellEventArgs e, DataGridViewRow row, string table, DataGridView dt)
        {
            try
            {
                if (row != null)
                {
                    string DTHeaderID = dt.Columns[0].HeaderText;
                    string DTHeaderImage = dt.Columns[1].HeaderText;
                    string DTHeaderAd = dt.Columns[2].HeaderText;
                    string DTHeaderAciklama = dt.Columns[3].HeaderText;
                    string DTHeaderFiyat = dt.Columns[4].HeaderText;
                    string DTHeaderAdet = dt.Columns[5].HeaderText;

                    string row0ID = row.Cells[0].Value.ToString();
                    string row1Image = row.Cells[1].Value.ToString();
                    string row2Ad = row.Cells[2].Value.ToString();
                    string row3Aciklama = row.Cells[3].Value.ToString();
                    string row4Fiyat = row.Cells[4].Value.ToString();
                    string row5Adet = row.Cells[5].Value.ToString();
                    //burda kaldım
                    string query = $"UPDATE {table} SET {DTHeaderImage}=@Row1Image, {DTHeaderAd}=@Row2Ad,{DTHeaderAciklama}=@Row3Aciklama, {DTHeaderFiyat}=@Row4Fiyat, {DTHeaderAdet}=@Row5Adet WHERE {DTHeaderID}=@Row0ID";


                    using (SqlConnection connection = new SqlConnection(Connection1.ConnectionString1))
                    {
                        connection.Open();
                        SqlCommand Com1 = new SqlCommand(query, connection);
                        Com1.Parameters.AddWithValue("@Row0ID", row0ID);
                        Com1.Parameters.AddWithValue("@Row1Image", row1Image);
                        Com1.Parameters.AddWithValue("@Row2Ad", row2Ad);
                        Com1.Parameters.AddWithValue("@Row3Aciklama", row3Aciklama);
                        Com1.Parameters.AddWithValue("@Row4Fiyat", row4Fiyat);
                        Com1.Parameters.AddWithValue("@Row5Adet", row5Adet);

                        Com1.ExecuteNonQuery();
                    }

                    MessageBox.Show("Değeri Değişti");
                    DataYenile();
                }
                else
                {
                    MessageBox.Show("Satır nesnesi boş.");
                }
            }
            catch (Exception ex) { MessageBox.Show("değer değiştirilemedi"+ex); }



        }

        private void dataGridView2_Iskenderler_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView2_Iskenderler.Rows[e.RowIndex];
            DataCellValue(sender, e, row, "Ii_urunler", dataGridView2_Iskenderler);
        }

        private void dataGridView3_Iicecekler_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView3_Iicecekler.Rows[e.RowIndex];
            DataCellValue(sender, e, row, "I_urunler", dataGridView3_Iicecekler);
        }

        private void dataGridView4_Tatlilar_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView4_Tatlilar.Rows[e.RowIndex];
            DataCellValue(sender, e, row, "T_urunler", dataGridView4_Tatlilar);
        }

        private void KullanicilariDuzenle_Click(object sender, EventArgs e)
        {
            YoneticiKullanicilariDuzernle openForm = Application.OpenForms.OfType<YoneticiKullanicilariDuzernle>().FirstOrDefault();
            if (openForm != null)
            {
                openForm.BringToFront();
                openForm.Focus();
                openForm.Show();
            }
            else
            {
                openForm = new YoneticiKullanicilariDuzernle();
                openForm.Show();
            }
        }

        private void GeriButton_Click(object sender, EventArgs e)
        {
            GirisFRM openForm = Application.OpenForms.OfType<GirisFRM>().FirstOrDefault();
            if (openForm != null)
            {
                openForm.BringToFront();
                openForm.Focus();
                openForm.Show();
                this.Close();
            }
            else
            {
                openForm = new GirisFRM();
                openForm.Show();
                this.Close();
            }
        }
    }
}
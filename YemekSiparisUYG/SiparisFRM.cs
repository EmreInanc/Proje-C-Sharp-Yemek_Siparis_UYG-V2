using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YemekSiparisUYG
{
	public partial class SiparisFRM : Form
	{

		Iiskenderler FRMiskender;
		Icecekler FRMicecekler;
		Tatlilar FRMTatlilar;
		Sepet sepetForm;
		DonerlerFRM FRMDoner;

		Listeleler siparislerListesiFRM;

		public SiparisFRM()
		{
			InitializeComponent();


		}


		/*
		 * VT DEKİ TABLOLAR  
		 * D_urunler döner
		 * I_urunler iskennder 
		 * Ii_urunler içecek
		 * T_urunler tatlılar 
		 */

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			if (FRMDoner == null || FRMDoner.IsDisposed)
			{
				FRMDoner = new DonerlerFRM();
				FRMDoner.FormClosed += (s, args) => { FRMDoner = null; }; // Form kapatıldığında, sepetForm değişkenini null olarak ayarla.
				FRMDoner.Show();
			}
			else
			{
				FRMDoner.Activate(); // Sepet formu zaten açıksa, onu ön plana getir.
			}
		}

		private void pictureBox2_Click(object sender, EventArgs e)
		{
			if (FRMiskender == null || FRMiskender.IsDisposed)
			{
				FRMiskender = new Iiskenderler();
				FRMiskender.FormClosed += (s, args) => { FRMiskender = null; }; // Form kapatıldığında, sepetForm değişkenini null olarak ayarla.
				FRMiskender.Show();
			}
			else
			{
				FRMiskender.Activate(); // Sepet formu zaten açıksa, onu ön plana getir.
			}
		}

		private void pictureBox3_Click(object sender, EventArgs e)
		{//frm tatllılar
			if (FRMTatlilar == null || FRMTatlilar.IsDisposed)
			{
				FRMTatlilar = new Tatlilar();
				FRMTatlilar.FormClosed += (s, args) => { FRMTatlilar = null; }; // Form kapatıldığında, sepetForm değişkenini null olarak ayarla.
				FRMTatlilar.Show();
			}
			else
			{
				FRMTatlilar.Activate(); // Sepet formu zaten açıksa, onu ön plana getir.
			}

		}

		private void pictureBox4_Click(object sender, EventArgs e)
		{//içecekler
			if (FRMicecekler == null || FRMicecekler.IsDisposed)
			{
				FRMicecekler = new Icecekler();
				FRMicecekler.FormClosed += (s, args) => { FRMicecekler = null; }; // Form kapatıldığında, sepetForm değişkenini null olarak ayarla.
				FRMicecekler.Show();
			}
			else
			{
				FRMicecekler.Activate(); // Sepet formu zaten açıksa, onu ön plana getir.
			}
		}

		private void pictureBox5_Click(object sender, EventArgs e)
		{
			if (sepetForm == null || sepetForm.IsDisposed)
			{
				sepetForm = new Sepet();
				sepetForm.FormClosed += (s, args) => { sepetForm = null; }; // Form kapatıldığında, sepetForm değişkenini null olarak ayarla.
				sepetForm.Show();
			}
			else
			{
				sepetForm.Activate(); // Sepet formu zaten açıksa, onu ön plana getir.
			}

		}

		private void pictureBox6_Click(object sender, EventArgs e)
		{
			if (siparislerListesiFRM == null || siparislerListesiFRM.IsDisposed)
			{
				siparislerListesiFRM = new Listeleler();
				siparislerListesiFRM.FormClosed += (s, args) => { siparislerListesiFRM = null; }; // Form kapatıldığında, sepetForm değişkenini null olarak ayarla.
				siparislerListesiFRM.Show();
			}
			else
			{
				siparislerListesiFRM.Activate(); // Sepet formu zaten açıksa, onu ön plana getir.
			}
		}

        private void pictureBox7_Click(object sender, EventArgs e)
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
	


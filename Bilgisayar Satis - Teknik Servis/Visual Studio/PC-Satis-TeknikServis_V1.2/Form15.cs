using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

// SİLİNMİŞ KAYITLAR PANELİ

namespace PC_Satis_TeknikServis_V1._2
{
    public partial class Form15 : Form
    {
        public Form15()
        {
            InitializeComponent();
        }

        private void Form15_Load(object sender, EventArgs e)
        {
            // Metin Kutularına Metin Ataması Yapılır.
            guna2Button1.Text = "Müşteriler";
            guna2Button2.Text = "Siparişler";
            guna2Button3.Text = "Üretici Firma";
            guna2Button4.Text = "Bilgisayarlar";
            guna2Button5.Text = "Teknik Servis";
            guna2Button6.Text = "Kullanıcı";
            gunaDataGridView1.ReadOnly = true;
        }

        // Bu Butonlara Tıklanıldığı Zaman İlgili Veritabanı Tablosundan Verileri Getirir.
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            baglanti("Select * From SilinenMusteri");
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            baglanti("Select * From Silinensiparis");
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            baglanti("Select * From SilinenUreticiFirma");
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            baglanti("Select * From Silinenbilgisayar");
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            baglanti("Select * From SilinenTeknikServis");
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            baglanti("Select * From SilinenKullanici");
        }

        private string dbname = "pcsatis";
        private void baglanti(string veri) // Veritabanından Verileri Getiren Fonksiyon
        {
            gunaDataGridView1.Columns.Clear(); // Ana Tablonun İçini Temizler.
            SqlConnection conn = new SqlConnection("Server = localhost; Database = " + dbname + "; Integrated Security = SSPI;"); // Veritabanına Bağlanır.
            conn.Open(); // Veritabanını Açar.
            SqlCommand komut = new SqlCommand(); // Veritabanı İçin Komut Vermeye Yardımcı Olur.
            komut.Connection = conn;
            komut.CommandText = ("Select * From " + veri + "");
            SqlDataAdapter dataadapter = new SqlDataAdapter(veri, conn);
            DataSet dataset = new DataSet();
            dataadapter.Fill(dataset); // Select Sorgusu ile Veriler dataset e doldurulur.
            gunaDataGridView1.DataSource = dataset.Tables[0];
            conn.Close(); // Veritabanını Kapatır.
        }
    }
}
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
using System.IO;

// BİLGİSAYAR ÖZELLİKLERİ EKRANI

namespace PC_Satis_TeknikServis_V1._2
{
    public partial class Form17 : Form
    {
        public Form17()
        {
            InitializeComponent();
        }

        private void Form17_Load(object sender, EventArgs e)
        {
            readpcspecs();
            readimg(gunaPictureBox1, pcid);

            gunaLabel15.Visible = false;

            if (stok == "0")
            {
                gunaLabel15.Visible = true;
                gunaButton1.Visible = false;
            }
            
        }

        private string pcid = ((Form4)Application.OpenForms["Form4"]).pciddondur(); // Form4 Açılır ve pciddondur Fonksiyonu Çağırılır.
        private string musteriid = ((Form1)Application.OpenForms["Form1"]).iddondur();
        private string date;
        private string stok;
        private void readpcspecs()
        {
            SqlConnection cn = new SqlConnection("Server = localhost; Database = pcsatis; Integrated Security = SSPI;"); // Veritabanına Bağlanılır.
            using (SqlCommand cmd = new SqlCommand("SELECT * From bilgisayar where pcid="+pcid+"")) // Veritabanına Komut Verilmesine Yardımcı Olur.
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;
                cn.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader()) // Verileri Almamızı Sağlar.
                {
                    sdr.Read();
                    gunaLabel1.Text = sdr["firmaAd"].ToString() + " " + sdr["modelno"].ToString();
                    gunaLabel2.Text = sdr["fiyat"].ToString() + " TL";
                    gunaLabel3.Text = sdr["CPU"].ToString();
                    gunaLabel4.Text = sdr["RAM"].ToString();
                    gunaLabel5.Text = sdr["Depolama"].ToString();
                    gunaLabel6.Text = sdr["GPU"].ToString();
                    gunaLabel7.Text = sdr["OS"].ToString();
                    stok = sdr["stokadeti"].ToString();
                }
                cn.Close();
            }
        }
        private void readimg(PictureBox picture, string deger)
        {
            SqlConnection baglanti = new SqlConnection("Server = localhost; Database = pcsatis; Integrated Security = SSPI;");
            SqlDataAdapter dataAdapter = new SqlDataAdapter(new SqlCommand("SELECT imgfile FROM pcimage WHERE pcid = " + deger + "", baglanti));
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet); // İçindeki Satırları dataSet Veri Kaynağı ile Eşleşecek Şekilde Ekler veya Yeniler.

            if (dataSet.Tables[0].Rows.Count == 1)
            {
                Byte[] data = new Byte[0];
                data = (Byte[])(dataSet.Tables[0].Rows[0]["imgfile"]);
                MemoryStream mem = new MemoryStream(data);
                picture.Image = Image.FromStream(mem);
            }
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Siparişi Onaylıyor Musunuz?\n", "pcsatis", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                date = DateTime.Now.ToString("dd.MM.yyyy HH:mm");
                siparisekle(pcid, "1", "-", "-", date, musteriid);
            }

        }
        public void siparisekle(string xb, string xc, string xd, string xe, string xf, string xg)
        {
            // Hata Blokları
            try
            {
                SqlConnection baglanti = new SqlConnection("Server = localhost; Database = pcsatis; Integrated Security = SSPI;"); // Veritabanına Bağlanılmasını Sağlar.
                baglanti.Open(); // Veritabanı Açılır.

                // Veritabanına Komut Vererek Veri Girmemizi Sağlar.
                SqlCommand komut = new SqlCommand("insert into Siparis ( pcid ,miktar ,kargosirketi ,kargoid ,alisveristarih, MusteriID) values (@pcid,@miktar,@kargosirketi,@kargoid,@alisveristarih, @MusteriID)", baglanti);
                komut.Parameters.AddWithValue("@pcid", xb);
                komut.Parameters.AddWithValue("@miktar", xc);
                komut.Parameters.AddWithValue("@kargosirketi", xd);
                komut.Parameters.AddWithValue("@kargoid", xe);
                komut.Parameters.AddWithValue("@alisveristarih", xf);
                komut.Parameters.AddWithValue("@MusteriID", xg);
                komut.ExecuteNonQuery(); // Kodu SQL'de Çalıştırıp Geriye Değer Döndüren Metod.
                baglanti.Close(); // Veritabanı Kapatılır.
                MessageBox.Show("Siparişiniz Başarıyla Oluşturuldu"); // Mesaj Kutusu
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
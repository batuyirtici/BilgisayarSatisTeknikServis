using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;

// İÇERİYE AKTARIM (İMPORT) EKRANI

namespace PC_Satis_TeknikServis_V1._2
{
    public partial class Form21 : Form
    {
        public Form21()
        {
            InitializeComponent();
        }

        private void Form21_Load(object sender, EventArgs e)
        {
            // ComboBox için Metin Ekler.
            /*guna2ComboBox1.Items.Add("Müşteri");
            guna2ComboBox1.Items.Add("Sipariş");
            guna2ComboBox1.Items.Add("Üretici Firma");
            guna2ComboBox1.Items.Add("Bilgisayar");
            guna2ComboBox1.Items.Add("Teknik Servis");*/

            guna2ComboBox1.Items.Add("Musteri");
            guna2ComboBox1.Items.Add("siparis");
            guna2ComboBox1.Items.Add("UreticiFirma");
            guna2ComboBox1.Items.Add("bilgisayar");
            guna2ComboBox1.Items.Add("TeknikServis");
        }

        private string secilitablo = "NULL";

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;
            string fileExt = string.Empty;
            OpenFileDialog file = new OpenFileDialog(); // Dosya Seçmek için İletişim Kutusunu Aç. 
            file.Filter = "Excel Dosyası(.xls)|*.xls*";
            file.Title = "Table Import";
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK) // Kullanıcı Tarafından Seçilen Bir Dosya Olup Olmadığını Kontrol Eder.
            {
                filePath = file.FileName; // Dosyanın Yolunu Kaydeder.  
                fileExt = Path.GetExtension(filePath); // Dosya Uzantısını Kaydeder.
                guna2TextBox1.Text = filePath;


                if (fileExt.CompareTo(".xls") == 0 || fileExt.CompareTo(".xlsx") == 0) // Dosyanın Uzantısı Kontrol Edilir.
                {
                    // Hata Komutları
                    try
                    {
                        DataTable dtExcel = new DataTable();
                        dtExcel = ReadExcel(filePath, fileExt); // Excel Dosyasını Okur. 
                        gunaDataGridView1.Visible = true;
                        gunaDataGridView1.DataSource = dtExcel;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Sadece .xls veya .xlsx Uzantılı Bir Dosya Seçin", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error); // Uyarı Gösteren Mesaj Kutusu  
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e) // Butona Basıldığı Zaman İçe Aktarma (Import) İşlemleri Başlar.
        {
            if (guna2TextBox1.Text == string.Empty) // Metin Kutusunun Boş Olup Olmadığı Kontrol Edilir.
            {
                MessageBox.Show("Lütfen Import Edilecek Bir Excel Dosyası Seçin!");
            }
            else
            { // Eğer Tablo İsimleri Yazılan İsimler Gibiyse Satırlarda Belirtilen Fonksiyonlar Çağırılır.
                if (secilitablo == "NULL")
                {
                    MessageBox.Show("Lütfen Önce Verilerin Aktarılacağı Tabloyu Seçin!");
                }
                else if (secilitablo == "Musteri")
                {
                    musteriimport();
                }
                else if (secilitablo == "siparis")
                {
                    siparisimport();
                }
                else if (secilitablo == "UreticiFirma")
                {
                    ureticifirmaimport();
                }
                else if (secilitablo == "bilgisayar")
                {
                    bilgisayarimport();
                }
                else if (secilitablo == "TeknikServis")
                {
                    teknikservisimport();
                }
            }
            
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            secilitablo = guna2ComboBox1.SelectedItem.ToString();
        }

        private DataTable ReadExcel(string fileName, string fileExt)
        {
            string conn = string.Empty;
            DataTable dtexcel = new DataTable();
            if (fileExt.CompareTo(".xls") == 0)
                conn = @"provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties='Excel 8.0;HRD=Yes;IMEX=1';"; 
            else
                conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties='Excel 12.0;HDR=NO';";  
            using (OleDbConnection con = new OleDbConnection(conn))
            {
                // Hata Komutları
                try
                {

                    OleDbDataAdapter oleAdpt = new OleDbDataAdapter("select * from [Sayfa1$]", con); // Sayfa1'in İçindeki Verileri Oku  
                    oleAdpt.Fill(dtexcel); // Excel Verilerini Tablolara Aktar.  
                }
                catch { }
            }
            return dtexcel;

        }

        private void musteriimport() // Veritabanına Bağlan, Veritabanını Aç, Veritabanına Ekle Komutunu ve Hangi Parametrelerin Ekleneceğini Gir, Veritabanını Kapat.
        {
            // Hata Komutları
            try
            {
                for (int i = 0; i < gunaDataGridView1.Rows.Count - 1; i++)
                {
                    SqlConnection baglanti = new SqlConnection("Server = localhost; Database =  pcsatis  ; Integrated Security = SSPI;");
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("insert into Musteri ( KimlikNo ,Ad ,Soyad ,MailAdres ,TelNo ,Adres, sifre) values (@KimlikNo,@Ad,@Soyad,@MailAdres,@TelNo,@Adres,@sifre)", baglanti);
                    komut.Parameters.AddWithValue("@KimlikNo", gunaDataGridView1.Rows[i].Cells["KimlikNo"].Value.ToString());
                    komut.Parameters.AddWithValue("@Ad", gunaDataGridView1.Rows[i].Cells["Ad"].Value.ToString());
                    komut.Parameters.AddWithValue("@Soyad", gunaDataGridView1.Rows[i].Cells["Soyad"].Value.ToString());
                    komut.Parameters.AddWithValue("@MailAdres", gunaDataGridView1.Rows[i].Cells["MailAdres"].Value.ToString());
                    komut.Parameters.AddWithValue("@TelNo", gunaDataGridView1.Rows[i].Cells["TelNo"].Value.ToString());
                    komut.Parameters.AddWithValue("@Adres", gunaDataGridView1.Rows[i].Cells["Adres"].Value.ToString());
                    komut.Parameters.AddWithValue("@sifre", gunaDataGridView1.Rows[i].Cells["sifre"].Value.ToString());
                    komut.ExecuteNonQuery(); // Kodu SQL'de Çalıştırıp Geriye Değer Döndüren Metod.
                    baglanti.Close();
                }
                MessageBox.Show("Musteri Import İşlemi Gerçekleşti.."); // Mesaj Kutusu
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir Hata Meydana Geldi  :" + ex.ToString());
            }
        }

        private void siparisimport() // Veritabanına Bağlan, Veritabanını Aç, Veritabanına Ekle Komutunu ve Hangi Parametrelerin Ekleneceğini Gir, Veritabanını Kapat.
        {
            // Hata Komutları 
            try
            {
                for (int i = 0; i < gunaDataGridView1.Rows.Count - 1; i++)
                {
                    SqlConnection baglanti = new SqlConnection("Server = localhost; Database =  pcsatis  ; Integrated Security = SSPI;");
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("insert into Siparis ( pcid ,miktar ,kargosirketi ,kargoid ,alisveristarih, MusteriID) values (@pcid,@miktar,@kargosirketi,@kargoid,@alisveristarih, @MusteriID)", baglanti);
                    komut.Parameters.AddWithValue("@pcid", gunaDataGridView1.Rows[i].Cells["pcid"].Value.ToString());
                    komut.Parameters.AddWithValue("@miktar", gunaDataGridView1.Rows[i].Cells["miktar"].Value.ToString());
                    komut.Parameters.AddWithValue("@kargosirketi", gunaDataGridView1.Rows[i].Cells["kargosirketi"].Value.ToString());
                    komut.Parameters.AddWithValue("@kargoid", gunaDataGridView1.Rows[i].Cells["kargoid"].Value.ToString());
                    komut.Parameters.AddWithValue("@alisveristarih", gunaDataGridView1.Rows[i].Cells["alisveristarih"].Value.ToString());
                    komut.Parameters.AddWithValue("@MusteriID", gunaDataGridView1.Rows[i].Cells["MusteriID"].Value.ToString());
                    komut.ExecuteNonQuery(); // Kodu SQL'de Çalıştırıp Geriye Değer Döndüren Metod.
                    baglanti.Close();
                }
                MessageBox.Show("Gerçekleşti!"); // Mesaj Kutusu
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir Hata Meydana Geldi  :" + ex.ToString());
            }
        }
        private void ureticifirmaimport() // Veritabanına Bağlan, Veritabanını Aç, Veritabanına Ekle Komutunu ve Hangi Parametrelerin Ekleneceğini Gir, Veritabanını Kapat.
        {
            // Hata Komutları
            try
            {
                for (int i = 0; i < gunaDataGridView1.Rows.Count - 1; i++)
                {
                    SqlConnection baglanti = new SqlConnection("Server = localhost; Database =  pcsatis  ; Integrated Security = SSPI;");
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("insert into UreticiFirma ( firmaAd ,webAdres ,mailAdres ,telNo ,firmaAdres) values (@firmaAd,@webAdres,@mailAdres,@telNo,@firmaAdres)", baglanti);
                    komut.Parameters.AddWithValue("@firmaAd", gunaDataGridView1.Rows[i].Cells["firmaAd"].Value.ToString());
                    komut.Parameters.AddWithValue("@webAdres", gunaDataGridView1.Rows[i].Cells["webAdres"].Value.ToString());
                    komut.Parameters.AddWithValue("@mailAdres", gunaDataGridView1.Rows[i].Cells["mailAdres"].Value.ToString());
                    komut.Parameters.AddWithValue("@telNo", gunaDataGridView1.Rows[i].Cells["telNo"].Value.ToString());
                    komut.Parameters.AddWithValue("@firmaAdres", gunaDataGridView1.Rows[i].Cells["firmaAdres"].Value.ToString());
                    komut.ExecuteNonQuery(); // Kodu SQL'de Çalıştırıp Geriye Değer Döndüren Metod.
                    baglanti.Close();
                }
                MessageBox.Show("Gerçekleşti!"); // Mesaj Kutusu
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir Hata Meydana Geldi  :" + ex.ToString());
            }
        }
        private void bilgisayarimport() // Veritabanına Bağlan, Veritabanını Aç, Veritabanına Ekle Komutunu ve Hangi Parametrelerin Ekleneceğini Gir, Veritabanını Kapat.
        {
            // Hata Komutları
            try
            {
                for (int i = 0; i < gunaDataGridView1.Rows.Count - 1; i++)
                {
                    SqlConnection baglanti = new SqlConnection("Server = localhost; Database =  pcsatis  ; Integrated Security = SSPI;");
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("insert into bilgisayar ( modelno ,firmaAd ,fiyat ,CPU ,RAM ,Depolama ,GPU ,OS ,stokadeti) values (@modelno ,@firmaAd ,@fiyat ,@CPU ,@RAM ,@Depolama ,@GPU ,@OS ,@stokadeti)", baglanti);
                    komut.Parameters.AddWithValue("@modelno", gunaDataGridView1.Rows[i].Cells["modelno"].Value.ToString());
                    komut.Parameters.AddWithValue("@firmaAd", gunaDataGridView1.Rows[i].Cells["firmaAd"].Value.ToString());
                    komut.Parameters.AddWithValue("@fiyat", gunaDataGridView1.Rows[i].Cells["fiyat"].Value.ToString());
                    komut.Parameters.AddWithValue("@CPU", gunaDataGridView1.Rows[i].Cells["CPU"].Value.ToString());
                    komut.Parameters.AddWithValue("@RAM", gunaDataGridView1.Rows[i].Cells["RAM"].Value.ToString());
                    komut.Parameters.AddWithValue("@Depolama", gunaDataGridView1.Rows[i].Cells["Depolama"].Value.ToString());
                    komut.Parameters.AddWithValue("@GPU", gunaDataGridView1.Rows[i].Cells["GPU"].Value.ToString());
                    komut.Parameters.AddWithValue("@OS", gunaDataGridView1.Rows[i].Cells["OS"].Value.ToString());
                    komut.Parameters.AddWithValue("@stokadeti", gunaDataGridView1.Rows[i].Cells["stokadeti"].Value.ToString());
                    komut.ExecuteNonQuery(); // Kodu SQL'de Çalıştırıp Geriye Değer Döndüren Metod.
                    baglanti.Close();
                }
                MessageBox.Show("Gerçekleşti!"); // Mesaj Kutusu
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir Hata Meydana Geldi  :" + ex.ToString());
            }
        }
        private void teknikservisimport() // Veritabanına Bağlan, Veritabanını Aç, Veritabanına Ekle Komutunu ve Hangi Parametrelerin Ekleneceğini Gir, Veritabanını Kapat.
        {
            // Hata Komutları
            try
            {
                for (int i = 0; i < gunaDataGridView1.Rows.Count - 1; i++)
                {
                    SqlConnection baglanti = new SqlConnection("Server = localhost; Database =  pcsatis  ; Integrated Security = SSPI;");
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("insert into TeknikServis ( personelID ,ad ,soyad ,kimlikNo ,telNo ,mail ,adres) values (@personelID,@ad ,@soyad ,@kimlikNo ,@telNo ,@mail ,@adres)", baglanti);
                    komut.Parameters.AddWithValue("@personelID", gunaDataGridView1.Rows[i].Cells["personelID"].Value.ToString());
                    komut.Parameters.AddWithValue("@ad", gunaDataGridView1.Rows[i].Cells["ad"].Value.ToString());
                    komut.Parameters.AddWithValue("@soyad", gunaDataGridView1.Rows[i].Cells["soyad"].Value.ToString());
                    komut.Parameters.AddWithValue("@kimlikNo", gunaDataGridView1.Rows[i].Cells["kimlikNo"].Value.ToString());
                    komut.Parameters.AddWithValue("@telNo", gunaDataGridView1.Rows[i].Cells["telNo"].Value.ToString());
                    komut.Parameters.AddWithValue("@mail", gunaDataGridView1.Rows[i].Cells["mail"].Value.ToString());
                    komut.Parameters.AddWithValue("@adres", gunaDataGridView1.Rows[i].Cells["adres"].Value.ToString());
                    komut.ExecuteNonQuery(); // Kodu SQL'de Çalıştırıp Geriye Değer Döndüren Metod.
                    baglanti.Close();
                }
                MessageBox.Show("Gerçekleşti!"); // Mesaj Kutusu
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir Hata Meydana Geldi  :" + ex.ToString());
            }
        }
    }
}
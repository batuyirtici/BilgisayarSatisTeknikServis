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

// HESAP BİLGİLERİ EKRANI

namespace PC_Satis_TeknikServis_V1._2
{
    public partial class Form18 : Form
    {
        public Form18()
        {
            InitializeComponent();
        }

        private void Form18_Load(object sender, EventArgs e)
        {
            // Metin Kutularının Uzunluğunu Ayarlar.
            gunaTextBox1.MaxLength = 11;
            gunaTextBox2.MaxLength = 45;
            gunaTextBox3.MaxLength = 20;
            gunaTextBox4.MaxLength = 60;
            gunaTextBox5.MaxLength = 11;
            gunaTextBox6.MaxLength = 200;
            gunaTextBox7.MaxLength = 40;

            SqlConnection cn = new SqlConnection("Server = localhost; Database = pcsatis; Integrated Security = SSPI;"); // Veritabanına Bağlanmayı Sağlar.
            using (SqlCommand cmd = new SqlCommand("SELECT * From Musteri where MusteriID=(" + musteriid + ")")) // Veritabanına Komut Vermeyi Sağlar.
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;
                cn.Open(); // Veritabanına Bağlanır.

                // Verileri Almayı Sağlar.
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    sdr.Read();
                    gunaTextBox1.Text = sdr["KimlikNo"].ToString();
                    gunaTextBox2.Text = sdr["Ad"].ToString();
                    gunaTextBox3.Text = sdr["Soyad"].ToString();
                    gunaTextBox4.Text = sdr["MailAdres"].ToString();
                    gunaTextBox5.Text = sdr["TelNo"].ToString();
                    gunaTextBox6.Text = sdr["Adres"].ToString();
                    gunaTextBox7.Text = sdr["sifre"].ToString(); 
                }
                cn.Close(); // Veritabanını Kapatır.
            }
            if (guncelleme == false)
            {
                gunaTextBox1.ReadOnly = true;
                gunaTextBox2.ReadOnly = true;
                gunaTextBox3.ReadOnly = true;
                gunaTextBox4.ReadOnly = true;
                gunaTextBox5.ReadOnly = true;
                gunaTextBox6.ReadOnly = true;
                gunaTextBox7.ReadOnly = true;
            }
            else
            {
                gunaTextBox1.ReadOnly = false;
                gunaTextBox2.ReadOnly = false;
                gunaTextBox3.ReadOnly = false;
                gunaTextBox4.ReadOnly = false;
                gunaTextBox5.ReadOnly = false;
                gunaTextBox6.ReadOnly = false;
                gunaTextBox7.ReadOnly = false;
            }

        }
        private bool guncelleme = ((Form1)Application.OpenForms["Form1"]).guncellemedondur(); // Form1 Açılır ve guncellemedondur Fonksiyonu Çağırılır.
        private string musteriid = ((Form1)Application.OpenForms["Form1"]).iddondur();
        private bool sil = ((Form1)Application.OpenForms["Form1"]).silmedondur();
        

        private void guna2Button1_Click(object sender, EventArgs e) // Butona Basıldığı Zaman Güncelleme Yetkilendirmesi Kontrol Edilir.
        {
            if (guncelleme == false) // Güncelleme Fonksiyonu Kontrol Edilir.
            {
                MessageBox.Show("Bu İşlemi Gercekleştirme Yetkisine Sahip Değilsiniz!");
            }
            else // Güncelleme Fonksiyonu "FALSE" Değilse Güncelleme İşlemi Başlatılabilir.
            {
                // Metin Kutularının Boş Olup Olmadığı Kontrol Edilir.
                if ((string.IsNullOrEmpty(gunaTextBox1.Text)) || (string.IsNullOrEmpty(gunaTextBox2.Text)) || (string.IsNullOrEmpty(gunaTextBox3.Text)) || (string.IsNullOrEmpty(gunaTextBox4.Text)) || (string.IsNullOrEmpty(gunaTextBox5.Text)) || (string.IsNullOrEmpty(gunaTextBox6.Text)))
                { 
                    MessageBox.Show("Bu Alanlar Boş Bırakılamaz!");
                }
                else
                {
                    if (gunaTextBox1.Text.Length < 11)
                    {
                        MessageBox.Show("Kimlik Numarası 11 Hane Olmalıdır");
                    }
                    else if (gunaTextBox5.Text.Length < 11)
                    {
                        MessageBox.Show("Telefon Numarası 11 Hane Olmalıdır");
                    }
                    else if (gunaTextBox7.Text.Length < 8)
                    {
                        MessageBox.Show("Şifre Minimum 8 Haneli Olmalıdır");
                    }
                    else
                    {
                        // Hata Komutları
                        try
                        {
                            SqlConnection baglanti = new SqlConnection("Server = localhost; Database = pcsatis; Integrated Security = SSPI;"); // Veritabanıyla Bağlantı Sağlanır.
                            baglanti.Open(); // Bağlantı Açılır.

                            // İstenilen Komut ile Birlikte Parametrelerin İçeriğinde Değişiklik Sağlanır.
                            string kayit = "update Musteri set KimlikNo =@KimlikNo,Ad=@Ad,Soyad=@Soyad,MailAdres=@MailAdres,TelNo=@TelNo,Adres=@Adres,sifre=@sifre where MusteriID=(" + musteriid + ")";
                            SqlCommand komut = new SqlCommand(kayit, baglanti);
                            komut.Parameters.AddWithValue("@KimlikNo", gunaTextBox1.Text);
                            komut.Parameters.AddWithValue("@Ad", gunaTextBox2.Text);
                            komut.Parameters.AddWithValue("@Soyad", gunaTextBox3.Text);
                            komut.Parameters.AddWithValue("@MailAdres", gunaTextBox4.Text);
                            komut.Parameters.AddWithValue("@TelNo", gunaTextBox5.Text);
                            komut.Parameters.AddWithValue("@Adres", gunaTextBox6.Text);
                            komut.Parameters.AddWithValue("@sifre", gunaTextBox7.Text);
                            komut.ExecuteNonQuery(); // Kodu SQL'de Çalıştırıp Geriye Değer Döndüren Metod.
                            baglanti.Close(); // Bağlantı Kapatılır.
                            MessageBox.Show("Güncelleme Başarılı!"); // Mesaj Kutusu
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            this.Close();
                        }
                    }
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e) // Butona Basıldığı Zaman Silme Yetkisi Kontrol Edilir.
        {
            if (sil == true) // Silme Fonksiyonu Kontrol Edilir.
            {
                // Hata Komutları
                try
                {
                    SqlConnection con = new SqlConnection("Server = localhost; Database = pcsatis; Integrated Security = SSPI;"); // Veritabanıyla Bağlantı Sağlanır.
                    con.Open(); // Bağlantı Açılır.
                    SqlCommand komut = new SqlCommand("delete from Musteri where MusteriID=(" + musteriid + ")", con); // Veritabanına Komut Verilmesi Sağlanır.

                    // Mesaj Kutusundaki Mesaja Olumlu Cevap Verildiğini Kontrol Eder.
                    if (MessageBox.Show("Hesabınızı Silmek İstediğinize Emin Misiniz?\n", "PC Teknik Servis - Satış", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        komut.ExecuteNonQuery(); // Kodu SQL'de Çalıştırıp Geriye Değer Döndüren Metod.
                        con.Close();
                        MessageBox.Show("Hesabınız Başarıyla Silindi!"); // Mesaj Kutusu
                        Application.Exit();

                    }
                    else
                    {
                        MessageBox.Show("Silme Gerçekleşmedi..");
                        con.Close();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Hesap Silinirken Bir Hata Oluştu!");
                }
            }
            else
            {
                MessageBox.Show("Bu İşlemi Gerçekleştirmek İçin Yetkiniz Bulunmamaktadır!");
            }
        }
    }
}
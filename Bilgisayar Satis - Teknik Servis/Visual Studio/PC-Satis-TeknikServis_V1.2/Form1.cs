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
using System.Net.Mail;

// GİRİŞ EKRANI

namespace PC_Satis_TeknikServis_V1._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Text Box ve Label İçindeki Metinler
            gunaTextBox1.Text = "";
            gunaTextBox2.Text = "";
            gunaLabel1.Text = "Hoşgeldiniz!";
            gunaLabel2.Text = "Hesabın Yok Mu?";
            gunaLabel3.Text = "Mail Adresi";
            gunaLabel4.Text = "Şifre";
            gunaLabel5.Text = "Software version 2.0";
            gunaButton1.Text = "Giriş Yap";
            gunaButton2.Text = "Kaydol";
            gunaCheckBox1.Text = "Şifreyi Göster";
            gunaTextBox2.PasswordChar = '*';
            gunaMediumRadioButton1.BaseColor = Color.DarkSlateBlue;
        }
        private void gunaCheckBox1_CheckedChanged(object sender, EventArgs e) // Bu Kutu İşaretlendiği Zaman Gizli Olan Şifre Gösterilir.
        {
            if (gunaCheckBox1.Checked)
            {
                gunaTextBox2.PasswordChar ='\0';
            }
            else
            {
                gunaTextBox2.PasswordChar = '*';
            }
        }

        private void gunaMediumRadioButton1_Click(object sender, EventArgs e) // Bu Butona Tıklandığı Zaman Giriş Ekranından Çıkar.
        {
            Application.Exit(); // Giriş Ekranından Çıkartan Fonksiyon
        }

        private void gunaMediumRadioButton1_MouseHover(object sender, EventArgs e) // Fare Butonun Üzerine Geldiği Zaman Butonun Rengini Değiştiren Fonksiyon
        {
            gunaMediumRadioButton1.BaseColor = Color.Red;
        }

        private void gunaMediumRadioButton1_MouseLeave(object sender, EventArgs e) // Fareyi Butonun Üzerinden Çekildiğinde Rengini Değiştiren Fonksiyon 
        {
            gunaMediumRadioButton1.BaseColor = Color.DarkSlateBlue;
        }

        private void gunaButton1_Click(object sender, EventArgs e) // "Giriş Yap" Butonuna Tıklanıldığı Zaman Giriş Yapar.
        {
            login(); // Giriş Fonksiyonu
        }

        private void gunaButton2_Click(object sender, EventArgs e) // "Kaydol" Butonuna Tıklanıldığı Zaman Kayıt Ekranına Yönlendirir.
        {
            Form2 f2 = new Form2(); // Yeni Form Oluşturur.
            f2.ShowDialog(); // Yeni Formu Gösterir.
        }

        // FONKSİYONLAR
        private string dbname = "pcsatis";
        private string MusteriID,veri;
        string okuma, yazma, guncelleme, silme;

        // Yekilendirme Fonksiyonları
        public bool guncellemedondur()
        {
            if(guncelleme == "True")
            {
                return true;
            }
            else
            {
                return false;
            }
        
        }
        public bool okumadondur()
        {
            if (okuma == "True")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool silmedondur()
        {
            if (silme == "True")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string veridondur()
        {
            return veri;
        }
        public string iddondur()
        {
            return MusteriID;
        }
        private void login() // Giriş Fonksiyonu
        {
            string user = gunaTextBox1.Text;
            string pass = gunaTextBox2.Text;

            // Burada Veritabanı İşlemlerine Başlanır.
            SqlConnection con = new SqlConnection("Server = localhost; Database = "+ dbname +"; Integrated Security = SSPI;"); // Veritabanına Bağlanır.
            SqlCommand cmd = new SqlCommand(); // Veritabanı Üzerinden İşlem Yapılmasını Sağlar.
            con.Open(); // Veritabanını Açar.
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM Kullanici where kullanici_mail='" + gunaTextBox1.Text + "' AND kullanici_sifre='" + gunaTextBox2.Text + "'"; // Veritabanından İstenilen Verileri Getirir.
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                if (dr.Read()) // Kullanıcı Adı ve Şifre Kontrol Edilir.
                {
                    veri = dr["kullanici_mail"].ToString();
                    MusteriID = dr["MusteriID"].ToString();
                    okuma = dr["okuma"].ToString();
                    yazma = dr["yazma"].ToString();
                    guncelleme = dr["guncelleme"].ToString();
                    silme = dr["silme"].ToString();
                    if ((okuma == "True") && (yazma == "True") && (guncelleme == "True") && (silme == "True")) // Yönetici (Admin) İzinleri Kontrol Edilir.
                    {
                        MessageBox.Show("Giriş Başarılı!");
                        Form3 f3 = new Form3();
                        f3.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Müşteri Girişi Başarılı!");
                        Form4 f4 = new Form4();
                        f4.ShowDialog();
                    }
                    
                }
                else
                {
                    MessageBox.Show("Kullanıcı Adı ve/veya Şifre Hatalı..!");
                }
                con.Close(); // Veritabanını Kapatır.
            }
        }
        
        public void kaydol(string kimlik, string ad, string soyad, string mail, string telno, string adres, string sifre) // Kayıt Fonksiyonu
        {
            //while (true) // Bu Döngünün İçerisinde Kayıt Ekranında Girilen Bilgilerin Uygunluğu Kontrol Edilir. Eğer Uygunluk Sağlanırsa Kayıt İşlemi Gerçekleştirilir.
            //{
                if (kimlik.Length < 11)
                {
                    MessageBox.Show("Lütfen Kimlik Numaranızı Doğru Giriniz.");
                }
                else if (telno.Length < 11)
                {
                    MessageBox.Show("Lütfen Telefon Numaranızı Başında 0 Olacak Şekilde Giriniz.");
                }
                else if (sifre.Length < 8)
                {
                    MessageBox.Show("Şifreniz Minimum 8 Haneli Olmalıdır.");
                }
                else
                {
                    try
                    {
                        // Burada Veritabanı İşlemlerine Başlanır.
                        SqlConnection baglanti = new SqlConnection("Server = localhost; Database = " + dbname + "; Integrated Security = SSPI;"); // Veritabanına Bağlanılır.
                        baglanti.Open(); // Bağlanılan Veritabanı Açılır.
                        SqlCommand komut = new SqlCommand("insert into Musteri ( KimlikNo ,Ad ,Soyad ,MailAdres ,TelNo ,Adres,sifre) values (@KimlikNo,@Ad,@Soyad,@MailAdres,@TelNo,@Adres,@sifre)", baglanti);
                        // İstenilen Kayıtlar Eklenir.
                        komut.Parameters.AddWithValue("@KimlikNo", kimlik);
                        komut.Parameters.AddWithValue("@Ad", ad);
                        komut.Parameters.AddWithValue("@Soyad", soyad);
                        komut.Parameters.AddWithValue("@MailAdres", mail);
                        komut.Parameters.AddWithValue("@TelNo", telno);
                        komut.Parameters.AddWithValue("@Adres", adres);
                        komut.Parameters.AddWithValue("@sifre", sifre);
                        komut.ExecuteNonQuery();
                        baglanti.Close(); // Bağlanılan Veritabanı Kapatılır.
                        MessageBox.Show("Kayıt Başarılı!");
                        //break;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Kayıt Başarısız: " + ex.Message);
                        //break;
                    }
                }
            //}

        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// KAYIT EKRANI

namespace PC_Satis_TeknikServis_V1._2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            
    }

        private void Form9_Load(object sender, EventArgs e)
        {
            // Metin Kutuları ve Başlıkları için Metin Girilir, Metin Kutularının Uzunluğu Belirlenir.
            gunaTextBox1.Text = "";
            gunaTextBox2.Text = "";
            gunaTextBox3.Text = "";
            gunaTextBox4.Text = "";
            gunaTextBox5.Text = "";
            gunaTextBox6.Text = "";
            gunaTextBox7.Text = "";
            gunaTextBox8.Text = "";
            gunaLabel1.Text = "Kimlik Numarası";
            gunaTextBox1.MaxLength = 11;
            gunaLabel2.Text = "Ad";
            gunaTextBox2.MaxLength = 45;
            gunaLabel3.Text = "Soyad";
            gunaTextBox3.MaxLength = 20;
            gunaLabel4.Text = "Mail Adresi";
            gunaTextBox4.MaxLength = 60;
            gunaLabel5.Text = "Telefon Numarası";
            gunaTextBox5.MaxLength = 11;
            gunaLabel6.Text = "Adres";
            gunaTextBox6.MaxLength = 200;
            gunaLabel7.Text = "Şifre";
            gunaTextBox7.MaxLength = 40;
            gunaLabel8.Text = "Güvenlik Kodu";
            Random rnd = new Random(); // Rastgele Sayı Oluşturucu
            string onaykod = rnd.Next(100000, 999999).ToString(); // Belirli Bir Aralıkta Restgele Sayı Oluşturulur ve Değişkene Atanır.
            gunaTextBox9.Text = onaykod;
            gunaButton1.Text = "Kaydol";
            gunaMediumRadioButton1.BaseColor = Color.DarkSlateBlue;
            gunaLabel9.Text = "Üye Kayıt Ekranı";
            gunaTextBox9.ReadOnly = true;
            gunaTextBox9.ShortcutsEnabled = false;
            gunaTextBox8.ShortcutsEnabled = false;

        }

        int kalandeneme = 3;
        private void gunaButton1_Click(object sender, EventArgs e) // Butona Basıldığı Zaman Kayıt İşlemleri Gerçekleşmeye Başlar.
        {
            // Kontrol Blokları
            if ((string.IsNullOrEmpty(gunaTextBox1.Text)) || (string.IsNullOrEmpty(gunaTextBox2.Text)) || (string.IsNullOrEmpty(gunaTextBox3.Text)) || (string.IsNullOrEmpty(gunaTextBox4.Text)) || (string.IsNullOrEmpty(gunaTextBox5.Text)) || (string.IsNullOrEmpty(gunaTextBox6.Text)) || (string.IsNullOrEmpty(gunaTextBox7.Text)))
            { // Metin Kutularının Boş Olup Olmadığını Kontrol Eder.
                MessageBox.Show("Bu Alanlar Boş Bırakılamaz!");
            }
            else 
            { 
                if (gunaTextBox8.Text == gunaTextBox9.Text) // Metin Kutuları Eşitse Kayıt Et.
                {
                    // Form1 Açılır ve kaydol Fonksiyonu Çağırılır.
                    ((Form1)Application.OpenForms["Form1"]).kaydol(gunaTextBox1.Text, gunaTextBox2.Text, gunaTextBox3.Text, gunaTextBox4.Text, gunaTextBox5.Text, gunaTextBox6.Text, gunaTextBox7.Text);
                    this.Close();
                }
                else // Metin Kutuları Eşit Değilse Ekrana Uyarı Bas ve Deneme Hakkını 1 Azalt.
                {
                    MessageBox.Show("Güvenlik Kodu Hatalı, Kalan Deneme Hakkı = "+ (kalandeneme-1).ToString());
                    kalandeneme -= 1;
                    if (kalandeneme <= 0)
                    {
                        this.Close();
                    }
                }
            }
        }

        private void gunaMediumRadioButton1_Click(object sender, EventArgs e) // Butona Basıldığında Ekranı Kapatır.
        {
            this.Close();
        }

        private void gunaMediumRadioButton1_MouseHover(object sender, EventArgs e) // Butonun Üstüne Gelindiği Zaman Rengi Değişir.
        {
            gunaMediumRadioButton1.BaseColor = Color.Red;
        }

        private void gunaMediumRadioButton1_MouseLeave(object sender, EventArgs e)  // Butonun Üzerinden Gidildiği Zaman Rengi Değişir.
        {
            gunaMediumRadioButton1.BaseColor = Color.DarkSlateBlue;
        }
    }
}
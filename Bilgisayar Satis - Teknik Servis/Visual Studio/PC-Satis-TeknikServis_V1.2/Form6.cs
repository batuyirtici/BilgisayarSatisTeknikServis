using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// MÜŞTERİ GÜNCELLEME EKRANI

namespace PC_Satis_TeknikServis_V1._2
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            
        }

        private void Form6_Load(object sender, EventArgs e)

        {
            string a1="", a2="", a3="", a4="", a5="", a6="", a7="";
            ((Form3)Application.OpenForms["Form3"]).musterioku(ref a1, ref a2, ref a3, ref a4, ref a5, ref a6, ref a7); // Form3 Açılır ve musterioku FOnksiyonu Çağırılır.

            // Metin Kutularına Metin Atama İşlemi Gerçekleştirilir ve Atanan Metinlerin Uzunluğu Belirlenir.
            gunaTextBox1.Text = a1;
            gunaTextBox2.Text = a2;
            gunaTextBox3.Text = a3;
            gunaTextBox4.Text = a4;
            gunaTextBox5.Text = a5;
            gunaTextBox6.Text = a6;
            gunaTextBox7.Text = a7;
            gunaTextBox1.MaxLength = 11;
            gunaTextBox2.MaxLength = 45;
            gunaTextBox3.MaxLength = 20;
            gunaTextBox4.MaxLength = 60;
            gunaTextBox5.MaxLength = 11;
            gunaTextBox6.MaxLength = 200;
            gunaTextBox7.MaxLength = 40;
        }

        private void guna2Button1_Click(object sender, EventArgs e) // Butona Basıldığı Zaman Güncelleme İşlemleri Gerçekleştirilir.
        {
            if ((string.IsNullOrEmpty(gunaTextBox1.Text)) || (string.IsNullOrEmpty(gunaTextBox2.Text)) || (string.IsNullOrEmpty(gunaTextBox3.Text)) || (string.IsNullOrEmpty(gunaTextBox4.Text)) || (string.IsNullOrEmpty(gunaTextBox5.Text)) || (string.IsNullOrEmpty(gunaTextBox6.Text)))
            { // Metimn Kutularının Boş Olup Olmadığı Kontrol Edilir.
                MessageBox.Show("Bu Alanlar Boş Bırakılamaz!");
            }
            else
            { // Eğer Metin Kutuları Boş Değilse Uzunluk Uygunlukları Kontrol Edilir.
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

                    if (MessageBox.Show("Kaydı Onaylıyor Musunuz?", "Bildiri", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        // Mesaj Kutusundaki Soruya Olumlu Cevap Verilirse Belirtlilen Formlar Açılır ve Belirtilen Fonksiyonlar Çağırılarak Gerekli İşlemler Yapılır.
                        ((Form3)Application.OpenForms["Form3"]).musteriupdate(gunaTextBox1.Text, gunaTextBox2.Text, gunaTextBox3.Text, gunaTextBox4.Text, gunaTextBox5.Text, gunaTextBox6.Text, gunaTextBox7.Text);
                        ((Form3)Application.OpenForms["Form3"]).baglanti("Select * from Musteri");
                        this.Close(); 
                    }
                    else
                    {
                        MessageBox.Show("Kayıt İptal Edildi!");
                        this.Close();
                    }
                }
            }
            
        }
    }
}
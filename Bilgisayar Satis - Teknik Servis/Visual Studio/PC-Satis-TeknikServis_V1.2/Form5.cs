using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// MÜŞTERİ EKLEME EKRANI

namespace PC_Satis_TeknikServis_V1._2
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // Metin Kutularına Metin Ataması Yapılır ve Metinlerin Uzunluğu Belirlenir.
            gunaTextBox1.Text = "";
            gunaTextBox2.Text = "";
            gunaTextBox3.Text = "";
            gunaTextBox4.Text = "";
            gunaTextBox5.Text = "";
            gunaTextBox6.Text = "";
            gunaTextBox7.Text = "";
            gunaTextBox1.MaxLength = 11;
            gunaTextBox2.MaxLength = 45;
            gunaTextBox3.MaxLength = 20;
            gunaTextBox4.MaxLength = 60;
            gunaTextBox5.MaxLength = 11;
            gunaTextBox6.MaxLength = 200;
            gunaTextBox7.MaxLength = 40;

        }

        private void guna2Button1_Click(object sender, EventArgs e) // Butona Basıldığı Zaman Kayıt İşlemleri Başlar.
        {
            if ((string.IsNullOrEmpty(gunaTextBox1.Text)) || (string.IsNullOrEmpty(gunaTextBox2.Text)) || (string.IsNullOrEmpty(gunaTextBox3.Text)) || (string.IsNullOrEmpty(gunaTextBox4.Text)) || (string.IsNullOrEmpty(gunaTextBox5.Text)) || (string.IsNullOrEmpty(gunaTextBox6.Text)))
            { // Metin Kutularının Boş Olup Olmadığı Kontrol Edilir.
                MessageBox.Show("Bu Alanlar Boş Bırakılamaz!");
            }
            else
            { // Metin Kutuları Boş Değilse İçindeki Metinlerin Uzunluğunun Uygunluğu Kontrol Edilir.
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
                        // Belirtilen Formlar Açılır ve Belirtilen Fonksiyonlar Çağırılır.
                        ((Form3)Application.OpenForms["Form3"]).musteriekle(gunaTextBox1.Text, gunaTextBox2.Text, gunaTextBox3.Text, gunaTextBox4.Text, gunaTextBox5.Text, gunaTextBox6.Text, gunaTextBox7.Text);
                        ((Form3)Application.OpenForms["Form3"]).baglanti("Select * from Musteri");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Kayıt İptal Edildi!"); // Mesaj Kutusu
                        this.Close();
                    }
                }
            }
            

        }
    
    }
}
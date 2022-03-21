using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// SİPARİŞ EKLEME EKRANI

namespace PC_Satis_TeknikServis_V1._2
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // Metin Kutularına Metin Ataması Yapılır ve Metinlerin Uzunlukları Belirlenir.
            gunaTextBox1.Text = "";
            gunaTextBox2.Text = "";
            gunaTextBox3.Text = "";
            gunaTextBox4.Text = "";
            gunaTextBox5.Text = "";
            gunaTextBox6.Text = "";
            gunaTextBox1.MaxLength = 40;
            gunaTextBox2.MaxLength = 4;
            gunaTextBox3.MaxLength = 25;
            gunaTextBox4.MaxLength = 30;
            gunaTextBox5.MaxLength = 16;
            gunaTextBox6.MaxLength = 10;


        }

        private void guna2Button1_Click(object sender, EventArgs e) // Butona Basıldığı Zaman Ekleme İşlemleri Başlar.
        {
            if ((string.IsNullOrEmpty(gunaTextBox1.Text)) || (string.IsNullOrEmpty(gunaTextBox2.Text)) || (string.IsNullOrEmpty(gunaTextBox3.Text)) || (string.IsNullOrEmpty(gunaTextBox4.Text)) || (string.IsNullOrEmpty(gunaTextBox5.Text)) || (string.IsNullOrEmpty(gunaTextBox6.Text)))
            { // Metin Kutularının Boş Olup Olmadığı Kontrol Edilir.
                MessageBox.Show("Bu Alanlar Boş Bırakılamaz!");
            }
            else
            {
                if (MessageBox.Show("Kaydı Onaylıyor Musunuz?", "Bildiri", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                { // Mesaj Kutusundaki Soruya Olumlu Cevap Verilirse Belirtilen Formdaki İstenilen Fonksiyon Çağırılır ve İşlemler Yapılır.
                    ((Form3)Application.OpenForms["Form3"]).siparisekle(gunaTextBox1.Text, gunaTextBox2.Text, gunaTextBox3.Text, gunaTextBox4.Text, gunaTextBox5.Text, gunaTextBox6.Text);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Kayıt İptal Edildi!");
                    this.Close();
                }
            }
            ((Form3)Application.OpenForms["Form3"]).baglanti("Select * from Siparis"); // Form3 Açılır ve baglanti Fonksiyonu Çağırılarak İstenilen İşlemler Yapılır.
        }
    }
}
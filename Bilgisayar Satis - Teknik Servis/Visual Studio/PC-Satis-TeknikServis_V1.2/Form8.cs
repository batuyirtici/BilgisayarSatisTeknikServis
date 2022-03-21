using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// SİPARİŞ GÜNCELLEME EKRANI

namespace PC_Satis_TeknikServis_V1._2
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            // Metin Kutularının Uzunluğu Belirlenir.
            gunaTextBox1.MaxLength = 40;
            gunaTextBox2.MaxLength = 4;
            gunaTextBox3.MaxLength = 25;
            gunaTextBox4.MaxLength = 30;
            gunaTextBox5.MaxLength = 16;
            gunaTextBox6.MaxLength = 10;
            string a1 = "", a2 = "", a3 = "", a4 = "", a5 = "", a6 = "";
            ((Form3)Application.OpenForms["Form3"]).siparisoku(ref a1, ref a2, ref a3, ref a4, ref a5, ref a6); // Form3 Açılır ve siparisoku Fonksiyonu Çağırılır.

            // Metin Kutularına Değer Ataması Yapılır.
            gunaTextBox1.Text = a1;
            gunaTextBox2.Text = a2;
            gunaTextBox3.Text = a3;
            gunaTextBox4.Text = a4;
            gunaTextBox5.Text = a5;
            gunaTextBox6.Text = a6;
        }

        private void guna2Button1_Click(object sender, EventArgs e) // Butona Basılınca Güncelleme İşlemleri Başlar.
        {
            if ((string.IsNullOrEmpty(gunaTextBox1.Text)) || (string.IsNullOrEmpty(gunaTextBox2.Text)) || (string.IsNullOrEmpty(gunaTextBox3.Text)) || (string.IsNullOrEmpty(gunaTextBox4.Text)) || (string.IsNullOrEmpty(gunaTextBox5.Text)) || (string.IsNullOrEmpty(gunaTextBox6.Text)))
            { // Metin Kutularının Boş Olup Olmadığı Kontrol Edilir.
                MessageBox.Show("Bu Alanlar Boş Bırakılamaz!");
            }
            else
            { // Metin Kutuları Boş Değilse Belirtilen Forma Gidilerek İstenilen Fonksiyon Çağırılır ve İşlemler Yapılır.
                ((Form3)Application.OpenForms["Form3"]).siparisupdate(gunaTextBox1.Text, gunaTextBox2.Text, gunaTextBox3.Text, gunaTextBox4.Text, gunaTextBox5.Text, gunaTextBox6.Text);
                ((Form3)Application.OpenForms["Form3"]).baglanti("Select * from Siparis");
                this.Close();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// ÜRETİCİ FİRMA EKLEME EKRANI

namespace PC_Satis_TeknikServis_V1._2
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
            
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            // Metin Kutularına Metin Ataması Yapılır ve Metinlerin Uzunlukları Belirlenir.
            gunaTextBox1.Text = "";
            gunaTextBox2.Text = "";
            gunaTextBox3.Text = "";
            gunaTextBox4.Text = "";
            gunaTextBox5.Text = "";
            gunaTextBox1.MaxLength = 25;
            gunaTextBox2.MaxLength = 100;
            gunaTextBox3.MaxLength = 60;
            gunaTextBox4.MaxLength = 11;
            gunaTextBox5.MaxLength = 150;
        }

        private void guna2Button1_Click(object sender, EventArgs e) // Butona Basılarak Kayıt İşlemleri Başlatılır.
        {
            if((gunaTextBox1.Text==string.Empty)|| (gunaTextBox2.Text == string.Empty) || (gunaTextBox3.Text == string.Empty) || (gunaTextBox4.Text == string.Empty) || (gunaTextBox5.Text == string.Empty))
            { // Metin Kutularının Boş Olup Olmadığı Kontrol Edilir.
                MessageBox.Show("Bu Alanlar Boş Bırakılamaz!");
            }
            else
            { // Metin Kutuları Boş Değilse Belirtilen Forma Gidilerek İstenilen Fonksiyon Çağırılır ve İşlemler Yapılır.
                ((Form3)Application.OpenForms["Form3"]).ureticifirmaekle(gunaTextBox1.Text, gunaTextBox2.Text, gunaTextBox3.Text, gunaTextBox4.Text, gunaTextBox5.Text);
                ((Form3)Application.OpenForms["Form3"]).baglanti("Select * from UreticiFirma");
                this.Close();
            }
        }
    }
}
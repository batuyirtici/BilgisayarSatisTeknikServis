using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// TEKNİK SERVİS ELEMANI EKLEME EKRANI

namespace PC_Satis_TeknikServis_V1._2
{
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
        }

        private void Form13_Load(object sender, EventArgs e)
        {
            // Metin Kutularına Metin Atanır.
            gunaTextBox1.Text = "";
            gunaTextBox2.Text = "";
            gunaTextBox3.Text = "";
            gunaTextBox4.Text = "";
            gunaTextBox5.Text = "";
            gunaTextBox6.Text = "";
            gunaTextBox7.Text = "";

            // Metin Kutularının Uzunluğunu Ayarlar.
            gunaTextBox1.MaxLength = 10;
            gunaTextBox2.MaxLength = 45;
            gunaTextBox3.MaxLength = 20;
            gunaTextBox4.MaxLength = 11;
            gunaTextBox5.MaxLength = 11;
            gunaTextBox6.MaxLength = 60;
            gunaTextBox7.MaxLength = 150;

        }

        private void guna2Button1_Click(object sender, EventArgs e) // Bu Butona Basıldığı Zaman Metin Kutularının Boş Olup Olmadığı Kontrol Edilir.
        {
            if ((gunaTextBox1.Text == string.Empty) || (gunaTextBox2.Text == string.Empty) || (gunaTextBox3.Text == string.Empty) || (gunaTextBox4.Text == string.Empty) || (gunaTextBox5.Text == string.Empty) || (gunaTextBox6.Text == string.Empty) || (gunaTextBox7.Text == string.Empty))
            {
                MessageBox.Show("Bu Alanlar Boş Bırakılamaz!");
            }
            else
            {
                ((Form3)Application.OpenForms["Form3"]).teknikservisekle(gunaTextBox1.Text, gunaTextBox2.Text, gunaTextBox3.Text, gunaTextBox4.Text, gunaTextBox5.Text, gunaTextBox6.Text, gunaTextBox7.Text); // Form3 Açılır ve teknikservisekle Fonksiyonu Çağırılır.
                ((Form3)Application.OpenForms["Form3"]).baglanti("Select * from TeknikServis");
                this.Close();
            }
        }
    }
}
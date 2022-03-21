using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// TEKNİK SERVİS ÇALIŞANI GÜNCELLEME EKRANI

namespace PC_Satis_TeknikServis_V1._2
{
    public partial class Form14 : Form
    {
        public Form14()
        {
            InitializeComponent();
        }

        private void Form14_Load(object sender, EventArgs e)
        {
            // Metin Kutularının Uzunluğu Ayarlanır.
            gunaTextBox1.MaxLength = 10;
            gunaTextBox2.MaxLength = 45;
            gunaTextBox3.MaxLength = 20;
            gunaTextBox4.MaxLength = 11;
            gunaTextBox5.MaxLength = 11;
            gunaTextBox6.MaxLength = 60;
            gunaTextBox7.MaxLength = 150;
            string b1 = "", b2 = "", b3 = "", b4 = "", b5 = "", b6 = "", b7 = "";
            ((Form3)Application.OpenForms["Form3"]).teknikservisoku(ref b1, ref b2, ref b3, ref b4, ref b5, ref b6, ref b7); // Form3 Açılır ve teknikservisoku Fonksiyonu Çağırılır.

            // Metin Kutularına Metin Atanır.
            gunaTextBox1.Text = b1;
            gunaTextBox2.Text = b2;
            gunaTextBox3.Text = b3;
            gunaTextBox4.Text = b4;
            gunaTextBox5.Text = b5;
            gunaTextBox6.Text = b6;
            gunaTextBox7.Text = b7;
        }

        private void guna2Button1_Click(object sender, EventArgs e) // Butona Basıldığı Zaman Metin Kutularının Dolu Olup Olmadığı Kontrol Edilir.
        {
            if ((gunaTextBox1.Text == string.Empty) || (gunaTextBox2.Text == string.Empty) || (gunaTextBox3.Text == string.Empty) || (gunaTextBox4.Text == string.Empty) || (gunaTextBox5.Text == string.Empty) || (gunaTextBox6.Text == string.Empty) || (gunaTextBox7.Text == string.Empty))
            {
                MessageBox.Show("Bu Alanlar Boş Bırakılamaz!");
            }
            else
            {
                ((Form3)Application.OpenForms["Form3"]).teknikservisupdate(gunaTextBox1.Text, gunaTextBox2.Text, gunaTextBox3.Text, gunaTextBox4.Text, gunaTextBox5.Text, gunaTextBox6.Text, gunaTextBox7.Text);
                ((Form3)Application.OpenForms["Form3"]).baglanti("Select * from TeknikServis");
                this.Close();
            }
        }
    }
}
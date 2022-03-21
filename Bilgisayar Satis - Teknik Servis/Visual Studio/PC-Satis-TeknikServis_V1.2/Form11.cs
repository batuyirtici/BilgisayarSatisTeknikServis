using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// BİLGİSAYAR EKLEME EKRANI

namespace PC_Satis_TeknikServis_V1._2
{
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            // Metin Kutularına Metin Ataması Yapılır.
            gunaTextBox2.Text = "";
            gunaTextBox3.Text = "";
            gunaTextBox4.Text = "";
            gunaTextBox5.Text = "";
            gunaTextBox6.Text = "";
            gunaTextBox7.Text = "";
            gunaTextBox8.Text = "";
            gunaTextBox9.Text = "";
            gunaTextBox10.Text = "";

            // Metin Kutularının Uzunluğu Ayarlanır.
            gunaTextBox2.MaxLength = 15;
            gunaTextBox3.MaxLength = 25;
            gunaTextBox4.MaxLength = 10;
            gunaTextBox5.MaxLength = 30;
            gunaTextBox6.MaxLength = 30;
            gunaTextBox7.MaxLength = 30;
            gunaTextBox8.MaxLength = 30;
            gunaTextBox9.MaxLength = 20;
            gunaTextBox10.MaxLength = 10;
        }

        private void guna2Button1_Click(object sender, EventArgs e) // Butona Basıldığı Zaman Metin Kutularının Boş Olup Olmadığı Kontrol Edilir.
        {
            if ((gunaTextBox2.Text == string.Empty) || (gunaTextBox3.Text == string.Empty) || (gunaTextBox4.Text == string.Empty) || (gunaTextBox5.Text == string.Empty) || (gunaTextBox6.Text == string.Empty) || (gunaTextBox7.Text == string.Empty) || (gunaTextBox8.Text == string.Empty) || (gunaTextBox9.Text == string.Empty) || (gunaTextBox10.Text == string.Empty))
            {
                MessageBox.Show("Bu Alanlar Boş Bırakılamaz!");
            }
            else
            {
                ((Form3)Application.OpenForms["Form3"]).bilgisayarekle(gunaTextBox2.Text, gunaTextBox3.Text, gunaTextBox4.Text, gunaTextBox5.Text, gunaTextBox6.Text, gunaTextBox7.Text, gunaTextBox8.Text, gunaTextBox9.Text, gunaTextBox10.Text); // Form3 Açılır ve bilgisayarekle Fonksiyonu Getirilir.
                ((Form3)Application.OpenForms["Form3"]).baglanti("Select * from bilgisayar");
                this.Close();
            }
        }
    }
}
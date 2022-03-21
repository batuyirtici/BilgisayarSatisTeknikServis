using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// BİLGİSAYAR GÜNCELLEME EKRANI

namespace PC_Satis_TeknikServis_V1._2
{
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            // Metin Kutularının Uzunluğu Belirlenir.
            gunaTextBox2.MaxLength = 15;
            gunaTextBox3.MaxLength = 25;
            gunaTextBox4.MaxLength = 10;
            gunaTextBox5.MaxLength = 30;
            gunaTextBox6.MaxLength = 30;
            gunaTextBox7.MaxLength = 30;
            gunaTextBox8.MaxLength = 30;
            gunaTextBox9.MaxLength = 20;
            gunaTextBox10.MaxLength = 10;
            string b2 = "", b3 = "", b4 = "", b5 = "", b6 = "", b7 = "", b8 = "", b9 = "", b10 = "";
            ((Form3)Application.OpenForms["Form3"]).bilgisayaroku(ref b2, ref b3, ref b4, ref b5, ref b6, ref b7, ref b8, ref b9, ref b10); // Form3 Açılır ve bilgisayaroku Fonksiyonu Getirilir.
           
            // Metin Kutularına Metin Ataması Yapılır.
            gunaTextBox2.Text = b2;
            gunaTextBox3.Text = b3;
            gunaTextBox4.Text = b4;
            gunaTextBox5.Text = b5;
            gunaTextBox6.Text = b6;
            gunaTextBox7.Text = b7;
            gunaTextBox8.Text = b8;
            gunaTextBox9.Text = b9;
            gunaTextBox10.Text = b10;
        }

        private void guna2Button1_Click(object sender, EventArgs e) // Butona Basıldığı Zaman Metin Kutularının Dolu Olup Olmadıkları Kontrol Edilir.
        {
            if ((gunaTextBox2.Text == string.Empty) || (gunaTextBox3.Text == string.Empty) || (gunaTextBox4.Text == string.Empty) || (gunaTextBox5.Text == string.Empty) || (gunaTextBox6.Text == string.Empty) || (gunaTextBox7.Text == string.Empty) || (gunaTextBox8.Text == string.Empty) || (gunaTextBox9.Text == string.Empty) || (gunaTextBox10.Text == string.Empty))
            {
                MessageBox.Show("Bu Alanlar Boş Bırakılamaz!");
            }
            else
            {
                ((Form3)Application.OpenForms["Form3"]).bilgisayarupdate(gunaTextBox2.Text, gunaTextBox3.Text, gunaTextBox4.Text, gunaTextBox5.Text, gunaTextBox6.Text, gunaTextBox7.Text, gunaTextBox8.Text, gunaTextBox9.Text, gunaTextBox10.Text); // Form3 Açılır ve bilgisayarupdate Fonksiyonu Getirilir.
                ((Form3)Application.OpenForms["Form3"]).baglanti("Select * from bilgisayar");
                this.Close();
            }
        }
    }
}
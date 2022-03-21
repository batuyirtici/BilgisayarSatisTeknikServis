using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// ÜRETİCİ FİRMA GÜNCELLEME EKRANI

namespace PC_Satis_TeknikServis_V1._2
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            gunaTextBox1.MaxLength = 25;   // Metin Kutularının Uzunluğunu Ayarlar.
            gunaTextBox2.MaxLength = 100;
            gunaTextBox3.MaxLength = 60;
            gunaTextBox4.MaxLength = 11;
            gunaTextBox5.MaxLength = 150;
            string a1="", a2 = "", a3 = "", a4 = "", a5 = "";
            ((Form3)Application.OpenForms["Form3"]).ureticifirmaoku(ref a1,ref a2,ref a3,ref a4,ref a5); // Form 3 Açılır ve ureticifirmaoku Fonksiyonunu Çağırılır.
            gunaTextBox1.Text = a1;        // Metin Kutularına Metin Atar.
            gunaTextBox2.Text = a2;
            gunaTextBox3.Text = a3;
            gunaTextBox4.Text = a4;
            gunaTextBox5.Text = a5;
        }

        private void guna2Button1_Click(object sender, EventArgs e) // Butona Tıklandığı Zaman Metin Kutularının Boş Olup Olmadığını Kontrol Eder.
        {
            if ((gunaTextBox1.Text == string.Empty) || (gunaTextBox2.Text == string.Empty) || (gunaTextBox3.Text == string.Empty) || (gunaTextBox4.Text == string.Empty) || (gunaTextBox5.Text == string.Empty))
            {
                MessageBox.Show("Bu Alanlar Boş Bırakılamaz!");
            }
            else
            {
                ((Form3)Application.OpenForms["Form3"]).ureticifirmaupdate(gunaTextBox1.Text, gunaTextBox2.Text, gunaTextBox3.Text, gunaTextBox4.Text, gunaTextBox5.Text);
                ((Form3)Application.OpenForms["Form3"]).baglanti("Select * from UreticiFirma");
                this.Close();
            }
        }
    }
}
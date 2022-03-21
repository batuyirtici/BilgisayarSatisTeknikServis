using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// YEDEKLE - YEDEKTEN DÖNME (BACKUP - RESTORE) EKRANI

namespace PC_Satis_TeknikServis_V1._2
{
    public partial class Form99 : Form
    {
        public Form99()
        {
            InitializeComponent();
        }

        private void Form99_Load(object sender, EventArgs e)
        {
            // Metin Kutusuna Metin Atanır.
            gunaTextBox1.Text = "";
            gunaTextBox2.Text = "";
        }

        private void guna2Button1_Click(object sender, EventArgs e) // Butona Basılınca İstenilen Klasör Yolu Seçilir.
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog(); // Bilgisayarda Bulunan Klasör Dizinlerini Görüntülemeyi Sağlar.
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                gunaTextBox1.Text = dlg.SelectedPath;
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)// Butona Basılınca Form3 Açılır ve vyedek Fonksiyonu Çağırılırak Yedekleme İşlemi Yapılır.
        {
            ((Form3)Application.OpenForms["Form3"]).vyedek(gunaTextBox1.Text);
            
        }

        private void guna2Button3_Click(object sender, EventArgs e)// Butona Basılınca İstenilen Klasör Yolu Seçilir.
        {
            OpenFileDialog dlg = new OpenFileDialog(); // Bir Dialog Ekranı ile Dosya Seçmeyi Sağlar.
            dlg.Filter = "SQL Server database backup files|*.bak*";
            dlg.Title = "Database Restore";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                gunaTextBox2.Text = dlg.FileName;
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)// Butona Basılınca Form3 Açılır ve vyedektendon Fonksiyonu Çağırılarak Yedekten Dönme İşlemi Gerçekleştirilir.
        {
            ((Form3)Application.OpenForms["Form3"]).vyedektendon(gunaTextBox2.Text);
        }
    }
}
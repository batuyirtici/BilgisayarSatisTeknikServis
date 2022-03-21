using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// KULLANICI YETKİLENDİRME EKRANI

namespace PC_Satis_TeknikServis_V1._2
{
    public partial class Form16 : Form
    {
        public Form16()
        {
            InitializeComponent();
        }

        private void Form16_Load(object sender, EventArgs e)
        {
            // İşaretleme Kutularına Metin Atanır.
            gunaCheckBox1.Text = "Okuma";
            gunaCheckBox2.Text = "Yazma";
            gunaCheckBox3.Text = "Güncelleme";
            gunaCheckBox4.Text = "Silme";
            ((Form3)Application.OpenForms["Form3"]).yetkioku(ref checkokuma, ref checkyazma, ref checkguncelleme, ref checksilme); // Form3 Açılır ve yetkioku Fonksiyonu Çağırılır.

            // İşaretleme Kutularının İşaretlenip İşaretlenmediği Kontrol Edilir.
            if (checkokuma == "True")
            {
                gunaCheckBox1.Checked = true;
            }
            if (checkyazma == "True")
            {
                gunaCheckBox2.Checked = true;
            }
            if (checkguncelleme == "True")
            {
                gunaCheckBox3.Checked = true;
            }
            if (checksilme == "True")
            {
                gunaCheckBox4.Checked = true;
            }

        }
        private string checkokuma, checkyazma, checkguncelleme, checksilme;

        // Kontrol Fonksiyonları
        private void gunaCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox1.Checked)
            {
                checkokuma = "True";
            }
            else
            {
                checkokuma = "False";
            }
        }
        private void gunaCheckBox2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (gunaCheckBox2.Checked)
            {
                checkyazma = "True";
            }
            else
            {
                checkyazma = "False";
            }
        }
        private void gunaCheckBox3_CheckedChanged_1(object sender, EventArgs e)
        {
            if (gunaCheckBox3.Checked)
            {
                checkguncelleme = "True";
            }
            else
            {
                checkguncelleme = "False";
            }
        }

        private void gunaCheckBox4_CheckedChanged_1(object sender, EventArgs e)
        {
            if (gunaCheckBox4.Checked)
            {
                checksilme = "True";
            }
            else
            {
                checksilme = "False";
            }
        }
        private void gunaButton1_Click(object sender, EventArgs e) // Bu Butona Basıldığı Zaman İşaret Kutularının İşaretlenip İşaretlenmediği Kontrol Edilir.
        {
            if((checkokuma=="True") && (checkyazma == "True") && (checkguncelleme == "True") && (checksilme == "True")) // Eğer Bütün Kutucuklar İşaretliyse Yetkilendirme İşlemine Geçilir.
            {
                if(MessageBox.Show("Bu Kullanıcıya Admin Yetkileri Vermek Üzeresiniz, Devam Etmek İsteğinize Emin Misiniz?\n","pcsatis", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ((Form3)Application.OpenForms["Form3"]).yetkilendirme(checkokuma, checkyazma, checkguncelleme, checksilme);
                    ((Form3)Application.OpenForms["Form3"]).baglanti("Select * From Kullanici");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Admin Yetkilendirmesi İptal Edildi..");
                    this.Close();
                }
            }
            else
            {
                ((Form3)Application.OpenForms["Form3"]).yetkilendirme(checkokuma, checkyazma, checkguncelleme, checksilme);
                ((Form3)Application.OpenForms["Form3"]).baglanti("Select * From Kullanici");
                this.Close();
            }
            
            
        }
    }
}
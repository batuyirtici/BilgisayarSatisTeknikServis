using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

// KULLANICI PANELİ

namespace PC_Satis_TeknikServis_V1._2
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            readpclabel(gunaLabel1, "100");
            readpclabel(gunaLabel2, "101");
            readpclabel(gunaLabel3, "102");
            readpclabel(gunaLabel4, "103");
            readpclabel(gunaLabel5, "104");

            gunaLabel6.Text = "Hosgeldin "+veri+"!";

            readimg(gunaPictureBox1,"100");
            readimg(gunaPictureBox2,"101");
            readimg(gunaPictureBox3,"102");
            readimg(gunaPictureBox4,"103");
            readimg(gunaPictureBox5,"104");

        }
        private string pcid;
        public string pciddondur()
        {
            return pcid;
        }
        private string veri = ((Form1)Application.OpenForms["Form1"]).veridondur();
        private bool okuma = ((Form1)Application.OpenForms["Form1"]).okumadondur();

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            if (okuma == true)
            {
                Form18 f18 = new Form18();
                f18.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bu İşlemi Gerçekleştirmek İçin Yetkiniz Bulunmamaktadır!");
            }
        }
        private void readimg(PictureBox picture, string deger)
        {
            SqlConnection baglanti = new SqlConnection("Server = localhost; Database = pcsatis; Integrated Security = SSPI;");
            SqlDataAdapter dataAdapter = new SqlDataAdapter(new SqlCommand("SELECT imgfile FROM pcimage WHERE pcid = "+deger+"", baglanti));
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);

            if (dataSet.Tables[0].Rows.Count == 1)
            {
                Byte[] data = new Byte[0];
                data = (Byte[])(dataSet.Tables[0].Rows[0]["imgfile"]);
                MemoryStream mem = new MemoryStream(data);
                picture.Image = Image.FromStream(mem);
            }
        }

        private void readpclabel(Label lbl, string id)
        {
            SqlConnection cn = new SqlConnection("Server = localhost; Database = pcsatis; Integrated Security = SSPI;");
            using (SqlCommand cmd = new SqlCommand("SELECT * From bilgisayar where pcid=" + id + ""))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;
                cn.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    sdr.Read();
                    lbl.Text = sdr["firmaAd"].ToString() +" "+ sdr["modelno"].ToString();
                }
                cn.Close();
            }
        }

        private void gunaPictureBox1_Click(object sender, EventArgs e)
        {
            pcid = "100";
            pciddondur();
            Form17 f17 = new Form17();
            f17.ShowDialog();
        }

        private void gunaPictureBox2_Click(object sender, EventArgs e)
        {
            pcid = "101";
            pciddondur();
            Form17 f17 = new Form17();
            f17.ShowDialog();
        }

        private void gunaPictureBox3_Click(object sender, EventArgs e)
        {
            pcid = "102";
            pciddondur();
            Form17 f17 = new Form17();
            f17.ShowDialog();
        }

        private void gunaPictureBox4_Click(object sender, EventArgs e)
        {
            pcid = "103";
            pciddondur();
            Form17 f17 = new Form17();
            f17.ShowDialog();
        }

        private void gunaPictureBox5_Click(object sender, EventArgs e)
        {
            pcid = "104";
            pciddondur();
            Form17 f17 = new Form17();
            f17.ShowDialog();
        }
    }
}
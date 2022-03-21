using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;
using System.Data.OleDb;

// DIŞA AKTARIM (EXPORT) EKRANI

namespace PC_Satis_TeknikServis_V1._2
{
    public partial class Form19 : Form
    {
        public Form19()
        {
            InitializeComponent();
        }

        private void Form19_Load(object sender, EventArgs e)
        {
            // TextBox ve ComboBox Metinleri

            gunaTextBox2.Text = "";

            guna2ComboBox2.Items.Add("Musteri");
            guna2ComboBox2.Items.Add("siparis");
            guna2ComboBox2.Items.Add("UreticiFirma");
            guna2ComboBox2.Items.Add("bilgisayar");
            guna2ComboBox2.Items.Add("TeknikServis");
            guna2ComboBox2.Items.Add("Kullanici");
            guna2ComboBox2.Items.Add("SilinenMusteri");
            guna2ComboBox2.Items.Add("Silinensiparis");
            guna2ComboBox2.Items.Add("SilinenUreticiFirma");
            guna2ComboBox2.Items.Add("Silinenbilgisayar");
            guna2ComboBox2.Items.Add("SilinenTeknikServis");
            guna2ComboBox2.Items.Add("SilinenKullanici");

            /*guna2ComboBox2.Items.Add("Müşteri");
            guna2ComboBox2.Items.Add("Sipariş");
            guna2ComboBox2.Items.Add("Üretici Firma");
            guna2ComboBox2.Items.Add("Bilgisayar");
            guna2ComboBox2.Items.Add("Teknik Servis");
            guna2ComboBox2.Items.Add("Kullanıcı");
            guna2ComboBox2.Items.Add("Silinen Müşteri");
            guna2ComboBox2.Items.Add("Silinen Sipariş");
            guna2ComboBox2.Items.Add("Silinen Üretici Firma");
            guna2ComboBox2.Items.Add("Silinen Bilgisayar");
            guna2ComboBox2.Items.Add("Silinen Teknik Servis");
            guna2ComboBox2.Items.Add("Silinen Kullanıcı");*/
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog(); // Bilgisayarda Bulunan Klasör Dizinlerini Görüntülemeyi Sağlar.
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                gunaTextBox2.Text = dlg.SelectedPath;
            }
        }
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (secilitablo == "NULL")
            {
                MessageBox.Show("Lütfen Önce Dışa Aktarılacak Bir Tablo Seçin!");
            }
            else
            {
                if (gunaTextBox2.Text == string.Empty)
                {
                    MessageBox.Show("Lütfen Önce Kaydedilecek Bir Yer Seçin!");
                }
                else
                {
                    ExportDataFromExcel(secilitablo);
                }
                
            }
        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            secilitablo = guna2ComboBox2.SelectedItem.ToString();

        }

        private string secilitablo="NULL";

        public void ExportDataFromExcel(string tablo) // Excel'i İşin İçine Dahil Etmemizi Sağlayan Fonksiyon
        {
            // Hata Komutları
            try
            {
                SqlConnection cnn; // Veritabanına Bağlanmayı Sağlar.
                string connectionString = null;
                string sql = null;
                string data = null;
                int i = 0;
                int j = 0;

                // Excel için Tanımlamalar
                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;

                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                connectionString = "Server = localhost; Database = pcsatis; Integrated Security = SSPI;";
                cnn = new SqlConnection(connectionString);
                cnn.Open(); // Bağlantı Açılır.
                sql = "SELECT * FROM " + tablo + ""; // Veritabanından Veriler Getirilir.
                SqlDataAdapter dscmd = new SqlDataAdapter(sql, cnn);
                DataSet ds = new DataSet(); 
                dscmd.Fill(ds); // İçindeki Satırları dataSet Veri Kaynağı ile Eşleşecek Şekilde Ekler veya Yeniler.


                using (SqlCommand command = new SqlCommand("SELECT * FROM " + tablo + "", cnn))
                {
                    SqlDataReader reader = command.ExecuteReader(); // Verileri Almamızı Sağlar.
                    while (reader.Read())
                    {
                        for (int z = 0; z < reader.FieldCount; z++)
                        {
                            xlWorkSheet.Cells[z + 1] = reader.GetName(z);
                            for (i = 1; i <= ds.Tables[0].Rows.Count; i++)
                            {
                                for (j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
                                {

                                    data = ds.Tables[0].Rows[i-1].ItemArray[j].ToString();
                                    xlWorkSheet.Cells[i + 1, j + 1] = data;

                                }
                            }
                        }

                    }
                }


                xlWorkBook.SaveAs(gunaTextBox2.Text + "\\" + "" + tablo + " Tablosu" + ".xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);

                MessageBox.Show("Excel Dosyası Oluşturuldu!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir Hata Meydana Geldi! " + ex.ToString());

            }
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Bir Hata Oluştu!" + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
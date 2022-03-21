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

// ADMİN PANELİ

namespace PC_Satis_TeknikServis_V1._2
{
    public partial class Form3 : Form
    {
        public Form3( )
        {
            InitializeComponent();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            butonlar(false, false, false, false, false, false, false);

            // Başlık ve Metin Kutularına Metin Atamasın Yapılır.
            label6.Text = "PC Satış - Teknik Servis";
            
            guna2Button1.Text = "Müşteriler";
            guna2Button2.Text = "Siparişler";
            guna2Button3.Text = "Üretici Firma";
            guna2Button4.Text = "Bilgisayarlar";
            guna2Button5.Text = "Teknik Servis";
            guna2Button21.Text = "Database Backup/Restore";
            guna2Button22.Text = "Export Table";
            guna2Button26.Text = "Import Table";
            guna2Button23.Text = "Silinmiş Veriler";
            guna2Button24.Text = "Kullanıcı";
            guna2Button25.Text = "Yetkilendirme";
            gunaDataGridView1.ReadOnly = true;
        }

        private void gunaDataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            // Hata Komutları
            try
            {
                int rowindex = gunaDataGridView1.CurrentCell.RowIndex; // Hücrenin Üst Satırının Dizinini Alır. //Seçili olan dizindeki 1.sütünun içindeki veriyi alır
                seciliveri = gunaDataGridView1.Rows[rowindex].Cells[0].Value.ToString();  // ''
            }
            catch (Exception ex)
            {

            }

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            butonlar(true, false, false, false, false, false, true);
            baglanti("Select * From Musteri");
            gunaLabel1.Text = "Musteri ID Numarası Ara";
            guna2Button6.Text = "Müşteri Kaydet";
            guna2Button7.Text = "Seçilen Müşteriyi Sil";
            guna2Button8.Text = "Seçilen Müşteriyi Güncelle";
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            butonlar(false, true, false, false, false, false, true);
            baglanti("Select * From Siparis");
            gunaLabel1.Text = "Siparis Numarası Ara";
            guna2Button9.Text = "Yeni Sipariş Ekle";
            guna2Button10.Text = "Seçilen Siparişi Sil";
            guna2Button11.Text = "Seçilen Siparişi Güncelle";
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            butonlar(false, false, true, false, false, false, true);
            baglanti("select * From UreticiFirma");
            gunaLabel1.Text = "Firma Adı Ara";
            guna2Button12.Text = "Yeni Üretici Firma Kaydet";
            guna2Button13.Text = "Seçilen Üretici Firma Bilgilerini Sil";
            guna2Button14.Text = "Seçilen Üretici Firma Bilgilerini Güncelle";
        }

        private void Guna2Button4_Click(object sender, EventArgs e)
        {
            butonlar(false, false, false, true, false, false, true);
            baglanti("Select * From bilgisayar");
            gunaLabel1.Text = "PC ID Numarası Ara";
            guna2Button15.Text = "Yeni Bilgisayar Ekle";
            guna2Button16.Text = "Seçilen Bilgisayarı sil";
            guna2Button17.Text = "Seçilen Bilgisayarı Güncelle";
        }

        private void Guna2Button5_Click(object sender, EventArgs e)
        {
            butonlar(false, false, false, false, true, false, true);
            baglanti("select * From TeknikServis");
            gunaLabel1.Text = "Personel ID Numarası Ara";
            guna2Button18.Text = "Yeni Teknik Servis Çalışanı Ekle";
            guna2Button19.Text = "Teknik Servis Çalışanını Sil";
            guna2Button20.Text = "Seçilen Teknik Servis Çalışanını Güncelle";
        }

        private void guna2Button24_Click(object sender, EventArgs e) // Kullanici butonu
        {
            baglanti("Select * From Kullanici");
            butonlar(false, false, false, false, false, true, true);
            gunaLabel1.Text = "Musteri ID Numarası ile Ara";
        }

        private void Guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            ara("Musteri", "MusteriID", guna2TextBox1.Text);
        }

        private void Guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            ara("siparis", "siparisno", guna2TextBox2.Text);
        }

        private void Guna2TextBox3_TextChanged(object sender, EventArgs e)
        {
            ara("UreticiFirma", "firmaAd", guna2TextBox3.Text);
        }

        private void Guna2TextBox4_TextChanged(object sender, EventArgs e)
        {
            ara("bilgisayar", "pcid", guna2TextBox4.Text);
        }

        private void Guna2TextBox5_TextChanged(object sender, EventArgs e)
        {
            ara("TeknikServis", "PersonelID", guna2TextBox5.Text);
        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {
            ara("Kullanici", "MusteriID", guna2TextBox6.Text);
        }

        private void guna2Button6_Click(object sender, EventArgs e) //musteri ekle
        {
            Form5 f5 = new Form5();
            f5.ShowDialog();
        }

        private void guna2Button7_Click(object sender, EventArgs e) //musteri sil
        {
            musterisil();
        }

        private void guna2Button8_Click(object sender, EventArgs e)// Secilen Musteriyi Guncelle
        {
            Form6 f6 = new Form6();
            f6.ShowDialog();
        }

        private void Guna2Button9_Click(object sender, EventArgs e)// Yeni Sipariş Ekle
        {
            Form7 f7 = new Form7();
            f7.ShowDialog();

        }

        private void Guna2Button10_Click(object sender, EventArgs e)//Seçilen Siparişi Sil
        {
            siparissil();
        }

        private void Guna2Button11_Click(object sender, EventArgs e)//Seçilen Siparişi Güncelle
        {
            Form8 f8 = new Form8();
            f8.ShowDialog();
        }

        private void Guna2Button12_Click(object sender, EventArgs e)// Yeni üretici firma kaydet
        {
            Form9 f9 = new Form9();
            f9.ShowDialog();
        }

        private void Guna2Button13_Click(object sender, EventArgs e)//Seçilen Üretici firma bilgilerini Sil
        {
            ureticifirmasil();
        }

        private void Guna2Button14_Click(object sender, EventArgs e)//Seçilen Üretici Firma Bilgilerini Güncelle
        {
            Form10 f10 = new Form10();
            f10.ShowDialog();
        }

        private void Guna2Button15_Click(object sender, EventArgs e)//Yeni Bilgisayar Ekle
        {
            Form11 f11 = new Form11();
            f11.ShowDialog();
        }

        private void Guna2Button16_Click(object sender, EventArgs e)//Seçilen Bilgisayarı sil
        {
            bilgisayarsil();
        }

        private void Guna2Button17_Click(object sender, EventArgs e)//Seçilen Bilgisayarı Güncelle
        {
            Form12 f12 = new Form12();
            f12.ShowDialog();
        }

        private void Guna2Button18_Click(object sender, EventArgs e)//Yeni Teknik Servis Elemanı Ekle
        {
            Form13 f13 = new Form13();
            f13.ShowDialog();
        }

        private void Guna2Button19_Click(object sender, EventArgs e)//Teknik Servis Elemanını Sil
        {
            teknikservissil();
        }

        private void Guna2Button20_Click(object sender, EventArgs e)//Seçilen Teknik Servis Elemanınını Güncelle
        {
            Form14 f14 = new Form14();
            f14.ShowDialog();
        }

        private void Guna2Button21_Click(object sender, EventArgs e)// database backup/restore
        {
            butonlar(false, false, false, false, false, false, false);
            Form99 f99 = new Form99();
            f99.ShowDialog();
        }

        private void guna2Button22_Click(object sender, EventArgs e) // table export edici
        {
            Form19 f19 = new Form19();
            f19.ShowDialog();
        }
        private void guna2Button23_Click(object sender, EventArgs e) // Silinmis verileri acma
        {
            butonlar(false, false, false, false, false, false, false);
            Form15 f15 = new Form15();
            f15.Show();

        }

        private void guna2Button25_Click(object sender, EventArgs e) // Kullanici Yetkilendirme
        {
            if (seciliveri == "0")
            {
                MessageBox.Show("Sistem Yöneticisinin İzinlerinde Değişiklik Yapılamaz!");
            }
            else
            {
                Form16 f16 = new Form16();
                f16.ShowDialog();
            }
        }

        private void guna2Button26_Click(object sender, EventArgs e)
        {
            Form21 f21 = new Form21();
            f21.ShowDialog();
        }


        // FONKSİYONLAR
        private string dbname = "pcsatis"; // Veritabanı Adı Değişkene Atanır.
        private string seciliveri;

        private void ara(string tabloadi, string aranacakyer, string aranacakveri) // Arama Fonksiyonu
        {
            SqlConnection conn = new SqlConnection("Server = localhost; Database = " + dbname + "; Integrated Security = SSPI;"); // Veritabanı Bağlantısı Sağlanır.
            SqlCommand cmd = new SqlCommand("arama", conn); // Veritabanına Komut Verilmesini Sağlar.
            cmd.CommandType = CommandType.StoredProcedure; // Stored Procedure'i Kullanmamızı Sağlar.

            // Stored Procedure Parametre Girişi ve Parametre Tipi Yazılır.
            cmd.Parameters.Add("@tabloadi", SqlDbType.NVarChar, 30);
            cmd.Parameters.Add("@aranacakyer", SqlDbType.NVarChar, 30);
            cmd.Parameters.Add("@aranacakveri", SqlDbType.NVarChar, 30);

            // Parametreler Değişkenlere Atanır.
            cmd.Parameters["@tabloadi"].Value = tabloadi;
            cmd.Parameters["@aranacakyer"].Value = aranacakyer;
            cmd.Parameters["@aranacakveri"].Value = aranacakveri;

            conn.Open(); // Veritabanı Açılır.
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet dataset = new DataSet();
            da.Fill(dataset); // İçindeki Satırları dataSet Veri Kaynağı ile Eşleşecek Şekilde Ekler veya Yeniler.
            gunaDataGridView1.DataSource = dataset.Tables[0];
            conn.Close(); // Veritabanı Kapatılır.

        }

        public void baglanti(string veri) // Veritabanının Bağlandığı Fonksiyon
        {
            gunaDataGridView1.Columns.Clear(); // Ana Tablonun İçeriği Temizlenir.
            SqlConnection conn = new SqlConnection("Server = localhost; Database = " + dbname + "; Integrated Security = SSPI;");
            conn.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = conn;
            SqlDataAdapter dataadapter = new SqlDataAdapter(veri, conn);
            DataSet dataset = new DataSet();
            dataadapter.Fill(dataset);
            gunaDataGridView1.DataSource = dataset.Tables[0];
            conn.Close();
        }

        public void musteriekle(string xa, string xb, string xc, string xd, string xe, string xf,string xg) // Müşterilerin Eklenmesini Sağlayan Fonksiyon
        {
            
            SqlConnection baglanti = new SqlConnection("Server = localhost; Database = " + dbname + "; Integrated Security = SSPI;"); // Veritabanına Bağlanılmasını Sağlar.
            baglanti.Open(); // Veritabanına Bağlanılır.

            // Veritabanı İçerisine Ekleme Komutu Girilir ve Eklenilecek Parametreler Belirlenir.
            SqlCommand komut = new SqlCommand("insert into Musteri ( KimlikNo ,Ad ,Soyad ,MailAdres ,TelNo ,Adres, sifre) values (@KimlikNo,@Ad,@Soyad,@MailAdres,@TelNo,@Adres,@sifre)", baglanti);
            komut.Parameters.AddWithValue("@KimlikNo", xa);
            komut.Parameters.AddWithValue("@Ad", xb);
            komut.Parameters.AddWithValue("@Soyad", xc);
            komut.Parameters.AddWithValue("@MailAdres", xd);
            komut.Parameters.AddWithValue("@TelNo", xe);
            komut.Parameters.AddWithValue("@Adres", xf);
            komut.Parameters.AddWithValue("@sifre", xg);
            komut.ExecuteNonQuery(); // Kodu SQL'de Çalıştırıp Geriye Değer Döndüren Metod.
            baglanti.Close(); // Veritabanındaki Bağlantı Kesilir.
            MessageBox.Show("Kayıt Başarılı!");
        }

        public void musterisil() // Müşterilerin Silinmesini Sağlayan Fonksiyon
        {
            // Hata Komutları
            try
            {
                SqlConnection con = new SqlConnection("Server = localhost; Database = " + dbname + "; Integrated Security = SSPI;"); // Veritabanına Bağlanılmasını Sağlar.
                if (gunaDataGridView1.Rows.Count == 0)
                { // Eğer Ana Tablonun İçinde Veri Yoksa Aşağıdaki Uyarıyı Ekrana Getir.
                    MessageBox.Show("Silinecek Veri Yok", "Uyarı");
                }
                else
                { // Ana Tablonun İçinde Veri Varsa Aşağıdaki İşlemleri Yaparak Verileri Sil.
                    con.Open(); // Veritabanına Bağlanır.
                    SqlCommand komut = new SqlCommand("delete from Musteri where MusteriID=(" + seciliveri + ")", con); // Veritabanına Komut Verilmesini Sağlar.
                    if (MessageBox.Show("Seçilen Veriyi Silmek İstediğinize Emin Misiniz?\n", "Pc Teknik Servis - Satış", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        komut.ExecuteNonQuery();
                        con.Close();

                    }
                    else
                    {
                        MessageBox.Show("Silme Gerçekleşmedi..");
                        con.Close();
                    }
                }
                baglanti("Select * from Musteri"); // Veritabanındaki Verileri Getirir.
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void musteriupdate(string ya, string yb, string yc, string yd, string ye, string yf, string yx) // Müşteri Güncelleme İşlemini Sağlayan Fonksiyon
        {
            // Hata Komutları 
            try
            {
                SqlConnection baglanti = new SqlConnection("Server = localhost; Database = " + dbname + "; Integrated Security = SSPI;"); // Veritabanına Bağlanılmayı Sağlar.
                baglanti.Open(); // Veritabanına Bağlanır.
                // Veritabanında Gerçekleştirmek İstediğimiz İşlemin Komutunu kayit Değişkenine Atadık.
                string kayit = "update Musteri set KimlikNo =@KimlikNo,Ad=@Ad,Soyad=@Soyad,MailAdres=@MailAdres,TelNo=@TelNo,Adres=@Adres,sifre=@sifre where MusteriID = (" + seciliveri + ")";
                
                // Komutu Atadığımız Parametriyi Çalışır Duruma Getirdik ve Güncellenmek İstenilen Parametreler Belirtildi.
                SqlCommand komut = new SqlCommand(kayit, baglanti);
                komut.Parameters.AddWithValue("@KimlikNo", ya);
                komut.Parameters.AddWithValue("@Ad", yb);
                komut.Parameters.AddWithValue("@Soyad", yc);
                komut.Parameters.AddWithValue("@MailAdres", yd);
                komut.Parameters.AddWithValue("@TelNo", ye);
                komut.Parameters.AddWithValue("@Adres", yf);
                komut.Parameters.AddWithValue("@sifre", yx);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Güncelleme Başarılı!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void musterioku(ref string aa, ref string ab, ref string ac, ref string ad, ref string ae, ref string af, ref string ak) // Müşteri Listesinin Getirilmesini Sağlayan Fonksiyon
        {
            SqlConnection cn = new SqlConnection("Server = localhost; Database = " + dbname + "; Integrated Security = SSPI;"); // Veritabanına Bağlanılmayı Sağlar.
            using (SqlCommand cmd = new SqlCommand("SELECT * From Musteri where MusteriID=(" + seciliveri + ")")) // Veritabanına Komut Verilmesini Sağlar.
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;
                cn.Open(); // Veritabanını Açar.
                using (SqlDataReader sdr = cmd.ExecuteReader()) // Verileri Almamızı Sağlar.
                {
                    sdr.Read();
                    aa = sdr["KimlikNo"].ToString();
                    ab = sdr["Ad"].ToString();
                    ac = sdr["Soyad"].ToString();
                    ad = sdr["MailAdres"].ToString();
                    ae = sdr["TelNo"].ToString();
                    af = sdr["Adres"].ToString();
                    ak = sdr["sifre"].ToString();
                }
                cn.Close(); // Veritabanını Kapatır.
            }
        }

        public void siparisekle(string xb, string xc, string xd, string xe, string xf, string xg) // Sipariş Eklenmesini Sağlayan Fonksiyon
        {
            try
            {
                SqlConnection baglanti = new SqlConnection("Server = localhost; Database = " + dbname + "; Integrated Security = SSPI;");
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into Siparis ( pcid ,miktar ,kargosirketi ,kargoid ,alisveristarih, MusteriID) values (@pcid,@miktar,@kargosirketi,@kargoid,@alisveristarih, @MusteriID)", baglanti);
                komut.Parameters.AddWithValue("@pcid", xb);
                komut.Parameters.AddWithValue("@miktar", xc);
                komut.Parameters.AddWithValue("@kargosirketi", xd);
                komut.Parameters.AddWithValue("@kargoid", xe);
                komut.Parameters.AddWithValue("@alisveristarih", xf);
                komut.Parameters.AddWithValue("@MusteriID", xg);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kayıt Başarılı!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void siparissil()
        {
            try
            {
                SqlConnection con = new SqlConnection("Server = localhost; Database = " + dbname + "; Integrated Security = SSPI;");
                if (gunaDataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("Önce Satırlar Doldurulmalıdır..", "Uyarı");
                }
                else
                {
                    con.Open();
                    SqlCommand komut = new SqlCommand("delete from Siparis where siparisno=(" + seciliveri + ")", con);
                    if (MessageBox.Show("Seçilen Veriyi Silmek İstediğinize Emin Misiniz?\n", "PC Teknik Servis - Satış", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        komut.ExecuteNonQuery();
                        con.Close();

                    }
                    else
                    {
                        MessageBox.Show("Silme Gerçekleşmedi..");
                        con.Close();
                    }
                }
                baglanti("Select * from Siparis");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        

        public void siparisupdate(string xb, string xc, string xd, string xe, string xf, string xg)
        {
            try
            {
                SqlConnection baglanti = new SqlConnection("Server = localhost; Database = " + dbname + "; Integrated Security = SSPI;");
                baglanti.Open();
                string kayit = "update Siparis set pcid =@pcid,miktar=@miktar,kargosirketi=@kargosirketi,kargoid=@kargoid,alisveristarih=@alisveristarih,MusteriID=@MusteriID where siparisno = (" + seciliveri + ")";
                SqlCommand komut = new SqlCommand(kayit, baglanti);

                komut.Parameters.AddWithValue("@pcid", xb);
                komut.Parameters.AddWithValue("@miktar", xc);
                komut.Parameters.AddWithValue("@kargosirketi", xd);
                komut.Parameters.AddWithValue("@kargoid", xe);
                komut.Parameters.AddWithValue("@alisveristarih", xf);
                komut.Parameters.AddWithValue("@MusteriID", xg);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Güncelleme Başarılı!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme Başarısız (Bir Hata Oluştu) : " + ex.Message);
            }
        }

        public void siparisoku(ref string aa, ref string ab, ref string ac, ref string ad, ref string ae, ref string af)
        {
            try
            {
                SqlConnection cn = new SqlConnection("Server = localhost; Database = " + dbname + "; Integrated Security = SSPI;");
                using (SqlCommand cmd = new SqlCommand("SELECT * From Siparis where siparisno=(" + seciliveri + ")"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = cn;
                    cn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        aa = sdr["pcid"].ToString();
                        ab = sdr["miktar"].ToString();
                        ac = sdr["kargosirketi"].ToString();
                        ad = sdr["kargoid"].ToString();
                        ae = sdr["alisveristarih"].ToString();
                        af = sdr["MusteriID"].ToString();
                    }
                    cn.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ureticifirmaekle(string a1, string a2, string a3, string a4, string a5)
        {
            SqlConnection baglanti = new SqlConnection("Server = localhost; Database = " + dbname + "; Integrated Security = SSPI;");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into UreticiFirma ( firmaAd ,webAdres ,mailAdres ,telNo ,firmaAdres) values (@firmaAd,@webAdres,@mailAdres,@telNo,@firmaAdres)", baglanti);
            komut.Parameters.AddWithValue("@firmaAd", a1);
            komut.Parameters.AddWithValue("@webAdres", a2);
            komut.Parameters.AddWithValue("@mailAdres", a3);
            komut.Parameters.AddWithValue("@telNo", a4);
            komut.Parameters.AddWithValue("@firmaAdres", a5);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Başarılı!");
        }

        private void ureticifirmasil()
        {
            try
            {
                SqlConnection con = new SqlConnection("Server = localhost; Database = " + dbname + "; Integrated Security = SSPI;");
                if (gunaDataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("Önce Satırlar Doldurulmalıdır..", "Uyarı");
                }
                else
                {
                    con.Open();
                    SqlCommand komut = new SqlCommand("delete from UreticiFirma where firmaID= ("+ seciliveri +")", con);
                    if (MessageBox.Show("Seçilen Veriyi Silmek İstediğinize Emin mMsiniz?\n", "PC Teknik Servis - Satış", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        komut.ExecuteNonQuery();
                        con.Close();

                    }
                    else
                    {
                        MessageBox.Show("Silme Gerçekleşmedi..");
                        con.Close();
                    }
                }
                baglanti("Select * from UreticiFirma");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        public void ureticifirmaupdate(string a1, string a2, string a3, string a4, string a5)
        {
            SqlConnection baglanti = new SqlConnection("Server = localhost; Database = " + dbname + "; Integrated Security = SSPI;");
            baglanti.Open();
            string kayit = "update UreticiFirma set firmaAd=@firmaAd,webAdres=@webAdres,mailAdres=@mailAdres,telNo=@telNo,firmaAdres=@firmaAdres where firmaID=(" + seciliveri + ")";
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            komut.Parameters.AddWithValue("@firmaAd", a1);
            komut.Parameters.AddWithValue("@webAdres", a2);
            komut.Parameters.AddWithValue("@mailAdres", a3);
            komut.Parameters.AddWithValue("@telNo", a4);
            komut.Parameters.AddWithValue("@firmaAdres", a5);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Güncelleme Başarılı!");

        }
        public void ureticifirmaoku(ref string a1, ref string a2, ref string a3, ref string a4, ref string a5)
        {
            SqlConnection cn = new SqlConnection("Server = localhost; Database = " + dbname + "; Integrated Security = SSPI;");
            using (SqlCommand cmd = new SqlCommand("SELECT * From UreticiFirma where firmaID=(" + seciliveri + ")"))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;
                cn.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    sdr.Read();
                    a1 = sdr["firmaAd"].ToString();
                    a2 = sdr["webAdres"].ToString();
                    a3 = sdr["mailAdres"].ToString();
                    a4 = sdr["telNo"].ToString();
                    a5 = sdr["firmaAdres"].ToString();
                }
                cn.Close();
            }
        }

        public void bilgisayarekle(string b2, string b3, string b4, string b5, string b6, string b7, string b8, string b9, string b10)
        {
            SqlConnection baglanti = new SqlConnection("Server = localhost; Database = " + dbname + "; Integrated Security = SSPI;");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into bilgisayar ( modelno ,firmaAd ,fiyat ,CPU ,RAM ,Depolama ,GPU ,OS ,stokadeti) values (@modelno ,@firmaAd ,@fiyat ,@CPU ,@RAM ,@Depolama ,@GPU ,@OS ,@stokadeti)", baglanti);
            komut.Parameters.AddWithValue("@modelno", b2);
            komut.Parameters.AddWithValue("@firmaAd", b3);
            komut.Parameters.AddWithValue("@fiyat", b4);
            komut.Parameters.AddWithValue("@CPU", b5);
            komut.Parameters.AddWithValue("@RAM", b6);
            komut.Parameters.AddWithValue("@Depolama", b7);
            komut.Parameters.AddWithValue("@GPU", b8);
            komut.Parameters.AddWithValue("@OS", b9);
            komut.Parameters.AddWithValue("@stokadeti", b10);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Başarılı!");
        }
        
        public void bilgisayarsil()
        {
            try
            {
                SqlConnection con = new SqlConnection("Server = localhost; Database = " + dbname + "; Integrated Security = SSPI;");
                if (gunaDataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("Önce Satırlar Doldurulmalıdır..", "Uyarı");
                }
                else
                {
                    con.Open();
                    SqlCommand komut = new SqlCommand("delete from bilgisayar where pcid= (" + seciliveri + ")", con);
                    if (MessageBox.Show("Seçilen Veriyi Silmek İstediğinize Emin Misiniz?\n", "PC Teknik Servis - Satış", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        komut.ExecuteNonQuery();
                        con.Close();

                    }
                    else
                    {
                        MessageBox.Show("Silme Gerçekleşmedi");
                        con.Close();
                    }
                }
                baglanti("Select * from bilgisayar");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        public void bilgisayarupdate(string b2, string b3, string b4, string b5, string b6, string b7, string b8, string b9, string b10)
        {
            SqlConnection baglanti = new SqlConnection("Server = localhost; Database = " + dbname + "; Integrated Security = SSPI;");
            baglanti.Open();
            string kayit = "update bilgisayar set modelno=@modelno ,firmaAd=@firmaAd ,fiyat=@fiyat ,CPU=@CPU ,RAM=@RAM ,Depolama=@Depolama ,GPU=@GPU ,OS=@OS ,stokadeti=@stokadeti  where pcid=(" + seciliveri + ")";
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            komut.Parameters.AddWithValue("@modelno", b2);
            komut.Parameters.AddWithValue("@firmaAd", b3);
            komut.Parameters.AddWithValue("@fiyat", b4);
            komut.Parameters.AddWithValue("@CPU", b5);
            komut.Parameters.AddWithValue("@RAM", b6);
            komut.Parameters.AddWithValue("@Depolama", b7);
            komut.Parameters.AddWithValue("@GPU", b8);
            komut.Parameters.AddWithValue("@OS", b9);
            komut.Parameters.AddWithValue("@stokadeti", b10);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Güncelleme Başarılı!");
        }

        public void bilgisayaroku(ref string b2, ref string b3, ref string b4, ref string b5, ref string b6, ref string b7, ref string b8, ref string b9, ref string b10)
        {
            SqlConnection cn = new SqlConnection("Server = localhost; Database = " + dbname + "; Integrated Security = SSPI;");
            using (SqlCommand cmd = new SqlCommand("SELECT * From bilgisayar where pcid=(" + seciliveri + ")"))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;
                cn.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    sdr.Read();
                    b2 = sdr["modelno"].ToString();
                    b3 = sdr["firmaAd"].ToString();
                    b4 = sdr["fiyat"].ToString();
                    b5 = sdr["CPU"].ToString();
                    b6 = sdr["RAM"].ToString();
                    b7 = sdr["Depolama"].ToString();
                    b8 = sdr["GPU"].ToString();
                    b9 = sdr["OS"].ToString();
                    b10 = sdr["stokadeti"].ToString();
                }
                cn.Close();
            }
        }

        public void teknikservisekle(string b1, string b2, string b3, string b4, string b5, string b6, string b7)
        {
            SqlConnection baglanti = new SqlConnection("Server = localhost; Database = " + dbname + "; Integrated Security = SSPI;");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TeknikServis ( personelID ,ad ,soyad ,kimlikNo ,telNo ,mail ,adres) values (@personelID,@ad ,@soyad ,@kimlikNo ,@telNo ,@mail ,@adres)", baglanti);
            komut.Parameters.AddWithValue("@personelID", b1);
            komut.Parameters.AddWithValue("@ad", b2);
            komut.Parameters.AddWithValue("@soyad", b3);
            komut.Parameters.AddWithValue("@kimlikNo", b4);
            komut.Parameters.AddWithValue("@telNo", b5);
            komut.Parameters.AddWithValue("@mail", b6);
            komut.Parameters.AddWithValue("@adres", b7);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Başarılı!");
        }

        public void teknikservissil()
        {
            try
            {
                SqlConnection con = new SqlConnection("Server = localhost; Database = " + dbname + "; Integrated Security = SSPI;");
                if (gunaDataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("Önce Satırlar Doldurulmalıdır..", "Uyarı");
                }
                else
                {
                    con.Open();
                    SqlCommand komut = new SqlCommand("delete from TeknikServis where personelID= (" + seciliveri + ")", con);
                    if (MessageBox.Show("Seçilen Veriyi Silmek İstediğinize Emin Misiniz?\n", "PC Teknik Servis - Satış", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        komut.ExecuteNonQuery();
                        con.Close();

                    }
                    else
                    {
                        MessageBox.Show("Silme Gerçekleşmedi..");
                        con.Close();
                    }
                }
                baglanti("Select * from TeknikServis");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void teknikservisupdate(string b1, string b2, string b3, string b4, string b5, string b6, string b7)
        {
            SqlConnection baglanti = new SqlConnection("Server = localhost; Database = " + dbname + "; Integrated Security = SSPI;");
            baglanti.Open();
            string kayit = "update TeknikServis set personelID=@personelID ,ad=@ad ,soyad=@soyad ,kimlikNo=@kimlikNo ,telNo=@telNo ,mail=@mail ,adres=@adres  where personelID=(" + seciliveri + ")";
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            komut.Parameters.AddWithValue("@personelID", b1);
            komut.Parameters.AddWithValue("@ad", b2);
            komut.Parameters.AddWithValue("@soyad", b3);
            komut.Parameters.AddWithValue("@kimlikNo", b4);
            komut.Parameters.AddWithValue("@telNo", b5);
            komut.Parameters.AddWithValue("@mail", b6);
            komut.Parameters.AddWithValue("@adres", b7);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Başarılı!");

        }

        public void teknikservisoku(ref string b1, ref string b2, ref string b3, ref string b4, ref string b5, ref string b6, ref string b7)
        {
            try
            {
                SqlConnection cn = new SqlConnection("Server = localhost; Database = " + dbname + "; Integrated Security = SSPI;");
                using (SqlCommand cmd = new SqlCommand("SELECT * From TeknikServis where personelID=(" + seciliveri + ")"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = cn;
                    cn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        b1 = sdr["personelID"].ToString();
                        b2 = sdr["ad"].ToString();
                        b3 = sdr["soyad"].ToString();
                        b4 = sdr["kimlikNo"].ToString();
                        b5 = sdr["telNo"].ToString();
                        b6 = sdr["mail"].ToString();
                        b7 = sdr["adres"].ToString();
                    }
                    cn.Close();

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void yetkilendirme(string okuma, string yazma, string guncelleme, string silme)
        {
            SqlConnection conn = new SqlConnection("Server = localhost; Database =" + dbname + "; Integrated Security = SSPI;");
            conn.Open();
            string kayit ="update Kullanici set okuma=@okuma ,yazma=@yazma ,guncelleme=@guncelleme ,silme=@silme where MusteriID=(" +seciliveri+ ")";
            SqlCommand komut = new SqlCommand(kayit, conn);
            komut.Parameters.AddWithValue("@okuma", okuma);
            komut.Parameters.AddWithValue("@yazma", yazma);
            komut.Parameters.AddWithValue("@guncelleme", guncelleme);
            komut.Parameters.AddWithValue("@silme", silme);
            komut.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Yetkilendirme Başarılı!");
        }

        public void yetkioku(ref string okuma, ref string yazma, ref string guncelleme, ref string silme)
        {
            SqlConnection cn = new SqlConnection("Server = localhost; Database = " + dbname + "; Integrated Security = SSPI;");
            using (SqlCommand cmd = new SqlCommand("SELECT * From Kullanici where MusteriID=(" + seciliveri + ")"))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;
                cn.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    sdr.Read();
                    okuma = sdr["okuma"].ToString();
                    yazma = sdr["yazma"].ToString();
                    guncelleme = sdr["guncelleme"].ToString();
                    silme = sdr["silme"].ToString();
                }
                cn.Close();

            }

        }

        public void vyedek(string path)
        {
            try
            {
                SqlConnection conn = new SqlConnection("Server = localhost; Database = " + dbname + "; Integrated Security = SSPI;");
                if (path == string.Empty)
                {
                    MessageBox.Show("Lütfen Backup Dosyasının Kaydedileceği Yeri Seçiniz.");
                }
                else
                {
                    string cmd = "BACKUP DATABASE " + dbname + " TO DISK='" + path + "\\" + "database" + "-" + DateTime.Now.ToString("yyyy-MM-dd--HH-mm") + ".bak'";
                    using (SqlCommand command = new SqlCommand(cmd, conn))
                    {
                        if (conn.State != ConnectionState.Open)
                        {
                            conn.Open();
                        }
                        command.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Veritabanı Başarılı Bir Şekilde Yedeklendi.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void vyedektendon(string path)
        {
            try
            {
                SqlConnection conn = new SqlConnection("Server = localhost; Database = " + dbname + "; Integrated Security = SSPI;");
                if (path == string.Empty)
                {
                    MessageBox.Show("Lütfen Restore Etmek İstediğiniz Backup Dosyasını Seçiniz.");
                }
                else
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }
                    try
                    {
                        string sqlStmt2 = string.Format("ALTER DATABASE " + dbname + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                        SqlCommand bu2 = new SqlCommand(sqlStmt2, conn);
                        bu2.ExecuteNonQuery();

                        string sqlStmt3 = "USE MASTER RESTORE DATABASE " + dbname + " FROM DISK = '" + path + "' WITH REPLACE";
                        SqlCommand bu3 = new SqlCommand(sqlStmt3, conn);
                        bu3.ExecuteNonQuery();

                        string sqlStmt4 = string.Format("ALTER DATABASE " + dbname + " SET MULTI_USER");
                        SqlCommand bu4 = new SqlCommand(sqlStmt4, conn);
                        bu4.ExecuteNonQuery();

                        MessageBox.Show("Veritabanı Başarılı Bir Şekilde Geri Yüklendi!");
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void butonlar(bool a, bool b, bool c, bool d, bool e, bool f, bool extra) // BUTONLARIN GÖRÜNÜP GÖRÜNMEMESİNİ SAĞLAYAN FONKSİYON
        {
            guna2Button6.Visible = a;
            guna2Button7.Visible = a;
            guna2Button8.Visible = a;
            guna2TextBox1.Visible = a;

            guna2Button9.Visible = b;
            guna2Button10.Visible = b;
            guna2Button11.Visible = b;
            guna2TextBox2.Visible = b;

            guna2Button12.Visible = c;
            guna2Button13.Visible = c;
            guna2Button14.Visible = c;
            guna2TextBox3.Visible = c;

            guna2Button15.Visible = d;
            guna2Button16.Visible = d;
            guna2Button17.Visible = d;
            guna2TextBox4.Visible = d;

            guna2Button18.Visible = e;
            guna2Button19.Visible = e;
            guna2Button20.Visible = e;
            guna2TextBox5.Visible = e;

            guna2Button25.Visible = f;
            guna2TextBox6.Visible = f;

            gunaDataGridView1.Visible = extra;
            gunaLabel1.Visible = extra;
        }
    }
}
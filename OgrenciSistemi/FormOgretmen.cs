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

namespace OgrenciKayit
{
    public partial class FormOgretmen : Form
    {

        SQLBaglantisi Sql = new SQLBaglantisi();
        public string Numara;
        string Fotograf;

        public FormOgretmen()
        {
            InitializeComponent();
        }

        void Pasif()
        {
            TxtBoxOgrSv1.Enabled = false;
            TxtBoxOgrSv2.Enabled = false;
            TxtBoxOgrSv3.Enabled = false;
            TxtBoxOgrPrj.Enabled = false;
            TxtBoxOgrOrt.Enabled = false;
            TxtBoxOgrDrm.Enabled = false;
            BtnHesapla.Enabled = false;
        }

        void Aktif()
        {
            TxtBoxOgrSv1.Enabled = true;
            TxtBoxOgrSv2.Enabled = true;
            TxtBoxOgrSv3.Enabled = true;
            TxtBoxOgrPrj.Enabled = true;
            BtnHesapla.Enabled = true;
        }

        private void FormOgretmen_Load(object sender, EventArgs e)
        {
            Pasif();
            LblOgrtNum.Text = Numara;
            SqlCommand Komut = new SqlCommand("SELECT * FROM TbOgretmen WHERE Numara = @Pm1", Sql.Baglanti());
            Komut.Parameters.AddWithValue("@Pm1", Numara);
            SqlDataReader Reader = Komut.ExecuteReader();
            while (Reader.Read())
                LblOgrtAdSoyad.Text = Reader[1] + " " + Reader[2];
            Sql.Baglanti().Close();
            OgrenciListesi();
            NotListesi();
        }

        void OgrenciListesi()
        {
            SqlCommand Komut = new SqlCommand("SELECT * FROM TbOgrenci", Sql.Baglanti());
            SqlDataAdapter Adapter = new SqlDataAdapter(Komut);
            DataTable Table = new DataTable();
            Adapter.Fill(Table);
            dataGridView1.DataSource = Table;
        }

        void NotListesi()
        {
            SqlCommand Komut = new SqlCommand("Exec dbo.Ogrenciler", Sql.Baglanti());
            SqlDataAdapter Adapter = new SqlDataAdapter(Komut);
            DataTable Table = new DataTable();
            Adapter.Fill(Table);
            dataGridView2.DataSource = Table;
        }

        private void BtnFotoSec_Click(object sender, EventArgs e)
        {
            OpenFileDialog Dialog = new OpenFileDialog();
            Dialog.ShowDialog();
            Fotograf = Dialog.FileName;
            PicBoxOgrFoto.ImageLocation = Fotograf;
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand Query = new SqlCommand("SELECT * FROM TbOgrenci WHERE Numara = @Pm1", Sql.Baglanti());
            Query.Parameters.AddWithValue("@Pm1", MskTxtBoxOgrNum.Text);
            SqlDataReader Reader = Query.ExecuteReader();
            if (Reader.Read())
                MessageBox.Show("Aynı Öğrenci Numarasıyla Öğrenci Kaydı Gerçekleştirilemez!", "Hatalı Bilgi Girişi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (!String.IsNullOrEmpty(MskTxtBoxOgrNum.Text))
                    if (!String.IsNullOrEmpty(TxtBoxOgrAd.Text))
                        if (!String.IsNullOrEmpty(TxtBoxOgrSoyad.Text))
                            if (!String.IsNullOrEmpty(TxtBoxOgrSifre.Text))
                                if (!String.IsNullOrEmpty(Fotograf))
                                {
                                    SqlCommand Komut = new SqlCommand("INSERT INTO TbOgrenci (Ad, Soyad, Numara, Sifre, Fotograf) VALUES (@Pm1, @Pm2, @Pm3, @Pm4, @Pm5)", Sql.Baglanti());
                                    Komut.Parameters.AddWithValue("@Pm1", TxtBoxOgrAd.Text);
                                    Komut.Parameters.AddWithValue("@Pm2", TxtBoxOgrSoyad.Text);
                                    Komut.Parameters.AddWithValue("@Pm3", MskTxtBoxOgrNum.Text);
                                    Komut.Parameters.AddWithValue("@Pm4", TxtBoxOgrSifre.Text);
                                    Komut.Parameters.AddWithValue("@Pm5", Fotograf);
                                    Komut.ExecuteNonQuery();
                                    Sql.Baglanti().Close();
                                    OgrenciListesi();
                                    NotListesi();
                                    Temizle();
                                    MessageBox.Show("Öğrenci Kayıtı Gerçekleşti. Öğrenciyi Seçerek Not Bilgisi Girebilirsiniz...", "Kayıt Bilgisi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                    MessageBox.Show("Öğrenci Fotoğrafı Boş Bırakılamaz!", "Eksik Bilgi Girişi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            else
                                MessageBox.Show("Öğrenci Şifresi Boş Bırakılamaz", "Eksik Bilgi Girişi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        else
                            MessageBox.Show("Öğrenci Soyadı Boş Bırakılamaz!", "Eksik Bilgi Girişi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    else
                        MessageBox.Show("Öğrenci Adı Boş Bırakılamaz!", "Eksik Bilgi Girişi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                else
                    MessageBox.Show("Öğrenci Numarası Boş Bırakılamaz!", "Eksik Bilgi Girişi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Aktif();
            MskTxtBoxOgrNum.Enabled = false;
            int Secilen = dataGridView1.SelectedCells[0].RowIndex;
            TxtBoxOgrAd.Text = dataGridView1.Rows[Secilen].Cells[1].Value.ToString();
            TxtBoxOgrSoyad.Text = dataGridView1.Rows[Secilen].Cells[2].Value.ToString();
            MskTxtBoxOgrNum.Text = dataGridView1.Rows[Secilen].Cells[3].Value.ToString();
            TxtBoxOgrSifre.Text = dataGridView1.Rows[Secilen].Cells[4].Value.ToString();
            PicBoxOgrFoto.ImageLocation = dataGridView1.Rows[Secilen].Cells[5].Value.ToString();
            SqlCommand Komut = new SqlCommand("SELECT * FROM TbNotlar WHERE OGRID = (SELECT ID FROM TbOgrenci WHERE Numara = @Pm1)", Sql.Baglanti());
            Komut.Parameters.AddWithValue("@Pm1", MskTxtBoxOgrNum.Text);
            SqlDataReader Reader = Komut.ExecuteReader();
            while (Reader.Read())
            {
                TxtBoxOgrSv1.Text = Reader[1].ToString();
                TxtBoxOgrSv2.Text = Reader[2].ToString();
                TxtBoxOgrSv3.Text = Reader[3].ToString();
                TxtBoxOgrPrj.Text = Reader[4].ToString();
                TxtBoxOgrOrt.Text = Reader[5].ToString();
                TxtBoxOgrDrm.Text = Reader[6].ToString();
            }
            Sql.Baglanti().Close();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(MskTxtBoxOgrNum.Text))
                if (!String.IsNullOrEmpty(TxtBoxOgrAd.Text))
                    if (!String.IsNullOrEmpty(TxtBoxOgrSoyad.Text))
                        if (!String.IsNullOrEmpty(TxtBoxOgrSifre.Text))
                            if (!String.IsNullOrEmpty(PicBoxOgrFoto.ImageLocation.ToString()))
                            {
                                SqlCommand Komut = new SqlCommand("UPDATE TbOgrenci SET Ad = @Pm1, Soyad = @Pm2, Sifre = @Pm3, Fotograf = @Pm4 WHERE Numara = @Pm5", Sql.Baglanti());
                                Komut.Parameters.AddWithValue("@Pm1", TxtBoxOgrAd.Text);
                                Komut.Parameters.AddWithValue("@Pm2", TxtBoxOgrSoyad.Text);
                                Komut.Parameters.AddWithValue("@Pm3", TxtBoxOgrSifre.Text);
                                Komut.Parameters.AddWithValue("@Pm4", Fotograf ?? PicBoxOgrFoto.ImageLocation);
                                Komut.Parameters.AddWithValue("@Pm5", MskTxtBoxOgrNum.Text);
                                Komut.ExecuteNonQuery();
                                Sql.Baglanti().Close();
                                SqlCommand Komut2 = new SqlCommand("UPDATE TbNotlar SET Sinav1 = @Pm1, Sinav2 = @Pm2, Sinav3 = @Pm3, Proje = @Pm4, Ortalama = @Pm5, Durum = @Pm6 WHERE OGRID = (SELECT ID FROM TbOgrenci WHERE Numara = @Pm7)", Sql.Baglanti());
                                Komut2.Parameters.AddWithValue("@Pm1", TxtBoxOgrSv1.Text);
                                Komut2.Parameters.AddWithValue("@Pm2", TxtBoxOgrSv2.Text);
                                Komut2.Parameters.AddWithValue("@Pm3", TxtBoxOgrSv3.Text);
                                Komut2.Parameters.AddWithValue("@Pm4", TxtBoxOgrPrj.Text);
                                Komut2.Parameters.AddWithValue("@Pm5", Convert.ToDecimal(TxtBoxOgrOrt.Text));
                                Komut2.Parameters.AddWithValue("@Pm6", TxtBoxOgrDrm.Text);
                                Komut2.Parameters.AddWithValue("@Pm7", MskTxtBoxOgrNum.Text);
                                Komut2.ExecuteNonQuery();
                                Sql.Baglanti().Close();
                                OgrenciListesi();
                                NotListesi();
                                MessageBox.Show("Öğrenci Bilgisi Başarıyla Güncelleşti.", "Güncelleme Bilgisi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                Temizle();
                            }
                            else
                                MessageBox.Show("Öğrenci Fotoğrafı Boş Bırakılamaz!", "Eksik Bilgi Girişi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        else
                            MessageBox.Show("Öğrenci Şifresi Boş Bırakılamaz", "Eksik Bilgi Girişi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    else
                        MessageBox.Show("Öğrenci Soyadı Boş Bırakılamaz!", "Eksik Bilgi Girişi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                else
                    MessageBox.Show("Öğrenci Adı Boş Bırakılamaz!", "Eksik Bilgi Girişi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            else
                MessageBox.Show("Öğrenci Numarası Boş Bırakılamaz!", "Eksik Bilgi Girişi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void BtnHesapla_Click(object sender, EventArgs e)
        {
            double Sinav1, Sinav2, Sinav3, Proje, Ortalama;
            Sinav1 = Convert.ToDouble(TxtBoxOgrSv1.Text);
            Sinav2 = Convert.ToDouble(TxtBoxOgrSv2.Text);
            Sinav3 = Convert.ToDouble(TxtBoxOgrSv3.Text);
            Proje = Convert.ToDouble(TxtBoxOgrPrj.Text);
            Ortalama = (Sinav1 + Sinav2 + Sinav3 + Proje) / 4;
            TxtBoxOgrOrt.Text = Ortalama.ToString();
            if (Ortalama >= 50)
                TxtBoxOgrDrm.Text = "True";
            else
                TxtBoxOgrDrm.Text = "False";
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            Temizle();
            Pasif();
        }

        void Temizle()
        {
            MskTxtBoxOgrNum.Enabled = true;
            TxtBoxOgrAd.Clear();
            TxtBoxOgrSoyad.Clear();
            MskTxtBoxOgrNum.Clear();
            TxtBoxOgrSifre.Clear();
            PicBoxOgrFoto.ImageLocation = null;
            TxtBoxOgrSv1.Clear();
            TxtBoxOgrSv2.Clear();
            TxtBoxOgrSv3.Clear();
            TxtBoxOgrPrj.Clear();
            TxtBoxOgrOrt.Clear();
            TxtBoxOgrDrm.Clear();
        }

        private void BtnDuyuruOlustur_Click(object sender, EventArgs e)
        {
            FormDuyuruOlustur FrmDuyuru = new FormDuyuruOlustur();
            FrmDuyuru.Show();
        }

        private void BtnDuyuruListesi_Click(object sender, EventArgs e)
        {
            FormDuyuruListesi FrmDyrListe = new FormDuyuruListesi();
            FrmDyrListe.Show();
        }

        private void BtnMesajlar_Click(object sender, EventArgs e)
        {
            FormMesajlar FrmMesajlar = new FormMesajlar();
            FrmMesajlar.Numara = LblOgrtNum.Text;
            FrmMesajlar.Show();
        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            DialogResult Dialog = MessageBox.Show("Öğretmen Bilgi Sisteminden Çıkış Yapmak İstediğinize Emin Misiniz?", "Çıkış Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (Dialog == DialogResult.Yes)
            {
                this.Close();
                Form1 Frm1 = new Form1();
                Frm1.Show();
            }
        }
    }
}

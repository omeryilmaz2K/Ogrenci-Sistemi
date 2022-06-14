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
    public partial class FormDuyuruOlustur : Form
    {

        SQLBaglantisi Sql = new SQLBaglantisi();
        string ID;

        public FormDuyuruOlustur()
        {
            InitializeComponent();
        }

        void Pasif()
        {
            BtnDuzenle.Enabled = false;
            BtnSil.Enabled = false;
        }

        void Aktif()
        {
            BtnDuzenle.Enabled = true;
            BtnSil.Enabled = true;
        }

        private void FormDuyuruOlustur_Load(object sender, EventArgs e)
        {
            Pasif();
            Listele();
        }

        void Listele()
        {
            SqlCommand Komut = new SqlCommand("SELECT * FROM TbDuyurular", Sql.Baglanti());
            SqlDataAdapter Adapter = new SqlDataAdapter(Komut);
            DataTable Table = new DataTable();
            Adapter.Fill(Table);
            dataGridView1.DataSource = Table;
        }

        void Temizle()
        {
            RichTxtBoxDuyuru.Clear();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(RichTxtBoxDuyuru.Text))
            {
                SqlCommand Komut = new SqlCommand("INSERT INTO TbDuyurular (Icerik) VALUES (@Pm1)", Sql.Baglanti());
                Komut.Parameters.AddWithValue("@Pm1", RichTxtBoxDuyuru.Text);
                Komut.ExecuteNonQuery();
                Sql.Baglanti().Close();
                Listele();
                Temizle();
                MessageBox.Show("Duyuru Başarıyla Oluşturuldu.", "Duyuru Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Duyuru Oluşturmak İçin Lütfen Bir İçerik Giriniz.", "Eksik Bilgi Girişi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Aktif();
            int Secilen = dataGridView1.SelectedCells[0].RowIndex;
            ID = dataGridView1.Rows[Secilen].Cells[0].Value.ToString();
            RichTxtBoxDuyuru.Text = dataGridView1.Rows[Secilen].Cells[1].Value.ToString();
            this.Text = ID;
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(RichTxtBoxDuyuru.Text))
            {
                SqlCommand Komut = new SqlCommand("DELETE FROM TbDuyurular WHERE ID = @Pm1", Sql.Baglanti());
                Komut.Parameters.AddWithValue("@Pm1", ID);
                Komut.ExecuteNonQuery();
                Sql.Baglanti().Close();
                Listele();
                Temizle();
                MessageBox.Show("Duyuru Başarıyla Silindi.", "Duyuru Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Öncelikle Silmek İstediğiniz Duyuruyu Seçiniz", "Hatalı İşlem Bilgisi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void BtnDuzenle_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(RichTxtBoxDuyuru.Text))
            {
                SqlCommand Komut = new SqlCommand("UPDATE TbDuyurular SET Icerik = @Pm1 WHERE ID = @Pm2", Sql.Baglanti());
                Komut.Parameters.AddWithValue("@Pm1", RichTxtBoxDuyuru.Text);
                Komut.Parameters.AddWithValue("@Pm2", ID);
                Komut.ExecuteNonQuery();
                Sql.Baglanti().Close();
                Listele();
                Temizle();
                MessageBox.Show("Duyuru Başarıyla Güncellendi.", "Duyuru Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Öncelikle Düzenlemek İstediğiniz Duyuruyu Seçiniz", "Hatalı İşlem Bilgisi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}

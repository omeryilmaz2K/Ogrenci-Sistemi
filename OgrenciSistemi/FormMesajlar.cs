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
    public partial class FormMesajlar : Form
    {

        SQLBaglantisi Sql = new SQLBaglantisi();
        public string Numara;

        public FormMesajlar()
        {
            InitializeComponent();
        }

        private void FormMesajlar_Load(object sender, EventArgs e)
        {
            MskTxtBoxGon.Text = Numara;
            GelenMesajlar();
            GidenMesajlar();
        }

        void GelenMesajlar()
        {
            SqlCommand Komut = new SqlCommand("SELECT * FROM TbMesajlar WHERE Gonderen = @Pm1", Sql.Baglanti());
            Komut.Parameters.AddWithValue("@Pm1", Numara);
            SqlDataAdapter Adapter = new SqlDataAdapter(Komut);
            DataTable Table = new DataTable();
            Adapter.Fill(Table);
            dataGridView2.DataSource = Table;
        }

        void GidenMesajlar()
        {
            SqlCommand Komut = new SqlCommand("SELECT * FROM TbMesajlar WHERE Alici = @Pm1", Sql.Baglanti());
            Komut.Parameters.AddWithValue("@Pm1", Numara);
            SqlDataAdapter Adapter = new SqlDataAdapter(Komut);
            DataTable Table = new DataTable();
            Adapter.Fill(Table);
            dataGridView1.DataSource = Table;
        }

        private void BtnGonder_Click(object sender, EventArgs e)
        {
            if (!MskTxtBoxGon.Text.Equals(MskTxtBoxAlc.Text))
                if (!String.IsNullOrEmpty(MskTxtBoxAlc.Text))
                    if (!String.IsNullOrEmpty(TxtBoxKonu.Text))
                        if (!String.IsNullOrEmpty(RichTxtBoxMsj.Text))
                        {
                            SqlCommand Komut = new SqlCommand("INSERT INTO TbMesajlar (Gonderen, Alici, Baslik, Icerik) VALUES (@Pm1, @Pm2, @Pm3, @Pm4)", Sql.Baglanti());
                            Komut.Parameters.AddWithValue("@Pm1", MskTxtBoxGon.Text);
                            Komut.Parameters.AddWithValue("@Pm2", MskTxtBoxAlc.Text);
                            Komut.Parameters.AddWithValue("@Pm3", TxtBoxKonu.Text);
                            Komut.Parameters.AddWithValue("@Pm4", RichTxtBoxMsj.Text);
                            Komut.ExecuteNonQuery();
                            Sql.Baglanti().Close();
                            GelenMesajlar();
                            GidenMesajlar();
                            MessageBox.Show("Mesajınız Başarıyla İletildi.", "Mesaj Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show("Mesaj Alanı Boş Bırakılamaz!", "Eksik Bilgi Girişi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                        MessageBox.Show("Konu Alanı Boş Bırakılamaz!", "Eksik Bilgi Girişi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    MessageBox.Show("Geçerli Bir Alıcı Numarası Giriniz.", "Hatalı İşlem Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Geçerli Bir Alıcı Numarası Giriniz.", "Hatalı İşlem Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}

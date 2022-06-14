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
    public partial class FormOgrenci : Form
    {

        public string Numara;
        SQLBaglantisi Sql = new SQLBaglantisi();

        public FormOgrenci()
        {
            InitializeComponent();
        }

        private void FormOgrenci_Load(object sender, EventArgs e)
        {
            LblNumara.Text = Numara;
            SqlCommand Komut = new SqlCommand("SELECT * FROM TbOgrenci WHERE Numara = @Pm1", Sql.Baglanti());
            Komut.Parameters.AddWithValue("@Pm1", Numara);
            SqlDataReader Reader = Komut.ExecuteReader();
            while (Reader.Read())
            {
                LblAdSoyad.Text = Reader[1] + " " + Reader[2];
                pictureBox1.ImageLocation = Reader[5].ToString();
            }
            Sql.Baglanti().Close();
            SqlCommand Komut2 = new SqlCommand("SELECT * FROM TbNotlar WHERE OGRID = (SELECT ID FROM TbOgrenci WHERE Numara = @Pm1)", Sql.Baglanti());
            Komut2.Parameters.AddWithValue("@Pm1", LblNumara.Text);
            SqlDataReader Reader2 = Komut2.ExecuteReader();
            while (Reader2.Read())
            {
                LblSv1.Text = Reader2[1].ToString();
                LblSv2.Text = Reader2[2].ToString();
                LblSv3.Text = Reader2[3].ToString();
                LblProje.Text = Reader2[4].ToString();
                LblOrt.Text = Reader2[5].ToString();
            }
            Sql.Baglanti().Close();
            if (Convert.ToDouble(LblOrt.Text) >= 50)
                LblDurum.Text = "Geçti";
            else
                LblDurum.Text = "Kaldı";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormMesajlar FrmMsj = new FormMesajlar();
            FrmMsj.Numara = LblNumara.Text;
            FrmMsj.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormDuyuruListesi FrmDyr = new FormDuyuruListesi();
            FrmDyr.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.Exe");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult Dialog = MessageBox.Show("Öğrenci Bilgi Sisteminden Çıkmak İstediğinize Emin Misiniz?", "Çıkış İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (Dialog == DialogResult.Yes)
            {
                this.Close();
                Form1 Frm1 = new Form1();
                Frm1.Show();
            }
        }
    }
}

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
    public partial class Form1 : Form
    {

        SQLBaglantisi Sql = new SQLBaglantisi();

        public Form1()
        {
            InitializeComponent();
        }

        private void BtnOgrtGiris_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(MskTxtBoxOgrtNum.Text) && !String.IsNullOrEmpty(TxtBoxOgrtSifre.Text))
            {
                SqlCommand Komut = new SqlCommand("SELECT * FROM TbOgretmen WHERE Numara = @Pm1 AND Sifre = @Pm2", Sql.Baglanti());
                Komut.Parameters.AddWithValue("@Pm1", MskTxtBoxOgrtNum.Text);
                Komut.Parameters.AddWithValue("@Pm2", TxtBoxOgrtSifre.Text);
                SqlDataReader Reader = Komut.ExecuteReader();
                if (Reader.Read())
                {
                    FormOgretmen FrmOgrt = new FormOgretmen();
                    FrmOgrt.Numara = MskTxtBoxOgrtNum.Text;
                    FrmOgrt.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("Girilen Numara ya da Şifre Hatalı!", "Hatalı Bilgi Giriş!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
                MessageBox.Show("Numara yada Şifre Alanları Boş Bırakılamaz!", "Eksik Bilgi Girişi!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            Sql.Baglanti().Close();
        }

        private void BtnOgrGiris_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(MskTxtBoxOgrNum.Text) && !String.IsNullOrEmpty(TxtBoxOgrSifre.Text))
            {
                SqlCommand Komut = new SqlCommand("SELECT * FROM TbOgrenci WHERE Numara = @Pm1 AND Sifre = @Pm2", Sql.Baglanti());
                Komut.Parameters.AddWithValue("@Pm1", MskTxtBoxOgrNum.Text);
                Komut.Parameters.AddWithValue("@Pm2", TxtBoxOgrSifre.Text);
                SqlDataReader Reader = Komut.ExecuteReader();
                if (Reader.Read())
                {
                    FormOgrenci FrmOgr = new FormOgrenci();
                    FrmOgr.Numara = MskTxtBoxOgrNum.Text;
                    FrmOgr.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("Girilen Numara ya da Şifre Hatalı!", "Hatalı Bilgi Girişi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
                MessageBox.Show("Numara ya da Şifre Alanları Boş Bırakılamaz!", "Eksik Bilgi Girişi!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            Sql.Baglanti().Close();
        }
    }
}

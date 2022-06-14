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
    public partial class FormDuyuruListesi : Form
    {

        SQLBaglantisi Sql = new SQLBaglantisi();

        public FormDuyuruListesi()
        {
            InitializeComponent();
        }

        private void FormDuyuruListesi_Load(object sender, EventArgs e)
        {
            ListBox Lst = new ListBox();
            Point LstKonum = new Point(10, 10);
            Lst.Name = "ListBox1";
            Lst.Height = 250;
            Lst.Width = 780;
            Lst.Font = new Font("Georgia", 14, FontStyle.Regular);
            Lst.Location = LstKonum;
            this.Controls.Add(Lst);

            SqlCommand Komut = new SqlCommand("SELECT * FROM TbDuyurular", Sql.Baglanti());
            SqlDataReader Reader = Komut.ExecuteReader();
            while (Reader.Read())
            {
                Lst.Items.Add(Reader[0] + " - " + Reader[1]);
            }
            Sql.Baglanti().Close();
        }
    }
}

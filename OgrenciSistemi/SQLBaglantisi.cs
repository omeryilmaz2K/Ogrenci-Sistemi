using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace OgrenciKayit
{
    class SQLBaglantisi
    {
        public SqlConnection Baglanti()
        {
            SqlConnection Baglan = new SqlConnection(@"Data Source=DESKTOP-76M5E2T;Initial Catalog=OgrenciSistemiVT;Integrated Security=True");
            Baglan.Open();
            return Baglan;
        }
    }
}

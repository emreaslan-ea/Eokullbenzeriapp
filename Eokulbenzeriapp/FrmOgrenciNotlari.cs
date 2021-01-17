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
namespace Eokulbenzeriapp
{
    public partial class FrmOgrenciNotlari : Form
    {
        public FrmOgrenciNotlari()
        {
            InitializeComponent();
        }
        public string numara;
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-CP3UBIA;Initial Catalog=EOKULSIST;Integrated Security=True");
        private void FrmOgrenciNotlari_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("SELECT DERSAD,SINAV1,SINAV2,SINAV3,PROJE,ORTALAMA,DURUM FROM Tbl_Notlar INNER JOIN Tbl_Dersler ON Tbl_Dersler.DERSID=Tbl_Notlar.DERSID WHERE OGRID=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1",numara);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}

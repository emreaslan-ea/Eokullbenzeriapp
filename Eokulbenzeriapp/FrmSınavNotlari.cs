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
    public partial class FrmSınavNotlari : Form
    {
        public FrmSınavNotlari()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.Tbl_NotlarTableAdapter ds = new DataSet1TableAdapters.Tbl_NotlarTableAdapter();
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-CP3UBIA;Initial Catalog=EOKULSIST;Integrated Security=True");

        private void FrmSınavNotlari_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("SELECT * FROM TBL_DERSLER", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbDersler.DisplayMember = "DERSAD";
            cmbDersler.ValueMember = "DERSID";
            cmbDersler.DataSource = dt;
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.NotListesi(int.Parse(txtOgrenciID.Text));
        }
        int notID;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            notID= int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtOgrenciID.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSınav1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtSınav2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtSınav3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtProje.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtOrtalama.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtDurum.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
        }
       

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtOgrenciID.Text = "";
            txtSınav1.Text = "";
            txtSınav2.Text = ""; 
            txtSınav3.Text = ""; 
            txtProje.Text = "";
            txtOrtalama.Text = "";
            txtDurum.Text = "";
        }
        int sinav1, sinav2, sinav3, proje;
        double ortalama;

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            sinav1 = Convert.ToInt32(txtSınav1.Text);
            sinav2 = Convert.ToInt32(txtSınav2.Text);
            sinav3 = Convert.ToInt32(txtSınav3.Text);
            proje = Convert.ToInt32(txtProje.Text);
            ortalama = (sinav1 + sinav2 + sinav3 + proje) / 4;
            txtOrtalama.Text = ortalama.ToString();
            if (ortalama >= 50)
            {
                txtDurum.Text = "True";

            }
            else
            {
                txtDurum.Text = "False";
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            ds.NotlarGuncelle(byte.Parse(cmbDersler.SelectedValue.ToString()),int.Parse(txtOgrenciID.Text), byte.Parse(txtSınav1.Text), byte.Parse(txtSınav2.Text), byte.Parse(txtSınav3.Text), byte.Parse(txtProje.Text), decimal.Parse(txtOrtalama.Text),bool.Parse(txtDurum.Text),notID);
        }
    }
}

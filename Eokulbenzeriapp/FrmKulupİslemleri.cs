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
    public partial class FrmKulupİslemleri : Form
    {
        public FrmKulupİslemleri()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-CP3UBIA;Initial Catalog=EOKULSIST;Integrated Security=True");

        void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Kulupler", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void FrmKulupİslemleri_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO TBL_KULUPLER (KULUPAD) VALUES (@p1)", baglanti);
            komut.Parameters.AddWithValue("@p1", txtKulupad.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Yeni bir kulüp listeye başarıyla eklenmiştir","Yeni Kulüp Eklendi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtKulupID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtKulupad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("DELETE FROM TBL_KULUPLER  where KULUPID=@p1", baglanti);
            komut1.Parameters.AddWithValue("@p1", txtKulupID.Text);
            komut1.ExecuteNonQuery();
            baglanti.Close();
            listele();
            MessageBox.Show("Kulüp başarıyla silinmiştir.", "Eski Kulüp Silindi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("UPDATE TBL_KULUPLER SET KULUPAD=@p1 where KULUPID=@p2", baglanti);
            komut2.Parameters.AddWithValue("@p1", txtKulupad.Text);
            komut2.Parameters.AddWithValue("@p2", txtKulupID.Text);
            komut2.ExecuteNonQuery();
            baglanti.Close();
            listele();
            MessageBox.Show("Güncelleme işlemi başarıyla gerçekleşmiştir","Kulüp Güncellendi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmOgretmen fr = new FrmOgretmen();
            fr.Show();
            this.Hide();
        }
    }
}

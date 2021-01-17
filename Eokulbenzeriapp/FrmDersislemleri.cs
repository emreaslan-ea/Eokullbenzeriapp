using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eokulbenzeriapp
{
    public partial class FrmDersislemleri : Form
    {
        public FrmDersislemleri()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmOgretmen fr = new FrmOgretmen();
            fr.Show();
            this.Hide();
        }
        DataSet1TableAdapters.Tbl_DerslerTableAdapter dtable = new DataSet1TableAdapters.Tbl_DerslerTableAdapter();
        
        private void FrmDersislemleri_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dtable.Derslistesi();
        }
        
        private void btnEkle_Click(object sender, EventArgs e)
        {
            dtable.DersEkle(txtdersad.Text);
            dataGridView1.DataSource = dtable.Derslistesi();
            MessageBox.Show("Ders ekleme işlemi başarıyla tamamlanmıştır", "Ders eklendi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtdersID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtdersad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            dtable.DersSil(byte.Parse(txtdersID.Text));
            dataGridView1.DataSource = dtable.Derslistesi();
            MessageBox.Show("Ders silme işlemi başarıyla gerçekleştirilmiştir", "Ders silindi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            dtable.DersGuncelle(txtdersad.Text, byte.Parse(txtdersID.Text));
            dataGridView1.DataSource = dtable.Derslistesi();
            MessageBox.Show("Ders güncelleme işlemi başarıyla gerçekleştirilmiştir", "Ders güncellendi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dtable.Derslistesi();
        }
    }
}

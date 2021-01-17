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
    public partial class FrmOgrencislemleri : Form
    {
        public FrmOgrencislemleri()
        {
            InitializeComponent();
        }

        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-CP3UBIA;Initial Catalog=EOKULSIST;Integrated Security=True");

        private void FrmOgrencislemleri_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrencislemleriList();

            SqlCommand komut = new SqlCommand("SELECT * FROM TBL_KULUPLER", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbKulup.DisplayMember = "KULUPAD";
            cmbKulup.ValueMember = "KULUPID";
            cmbKulup.DataSource = dt;

        }
        string c = " ";
        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (radioButtonErkek.Checked == false && radioButtonKız.Checked == false)
            {
                MessageBox.Show("Lütfen bir cinsiyet giriniz", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (txtOgrenciad.Text == "")
            {
                MessageBox.Show("Lütfen bir isim giriniz", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (txtOgrenciSoyad.Text == "")
            {
                MessageBox.Show("Lütfen bir soyisim giriniz", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                if (radioButtonErkek.Checked == true)
                {
                    c = "Erkek";
                }
                if (radioButtonKız.Checked == true)
                {
                    c = "Kız";
                }

                ds.OgrenciEkle(txtOgrenciad.Text, txtOgrenciSoyad.Text, byte.Parse(cmbKulup.SelectedValue.ToString()), c);
                MessageBox.Show("Öğrenci ekleme işlemi başarıyla gerçekleştirilmiştir", "Öğrenci eklendi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = ds.OgrencislemleriList();
            }
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrencislemleriList();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            ds.OgrenciSil(int.Parse(txtOgrenciID.Text));
            dataGridView1.DataSource = ds.OgrencislemleriList();
            MessageBox.Show("Silme işlemi başarıyla gerçekleştirilmiştir","Öğrenci Silindi",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            txtOgrenciID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtOgrenciad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtOgrenciSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            cmbKulup.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            if (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() == "Kız")
            {
                radioButtonKız.Checked = true;
            }
            else
            {
                radioButtonErkek.Checked = true;
            }
        }
        
        private void linkLabelTemizle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            txtOgrenciad.Text = "";
            txtOgrenciID.Text = "";
            txtOgrenciSoyad.Text = "";
            cmbKulup.SelectedItem = "";
            radioButtonErkek.Checked = false;
            radioButtonKız.Checked = false;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (radioButtonErkek.Checked == false && radioButtonKız.Checked == false)
            {
                MessageBox.Show("Lütfen bir cinsiyet giriniz", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (txtOgrenciad.Text == "")
            {
                MessageBox.Show("Lütfen bir isim giriniz", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (txtOgrenciSoyad.Text == "")
            {
                MessageBox.Show("Lütfen bir soyisim giriniz", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                if (radioButtonErkek.Checked == true)
                {
                    c = "Erkek";
                }
                if (radioButtonKız.Checked == true)
                {
                    c = "Kız";
                }

                ds.OgrenciGuncelle(txtOgrenciad.Text, txtOgrenciSoyad.Text, int.Parse(cmbKulup.SelectedValue.ToString()), c, int.Parse(txtOgrenciID.Text));
                dataGridView1.DataSource = ds.OgrencislemleriList();
                MessageBox.Show("Öğrencinin bilgileri başarıyla güncellendi", "Günceleme işlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource=ds.OgrenciAra(txtAra.Text);
        }
    }
}

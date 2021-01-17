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
    public partial class FrmAnaGiris : Form
    {
        public FrmAnaGiris()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (lblPinogr.Text == txtpinogr.Text)
            {
                FrmOgrenciNotlari fr = new FrmOgrenciNotlari();
                fr.numara = textBox1.Text;
                fr.Show();
            }
            else
            {
                MessageBox.Show("Yanlış pin ve ya okul numarası girildi.\nLütfen tekrar deneyiniz", "Yanlış giriş denendi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (lblSifreOgrt.Text == "1234")
            {
                FrmOgretmen fr = new FrmOgretmen();
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Yanlış şifre girildi...\nLütfen tekrar deneyiniz.", "Yanlış giriş denendi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void random()
        {
            string[] sembol1 = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "V", "Y", "Z", "Q", "W", "X" };
            string[] sembol2 = { "a", "b", "c", "d", "e", "f", "g", "h", "ı", "i", "j", "k", "l", "m", "n", "o", "p", "r", "s", "ş", "t", "u", "v", "y", "z", "q", "w", "x" };

            Random rndm = new Random();
            int s1, s2, s3, s4;
            s1 = rndm.Next(0, sembol1.Length);
            s2 = rndm.Next(0, sembol2.Length);
            s3 = rndm.Next(0, 10);
            s4 = rndm.Next(0, 10);
            lblPinogr.Text = sembol1[s1] + s3.ToString() + sembol2[s2] + s4.ToString();
        }
        private void FrmAnaGiris_Load(object sender, EventArgs e)
        {
            random();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            random();
        }
    }
}

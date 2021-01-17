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
    public partial class FrmOgretmen : Form
    {
        public FrmOgretmen()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmKulupİslemleri fr = new FrmKulupİslemleri();
            fr.Show();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmDersislemleri fr = new FrmDersislemleri();
            fr.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmOgrencislemleri fr = new FrmOgrencislemleri();
            fr.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmYukleniyorcs fr = new FrmYukleniyorcs();
            fr.Show();
        }
    }
}

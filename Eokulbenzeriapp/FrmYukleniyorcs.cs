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
    public partial class FrmYukleniyorcs : Form
    {
        public FrmYukleniyorcs()
        {
            InitializeComponent();
        }
        int a;
        private void FrmYukleniyorcs_Load(object sender, EventArgs e)
        {
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.MarqueeAnimationSpeed = 30;
            timer1.Interval = 3500;
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            a++;
            if (a == 1)
            {
                timer1.Stop();
                this.Hide();
                FrmSınavNotlari fr = new FrmSınavNotlari();
                fr.Show();
            }
        }
    }
}

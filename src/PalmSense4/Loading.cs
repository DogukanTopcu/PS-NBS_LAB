using PalmSense4.components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalmSense4
{
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void Loading_Load(object sender, EventArgs e)
        {
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.MarqueeAnimationSpeed = 2;
        }

        private async void rjButton1_Click(object sender, EventArgs e)
        {
            await regeneration.psRegeneration.AbortMeasurementAsync();
            this.Close();
        }
    }
}

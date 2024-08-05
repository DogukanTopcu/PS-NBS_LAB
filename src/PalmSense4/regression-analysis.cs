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
    public partial class regression_analysis : Form
    {
        List<double> xdata;
        List<double> ydata;

        public regression_analysis()
        {
            InitializeComponent();

            xdata = new List<double>();
            ydata = new List<double>();
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = !splitContainer1.Panel1Collapsed;
            rjButton1.BackgroundImage.RotateFlip(RotateFlipType.Rotate180FlipY);
        }

        private void regression_analysis_Load(object sender, EventArgs e)
        {
            plotsPanel.Controls.Add(splitContainer1);
        }

        private void calculateBtn_Click(object sender, EventArgs e)
        {
            var M = Matrix<double>.Build;
            var V = Vector<double>.Build;



            
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MathNet.Numerics.LinearAlgebra;

namespace PalmSense4
{
    public partial class RegressionAnalysis : Form
    {
        List<double> xdata;
        List<double> ydata;

        public RegressionAnalysis()
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
            //plotsPanel.Controls.Add(splitContainer1);
        }

        private void calculateBtn_Click(object sender, EventArgs e)
        {
            var M = Matrix<double>.Build;
            var V = Vector<double>.Build;

            // Create xdata and ydata lists
            // Also find the minimum and maximum values of xdata.
            double minValue = 0.0;
            double maxValue = 0.0;

            var X = M.DenseOfColumnVectors(V.Dense(xdata.ToArray().Length, 1), V.Dense(xdata.ToArray()));
            var Y = V.Dense(ydata.ToArray());
            var P = X.QR().Solve(Y);

            double a = P[0];
            double b = P[1];

            // y = a + bx
            List<double> xVals = new List<double>();
            List<double> yVals = new List<double>();
            for (double x = minValue; x < maxValue; x++)
            {
                double y = a + b * x;
                xVals.Add(x);
                yVals.Add(y);
            }

            plot1.AddData("", new List<double>(xVals).ToArray(), new List<double>(yVals).ToArray());
        }
    }
}

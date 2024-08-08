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

        private Dictionary<string, List<List<double>>> _allMeasurements;

        public RegressionAnalysis(Dictionary<string, List<List<double>>> _m)
        {
            InitializeComponent();

            xdata = new List<double>();
            ydata = new List<double>();

            _allMeasurements = _m;
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
            foreach (var item in _allMeasurements)
            {
                plotsList.Items.Add(item.Key);
            }
        }


        // Regression Analysis for all graph
        private void calculateBtn_Click(object sender, EventArgs e)
        {
            plot1.ClearAll();

            var M = Matrix<double>.Build;
            var V = Vector<double>.Build;

            // Create xdata and ydata lists
            Console.WriteLine(plotsList.SelectedItems.Count);
            Console.WriteLine(plotsList.CheckedItems.Count);
            for (int j = 0; j < plotsList.CheckedItems.Count; j++)
            {
                string plotName = plotsList.SelectedItems[j].ToString();
                List<List<double>> plotData = _allMeasurements[plotName];

                foreach (List<double> data in plotData)
                {
                    xdata.Add(data[1]);
                    ydata.Add(data[2]);
                }

                plot1.AddData(plotName, xdata.ToArray(), ydata.ToArray());
            }
            // Also find the minimum and maximum values of xdata.
            double minValue = xdata[0];
            double maxValue = xdata[xdata.Count - 1];

            var X = M.DenseOfColumnVectors(V.Dense(xdata.ToArray().Length, 1), V.Dense(xdata.ToArray()));
            var Y = V.Dense(ydata.ToArray());
            var P = X.QR().Solve(Y);

            double a = P[0];
            double b = P[1];

            // y = a + bx
            List<double> xVals = new List<double>();
            List<double> yVals = new List<double>();

            foreach (double x in xdata)
            {
                double y = a + b * x;
                xVals.Add(x);
                yVals.Add(y);
            }

            plot1.AddData("", new List<double>(xVals).ToArray(), new List<double>(yVals).ToArray());
        }

        private void plotsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //List<double> tempXdata = new List<double>();
            //List<double> tempYdata = new List<double>();
            //plot1.ClearAll();
            
            //for (int j = 0; j < plotsList.SelectedItems.Count; j++)
            //{
            //    string plotName = plotsList.SelectedItems[j].ToString();
            //    List<List<double>> plotData = _allMeasurements[plotName];

            //    foreach (List<double> data in plotData)
            //    {
            //        tempXdata.Add(data[1]);
            //        tempYdata.Add(data[2]);
            //    }

            //    plot1.AddData(plotName, xdata.ToArray(), ydata.ToArray());
            //}
        }
    }
}

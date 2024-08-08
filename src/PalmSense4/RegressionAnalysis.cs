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
using PalmSens.Core.Simplified.Data;
using PalmSens.Plottables;

namespace PalmSense4
{
    public partial class RegressionAnalysis : Form
    {
        List<double> xdata;
        List<double> ydata;

        private List<SimpleCurve> _allMeasurements;

        private Dictionary<string, SimpleCurve> _allCurvesDict;

        public RegressionAnalysis(List<SimpleCurve> _m)
        {
            InitializeComponent();

            xdata = new List<double>();
            ydata = new List<double>();

            _allMeasurements = _m;
            _allCurvesDict = new Dictionary<string, SimpleCurve>();
            int l = 0;
            foreach (SimpleCurve item in _allMeasurements)
            {
                _allCurvesDict.Add(l.ToString() + ") " +item.FullTitle, item);
                l++;
            }
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
            foreach (var item in _allCurvesDict)
            {
                plotsList.Items.Add(item.Key);
            }
        }


        // Regression Analysis for all graph
        //private void calculateBtn_Click(object sender, EventArgs e)
        //{
        //    plot1.ClearAll();

        //    var M = Matrix<double>.Build;
        //    var V = Vector<double>.Build;

        //    // Create xdata and ydata lists
        //    for (int j = 0; j < plotsList.CheckedItems.Count; j++)
        //    {
        //        string plotName = plotsList.SelectedItems[j].ToString();
        //        List<List<double>> plotData = _allMeasurements[plotName];

        //        foreach (List<double> data in plotData)
        //        {
        //            xdata.Add(data[1]);
        //            ydata.Add(data[2]);
        //        }

        //        plot1.AddData(plotName, xdata.ToArray(), ydata.ToArray());
        //    }
        //    // Also find the minimum and maximum values of xdata.
        //    double minValue = xdata[0];
        //    double maxValue = xdata[xdata.Count - 1];

        //    var X = M.DenseOfColumnVectors(V.Dense(xdata.ToArray().Length, 1), V.Dense(xdata.ToArray()));
        //    var Y = V.Dense(ydata.ToArray());
        //    var P = X.QR().Solve(Y);

        //    double a = P[0];
        //    double b = P[1];

        //    // y = a + bx
        //    List<double> xVals = new List<double>();
        //    List<double> yVals = new List<double>();

        //    foreach (double x in xdata)
        //    {
        //        double y = a + b * x;
        //        xVals.Add(x);
        //        yVals.Add(y);
        //    }

        //    plot1.AddData("", new List<double>(xVals).ToArray(), new List<double>(yVals).ToArray());
        //}


        private void calculateBtn_Click(object sender, EventArgs e)
        {
            plot1.ClearAll();
            tabControl1.SelectedTab = tabPage1;

            var M = Matrix<double>.Build;
            var V = Vector<double>.Build;


            // Take all peak data and
            // fill these xdata and ydata lists
            for (int j = 0; j < plotsList.CheckedItems.Count; j++)
            {
                string plotName = plotsList.CheckedItems[j].ToString();
                SimpleCurve plotData = _allCurvesDict[plotName];

                // Peak Detection
                if (plotData.FullTitle.Contains("DPV"))
                {
                    SimpleCurve _baselineCurve = plotData.MovingAverageBaseline();
                    plotData = plotData.Subtract(_baselineCurve);
                }
                plotData.DetectPeaks();

                for (int i = 0; i < plotData.Peaks.nPeaks; i++)
                {
                    xdata.Add(plotData.Peaks[i].PeakX);
                    ydata.Add(plotData.Peaks[i].PeakValue);

                    double[] x = new double[1];
                    double[] y = new double[1];
                    x[0] = plotData.Peaks[i].PeakX;
                    y[0] = plotData.Peaks[i].PeakValue;
                    plot1.AddData("", x, y);
                }
            }

            // Find the minimum and maximum values of xdata.
            double minValue = xdata.Min();
            double maxValue = xdata.Max();


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
            plot2.ClearAll();
            tabControl1.SelectedTab = tabPage2;
            string plotName = plotsList.SelectedItem.ToString();
            try
            {
                SimpleCurve curve = _allCurvesDict[plotName];
                if (curve.FullTitle.Contains("DPV"))
                {
                    SimpleCurve _baselineCurve = curve.MovingAverageBaseline();
                    curve = curve.Subtract(_baselineCurve);
                }
                curve.DetectPeaks();
                plot2.AddSimpleCurve(curve);
            }
            catch { }
        }
    }
}

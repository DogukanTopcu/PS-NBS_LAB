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
using PalmSense4.components;

namespace PalmSense4
{
    public partial class RegressionAnalysis : Form
    {
        List<double> xdata;
        List<double> ydata;

        private List<SimpleCurve> _allMeasurements;

        private Dictionary<string, SimpleCurve> _allCurvesDict;

        private int manuelDataNumber = 0;
        private List<manuelPeakDataView> manuelData;
        public static List<autoPeakDataView> autoPeakData = new List<autoPeakDataView>();
        public static FlowLayoutPanel autoPeakDataflp;

        public RegressionAnalysis(List<SimpleCurve> _m)
        {
            InitializeComponent();

            xdata = new List<double>();
            ydata = new List<double>();

            manuelData = new List<manuelPeakDataView>();

            _allMeasurements = _m;
            _allCurvesDict = new Dictionary<string, SimpleCurve>();

            autoPeakDataflp = autoDetectedPlots;

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
            lod_label.Text = "";
            loq_label.Text = "";
            formul.Text = "";
            //plotsPanel.Controls.Add(splitContainer1);
            foreach (var item in _allCurvesDict)
            {
                plotsList.Items.Add(item.Key);
            }
            decreaseBtn.Enabled = false;
            decreaseBtn.BackgroundColor = Color.LightGray;
        }


        private void calculateBtn_Click(object sender, EventArgs e)
        {
            plot1.ClearAll();
            tabControl1.SelectedTab = tabPage1;

            var M = Matrix<double>.Build;
            var V = Vector<double>.Build;


            // Take all peak data and
            // fill these xdata and ydata lists

            // Peak Detection
            foreach (autoPeakDataView item in autoPeakData)
            {
                if (item.CheckIsValid())
                {
                    double c = Double.Parse(item.concentration.Texts);
                    double cur = item.peaks[item.current.SelectedIndex];
                    xdata.Add(c);
                    ydata.Add(cur);

                    double[] x = new double[1];
                    double[] y = new double[1];
                    x[0] = c;
                    y[0] = cur;
                    plot1.AddData("", x, y);
                }
            }

            // Manuel Peaks:
            foreach (manuelPeakDataView component in manuelData)
            {
                if (component.CheckIsValid())
                {
                    xdata.Add(component.xValue);
                    ydata.Add(component.yValue);

                    double[] x = new double[1];
                    double[] y = new double[1];
                    x[0] = component.xValue;
                    y[0] = component.yValue;
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
            
            formul.Text = $"y = {b.ToString("F4")}x + {a.ToString("F4")}";

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


            plot1.YAxisLabel = "Current (µA)";
            plot1.XAxisLabel = "Concentration (M)";

            if (ydata.Count > 2)
            {
                double sd = CalculateStandardError(ydata, yVals);
                double lod = 3.3 * (sd / a);
                double loq = 10 * (sd / a);

                lod_label.Text = "LOD: " + lod.ToString("F4");
                loq_label.Text = "LOQ: " + loq.ToString("F4");
            }
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


            for (int j = 0; j < autoPeakData.Count; j++)
            {
                autoPeakDataView item = autoPeakData[j];
                bool isExists = false;
                for (int i = 0; i < plotsList.CheckedItems.Count; i++)
                {
                    string pName = plotsList.CheckedItems[i].ToString();
                    if (item.name == pName)
                    {
                        isExists = true;
                        break;
                    }
                }
                if (!isExists)
                {
                    autoPeakData.Remove(item);
                    autoDetectedPlots.Controls.Remove(item);
                    j--;
                }
            }

            for (int i = 0; i < plotsList.CheckedItems.Count; i++)
            {
                string pName = plotsList.CheckedItems[i].ToString();
                bool isExists = false;
                foreach (autoPeakDataView item in autoPeakData)
                {
                    if (item.name == pName)
                    {
                        isExists = true;
                        break;
                    }
                }
                if (isExists)
                {
                    continue;
                }
                SimpleCurve plotData = _allCurvesDict[pName];

                // Peak Detection
                if (plotData.FullTitle.Contains("DPV"))
                {
                    SimpleCurve _baselineCurve = plotData.MovingAverageBaseline();
                    plotData = plotData.Subtract(_baselineCurve);
                }
                plotData.DetectPeaks();

                List<double> peaks = new List<double>();
                for (int j = 0; j < plotData.Peaks.nPeaks; j++)
                {
                    peaks.Add(plotData.Peaks[j].PeakValue);
                }

                autoPeakDataView component = new autoPeakDataView(pName, peaks, false);
                autoDetectedPlots.Controls.Add(component);
                autoPeakData.Add(component);
            }
        }

        private void increaseBtn_Click(object sender, EventArgs e)
        {
            manuelDataNumber++;
            decreaseBtn.Enabled = true;
            decreaseBtn.BackgroundColor = Color.CornflowerBlue;

            manuelPeakDataView component = new manuelPeakDataView("Plot " + manuelDataNumber + ":", manuelDataNumber);
            manuelPeaks.Controls.Add(component);
            manuelData.Add(component);
        }

        private void decreaseBtn_Click(object sender, EventArgs e)
        {
            manuelDataNumber--;
            if (manuelDataNumber == 0)
            {
                decreaseBtn.Enabled = false;
                decreaseBtn.BackgroundColor = Color.LightGray;
            }
            manuelPeaks.Controls.Remove(manuelPeaks.Controls[manuelPeaks.Controls.Count - 1]);
            manuelData.Add(manuelData[manuelData.Count - 1]);
        }


        private double CalculateStandardError(List<double> actualValues, List<double> predictedValues)
        {
            if (actualValues.Count != predictedValues.Count)
                throw new ArgumentException("The lists must have the same number of elements.");

            int n = actualValues.Count;

            // Calculate residuals (errors)
            double sumOfSquaredResiduals = 0;
            for (int i = 0; i < n; i++)
            {
                double residual = actualValues[i] - predictedValues[i];
                sumOfSquaredResiduals += Math.Pow(residual, 2);
            }

            // Calculate the standard error of the regression
            double standardError = Math.Sqrt(sumOfSquaredResiduals / (n - 2));
            return standardError;
        }
    }
}

using Microsoft.Office.Interop.Excel;
using PalmSens;
using PalmSens.Core.Simplified.Data;
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
    public partial class FilteredPlot : Form
    {
        private SimpleCurve _activeCurve;
        private SimpleCurve _baselineCurve;

        public FilteredPlot(SimpleCurve activeCurve)
        {
            InitializeComponent();
            _activeCurve = activeCurve;
        }

        private void FilteredPlot_Load(object sender, EventArgs e)
        {
            plot1.AddSimpleCurve(_activeCurve);
            this.Text = _activeCurve.FullTitle;

            if (_activeCurve.Title == "DPV i vs E" || _activeCurve.Title == "DPV i vs E, smooth level High")
            {
                averageBaselineToolStripMenuItem.Enabled = true;
                subtractBaselineToolStripMenuItem.Enabled = true;
            }
            else
            {
                averageBaselineToolStripMenuItem.Enabled = false;
                subtractBaselineToolStripMenuItem.Enabled = false;
            }


        }


        private void smoothCurveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            plot1.RemoveSimpleCurve(_activeCurve);
            SimpleCurve smoothedCurve = _activeCurve.Smooth(SmoothLevel.High);

            plot1.AddSimpleCurve(smoothedCurve);
        }

        private void averageBaselineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Determine and plot the moving average baseline curve
            _baselineCurve = _activeCurve.MovingAverageBaseline();
            plot1.AddSimpleCurve(_baselineCurve);
        }

        private void subtractBaselineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _activeCurve = _activeCurve.Subtract(_baselineCurve); //Replace the activeCurve reference with the result
            plot1.AddSimpleCurve(_activeCurve);

        }

        private void detectPeaksToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _activeCurve.DetectPeaks();
        }

        private void pssessionFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void xlsxFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}

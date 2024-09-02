using Microsoft.Office.Interop.Excel;
using PalmSens;
using PalmSens.Comm;
using PalmSens.Core.Simplified.Data;
using PalmSense4.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        
        private FileIO _fileIO;
        private List<SimpleMeasurement> _activeMeasurement;

        public FilteredPlot(SimpleCurve activeCurve, SimpleMeasurement activeMeasurement)
        {
            InitializeComponent();
            _activeCurve = activeCurve;
            
            _fileIO = new FileIO();
            _activeMeasurement = new List<SimpleMeasurement>();
            _activeMeasurement.Add(activeMeasurement);
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



        // Export Process
        string folderName = null;
        private void pssessionFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            folderBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop;
            folderBrowserDialog.Description = "Save Measurement";

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                folderName = folderBrowserDialog.SelectedPath;
                string fileName = "PalmSens4 Measurement (" + DateTime.Now.ToString("MM-dd-yyyy-h-mm-tt") + ").pssession";
                string filePathName = Path.Combine(folderName, fileName);

                if (_fileIO.SaveDataToPssession(filePathName, _activeMeasurement))
                {
                    MainPage.lbox.Items.Add($"Measurements successfully saved to {filePathName}");
                }
                else
                {
                    MainPage.lbox.Items.Add("An error occurred when saving measurements");
                }
            }
        }

        private void xlsxFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exportAsImageToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}

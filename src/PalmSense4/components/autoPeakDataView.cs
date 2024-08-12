using RJCodeAdvance.RJControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalmSense4.components
{
    public partial class autoPeakDataView : UserControl
    {
        public List<double> peaks;
        public string name;
        public bool isDuplicated;

        public RJTextBox concentration;
        public ComboBox current;

        public autoPeakDataView(string plotName, List<double> peaks, bool isDuplicated)
        {
            InitializeComponent();
            name = plotName;
            this.peaks = peaks;
            this.isDuplicated = isDuplicated;

            this.concentration = concentration_value;
            this.current = cbPeaks;
        }

        private void autoPeakDataView_Load(object sender, EventArgs e)
        {
            this.plotName.Text = name;
            if (isDuplicated)
            {
                removeBtn.Enabled = true;
                removeBtn.Visible = true;

                duplicateBtn.Enabled = false;
                duplicateBtn.Visible = false;
            }
            else
            {
                removeBtn.Enabled = false;
                removeBtn.Visible = false;

                duplicateBtn.Enabled = true;
                duplicateBtn.Visible = true;
            }

            for (int i = 0; i < peaks.Count; i++)
            {
                cbPeaks.Items.Add(peaks[i].ToString("E3"));
            }
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            RegressionAnalysis.autoPeakData.Remove(this);
            RegressionAnalysis.autoPeakDataflp.Controls.Remove(this);
        }

        private void duplicateBtn_Click(object sender, EventArgs e)
        {
            autoPeakDataView component = new autoPeakDataView(name, peaks, true);
            RegressionAnalysis.autoPeakData.Add(component);
            RegressionAnalysis.autoPeakDataflp.Controls.Add(component);
        }


        public bool CheckIsValid()
        {
            if (concentration_value.Texts == "" || cbPeaks.SelectedIndex == -1)
            {
                return false;
            }
            return true;
        }
    }
}

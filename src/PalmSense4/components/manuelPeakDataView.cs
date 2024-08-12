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
    public partial class manuelPeakDataView : UserControl
    {
        public double xValue;
        public double yValue;
        public int id;

        public manuelPeakDataView(string dataName, int id)
        {
            InitializeComponent();

            peakCount.Text = dataName;
            this.id = id;
        }

        private void xVal_Click(object sender, EventArgs e)
        {

        }

        private void manuelPeakDataView_Load(object sender, EventArgs e)
        {

        }

        private void xValInput__TextChanged(object sender, EventArgs e)
        {
            try
            {
                xValue = Double.Parse(xValInput.Texts);
            }
            catch
            {
                MessageBox.Show("Please enter a floating point or integer number.");
            }
        }

        private void yValInput__TextChanged(object sender, EventArgs e)
        {
            try
            {
                yValue = Double.Parse(yValInput.Texts);
            }
            catch
            {
                MessageBox.Show("Please enter a floating point or integer number.");
            }
        }


        public bool CheckIsValid()
        {
            if (xValInput.Texts == "" || yValInput.Texts == "")
            {
                return false;
            }
            return true;
        }
    }
}

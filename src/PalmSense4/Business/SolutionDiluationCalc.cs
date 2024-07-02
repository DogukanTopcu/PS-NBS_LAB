using RJCodeAdvance.RJControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalmSense4.Business
{
    public class SolutionDiluationCalc
    {
        // Solution Diluation Calculator Attributes
        private RadioButton rbInitConc;
        private RadioButton rbInitVol;
        private RadioButton rbFinConc;
        private RadioButton rbFinVol;
        private RJTextBox tbInitConc;
        private RJTextBox tbInitVol;
        private RJTextBox tbFinConc;
        private RJTextBox tbFinVol;

        public SolutionDiluationCalc(
            RadioButton rbInitConc,
            RadioButton rbInitVol,
            RadioButton rbFinConc,
            RadioButton rbFinVol,
            RJTextBox tbInitConc,
            RJTextBox tbInitVol,
            RJTextBox tbFinConc,
            RJTextBox tbFinVol
        )
        {
            this.rbInitConc = rbInitConc;
            this.rbInitVol = rbInitVol;
            this.rbFinConc = rbFinConc;
            this.rbFinVol = rbFinVol;
            this.tbInitConc = tbInitConc;
            this.tbInitVol = tbInitVol;
            this.tbFinConc = tbFinConc;
            this.tbFinVol = tbFinVol;
        }

        public void rbInitConc_CheckedChanged()
        {
            if (rbInitConc.Checked)
            {
                tbInitConc.Enabled = false; tbInitVol.Enabled = true; tbFinConc.Enabled = true; tbFinVol.Enabled = true;
                tbInitConc.Texts = string.Empty;
            }
        }

        public void rbInitVol_CheckedChanged()
        {
            if (rbInitVol.Checked)
            {
                tbInitVol.Enabled = false; tbInitConc.Enabled = true; tbFinConc.Enabled = true; tbFinVol.Enabled = true;
                tbInitVol.Texts = string.Empty;
            }
        }

        public void rbFinConc_CheckedChanged()
        {
            if (rbFinConc.Checked)
            {
                tbFinConc.Enabled = false; tbInitVol.Enabled = true; tbInitConc.Enabled = true; tbFinVol.Enabled = true;
                tbFinConc.Texts = string.Empty;
            }
        }

        public void rbFinVol_CheckedChanged()
        {
            if (rbFinVol.Checked)
            {
                tbFinVol.Enabled = false; tbInitVol.Enabled = true; tbInitConc.Enabled = true; tbFinConc.Enabled = true;
                tbFinVol.Texts = string.Empty;
            }
        }




        public void SolDilCalc()
        {
            double InitConc, InitVol, FinConc, FinVol;
            if (rbInitConc.Checked)
            {
                if (double.TryParse(tbInitVol.Texts, out InitVol) && double.TryParse(tbFinConc.Texts, out FinConc) && double.TryParse(tbFinVol.Texts, out FinVol))
                {
                    InitConc = (FinConc * FinVol) / InitVol;
                    tbInitConc.Texts = InitConc.ToString("0.00000");
                }
            }
            else if (rbInitVol.Checked)
            {
                if (double.TryParse(tbInitConc.Texts, out InitConc) && double.TryParse(tbFinConc.Texts, out FinConc) && double.TryParse(tbFinVol.Texts, out FinVol))
                {
                    InitVol = (FinConc * FinVol) / InitConc;
                    tbInitVol.Texts = InitVol.ToString("0.00000");
                }
            }
            else if (rbFinConc.Checked)
            {
                if (double.TryParse(tbInitConc.Texts, out InitConc) && double.TryParse(tbInitVol.Texts, out InitVol) && double.TryParse(tbFinVol.Texts, out FinVol))
                {
                    FinConc = (InitConc * InitVol) / FinVol;
                    tbFinConc.Texts = FinConc.ToString("0.00000");
                }
            }
            else if (rbFinVol.Checked)
            {
                if (double.TryParse(tbInitConc.Texts, out InitConc) && double.TryParse(tbFinConc.Texts, out FinConc) && double.TryParse(tbInitVol.Texts, out InitVol))
                {
                    FinVol = (InitConc * InitVol) / FinConc;
                    tbFinVol.Texts = FinVol.ToString("0.00000");
                }
            }
        }


        public void soldiluationResetBtn_Click()
        {
            rbInitConc.Checked = false; rbFinConc.Checked = false; rbInitVol.Checked = false; rbFinVol.Checked = false;
            tbInitConc.Enabled = false; tbInitVol.Enabled = false; tbFinConc.Enabled = false; tbFinVol.Enabled = false;
            tbInitConc.Texts = string.Empty; tbInitVol.Texts = string.Empty; tbFinConc.Texts = string.Empty; tbFinVol.Texts = string.Empty;
        }
    }
}

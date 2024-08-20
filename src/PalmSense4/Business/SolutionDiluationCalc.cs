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
        private ComboBox initConcentration;
        private ComboBox finalConcentration;
        private ComboBox initVolume;
        private ComboBox finalVolume;

        private Dictionary<string, Dictionary<string, int>> _conversionFactorsForConcentration;
        private Dictionary<string, Dictionary<string, int>> _conversionFactorsForVolume;

        public SolutionDiluationCalc(
            RadioButton rbInitConc,
            RadioButton rbInitVol,
            RadioButton rbFinConc,
            RadioButton rbFinVol,
            RJTextBox tbInitConc,
            RJTextBox tbInitVol,
            RJTextBox tbFinConc,
            RJTextBox tbFinVol,
            ComboBox initConcentration,
            ComboBox finalConcentration,
            ComboBox initVolume,
            ComboBox finalVolume
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
            this.initConcentration = initConcentration;
            this.initVolume = initVolume;
            this.finalConcentration = finalConcentration;
            this.finalVolume = finalVolume;

            this._conversionFactorsForConcentration = new Dictionary<string, Dictionary<string, int>>();
            this._conversionFactorsForVolume = new Dictionary<string, Dictionary<string, int>>();
            AddConversionData();

        }
        private void AddConversionData()
        {
            _conversionFactorsForConcentration.Add("M", new Dictionary<string, int> { { "M", 0 }, { "mM", 3 }, { "μM", 6 }, { "nM", 9 }, { "pM", 12 }, { "fM", 15 } });
            _conversionFactorsForConcentration.Add("mM", new Dictionary<string, int> { { "M", -3 }, { "mM", 0 }, { "μM", 3 }, { "nM", 6 }, { "pM", 9 }, { "fM", 12 } });
            _conversionFactorsForConcentration.Add("μM", new Dictionary<string, int> { { "M", -6 }, { "mM", -3 }, { "μM", 0 }, { "nM", 3 }, { "pM", 6 }, { "fM", 9 } });
            _conversionFactorsForConcentration.Add("nM", new Dictionary<string, int> { { "M", -9 }, { "mM", -6 }, { "μM", -3 }, { "nM", 0 }, { "pM", 3 }, { "fM", 6 } });
            _conversionFactorsForConcentration.Add("pM", new Dictionary<string, int> { { "M", -12 }, { "mM", -9 }, { "μM", -6 }, { "nM", -3 }, { "pM", 0 }, { "fM", 3 } });
            _conversionFactorsForConcentration.Add("fM", new Dictionary<string, int> { { "M", -15 }, { "mM", -12 }, { "μM", -9 }, { "nM", -6 }, { "pM", -3 }, { "fM", 0 } });

            _conversionFactorsForVolume.Add("L", new Dictionary<string, int> { { "L", 0 }, { "mL", 3 }, { "μL", 6 } });
            _conversionFactorsForVolume.Add("mL", new Dictionary<string, int> { { "L", -3 }, { "mL", 0 }, { "μL", 3 } });
            _conversionFactorsForVolume.Add("μL", new Dictionary<string, int> { { "L", -6 }, { "mL", -3 }, { "μL", 0 } });
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




        public void SolDilCalc(string initConc, string initVol, string finalConc, string finalVol)
        {
            if (initConc != null && initVol != null && finalConc != null && finalVol != null)
            {
                int initConcFactor = _conversionFactorsForConcentration[initConc]["M"];
                int finalConcFactor = _conversionFactorsForConcentration[finalConc]["M"];
                int initVolFactor = _conversionFactorsForVolume[initVol]["L"];
                int finalVolFactor = _conversionFactorsForVolume[finalVol]["L"];
                try
                {
                    double InitConc, InitVol, FinConc, FinVol;
                    if (rbInitConc.Checked)
                    {
                        if (double.TryParse(tbInitVol.Texts, out InitVol) && double.TryParse(tbFinConc.Texts, out FinConc) && double.TryParse(tbFinVol.Texts, out FinVol))
                        {
                            int numberOfZeros = finalConcFactor + finalVolFactor - initConcFactor - initVolFactor;
                            InitConc = (FinConc * FinVol) / InitVol;
                            InitConc = PutZeros(numberOfZeros, InitConc);

                            tbInitConc.Texts = InitConc.ToString("0.0000");
                        }
                    }
                    else if (rbInitVol.Checked)
                    {
                        if (double.TryParse(tbInitConc.Texts, out InitConc) && double.TryParse(tbFinConc.Texts, out FinConc) && double.TryParse(tbFinVol.Texts, out FinVol))
                        {
                            int numberOfZeros = finalConcFactor + finalVolFactor - initConcFactor - initVolFactor;
                            InitVol = (FinConc * FinVol) / InitConc;
                            InitVol = PutZeros(numberOfZeros, InitVol);

                            tbInitVol.Texts = InitVol.ToString("0.0000");
                        }
                    }
                    else if (rbFinConc.Checked)
                    {
                        if (double.TryParse(tbInitConc.Texts, out InitConc) && double.TryParse(tbInitVol.Texts, out InitVol) && double.TryParse(tbFinVol.Texts, out FinVol))
                        {
                            int numberOfZeros = initConcFactor + initVolFactor - finalConcFactor - finalVolFactor;
                            FinConc = (InitConc * InitVol) / FinVol;
                            FinConc = PutZeros(numberOfZeros, FinConc);

                            tbFinConc.Texts = FinConc.ToString("0.0000");
                        }
                    }
                    else if (rbFinVol.Checked)
                    {
                        if (double.TryParse(tbInitConc.Texts, out InitConc) && double.TryParse(tbFinConc.Texts, out FinConc) && double.TryParse(tbInitVol.Texts, out InitVol))
                        {
                            int numberOfZeros = initConcFactor + initVolFactor - finalConcFactor - finalVolFactor;
                            FinVol = (InitConc * InitVol) / FinConc;
                            FinVol = PutZeros(numberOfZeros, FinVol);

                            tbFinVol.Texts = FinVol.ToString("0.0000");
                        }
                    }
                }
                catch { }

            }

        }

        private double PutZeros(int numberOfZeros, double number)
        {
            if (numberOfZeros < 0)
            {
                for (int i = 0; i > numberOfZeros; i--)
                {
                    number /= 10;
                }
            }
            else
            {
                for (int i = 0; i < numberOfZeros; i++)
                {
                    number *= 10;
                }
            }

            return number;
        }


        public void soldiluationResetBtn_Click()
        {
            rbInitConc.Checked = false; rbFinConc.Checked = false; rbInitVol.Checked = false; rbFinVol.Checked = false;
            tbInitConc.Enabled = false; tbInitVol.Enabled = false; tbFinConc.Enabled = false; tbFinVol.Enabled = false;
            tbInitConc.Texts = string.Empty; tbInitVol.Texts = string.Empty; tbFinConc.Texts = string.Empty; tbFinVol.Texts = string.Empty;

            initConcentration.SelectedIndex = 0;
            finalConcentration.SelectedIndex = 0;
            initVolume.SelectedIndex = 0;
            finalVolume.SelectedIndex = 0;
        }
    }
}

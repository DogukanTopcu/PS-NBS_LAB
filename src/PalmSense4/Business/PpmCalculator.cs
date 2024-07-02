using RJCodeAdvance.RJControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalmSense4.Business
{
    public class PpmCalculator
    {
        // ppm Calculator Attributes
        private RadioButton radioButton_ppm;
        private RadioButton radioButton_molarmass;
        private RadioButton radioButton_molarity;
        private RJTextBox textBox_ppm;
        private RJTextBox textBox_MolarMass_ppm;
        private RJTextBox textBox_Molarity;
        private ComboBox comboBox_ppm_unit;
        private ComboBox comboBox_molarity_unit;

        private Dictionary<string, Dictionary<string, double>> _conversionFactors;

        public PpmCalculator(
            RadioButton radioButton_ppm,
            RadioButton radioButton_molarmass,
            RadioButton radioButton_molarity,
            RJTextBox textBox_ppm,
            RJTextBox textBox_MolarMass_ppm, 
            RJTextBox textBox_Molarity, 
            ComboBox comboBox_ppm_unit, 
            ComboBox comboBox_molarity_unit
        )
        {
            this.radioButton_ppm = radioButton_ppm;
            this.radioButton_molarmass = radioButton_molarmass;
            this.radioButton_molarity = radioButton_molarity;
            this.textBox_ppm = textBox_ppm;
            this.textBox_MolarMass_ppm = textBox_MolarMass_ppm;
            this.textBox_Molarity = textBox_Molarity;
            this.comboBox_ppm_unit = comboBox_ppm_unit;
            this.comboBox_molarity_unit = comboBox_molarity_unit;


            this._conversionFactors = new Dictionary<string, Dictionary<string, double>>();
            AddConversionData();
        }
        private void AddConversionData()
        {
            _conversionFactors.Add("ppb", new Dictionary<string, double> { { "M", 1000000 }, { "mM", 1000 }, { "mg/L", 1000 }, { "μM", 1 }, { "nM", 1 / 1000 } });
            _conversionFactors.Add("ppm", new Dictionary<string, double> { { "M", 1000 }, { "mM", 1 }, { "mg/L", 1 }, { "μM", 1 / 1000.0 }, { "nM", 1 / 1000000.0 } });
            _conversionFactors.Add("mg/L", new Dictionary<string, double> { { "M", 1000 }, { "ppm", 1 }, { "mM", 1 }, { "μM", 1 / 1000.0 }, { "nM", 1 / 1000000.0 } });
            _conversionFactors.Add("M", new Dictionary<string, double> { { "ppb", 1 / 1000000.0 }, { "ppm", 1 / 1000.0 }, { "mg/L", 1 } });
            _conversionFactors.Add("mM", new Dictionary<string, double> { { "ppb", 1 / 1000000.0 }, { "ppm", 1 }, { "mg/L", 1 } });
            _conversionFactors.Add("μM", new Dictionary<string, double> { { "ppm", 1 / 1000.0 }, { "ppb", 1 }, { "mg/L", 1 / 1000.0 } });
            _conversionFactors.Add("nM", new Dictionary<string, double> { { "ppm", 1 / 1000000.0 }, { "ppb", 1 / 1000.0 }, { "mg/L", 1 / 1000000.0 } });
        }


        public void radioButton_ppm_CheckedChanged()
        {
            if (radioButton_ppm.Checked)
            {
                textBox_ppm.Enabled = false;
                textBox_Molarity.Enabled = true;
                textBox_MolarMass_ppm.Enabled = true;
            }
        }

        public void radioButton_molarmass_CheckedChanged()
        {
            if (radioButton_molarmass.Checked)
            {
                textBox_ppm.Enabled = true;
                textBox_MolarMass_ppm.Enabled = false;
                textBox_Molarity.Enabled = true;
            }
        }

        public void radioButton_molarity_CheckedChanged()
        {
            if (radioButton_molarity.Checked)
            {
                textBox_ppm.Enabled = true;
                textBox_MolarMass_ppm.Enabled = true;
                textBox_Molarity.Enabled = false;
            }
        }


        public void comboBox_ppm_unit_SelectedIndexChanged()
        {
            string selectedUnit = comboBox_ppm_unit.SelectedItem.ToString();
            string ppm2 = textBox_ppm.Texts;
            string molarmass2 = textBox_MolarMass_ppm.Texts;
            string molarity2 = textBox_Molarity.Texts;

            double ppm, molarity, molarmass;

            try
            {
                ppm = double.Parse(ppm2);
                molarity = double.Parse(molarity2);
                molarmass = double.Parse(molarmass2);

                if (selectedUnit == "ppm")
                {
                    ppm = molarity * molarmass * 1000.0;
                    textBox_ppm.Texts = ppm.ToString("0.000000");

                }
                else if (selectedUnit == "mg/L")
                {
                    ppm = molarity * molarmass * 1000.0;
                    textBox_ppm.Texts = ppm.ToString("0.000000");

                }
                else if (selectedUnit == "ppb")
                {
                    ppm = molarity * molarmass * 1000000.0;
                    textBox_ppm.Texts = ppm.ToString("0.000000");

                }
            }
            catch (FormatException ex) { }
        }


        public void comboBox_molarity_unit_SelectedIndexChanged()
        {
            string selectedUnit = comboBox_molarity_unit.SelectedItem.ToString();
            string ppm2 = textBox_ppm.Texts;
            string molarmass2 = textBox_MolarMass_ppm.Texts;
            string molarity2 = textBox_Molarity.Texts;

            double ppm, molarity, molarmass;

            try
            {
                ppm = double.Parse(ppm2);
                molarity = double.Parse(molarity2);
                molarmass = double.Parse(molarmass2);

                if (selectedUnit == "M")
                {
                    molarity = ppm / molarmass / 1000.0;
                    textBox_Molarity.Texts = molarity.ToString("0.000000");
                }
                else if (selectedUnit == "mM")
                {
                    molarity = ppm / molarmass;
                    textBox_Molarity.Texts = molarity.ToString("0.000000");
                }
                else if (selectedUnit == "μM")
                {
                    molarity = ppm / molarmass * 1000.0;
                    textBox_Molarity.Texts = molarity.ToString("0.000000");
                }
                else if (selectedUnit == "nM")
                {
                    molarity = ppm / molarmass * 1000000.0;
                    textBox_Molarity.Texts = molarity.ToString("0.000000");
                }
            }
            catch (FormatException ex) { }
        }






        public void PpmCalculate()
        {
            // Get the selected units and conversion factor from the dictionary
            string selectedUnit = comboBox_ppm_unit.SelectedItem.ToString();
            string selectedUnit2 = comboBox_molarity_unit.SelectedItem.ToString();
            double conversionFactor = _conversionFactors[selectedUnit][selectedUnit2];

            try
            {
                double molarity, ppm, molarMass;
                if (radioButton_molarity.Checked)
                {
                    if (double.TryParse(textBox_MolarMass_ppm.Texts, out molarMass) && double.TryParse(textBox_ppm.Texts, out ppm))
                    {
                        molarity = ppm / molarMass / conversionFactor;
                        textBox_Molarity.Texts = molarity.ToString("0.000000");
                    }
                }
                else if (radioButton_ppm.Checked)
                {
                    if (double.TryParse(textBox_MolarMass_ppm.Texts, out molarMass) && double.TryParse(textBox_Molarity.Texts, out molarity))
                    {
                        ppm = molarity * molarMass * conversionFactor;
                        textBox_ppm.Texts = ppm.ToString("0.000000");
                    }
                }
                else if (radioButton_molarmass.Checked)
                {
                    if (double.TryParse(textBox_ppm.Texts, out ppm) && double.TryParse(textBox_Molarity.Texts, out molarity))
                    {
                        molarMass = ppm / molarity / conversionFactor;
                        textBox_MolarMass_ppm.Texts = molarMass.ToString("0.000000");
                    }
                }

            }
            catch (Exception ex) { }
        }







        public void button_reset_ppm_Click()
        {
            textBox_ppm.Enabled = false; textBox_Molarity.Enabled = false; textBox_MolarMass_ppm.Enabled = false;

            comboBox_ppm_unit.SelectedIndex = 0; comboBox_molarity_unit.SelectedIndex = 0;

            radioButton_ppm.Checked = false; radioButton_molarity.Checked = false; radioButton_molarmass.Checked = false;

            textBox_ppm.Texts = " "; textBox_Molarity.Texts = " "; textBox_MolarMass_ppm.Texts = " ";
        }
    }
}

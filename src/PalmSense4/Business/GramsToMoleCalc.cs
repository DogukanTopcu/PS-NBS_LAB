using RJCodeAdvance.RJControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalmSense4.Business
{
    public class GramsToMoleCalc
    {
        // Grams to Mole Calculator Attributes:
        private ComboBox comboBox_Chemical;
        private ComboBox comboBox_Chemical_Select;
        private RJTextBox textBox_MolarMass;
        private RJTextBox textBox_Mass;
        private RJTextBox textBox_NumberofMoles;
        private RadioButton radioButton_Mass;
        private RadioButton radioButton_NumberofMoles;
        private Button btnReset_GramsToMoleCalc;

        private InitializeData data;
        private List<Chemical_Combinations> _cc;


        public GramsToMoleCalc(
                ComboBox comboBox_Chemical,
                ComboBox comboBox_Chemical_Select,
                RJTextBox textBox_MolarMass,
                RJTextBox textBox_Mass,
                RJTextBox textBox_NumberofMoles,
                RadioButton radioButton_Mass,
                RadioButton radioButton_NumberofMoles,
                Button btnReset_GramsToMoleCalc
            )
        {
            this.comboBox_Chemical = comboBox_Chemical;
            this.comboBox_Chemical_Select = comboBox_Chemical_Select;
            this.textBox_MolarMass = textBox_MolarMass;
            this.textBox_Mass = textBox_Mass;
            this.textBox_NumberofMoles = textBox_NumberofMoles;
            this.radioButton_Mass = radioButton_Mass;
            this.radioButton_NumberofMoles = radioButton_NumberofMoles;
            this.btnReset_GramsToMoleCalc = btnReset_GramsToMoleCalc;

            // ../../
            // src/PalmSense4/
            data = new InitializeData("../../data/chemical_combinations_data.json");
            _cc = data.InitializeChemicalCombinations();
        }

        public void comboBox_Chemical_SelectedIndexChanged()
        {
            string selected_type = comboBox_Chemical.Text;
            
            comboBox_Chemical_Select.Items.Clear();
            comboBox_Chemical_Select.Text = "";
            foreach (Chemical_Combinations cc in _cc)
            {
                if (cc.Type.Equals(selected_type))
                {
                    comboBox_Chemical_Select.Items.Add(cc.Name);
                }
            }
            textBox_MolarMass.Texts = " ";
            textBox_Mass.Texts = " ";
            textBox_NumberofMoles.Texts = " ";
            textBox_MolarMass.Enabled = false;
            comboBox_Chemical_Select.Enabled = true;
        }


        public void comboBox_Chemical_Select_SelectedIndexChanged()
        {
            string selectedChemical = comboBox_Chemical_Select.SelectedItem.ToString();
            float molarMass = 0;

            Console.WriteLine(selectedChemical);
            foreach (Chemical_Combinations cc in _cc)
            {
                Console.WriteLine(cc.Name.Equals(selectedChemical));
                if (cc.Name.Equals(selectedChemical))
                {
                    molarMass = cc.MolarMass;
                    textBox_MolarMass.Texts = " ";
                    textBox_Mass.Texts = " ";
                    textBox_NumberofMoles.Texts = " ";
                    break;
                }
            }
            textBox_MolarMass.Texts = molarMass.ToString();
        }


        public void radioButton_Mass_CheckedChanged()
        {
            if (radioButton_Mass.Checked)
            {
                textBox_NumberofMoles.Texts = " ";
                textBox_Mass.Texts = " ";
                textBox_NumberofMoles.Enabled = false;
                textBox_Mass.Enabled = true;
            }
        }


        public void radioButton_NumberofMoles_CheckedChanged()
        {
            if (radioButton_NumberofMoles.Checked)
            {
                textBox_NumberofMoles.Texts = " ";
                textBox_Mass.Texts = " ";
                textBox_Mass.Enabled = false;
                textBox_NumberofMoles.Enabled = true;
            }
        }

        public void btnReset_GramsToMoleCalc_Click()
        {
            textBox_MolarMass.Texts = " ";
            textBox_Mass.Texts = " ";
            textBox_NumberofMoles.Texts = " ";
            textBox_MolarMass.Enabled = true;
            comboBox_Chemical_Select.Enabled = false;
            comboBox_Chemical_Select.Text = " ";
            comboBox_Chemical.Text = " ";

            radioButton_Mass.Checked = false;
            radioButton_NumberofMoles.Checked = false;
            textBox_Mass.Enabled = false;
            textBox_NumberofMoles.Enabled = false;
        }


        public void textBox_Mass__TextChanged()
        {
            string text = textBox_Mass.Texts;
            string filteredText = new string(text.Where(c => char.IsDigit(c) || c == '.').ToArray());

            // Ensure that there's only one decimal point in the filtered text
            int count = filteredText.Count(c => c == '.');
            if (count > 1)
            {
                int lastIndex = filteredText.LastIndexOf('.');
                filteredText = filteredText.Remove(lastIndex, 1);
            }

            textBox_Mass.Texts = filteredText;
            //textBox_Mass.SelectionStart = filteredText.Length;

            if (radioButton_Mass.Checked)
            {
                double molarMass, mass, numberofmoles;
                if (double.TryParse(textBox_MolarMass.Texts, out molarMass) && double.TryParse(textBox_Mass.Texts, out mass))
                {
                    numberofmoles = mass / molarMass;

                    textBox_NumberofMoles.Texts = numberofmoles.ToString("0.000");
                }
            }
        }



        public void textBox_NumberofMoles__TextChanged()
        {
            if (radioButton_NumberofMoles.Checked)
            {
                double molarMass, mass, numberofmoles;
                if (double.TryParse(textBox_NumberofMoles.Texts, out numberofmoles) && double.TryParse(textBox_MolarMass.Texts, out molarMass))
                {
                    mass = molarMass * numberofmoles;
                    textBox_Mass.Texts = mass.ToString("0.000");
                }

            }
        }

    }
}

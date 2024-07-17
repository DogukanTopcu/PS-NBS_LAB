using PalmSense4.Business;
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
    public partial class calculators : UserControl
    {
        // Calculators
        private GramsToMoleCalc gtmCalc;
        private PH_POH_Calculator pH_pOH;
        private PpmCalculator ppmCalc;
        private SolutionDiluationCalc solDiluationCalc;

        public calculators()
        {
            InitializeComponent();

            // Calculators
            gtmCalc = new GramsToMoleCalc(
                comboBox_Chemical,
                comboBox_Chemical_Select,
                textBox_MolarMass,
                textBox_Mass,
                textBox_NumberofMoles,
                radioButton_Mass,
                radioButton_NumberofMoles,
                btnReset_GramsToMoleCalc
            );
            pH_pOH = new PH_POH_Calculator(
                radioButton_H,
                textBox_H,
                textBox_pH,
                radioButton_OH,
                textBox_OH,
                textBox_pOH,
                pHpOHResetBtn
            );
            ppmCalc = new PpmCalculator(
                radioButton_ppm,
                radioButton_molarmass,
                radioButton_molarity,
                textBox_ppm,
                textBox_MolarMass_ppm,
                textBox_Molarity,
                comboBox_ppm_unit,
                comboBox_molarity_unit
            );
            solDiluationCalc = new SolutionDiluationCalc(
                rbInitConc,
                rbInitVol,
                rbFinConc,
                rbFinVol,
                tbInitConc,
                tbInitVol,
                tbFinConc,
                tbFinVol
            );
        }

        private void calculators_Load(object sender, EventArgs e)
        {
            comboBox_ppm_unit.Items.Add("ppm");
            comboBox_ppm_unit.Items.Add("ppb");
            comboBox_ppm_unit.Items.Add("mg/L");
            comboBox_molarity_unit.Items.Add("M");
            comboBox_molarity_unit.Items.Add("mM");
            comboBox_molarity_unit.Items.Add("μM");
            comboBox_molarity_unit.Items.Add("nM");
            comboBox_ppm_unit.SelectedIndex = 0;
            comboBox_molarity_unit.SelectedIndex = 0;
        }


        // CALCULATORS ----------------------------------------------------------------------------------


        // GRAM TO MOLE CALC
        private void comboBox_Chemical_SelectedIndexChanged(object sender, EventArgs e) => gtmCalc.comboBox_Chemical_SelectedIndexChanged();
        private void comboBox_Chemical_Select_SelectedIndexChanged(object sender, EventArgs e) => gtmCalc.comboBox_Chemical_Select_SelectedIndexChanged();
        private void radioButton_Mass_CheckedChanged(object sender, EventArgs e) => gtmCalc.radioButton_Mass_CheckedChanged();
        private void radioButton_NumberofMoles_CheckedChanged(object sender, EventArgs e) => gtmCalc.radioButton_NumberofMoles_CheckedChanged();
        private void btnReset_GramsToMoleCalc_Click(object sender, EventArgs e) => gtmCalc.btnReset_GramsToMoleCalc_Click();
        private void textBox_Mass__TextChanged(object sender, EventArgs e) => gtmCalc.textBox_Mass__TextChanged();
        private void textBox_NumberofMoles__TextChanged(object sender, EventArgs e) => gtmCalc.textBox_NumberofMoles__TextChanged();

        // pH - pOH CALCULATOR
        private void textBox_H__TextChanged(object sender, EventArgs e) => pH_pOH.textBox_H__TextChanged();
        private void radioButton_H_CheckedChanged(object sender, EventArgs e) => pH_pOH.radioButton_H_CheckedChanged();
        private void radioButton_OH_CheckedChanged(object sender, EventArgs e) => pH_pOH.radioButton_OH_CheckedChanged();
        private void textBox_OH__TextChanged(object sender, EventArgs e) => pH_pOH.textBox_OH__TextChanged();
        private void pHpOHResetBtn_Click(object sender, EventArgs e) => pH_pOH.pHpOHResetBtn_Click();

        // PPM CALCULATOR
        private void radioButton_ppm_CheckedChanged(object sender, EventArgs e) => ppmCalc.radioButton_ppm_CheckedChanged();
        private void radioButton_molarmass_CheckedChanged(object sender, EventArgs e) => ppmCalc.radioButton_molarmass_CheckedChanged();
        private void radioButton_molarity_CheckedChanged(object sender, EventArgs e) => ppmCalc.radioButton_molarity_CheckedChanged();
        private void comboBox_ppm_unit_SelectedIndexChanged(object sender, EventArgs e) => ppmCalc.comboBox_ppm_unit_SelectedIndexChanged();
        private void comboBox_molarity_unit_SelectedIndexChanged(object sender, EventArgs e) => ppmCalc.comboBox_molarity_unit_SelectedIndexChanged();
        private void textBox_ppm__TextChanged(object sender, EventArgs e) => ppmCalc.PpmCalculate();
        private void textBox_MolarMass_ppm__TextChanged(object sender, EventArgs e) => ppmCalc.PpmCalculate();
        private void textBox_Molarity__TextChanged(object sender, EventArgs e) => ppmCalc.PpmCalculate();
        private void button_reset_ppm_Click(object sender, EventArgs e) => ppmCalc.button_reset_ppm_Click();

        // SOLUTION DILUATION CALCULATOR
        private void rbInitConc_CheckedChanged(object sender, EventArgs e) => solDiluationCalc.rbInitConc_CheckedChanged();
        private void rbInitVol_CheckedChanged(object sender, EventArgs e) => solDiluationCalc.rbInitVol_CheckedChanged();
        private void rbFinConc_CheckedChanged(object sender, EventArgs e) => solDiluationCalc.rbFinConc_CheckedChanged();
        private void rbFinVol_CheckedChanged(object sender, EventArgs e) => solDiluationCalc.rbFinVol_CheckedChanged();
        private void tbInitConc__TextChanged(object sender, EventArgs e) => solDiluationCalc.SolDilCalc();
        private void tbInitVol__TextChanged(object sender, EventArgs e) => solDiluationCalc.SolDilCalc();
        private void tbFinConc__TextChanged(object sender, EventArgs e) => solDiluationCalc.SolDilCalc();
        private void tbFinVol__TextChanged(object sender, EventArgs e) => solDiluationCalc.SolDilCalc();
        private void soldiluationResetBtn_Click(object sender, EventArgs e) => solDiluationCalc.soldiluationResetBtn_Click();



        //END CALCULATORS ----------------------------------------------------------------------------------

    }
}

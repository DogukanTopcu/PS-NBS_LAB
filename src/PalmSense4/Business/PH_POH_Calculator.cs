using RJCodeAdvance.RJControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalmSense4.Business
{
    public class PH_POH_Calculator
    {
        // pH pOH Calculator Attributes:
        private RadioButton radioButton_H;
        private RJTextBox textBox_H;
        private RJTextBox textBox_pH;

        private RadioButton radioButton_OH;
        private RJTextBox textBox_OH;
        private RJTextBox textBox_pOH;

        private Button pHpOHResetBtn;

        public PH_POH_Calculator(
                RadioButton radioButton_H,
                RJTextBox textBox_H,
                RJTextBox textBox_pH,
                RadioButton radioButton_OH,
                RJTextBox textBox_OH,
                RJTextBox textBox_pOH,
                Button pHpOHResetBtn
            )
        {
            this.radioButton_H = radioButton_H;
            this.textBox_H = textBox_H;
            this.textBox_pH = textBox_pH;
            this.radioButton_OH = radioButton_OH;
            this.textBox_OH = textBox_OH;
            this.textBox_pOH = textBox_pOH;
            this.pHpOHResetBtn = pHpOHResetBtn;
        }


        public void radioButton_H_CheckedChanged()
        {
            if (radioButton_H.Checked)
            {
                textBox_H.Enabled = true;
                textBox_OH.Enabled = false;
            }
            else
            {
                textBox_OH.Enabled = true;
                textBox_H.Enabled = false;
            }
            textBox_OH.Texts = string.Empty;
            textBox_pH.Texts = string.Empty;
            textBox_pOH.Texts = string.Empty;
        }


        public void radioButton_OH_CheckedChanged()
        {
            if (radioButton_H.Checked)
            {
                textBox_H.Enabled = true;
                textBox_OH.Enabled = false;
            }
            else
            {
                textBox_OH.Enabled = true;
                textBox_H.Enabled = false;
            }

            textBox_H.Texts = string.Empty;
            textBox_pH.Texts = string.Empty;
            textBox_pOH.Texts = string.Empty;
        }


        public void textBox_H__TextChanged()
        {
            string text = textBox_H.Texts;
            string filteredText = new string(text.Where(c => char.IsDigit(c) || c == '.').ToArray());

            int count = filteredText.Count(c => c == '.');
            if (count > 1)
            {
                int lastIndex = filteredText.LastIndexOf('.');
                filteredText = filteredText.Remove(lastIndex, 1);
            }

            textBox_H.Texts = filteredText;
            //textBox_H.SelectionStart = filteredText.Length;

            double H;
            if (double.TryParse(textBox_H.Texts, out H) && H > 1)
            {
                MessageBox.Show("H+ concentration cannot be greater than 1.");
                textBox_H.Texts = string.Empty;
            }
            else
            {
                CalculateResult();
            }
        }


        public void textBox_OH__TextChanged()
        {
            string text = textBox_OH.Texts;
            string filteredText = new string(text.Where(c => char.IsDigit(c) || c == '.').ToArray());

            int count = filteredText.Count(c => c == '.');
            if (count > 1)
            {
                int lastIndex = filteredText.LastIndexOf('.');
                filteredText = filteredText.Remove(lastIndex, 1);
            }

            textBox_OH.Texts = filteredText;
            //textBox_OH.SelectionStart = filteredText.Length;

            double OH;
            if (double.TryParse(textBox_OH.Texts, out OH) && OH > 1)
            {
                MessageBox.Show("OH- concentration cannot be greater than 1.");
                textBox_OH.Texts = string.Empty;
            }
            else
            {
                CalculateResult();
            }
        }

        private void CalculateResult()
        {
            try
            {
                double H, OH, pH, pOH;
                if (textBox_H.Texts != string.Empty)
                {
                    H = double.Parse(textBox_H.Texts);
                    pH = -(Math.Log10(H));
                    textBox_pH.Texts = pH.ToString("0.000");
                    pOH = 14 - pH;
                    textBox_pOH.Texts = pOH.ToString("0.000");
                }
                else if (textBox_OH.Texts != string.Empty)
                {
                    OH = double.Parse(textBox_OH.Texts);
                    pOH = -Math.Log10(OH);
                    textBox_pOH.Texts = pOH.ToString("0.000");
                    pH = 14 - pOH;
                    textBox_pH.Texts = pH.ToString("0.000");
                }
            }
            catch
            {

            }
        }


        public void pHpOHResetBtn_Click()
        {
            radioButton_H.Checked = false;
            radioButton_OH.Checked = false;
            textBox_OH.Texts = " ";
            textBox_pOH.Texts = " ";
            textBox_H.Texts = " ";
            textBox_pH.Texts = " ";
            textBox_OH.Enabled = false;
            textBox_H.Enabled = false;
        }
    }
}

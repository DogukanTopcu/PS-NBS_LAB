using Microsoft.Win32;
using PalmSens;
using PalmSens.Devices;
using PalmSense4.data.Measurement_Settings;
using RJCodeAdvance.RJControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PalmSense4.components
{
    public partial class currentRangeSettings : UserControl
    {
        private List<RJButton> rangeBtns;
        private List<RJButton> currentBtns;

        private CyclicVoltammetry_Settings _cvSettings;
        private DifferentialPulse_Settings _dpSettings;
        private ImpedimetricMethod_Settings _isSettings;

        private int start;
        private int min;
        private int max;

        private Color baseColor;

        public currentRangeSettings()
        {
            InitializeComponent();

            _cvSettings = cvSettings._cvSettings;
            _dpSettings = dpSettings._dpSettings;
            _isSettings = isSettings._impSettings;

            baseColor = btnpA100.BackColor;

            start = 0;
            max = 0;
            min = 0;

            rangeBtns = new List<RJButton>()
            {
                btnpA100,
                
                btnnA1,
                btnnA10,
                btnnA100,
                
                btnuA1,
                btnuA10,
                btnuA100,
                
                btnmA1,
                btnmA10,
                btnmA100,
            };

            currentBtns = new List<RJButton>()
            {
                btnpA100_current,

                btnnA1_current,
                btnnA10_current,
                btnnA100_current,

                btnuA1_current,
                btnuA10_current,
                btnuA100_current,

                btnmA1_current,
                btnmA10_current,
                btnmA100_current,
            };
        }

        private void currentRangeSettings_Load(object sender, EventArgs e)
        {
            if (MainPage._selectedMethod == MainPage._methodCLV)
            {
                loadCLVCurrentRange();
            }
            else if (MainPage._selectedMethod == MainPage._methodCLV)
            {
                loadDPCurrentRange();
            }
            else if (MainPage._selectedMethod == MainPage._methodIMM)
            {
                loadISCurrentRange();
            }
        }

        public void loadCLVCurrentRange()
        {
            currentRangeBtns.Visible = true;
            string keyPath = @"SOFTWARE\PalmSense";
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
            {
                if (key != null)
                {
                    start = (int) key.GetValue("cv_StartCurrent");
                    max = (int) key.GetValue("cv_MaxCurrent");
                    min = (int) key.GetValue("cv_MinCurrent");
                }
                else
                {
                    start = _cvSettings.StartCurrent.GetPositionByCurrentRanges(_cvSettings.StartCurrent.Method.Ranging.CurrentRange.ToString());
                    max = _cvSettings.MaxCurrent.GetPositionByCurrentRanges(_cvSettings.MaxCurrent.Method.Ranging.MaximumCurrentRange.ToString());
                    min = _cvSettings.MinCurrent.GetPositionByCurrentRanges(_cvSettings.MinCurrent.Method.Ranging.MinimumCurrentRange.ToString());

                }

                btnUI(start, max, min);
            }
        }
        public void loadCLVCurrentRange(Method m)
        {
            currentRangeBtns.Visible = true;

            start = _cvSettings.StartCurrent.GetPositionByCurrentRanges(m.Ranging.CurrentRange.ToString());
            max = _cvSettings.MaxCurrent.GetPositionByCurrentRanges(m.Ranging.MaximumCurrentRange.ToString());
            min = _cvSettings.MinCurrent.GetPositionByCurrentRanges(m.Ranging.MinimumCurrentRange.ToString());

            _cvSettings.StartCurrent.Method.Ranging.CurrentRange = m.Ranging.CurrentRange;
            _cvSettings.MaxCurrent.Method.Ranging.MaximumCurrentRange = m.Ranging.MaximumCurrentRange;
            _cvSettings.MinCurrent.Method.Ranging.MinimumCurrentRange = m.Ranging.MinimumCurrentRange;

            btnUI(start, max, min);
        }



        public void loadDPCurrentRange()
        {
            currentRangeBtns.Visible = true;
            string keyPath = @"SOFTWARE\PalmSense";
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
            {
                if (key != null)
                {
                    start = (int)key.GetValue("dp_StartCurrent");
                    max = (int)key.GetValue("dp_MaxCurrent");
                    min = (int)key.GetValue("dp_MinCurrent");
                }
                else
                {
                    start = _dpSettings.StartCurrent.GetPositionByCurrentRanges(_dpSettings.StartCurrent.Method.Ranging.CurrentRange.ToString());
                    max = _dpSettings.MaxCurrent.GetPositionByCurrentRanges(_dpSettings.MaxCurrent.Method.Ranging.MaximumCurrentRange.ToString());
                    min = _dpSettings.MinCurrent.GetPositionByCurrentRanges(_dpSettings.MinCurrent.Method.Ranging.MinimumCurrentRange.ToString());
                }

                btnUI(start, max, min);
            }
        }
        public void loadDPCurrentRange(Method m)
        {
            currentRangeBtns.Visible = true;

            start = _dpSettings.StartCurrent.GetPositionByCurrentRanges(m.Ranging.CurrentRange.ToString());
            max = _dpSettings.MaxCurrent.GetPositionByCurrentRanges(m.Ranging.MaximumCurrentRange.ToString());
            min = _dpSettings.MinCurrent.GetPositionByCurrentRanges(m.Ranging.MinimumCurrentRange.ToString());

            _dpSettings.StartCurrent.Method.Ranging.CurrentRange = m.Ranging.CurrentRange;
            _dpSettings.MaxCurrent.Method.Ranging.MaximumCurrentRange = m.Ranging.MaximumCurrentRange;
            _dpSettings.MinCurrent.Method.Ranging.MinimumCurrentRange = m.Ranging.MinimumCurrentRange;

            btnUI(start, max, min);
        }



        public void loadISCurrentRange()
        {
            currentRangeBtns.Visible = false;
            string keyPath = @"SOFTWARE\PalmSense";
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
            {
                if (key != null)
                {
                    max = (int)key.GetValue("im_MaxCurrent");
                    min = (int)key.GetValue("im_MinCurrent");
                }
                else
                {
                    max = _isSettings.MaxCurrent.GetPositionByFrequency(_isSettings.MaxCurrent.Method.PretLimitMaxValue);
                    min = _isSettings.MinCurrent.GetPositionByFrequency(_isSettings.MinCurrent.Method.PretLimitMinValue);
                }

                btnUI(start, max, min);
            }
        }


        private void btnUI(int start, int max, int min)
        {
            for (int i = 0; i < rangeBtns.Count; i++)
            {
                if (i < min || i > max)
                {
                    currentBtns[i].Enabled = false;
                    rangeBtns[i].BackColor = SystemColors.GrayText;
                }
                else
                {
                    currentBtns[i].Enabled = true;
                    rangeBtns[i].BackColor = baseColor;
                }
            }

            for (int i = 0; i < currentBtns.Count; i++)
            {
                if (i == start)
                {
                    currentBtns[i].BackgroundImage = PalmSense4.Properties.Resources.downIconBlue24;
                }
                else
                {
                    currentBtns[i].BackgroundImage = PalmSense4.Properties.Resources.downIconGray24;
                }
            }
        }

        private void btnpA100_current_Click(object sender, EventArgs e) { start = 0; SaveCurrent(); btnUI(start, max, min); }

        private void btnnA1_current_Click(object sender, EventArgs e) { start = 1; SaveCurrent(); btnUI(start, max, min); }

        private void btnnA10_current_Click(object sender, EventArgs e) { start = 2; SaveCurrent(); btnUI(start, max, min); }

        private void btnnA100_current_Click(object sender, EventArgs e) { start = 3; SaveCurrent(); btnUI(start, max, min); }

        private void btnuA1_current_Click(object sender, EventArgs e) { start = 4; SaveCurrent(); btnUI(start, max, min); }

        private void btnuA10_current_Click(object sender, EventArgs e) { start = 5; SaveCurrent(); btnUI(start, max, min); }

        private void btnuA100_current_Click(object sender, EventArgs e) { start = 6; SaveCurrent(); btnUI(start, max, min); }

        private void btnmA1_current_Click(object sender, EventArgs e) { start = 7; SaveCurrent(); btnUI(start, max, min); }

        private void btnmA10_current_Click(object sender, EventArgs e) { start = 8; SaveCurrent(); btnUI(start, max, min); }

        private void btnmA100_current_Click(object sender, EventArgs e) { start = 9; SaveCurrent(); btnUI(start, max, min); }


        private void btnpA100_Click(object sender, EventArgs e)
        {
            if (min == 0)
            {
                min = 1;
            }
            else
            {
                min = 0;
            }

            SaveCurrent();
            btnUI(start, max, min);
        }

        private void btnnA1_Click(object sender, EventArgs e) => rangeSelection(1);
        private void btnnA10_Click(object sender, EventArgs e) => rangeSelection(2);
        private void btnnA100_Click(object sender, EventArgs e) => rangeSelection(3);
        private void btnuA1_Click(object sender, EventArgs e) => rangeSelection(4);
        private void btnuA10_Click(object sender, EventArgs e) => rangeSelection(5);
        private void btnuA100_Click(object sender, EventArgs e) => rangeSelection(6);
        private void btnmA1_Click(object sender, EventArgs e) => rangeSelection(7);
        private void btnmA10_Click(object sender, EventArgs e) => rangeSelection(8);
        private void btnmA100_Click(object sender, EventArgs e) => rangeSelection(9);



        private void rangeSelection(int index)
        {
            if (min < index && index < max)
            {
                if (index - min >= max - index)
                {
                    max = index;
                }
                else
                {
                    min = index;
                }
            }
            else if (min > index)
            {
                min = index;
            }
            else if (max < index)
            {
                max = index;
            }
            else if (max == index && min != max)
            {
                max -= 1;
            }
            else if (min == index && min != max)
            {
                min += 1;
            }

            if (!(start >= min && start <= max))
            {
                if (Math.Abs(start - min) > Math.Abs(start - max))
                {
                    start = max;
                }
                else
                {
                    start = min;
                }
            }

            SaveCurrent();
            btnUI(start, max, min);
        }


        private void SaveCurrent()
        {
            if (MainPage._selectedMethod == MainPage._methodCLV)
            {
                CV_SaveInternalStorage();
            }
            else if (MainPage._selectedMethod == MainPage._methodDLP)
            {
                DP_SaveInternalStorage();
            }
            else if (MainPage._selectedMethod == MainPage._methodIMM)
            {
                IS_SaveInternalStorage();
            }
        }

        private void CV_SaveInternalStorage()
        {
            _cvSettings.StartCurrent.Value = start + 1;
            _cvSettings.StartCurrent.Method.Ranging.CurrentRange = new CurrentRange(_cvSettings.StartCurrent.GetFrequency());

            _cvSettings.MaxCurrent.Value = max + 1;
            _cvSettings.MaxCurrent.Method.Ranging.MaximumCurrentRange = new CurrentRange(_cvSettings.MaxCurrent.GetFrequency());

            _cvSettings.MinCurrent.Value = min + 1;
            _cvSettings.MinCurrent.Method.Ranging.MinimumCurrentRange = new CurrentRange(_cvSettings.MinCurrent.GetFrequency());


            if (MainPage.saveInternalStorage)
            {
                string keyPath = @"SOFTWARE\PalmSense";
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
                {
                    if (key != null)
                    {
                        key.SetValue("cv_StartCurrent", start);
                        key.SetValue("cv_MaxCurrent", max);
                        key.SetValue("cv_MinCurrent", min);
                    }
                    else
                    {
                        MessageBox.Show("Error: Unable to access or create registry key.");
                    }
                }
            }
        }

        private void DP_SaveInternalStorage()
        {
            _dpSettings.StartCurrent.Value = start + 1;
            _dpSettings.StartCurrent.Method.Ranging.CurrentRange = new CurrentRange(_dpSettings.StartCurrent.GetFrequency());

            _dpSettings.MaxCurrent.Value = max + 1;
            _dpSettings.MaxCurrent.Method.Ranging.MaximumCurrentRange = new CurrentRange(_dpSettings.MaxCurrent.GetFrequency());

            _dpSettings.MinCurrent.Value = min + 1;
            _dpSettings.MinCurrent.Method.Ranging.MinimumCurrentRange = new CurrentRange(_dpSettings.MinCurrent.GetFrequency());

            if (MainPage.saveInternalStorage)
            {
                string keyPath = @"SOFTWARE\PalmSense";
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
                {
                    if (key != null)
                    {
                        key.SetValue("dp_StartCurrent", start);
                        key.SetValue("dp_MaxCurrent", max);
                        key.SetValue("dp_MinCurrent", min);
                    }
                    else
                    {
                        MessageBox.Show("Error: Unable to access or create registry key.");
                    }
                }
            }
        }

        private void IS_SaveInternalStorage()
        {
            _isSettings.MaxCurrent.Value = max + 1;
            _isSettings.MaxCurrent.Method.Ranging.MaximumCurrentRange = new CurrentRange(_isSettings.MaxCurrent.GetFrequency());

            _isSettings.MinCurrent.Value = min + 1;
            _isSettings.MinCurrent.Method.Ranging.MinimumCurrentRange = new CurrentRange(_isSettings.MinCurrent.GetFrequency());

            if (MainPage.saveInternalStorage)
            {
                string keyPath = @"SOFTWARE\PalmSense";
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
                {
                    if (key != null)
                    {
                        key.SetValue("im_StartCurrent", start);
                        key.SetValue("im_MaxCurrent", max);
                        key.SetValue("im_MinCurrent", min);
                    }
                    else
                    {
                        MessageBox.Show("Error: Unable to access or create registry key.");
                    }
                }
            }
        }
    }
}

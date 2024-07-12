using Microsoft.Win32;
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
            btnmA1.BackColor = SystemColors.GrayText;
            btnmA10.BackColor = SystemColors.GrayText;
            btnmA100.BackColor = SystemColors.GrayText;
            
            btnnA1.BackColor = SystemColors.GrayText;
            btnnA10.BackColor = SystemColors.GrayText;
            btnpA100.BackColor = SystemColors.GrayText;
        }

        public void loadCLVCurrentRange()
        {
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
                    start = _cvSettings.StartCurrent.Value;
                    max = _cvSettings.MaxCurrent.GetPositionByFrequency(_cvSettings.MaxCurrent.Method.PretLimitMaxValue);
                    min = _cvSettings.MinCurrent.GetPositionByFrequency(_cvSettings.MinCurrent.Method.PretLimitMinValue);

                }

                btnUI(start, max, min);
            }

        }
        public void loadDPCurrentRange()
        {
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
                    start = _dpSettings.StartCurrent.Value;
                    max = _dpSettings.MaxCurrent.GetPositionByFrequency(_dpSettings.MaxCurrent.Method.PretLimitMaxValue);
                    min = _dpSettings.MinCurrent.GetPositionByFrequency(_dpSettings.MinCurrent.Method.PretLimitMinValue);
                }

                btnUI(start, max, min);
            }
        }
        public void loadISCurrentRange()
        {
            string keyPath = @"SOFTWARE\PalmSense";
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
            {
                if (key != null)
                {
                    start = (int)key.GetValue("im_StartCurrent");
                    max = (int)key.GetValue("im_MaxCurrent");
                    min = (int)key.GetValue("im_MinCurrent");
                }
                else
                {
                    start = _isSettings.StartCurrent.Value;
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
                    currentBtns[i].BackColor = baseColor;
                }
                else
                {
                    currentBtns[i].BackColor = SystemColors.GrayText;
                }
            }
        }
    }
}

using Microsoft.Win32;
using PalmSens.Techniques;
using PalmSense4.data.Measurement_Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PalmSense4.components
{
    public partial class isSettings : UserControl
    {
        private int panelHeight;

        public static ImpedimetricMethod_Settings _impSettings;

        public isSettings()
        {
            InitializeComponent();

            panelHeight = 560;
            _impSettings = new ImpedimetricMethod_Settings(MainPage._methodIMM);
        }

        private void isSettings_Load(object sender, EventArgs e)
        {
            cbScanType.Items.Add(PalmSens.Techniques.Impedance.enumScanType.TimeScan);
            cbScanType.Items.Add(PalmSens.Techniques.Impedance.enumScanType.PGScan);
            cbScanType.Items.Add(PalmSens.Techniques.Impedance.enumScanType.Fixed);
            cbScanType.SelectedIndex = 0;
            eBeginPanel.Visible = false;
            eStepPanel.Visible = false;
            eEndPanel.Visible = false;

            cbFreqType.Items.Add(PalmSens.Techniques.Impedance.enumFrequencyType.Scan);
            cbFreqType.Items.Add(PalmSens.Techniques.Impedance.enumFrequencyType.Fixed);
            cbFreqType.SelectedIndex = 0;
            freqPanel.Visible = false;

            Height = panelHeight;


            setupSettings();
        }

        private void setupSettings()
        {
            string keyPath = @"SOFTWARE\PalmSense";
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
            {
                if (key != null)
                {
                    tbTEq.Texts = key.GetValue("im_EquilibrationTime").ToString();
                    tbEDc.Texts = key.GetValue("im_Potential").ToString();
                    tbEAc.Texts = key.GetValue("im_Eac").ToString();

                    try
                    {
                        cbScanType.SelectedIndex = (int)key.GetValue("im_ScanType");
                        cbFreqType.SelectedIndex = (int)key.GetValue("im_FreqType");
                    }
                    catch
                    {
                        cbScanType.SelectedIndex = (int)_impSettings.ScanType.Method.ScanType;
                        cbFreqType.SelectedIndex = (int)_impSettings.FrequencyType.Method.FreqType;
                    }

                    tbNFreq.Texts = key.GetValue("im_nFrequencies").ToString();

                    tbEBegin.Texts = key.GetValue("im_BeginPotential").ToString();
                    tbEStep.Texts = key.GetValue("im_StepPotential").ToString();
                    tbEEnd.Texts = key.GetValue("im_EndPotential").ToString();
                }
                else
                {
                    tbTEq.Texts = _impSettings.TimeEquilibrium.Method.EquilibrationTime.ToString();
                    tbEDc.Texts = _impSettings.Potential.Method.Potential.ToString();
                    tbEAc.Texts = _impSettings.EAC.Method.Eac.ToString();
                    cbScanType.SelectedIndex = (int)_impSettings.ScanType.Method.ScanType;
                    cbFreqType.SelectedIndex = (int)_impSettings.FrequencyType.Method.FreqType;
                    
                    tbMaxFreq.Texts = _impSettings.NFrequencies.Method.nFrequencies.ToString();

                    tbEBegin.Texts = _impSettings.EBegin.Method.BeginPotential.ToString();
                    tbEStep.Texts = _impSettings.EStep.Method.StepPotential.ToString();
                    tbEEnd.Texts = _impSettings.EEnd.Method.EndPotential.ToString();


                }
            }
        }

        private void isSettingsBtn_Click(object sender, EventArgs e)
        {
            isSettingsBtn.Image.RotateFlip(RotateFlipType.Rotate180FlipX);

            if (Height == isSettingsBtn.Height)
            {
                Height = panelHeight;
            }
            else
            {
                Height = isSettingsBtn.Height;
            }
        }

        private void cbScanType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbScanType.SelectedIndex)
            {
                case 0:
                    eBeginPanel.Visible = false;
                    eStepPanel.Visible = false;
                    eEndPanel.Visible = false;

                    eDcPanel.Visible = true;
                    tTurnPanel.Visible = true;
                    tIntervalPanel.Visible = true;
                    eAcPanel.Visible = true;

                    if (cbFreqType.SelectedIndex == 0)
                    {
                        Height = 560;
                    }
                    else
                    {
                        Height = 460;
                    }
                    break;
                case 1:
                    eDcPanel.Visible = false;
                    tTurnPanel.Visible = false;
                    tIntervalPanel.Visible = false;

                    eBeginPanel.Visible = true;
                    eStepPanel.Visible = true;
                    eEndPanel.Visible = true;
                    eAcPanel.Visible = true;

                    if (cbFreqType.SelectedIndex == 0)
                    {
                        Height = 560;
                    }
                    else
                    {
                        Height = 460;
                    }
                    break;
                case 2:
                    tTurnPanel.Visible = false;
                    tIntervalPanel.Visible = false;
                    eBeginPanel.Visible = false;
                    eStepPanel.Visible = false;
                    eEndPanel.Visible = false;

                    eDcPanel.Visible = true;
                    eAcPanel.Visible = true;

                    if (cbFreqType.SelectedIndex == 0)
                    {
                        Height = 460;
                    }
                    else
                    {
                        Height = 360;
                    }
                    break;
                default:
                    break;
            }
        }

        private void cbFreqType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(cbFreqType.SelectedIndex)
            {
                case 0:
                    freqPanel.Visible = false;

                    nFreqPanel.Visible = true;
                    maxFreqPanel.Visible = true;
                    minFreqPanel.Visible = true;
                    
                    tbMaxFreq.Enabled = false;
                    tbMaxFreq.Texts = "50000.0";
                    tbMinFreq.Enabled = false;
                    tbMinFreq.Texts = "5.0";

                    if (cbScanType.SelectedIndex == 0 || cbScanType.SelectedIndex == 1)
                    {
                        Height = 560;
                    }
                    else
                    {
                        Height = 460;
                    }
                    break; 
                case 1:
                    nFreqPanel.Visible = false;
                    maxFreqPanel.Visible = false;
                    minFreqPanel.Visible = false;

                    freqPanel.Visible = true;

                    if (cbScanType.SelectedIndex == 0 || cbScanType.SelectedIndex == 1)
                    {
                        Height = 460;
                    }
                    else
                    {
                        Height = 360;
                    }
                    break;
                default:
                    freqPanel.Visible = false;

                    nFreqPanel.Visible = true;
                    maxFreqPanel.Visible = true;
                    tbMaxFreq.Enabled = false;
                    tbMaxFreq.Texts = "50000.0";
                    minFreqPanel.Visible = true;
                    tbMinFreq.Enabled = false;
                    tbMinFreq.Texts = "5.0";

                    if (cbScanType.SelectedIndex == 0 || cbScanType.SelectedIndex == 1)
                    {
                        Height = 560;
                    }
                    else
                    {
                        Height = 460;
                    }
                    break;
            }
        }
    }
}

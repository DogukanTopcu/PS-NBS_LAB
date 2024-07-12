using Microsoft.Win32;
using PalmSense4.data.Measurement_Settings;
using RJCodeAdvance.RJControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PalmSense4.components
{
    public partial class dpSettings : UserControl
    {
        public static DifferentialPulse_Settings _dpSettings;
        public dpSettings()
        {
            InitializeComponent();
            _dpSettings = new DifferentialPulse_Settings(MainPage._methodDLP);
        }

        private void dpSettings_Load(object sender, EventArgs e)
        {
            string keyPath = @"SOFTWARE\PalmSense";
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
            {
                if (key != null)
                {
                    tbTEq.Texts = key.GetValue("dp_EquilibrationTime").ToString();
                    tbEBegin.Texts = key.GetValue("dp_BeginPotential").ToString();
                    tbEEnd.Texts = key.GetValue("dp_EndPotential").ToString();
                    tbEStep.Texts = key.GetValue("dp_StepPotential").ToString();
                    tbScanRate.Texts = key.GetValue("dp_Scanrate").ToString();
                    tbEPulse.Texts = key.GetValue("dp_PulsePotential").ToString();
                    tbTPulse.Texts = key.GetValue("dp_PulseTime").ToString();
                }
                else
                {
                    tbTEq.Texts = _dpSettings.TimeEquilibrium.Method.EquilibrationTime.ToString();
                    tbEBegin.Texts = _dpSettings.EBegin.Method.BeginPotential.ToString();
                    tbEEnd.Texts = _dpSettings.EEnd.Method.EndPotential.ToString();
                    tbEStep.Texts = _dpSettings.EStep.Method.StepPotential.ToString();
                    tbScanRate.Texts = _dpSettings.ScanRate.Method.Scanrate.ToString();
                    tbEPulse.Texts = _dpSettings.EPulse.Method.PulsePotential.ToString();
                    tbTPulse.Texts = _dpSettings.TPulse.Method.PulseTime.ToString();
                }
            }
        }

        private void dpSettingsBtn_Click(object sender, EventArgs e)
        {
            dpSettingsBtn.Image.RotateFlip(RotateFlipType.Rotate180FlipX);

            if (Height == dpSettingsBtn.Height)
            {
                Height = 380;
            }
            else
            {
                Height = dpSettingsBtn.Height;
            }
        }

        
    }
}

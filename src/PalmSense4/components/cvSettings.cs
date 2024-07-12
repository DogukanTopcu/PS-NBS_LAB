using Microsoft.Win32;
using PalmSense4.data.Measurement_Settings;
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
    public partial class cvSettings : UserControl
    {
        public static CyclicVoltammetry_Settings _cvSettings;
        public cvSettings()
        {
            InitializeComponent();
            _cvSettings = new CyclicVoltammetry_Settings(MainPage._methodCLV);
        }

        private void cvSettings_Load(object sender, EventArgs e)
        {
            string keyPath = @"SOFTWARE\PalmSense";
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
            {
                if (key != null)
                {
                    tbTEq.Texts = key.GetValue("cv_EquilibrationTime").ToString();
                    tbEBegin.Texts = key.GetValue("cv_BeginPotential").ToString();
                    tbEVertex1.Texts = key.GetValue("cv_Vtx1Potential").ToString();
                    tbEVertex2.Texts = key.GetValue("cv_Vtx2Potential").ToString();
                    tbEStep.Texts = key.GetValue("cv_StepPotential").ToString();
                    tbScanRate.Texts = key.GetValue("cv_Scanrate").ToString();
                    tbNumberOfScan.Texts = key.GetValue("cv_nEqScans").ToString();
                }
                else
                {

                    tbTEq.Texts = _cvSettings.TimeEquilibrium.Method.EquilibrationTime.ToString();
                    tbEBegin.Texts = _cvSettings.EBegin.Method.BeginPotential.ToString();
                    tbEVertex1.Texts = _cvSettings.EVertex1.Method.Vtx1Potential.ToString();
                    tbEVertex2.Texts = _cvSettings.EVertex2.Method.Vtx2Potential.ToString();
                    tbEStep.Texts = _cvSettings.EStep.Method.StepPotential.ToString();
                    tbScanRate.Texts = _cvSettings.ScanRate.Method.Scanrate.ToString();
                    tbNumberOfScan.Texts = _cvSettings.NumbersOfScan.Method.nEqScans.ToString();
                }
            }

        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            rjButton1.Image.RotateFlip(RotateFlipType.Rotate180FlipX);

            if (Height == rjButton1.Height)
            {
                Height = 380;
            }
            else
            {
                Height = rjButton1.Height;
            }

        }

        
    }
}

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
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PalmSense4.components
{
    public partial class pretreatmentSettings : UserControl
    {
        CyclicVoltammetry_Settings _cvSettings;
        DifferentialPulse_Settings _dpSettings;
        ImpedimetricMethod_Settings _impSettings;
        public pretreatmentSettings()
        {
            InitializeComponent();
            _cvSettings = cvSettings._cvSettings;
            _dpSettings = dpSettings._dpSettings;
            _impSettings = isSettings._impSettings;
        }

        private void pretreatmentSettings_Load(object sender, EventArgs e)
        {
            if (MainPage._selectedMethod == MainPage._methodCLV)
            {
                loadCLVPretreatmentSettings();
            }
            else if (MainPage._selectedMethod == MainPage._methodDLP)
            {
                loadDPPretreatmentSettings();
            }
            else if (MainPage._selectedMethod == MainPage._methodIMM)
            {
                loadIMMPretreatmentSettings();
            }
        }

        public void loadCLVPretreatmentSettings()
        {
            string keyPath = @"SOFTWARE\PalmSense";
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
            {
                if (key != null)
                {
                    tbECondition.Texts = key.GetValue("cv_ConditioningPotential").ToString();
                    tbTCondition.Texts = key.GetValue("cv_ConditioningTime").ToString();
                    tbEDeposition.Texts = key.GetValue("cv_DepositionPotential").ToString();
                    tbTDeposition.Texts = key.GetValue("cv_DepositionTime").ToString();
                }
                else
                {
                    tbECondition.Texts = _cvSettings.ECondition.Method.ConditioningPotential.ToString();
                    tbTCondition.Texts = _cvSettings.TCondition.Method.ConditioningTime.ToString();
                    tbEDeposition.Texts = _cvSettings.EDeposition.Method.DepositionPotential.ToString();
                    tbTDeposition.Texts = _cvSettings.TDeposition.Method.DepositionTime.ToString();
                }
            }

        }
        public void loadDPPretreatmentSettings()
        {
            string keyPath = @"SOFTWARE\PalmSense";
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
            {
                if (key != null)
                {

                    tbECondition.Texts = key.GetValue("dp_ConditioningPotential").ToString();
                    tbTCondition.Texts = key.GetValue("dp_ConditioningTime").ToString();
                    tbEDeposition.Texts = key.GetValue("dp_DepositionPotential").ToString();
                    tbTDeposition.Texts = key.GetValue("dp_DepositionTime").ToString();
                }
                else
                {

                    tbECondition.Texts = _dpSettings.ECondition.Method.ConditioningPotential.ToString();
                    tbTCondition.Texts = _dpSettings.TCondition.Method.ConditioningTime.ToString();
                    tbEDeposition.Texts = _dpSettings.EDeposition.Method.DepositionPotential.ToString();
                    tbTDeposition.Texts = _dpSettings.TDeposition.Method.DepositionTime.ToString();
                }
            }

        }
        public void loadIMMPretreatmentSettings()
        {
            string keyPath = @"SOFTWARE\PalmSense";
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
            {
                if (key != null)
                {
                    tbECondition.Texts = key.GetValue("im_ConditioningPotential").ToString();
                    tbTCondition.Texts = key.GetValue("im_ConditioningTime").ToString();
                    tbEDeposition.Texts = key.GetValue("im_DepositionPotential").ToString();
                    tbTDeposition.Texts = key.GetValue("im_DepositionTime").ToString();
                }
                else
                {
                    tbECondition.Texts = _impSettings.ECondition.Method.ConditioningPotential.ToString();
                    tbTCondition.Texts = _impSettings.TCondition.Method.ConditioningTime.ToString();
                    tbEDeposition.Texts = _impSettings.EDeposition.Method.DepositionPotential.ToString();
                    tbTDeposition.Texts = _impSettings.TDeposition.Method.DepositionTime.ToString();
                }
            }
        }

        private void pretreatment_settings_btn_Click(object sender, EventArgs e)
        {
            pretreatment_settings_btn.Image.RotateFlip(RotateFlipType.Rotate180FlipX);

            if (Height == pretreatment_settings_btn.Height)
            {
                Height = 331;
            }
            else
            {
                Height = pretreatment_settings_btn.Height;
            }
        }

        
    }
}

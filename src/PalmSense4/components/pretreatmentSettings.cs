using Microsoft.Win32;
using Org.BouncyCastle.Utilities;
using PalmSens;
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

        private float _eCondition;
        private float _tCondition;
        private float _eDeposition;
        private float _tDeposition;

        public pretreatmentSettings()
        {
            InitializeComponent();
            _cvSettings = cvSettings._cvSettings;
            _dpSettings = dpSettings._dpSettings;
            _impSettings = isSettings._impSettings;

            _eCondition = 0;
            _tCondition = 0;
            _eDeposition = 0;
            _tDeposition = 0;
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

                    if (key.ValueCount == 0)
                    {
                        key.SetValue("cv_EquilibrationTime", "a");
                        key.SetValue("cv_BeginPotential", "a");
                        key.SetValue("cv_Vtx1Potential", "a");
                        key.SetValue("cv_Vtx2Potential", "a");
                        key.SetValue("cv_StepPotential", "a");
                        key.SetValue("cv_Scanrate", "a");
                        key.SetValue("cv_nEqScans", "a");

                        key.SetValue("dp_EquilibrationTime", "a");
                        key.SetValue("dp_BeginPotential", "a");
                        key.SetValue("dp_EndPotential", "a");
                        key.SetValue("dp_StepPotential", "a");
                        key.SetValue("dp_Scanrate", "a");
                        key.SetValue("dp_PulsePotential", "a");
                        key.SetValue("dp_PulseTime", "a");

                        key.SetValue("cv_ConditioningPotential", "a");
                        key.SetValue("cv_ConditioningTime", "a");
                        key.SetValue("cv_DepositionPotential", "a");
                        key.SetValue("cv_DepositionTime", "a");

                        key.SetValue("dp_ConditioningPotential", "a");
                        key.SetValue("dp_ConditioningTime", "a");
                        key.SetValue("dp_DepositionPotential", "a");
                        key.SetValue("dp_DepositionTime", "a");

                        key.SetValue("cv_StartCurrent", "a");
                        key.SetValue("cv_MaxCurrent", "a");
                        key.SetValue("cv_MinCurrent", "a");

                        key.SetValue("dp_StartCurrent", "a");
                        key.SetValue("dp_MaxCurrent", "a");
                        key.SetValue("dp_MinCurrent", "a");
                    }

                    if (key.GetValue("cv_ConditioningPotential").ToString() != "a")
                    {
                        tbECondition.Texts = key.GetValue("cv_ConditioningPotential").ToString();    
                    }
                    else
                    {
                        tbECondition.Texts = _cvSettings.ECondition.Method.ConditioningPotential.ToString();
                    }

                    if (key.GetValue("cv_ConditioningTime").ToString() != "a")
                    {
                        tbTCondition.Texts = key.GetValue("cv_ConditioningTime").ToString();
                    }
                    else
                    {
                        tbTCondition.Texts = _cvSettings.TCondition.Method.ConditioningTime.ToString();
                    }

                    if (key.GetValue("cv_DepositionPotential").ToString() != "a")
                    {
                        tbEDeposition.Texts = key.GetValue("cv_DepositionPotential").ToString();
                    }
                    else
                    {
                        tbEDeposition.Texts = _cvSettings.EDeposition.Method.DepositionPotential.ToString();
                    }

                    if (key.GetValue("cv_DepositionTime").ToString() != "a")
                    {
                        tbTDeposition.Texts = key.GetValue("cv_DepositionTime").ToString();
                    }
                    else
                    {
                        tbTDeposition.Texts = _cvSettings.TDeposition.Method.DepositionTime.ToString();
                    }
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
        public void loadCLVPretreatmentSettings(Method m)
        {
            tbECondition.Texts = m.ConditioningPotential.ToString();
            tbTCondition.Texts = m.ConditioningTime.ToString();
            tbEDeposition.Texts = m.DepositionPotential.ToString();
            tbTDeposition.Texts = m.DepositionTime.ToString();

            _cvSettings.ECondition.Method.ConditioningPotential = m.ConditioningPotential;
            _cvSettings.TCondition.Method.ConditioningTime = m.ConditioningTime;
            _cvSettings.EDeposition.Method.DepositionPotential = m.DepositionPotential;
            _cvSettings.TDeposition.Method.DepositionTime = m.DepositionTime;
        }

        public void loadDPPretreatmentSettings()
        {
            string keyPath = @"SOFTWARE\PalmSense";
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
            {
                if (key != null)
                {
                    if (key.ValueCount == 0)
                    {
                        key.SetValue("cv_EquilibrationTime", "a");
                        key.SetValue("cv_BeginPotential", "a");
                        key.SetValue("cv_Vtx1Potential", "a");
                        key.SetValue("cv_Vtx2Potential", "a");
                        key.SetValue("cv_StepPotential", "a");
                        key.SetValue("cv_Scanrate", "a");
                        key.SetValue("cv_nEqScans", "a");

                        key.SetValue("dp_EquilibrationTime", "a");
                        key.SetValue("dp_BeginPotential", "a");
                        key.SetValue("dp_EndPotential", "a");
                        key.SetValue("dp_StepPotential", "a");
                        key.SetValue("dp_Scanrate", "a");
                        key.SetValue("dp_PulsePotential", "a");
                        key.SetValue("dp_PulseTime", "a");

                        key.SetValue("cv_ConditioningPotential", "a");
                        key.SetValue("cv_ConditioningTime", "a");
                        key.SetValue("cv_DepositionPotential", "a");
                        key.SetValue("cv_DepositionTime", "a");

                        key.SetValue("dp_ConditioningPotential", "a");
                        key.SetValue("dp_ConditioningTime", "a");
                        key.SetValue("dp_DepositionPotential", "a");
                        key.SetValue("dp_DepositionTime", "a");

                        key.SetValue("cv_StartCurrent", "a");
                        key.SetValue("cv_MaxCurrent", "a");
                        key.SetValue("cv_MinCurrent", "a");

                        key.SetValue("dp_StartCurrent", "a");
                        key.SetValue("dp_MaxCurrent", "a");
                        key.SetValue("dp_MinCurrent", "a");
                    }

                    if (key.GetValue("dp_ConditioningPotential").ToString() != "a")
                    {
                        tbECondition.Texts = key.GetValue("dp_ConditioningPotential").ToString();
                    }
                    else
                    {
                        tbECondition.Texts = _dpSettings.ECondition.Method.ConditioningPotential.ToString();
                    }

                    if (key.GetValue("dp_ConditioningTime").ToString() != "a")
                    {
                        tbTCondition.Texts = key.GetValue("dp_ConditioningTime").ToString();
                    }
                    else
                    {
                        tbTCondition.Texts = _dpSettings.TCondition.Method.ConditioningTime.ToString();
                    }

                    if (key.GetValue("dp_DepositionPotential").ToString() != "a")
                    {
                        tbEDeposition.Texts = key.GetValue("dp_DepositionPotential").ToString();
                    }
                    else
                    {
                        tbEDeposition.Texts = _dpSettings.EDeposition.Method.DepositionPotential.ToString();
                    }

                    if (key.GetValue("dp_DepositionTime").ToString() != "a")
                    {
                        tbTDeposition.Texts = key.GetValue("dp_DepositionTime").ToString();
                    }
                    else
                    {
                        tbTDeposition.Texts = _dpSettings.TDeposition.Method.DepositionTime.ToString();
                    }  
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
        public void loadDPPretreatmentSettings(Method m)
        {
            tbECondition.Texts = m.ConditioningPotential.ToString();
            tbTCondition.Texts = m.ConditioningTime.ToString();
            tbEDeposition.Texts = m.DepositionPotential.ToString();
            tbTDeposition.Texts = m.DepositionTime.ToString();

            _dpSettings.ECondition.Method.ConditioningPotential = m.ConditioningPotential;
            _dpSettings.TCondition.Method.ConditioningTime = m.ConditioningTime;
            _dpSettings.EDeposition.Method.DepositionPotential = m.DepositionPotential;
            _dpSettings.TDeposition.Method.DepositionTime = m.DepositionTime;
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



        private float CheckStringToFloat(string text)
        {
            try
            {
                return float.Parse(text);
            }
            catch (FormatException)
            {
                throw new FormatException();
            }
        }


        private void tbECondition__TextChanged(object sender, EventArgs e)
        {
            try
            {
                _eCondition = this.CheckStringToFloat(tbECondition.Texts);
            }
            catch
            {
                MessageBox.Show("Lütfen boş alan bırakmayınız.");
                return;
            }

            if (MainPage._selectedMethod == MainPage._methodCLV)
            {
                _cvSettings.ECondition.Method.ConditioningPotential = _eCondition;

                if (MainPage.saveInternalStorage)
                {
                    string keyPath = @"SOFTWARE\PalmSense";
                    using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
                    {

                        key.SetValue("cv_ConditioningPotential", _eCondition);
                    }
                }
            }
            else if (MainPage._selectedMethod == MainPage._methodDLP)
            {
                _dpSettings.ECondition.Method.ConditioningPotential = _eCondition;

                if (MainPage.saveInternalStorage)
                {
                    string keyPath = @"SOFTWARE\PalmSense";
                    using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
                    {

                        key.SetValue("dp_ConditioningPotential", _eCondition);
                    }
                }
            }
            else if (MainPage._selectedMethod == MainPage._methodIMM)
            {
                _impSettings.ECondition.Method.ConditioningPotential = _eCondition;

                if (MainPage.saveInternalStorage)
                {
                    string keyPath = @"SOFTWARE\PalmSense";
                    using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
                    {

                        key.SetValue("im_ConditioningPotential", _eCondition);
                    }
                }
            }
        }

        private void tbTCondition__TextChanged(object sender, EventArgs e)
        {
            try
            {
                _tCondition = this.CheckStringToFloat(tbTCondition.Texts);
            }
            catch
            {
                MessageBox.Show("Lütfen boş alan bırakmayınız.");
                return;
            }

            if (MainPage._selectedMethod == MainPage._methodCLV)
            {
                _cvSettings.TCondition.Method.ConditioningTime = _tCondition;

                if (MainPage.saveInternalStorage)
                {
                    string keyPath = @"SOFTWARE\PalmSense";
                    using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
                    {

                        key.SetValue("cv_ConditioningTime", _tCondition);
                    }
                }
            }
            else if (MainPage._selectedMethod == MainPage._methodDLP)
            {
                _dpSettings.TCondition.Method.ConditioningTime = _tCondition;

                if (MainPage.saveInternalStorage)
                {
                    string keyPath = @"SOFTWARE\PalmSense";
                    using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
                    {

                        key.SetValue("dp_ConditioningTime", _tCondition);
                    }
                }
            }
            else if (MainPage._selectedMethod == MainPage._methodIMM)
            {
                _impSettings.TCondition.Method.ConditioningTime = _tCondition;

                if (MainPage.saveInternalStorage)
                {
                    string keyPath = @"SOFTWARE\PalmSense";
                    using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
                    {

                        key.SetValue("im_ConditioningTime", _tCondition);
                    }
                }
            }
        }

        private void tbEDeposition__TextChanged(object sender, EventArgs e)
        {
            try
            {
                _eDeposition = this.CheckStringToFloat(tbEDeposition.Texts);
            }
            catch
            {
                MessageBox.Show("Lütfen boş alan bırakmayınız.");
                return;
            }

            if (MainPage._selectedMethod == MainPage._methodCLV)
            {
                _cvSettings.EDeposition.Method.DepositionPotential = _eDeposition;

                if (MainPage.saveInternalStorage)
                {
                    string keyPath = @"SOFTWARE\PalmSense";
                    using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
                    {

                        key.SetValue("cv_DepositionPotential", _eDeposition);
                    }
                }
            }
            else if (MainPage._selectedMethod == MainPage._methodDLP)
            {
                _dpSettings.EDeposition.Method.DepositionPotential = _eDeposition;

                if (MainPage.saveInternalStorage)
                {
                    string keyPath = @"SOFTWARE\PalmSense";
                    using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
                    {

                        key.SetValue("dp_DepositionPotential", _eDeposition);
                    }
                }
            }
            else if (MainPage._selectedMethod == MainPage._methodIMM)
            {
                _impSettings.EDeposition.Method.DepositionPotential = _eDeposition;

                if (MainPage.saveInternalStorage)
                {
                    string keyPath = @"SOFTWARE\PalmSense";
                    using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
                    {

                        key.SetValue("im_DepositionPotential", _eDeposition);
                    }
                }
            }
        }

        private void tbTDeposition__TextChanged(object sender, EventArgs e)
        {
            try
            {
                _tDeposition = this.CheckStringToFloat(tbTDeposition.Texts);
            }
            catch
            {
                MessageBox.Show("Lütfen boş alan bırakmayınız.");
                return;
            }

            if (MainPage._selectedMethod == MainPage._methodCLV)
            {
                _cvSettings.TDeposition.Method.DepositionTime = _tDeposition;

                if (MainPage.saveInternalStorage)
                {
                    string keyPath = @"SOFTWARE\PalmSense";
                    using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
                    {

                        key.SetValue("cv_DepositionTime", _tDeposition);
                    }
                }
            }
            else if (MainPage._selectedMethod == MainPage._methodDLP)
            {
                _dpSettings.TDeposition.Method.DepositionTime = _tDeposition;

                if (MainPage.saveInternalStorage)
                {
                    string keyPath = @"SOFTWARE\PalmSense";
                    using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
                    {

                        key.SetValue("dp_DepositionTime", _tDeposition);
                    }
                }
            }
            else if (MainPage._selectedMethod == MainPage._methodIMM)
            {
                _impSettings.TDeposition.Method.DepositionTime = _tDeposition;

                if (MainPage.saveInternalStorage)
                {
                    string keyPath = @"SOFTWARE\PalmSense";
                    using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
                    {

                        key.SetValue("im_DepositionTime", _tDeposition);
                    }
                }
            }

        }
    }
}

using Microsoft.Win32;
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
    public partial class dpSettings : UserControl
    {
        public static DifferentialPulse_Settings _dpSettings = new DifferentialPulse_Settings(MainPage._methodDLP);

        private float _timeEquilibration;
        private float _eBegin;
        private float _eStep;
        private float _eEnd;
        private float _ePulse;
        private float _tPulse;
        private float _scanRate;

        public dpSettings()
        {
            InitializeComponent();
            
            _timeEquilibration = 0;
            _eBegin = 0;
            _eStep = 0;
            _scanRate = 0;
            _tPulse = 0;
            _eEnd = 0;
            _ePulse = 0;
        }

        private void dpSettings_Load(object sender, EventArgs e)
        {
            string keyPath = @"SOFTWARE\PalmSense";
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
            {
                if (key != null)
                {
                    // Equilibration Time
                    try
                    {
                        tbTEq.Texts = key.GetValue("dp_EquilibrationTime").ToString();
                        _dpSettings.TimeEquilibrium.Method.EquilibrationTime = this.CheckStringToFloat(key.GetValue("dp_EquilibrationTime").ToString());
                    } catch
                    {
                        tbTEq.Texts = _dpSettings.TimeEquilibrium.Method.EquilibrationTime.ToString();
                        _dpSettings.TimeEquilibrium.Method.EquilibrationTime = this.CheckStringToFloat(_dpSettings.TimeEquilibrium.Method.EquilibrationTime.ToString());
                    }

                    // Begin Potential
                    try
                    {
                        tbEBegin.Texts = key.GetValue("dp_BeginPotential").ToString();
                        _dpSettings.EBegin.Method.BeginPotential = this.CheckStringToFloat(key.GetValue("dp_BeginPotential").ToString());
                    } catch
                    {
                        tbEBegin.Texts = _dpSettings.EBegin.Method.BeginPotential.ToString();
                        _dpSettings.EBegin.Method.BeginPotential = this.CheckStringToFloat(_dpSettings.EBegin.Method.BeginPotential.ToString());
                    }

                    // End Potential
                    try
                    {
                        tbEEnd.Texts = key.GetValue("dp_EndPotential").ToString();
                        _dpSettings.EEnd.Method.EndPotential = this.CheckStringToFloat(key.GetValue("dp_EndPotential").ToString());
                    } catch
                    {
                        tbEEnd.Texts = _dpSettings.EEnd.Method.EndPotential.ToString();
                        _dpSettings.EEnd.Method.EndPotential = this.CheckStringToFloat(_dpSettings.EEnd.Method.EndPotential.ToString());
                    }

                    // Step Potential
                    try
                    {
                        tbEStep.Texts = key.GetValue("dp_StepPotential").ToString();
                        _dpSettings.EStep.Method.StepPotential = this.CheckStringToFloat(key.GetValue("dp_StepPotential").ToString());
                    } catch
                    {
                        tbEStep.Texts = _dpSettings.EStep.Method.StepPotential.ToString();
                        _dpSettings.EStep.Method.StepPotential = this.CheckStringToFloat(_dpSettings.EStep.Method.StepPotential.ToString());
                    }

                    // Scan Rate
                    try
                    {
                        tbScanRate.Texts = key.GetValue("dp_Scanrate").ToString();
                        _dpSettings.ScanRate.Method.Scanrate = this.CheckStringToFloat(key.GetValue("dp_Scanrate").ToString());
                    } catch
                    {
                        tbScanRate.Texts = _dpSettings.ScanRate.Method.Scanrate.ToString();
                        _dpSettings.ScanRate.Method.Scanrate = this.CheckStringToFloat(_dpSettings.ScanRate.Method.Scanrate.ToString());
                    }

                    // Pulse Potential
                    try
                    {
                        tbEPulse.Texts = key.GetValue("dp_PulsePotential").ToString();
                        _dpSettings.EPulse.Method.PulsePotential = this.CheckStringToFloat(key.GetValue("dp_PulsePotential").ToString());
                    } catch
                    {
                        tbEPulse.Texts = _dpSettings.EPulse.Method.PulsePotential.ToString();
                        _dpSettings.EPulse.Method.PulsePotential = this.CheckStringToFloat(_dpSettings.EPulse.Method.PulsePotential.ToString());
                    }

                    // Pulse Time
                    try
                    {
                        tbTPulse.Texts = key.GetValue("dp_PulseTime").ToString();
                        _dpSettings.TPulse.Method.PulseTime = this.CheckStringToFloat(key.GetValue("dp_PulseTime").ToString());
                    } catch
                    {
                        tbTPulse.Texts = _dpSettings.TPulse.Method.PulseTime.ToString();
                        _dpSettings.TPulse.Method.PulseTime = this.CheckStringToFloat(_dpSettings.TPulse.Method.PulseTime.ToString());
                    }
                }
                else
                {
                    tbTEq.Texts = _dpSettings.TimeEquilibrium.Method.EquilibrationTime.ToString();
                    _dpSettings.TimeEquilibrium.Method.EquilibrationTime = this.CheckStringToFloat(_dpSettings.TimeEquilibrium.Method.EquilibrationTime.ToString());

                    tbEBegin.Texts = _dpSettings.EBegin.Method.BeginPotential.ToString();
                    _dpSettings.EBegin.Method.BeginPotential = this.CheckStringToFloat(_dpSettings.EBegin.Method.BeginPotential.ToString());

                    tbEEnd.Texts = _dpSettings.EEnd.Method.EndPotential.ToString();
                    _dpSettings.EEnd.Method.EndPotential = this.CheckStringToFloat(_dpSettings.EEnd.Method.EndPotential.ToString());

                    tbEStep.Texts = _dpSettings.EStep.Method.StepPotential.ToString();
                    _dpSettings.EStep.Method.StepPotential = this.CheckStringToFloat(_dpSettings.EStep.Method.StepPotential.ToString());
                    
                    tbScanRate.Texts = _dpSettings.ScanRate.Method.Scanrate.ToString();
                    _dpSettings.ScanRate.Method.Scanrate = this.CheckStringToFloat(_dpSettings.ScanRate.Method.Scanrate.ToString());

                    tbEPulse.Texts = _dpSettings.EPulse.Method.PulsePotential.ToString();
                    _dpSettings.EPulse.Method.PulsePotential = this.CheckStringToFloat(_dpSettings.EPulse.Method.PulsePotential.ToString());

                    tbTPulse.Texts = _dpSettings.TPulse.Method.PulseTime.ToString();
                    _dpSettings.TPulse.Method.PulseTime = this.CheckStringToFloat(_dpSettings.TPulse.Method.PulseTime.ToString());
                }
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



        private void tbTEq__TextChanged(object sender, EventArgs e)
        {
            try
            {
                _timeEquilibration = this.CheckStringToFloat(tbTEq.Texts);
            }
            catch
            {
                MessageBox.Show("Lütfen boş alan bırakmayınız.");
                return;
            }

            _dpSettings.TimeEquilibrium.Method.EquilibrationTime = _timeEquilibration;
            if (MainPage.saveInternalStorage)
            {
                string keyPath = @"SOFTWARE\PalmSense";
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
                {
                    key.SetValue("dp_EquilibrationTime", _timeEquilibration);
                }
            }
        }

        private void tbEBegin__TextChanged(object sender, EventArgs e)
        {
            try
            {
                _eBegin = this.CheckStringToFloat(tbEBegin.Texts);
            }
            catch
            {
                MessageBox.Show("Lütfen boş alan bırakmayınız.");
                return;
            }

            _dpSettings.EBegin.Method.BeginPotential = _eBegin;
            if (MainPage.saveInternalStorage)
            {
                string keyPath = @"SOFTWARE\PalmSense";
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
                {
                    key.SetValue("dp_BeginPotential", _eBegin);
                }
            }
        }

        private void tbEEnd__TextChanged(object sender, EventArgs e)
        {
            try
            {
                _eEnd = this.CheckStringToFloat(tbEEnd.Texts);
            }
            catch
            {
                MessageBox.Show("Lütfen boş alan bırakmayınız.");
                return;
            }

            _dpSettings.EEnd.Method.EndPotential = _eEnd;
            if (MainPage.saveInternalStorage)
            {
                string keyPath = @"SOFTWARE\PalmSense";
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
                {
                    key.SetValue("dp_EndPotential", _eEnd);
                }
            }
        }

        private void tbEStep__TextChanged(object sender, EventArgs e)
        {
            try
            {
                _eStep = this.CheckStringToFloat(tbEStep.Texts);
            }
            catch
            {
                MessageBox.Show("Lütfen boş alan bırakmayınız.");
                return;
            }

            _dpSettings.EStep.Method.StepPotential = _eStep;
            if (MainPage.saveInternalStorage)
            {
                string keyPath = @"SOFTWARE\PalmSense";
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
                {
                    key.SetValue("dp_StepPotential", _eStep);
                }
            }
        }

        private void tbEPulse__TextChanged(object sender, EventArgs e)
        {
            try
            {
                _ePulse = this.CheckStringToFloat(tbEPulse.Texts);
            }
            catch
            {
                MessageBox.Show("Lütfen boş alan bırakmayınız.");
                return;
            }

            _dpSettings.EPulse.Method.PulsePotential = _ePulse;
            if (MainPage.saveInternalStorage)
            {
                string keyPath = @"SOFTWARE\PalmSense";
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
                {
                    key.SetValue("dp_PulsePotential", _ePulse);
                }
            }
        }

        private void tbTPulse__TextChanged(object sender, EventArgs e)
        {
            try
            {
                _tPulse = this.CheckStringToFloat(tbTPulse.Texts);
            }
            catch
            {
                MessageBox.Show("Lütfen boş alan bırakmayınız.");
                return;
            }

            _dpSettings.TPulse.Method.PulseTime = _tPulse;
            if (MainPage.saveInternalStorage)
            {
                string keyPath = @"SOFTWARE\PalmSense";
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
                {
                    key.SetValue("dp_PulseTime", _tPulse);
                }
            }
        }

        private void tbScanRate__TextChanged(object sender, EventArgs e)
        {
            try
            {
                _scanRate = this.CheckStringToFloat(tbScanRate.Texts);
            }
            catch
            {
                MessageBox.Show("Lütfen boş alan bırakmayınız.");
                return;
            }

            _dpSettings.ScanRate.Method.Scanrate = _scanRate;
            if (MainPage.saveInternalStorage)
            {
                string keyPath = @"SOFTWARE\PalmSense";
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
                {
                    key.SetValue("dp_Scanrate", _scanRate);
                }
            }
        }

    }
}

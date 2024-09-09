using Microsoft.Win32;
using PalmSens.Techniques;
using PalmSens.Techniques.Impedance;
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

        public static ImpedimetricMethod_Settings _impSettings = new ImpedimetricMethod_Settings(MainPage._methodIMM);


        private float _timeEquilibration;
        private float _eac;
        private float _edc;
        private float _tRun;
        private float _tInterval;
        private float _maxFrequency;
        private float _minFrequency;
        private int _nFreqs;
        private float _freq;
        private float _eBegin;
        private float _eEnd;
        private float _eStep;

        public isSettings()
        {
            InitializeComponent();

            panelHeight = 560;

            _timeEquilibration = 0;
            _eac = 0;
            _edc = 0;
            _tRun = 0;
            _tInterval = 0;
            _maxFrequency = 0;
            _minFrequency = 0;
            _nFreqs = 0;
            _freq = 0;
            _eBegin = 0;
            _eEnd = 0;
            _eStep = 0;
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

                    key.SetValue("im_FixedFrequency", "a");

                    // Fixed Frequency
                    if (key.GetValue("im_FixedFrequency").ToString() != "a")
                    {
                        tbFreq.Texts = key.GetValue("im_FixedFrequency").ToString();
                        _impSettings.Frequency.Method.FixedFrequency = this.CheckStringToFloat(key.GetValue("im_FixedFrequency").ToString());
                    }
                    else
                    {
                        tbFreq.Texts = _impSettings.Frequency.Method.FixedFrequency.ToString();
                        _impSettings.Frequency.Method.FixedFrequency = this.CheckStringToFloat(_impSettings.Frequency.Method.FixedFrequency.ToString());
                    }


                    
                    
                }
                else
                {
                    tbTEq.Texts = _impSettings.TimeEquilibrium.Method.EquilibrationTime.ToString();
                    _impSettings.TimeEquilibrium.Method.EquilibrationTime = this.CheckStringToFloat(_impSettings.TimeEquilibrium.Method.EquilibrationTime.ToString());

                    tbEDc.Texts = _impSettings.Potential.Method.Potential.ToString();
                    _impSettings.Potential.Method.Potential = this.CheckStringToFloat(_impSettings.Potential.Method.Potential.ToString());

                    tbEAc.Texts = _impSettings.EAC.Method.Eac.ToString();
                    _impSettings.EAC.Method.Eac = this.CheckStringToFloat(_impSettings.EAC.Method.Eac.ToString());

                    cbScanType.SelectedIndex = (int)_impSettings.ScanType.Method.ScanType;
                    _impSettings.ScanType.Method.ScanType = this.GetScanType((int)_impSettings.ScanType.Method.ScanType);

                    cbFreqType.SelectedIndex = (int)_impSettings.FrequencyType.Method.FreqType;
                    _impSettings.FrequencyType.Method.FreqType = this.GetFrequencyType((int)_impSettings.FrequencyType.Method.FreqType);

                    tbNFreq.Texts = _impSettings.NFrequencies.Method.nFrequencies.ToString();
                    _impSettings.NFrequencies.Method.nFrequencies = this.CheckStringToInt(_impSettings.NFrequencies.Method.nFrequencies.ToString());

                    tbMaxFreq.Texts = _impSettings.MaxFrequency.Method.MaxFrequency.ToString();
                    _impSettings.MaxFrequency.Method.MaxFrequency = this.CheckStringToFloat(_impSettings.MaxFrequency.Method.MaxFrequency.ToString());

                    tbMinFreq.Texts = _impSettings.MinFrequency.Method.MinFrequency.ToString();
                    _impSettings.MinFrequency.Method.MinFrequency = this.CheckStringToFloat(_impSettings.MinFrequency.Method.MinFrequency.ToString());

                    tbFreq.Texts = _impSettings.Frequency.Method.FixedFrequency.ToString();
                    _impSettings.Frequency.Method.FixedFrequency = this.CheckStringToFloat(_impSettings.Frequency.Method.FixedFrequency.ToString());

                    tbTRun.Texts = _impSettings.TRun.Method.RunTime.ToString();
                    _impSettings.TRun.Method.RunTime = this.CheckStringToFloat(_impSettings.TRun.Method.RunTime.ToString());

                    tbTInterval.Texts = _impSettings.TInterval.Method.IntervalTime.ToString();
                    _impSettings.TInterval.Method.IntervalTime = this.CheckStringToFloat(_impSettings.TInterval.Method.IntervalTime.ToString());

                    tbEBegin.Texts = _impSettings.EBegin.Method.BeginPotential.ToString();
                    _impSettings.EBegin.Method.BeginPotential = this.CheckStringToFloat(_impSettings.EBegin.Method.BeginPotential.ToString());

                    tbEStep.Texts = _impSettings.EStep.Method.StepPotential.ToString();
                    _impSettings.EStep.Method.StepPotential = this.CheckStringToFloat(_impSettings.EStep.Method.StepPotential.ToString());

                    tbEEnd.Texts = _impSettings.EEnd.Method.EndPotential.ToString();
                    _impSettings.EEnd.Method.EndPotential = this.CheckStringToFloat(_impSettings.EEnd.Method.EndPotential.ToString());
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
                    _impSettings.ScanType.Method.ScanType = enumScanType.TimeScan;
                    if (MainPage.saveInternalStorage)
                    {
                        string keyPath = @"SOFTWARE\PalmSense";
                        using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
                        {
                            key.SetValue("im_ScanType", 0);
                        }
                    }

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
                    _impSettings.ScanType.Method.ScanType = enumScanType.PGScan;
                    if (MainPage.saveInternalStorage)
                    {
                        string keyPath = @"SOFTWARE\PalmSense";
                        using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
                        {
                            key.SetValue("im_ScanType", 1);
                        }
                    }

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
                    _impSettings.ScanType.Method.ScanType = enumScanType.Fixed;
                    if (MainPage.saveInternalStorage)
                    {
                        string keyPath = @"SOFTWARE\PalmSense";
                        using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
                        {
                            key.SetValue("im_ScanType", 2);
                        }
                    }

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
                    _impSettings.FrequencyType.Method.FreqType = enumFrequencyType.Scan;
                    if (MainPage.saveInternalStorage)
                    {
                        string keyPath = @"SOFTWARE\PalmSense";
                        using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
                        {
                            key.SetValue("im_FreqType", 0);
                        }
                    }

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
                    _impSettings.FrequencyType.Method.FreqType = enumFrequencyType.Fixed;
                    if (MainPage.saveInternalStorage)
                    {
                        string keyPath = @"SOFTWARE\PalmSense";
                        using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
                        {
                            key.SetValue("im_FreqType", 1);
                        }
                    }

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
        private int CheckStringToInt(string text)
        {
            try
            {
                return int.Parse(text);
            }
            catch (FormatException)
            {
                throw new FormatException();
            }
        }
        private enumScanType GetScanType(int selection)
        {
            if (selection == 0)
            {
                return enumScanType.PGScan;
            }
            else if (selection == 1)
            {
                return enumScanType.TimeScan;
            }
            else
            {
                return enumScanType.Fixed;
            }
        }
        private enumFrequencyType GetFrequencyType(int selection)
        {
            if (selection == 0)
            {
                return enumFrequencyType.Scan;
            }
            else
            {
                return enumFrequencyType.Fixed;
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

            _impSettings.TimeEquilibrium.Method.EquilibrationTime = _timeEquilibration;

            if (MainPage.saveInternalStorage)
            {
                string keyPath = @"SOFTWARE\PalmSense";
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
                {
                    key.SetValue("im_EquilibrationTime", _timeEquilibration);
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

            _impSettings.EBegin.Method.BeginPotential = _eBegin;

            if (MainPage.saveInternalStorage)
            {
                string keyPath = @"SOFTWARE\PalmSense";
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
                {
                    key.SetValue("im_BeginPotential", _eBegin);
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

            _impSettings.EStep.Method.StepPotential = _eStep;

            if (MainPage.saveInternalStorage)
            {
                string keyPath = @"SOFTWARE\PalmSense";
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
                {
                    key.SetValue("im_StepPotential", _eStep);
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

            _impSettings.EEnd.Method.EndPotential = _eEnd;

            if (MainPage.saveInternalStorage)
            {
                string keyPath = @"SOFTWARE\PalmSense";
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
                {
                    key.SetValue("im_EndPotential", _eEnd);
                }
            }
        }

        private void tbEDc__TextChanged(object sender, EventArgs e)
        {
            try
            {
                _edc = this.CheckStringToFloat(tbEDc.Texts);
            }
            catch
            {
                MessageBox.Show("Lütfen boş alan bırakmayınız.");
                return;
            }

            _impSettings.Potential.Method.Potential = _edc;

            if (MainPage.saveInternalStorage)
            {
                string keyPath = @"SOFTWARE\PalmSense";
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
                {
                    key.SetValue("im_Potential", _edc);
                }
            }
        }

        private void tbTRun__TextChanged(object sender, EventArgs e)
        {
            try
            {
                _tRun = this.CheckStringToFloat(tbTRun.Texts);
            }
            catch
            {
                MessageBox.Show("Lütfen boş alan bırakmayınız.");
                return;
            }

            _impSettings.TRun.Method.RunTime = _tRun;

            if (MainPage.saveInternalStorage)
            {
                string keyPath = @"SOFTWARE\PalmSense";
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
                {
                    key.SetValue("im_RunTime", _tRun);
                }
            }
        }

        private void tbTInterval__TextChanged(object sender, EventArgs e)
        {
            try
            {
                _tInterval = this.CheckStringToFloat(tbTInterval.Texts);
            }
            catch
            {
                MessageBox.Show("Lütfen boş alan bırakmayınız.");
                return;
            }

            _impSettings.TInterval.Method.IntervalTime = _tInterval;

            if (MainPage.saveInternalStorage)
            {
                string keyPath = @"SOFTWARE\PalmSense";
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
                {
                    key.SetValue("im_IntervalTime", _tInterval);
                }
            }
        }

        private void tbEAc__TextChanged(object sender, EventArgs e)
        {
            try
            {
                _eac = this.CheckStringToFloat(tbEAc.Texts);
            }
            catch
            {
                MessageBox.Show("Lütfen boş alan bırakmayınız.");
                return;
            }

            _impSettings.EAC.Method.Eac = _eac;

            if (MainPage.saveInternalStorage)
            {
                string keyPath = @"SOFTWARE\PalmSense";
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
                {
                    key.SetValue("im_Eac", _eac);
                }
            }
        }

        private void tbFreq__TextChanged(object sender, EventArgs e)
        {
            try
            {
                _freq = this.CheckStringToFloat(tbFreq.Texts);
            }
            catch
            {
                MessageBox.Show("Lütfen boş alan bırakmayınız.");
                return;
            }

            _impSettings.Frequency.Method.FixedFrequency = _freq;

            if (MainPage.saveInternalStorage)
            {
                string keyPath = @"SOFTWARE\PalmSense";
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
                {
                    key.SetValue("im_FixedFrequency", _freq);
                }
            }
        }

        private void tbNFreq__TextChanged(object sender, EventArgs e)
        {
            try
            {
                _nFreqs = this.CheckStringToInt(tbNFreq.Texts);
            }
            catch
            {
                MessageBox.Show("Lütfen boş alan bırakmayınız.");
                return;
            }

            _impSettings.NFrequencies.Method.nFrequencies = _nFreqs;

            if (MainPage.saveInternalStorage)
            {
                string keyPath = @"SOFTWARE\PalmSense";
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
                {
                    key.SetValue("im_nFrequencies", _nFreqs);
                }
            }
        }

        private void tbMaxFreq__TextChanged(object sender, EventArgs e)
        {
            try
            {
                _maxFrequency = this.CheckStringToFloat(tbMaxFreq.Texts);
            }
            catch
            {
                MessageBox.Show("Lütfen boş alan bırakmayınız.");
                return;
            }

            _impSettings.MaxFrequency.Method.MaxFrequency = _maxFrequency;

            if (MainPage.saveInternalStorage)
            {
                string keyPath = @"SOFTWARE\PalmSense";
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
                {
                    key.SetValue("im_MaxFrequency", _maxFrequency);
                }
            }
        }

        private void tbMinFreq__TextChanged(object sender, EventArgs e)
        {
            try
            {
                _minFrequency = this.CheckStringToFloat(tbMinFreq.Texts);
            }
            catch
            {
                MessageBox.Show("Lütfen boş alan bırakmayınız.");
                return;
            }

            _impSettings.MinFrequency.Method.MinFrequency = _minFrequency;

            if (MainPage.saveInternalStorage)
            {
                string keyPath = @"SOFTWARE\PalmSense";
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
                {
                    key.SetValue("im_MinFrequency", _minFrequency);
                }
            }
        }

        
    }
}

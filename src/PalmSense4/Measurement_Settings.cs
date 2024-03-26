using Newtonsoft.Json.Linq;
using PalmSens;
using PalmSens.Techniques;
using PalmSens.Techniques.Impedance;
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

using Microsoft.Win32;

namespace PalmSense4
{
    public partial class Measurement_Settings : Form
    {
        // Data of Measurement Settings
        private string title;
        private Method selected_method;

        private CyclicVoltammetry_Settings _cvSettings;
        private DifferentialPulse_Settings _dpSettings;
        private ImpedimetricMethod_Settings _impSettings;


        public Measurement_Settings(CyclicVoltammetry_Settings cvSettings, DifferentialPulse_Settings differentialPulse_Settings, ImpedimetricMethod_Settings impedimetricMethod_Settings)
        {
            InitializeComponent();

            _cvSettings = cvSettings;
            _dpSettings = differentialPulse_Settings;
            _impSettings = impedimetricMethod_Settings;
        }

        private void Measurement_Settings_Load(object sender, EventArgs e)
        {
            this.Text = this.title;

            switch (selected_method.GetType().Name)
            {
                case "CyclicVoltammetry":
                    Setup_CV_Settings();
                    break;
                case "DifferentialPulse":
                    Setup_DP_Settings();
                    break;
                case "ImpedimetricMethod":
                    Setup_IM_Setup();
                    break;
                default:
                    MessageBox.Show("There is an error occurred");
                    this.Close();
                    break;
            }
        }

        private void Setup_CV_Settings()
        {
            textBox4.Visible = true;
            textBox5.Visible = true;

            textBox8.Visible = false;
            setting_8.Visible = false;
            cbScanType.Visible = false;
            cbFreqType.Visible = false;
            
            tbEbegin.Visible = false;
            tbEend.Visible = false;
            tbEstep.Visible = false;
            lbEbegin.Visible = false;
            lbEend.Visible = false;
            lbEstep.Visible = false;



            setting_1.Text = _cvSettings.TimeEquilibrium.Name;
            setting_2.Text = _cvSettings.EBegin.Name;
            setting_3.Text = _cvSettings.EVertex1.Name;
            setting_4.Text = _cvSettings.EVertex2.Name;
            setting_5.Text = _cvSettings.EStep.Name;
            setting_6.Text = _cvSettings.ScanRate.Name;
            setting_7.Text = _cvSettings.NumbersOfScan.Name;

            string keyPath = @"SOFTWARE\PalmSense";
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
            {
                if (key != null)
                {

                    textBox1.Text = key.GetValue("cv_EquilibrationTime").ToString();
                    textBox2.Text = key.GetValue("cv_BeginPotential").ToString();
                    textBox3.Text = key.GetValue("cv_Vtx1Potential").ToString();
                    textBox4.Text = key.GetValue("cv_Vtx2Potential").ToString();
                    textBox5.Text = key.GetValue("cv_StepPotential").ToString();
                    textBox6.Text = key.GetValue("cv_Scanrate").ToString();
                    textBox7.Text = key.GetValue("cv_nEqScans").ToString();

                    TbECondition.Text = key.GetValue("cv_ConditioningPotential").ToString();
                    TbTCondition.Text = key.GetValue("cv_ConditioningTime").ToString();
                    TbEDeposition.Text = key.GetValue("cv_DepositionPotential").ToString();
                    TbTDeposition.Text = key.GetValue("cv_DepositionTime").ToString();

                    tBStartCurrent.Value = (int) key.GetValue("cv_StartCurrent");
                    tbMaxCurrent.Value = (int) key.GetValue("cv_MaxCurrent");
                    tBMinCurrent.Value = (int) key.GetValue("cv_MinCurrent");

                    lbStartCurrentRange.Text = key.GetValue("cv_StartCurrentValue").ToString();
                    lbMaxCurrentRange.Text = key.GetValue("cv_MaxCurrentValue").ToString();
                    lbMinCurrentRange.Text = key.GetValue("cv_MinCurrentValue").ToString();
                }
                else
                {

                    textBox1.Text = _cvSettings.TimeEquilibrium.Method.EquilibrationTime.ToString();
                    textBox2.Text = _cvSettings.EBegin.Method.BeginPotential.ToString();
                    textBox3.Text = _cvSettings.EVertex1.Method.Vtx1Potential.ToString();
                    textBox4.Text = _cvSettings.EVertex2.Method.Vtx2Potential.ToString();
                    textBox5.Text = _cvSettings.EStep.Method.StepPotential.ToString();
                    textBox6.Text = _cvSettings.ScanRate.Method.Scanrate.ToString();
                    textBox7.Text = _cvSettings.NumbersOfScan.Method.nEqScans.ToString();

                    TbECondition.Text = _cvSettings.ECondition.Method.ConditioningPotential.ToString();
                    TbTCondition.Text = _cvSettings.TCondition.Method.ConditioningTime.ToString();
                    TbEDeposition.Text = _cvSettings.EDeposition.Method.DepositionPotential.ToString();
                    TbTDeposition.Text = _cvSettings.TDeposition.Method.DepositionTime.ToString();

                    tBStartCurrent.Value = _cvSettings.StartCurrent.Value;
                    tbMaxCurrent.Value = _cvSettings.MaxCurrent.GetPositionByFrequency(_cvSettings.MaxCurrent.Method.PretLimitMaxValue);
                    tBMinCurrent.Value = _cvSettings.MinCurrent.GetPositionByFrequency(_cvSettings.MinCurrent.Method.PretLimitMinValue);

                    lbStartCurrentRange.Text = _cvSettings.StartCurrent.GetFrequencyValue(tBStartCurrent.Value);
                    lbMaxCurrentRange.Text = _cvSettings.MaxCurrent.GetFrequencyValue(tbMaxCurrent.Value);
                    lbMinCurrentRange.Text = _cvSettings.MinCurrent.GetFrequencyValue(tBMinCurrent.Value);
                }
            }

        }
        private void Setup_DP_Settings()
        {
            textBox4.Visible = true;
            textBox5.Visible = true;

            textBox8.Visible = false;
            setting_8.Visible = false;
            cbScanType.Visible = false;
            cbFreqType.Visible = false;

            tbEbegin.Visible = false;
            tbEend.Visible = false;
            tbEstep.Visible = false;
            lbEbegin.Visible = false;
            lbEend.Visible = false;
            lbEstep.Visible = false;

            setting_1.Text = _dpSettings.TimeEquilibrium.Name;
            setting_2.Text = _dpSettings.EBegin.Name;
            setting_3.Text = _dpSettings.EEnd.Name;
            setting_4.Text = _dpSettings.EStep.Name;
            setting_5.Text = _dpSettings.ScanRate.Name;
            setting_6.Text = _dpSettings.EPulse.Name;
            setting_7.Text = _dpSettings.TPulse.Name;


            string keyPath = @"SOFTWARE\PalmSense";
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
            {
                if (key != null)
                {
                    textBox1.Text = key.GetValue("dp_EquilibrationTime").ToString();
                    textBox2.Text = key.GetValue("dp_BeginPotential").ToString();
                    textBox3.Text = key.GetValue("dp_EndPotential").ToString();
                    textBox4.Text = key.GetValue("dp_StepPotential").ToString();
                    textBox5.Text = key.GetValue("dp_Scanrate").ToString();
                    textBox6.Text = key.GetValue("dp_PulsePotential").ToString();
                    textBox7.Text = key.GetValue("dp_PulseTime").ToString();

                    TbECondition.Text = key.GetValue("dp_ConditioningPotential").ToString();
                    TbTCondition.Text = key.GetValue("dp_ConditioningTime").ToString();
                    TbEDeposition.Text = key.GetValue("dp_DepositionPotential").ToString();
                    TbTDeposition.Text = key.GetValue("dp_DepositionTime").ToString();

                    tBStartCurrent.Value = (int)key.GetValue("dp_StartCurrent");
                    tbMaxCurrent.Value = (int)key.GetValue("dp_MaxCurrent");
                    tBMinCurrent.Value = (int)key.GetValue("dp_MinCurrent");

                    lbStartCurrentRange.Text = key.GetValue("dp_StartCurrentValue").ToString();
                    lbMaxCurrentRange.Text = key.GetValue("dp_MaxCurrentValue").ToString();
                    lbMinCurrentRange.Text = key.GetValue("dp_MinCurrentValue").ToString();
                }
                else
                {
                    textBox1.Text = _dpSettings.TimeEquilibrium.Method.EquilibrationTime.ToString();
                    textBox2.Text = _dpSettings.EBegin.Method.BeginPotential.ToString();
                    textBox3.Text = _dpSettings.EEnd.Method.EndPotential.ToString();
                    textBox4.Text = _dpSettings.EStep.Method.StepPotential.ToString();
                    textBox5.Text = _dpSettings.ScanRate.Method.Scanrate.ToString();
                    textBox6.Text = _dpSettings.EPulse.Method.PulsePotential.ToString();
                    textBox7.Text = _dpSettings.TPulse.Method.PulseTime.ToString();

                    TbECondition.Text = _dpSettings.ECondition.Method.ConditioningPotential.ToString();
                    TbTCondition.Text = _dpSettings.TCondition.Method.ConditioningTime.ToString();
                    TbEDeposition.Text = _dpSettings.EDeposition.Method.DepositionPotential.ToString();
                    TbTDeposition.Text = _dpSettings.TDeposition.Method.DepositionTime.ToString();

                    tBStartCurrent.Value = _dpSettings.StartCurrent.Value;
                    tbMaxCurrent.Value = _dpSettings.MaxCurrent.GetPositionByFrequency(_dpSettings.MaxCurrent.Method.PretLimitMaxValue);
                    tBMinCurrent.Value = _dpSettings.MinCurrent.GetPositionByFrequency(_dpSettings.MinCurrent.Method.PretLimitMinValue);


                    lbStartCurrentRange.Text = _dpSettings.StartCurrent.GetFrequencyValue(tBStartCurrent.Value);
                    lbMaxCurrentRange.Text = _dpSettings.MaxCurrent.GetFrequencyValue(tbMaxCurrent.Value);
                    lbMinCurrentRange.Text = _dpSettings.MinCurrent.GetFrequencyValue(tBMinCurrent.Value);
                }
            }

            
        }
        private void Setup_IM_Setup()
        {
            textBox8.Visible = true;
            setting_8.Visible = true;
            cbScanType.Visible = true;
            cbFreqType.Visible = true;
            tbEbegin.Visible = true;
            tbEend.Visible = true;
            tbEstep.Visible = true;
            lbEbegin.Visible = true;
            lbEend.Visible = true;
            lbEstep.Visible = true;

            textBox4.Visible = false;
            textBox5.Visible = false;
            cbScanType.Location = textBox4.Location;
            cbFreqType.Location = textBox5.Location;

            setting_1.Text = _impSettings.TimeEquilibrium.Name;
            setting_2.Text = _impSettings.Potential.Name;
            setting_3.Text = _impSettings.EAC.Name;
            setting_4.Text = _impSettings.ScanType.Name;
            setting_5.Text = _impSettings.FrequencyType.Name;
            setting_6.Text = _impSettings.MaxFrequency.Name;
            setting_7.Text = _impSettings.MinFrequency.Name;
            setting_8.Text = _impSettings.NFrequencies.Name;


            string keyPath = @"SOFTWARE\PalmSense";
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
            {
                if (key != null)
                {
                    textBox1.Text = key.GetValue("im_EquilibrationTime").ToString();
                    textBox2.Text = key.GetValue("im_Potential").ToString();
                    textBox3.Text = key.GetValue("im_Eac").ToString();

                    try
                    {
                        cbScanType.SelectedIndex = (int) key.GetValue("im_ScanType");
                        cbFreqType.SelectedIndex = (int) key.GetValue("im_FreqType");
                    }
                    catch
                    {
                        cbScanType.SelectedIndex = (int)_impSettings.ScanType.Method.ScanType;
                        cbFreqType.SelectedIndex = (int)_impSettings.FrequencyType.Method.FreqType;
                    }
                    textBox6.Text = key.GetValue("im_MaxFrequency").ToString();
                    textBox7.Text = key.GetValue("im_MinFrequency").ToString();
                    textBox8.Text = key.GetValue("im_nFrequencies").ToString();

                    tbEbegin.Text = key.GetValue("im_BeginPotential").ToString();
                    tbEstep.Text = key.GetValue("im_StepPotential").ToString();
                    tbEend.Text = key.GetValue("im_EndPotential").ToString();

                    TbECondition.Text = key.GetValue("im_ConditioningPotential").ToString();
                    TbTCondition.Text = key.GetValue("im_ConditioningTime").ToString();
                    TbEDeposition.Text = key.GetValue("im_DepositionPotential").ToString();
                    TbTDeposition.Text = key.GetValue("im_DepositionTime").ToString();

                    tBStartCurrent.Value = (int) key.GetValue("im_StartCurrent");
                    tbMaxCurrent.Value = (int) key.GetValue("im_MaxCurrent");
                    tBMinCurrent.Value = (int) key.GetValue("im_MinCurrent");

                    lbStartCurrentRange.Text = key.GetValue("im_StartCurrentValue").ToString();
                    lbMaxCurrentRange.Text = key.GetValue("im_MaxCurrentValue").ToString();
                    lbMinCurrentRange.Text = key.GetValue("im_MinCurrentValue").ToString();
                }
                else
                {
                    textBox1.Text = _impSettings.TimeEquilibrium.Method.EquilibrationTime.ToString();
                    textBox2.Text = _impSettings.Potential.Method.Potential.ToString();
                    textBox3.Text = _impSettings.EAC.Method.Eac.ToString();
                    cbScanType.SelectedIndex = (int)_impSettings.ScanType.Method.ScanType;
                    cbFreqType.SelectedIndex = (int)_impSettings.FrequencyType.Method.FreqType;
                    textBox6.Text = _impSettings.MaxFrequency.Method.MaxFrequency.ToString();
                    textBox7.Text = _impSettings.MinFrequency.Method.MinFrequency.ToString();
                    textBox8.Text = _impSettings.NFrequencies.Method.nFrequencies.ToString();

                    tbEbegin.Text = _impSettings.EBegin.Method.BeginPotential.ToString();
                    tbEstep.Text = _impSettings.EStep.Method.StepPotential.ToString();
                    tbEend.Text = _impSettings.EEnd.Method.EndPotential.ToString();

                    TbECondition.Text = _impSettings.ECondition.Method.ConditioningPotential.ToString();
                    TbTCondition.Text = _impSettings.TCondition.Method.ConditioningTime.ToString();
                    TbEDeposition.Text = _impSettings.EDeposition.Method.DepositionPotential.ToString();
                    TbTDeposition.Text = _impSettings.TDeposition.Method.DepositionTime.ToString();

                    tBStartCurrent.Value = _impSettings.StartCurrent.Value;
                    tbMaxCurrent.Value = _impSettings.MaxCurrent.GetPositionByFrequency(_impSettings.MaxCurrent.Method.PretLimitMaxValue);
                    tBMinCurrent.Value = _impSettings.MinCurrent.GetPositionByFrequency(_impSettings.MinCurrent.Method.PretLimitMinValue);


                    lbStartCurrentRange.Text = _impSettings.StartCurrent.GetFrequencyValue(tBStartCurrent.Value);
                    lbMaxCurrentRange.Text = _impSettings.MaxCurrent.GetFrequencyValue(tbMaxCurrent.Value);
                    lbMinCurrentRange.Text = _impSettings.MinCurrent.GetFrequencyValue(tBMinCurrent.Value);
                }
            }
        }


        private void btnSave1_Click(object sender, EventArgs e)
        {
            float _timeEquilibration;
            float _potential;
            float _eac;
            float _maxFrequency;
            float _minFrequency;
            int _nFrequencies;
            float _eEnd;
            float _eStep;
            float _eBegin;
            float _eVertex1;
            float _eVertex2;
            float _scanRate;
            int _numberOfScans;
            float _ePulse;
            float _tPulse;

            float _eCondition;
            float _tCondition;
            float _eDeposition;
            float _tDeposition;


            if (selected_method.GetType().Name == "CyclicVoltammetry")
            {
                try
                {
                    _timeEquilibration = this.CheckStringToFloat(textBox1.Text);
                    _eBegin = this.CheckStringToFloat(textBox2.Text);
                    _eVertex1 = this.CheckStringToFloat(textBox3.Text);
                    _eVertex2 = this.CheckStringToFloat(textBox4.Text);
                    _eStep = this.CheckStringToFloat(textBox5.Text);
                    _scanRate = this.CheckStringToFloat(textBox6.Text);
                    _numberOfScans = this.CheckStringToInt(textBox7.Text);
                
                    _eCondition = this.CheckStringToFloat(TbECondition.Text);
                    _tCondition = this.CheckStringToFloat(TbTCondition.Text);
                    _eDeposition = this.CheckStringToFloat(TbEDeposition.Text);
                    _tDeposition = this.CheckStringToFloat(TbTDeposition.Text);
                }
                catch
                {
                    MessageBox.Show("Lütfen boş alan bırakmayınız.");
                    return;
                }

                // Visual setting data
                //_cvSettings.TimeEquilibrium.Value = _timeEquilibration;
                // Real setting data
                _cvSettings.TimeEquilibrium.Method.EquilibrationTime = _timeEquilibration;
                _cvSettings.EBegin.Method.BeginPotential = _eBegin;
                _cvSettings.EVertex1.Method.Vtx1Potential = _eVertex1;
                _cvSettings.EVertex2.Method.Vtx2Potential = _eVertex2;
                _cvSettings.EStep.Method.StepPotential = _eStep;
                _cvSettings.ScanRate.Method.Scanrate = _scanRate;
                _cvSettings.NumbersOfScan.Method.nEqScans = _numberOfScans;
                _cvSettings.ECondition.Method.ConditioningPotential = _eCondition;
                _cvSettings.TCondition.Method.ConditioningTime = _tCondition;
                _cvSettings.EDeposition.Method.DepositionPotential = _eDeposition;
                _cvSettings.TDeposition.Method.DepositionTime = _tDeposition;
                
                _cvSettings.StartCurrent.Value = tBStartCurrent.Value;
                //_cvSettings.StartCurrent.Method. = _cvSettings.StartCurrent.GetFrequency();

                _cvSettings.MaxCurrent.Value = tbMaxCurrent.Value;
                _cvSettings.MaxCurrent.Method.PretLimitMaxValue = _cvSettings.MaxCurrent.GetFrequency();

                _cvSettings.MinCurrent.Value = tBMinCurrent.Value;
                _cvSettings.MinCurrent.Method.PretLimitMinValue = _cvSettings.MinCurrent.GetFrequency();

                
                // Save the measurement settings to the Windows Registry
                string keyPath = @"SOFTWARE\PalmSense";
                using(RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
                {
                    if (key != null)
                    {
                        // Save data to the registry
                        //key.SetValue("DataKey", tbMaxCurrent.Value);
                        //object data = key.GetValue("DataKey");

                        key.SetValue("cv_EquilibrationTime", _timeEquilibration);
                        key.SetValue("cv_BeginPotential", _eBegin);
                        key.SetValue("cv_Vtx1Potential", _eVertex1);
                        key.SetValue("cv_Vtx2Potential", _eVertex2);
                        key.SetValue("cv_StepPotential", _eStep);
                        key.SetValue("cv_Scanrate", _scanRate);
                        key.SetValue("cv_nEqScans", _numberOfScans);
                        key.SetValue("cv_ConditioningPotential", _eCondition);
                        key.SetValue("cv_ConditioningTime", _tCondition);
                        key.SetValue("cv_DepositionPotential", _eDeposition);
                        key.SetValue("cv_DepositionTime", _tDeposition);

                        key.SetValue("cv_StartCurrent", tBStartCurrent.Value);
                        key.SetValue("cv_StartCurrentValue", _cvSettings.StartCurrent.GetFrequency());
                        
                        key.SetValue("cv_MaxCurrent", tbMaxCurrent.Value);
                        key.SetValue("cv_MaxCurrentValue", _cvSettings.MaxCurrent.GetFrequency());
                        
                        key.SetValue("cv_MinCurrent", tBMinCurrent.Value);
                        key.SetValue("cv_MinCurrentValue", _cvSettings.MinCurrent.GetFrequency());

                        MessageBox.Show("Your settings have been saved");
                    }
                    else
                    {
                        MessageBox.Show("Error: Unable to access or create registry key.");
                    }
                }

            }
            else if (selected_method.GetType().Name == "DifferentialPulse")
            {
                try
                {
                    _timeEquilibration = this.CheckStringToFloat(textBox1.Text);
                    _eBegin = this.CheckStringToFloat(textBox2.Text);
                    _eEnd = this.CheckStringToFloat(textBox3.Text);
                    _eStep = this.CheckStringToFloat(textBox4.Text);
                    _scanRate = this.CheckStringToFloat(textBox5.Text);
                    _ePulse = this.CheckStringToFloat(textBox6.Text);
                    _tPulse = this.CheckStringToFloat(textBox7.Text);

                    _eCondition = this.CheckStringToFloat(TbECondition.Text);
                    _tCondition = this.CheckStringToFloat(TbTCondition.Text);
                    _eDeposition = this.CheckStringToFloat(TbEDeposition.Text);
                    _tDeposition = this.CheckStringToFloat(TbTDeposition.Text);
                }
                catch
                {
                    MessageBox.Show("Lütfen boş alan bırakmayınız ve tamsayı türünde değerler giriniz.");
                    return;
                }

                _dpSettings.TimeEquilibrium.Method.EquilibrationTime = _timeEquilibration;
                _dpSettings.EBegin.Method.BeginPotential = _eBegin;
                _dpSettings.EEnd.Method.EndPotential = _eEnd;
                _dpSettings.EStep.Method.StepPotential = _eStep;
                _dpSettings.ScanRate.Method.Scanrate = _scanRate;
                _dpSettings.EPulse.Method.PulsePotential = _ePulse;
                _dpSettings.TPulse.Method.PulseTime = _tPulse;

                _dpSettings.ECondition.Method.ConditioningPotential = _eCondition;
                _dpSettings.TCondition.Method.ConditioningTime = _tCondition;
                _dpSettings.EDeposition.Method.DepositionPotential = _eDeposition;
                _dpSettings.TDeposition.Method.DepositionTime = _tDeposition;


                _dpSettings.StartCurrent.Value = tBStartCurrent.Value;
                //_dpSettings.StartCurrent.Method. = _dpSettings.StartCurrent.GetFrequency();

                _dpSettings.MaxCurrent.Value = tbMaxCurrent.Value;
                _dpSettings.MaxCurrent.Method.PretLimitMaxValue = _dpSettings.MaxCurrent.GetFrequency();
                
                _dpSettings.MinCurrent.Value = tBMinCurrent.Value;
                _dpSettings.MinCurrent.Method.PretLimitMinValue = _dpSettings.MinCurrent.GetFrequency();


                // Save the measurement settings to the Windows Registry
                string keyPath = @"SOFTWARE\PalmSense";
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
                {
                    if (key != null)
                    {
                        // Save data to the registry
                        //key.SetValue("DataKey", tbMaxCurrent.Value);
                        //object data = key.GetValue("DataKey");

                        key.SetValue("dp_EquilibrationTime", _timeEquilibration);
                        key.SetValue("dp_BeginPotential", _eBegin);
                        key.SetValue("dp_EndPotential", _eEnd);
                        key.SetValue("dp_StepPotential", _eStep);
                        key.SetValue("dp_Scanrate", _scanRate);
                        key.SetValue("dp_PulsePotential", _ePulse);
                        key.SetValue("dp_PulseTime", _tPulse);
                        key.SetValue("dp_ConditioningPotential", _eCondition);
                        key.SetValue("dp_ConditioningTime", _tCondition);
                        key.SetValue("dp_DepositionPotential", _eDeposition);
                        key.SetValue("dp_DepositionTime", _tDeposition);

                        key.SetValue("dp_StartCurrent", tBStartCurrent.Value);
                        key.SetValue("dp_StartCurrentValue", _cvSettings.StartCurrent.GetFrequency());

                        key.SetValue("dp_MaxCurrent", tbMaxCurrent.Value);
                        key.SetValue("dp_MaxCurrentValue", _cvSettings.MaxCurrent.GetFrequency());

                        key.SetValue("dp_MinCurrent", tBMinCurrent.Value);
                        key.SetValue("dp_MinCurrentValue", _cvSettings.MinCurrent.GetFrequency());

                        MessageBox.Show("Your settings have been saved");
                    }
                    else
                    {
                        MessageBox.Show("Error: Unable to access or create registry key.");
                    }
                }

            }
            else if (selected_method.GetType().Name == "ImpedimetricMethod")
            {
                try
                {
                    _timeEquilibration = this.CheckStringToFloat(textBox1.Text);
                    _potential = this.CheckStringToFloat(textBox2.Text);
                    _eac = this.CheckStringToFloat(textBox3.Text);

                    _maxFrequency = this.CheckStringToFloat(textBox6.Text);
                    _minFrequency = this.CheckStringToFloat(textBox7.Text);
                    _nFrequencies = this.CheckStringToInt(textBox8.Text);

                    _eBegin = this.CheckStringToFloat(tbEbegin.Text);
                    _eEnd = this.CheckStringToFloat(tbEend.Text);
                    _eStep = this.CheckStringToFloat(tbEstep.Text);

                    _eCondition = this.CheckStringToFloat(TbECondition.Text);
                    _tCondition = this.CheckStringToFloat(TbTCondition.Text);
                    _eDeposition = this.CheckStringToFloat(TbEDeposition.Text);
                    _tDeposition = this.CheckStringToFloat(TbTDeposition.Text);
                }
                catch
                {
                    MessageBox.Show("Lütfen boş alan bırakmayınız ve tamsayı türünde değerler giriniz.");
                    return;
                }

                _impSettings.TimeEquilibrium.Method.EquilibrationTime = _timeEquilibration;
                _impSettings.Potential.Method.Potential = _potential;
                _impSettings.EAC.Method.Eac = _eac;

                
                _impSettings.ScanType.Method.ScanType = GetScanType(cbScanType.SelectedIndex);
                _impSettings.FrequencyType.Method.FreqType = GetFrequencyType(cbFreqType.SelectedIndex);
                _impSettings.MaxFrequency.Method.MaxFrequency = _maxFrequency;
                _impSettings.MinFrequency.Method.MinFrequency = _minFrequency;
                _impSettings.NFrequencies.Method.nFrequencies = _nFrequencies;

                _impSettings.EBegin.Method.BeginPotential = _eBegin;
                _impSettings.EStep.Method.StepPotential = _eStep;
                _impSettings.EEnd.Method.EndPotential = _eEnd;

                _impSettings.ECondition.Method.ConditioningPotential = _eCondition;
                _impSettings.TCondition.Method.ConditioningTime = _tCondition;
                _impSettings.EDeposition.Method.DepositionPotential = _eDeposition;
                _impSettings.TDeposition.Method.DepositionTime = _tDeposition;

                _impSettings.StartCurrent.Value = tBStartCurrent.Value;
                _impSettings.MaxCurrent.Value = tbMaxCurrent.Value;
                _impSettings.MinCurrent.Value = tBMinCurrent.Value;


                // Save the measurement settings to the Windows Registry
                string keyPath = @"SOFTWARE\PalmSense";
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
                {
                    if (key != null)
                    {
                        // Save data to the registry
                        //key.SetValue("DataKey", tbMaxCurrent.Value);
                        //object data = key.GetValue("DataKey");

                        key.SetValue("im_EquilibrationTime", _timeEquilibration);
                        key.SetValue("im_Potential", _potential);
                        key.SetValue("im_Eac", _eac);

                        //key.SetValue("im_ScanType", GetScanType(cbScanType.SelectedIndex));
                        key.SetValue("im_ScanType", cbScanType.SelectedIndex);
                        //key.SetValue("im_FreqType", GetFrequencyType(cbFreqType.SelectedIndex));
                        key.SetValue("im_FreqType", cbFreqType.SelectedIndex);
                        key.SetValue("im_MaxFrequency", _maxFrequency);
                        key.SetValue("im_MinFrequency", _minFrequency);
                        key.SetValue("im_nFrequencies", _nFrequencies);

                        key.SetValue("im_BeginPotential", _eBegin);
                        key.SetValue("im_EndPotential", _eEnd);
                        key.SetValue("im_StepPotential", _eStep);

                        key.SetValue("im_ConditioningPotential", _eCondition);
                        key.SetValue("im_ConditioningTime", _tCondition);
                        key.SetValue("im_DepositionPotential", _eDeposition);
                        key.SetValue("im_DepositionTime", _tDeposition);

                        key.SetValue("im_StartCurrent", tBStartCurrent.Value);
                        key.SetValue("im_StartCurrentValue", _cvSettings.StartCurrent.GetFrequency());

                        key.SetValue("im_MaxCurrent", tbMaxCurrent.Value);
                        key.SetValue("im_MaxCurrentValue", _cvSettings.MaxCurrent.GetFrequency());

                        key.SetValue("im_MinCurrent", tBMinCurrent.Value);
                        key.SetValue("im_MinCurrentValue", _cvSettings.MinCurrent.GetFrequency());

                        MessageBox.Show("Your settings have been saved");
                    }
                    else
                    {
                        MessageBox.Show("Error: Unable to access or create registry key.");
                    }
                }

            }

            this.Close();       
        }

        private void setDefault_Click(object sender, EventArgs e)
        {
            if (selected_method.GetType().Name == "CyclicVoltammetry")
            {
                CyclicVoltammetry newCV = new CyclicVoltammetry();

                textBox1.Text = newCV.EquilibrationTime.ToString();
                textBox2.Text = newCV.BeginPotential.ToString();
                textBox3.Text = newCV.Vtx1Potential.ToString();
                textBox4.Text = newCV.Vtx2Potential.ToString();
                textBox5.Text = newCV.StepPotential.ToString();
                textBox6.Text = newCV.Scanrate.ToString();
                textBox7.Text = newCV.nEqScans.ToString();

                TbECondition.Text = newCV.ConditioningPotential.ToString();
                TbTCondition.Text = newCV.ConditioningTime.ToString();
                TbEDeposition.Text = newCV.DepositionPotential.ToString();
                TbTDeposition.Text = newCV.DepositionTime.ToString();

                tBStartCurrent.Value = _cvSettings.StartCurrent.Value;
                tbMaxCurrent.Value = _cvSettings.MaxCurrent.GetPositionByFrequency(newCV.PretLimitMaxValue);
                tBMinCurrent.Value = _cvSettings.MinCurrent.GetPositionByFrequency(newCV.PretLimitMinValue);

                lbStartCurrentRange.Text = _cvSettings.StartCurrent.GetFrequencyValue(tBStartCurrent.Value);
                lbMaxCurrentRange.Text = _cvSettings.MaxCurrent.GetFrequencyValue(tbMaxCurrent.Value);
                lbMinCurrentRange.Text = _cvSettings.MinCurrent.GetFrequencyValue(tBMinCurrent.Value);

            }
            else if (selected_method.GetType().Name == "DifferentialPulse")
            {
                DifferentialPulse newDP = new DifferentialPulse();

                textBox1.Text = newDP.EquilibrationTime.ToString();
                textBox2.Text = newDP.BeginPotential.ToString();
                textBox3.Text = newDP.EndPotential.ToString();
                textBox4.Text = newDP.StepPotential.ToString();
                textBox5.Text = newDP.Scanrate.ToString();
                textBox6.Text = newDP.PulsePotential.ToString();
                textBox7.Text = newDP.PulseTime.ToString();

                TbECondition.Text = newDP.ConditioningPotential.ToString();
                TbTCondition.Text = newDP.ConditioningTime.ToString();
                TbEDeposition.Text = newDP.DepositionPotential.ToString();
                TbTDeposition.Text = newDP.DepositionTime.ToString();

                tBStartCurrent.Value = _dpSettings.StartCurrent.Value;
                tbMaxCurrent.Value = _dpSettings.MaxCurrent.GetPositionByFrequency(newDP.PretLimitMaxValue);
                tBMinCurrent.Value = _dpSettings.MinCurrent.GetPositionByFrequency(newDP.PretLimitMinValue);


                lbStartCurrentRange.Text = _dpSettings.StartCurrent.GetFrequencyValue(tBStartCurrent.Value);
                lbMaxCurrentRange.Text = _dpSettings.MaxCurrent.GetFrequencyValue(tbMaxCurrent.Value);
                lbMinCurrentRange.Text = _dpSettings.MinCurrent.GetFrequencyValue(tBMinCurrent.Value);
            }
            else if (selected_method.GetType().Name == "ImpedimetricMethod")
            {
                ImpedimetricMethod newIM = new ImpedimetricMethod();

                textBox1.Text = newIM.EquilibrationTime.ToString();
                textBox2.Text = newIM.Potential.ToString();
                textBox3.Text = newIM.Eac.ToString();
                cbScanType.SelectedIndex = (int)newIM.ScanType;
                cbFreqType.SelectedIndex = (int)newIM.FreqType;
                textBox6.Text = newIM.MaxFrequency.ToString();
                textBox7.Text = newIM.MinFrequency.ToString();
                textBox8.Text = newIM.nFrequencies.ToString();

                tbEbegin.Text = newIM.BeginPotential.ToString();
                tbEstep.Text = newIM.StepPotential.ToString();
                tbEend.Text = newIM.EndPotential.ToString();

                TbECondition.Text = newIM.ConditioningPotential.ToString();
                TbTCondition.Text = newIM.ConditioningTime.ToString();
                TbEDeposition.Text = newIM.DepositionPotential.ToString();
                TbTDeposition.Text = newIM.DepositionTime.ToString();

                tBStartCurrent.Value = _impSettings.StartCurrent.Value;
                tbMaxCurrent.Value = _impSettings.MaxCurrent.GetPositionByFrequency(newIM.PretLimitMaxValue);
                tBMinCurrent.Value = _impSettings.MinCurrent.GetPositionByFrequency(newIM.PretLimitMinValue);


                lbStartCurrentRange.Text = _impSettings.StartCurrent.GetFrequencyValue(tBStartCurrent.Value);
                lbMaxCurrentRange.Text = _impSettings.MaxCurrent.GetFrequencyValue(tbMaxCurrent.Value);
                lbMinCurrentRange.Text = _impSettings.MinCurrent.GetFrequencyValue(tBMinCurrent.Value);
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


        private void tBStartCurrent_Scroll(object sender, EventArgs e)
        {
            if (selected_method.GetType().Name == "CyclicVoltammetry")
            {
                lbStartCurrentRange.Text = _cvSettings.StartCurrent.GetFrequencyValue(tBStartCurrent.Value);
            }
            else if (selected_method.GetType().Name == "DifferentialPulse")
            {
                lbStartCurrentRange.Text = _dpSettings.StartCurrent.GetFrequencyValue(tBStartCurrent.Value);
            }
            else if (selected_method.GetType().Name == "ImpedimetricMethod")
            {
                lbStartCurrentRange.Text = _impSettings.StartCurrent.GetFrequencyValue(tBStartCurrent.Value);
            }
        }

        private void tbMaxCurrent_Scroll(object sender, EventArgs e)
        {
            if (selected_method.GetType().Name == "CyclicVoltammetry")
            {
                lbMaxCurrentRange.Text = _cvSettings.MaxCurrent.GetFrequencyValue(tbMaxCurrent.Value);
            }
            else if (selected_method.GetType().Name == "DifferentialPulse")
            {
                lbMaxCurrentRange.Text = _dpSettings.MaxCurrent.GetFrequencyValue(tbMaxCurrent.Value);
            }
            else if (selected_method.GetType().Name == "ImpedimetricMethod")
            {
                lbMaxCurrentRange.Text = _impSettings.MaxCurrent.GetFrequencyValue(tbMaxCurrent.Value);
            }
        }

        private void tBMinCurrent_Scroll(object sender, EventArgs e)
        {
            if (selected_method.GetType().Name == "CyclicVoltammetry")
            {
                lbMinCurrentRange.Text = _cvSettings.MinCurrent.GetFrequencyValue(tBMinCurrent.Value);
            }
            else if (selected_method.GetType().Name == "DifferentialPulse")
            {
                lbMinCurrentRange.Text = _dpSettings.MinCurrent.GetFrequencyValue(tBMinCurrent.Value);
            }
            else if (selected_method.GetType().Name == "ImpedimetricMethod")
            {
                lbMinCurrentRange.Text = _impSettings.MinCurrent.GetFrequencyValue(tBMinCurrent.Value);
            }
        }



        // Getters and Setters of Data
        public string Title { get { return title; } set { title = value; } }
        public Method SelectedMethod { get { return selected_method; } set { selected_method = value; } }

        
    }
}

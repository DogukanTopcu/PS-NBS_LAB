﻿using Microsoft.Office.Interop.Excel;
using Microsoft.Win32;
using PalmSens;
using PalmSens.Techniques;
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
        public static CyclicVoltammetry_Settings _cvSettings = new CyclicVoltammetry_Settings(MainPage._methodCLV);


        private float _timeEquilibration;
        private float _eStep;
        private float _eBegin;
        private float _eVertex1;
        private float _eVertex2;
        private float _scanRate;
        private int _numberOfScans;


        public cvSettings()
        {
            InitializeComponent();

            _timeEquilibration = 0;
        }

        private void cvSettings_Load(object sender, EventArgs e)
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

                    // Equilibration Time
                    if (key.GetValue("cv_EquilibrationTime").ToString() != "a")
                    {
                        tbTEq.Texts = key.GetValue("cv_EquilibrationTime").ToString();
                        _cvSettings.TimeEquilibrium.Method.EquilibrationTime = this.CheckStringToFloat(key.GetValue("cv_EquilibrationTime").ToString());
                    }
                    else
                    {
                        tbTEq.Texts = _cvSettings.TimeEquilibrium.Method.EquilibrationTime.ToString();
                        _cvSettings.TimeEquilibrium.Method.EquilibrationTime = this.CheckStringToFloat(_cvSettings.TimeEquilibrium.Method.EquilibrationTime.ToString());
                    }

                    // Begin Potential
                    if (key.GetValue("cv_BeginPotential").ToString() != "a")
                    {
                        tbEBegin.Texts = key.GetValue("cv_BeginPotential").ToString();
                        _cvSettings.EBegin.Method.BeginPotential = this.CheckStringToFloat(key.GetValue("cv_BeginPotential").ToString());
                    }
                    else
                    {
                        tbEBegin.Texts = _cvSettings.EBegin.Method.BeginPotential.ToString();
                        _cvSettings.EBegin.Method.BeginPotential = this.CheckStringToFloat(_cvSettings.EBegin.Method.BeginPotential.ToString());
                    }

                    // Vertex 1
                    if (key.GetValue("cv_Vtx1Potential").ToString() != "a")
                    {
                        tbEVertex1.Texts = key.GetValue("cv_Vtx1Potential").ToString();
                        _cvSettings.EVertex1.Method.Vtx1Potential = this.CheckStringToFloat(key.GetValue("cv_Vtx1Potential").ToString());
                    }
                    else
                    {
                        tbEVertex1.Texts = _cvSettings.EVertex1.Method.Vtx1Potential.ToString();
                        _cvSettings.EVertex1.Method.Vtx1Potential = this.CheckStringToFloat(_cvSettings.EVertex1.Method.Vtx1Potential.ToString());
                    }

                    // Vertex 2
                    if (key.GetValue("cv_Vtx2Potential").ToString() != "a")
                    {
                        tbEVertex2.Texts = key.GetValue("cv_Vtx2Potential").ToString();
                        _cvSettings.EVertex2.Method.Vtx2Potential = this.CheckStringToFloat(key.GetValue("cv_Vtx2Potential").ToString());
                    }
                    else
                    {
                        tbEVertex2.Texts = _cvSettings.EVertex2.Method.Vtx2Potential.ToString();
                        _cvSettings.EVertex2.Method.Vtx2Potential = this.CheckStringToFloat(_cvSettings.EVertex2.Method.Vtx2Potential.ToString());
                    }

                    // Step Potential
                    if (key.GetValue("cv_StepPotential").ToString() != "a")
                    {
                        tbEStep.Texts = key.GetValue("cv_StepPotential").ToString();
                        _cvSettings.EStep.Method.StepPotential = this.CheckStringToFloat(key.GetValue("cv_StepPotential").ToString());
                    }
                    else
                    {
                        tbEStep.Texts = _cvSettings.EStep.Method.StepPotential.ToString();
                        _cvSettings.EStep.Method.StepPotential = this.CheckStringToFloat(_cvSettings.EStep.Method.StepPotential.ToString());
                    }

                    // Scan Rate
                    if (key.GetValue("cv_Scanrate").ToString() != "a")
                    {
                        tbScanRate.Texts = key.GetValue("cv_Scanrate").ToString();
                        _cvSettings.ScanRate.Method.Scanrate = this.CheckStringToFloat(key.GetValue("cv_Scanrate").ToString());
                    }
                    else
                    {
                        tbScanRate.Texts = _cvSettings.ScanRate.Method.Scanrate.ToString();
                        _cvSettings.ScanRate.Method.Scanrate = this.CheckStringToFloat(_cvSettings.ScanRate.Method.Scanrate.ToString());
                    }

                    // Number of Scan
                    if (key.GetValue("cv_nEqScans").ToString() != "a")
                    {
                        tbNumberOfScan.Texts = key.GetValue("cv_nEqScans").ToString();
                        _cvSettings.NumbersOfScan.Method.nScans = this.CheckStringToInt(key.GetValue("cv_nEqScans").ToString());
                    }
                    else
                    {
                        tbNumberOfScan.Texts = _cvSettings.NumbersOfScan.Method.nScans.ToString();
                        _cvSettings.NumbersOfScan.Method.nScans = this.CheckStringToInt(_cvSettings.NumbersOfScan.Method.nScans.ToString());
                    }
                }
                else
                {

                    tbTEq.Texts = _cvSettings.TimeEquilibrium.Method.EquilibrationTime.ToString();
                    _cvSettings.TimeEquilibrium.Method.EquilibrationTime = this.CheckStringToFloat(_cvSettings.TimeEquilibrium.Method.EquilibrationTime.ToString());

                    tbEBegin.Texts = _cvSettings.EBegin.Method.BeginPotential.ToString();
                    _cvSettings.EBegin.Method.BeginPotential = this.CheckStringToFloat(_cvSettings.EBegin.Method.BeginPotential.ToString());

                    tbEVertex1.Texts = _cvSettings.EVertex1.Method.Vtx1Potential.ToString();
                    _cvSettings.EVertex1.Method.Vtx1Potential = this.CheckStringToFloat(_cvSettings.EVertex1.Method.Vtx1Potential.ToString());

                    tbEVertex2.Texts = _cvSettings.EVertex2.Method.Vtx2Potential.ToString();
                    _cvSettings.EVertex2.Method.Vtx2Potential = this.CheckStringToFloat(_cvSettings.EVertex2.Method.Vtx2Potential.ToString());

                    tbEStep.Texts = _cvSettings.EStep.Method.StepPotential.ToString();
                    _cvSettings.EStep.Method.StepPotential = this.CheckStringToFloat(_cvSettings.EStep.Method.StepPotential.ToString());

                    tbScanRate.Texts = _cvSettings.ScanRate.Method.Scanrate.ToString();
                    _cvSettings.ScanRate.Method.Scanrate = this.CheckStringToFloat(_cvSettings.ScanRate.Method.Scanrate.ToString());

                    tbNumberOfScan.Texts = _cvSettings.NumbersOfScan.Method.nScans.ToString();
                    _cvSettings.NumbersOfScan.Method.nScans = this.CheckStringToInt(_cvSettings.NumbersOfScan.Method.nScans.ToString());
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
            
            _cvSettings.TimeEquilibrium.Method.EquilibrationTime = _timeEquilibration;
            if (MainPage.saveInternalStorage)
            {
                string keyPath = @"SOFTWARE\PalmSense";
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
                {
                    key.SetValue("cv_EquilibrationTime", _timeEquilibration);
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

            _cvSettings.EBegin.Method.BeginPotential = _eBegin;
            if (MainPage.saveInternalStorage)
            {
                string keyPath = @"SOFTWARE\PalmSense";
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
                {
                    key.SetValue("cv_BeginPotential", _eBegin);
                }
            }
        }

        private void tbEVertex1__TextChanged(object sender, EventArgs e)
        {
            try
            {
                _eVertex1 = this.CheckStringToFloat(tbEVertex1.Texts);
            }
            catch
            {
                MessageBox.Show("Lütfen boş alan bırakmayınız.");
                return;
            }

            _cvSettings.EVertex1.Method.Vtx1Potential = _eVertex1;
            if (MainPage.saveInternalStorage)
            {
                string keyPath = @"SOFTWARE\PalmSense";
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
                {
                    key.SetValue("cv_Vtx1Potential", _eVertex1);
                }
            }
        }

        private void tbEVertex2__TextChanged(object sender, EventArgs e)
        {
            try
            {
                _eVertex2 = this.CheckStringToFloat(tbEVertex2.Texts);
            }
            catch
            {
                MessageBox.Show("Lütfen boş alan bırakmayınız.");
                return;
            }

            _cvSettings.EVertex2.Method.Vtx2Potential = _eVertex2;
            if (MainPage.saveInternalStorage)
            {
                string keyPath = @"SOFTWARE\PalmSense";
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
                {
                    key.SetValue("cv_Vtx2Potential", _eVertex2);
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

            _cvSettings.EStep.Method.StepPotential = _eStep;
            if (MainPage.saveInternalStorage)
            {
                string keyPath = @"SOFTWARE\PalmSense";
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
                {
                    key.SetValue("cv_StepPotential", _eStep);
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

            _cvSettings.ScanRate.Method.Scanrate = _scanRate;
            if (MainPage.saveInternalStorage)
            {
                string keyPath = @"SOFTWARE\PalmSense";
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
                {
                    key.SetValue("cv_Scanrate", _scanRate);
                }
            }
        }

        private void tbNumberOfScan__TextChanged(object sender, EventArgs e)
        {
            try
            {
                _numberOfScans = this.CheckStringToInt(tbNumberOfScan.Texts);
            }
            catch
            {
                MessageBox.Show("Lütfen boş alan bırakmayınız.");
                return;
            }

            _cvSettings.NumbersOfScan.Method.nScans = _numberOfScans;
            if (MainPage.saveInternalStorage)
            {
                string keyPath = @"SOFTWARE\PalmSense";
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
                {
                    key.SetValue("cv_nEqScans", _numberOfScans);
                }
            }
        }


        public void LoadData(CyclicVoltammetry m)
        {
            tbTEq.Texts = m.EquilibrationTime.ToString();
            _cvSettings.TimeEquilibrium.Method.EquilibrationTime = m.EquilibrationTime;

            tbEBegin.Texts = m.BeginPotential.ToString();
            _cvSettings.EBegin.Method.BeginPotential = m.BeginPotential;

            tbEVertex1.Texts = m.Vtx1Potential.ToString();
            _cvSettings.EVertex1.Method.Vtx1Potential = m.Vtx1Potential;

            tbEVertex2.Texts = m.Vtx2Potential.ToString();
            _cvSettings.EVertex2.Method.Vtx2Potential = m.Vtx2Potential;

            tbEStep.Texts = m.StepPotential.ToString();
            _cvSettings.EStep.Method.StepPotential = m.StepPotential;

            tbScanRate.Texts = m.Scanrate.ToString();
            _cvSettings.ScanRate.Method.Scanrate = m.Scanrate;

            tbNumberOfScan.Texts = m.nScans.ToString();
            _cvSettings.NumbersOfScan.Method.nScans = m.nScans;
        }
    }
}

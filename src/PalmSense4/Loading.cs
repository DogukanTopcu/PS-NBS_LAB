using PalmSens.Core.Simplified.WinForms;
using PalmSens.Techniques;
using PalmSense4.components;
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

namespace PalmSense4
{
    public partial class Loading : Form
    {
        private DifferentialPulse_Settings _dpSettings;
        private DifferentialPulse _methodDLP;
        private ListBox lbConsole;
        public static PSCommSimpleWinForms psRegeneration;

        private double p;
        private double t;

        public Loading(double potential, double time)
        {
            InitializeComponent();
            
            _methodDLP = new DifferentialPulse();
            _dpSettings = new DifferentialPulse_Settings(_methodDLP);
            psRegeneration = psCommSimpleWinForms1;

            p = potential;
            t = time;
        }


        private void Loading_Load(object sender, EventArgs e)
        {
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.MarqueeAnimationSpeed = 2;

            StartRegeneration(p, t);
        }


        private async void StartRegeneration(double p, double t)
        {
            MainPage.ps.Disconnect();
            psCommSimpleWinForms1.Connect(MainPage.connectedDevice);

            float tempECondition = _dpSettings.ECondition.Method.ConditioningPotential;
            float tempTCondition = _dpSettings.TCondition.Method.ConditioningTime;

            _dpSettings.ECondition.Method.ConditioningPotential = (float) p;
            _dpSettings.TCondition.Method.ConditioningTime = (float) t;

            if (psCommSimpleWinForms1.DeviceState == PalmSens.Comm.CommManager.DeviceState.Idle)
            {
                try
                {
                    psCommSimpleWinForms1.Measure(_methodDLP);
                }
                catch (Exception ex)
                {
                    MainPage.lbox.Items.Add(ex.Message);
                }
            }
            else
            {
                try
                {
                    if (psCommSimpleWinForms1.EnableBluetooth)
                        await psCommSimpleWinForms1.AbortMeasurementAsync();
                    else
                        psCommSimpleWinForms1.AbortMeasurement(); //Abort the active measurement
                }
                catch (Exception ex)
                {
                    MainPage.lbox.Items.Add(ex.Message);
                }
            }

            _dpSettings.ECondition.Method.ConditioningPotential = tempECondition;
            _dpSettings.TCondition.Method.ConditioningTime = tempTCondition;
        }

        private async void rjButton1_Click(object sender, EventArgs e)
        {
            await psCommSimpleWinForms1.DisconnectAsync();
            MainPage.ps.Connect(MainPage.connectedDevice);
            MainPage.lbox.Items.Add("Connected");
            MainPage.btnConn.Enabled = true;
            MainPage.measureBtn.Enabled = true;

            regeneration.startBtn.Enabled = true;
            Close();
        }


        private void psCommSimpleWinForms1_MeasurementStarted(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            rjButton1.Text = "Cancel";
            label1.Text = "Regeneration process is proceeding";
        }

        private void psCommSimpleWinForms1_MeasurementEnded(object sender, Exception e)
        {
            progressBar1.Visible = false;
            rjButton1.Text = "OK";
            label1.Text = "Regeneration process has done";
        }
    }
}

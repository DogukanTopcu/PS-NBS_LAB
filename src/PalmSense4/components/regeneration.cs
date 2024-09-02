using PalmSens.Core.Simplified.Data;
using PalmSens.Core.Simplified.WinForms;
using PalmSens.Techniques;
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

namespace PalmSense4.components
{
    public partial class regeneration : UserControl
    {
        private DifferentialPulse_Settings _dpSettings;
        private DifferentialPulse _methodDLP;
        private ListBox lbConsole;

        private Loading loadingPage;

        public static Button startBtn;
        public static PSCommSimpleWinForms psRegeneration;
        public static bool isRegeneration = false;

        public regeneration()
        {
            InitializeComponent();
            regenerationStartButton.Enabled = false;
            _methodDLP = new DifferentialPulse();
            _dpSettings = new DifferentialPulse_Settings(_methodDLP);

            loadingPage = new Loading();

            psRegeneration = psCommSimpleWinForms2;
            startBtn = regenerationStartButton;
        }

        public void generateFunction(ListBox lb)
        {
            lbConsole = lb;
        }
        private async void regenerationStartButton_Click(object sender, EventArgs e)
        {
            if (potantialRegeneration.Texts == "" || timeRegeneration.Texts == "")
            {
                MainPage.lbox.Items.Add("Regeneration Process couldn't start");
            }
            else
            {
                MainPage.ps.Disconnect();
                psCommSimpleWinForms2.Connect(MainPage.connectedDevice);

                try
                {
                    double potential = Double.Parse(potantialRegeneration.Texts);
                    double time = Double.Parse(timeRegeneration.Texts);

                    float tempECondition = _dpSettings.ECondition.Method.ConditioningPotential;
                    float tempTCondition = _dpSettings.TCondition.Method.ConditioningTime;

                    _dpSettings.ECondition.Method.ConditioningPotential = (float)potential;
                    _dpSettings.TCondition.Method.ConditioningTime = (float)time;

                    if (psCommSimpleWinForms2.DeviceState == PalmSens.Comm.CommManager.DeviceState.Idle)
                    {
                        try
                        {
                            psCommSimpleWinForms2.Measure(_methodDLP);
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
                            if (psCommSimpleWinForms2.EnableBluetooth)
                                await psCommSimpleWinForms2.AbortMeasurementAsync();
                            else
                                psCommSimpleWinForms2.AbortMeasurement(); //Abort the active measurement
                        }
                        catch (Exception ex)
                        {
                            MainPage.lbox.Items.Add(ex.Message);
                        }
                    }


                    _dpSettings.ECondition.Method.ConditioningPotential = tempECondition;
                    _dpSettings.TCondition.Method.ConditioningTime = tempTCondition;

                }
                catch
                {
                    MainPage.lbox.Items.Add("Regeneration Process is not done");
                    await psCommSimpleWinForms2.DisconnectAsync();
                    MainPage.ps.Connect(MainPage.connectedDevice);
                    return;
                }
            }
        }



        private void psCommSimpleWinForms2_MeasurementStarted(object sender, EventArgs e)
        {
            lbConsole.Items.Add("Regeneration started.");
            isRegeneration = true;
            loadingPage.ShowDialog();

            MainPage.btnConn.Enabled = false;
            MainPage.measureBtn.Enabled = false;
        }
        private async void psCommSimpleWinForms2_MeasurementEnded(object sender, Exception e)
        {
            MainPage.lbox.Items.Add("Regeneration Process is done successfully");

            lbConsole.Items.Add("Regeneration ended.");
            isRegeneration = false;
            loadingPage.Close();

            await psCommSimpleWinForms2.DisconnectAsync();
            MainPage.ps.Connect(MainPage.connectedDevice);
            MainPage.lbox.Items.Add("Connected");
            MainPage.btnConn.Enabled = true;
            MainPage.measureBtn.Enabled = true;
            regenerationStartButton.Enabled = true;
        }

        private void panel20_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

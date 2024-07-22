using PalmSens.Core.Simplified.WinForms;
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

namespace PalmSense4.components
{
    public partial class regeneration : UserControl
    {
        private DifferentialPulse_Settings _dpSettings;
        private DifferentialPulse _methodDLP;
        private ListBox lbConsole;

        public regeneration()
        {
            InitializeComponent();

            _methodDLP = new DifferentialPulse();
            _dpSettings = new DifferentialPulse_Settings(_methodDLP);
        }

        public void generateFunction(ListBox lb)
        {
            lbConsole = lb;
        }
        private void regenerationStartButton_Click(object sender, EventArgs e)
        {
            if (potantialRegeneration.Text == "" || timeRegeneration.Text == "")
            {
                //lbConsole.Items.Add("Regeneration Process couldn't start");
            }
            else
            {
                try
                {
                    double potantial = Double.Parse(potantialRegeneration.Text);
                    double time = Double.Parse(timeRegeneration.Text);

                    float tempECondition = _dpSettings.ECondition.Method.ConditioningPotential;
                    float tempTCondition = _dpSettings.TCondition.Method.ConditioningTime;

                    _dpSettings.ECondition.Method.ConditioningPotential = (float)potantial;
                    _dpSettings.TCondition.Method.ConditioningTime = (float)time;

                    if (psCommSimpleWinForms2.DeviceState == PalmSens.Comm.CommManager.DeviceState.Idle)
                    {
                        try
                        {
                            psCommSimpleWinForms2.Measure(_methodDLP);
                        }
                        catch (Exception ex)
                        {
                            //lbConsole.Items.Add(ex.Message);
                        }
                    }
                    else
                    {
                        try
                        {
                            if (psCommSimpleWinForms2.EnableBluetooth)
                                psCommSimpleWinForms2.AbortMeasurementAsync();
                            else
                                psCommSimpleWinForms2.AbortMeasurement(); //Abort the active measurement
                        }
                        catch (Exception ex)
                        {
                            //lbConsole.Items.Add(ex.Message);
                        }
                    }


                    _dpSettings.ECondition.Method.ConditioningPotential = tempECondition;
                    _dpSettings.TCondition.Method.ConditioningTime = tempTCondition;

                }
                catch
                {
                    //lbConsole.Items.Add("Regeneration Process is not done");
                }


                //lbConsole.Items.Add("Regeneration Process is done successfully");

            }
        }
    }
}

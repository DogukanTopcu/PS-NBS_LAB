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

        public static Button startBtn;
        public static bool isRegeneration = false;

        public regeneration()
        {
            InitializeComponent();
            regenerationStartButton.Enabled = MainPage.ps != null ? MainPage.ps.Connected : false;
            _methodDLP = new DifferentialPulse();
            _dpSettings = new DifferentialPulse_Settings(_methodDLP);

            startBtn = regenerationStartButton;
        }

        
        private void regenerationStartButton_Click(object sender, EventArgs e)
        {
            if (potantialRegeneration.Texts == "" || timeRegeneration.Texts == "")
            {
                MainPage.lbox.Items.Add("Regeneration Process couldn't start");
            }
            else
            {
                try
                {
                    double potential = Double.Parse(potantialRegeneration.Texts);
                    double time = Double.Parse(timeRegeneration.Texts);

                    new Loading(potential, time).ShowDialog();
                }
                catch
                {
                    MainPage.lbox.Items.Add("Regeneration Process is not done");
                    return;
                }
            }
        }

        private void panel20_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

using PalmSens.Core.Simplified.Data;
using PalmSens.Core.Simplified.WinForms;
using PalmSens.Devices;
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
    public partial class MainPage : Form
    {
        // Attributes
        private Device[] _connectedDevices;
        private SimpleMeasurement _activeMeasurement;

        // CONSTRUCTORS *************************************************************************
        public MainPage()
        {
            InitializeComponent();
            this._connectedDevices = new Device[0];

            btnConnect.Enabled = false;
            DiscoverConnectedDevices();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            splitContainer2.IsSplitterFixed = true;
            splitContainer1.IsSplitterFixed = true;
            measurementBtn.Enabled = false;
            
            if (psCommSimpleWinForms.EnableBluetooth) btnBluetooth.BackgroundColor = Color.LightBlue;
        }
        // CONSTRUCTORS *************************************************************************



        // CONNECTION ***************************************************************************
        private void DiscoverConnectedDevices()
        {
            cmbDevices.Items.Clear();
            _connectedDevices = psCommSimpleWinForms.ConnectedDevices; // Discover connected devices

            foreach (Device d in _connectedDevices)
                cmbDevices.Items.Add(d.ToString()); // Add connected devices to control

            int nDevices = cmbDevices.Items.Count;
            cmbDevices.SelectedIndex = nDevices > 0 ? 0 : -1;
            lbConsole.Items.Add($"Found {nDevices} device(s).");

            btnConnect.Enabled = nDevices > 0;
        }

        private void btnRefresh_Click(object sender, EventArgs e) => DiscoverConnectedDevices();

        private void btnBluetooth_Click(object sender, EventArgs e)
        {
            psCommSimpleWinForms.EnableBluetooth = !psCommSimpleWinForms.EnableBluetooth;

            if (psCommSimpleWinForms.EnableBluetooth) btnBluetooth.BackgroundColor = Color.LightBlue; 
            else btnBluetooth.BackgroundColor = Color.Transparent;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (!psCommSimpleWinForms.Connected)
            {
                if (cmbDevices.SelectedIndex == -1) return;

                try
                {
                    //Connect to the device selected in the devices combobox control
                    psCommSimpleWinForms.Connect(_connectedDevices[cmbDevices.SelectedIndex]);
                    lbConsole.Items.Add($"Connected to {psCommSimpleWinForms.ConnectedDevice.ToString()}");
                }
                catch (Exception ex)
                {
                    lbConsole.Items.Add(ex.Message);
                }
            }
            else
            {
                psCommSimpleWinForms.Disconnect(); //Disconnect from the connected device
            }


            // Update UI based on connection status
            cmbDevices.Enabled = !psCommSimpleWinForms.Connected;
            btnRefresh.Enabled = !psCommSimpleWinForms.Connected;
            btnConnect.Text = psCommSimpleWinForms.Connected ? "Disconnect" : "Connect";
            connectionLabel.Text = psCommSimpleWinForms.Connected ? "Connected" : "No Connection";
            measurementBtn.Enabled = psCommSimpleWinForms.Connected;
            measurement_type.Enabled = psCommSimpleWinForms.Connected;
        }

        // CONNECTION ***************************************************************************



        private void section1_btn_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel1Collapsed = !splitContainer2.Panel1Collapsed;
            section1_btn.BackgroundImage.RotateFlip(RotateFlipType.Rotate180FlipY);
        }
        private void section2_btn_Click_1(object sender, EventArgs e)
        {
            splitContainer1.Panel2Collapsed = !splitContainer1.Panel2Collapsed;
            section2_btn.BackgroundImage.RotateFlip(RotateFlipType.Rotate180FlipY);
        }

        private void pretreatment_settings_btn_Click(object sender, EventArgs e)
        {
            pretreatment_settings_btn.Image.RotateFlip(RotateFlipType.Rotate180FlipX);

            if (pretreatmentSettingsPanel.Height == pretreatment_settings_btn.Height)
            {
                pretreatmentSettingsPanel.Height = 331;
            }
            else
            {
                pretreatmentSettingsPanel.Height = pretreatment_settings_btn.Height;
            }
        }

        private void technique_settings_Click(object sender, EventArgs e)
        {
            technique_settings.Image.RotateFlip(RotateFlipType.Rotate180FlipX);

            if (techniqueSettingsPanel.Height == technique_settings.Height)
            {
                techniqueSettingsPanel.Height = 331;
            }
            else
            {
                techniqueSettingsPanel.Height = technique_settings.Height;
            }
        }
    }
}

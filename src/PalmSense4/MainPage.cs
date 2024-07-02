using PalmSens;
using PalmSens.Comm;
using PalmSens.Core.Simplified.Data;
using PalmSens.Core.Simplified.WinForms;
using PalmSens.Devices;
using PalmSens.Techniques;
using PalmSense4.Business;
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
    public partial class MainPage : Form
    {
        // Attributes
        private Device[] _connectedDevices;
        private SimpleMeasurement _activeMeasurement;

        private CyclicVoltammetry _methodCLV;
        private DifferentialPulse _methodDLP;
        private ImpedimetricMethod _methodIMM;
        private Method _selectedMethod;

        private Measurement_Settings _measurementSettings;
        private CyclicVoltammetry_Settings _cvSettings;
        private DifferentialPulse_Settings _dpSettings;
        private ImpedimetricMethod_Settings _impSettings;


        // Calculators
        private GramsToMoleCalc gtmCalc;

        // CONSTRUCTORS *************************************************************************
        public MainPage()
        {
            InitializeComponent();
            this._connectedDevices = new Device[0];

            DiscoverConnectedDevices();

            _methodCLV = new CyclicVoltammetry();
            _methodDLP = new DifferentialPulse();
            _methodIMM = new ImpedimetricMethod();
            _selectedMethod = _methodCLV;

            _cvSettings = new CyclicVoltammetry_Settings(_methodCLV);
            _dpSettings = new DifferentialPulse_Settings(_methodDLP);
            _impSettings = new ImpedimetricMethod_Settings(_methodIMM);
            _measurementSettings = new Measurement_Settings(_cvSettings, _dpSettings, _impSettings);


            // Calculators
            gtmCalc = new GramsToMoleCalc(
                comboBox_Chemical, 
                comboBox_Chemical_Select, 
                textBox_MolarMass,
                textBox_Mass,
                textBox_NumberofMoles,
                radioButton_Mass,
                radioButton_NumberofMoles,
                btnReset_GramsToMoleCalc
            );
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            splitContainer2.IsSplitterFixed = true;
            splitContainer1.IsSplitterFixed = true;
            measurementBtn.Enabled = false;

            if (psCommSimpleWinForms.EnableBluetooth) btnBluetooth.BackgroundColor = Color.LightBlue;


            measurement_type.Items.Add(CyclicVoltammetry.Name);
            measurement_type.Items.Add(DifferentialPulse.Name);
            measurement_type.Items.Add(ImpedimetricMethod.Name);
            measurement_type.SelectedIndex = 0;
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
                    psCommSimpleWinForms.Connect(_connectedDevices[cmbDevices.SelectedIndex]);
                    lbConsole.Items.Add($"Connected to {psCommSimpleWinForms.ConnectedDevice.ToString()}");
                    measurement_type.SelectedIndex = 0;
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




        // BUILT-IN FUNCTIONS FOR psCommSimpleWinForm ***********************************************

        private void psCommSimpleWinForms_StateChanged(object sender, PalmSens.Comm.CommManager.DeviceState CurrentState)
        {
            status_statusbar.Text = "Status: " + CurrentState.ToString();

            btnConnect.Enabled = CurrentState == PalmSens.Comm.CommManager.DeviceState.Idle;
            regenerationStartButton.Text = CurrentState == PalmSens.Comm.CommManager.DeviceState.Idle ? "Start" : "Abort";
        }

        private void psCommSimpleWinForms_ReceiveStatus(object sender, PalmSens.Comm.StatusEventArgs e)
        {
            Status status = e.GetStatus();
            double potential = status.PotentialReading.Value;
            double currentInRange = status.CurrentReading.ValueInRange;

            ReadingStatus currentStatus = status.CurrentReading.ReadingStatus;
            CurrentRange cr = status.CurrentReading.CurrentRange;

            status_statusbar.Text = "Status: Idle";
            potential_statusbar.Text = "Potential: " + potential.ToString("F3");
            current_statusbar.Text = "Current: " + currentInRange.ToString("F3");
        }


        private void psCommSimpleWinForms_Disconnected(object sender, Exception exception)
        {
            if (exception != null) lbConsole.Items.Add(exception.Message);
            lbConsole.Items.Add("Disconnected.");
        }


        // BUILT-IN FUNCTIONS FOR psCommSimpleWinForm ***********************************************


        //Measurement Technique
        private void measurement_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (measurement_type.SelectedItem)
            {
                case CyclicVoltammetry.Name:
                    _selectedMethod = _methodCLV;
                    break;
                case DifferentialPulse.Name:
                    _selectedMethod = _methodDLP;
                    break;
                case ImpedimetricMethod.Name:
                    _selectedMethod = _methodIMM;
                    break;
                default:
                    _selectedMethod = null;
                    break;
            }
        }





        // CALCULATORS ----------------------------------------------------------------------------------


        // GRAM TO MOLE CALC
        private void comboBox_Chemical_SelectedIndexChanged(object sender, EventArgs e) => gtmCalc.comboBox_Chemical_SelectedIndexChanged();
        private void comboBox_Chemical_Select_SelectedIndexChanged(object sender, EventArgs e) => gtmCalc.comboBox_Chemical_Select_SelectedIndexChanged();
        private void radioButton_Mass_CheckedChanged(object sender, EventArgs e) => gtmCalc.radioButton_Mass_CheckedChanged();
        private void radioButton_NumberofMoles_CheckedChanged(object sender, EventArgs e) => gtmCalc.radioButton_NumberofMoles_CheckedChanged();
        private void btnReset_GramsToMoleCalc_Click(object sender, EventArgs e) => gtmCalc.btnReset_GramsToMoleCalc_Click();
        private void textBox_Mass__TextChanged(object sender, EventArgs e) => gtmCalc.textBox_Mass__TextChanged();
        private void textBox_NumberofMoles__TextChanged(object sender, EventArgs e) => gtmCalc.textBox_NumberofMoles__TextChanged();




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

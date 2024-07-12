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
        private PH_POH_Calculator pH_pOH;
        private PpmCalculator ppmCalc;
        private SolutionDiluationCalc solDiluationCalc;

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
            pH_pOH = new PH_POH_Calculator(
                radioButton_H,
                textBox_H,
                textBox_pH,
                radioButton_OH,
                textBox_OH,
                textBox_pOH,
                pHpOHResetBtn
            );
            ppmCalc = new PpmCalculator(
                radioButton_ppm,
                radioButton_molarmass,
                radioButton_molarity,
                textBox_ppm,
                textBox_MolarMass_ppm,
                textBox_Molarity,
                comboBox_ppm_unit,
                comboBox_molarity_unit
            );
            solDiluationCalc = new SolutionDiluationCalc(
                rbInitConc,
                rbInitVol,
                rbFinConc,
                rbFinVol,
                tbInitConc,
                tbInitVol,
                tbFinConc,
                tbFinVol
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


            // Calculator
            comboBox_ppm_unit.Items.Add("ppm");
            comboBox_ppm_unit.Items.Add("ppb");
            comboBox_ppm_unit.Items.Add("mg/L");
            comboBox_molarity_unit.Items.Add("M");
            comboBox_molarity_unit.Items.Add("mM");
            comboBox_molarity_unit.Items.Add("μM");
            comboBox_molarity_unit.Items.Add("nM");
            comboBox_ppm_unit.SelectedIndex = 0;
            comboBox_molarity_unit.SelectedIndex = 0;
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
                    
                    cvSettings1.Visible = true;
                    dpSettings1.Visible = false;
                    isSettings1.Visible = false;
                    break;
                case DifferentialPulse.Name:
                    _selectedMethod = _methodDLP;
                    
                    cvSettings1.Visible = false;
                    dpSettings1.Visible = true;
                    isSettings1.Visible = false;
                    break;
                case ImpedimetricMethod.Name:
                    _selectedMethod = _methodIMM;

                    cvSettings1.Visible = false;
                    dpSettings1.Visible = false;
                    isSettings1.Visible = true;
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

        // pH - pOH CALCULATOR
        private void textBox_H__TextChanged(object sender, EventArgs e) => pH_pOH.textBox_H__TextChanged();
        private void radioButton_H_CheckedChanged(object sender, EventArgs e) => pH_pOH.radioButton_H_CheckedChanged();
        private void radioButton_OH_CheckedChanged(object sender, EventArgs e) => pH_pOH.radioButton_OH_CheckedChanged();
        private void textBox_OH__TextChanged(object sender, EventArgs e) => pH_pOH.textBox_OH__TextChanged();
        private void pHpOHResetBtn_Click(object sender, EventArgs e) => pH_pOH.pHpOHResetBtn_Click();

        // PPM CALCULATOR
        private void radioButton_ppm_CheckedChanged(object sender, EventArgs e) => ppmCalc.radioButton_ppm_CheckedChanged();
        private void radioButton_molarmass_CheckedChanged(object sender, EventArgs e) => ppmCalc.radioButton_molarmass_CheckedChanged();
        private void radioButton_molarity_CheckedChanged(object sender, EventArgs e) => ppmCalc.radioButton_molarity_CheckedChanged();
        private void comboBox_ppm_unit_SelectedIndexChanged(object sender, EventArgs e) => ppmCalc.comboBox_ppm_unit_SelectedIndexChanged();
        private void comboBox_molarity_unit_SelectedIndexChanged(object sender, EventArgs e) => ppmCalc.comboBox_molarity_unit_SelectedIndexChanged();
        private void textBox_ppm__TextChanged(object sender, EventArgs e) => ppmCalc.PpmCalculate();
        private void textBox_MolarMass_ppm__TextChanged(object sender, EventArgs e) => ppmCalc.PpmCalculate();
        private void textBox_Molarity__TextChanged(object sender, EventArgs e) => ppmCalc.PpmCalculate();
        private void button_reset_ppm_Click(object sender, EventArgs e) => ppmCalc.button_reset_ppm_Click();

        // SOLUTION DILUATION CALCULATOR
        private void rbInitConc_CheckedChanged(object sender, EventArgs e) => solDiluationCalc.rbInitConc_CheckedChanged();
        private void rbInitVol_CheckedChanged(object sender, EventArgs e) => solDiluationCalc.rbInitVol_CheckedChanged();
        private void rbFinConc_CheckedChanged(object sender, EventArgs e) => solDiluationCalc.rbFinConc_CheckedChanged();
        private void rbFinVol_CheckedChanged(object sender, EventArgs e) => solDiluationCalc.rbFinVol_CheckedChanged();
        private void tbInitConc__TextChanged(object sender, EventArgs e) => solDiluationCalc.SolDilCalc();
        private void tbInitVol__TextChanged(object sender, EventArgs e) => solDiluationCalc.SolDilCalc();
        private void tbFinConc__TextChanged(object sender, EventArgs e) => solDiluationCalc.SolDilCalc();
        private void tbFinVol__TextChanged(object sender, EventArgs e) => solDiluationCalc.SolDilCalc();
        private void soldiluationResetBtn_Click(object sender, EventArgs e) => solDiluationCalc.soldiluationResetBtn_Click();

        //END CALCULATORS ----------------------------------------------------------------------------------


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

        private void cvSettings1_Load(object sender, EventArgs e)
        {

        }
    }
}

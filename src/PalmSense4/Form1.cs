using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra.Factorization;
using Newtonsoft.Json.Linq;
using OxyPlot;
using PalmSens;
using PalmSens.Comm;
using PalmSens.Core.Simplified.Data;
using PalmSens.Core.Simplified.WinForms;
using PalmSens.Data;
using PalmSens.Devices;
using PalmSens.Techniques;
using PalmSens.Windows;
using PalmSense4.Business;
using PalmSense4.data.Measurement_Settings;
using SDKPlot.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace PalmSense4
{
    public partial class Form1 : Form
    {
        private Device[] _connectedDevices;
        private List<Chemical_Combinations> _cc;
        Dictionary<string, Dictionary<string, double>> _conversionFactors;

        private CyclicVoltammetry _methodCLV;
        private DifferentialPulse _methodDLP;
        private ImpedimetricMethod _methodIMM;
        private Method _selectedMethod;
        
        private Measurement_Settings _measurementSettings;
        private CyclicVoltammetry_Settings _cvSettings;
        private DifferentialPulse_Settings _dpSettings;
        private ImpedimetricMethod_Settings _impSettings;

        private SimpleMeasurement _activeMeasurement;

        private FileIO _fileIO;
        private List<List<double>> _measurementData;

        private Dictionary<string, List<List<double>>> _allMeasurements;
        private Dictionary<string, System.Windows.Forms.DataGridView> _allMeasurementTable;

        private int plotNumber;

        public Form1(List<Chemical_Combinations> _cc)
        {
            InitializeComponent();

            this._connectedDevices = new Device[0];
            this._cc = _cc;
            this._conversionFactors = new Dictionary<string, Dictionary<string, double>>();

            _methodCLV = new CyclicVoltammetry();
            _methodDLP = new DifferentialPulse();
            _methodIMM = new ImpedimetricMethod();
            _selectedMethod = null;

            DiscoverConnectedDevices();

            _cvSettings = new CyclicVoltammetry_Settings(_methodCLV);
            _dpSettings = new DifferentialPulse_Settings(_methodDLP);
            _impSettings = new ImpedimetricMethod_Settings(_methodIMM);
            _measurementSettings = new Measurement_Settings(_cvSettings, _dpSettings, _impSettings);

            _fileIO = new FileIO();
            _measurementData = new List<List<double>>();

            _allMeasurements = new Dictionary<string, List<List<double>>>();
            _allMeasurementTable = new Dictionary<string, DataGridView>();
            plotNumber = 1;

        }

        // Connection
        private void DiscoverConnectedDevices()
        {
            cmbDevices.Items.Clear();
            _connectedDevices = psCommSimpleWinForms1.ConnectedDevices; //Discover connected devices

            foreach (Device d in _connectedDevices)
                cmbDevices.Items.Add(d.ToString()); //Add connected devices to control

            int nDevices = cmbDevices.Items.Count;
            cmbDevices.SelectedIndex = nDevices > 0 ? 0 : -1;
            lbConsole.Items.Add($"Found {nDevices} device(s).");

            btnConnect.Enabled = nDevices > 0;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (!psCommSimpleWinForms1.Connected) //Determine whether a device is currently connected
            {
                if (cmbDevices.SelectedIndex == -1)
                    return;

                try
                {
                    //Connect to the device selected in the devices combobox control
                    psCommSimpleWinForms1.Connect(_connectedDevices[cmbDevices.SelectedIndex]);
                    lbConsole.Items.Add($"Connected to {psCommSimpleWinForms1.ConnectedDevice.ToString()}");
                }
                catch (Exception ex)
                {
                    lbConsole.Items.Add(ex.Message);
                }
            }
            else
            {
                psCommSimpleWinForms1.Disconnect(); //Disconnect from the connected device
            }

            //Update UI based on connection status
            cmbDevices.Enabled = !psCommSimpleWinForms1.Connected;
            btnRefresh.Enabled = !psCommSimpleWinForms1.Connected;
            btnConnect.Text = psCommSimpleWinForms1.Connected ? "Disconnect" : "Connect";
            btnMeasure.Enabled = psCommSimpleWinForms1.Connected;
            measurement_type.Enabled = psCommSimpleWinForms1.Connected;
            //btnSaveSetting.Enabled = psCommSimpleWinForms1.Connected;

        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DiscoverConnectedDevices();
        }
        // Connection END


        private void Form1_Load(object sender, EventArgs e)
        {
            // Adding Items in the measurement combobox. (CyclicVoltammetry, DifferentialPulse, and ImpedimetricMethod)
            measurement_type.Items.Add("Please Select");
            measurement_type.Items.Add(CyclicVoltammetry.Name);
            measurement_type.Items.Add(DifferentialPulse.Name);
            measurement_type.Items.Add(ImpedimetricMethod.Name);
            measurement_type.SelectedIndex = 0;

            // Define a dictionary to store the conversion factors for each combination of units
            _conversionFactors.Add("ppb", new Dictionary<string, double> { { "M", 1000000 }, { "mM", 1000 }, { "mg/L", 1000 }, { "μM", 1 }, { "nM", 1 / 1000 } });
            _conversionFactors.Add("ppm", new Dictionary<string, double> { { "M", 1000 }, { "mM", 1 }, { "mg/L", 1 }, { "μM", 1 / 1000.0 }, { "nM", 1 / 1000000.0 } });
            _conversionFactors.Add("mg/L", new Dictionary<string, double> { { "M", 1000 }, { "ppm", 1 }, { "mM", 1 }, { "μM", 1 / 1000.0 }, { "nM", 1 / 1000000.0 } });
            _conversionFactors.Add("M", new Dictionary<string, double> { { "ppb", 1 / 1000000.0 }, { "ppm", 1 / 1000.0 }, { "mg/L", 1 } });
            _conversionFactors.Add("mM", new Dictionary<string, double> { { "ppb", 1 / 1000000.0 }, { "ppm", 1 }, { "mg/L", 1 } });
            _conversionFactors.Add("μM", new Dictionary<string, double> { { "ppm", 1 / 1000.0 }, { "ppb", 1 }, { "mg/L", 1 / 1000.0 } });
            _conversionFactors.Add("nM", new Dictionary<string, double> { { "ppm", 1 / 1000000.0 }, { "ppb", 1 / 1000.0 }, { "mg/L", 1 / 1000000.0 } });

            // PPM and Molarity units can be selected in the combo box
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

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (radioButton_NumberofMoles.Checked)
            {
                double molarMass, mass, numberofmoles;
                if (double.TryParse(textBox_NumberofMoles.Text, out numberofmoles) && double.TryParse(textBox_MolarMass.Text, out molarMass))
                {
                    mass = molarMass * numberofmoles;
                    textBox_Mass.Text = mass.ToString("0.000");
                }

            }
        }

        // Grams to Mole Calculator
        /* Chemical Combination Selection */
        private void comboBox_Chemical_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected_type = comboBox_Chemical.Text;

            comboBox_Chemical_Select.Items.Clear();
            foreach (Chemical_Combinations cc in _cc)
            {
                if (cc.Type.Equals(selected_type))
                {
                    comboBox_Chemical_Select.Items.Add(cc.Name);
                }
            }
            textBox_MolarMass.Text = " ";
            textBox_Mass.Text = " ";
            textBox_NumberofMoles.Text = " ";
            textBox_MolarMass.ReadOnly = true;
            comboBox_Chemical_Select.Enabled = true;
        }
        private void comboBox_Chemical_Select_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedChemical = comboBox_Chemical_Select.SelectedItem.ToString();
            float molarMass = 0;

            foreach (Chemical_Combinations cc in _cc)
            {
                if (cc.Name.Equals(selectedChemical))
                {
                    molarMass = cc.MolarMass;
                    textBox_MolarMass.Text = " ";
                    textBox_Mass.Text = " ";
                    textBox_NumberofMoles.Text = " ";
                    break;
                }
            }
            textBox_MolarMass.Text = molarMass.ToString();
        }


        /* input selection */
        private void radioButton_Mass_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Mass.Checked)
            {
                textBox_NumberofMoles.Text = " ";
                textBox_Mass.Text = " ";
                textBox_NumberofMoles.ReadOnly = true;
                textBox_Mass.ReadOnly = false;
            }
        }
        private void radioButton_NumberofMoles_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_NumberofMoles.Checked)
            {
                textBox_NumberofMoles.Text = " ";
                textBox_Mass.Text = " ";
                textBox_Mass.ReadOnly = true;
                textBox_NumberofMoles.ReadOnly = false;
            }
        }

        /* Calculation */
        private void textBox_Mass_TextChanged(object sender, EventArgs e)
        {
            string text = textBox_Mass.Text;
            string filteredText = new string(text.Where(c => char.IsDigit(c) || c == '.').ToArray());

            // Ensure that there's only one decimal point in the filtered text
            int count = filteredText.Count(c => c == '.');
            if (count > 1)
            {
                int lastIndex = filteredText.LastIndexOf('.');
                filteredText = filteredText.Remove(lastIndex, 1);
            }

            textBox_Mass.Text = filteredText;
            textBox_Mass.SelectionStart = filteredText.Length;

            if (radioButton_Mass.Checked)
            {
                double molarMass, mass, numberofmoles;
                if (double.TryParse(textBox_MolarMass.Text, out molarMass) && double.TryParse(textBox_Mass.Text, out mass))
                {
                    numberofmoles = mass / molarMass;

                    textBox_NumberofMoles.Text = numberofmoles.ToString("0.000");
                }
            }
        }

        /* Reset Button */
        private void btnReset_GramsToMoleCalc_Click(object sender, EventArgs e)
        {
            textBox_MolarMass.Text = " ";
            textBox_Mass.Text = " ";
            textBox_NumberofMoles.Text = " ";
            textBox_MolarMass.ReadOnly = true;
            comboBox_Chemical_Select.Enabled = false;
            comboBox_Chemical_Select.Text = " ";
            comboBox_Chemical.Text = " ";
        }
        // Grams to Mole Calculator END


        // pH - pOH Calculator
        /* H+ */
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_H.Checked)
            {
                textBox_H.ReadOnly = false;
                textBox_OH.ReadOnly = true;
            }
            else
            {
                textBox_OH.ReadOnly = false;
                textBox_H.ReadOnly = true;
            }
            textBox_OH.Text = string.Empty;
            textBox_pH.Text = string.Empty;
            textBox_pOH.Text = string.Empty;
        }
        /* OH- */
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_H.Checked)
            {
                textBox_H.ReadOnly = false;
                textBox_OH.ReadOnly = true;
            }
            else
            {
                textBox_OH.ReadOnly = false;
                textBox_H.ReadOnly = true;
            }

            textBox_H.Text = string.Empty;
            textBox_pH.Text = string.Empty;
            textBox_pOH.Text = string.Empty;
        }

        private void textBox_H_TextChanged(object sender, EventArgs e)
        {
            string text = textBox_H.Text;
            string filteredText = new string(text.Where(c => char.IsDigit(c) || c == '.').ToArray());

            // Ensure that there's only one decimal point in the filtered text
            int count = filteredText.Count(c => c == '.');
            if (count > 1)
            {
                int lastIndex = filteredText.LastIndexOf('.');
                filteredText = filteredText.Remove(lastIndex, 1);
            }

            textBox_H.Text = filteredText;
            textBox_H.SelectionStart = filteredText.Length;
            double H;
            if (double.TryParse(textBox_H.Text, out H) && H > 1)
            {
                MessageBox.Show("H+ concentration cannot be greater than 1.");
                textBox_H.Text = string.Empty;
            }
            else
            {
                CalculateResult();
            }
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            string text = textBox_OH.Text;
            string filteredText = new string(text.Where(c => char.IsDigit(c) || c == '.').ToArray());

            // Ensure that there's only one decimal point in the filtered text
            int count = filteredText.Count(c => c == '.');
            if (count > 1)
            {
                int lastIndex = filteredText.LastIndexOf('.');
                filteredText = filteredText.Remove(lastIndex, 1);
            }

            textBox_OH.Text = filteredText;
            textBox_OH.SelectionStart = filteredText.Length;

            double OH;
            if (double.TryParse(textBox_OH.Text, out OH) && OH > 1)
            {
                MessageBox.Show("OH- concentration cannot be greater than 1.");
                textBox_OH.Text = string.Empty;
            }
            else
            {
                CalculateResult();
            }
        }
        private void CalculateResult()
        {
            try
            {
                double H, OH, pH, pOH;
                if (textBox_H.Text != string.Empty)
                {
                    H = double.Parse(textBox_H.Text);
                    pH = -(Math.Log10(H));
                    textBox_pH.Text = pH.ToString("0.000");
                    pOH = 14 - pH;
                    textBox_pOH.Text = pOH.ToString("0.000");
                }
                else if (textBox_OH.Text != string.Empty)
                {
                    OH = double.Parse(textBox_OH.Text);
                    pOH = -Math.Log10(OH);
                    textBox_pOH.Text = pOH.ToString("0.000");
                    pH = 14 - pOH;
                    textBox_pH.Text = pH.ToString("0.000");
                }
            }
            catch
            {

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            radioButton_H.Checked = false;
            radioButton_OH.Checked = false;
            textBox_OH.Text = " ";
            textBox_pOH.Text = " ";
            textBox_H.Text = " ";
            textBox_pH.Text = " ";
            textBox_OH.ReadOnly = true;
            textBox_H.ReadOnly = true;
        }
        // pH - pOH Calculator END



        // ppm Calculator
        private void radioButton_ppm_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_ppm.Checked)
            {
                textBox_ppm.ReadOnly = true;
                textBox_Molarity.ReadOnly = false;
                textBox_MolarMass_ppm.ReadOnly = false;
            }
        }

        private void radioButton_molarmass_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_molarmass.Checked)
            {
                textBox_ppm.ReadOnly = false;
                textBox_MolarMass_ppm.ReadOnly = true;
                textBox_Molarity.ReadOnly = false;
            }
        }

        private void radioButton_molarity_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_molarity.Checked)
            {
                textBox_ppm.ReadOnly = false;
                textBox_MolarMass_ppm.ReadOnly = false;
                textBox_Molarity.ReadOnly = true;
            }
        }

        private void comboBox_ppm_unit_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedUnit = comboBox_ppm_unit.SelectedItem.ToString();
            string ppm2 = textBox_ppm.Text;
            string molarmass2 = textBox_MolarMass_ppm.Text;
            string molarity2 = textBox_Molarity.Text;

            double ppm, molarity, molarmass;

            try
            {
                ppm = double.Parse(ppm2);
                molarity = double.Parse(molarity2);
                molarmass = double.Parse(molarmass2);

                if (selectedUnit == "ppm")
                {
                    ppm = molarity * molarmass * 1000.0;
                    textBox_ppm.Text = ppm.ToString("0.000000");

                }
                else if (selectedUnit == "mg/L")
                {
                    ppm = molarity * molarmass * 1000.0;
                    textBox_ppm.Text = ppm.ToString("0.000000");

                }
                else if (selectedUnit == "ppb")
                {
                    ppm = molarity * molarmass * 1000000.0;
                    textBox_ppm.Text = ppm.ToString("0.000000");

                }
            }
            catch (FormatException ex) { }
        }

        private void comboBox_molarity_unit_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedUnit = comboBox_molarity_unit.SelectedItem.ToString();
            string ppm2 = textBox_ppm.Text;
            string molarmass2 = textBox_MolarMass_ppm.Text;
            string molarity2 = textBox_Molarity.Text;

            double ppm, molarity, molarmass;

            try
            {
                ppm = double.Parse(ppm2);
                molarity = double.Parse(molarity2);
                molarmass = double.Parse(molarmass2);

                if (selectedUnit == "M")
                {
                    molarity = ppm / molarmass / 1000.0;
                    textBox_Molarity.Text = molarity.ToString("0.000000");
                }
                else if (selectedUnit == "mM")
                {
                    molarity = ppm / molarmass;
                    textBox_Molarity.Text = molarity.ToString("0.000000");
                }
                else if (selectedUnit == "μM")
                {
                    molarity = ppm / molarmass * 1000.0;
                    textBox_Molarity.Text = molarity.ToString("0.000000");
                }
                else if (selectedUnit == "nM")
                {
                    molarity = ppm / molarmass * 1000000.0;
                    textBox_Molarity.Text = molarity.ToString("0.000000");
                }
            }
            catch (FormatException ex) { }
        }

        private void PpmCalculator()
        {
            // Get the selected units and conversion factor from the dictionary
            string selectedUnit = comboBox_ppm_unit.SelectedItem.ToString();
            string selectedUnit2 = comboBox_molarity_unit.SelectedItem.ToString();
            double conversionFactor = _conversionFactors[selectedUnit][selectedUnit2];

            try
            {
                double molarity, ppm, molarMass;
                if (radioButton_molarity.Checked)
                {
                    if (double.TryParse(textBox_MolarMass_ppm.Text, out molarMass) && double.TryParse(textBox_ppm.Text, out ppm))
                    {
                        molarity = ppm / molarMass / conversionFactor;
                        textBox_Molarity.Text = molarity.ToString("0.000000");
                    }
                }
                else if (radioButton_ppm.Checked)
                {
                    if (double.TryParse(textBox_MolarMass_ppm.Text, out molarMass) && double.TryParse(textBox_Molarity.Text, out molarity))
                    {
                        ppm = molarity * molarMass * conversionFactor;
                        textBox_ppm.Text = ppm.ToString("0.000000");
                    }
                }
                else if (radioButton_molarmass.Checked)
                {
                    if (double.TryParse(textBox_ppm.Text, out ppm) && double.TryParse(textBox_Molarity.Text, out molarity))
                    {
                        molarMass = ppm / molarity / conversionFactor;
                        textBox_MolarMass_ppm.Text = molarMass.ToString("0.000000");
                    }
                }

            }
            catch (Exception ex) { }
        }

        private void textBox_ppm_TextChanged(object sender, EventArgs e)
        {
            PpmCalculator();
        }

        private void textBox_MolarMass_ppm_TextChanged(object sender, EventArgs e)
        {
            PpmCalculator();
        }

        private void textBox_Molarity_TextChanged(object sender, EventArgs e)
        {
            PpmCalculator();
        }

        private void button_reset_ppm_Click(object sender, EventArgs e)
        {
            textBox_ppm.ReadOnly = false; textBox_Molarity.ReadOnly = false; textBox_MolarMass_ppm.ReadOnly = false;
            textBox_ppm.Text = ""; textBox_Molarity.Text = ""; textBox_MolarMass_ppm.Text = "";
            comboBox_ppm_unit.SelectedIndex = 0; comboBox_molarity_unit.SelectedIndex = 0;
            radioButton_ppm.Checked = false; radioButton_molarity.Checked = false; radioButton_molarmass.Checked = false;
        }
        // ppm Calculator END


        // Solution Dialution Calculator
        private void rbInitConc_CheckedChanged(object sender, EventArgs e)
        {
            if (rbInitConc.Checked)
            {
                tbInitConc.ReadOnly = true; tbInitVol.ReadOnly = false; tbFinConc.ReadOnly = false; tbFinVol.ReadOnly = false;
                tbInitConc.Text = string.Empty;
            }
        }

        private void rbInitVol_CheckedChanged(object sender, EventArgs e)
        {
            if (rbInitVol.Checked)
            {
                tbInitVol.ReadOnly = true; tbInitConc.ReadOnly = false; tbFinConc.ReadOnly = false; tbFinVol.ReadOnly = false;
                tbInitVol.Text = string.Empty;
            }
        }

        private void rbFinConc_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFinConc.Checked)
            {
                tbFinConc.ReadOnly = true; tbInitVol.ReadOnly = false; tbInitConc.ReadOnly = false; tbFinVol.ReadOnly = false;
                tbFinConc.Text = string.Empty;
            }
        }

        private void rbFinVol_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFinVol.Checked)
            {
                tbFinVol.ReadOnly = true; tbInitVol.ReadOnly = false; tbInitConc.ReadOnly = false; tbFinConc.ReadOnly = false;
                tbFinVol.Text = string.Empty;
            }
        }


        private void SolDilCalc()
        {
            double InitConc, InitVol, FinConc, FinVol;
            if (rbInitConc.Checked)
            {
                if (double.TryParse(tbInitVol.Text, out InitVol) && double.TryParse(tbFinConc.Text, out FinConc) && double.TryParse(tbFinVol.Text, out FinVol))
                {
                    InitConc = (FinConc * FinVol) / InitVol;
                    tbInitConc.Text = InitConc.ToString("0.00000");
                }
            }
            else if (rbInitVol.Checked)
            {
                if (double.TryParse(tbInitConc.Text, out InitConc) && double.TryParse(tbFinConc.Text, out FinConc) && double.TryParse(tbFinVol.Text, out FinVol))
                {
                    InitVol = (FinConc * FinVol) / InitConc;
                    tbInitVol.Text = InitVol.ToString("0.00000");
                }
            }
            else if (rbFinConc.Checked)
            {
                if (double.TryParse(tbInitConc.Text, out InitConc) && double.TryParse(tbInitVol.Text, out InitVol) && double.TryParse(tbFinVol.Text, out FinVol))
                {
                    FinConc = (InitConc * InitVol) / FinVol;
                    tbFinConc.Text = FinConc.ToString("0.00000");
                }
            }
            else if (rbFinVol.Checked)
            {
                if (double.TryParse(tbInitConc.Text, out InitConc) && double.TryParse(tbFinConc.Text, out FinConc) && double.TryParse(tbInitVol.Text, out InitVol))
                {
                    FinVol = (InitConc * InitVol) / FinConc;
                    tbFinVol.Text = FinVol.ToString("0.00000");
                }
            }
        }

        private void tbInitConc_TextChanged(object sender, EventArgs e) => SolDilCalc();
        private void tbInitVol_TextChanged(object sender, EventArgs e) => SolDilCalc();
        private void tbFinConc_TextChanged(object sender, EventArgs e) => SolDilCalc();
        private void tbFinVol_TextChanged(object sender, EventArgs e) => SolDilCalc();

        private void button6_Click(object sender, EventArgs e)
        {
            rbInitConc.Checked = false; rbFinConc.Checked = false; rbInitVol.Checked = false; rbFinVol.Checked = false;
            tbInitConc.ReadOnly = false; tbInitVol.ReadOnly = false; tbFinConc.ReadOnly = false; tbFinVol.ReadOnly = false;
            tbInitConc.Text = string.Empty; tbInitVol.Text = string.Empty; tbFinConc.Text = string.Empty; tbFinVol.Text = string.Empty;
        }
        // Solution Dialution Calculator END

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
            if (_selectedMethod != null)
            {
                btnSaveSetting.Enabled = true;
            }
            else
            {
                btnSaveSetting.Enabled = false;
            }

            _measurementSettings.Title = (string) measurement_type.SelectedItem;
            _measurementSettings.SelectedMethod = _selectedMethod;
        }

        private void btnSaveSetting_Click(object sender, EventArgs e)
        {
            _measurementSettings.ShowDialog();
        }



        // MEASUREMENT DATA GRID
        private void InitDataGridView()
        {
            dgvMeasurement.Rows.Clear();
            dgvMeasurement.Columns.Clear();

            DataGridViewTextBoxColumn dgvColID = new DataGridViewTextBoxColumn();
            dgvColID.HeaderText = "ID";
            dgvColID.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvColID.ReadOnly = true;

            DataGridViewTextBoxColumn dgvColPotential = new DataGridViewTextBoxColumn();
            dgvColPotential.HeaderText = "Potential (V)";
            dgvColPotential.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvColPotential.ReadOnly = true;

            DataGridViewTextBoxColumn dgvColCurrent = new DataGridViewTextBoxColumn();
            dgvColCurrent.HeaderText = "Current (µA)";
            dgvColCurrent.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvColCurrent.ReadOnly = true;

            dgvMeasurement.Columns.Add(dgvColID);
            dgvMeasurement.Columns.Add(dgvColPotential);
            dgvMeasurement.Columns.Add(dgvColCurrent);
        }

        private void btnMeasure_Click(object sender, EventArgs e)
        {
            if (psCommSimpleWinForms1.DeviceState == PalmSens.Comm.CommManager.DeviceState.Idle)
            {
                _measurementData.Clear();
                InitDataGridView();
                try
                {
                    _activeMeasurement = psCommSimpleWinForms1.Measure(_selectedMethod);
                }
                catch (Exception ex)
                {
                    lbConsole.Items.Add(ex.Message);
                }
            }
            else
            {
                try
                {
                    if (psCommSimpleWinForms1.EnableBluetooth)
                        psCommSimpleWinForms1.AbortMeasurementAsync();
                    else
                        psCommSimpleWinForms1.AbortMeasurement(); //Abort the active measurement
                }
                catch (Exception ex)
                {
                    lbConsole.Items.Add(ex.Message);
                }
            }
        }

        private void psCommSimpleWinForms1_StateChanged(object sender, PalmSens.Comm.CommManager.DeviceState CurrentState)
        {
            tbDeviceStatus.Text = CurrentState.ToString(); 
            btnConnect.Enabled = CurrentState == PalmSens.Comm.CommManager.DeviceState.Idle;
            btnMeasure.Text = CurrentState == PalmSens.Comm.CommManager.DeviceState.Idle ? "Measure" : "Abort";
        }


        private void psCommSimpleWinForms1_MeasurementStarted(object sender, EventArgs e)
        {
            lbConsole.Items.Add("Linear sweep voltammetry measurement started.");
        }
        private void psCommSimpleWinForms1_MeasurementEnded(object sender, Exception e)
        {
            lbConsole.Items.Add("Measurement ended.");


            _allMeasurements.Add($"plot{plotNumber}", new List<List<double>>(_measurementData));
            plotNumber++;
        }

        private void psCommSimpleWinForms1_SimpleCurveStartReceivingData(object sender, SimpleCurve activeSimpleCurve)
        {
            //Subscribe to the curve's events to receive updates when new data is available and when it iss finished receiving data
            activeSimpleCurve.NewDataAdded += activeSimpleCurve_NewDataAdded;
            plot.AddSimpleCurve(activeSimpleCurve);
            activeSimpleCurve.CurveFinished += activeSimpleCurve_CurveFinished;

            lbConsole.Items.Add("Curve is receiving new data...");
        }

        private void activeSimpleCurve_NewDataAdded(object sender, PalmSens.Data.ArrayDataAddedEventArgs e)
        {
            SimpleCurve activeSimpleCurve = sender as SimpleCurve;
            int startIndex = e.StartIndex; //The index of the first new data point added to the curve
            int count = e.Count; //The number of new data points added to the curve

            for (int i = startIndex; i < startIndex + count; i++)
            {
                double xValue = activeSimpleCurve.XAxisValue(i); //Get the value on Curve's X-Axis (potential) at the specified index
                double yValue = activeSimpleCurve.YAxisValue(i); //Get the value on Curve's Y-Axis (current) at the specified index
                dgvMeasurement.Rows.Add(1);
                dgvMeasurement.Rows[i].Cells[0].Value = (i + 1).ToString();
                dgvMeasurement.Rows[i].Cells[1].Value = xValue.ToString("F2");
                dgvMeasurement.Rows[i].Cells[2].Value = yValue.ToString("E3");

                _measurementData.Add(new List<double> { (i + 1), xValue, yValue });
            }

            //tbPotential.Text = activeSimpleCurve.XAxisValue(startIndex + count - 1).ToString("F3");
            //tbCurrent.Text = activeSimpleCurve.YAxisValue(startIndex + count - 1).ToString("F3");
        }

        private void activeSimpleCurve_CurveFinished(object sender, EventArgs e)
        {
            SimpleCurve activeSimpleCurve = sender as SimpleCurve;

            //Unsubscribe from the curves events to avoid memory leaks
            activeSimpleCurve.NewDataAdded -= activeSimpleCurve_NewDataAdded;
            activeSimpleCurve.CurveFinished -= activeSimpleCurve_CurveFinished;

            int nDataPointsReceived = activeSimpleCurve.NDataPoints;
            lbConsole.Items.Add($"{nDataPointsReceived} data point(s) received.");

            lbConsole.Items.Add("Curve Finished");
        }


        private void psCommSimpleWinForms1_ReceiveStatus(object sender, PalmSens.Comm.StatusEventArgs e)
        {
            PalmSens.Comm.Status status = e.GetStatus(); //Get the PalmSens.Comm.Status instance from the event data
            double potential = status.PotentialReading.Value; //Get the potential
            double currentInRange = status.CurrentReading.ValueInRange; //Get the current expressed inthe active current range
            PalmSens.Comm.ReadingStatus currentStatus = status.CurrentReading.ReadingStatus; //Get the status of the current reading
            CurrentRange cr = status.CurrentReading.CurrentRange; //Get the active current range

            tbPotential.Text = potential.ToString("F3");
            tbCurrent.Text = currentInRange.ToString("F3");

            switch (currentStatus)
            {
                case PalmSens.Comm.ReadingStatus.OK:
                    tbCurrent.ForeColor = Color.Black;
                    break;
                case PalmSens.Comm.ReadingStatus.Overload:
                    tbCurrent.ForeColor = Color.Red;
                    break;
                case PalmSens.Comm.ReadingStatus.Underload:
                    tbCurrent.ForeColor = Color.Yellow;
                    break;
            }
            lblCurrentRange.Text = $"* {cr.ToString()}";

        }


        private void psCommSimpleWinForms1_Disconnected(object sender, Exception exception)
        {
            if (exception != null)
            {
                lbConsole.Items.Add(exception.Message);
            }

            lbConsole.Items.Add("Disconnected.");
            btnConnect.Text = "Connect";
            btnConnect.Enabled = true;
            btnMeasure.Text = "Measure";
        }



        // Plot Side ****

        private void InitPlot()
        {
            plot.ClearAll(); //Clear all curves and data from plot
            //Set the Axis labels
            plot.XAxisLabel = "V";
            plot.YAxisLabel = "µA";
            plot.AddData("", new double[0], new double[0]); //Add a empty data array to draw an empty plot
        }

        private void clearPlotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            plot.ClearAll();
        }

        private void clearMeasureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvMeasurement.Rows.Clear();
        }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            plot.ClearAll();
            dgvMeasurement.Rows.Clear();
        }

        // **************



        // DataGridView Operations:
        string folderName = null;
        private void btnDataViewSave_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            folderBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop;
            folderBrowserDialog.Description = "Save Excel File";


            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                folderName = folderBrowserDialog.SelectedPath;
                string fileName = "PalmSens4 Measurement (" + DateTime.Now.ToString("MM-dd-yyyy-h-mm-tt") + ").xlsx";
                string filePathName = Path.Combine(folderName, fileName);

                if (_fileIO.SaveDataToExcel(filePathName, _allMeasurements))
                {
                    lbConsole.Items.Add($"Measurements successfuly saved to {filePathName}");
                }
                else
                {
                    lbConsole.Items.Add("An error occured when saving measurements");
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|Excel Files (*.xls)|*.xls";
            openFileDialog.Title = "Load Excel File";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePathName = openFileDialog.FileName;
                
                _allMeasurements.Clear();
                _allMeasurements = _fileIO.LoadDataFromExcel(filePathName);

                if (_allMeasurements == null)
                {
                    _allMeasurements = new Dictionary<string, List<List<double>>>();
                    lbConsole.Items.Add("An error occured while the file loading.");
                }
                else
                {
                    lbConsole.Items.Add("File loaded successfully.");
                    DisplayLoadedData();
                    lbConsole.Items.Add("Data table created.");
                }

            }
        }

        private void DisplayLoadedData()
        {
            InitDataGridView();
            plot.ClearAll();
            List<double> potentials = new List<double>();
            List<double> currents = new List<double>();

            bool isFirst = true;
            foreach (var item in _allMeasurements)
            {
                for (int i = 0; i < item.Value.Count; i++)
                {
                    if (isFirst)
                    {
                        dgvMeasurement.Rows.Add(1);
                        dgvMeasurement.Rows[i].Cells[0].Value = item.Value[i][0].ToString();
                        dgvMeasurement.Rows[i].Cells[1].Value = item.Value[i][1].ToString("F2");
                        dgvMeasurement.Rows[i].Cells[2].Value = item.Value[i][2].ToString("E3");
                    }

                    potentials.Add(item.Value[i][1]);
                    currents.Add(item.Value[i][2]);
                }

                plot.AddData(item.Key, new List<double>(potentials).ToArray(), new List<double>(currents).ToArray());
                isFirst = false;
                potentials.Clear();
                currents.Clear();
            }

        }

        private void clearPlotToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            plot.ClearAll();
        }

        private void clearMeasureToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            InitDataGridView();
        }

        private void clearAllToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            plot.ClearAll();
            InitDataGridView();

        }


        // Export Options :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        private void imageGraphExport_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            folderBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop;
            folderBrowserDialog.Description = "Save Excel File";


            try
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    folderName = folderBrowserDialog.SelectedPath;
                    string fn = "Graph (" + DateTime.Now.ToString("MM-dd-yyyy-h-mm-tt") + ").png";
                    string filePathName = Path.Combine(folderName, fn);

                    Bitmap bitmap = new Bitmap(plot.Width, plot.Height);
                    plot.DrawToBitmap(bitmap, new Rectangle(0, 0, plot.Width, plot.Height));
                    bitmap.Save(filePathName, System.Drawing.Imaging.ImageFormat.Png);
                    bitmap.Dispose();
                    lbConsole.Items.Add($"Graph exported as {filePathName}");
                }
            }
            catch
            {
                lbConsole.Items.Add($"Graph couldn't export as .png format");
            }
        }

        private void graphTxtExport_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            folderBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop;
            folderBrowserDialog.Description = "Save Excel File";


            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    folderName = folderBrowserDialog.SelectedPath;
                    string fn = "Graph (" + DateTime.Now.ToString("MM-dd-yyyy-h-mm-tt") + ").txt";
                    string filePathName = Path.Combine(folderName, fn);

                    using (StreamWriter writer = new StreamWriter(filePathName))
                    {
                        foreach (var item in _allMeasurements)
                        {
                            writer.WriteLine(item.Key);

                            for (int i = 0; i < item.Value.Count; i++)
                            {
                                writer.WriteLine(item.Value[i][0].ToString() + "\t" + item.Value[i][1].ToString() + "\t" + item.Value[i][2].ToString());
                            }

                            writer.WriteLine();
                            writer.WriteLine();
                        }
                    }

                    lbConsole.Items.Add($"Graph exported as {filePathName}");
                }
                catch
                {
                    lbConsole.Items.Add($"Graph couldn't export as .txt format");
                }

            }
        }

        // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::






        // *************************

    }

}
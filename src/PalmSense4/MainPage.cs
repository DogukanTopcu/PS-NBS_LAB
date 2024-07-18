using PalmSens;
using PalmSens.Comm;
using PalmSens.Core.Simplified.Data;
using PalmSens.Core.Simplified.WinForms;
using PalmSens.Devices;
using PalmSens.Techniques;
using PalmSense4.Business;
using PalmSense4.components;
using PalmSense4.data.Measurement_Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        public static CyclicVoltammetry _methodCLV = new CyclicVoltammetry();
        public static DifferentialPulse _methodDLP = new DifferentialPulse();
        public static ImpedimetricMethod _methodIMM = new ImpedimetricMethod();
        public static Method _selectedMethod;

        private Measurement_Settings _measurementSettings;
        private CyclicVoltammetry_Settings _cvSettings;
        private DifferentialPulse_Settings _dpSettings;
        private ImpedimetricMethod_Settings _impSettings;
        public static bool saveInternalStorage;


        // Calculators
        private GramsToMoleCalc gtmCalc;
        private PH_POH_Calculator pH_pOH;
        private PpmCalculator ppmCalc;
        private SolutionDiluationCalc solDiluationCalc;


        // Measurement Data 
        private List<List<double>> _measurementData;
        private Dictionary<string, List<List<double>>> _allMeasurements;
        private int plotNumber;

        private FileIO _fileIO;


        // CONSTRUCTORS *************************************************************************
        public MainPage()
        {
            InitializeComponent();
            this._connectedDevices = new Device[0];

            DiscoverConnectedDevices();

            _selectedMethod = _methodCLV;

            _cvSettings = new CyclicVoltammetry_Settings(_methodCLV);
            _dpSettings = new DifferentialPulse_Settings(_methodDLP);
            _impSettings = new ImpedimetricMethod_Settings(_methodIMM);
            _measurementSettings = new Measurement_Settings(_cvSettings, _dpSettings, _impSettings);
            saveInternalStorage = saveSettingsInInternalStorage.Checked;


            _measurementData = new List<List<double>>();
            _allMeasurements = new Dictionary<string, List<List<double>>>();
            plotNumber = 1;

            _fileIO = new FileIO();
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

        private void psCommSimpleWinForms_MeasurementStarted(object sender, EventArgs e)
        {
            lbConsole.Items.Add("Linear sweep voltammetry measurement started.");
        }
        private void psCommSimpleWinForms_MeasurementEnded(object sender, Exception e)
        {
            lbConsole.Items.Add("Measurement ended.");


            _allMeasurements.Add($"plot{plotNumber}", new List<List<double>>(_measurementData));
            plotNumber++;
        }


        private void psCommSimpleWinForms_SimpleCurveStartReceivingData(object sender, SimpleCurve activeSimpleCurve)
        {
            //Subscribe to the curve's events to receive updates when new data is available and when it iss finished receiving data
            activeSimpleCurve.NewDataAdded += activeSimpleCurve_NewDataAdded;
            plot.AddSimpleCurve(activeSimpleCurve);
            activeSimpleCurve.CurveFinished += activeSimpleCurve_CurveFinished;

            lbConsole.Items.Add("Curve is receiving new data...");
        }

        // BUILT-IN FUNCTIONS FOR psCommSimpleWinForm ***********************************************


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

                    pretreatmentSettings1.loadCLVPretreatmentSettings();
                    currentRangeSettings1.loadCLVCurrentRange();
                    break;
                case DifferentialPulse.Name:
                    _selectedMethod = _methodDLP;
                    
                    cvSettings1.Visible = false;
                    dpSettings1.Visible = true;
                    isSettings1.Visible = false;

                    pretreatmentSettings1.loadDPPretreatmentSettings();
                    currentRangeSettings1.loadDPCurrentRange();
                    break;
                case ImpedimetricMethod.Name:
                    _selectedMethod = _methodIMM;

                    cvSettings1.Visible = false;
                    dpSettings1.Visible = false;
                    isSettings1.Visible = true;

                    pretreatmentSettings1.loadIMMPretreatmentSettings();
                    currentRangeSettings1.loadISCurrentRange();
                    break;
                default:
                    _selectedMethod = null;
                    break;
            }
        }



        

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

        private void saveSettingsInInternalStorage_CheckedChanged(object sender, EventArgs e)
        {
            saveInternalStorage = saveSettingsInInternalStorage.Checked;
        }


        // Measurement Button
        private void measurementBtn_ButtonClick(object sender, EventArgs e)
        {
            if (psCommSimpleWinForms.DeviceState == PalmSens.Comm.CommManager.DeviceState.Idle)
            {
                _measurementData.Clear();
                InitDataGridView();
                try
                {
                    _activeMeasurement = psCommSimpleWinForms.Measure(_selectedMethod);
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
                    if (psCommSimpleWinForms.EnableBluetooth)
                        psCommSimpleWinForms.AbortMeasurementAsync();
                    else
                        psCommSimpleWinForms.AbortMeasurement(); //Abort the active measurement
                }
                catch (Exception ex)
                {
                    lbConsole.Items.Add(ex.Message);
                }
            }
        }

        private void overlayRunBtn_Click(object sender, EventArgs e)
        {
            measurementBtn_ButtonClick(sender, e);
        }

        private void newRunBtn_Click(object sender, EventArgs e)
        {
            if (_measurementData.Count > 0)
            {
                var confirmResult = MessageBox.Show("Are you sure to delete this item ??",
                                         "Confirm Delete!!",
                                         MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    plot.ClearAll();
                    _measurementData.Clear();
                    measurementBtn_ButtonClick(sender, e);
                }
            }
            else
            {
                measurementBtn_ButtonClick(sender, e);
            }

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


        // Save Data
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

        // Load Data
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
    }
}

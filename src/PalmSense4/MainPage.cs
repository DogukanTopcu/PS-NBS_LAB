using Microsoft.Office.Interop.Excel;
using Newtonsoft.Json.Linq;
using OxyPlot;
using PalmSens;
using PalmSens.Comm;
using PalmSens.Core.Simplified.Data;
using PalmSens.Core.Simplified.WinForms;
using PalmSens.Devices;
using PalmSens.Techniques;
using PalmSense4.Business;
using PalmSense4.components;
using PalmSense4.data.Measurement_Settings;
using RJCodeAdvance.RJControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PalmSense4
{
    public partial class MainPage : Form
    {
        // Attributes
        private Device[] _connectedDevices;
        public static Device connectedDevice;
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
        private List<SimpleMeasurement> _simpleMeasurements;
        private int plotNumber;
        private FileIO _fileIO;

        private List<SimpleCurve> _allCurves;


        // SimpleCurve data
        private SimpleCurve _activeCurve;
        private SimpleCurve _baselineCurve;


        public static PSCommSimpleWinForms ps;
        public static System.Windows.Forms.ListBox lbox;
        public static RJButton btnConn;
        public static ToolStripSplitButton measureBtn;


        // CONSTRUCTORS *************************************************************************
        public MainPage()
        {
            InitializeComponent();
            FormClosing += MainPage_Colsing;

            this._connectedDevices = new Device[0];
            
            DiscoverConnectedDevices();
            InitPlot();

            _selectedMethod = _methodCLV;

            _cvSettings = new CyclicVoltammetry_Settings(_methodCLV);
            _dpSettings = new DifferentialPulse_Settings(_methodDLP);
            _impSettings = new ImpedimetricMethod_Settings(_methodIMM);
            _measurementSettings = new Measurement_Settings(_cvSettings, _dpSettings, _impSettings);
            saveInternalStorage = saveSettingsInInternalStorage.Checked;


            _measurementData = new List<List<double>>();
            _allMeasurements = new Dictionary<string, List<List<double>>>();
            _allCurves = new List<SimpleCurve>();
            _simpleMeasurements = new List<SimpleMeasurement>();
            plotNumber = 1;

            _fileIO = new FileIO();

            ps = psCommSimpleWinForms;
            lbox = lbConsole;
            btnConn = btnConnect;
            measureBtn = measurementBtn;
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            splitContainer2.IsSplitterFixed = true;
            splitContainer1.IsSplitterFixed = true;
            measurementBtn.Enabled = false;

            if (psCommSimpleWinForms.EnableBluetooth) btnBluetooth.BackgroundColor = Color.LightBlue;


            measurement_type.Items.Add(CyclicVoltammetry.Name);
            measurement_type.Items.Add(DifferentialPulse.Name);
            measurement_type.SelectedIndex = 0;


            if (_allCurves.Count == 0)
            {
                smoothCurveToolStripMenuItem.Enabled = false;
                detectPeaksToolStripMenuItem.Enabled = false;
                clearPlotToolStripMenuItem.Enabled = false;
            }
        }
        private void MainPage_Colsing(object sender, EventArgs e)
        {
            Console.WriteLine("Form Closinngg");
            if (pwm_duration.serialPort.IsOpen) pwm_duration.serialPort.Close();
        }
        // CONSTRUCTORS *************************************************************************


        // Initial Plot
        private void InitPlot()
        {
            plot.ClearAll(); //Clear all curves and data from plot
            //Set the Axis labels
            plot.XAxisLabel = "Potential/V";
            plot.YAxisLabel = "Current/µA";

            
            plot.AddData("", new double[0], new double[0]); //Add a empty data array to draw an empty plot
        }


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
                    connectedDevice = _connectedDevices[cmbDevices.SelectedIndex];
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

            regeneration.startBtn.Enabled = psCommSimpleWinForms.Connected;
        }

        // CONNECTION ***************************************************************************




        // BUILT-IN FUNCTIONS FOR psCommSimpleWinForm ***********************************************

        private void psCommSimpleWinForms_StateChanged(object sender, PalmSens.Comm.CommManager.DeviceState CurrentState)
        {
            status_statusbar.Text = "Status: " + CurrentState.ToString();

            btnConnect.Enabled = CurrentState == PalmSens.Comm.CommManager.DeviceState.Idle;
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
            regeneration.startBtn.Enabled = psCommSimpleWinForms.Connected;
            lbConsole.Items.Add("Disconnected.");
        }

        private void psCommSimpleWinForms_MeasurementStarted(object sender, EventArgs e)
        {
            lbConsole.Items.Add("Measurement started.");
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
            smoothCurveToolStripMenuItem.Enabled = false;
            detectPeaksToolStripMenuItem.Enabled = false;
            clearPlotToolStripMenuItem.Enabled = false;
            clearAllToolStripMenuItem.Enabled = false;
            filterToolStripMenuItem.Enabled = false;

            plot.AddSimpleCurve(activeSimpleCurve);
            plot.XAxisLabel = "Potential/V";
            plot.YAxisLabel = "Current/µA";

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

            _allCurves.Add(activeSimpleCurve);
            _activeCurve = activeSimpleCurve;

            string itemName = plotNumber + " " + activeSimpleCurve.FullTitle;

            // Smooth Curve
            smoothCurveToolStripMenuItem.Enabled = true;
            smoothCurveToolStripMenuItem.DropDownItems.Add(itemName, null, (sender2, e2) =>
            {
                smoothCurve(sender, e, activeSimpleCurve, itemName);
            });

            // Detect Peek
            detectPeaksToolStripMenuItem.Enabled = true;
            detectPeaksToolStripMenuItem.DropDownItems.Add(itemName, null, (sender3, e3) =>
            {
                detectPeek(sender, e, activeSimpleCurve, itemName);
            });

            // Clear Plot
            clearPlotToolStripMenuItem.Enabled = true;
            clearAllToolStripMenuItem.Enabled = true;
            clearPlotToolStripMenuItem.DropDownItems.Add(itemName, null, (sender4, e4) =>
            {
                clearPlot(sender, e, itemName, activeSimpleCurve);
            });


            // Filter Plot
            filterToolStripMenuItem.Enabled = true;
            filterToolStripMenuItem.DropDownItems.Add(itemName, null, (sender5, e5) =>
            {
                filterPlot(sender, e, activeSimpleCurve);
            });


            //Unsubscribe from the curves events to avoid memory leaks
            activeSimpleCurve.NewDataAdded -= activeSimpleCurve_NewDataAdded;
            activeSimpleCurve.CurveFinished -= activeSimpleCurve_CurveFinished;

            int nDataPointsReceived = activeSimpleCurve.NDataPoints;
            lbConsole.Items.Add($"{nDataPointsReceived} data point(s) received.");
            lbConsole.Items.Add("Curve Finished");
            try
            {
                _simpleMeasurements.Add(_activeMeasurement);
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.ToString());
            }
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
                        psCommSimpleWinForms.AbortMeasurement();
                    else
                        psCommSimpleWinForms.AbortMeasurement(); //Abort the active measurement
                }
                catch (Exception ex)
                {
                    lbConsole.Items.Add(ex.Message);
                }
            }

            tabControl2.SelectedTab = PlotArea;
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
            tabControl2.SelectedTab = dataArea;
        }

        
        private void smoothCurve(object sender, EventArgs e, SimpleCurve activeCurve, string name)
        {
            plot.RemoveSimpleCurve(activeCurve);
            SimpleCurve smoothedCurve = activeCurve.Smooth(SmoothLevel.High);

            lbConsole.Items.Add("Curve Smoothed: " + name);
            plot.AddSimpleCurve(smoothedCurve);

            _allCurves.Remove(activeCurve);
            _allCurves.Add(smoothedCurve);

            foreach (ToolStripMenuItem item in smoothCurveToolStripMenuItem.DropDownItems)
            {
                if (item.Text == name)
                {
                    item.Enabled = false;
                    item.Text = name + " (Smoothed)";
                    
                    foreach (ToolStripMenuItem peakItem in detectPeaksToolStripMenuItem.DropDownItems)
                    {
                        if (peakItem.Text == name || peakItem.Text == name + " (Detected)")
                        {
                            detectPeaksToolStripMenuItem.DropDownItems.Remove(peakItem);
                            detectPeaksToolStripMenuItem.DropDownItems.Add(item.Text, null, (sender3, e3) =>
                            {
                                detectPeek(sender, e, smoothedCurve, item.Text);
                            });
                            break;
                        }
                    }
                    foreach (ToolStripMenuItem removeItem in clearPlotToolStripMenuItem.DropDownItems)
                    {
                        if (removeItem.Text == name)
                        {
                            clearPlotToolStripMenuItem.DropDownItems.Remove(removeItem);
                            clearPlotToolStripMenuItem.DropDownItems.Add(item.Text, null, (sender3, e3) =>
                            {
                                clearPlot(sender, e, item.Text, smoothedCurve);
                            });
                            break;
                        }
                    }
                    foreach (ToolStripMenuItem filterItem in filterToolStripMenuItem.DropDownItems)
                    {
                        if (filterItem.Text == name)
                        {
                            filterToolStripMenuItem.DropDownItems.Remove(filterItem);
                            filterToolStripMenuItem.DropDownItems.Add(item.Text, null, (sender3, e3) =>
                            {
                                filterPlot(sender, e, smoothedCurve);
                            });
                            break;
                        }
                    }
                    break;
                }
            }
        }

        private void averageBaselineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Determine and plot the moving average baseline curve
            _baselineCurve = _activeCurve.MovingAverageBaseline();
            plot.AddSimpleCurve(_baselineCurve);

            lbConsole.Items.Add("SWV Example Curve Moving Average Baseline Determined.");
        }

        private void subtractBaselineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _activeCurve = _activeCurve.Subtract(_baselineCurve); //Replace the activeCurve reference with the result
            plot.AddSimpleCurve(_activeCurve);

            lbConsole.Items.Add("Baseline Curve Subtracted From SWV Example Curve.");
        }

        
        private void detectPeek(object sender, EventArgs e, SimpleCurve activeCurve, string name)
        {
            activeCurve.DetectPeaks();
            foreach (ToolStripMenuItem item in detectPeaksToolStripMenuItem.DropDownItems)
            {
                if (item.Text == name || item.Text == name + " (Smoothed)")
                {
                    item.Enabled = false;
                    item.Text = name + " (Detected)";
                }
            }
            lbConsole.Items.Add("Peak Detected: " + name);
        }
        private void allPlotsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (SimpleCurve curve in _allCurves)
            {
                curve.DetectPeaks();
            }

            bool isfirst = true;
            foreach (ToolStripMenuItem item in detectPeaksToolStripMenuItem.DropDownItems)
            {
                if (isfirst) { isfirst = false; continue; }
                item.Enabled = false;
                item.Text += " (Detected)";
            }
            lbConsole.Items.Add("All Peaks Detected");
        }

        private void clearPlot(object sender, EventArgs e, string name, SimpleCurve removingCurve)
        {
            foreach (ToolStripMenuItem item in clearPlotToolStripMenuItem.DropDownItems)
            {
                if (item.Text == name || item.Text == name + " (Smoothed)")
                {
                    plot.RemoveSimpleCurve(removingCurve);
                    _allCurves.Remove(removingCurve);
                    clearPlotToolStripMenuItem.DropDownItems.Remove(item);

                    foreach (ToolStripMenuItem peakItem in detectPeaksToolStripMenuItem.DropDownItems)
                    {
                        if (peakItem.Text == name || peakItem.Text == name + " (Detected)")
                        {
                            detectPeaksToolStripMenuItem.DropDownItems.Remove(peakItem);
                            if (detectPeaksToolStripMenuItem.DropDownItems.Count == 1) detectPeaksToolStripMenuItem.Enabled = false;
                            break;
                        }
                    }
                    foreach (ToolStripMenuItem smooothItem in smoothCurveToolStripMenuItem.DropDownItems)
                    {
                        if (smooothItem.Text == name)
                        {
                            smoothCurveToolStripMenuItem.DropDownItems.Remove(smooothItem);
                            if (smoothCurveToolStripMenuItem.DropDownItems.Count == 0) smoothCurveToolStripMenuItem.Enabled = false;
                            break;
                        }
                    }
                    foreach (ToolStripMenuItem filteredItem in filterToolStripMenuItem.DropDownItems)
                    {
                        if (filteredItem.Text == name)
                        {
                            filterToolStripMenuItem.DropDownItems.Remove(filteredItem);
                            if (filterToolStripMenuItem.DropDownItems.Count == 0) filterToolStripMenuItem.Enabled = false;
                            break;
                        }
                    }
                    if (clearPlotToolStripMenuItem.DropDownItems.Count == 0) { clearPlotToolStripMenuItem.Enabled = false; clearAllToolStripMenuItem.Enabled = false; filterToolStripMenuItem.Enabled = false; }
                    break;
                }
            }

            lbConsole.Items.Add("Plot Removed: " + name);
        }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            plot.ClearAll();
            _allCurves.Clear();
            detectPeaksToolStripMenuItem.DropDownItems.Clear();
            smoothCurveToolStripMenuItem.DropDownItems.Clear();
            clearPlotToolStripMenuItem.DropDownItems.Clear();

            smoothCurveToolStripMenuItem.Enabled = false;
            detectPeaksToolStripMenuItem.Enabled = false;
            clearPlotToolStripMenuItem.Enabled = false;
            clearAllToolStripMenuItem.Enabled = false;
            filterToolStripMenuItem.Enabled = false;
        }


        private void filterPlot(object sender, EventArgs e, SimpleCurve filteredCurve)
        {
            if (filteredCurve != null && plot.ContainsSimpleCurve(filteredCurve))
            {
                new FilteredPlot(filteredCurve).ShowDialog();
            }
        }


        // Export Functions
        private void xlsxFileToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void pssessionExport_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            folderBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop;
            folderBrowserDialog.Description = "Save Measurement";

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                folderName = folderBrowserDialog.SelectedPath;
                string fileName = "PalmSens4 Measurement (" + DateTime.Now.ToString("MM-dd-yyyy-h-mm-tt") + ").pssession";
                string filePathName = Path.Combine(folderName, fileName);

                if (_fileIO.SaveDataToPssession(filePathName, _simpleMeasurements))
                {
                    lbConsole.Items.Add($"Measurements successfully saved to {filePathName}");
                }
                else
                {
                    lbConsole.Items.Add("An error occurred when saving measurements");
                }
            }
        }

        // Export as Graph
        private void exportGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            folderBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop;
            folderBrowserDialog.Description = "Save Image";

            try
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    folderName = folderBrowserDialog.SelectedPath;
                    string fn = "Graph (" + DateTime.Now.ToString("MM-dd-yyyy-h-mm-tt") + ").png";
                    string filePathName = Path.Combine(folderName, fn);

                    Bitmap bitmap = new Bitmap(plot.Width, plot.Height);
                    plot.DrawToBitmap(bitmap, new System.Drawing.Rectangle(0, 0, plot.Width, plot.Height));
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

        private void importFrompssessionFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Pssession Files (*.pssession)|*.pssession";
            openFileDialog.Title = "Load Pssession File";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePathName = openFileDialog.FileName;

                _simpleMeasurements.Clear();
                _simpleMeasurements = _fileIO.LoadDataFromPssession(filePathName);

                if (_simpleMeasurements != null)
                {
                    lbConsole.Items.Add(".pssession file successfully loaded.");
                    DisplayPssessionLoadedData(sender, e);
                }
                else
                {
                    lbConsole.Items.Add("File empty...");
                    lbConsole.Items.Add("Please make sure the .pssession file is present in the project folder.");
                }
            }
        }

        private void DisplayPssessionLoadedData(object sender, EventArgs e)
        {
            int number = 0;
            foreach(SimpleMeasurement sm in _simpleMeasurements)
            {
                foreach (SimpleCurve sc in sm.SimpleCurveCollection)
                {
                    number++;
                    plot.AddSimpleCurve(sc);
                    InitDataGridView();
                    for (int i = 0; i < sc.XAxisValues.Length; i++)
                    {
                        _measurementData.Add(new List<double> { (i + 1), sc.XAxisValues[i], sc.YAxisValues[i] });

                        dgvMeasurement.Rows.Add(1);
                        dgvMeasurement.Rows[i].Cells[0].Value = (i + 1).ToString();
                        dgvMeasurement.Rows[i].Cells[1].Value = sc.XAxisValues[i].ToString("F2");
                        dgvMeasurement.Rows[i].Cells[2].Value = sc.YAxisValues[i].ToString("E3");

                    }
                    _allMeasurements.Add(sc.FullTitle + _allMeasurements.Count.ToString(), new List<List<double>>(_measurementData));
                    _allCurves.Add(sc);
                    _measurementData.Clear();

                    string itemName = number + " " + sc.FullTitle;

                    // Smooth Curve
                    smoothCurveToolStripMenuItem.Enabled = true;
                    smoothCurveToolStripMenuItem.DropDownItems.Add(itemName, null, (sender2, e2) =>
                    {
                        smoothCurve(sender, e, sc, itemName);
                    });

                    // Detect Peek
                    detectPeaksToolStripMenuItem.Enabled = true;
                    detectPeaksToolStripMenuItem.DropDownItems.Add(itemName, null, (sender3, e3) =>
                    {
                        detectPeek(sender, e, sc, itemName);
                    });

                    // Clear Plot
                    clearPlotToolStripMenuItem.Enabled = true;
                    clearAllToolStripMenuItem.Enabled = true;
                    clearPlotToolStripMenuItem.DropDownItems.Add(itemName, null, (sender4, e4) =>
                    {
                        clearPlot(sender, e, itemName, sc);
                    });


                    // Filter Plot
                    filterToolStripMenuItem.Enabled = true;
                    filterToolStripMenuItem.DropDownItems.Add(itemName, null, (sender5, e5) =>
                    {
                        filterPlot(sender, e, sc);
                    });
                }
            }
        }

        private void importFromxlsxFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnLoad_Click(sender, e);
        }

        private void regeneration1_Load(object sender, EventArgs e)
        {
            regeneration1.generateFunction(lbConsole);
        }

        private void regressionAnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new RegressionAnalysis(_allCurves).ShowDialog();
        }



        // Method Saving and Loading ###############################################################
        private void saveMethodAspssessionFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            folderBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop;
            folderBrowserDialog.Description = "Save Method";

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                folderName = folderBrowserDialog.SelectedPath;
                string fileName = "PalmSens4 Method (" + DateTime.Now.ToString("MM-dd-yyyy-h-mm-tt") + ").psmethod";
                string filePathName = Path.Combine(folderName, fileName);

                if (_fileIO.SaveMethodAsPssessionFile(filePathName, _selectedMethod))
                {
                    lbConsole.Items.Add($"Method successfully saved to {filePathName}");
                }
                else
                {
                    lbConsole.Items.Add("An error occurred when saving method");
                }
            }
        }

        private void loadMethodFrompssessionFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Psmethod Files (*.psmethod)|*.psmethod";
            openFileDialog.Title = "Load Method";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePathName = openFileDialog.FileName;

                _selectedMethod = _fileIO.LoadMethodAsPsssessionFile(filePathName);

                if (_selectedMethod != null)
                {
                    lbConsole.Items.Add(".psmethod file successfully loaded.");
                    SetupSettingsWithLoadedMethod();
                }
                else
                {
                    lbConsole.Items.Add("File is empty...");
                    lbConsole.Items.Add("Please make sure the .psmethod file is present in the project folder.");
                }
            }
        }


        private void SetupSettingsWithLoadedMethod()
        {
            if (_selectedMethod.ToString() == _methodCLV.ToString())
            {
                measurement_type.SelectedIndex = 0;
                measurement_type.SelectedItem = CyclicVoltammetry.Name;
                
                pretreatmentSettings1.loadCLVPretreatmentSettings(_selectedMethod);
                currentRangeSettings1.loadCLVCurrentRange(_selectedMethod);

                cvSettings1.LoadData((CyclicVoltammetry) _selectedMethod);
            }
            else if (_selectedMethod.ToString() == _methodDLP.ToString())
            {
                Console.WriteLine(_selectedMethod);
                measurement_type.SelectedIndex = 1;
                measurement_type.SelectedItem = DifferentialPulse.Name;

                pretreatmentSettings1.loadDPPretreatmentSettings(_selectedMethod);
                currentRangeSettings1.loadDPCurrentRange(_selectedMethod);

                dpSettings1.LoadData((DifferentialPulse) _selectedMethod);
            }
            else if (_selectedMethod == _methodIMM)
            {
                // YAPMA
            }
        }

        // #########################################################################################



        // Statusbar:
        private void importFrompssessionFileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            importFrompssessionFileToolStripMenuItem_Click(sender, e);
        }

        private void importFromxlsxFileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            btnLoad_Click(sender, e);
        }

        private void exportAspssessionFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pssessionExport_Click(sender, e);
        }

        private void exportAsxlsxFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            xlsxFileToolStripMenuItem_Click(sender, e);
        }

        private void exportGraphAsImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exportGraphToolStripMenuItem_Click(sender, e);
        }


        // Measurement
        private void downloadMeasurementDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            measurementBtn_ButtonClick(sender, e);
        }

        private void startWithNewPlotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newRunBtn_Click(sender, e);
        }

        private void exportsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void TSMILoadPeakLOD_Click(object sender, EventArgs e)
        {

        }

        private void PlotSettings_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        private void calculators1_Load(object sender, EventArgs e)
        {

        }
    }
}

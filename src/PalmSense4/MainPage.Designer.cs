namespace PalmSense4
{
    partial class MainPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.methodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMethodAspssessionFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadMethodFrompssessionFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importFrompssessionFileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.importFromxlsxFileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exportDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportAspssessionFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportAsxlsxFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportGraphAsImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.measurementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadMeasurementDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMeasurementDaaToLocalStorageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startWithNewPlotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.status_statusbar = new System.Windows.Forms.ToolStripStatusLabel();
            this.potential_statusbar = new System.Windows.Forms.ToolStripStatusLabel();
            this.current_statusbar = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel5 = new System.Windows.Forms.Panel();
            this.regeneration1 = new PalmSense4.components.regeneration();
            this.calculators1 = new PalmSense4.components.calculators();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lbConsole = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.connectionLabel = new System.Windows.Forms.Label();
            this.btnConnect = new RJCodeAdvance.RJControls.RJButton();
            this.btnBluetooth = new RJCodeAdvance.RJControls.RJButton();
            this.btnRefresh = new RJCodeAdvance.RJControls.RJButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDevices = new System.Windows.Forms.ComboBox();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.PlotArea = new System.Windows.Forms.TabPage();
            this.cv_dp_plot = new System.Windows.Forms.Panel();
            this.plot = new SDKPlot.WinForms.Plot();
            this.PlotSettings = new System.Windows.Forms.MenuStrip();
            this.plotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smoothCurveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detectPeaksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allPlotsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearPlotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regressionAnalysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMILoadPeakLOD = new System.Windows.Forms.ToolStripMenuItem();
            this.importFrompssessionFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importFromxlsxFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pssessionExport = new System.Windows.Forms.ToolStripMenuItem();
            this.xlsxFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.rjButton2 = new RJCodeAdvance.RJControls.RJButton();
            this.rjButton22 = new RJCodeAdvance.RJControls.RJButton();
            this.rjButton23 = new RJCodeAdvance.RJControls.RJButton();
            this.rjButton24 = new RJCodeAdvance.RJControls.RJButton();
            this.rjButton25 = new RJCodeAdvance.RJControls.RJButton();
            this.rjButton26 = new RJCodeAdvance.RJControls.RJButton();
            this.rjButton27 = new RJCodeAdvance.RJControls.RJButton();
            this.rjButton28 = new RJCodeAdvance.RJControls.RJButton();
            this.rjButton29 = new RJCodeAdvance.RJControls.RJButton();
            this.rjButton30 = new RJCodeAdvance.RJControls.RJButton();
            this.eisPlotArea = new System.Windows.Forms.TabPage();
            this.eisPlot = new SDKPlot.WinForms.Plot();
            this.dataArea = new System.Windows.Forms.TabPage();
            this.dgvMeasurement = new System.Windows.Forms.DataGridView();
            this.btnDataViewSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.section2_btn = new RJCodeAdvance.RJControls.RJButton();
            this.section1_btn = new RJCodeAdvance.RJControls.RJButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.saveSettingsInInternalStorage = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.pretreatmentSettings1 = new PalmSense4.components.pretreatmentSettings();
            this.isSettings1 = new PalmSense4.components.isSettings();
            this.dpSettings1 = new PalmSense4.components.dpSettings();
            this.cvSettings1 = new PalmSense4.components.cvSettings();
            this.label5 = new System.Windows.Forms.Label();
            this.currentRangeSettings1 = new PalmSense4.components.currentRangeSettings();
            this.btnRun = new System.Windows.Forms.ToolStrip();
            this.measurementBtn = new System.Windows.Forms.ToolStripSplitButton();
            this.newRunBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.overlayRunBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.measurement_type = new System.Windows.Forms.ComboBox();
            this.rjDropdownMenu1 = new RJCodeAdvance.RJControls.RJDropdownMenu(this.components);
            this.psCommSimpleWinForms = new PalmSens.Core.Simplified.WinForms.PSCommSimpleWinForms(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.PlotArea.SuspendLayout();
            this.cv_dp_plot.SuspendLayout();
            this.PlotSettings.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.eisPlotArea.SuspendLayout();
            this.dataArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeasurement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.btnRun.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.methodToolStripMenuItem,
            this.dataToolStripMenuItem,
            this.measurementToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1632, 36);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // methodToolStripMenuItem
            // 
            this.methodToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveMethodAspssessionFileToolStripMenuItem,
            this.loadMethodFrompssessionFileToolStripMenuItem});
            this.methodToolStripMenuItem.Name = "methodToolStripMenuItem";
            this.methodToolStripMenuItem.Size = new System.Drawing.Size(96, 32);
            this.methodToolStripMenuItem.Text = "Method";
            // 
            // saveMethodAspssessionFileToolStripMenuItem
            // 
            this.saveMethodAspssessionFileToolStripMenuItem.Name = "saveMethodAspssessionFileToolStripMenuItem";
            this.saveMethodAspssessionFileToolStripMenuItem.Size = new System.Drawing.Size(224, 32);
            this.saveMethodAspssessionFileToolStripMenuItem.Text = "Save Method";
            this.saveMethodAspssessionFileToolStripMenuItem.Click += new System.EventHandler(this.saveMethodAspssessionFileToolStripMenuItem_Click);
            // 
            // loadMethodFrompssessionFileToolStripMenuItem
            // 
            this.loadMethodFrompssessionFileToolStripMenuItem.Name = "loadMethodFrompssessionFileToolStripMenuItem";
            this.loadMethodFrompssessionFileToolStripMenuItem.Size = new System.Drawing.Size(224, 32);
            this.loadMethodFrompssessionFileToolStripMenuItem.Text = "Load Method";
            this.loadMethodFrompssessionFileToolStripMenuItem.Click += new System.EventHandler(this.loadMethodFrompssessionFileToolStripMenuItem_Click);
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importDataToolStripMenuItem,
            this.exportDataToolStripMenuItem});
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(67, 32);
            this.dataToolStripMenuItem.Text = "Data";
            // 
            // importDataToolStripMenuItem
            // 
            this.importDataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importFrompssessionFileToolStripMenuItem1,
            this.importFromxlsxFileToolStripMenuItem1});
            this.importDataToolStripMenuItem.Name = "importDataToolStripMenuItem";
            this.importDataToolStripMenuItem.Size = new System.Drawing.Size(204, 32);
            this.importDataToolStripMenuItem.Text = "Import Data";
            // 
            // importFrompssessionFileToolStripMenuItem1
            // 
            this.importFrompssessionFileToolStripMenuItem1.Name = "importFrompssessionFileToolStripMenuItem1";
            this.importFrompssessionFileToolStripMenuItem1.Size = new System.Drawing.Size(335, 32);
            this.importFrompssessionFileToolStripMenuItem1.Text = "Import From .pssession File";
            this.importFrompssessionFileToolStripMenuItem1.Click += new System.EventHandler(this.importFrompssessionFileToolStripMenuItem1_Click);
            // 
            // importFromxlsxFileToolStripMenuItem1
            // 
            this.importFromxlsxFileToolStripMenuItem1.Name = "importFromxlsxFileToolStripMenuItem1";
            this.importFromxlsxFileToolStripMenuItem1.Size = new System.Drawing.Size(335, 32);
            this.importFromxlsxFileToolStripMenuItem1.Text = "Import From .xlsx File";
            this.importFromxlsxFileToolStripMenuItem1.Click += new System.EventHandler(this.importFromxlsxFileToolStripMenuItem1_Click);
            // 
            // exportDataToolStripMenuItem
            // 
            this.exportDataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportAspssessionFileToolStripMenuItem,
            this.exportAsxlsxFileToolStripMenuItem,
            this.exportGraphAsImageToolStripMenuItem});
            this.exportDataToolStripMenuItem.Name = "exportDataToolStripMenuItem";
            this.exportDataToolStripMenuItem.Size = new System.Drawing.Size(204, 32);
            this.exportDataToolStripMenuItem.Text = "Export Data";
            // 
            // exportAspssessionFileToolStripMenuItem
            // 
            this.exportAspssessionFileToolStripMenuItem.Name = "exportAspssessionFileToolStripMenuItem";
            this.exportAspssessionFileToolStripMenuItem.Size = new System.Drawing.Size(304, 32);
            this.exportAspssessionFileToolStripMenuItem.Text = "Export as .pssession File";
            this.exportAspssessionFileToolStripMenuItem.Click += new System.EventHandler(this.exportAspssessionFileToolStripMenuItem_Click);
            // 
            // exportAsxlsxFileToolStripMenuItem
            // 
            this.exportAsxlsxFileToolStripMenuItem.Name = "exportAsxlsxFileToolStripMenuItem";
            this.exportAsxlsxFileToolStripMenuItem.Size = new System.Drawing.Size(304, 32);
            this.exportAsxlsxFileToolStripMenuItem.Text = "Export as .xlsx File";
            this.exportAsxlsxFileToolStripMenuItem.Click += new System.EventHandler(this.exportAsxlsxFileToolStripMenuItem_Click);
            // 
            // exportGraphAsImageToolStripMenuItem
            // 
            this.exportGraphAsImageToolStripMenuItem.Name = "exportGraphAsImageToolStripMenuItem";
            this.exportGraphAsImageToolStripMenuItem.Size = new System.Drawing.Size(304, 32);
            this.exportGraphAsImageToolStripMenuItem.Text = "Export Graph as Image";
            this.exportGraphAsImageToolStripMenuItem.Click += new System.EventHandler(this.exportGraphAsImageToolStripMenuItem_Click);
            // 
            // measurementToolStripMenuItem
            // 
            this.measurementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.downloadMeasurementDataToolStripMenuItem,
            this.saveMeasurementDaaToLocalStorageToolStripMenuItem,
            this.startWithNewPlotToolStripMenuItem});
            this.measurementToolStripMenuItem.Name = "measurementToolStripMenuItem";
            this.measurementToolStripMenuItem.Size = new System.Drawing.Size(145, 32);
            this.measurementToolStripMenuItem.Text = "Measurement";
            // 
            // downloadMeasurementDataToolStripMenuItem
            // 
            this.downloadMeasurementDataToolStripMenuItem.Name = "downloadMeasurementDataToolStripMenuItem";
            this.downloadMeasurementDataToolStripMenuItem.Size = new System.Drawing.Size(273, 32);
            this.downloadMeasurementDataToolStripMenuItem.Text = "Start Measurement";
            // 
            // saveMeasurementDaaToLocalStorageToolStripMenuItem
            // 
            this.saveMeasurementDaaToLocalStorageToolStripMenuItem.Name = "saveMeasurementDaaToLocalStorageToolStripMenuItem";
            this.saveMeasurementDaaToLocalStorageToolStripMenuItem.Size = new System.Drawing.Size(273, 32);
            this.saveMeasurementDaaToLocalStorageToolStripMenuItem.Text = "Abort Measurement";
            // 
            // startWithNewPlotToolStripMenuItem
            // 
            this.startWithNewPlotToolStripMenuItem.Name = "startWithNewPlotToolStripMenuItem";
            this.startWithNewPlotToolStripMenuItem.Size = new System.Drawing.Size(273, 32);
            this.startWithNewPlotToolStripMenuItem.Text = "Start with New Plot";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status_statusbar,
            this.potential_statusbar,
            this.current_statusbar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 927);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1632, 26);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // status_statusbar
            // 
            this.status_statusbar.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.status_statusbar.Name = "status_statusbar";
            this.status_statusbar.Size = new System.Drawing.Size(52, 20);
            this.status_statusbar.Text = "Status:";
            // 
            // potential_statusbar
            // 
            this.potential_statusbar.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.potential_statusbar.Name = "potential_statusbar";
            this.potential_statusbar.Size = new System.Drawing.Size(70, 20);
            this.potential_statusbar.Text = "Potential:";
            // 
            // current_statusbar
            // 
            this.current_statusbar.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.current_statusbar.Name = "current_statusbar";
            this.current_statusbar.Size = new System.Drawing.Size(60, 20);
            this.current_statusbar.Text = "Current:";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.panel5);
            this.splitContainer2.Panel1.Controls.Add(this.panel2);
            this.splitContainer2.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tabControl2);
            this.splitContainer2.Panel2.Controls.Add(this.section2_btn);
            this.splitContainer2.Panel2.Controls.Add(this.section1_btn);
            this.splitContainer2.Size = new System.Drawing.Size(1155, 891);
            this.splitContainer2.SplitterDistance = 425;
            this.splitContainer2.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.regeneration1);
            this.panel5.Controls.Add(this.calculators1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 115);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(425, 571);
            this.panel5.TabIndex = 14;
            // 
            // regeneration1
            // 
            this.regeneration1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.regeneration1.Location = new System.Drawing.Point(0, 396);
            this.regeneration1.Name = "regeneration1";
            this.regeneration1.Size = new System.Drawing.Size(425, 172);
            this.regeneration1.TabIndex = 27;
            this.regeneration1.Load += new System.EventHandler(this.regeneration1_Load);
            // 
            // calculators1
            // 
            this.calculators1.Location = new System.Drawing.Point(0, 0);
            this.calculators1.Name = "calculators1";
            this.calculators1.Size = new System.Drawing.Size(425, 398);
            this.calculators1.TabIndex = 26;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.lbConsole);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 686);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(425, 205);
            this.panel2.TabIndex = 13;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(425, 36);
            this.panel3.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(7, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Console";
            // 
            // lbConsole
            // 
            this.lbConsole.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbConsole.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbConsole.FormattingEnabled = true;
            this.lbConsole.ItemHeight = 16;
            this.lbConsole.Location = new System.Drawing.Point(0, 29);
            this.lbConsole.Name = "lbConsole";
            this.lbConsole.Size = new System.Drawing.Size(425, 176);
            this.lbConsole.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.connectionLabel);
            this.panel1.Controls.Add(this.btnConnect);
            this.panel1.Controls.Add(this.btnBluetooth);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.cmbDevices);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(425, 115);
            this.panel1.TabIndex = 1;
            // 
            // connectionLabel
            // 
            this.connectionLabel.AutoSize = true;
            this.connectionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectionLabel.Location = new System.Drawing.Point(7, 83);
            this.connectionLabel.Name = "connectionLabel";
            this.connectionLabel.Size = new System.Drawing.Size(142, 25);
            this.connectionLabel.TabIndex = 6;
            this.connectionLabel.Text = "No Connection";
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnConnect.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnConnect.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnConnect.BorderRadius = 0;
            this.btnConnect.BorderSize = 0;
            this.btnConnect.Enabled = false;
            this.btnConnect.FlatAppearance.BorderSize = 0;
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.ForeColor = System.Drawing.Color.Black;
            this.btnConnect.Location = new System.Drawing.Point(300, 48);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(122, 32);
            this.btnConnect.TabIndex = 13;
            this.btnConnect.Text = "Connect";
            this.btnConnect.TextColor = System.Drawing.Color.Black;
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnBluetooth
            // 
            this.btnBluetooth.BackColor = System.Drawing.Color.Transparent;
            this.btnBluetooth.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnBluetooth.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBluetooth.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnBluetooth.BorderRadius = 0;
            this.btnBluetooth.BorderSize = 0;
            this.btnBluetooth.FlatAppearance.BorderSize = 0;
            this.btnBluetooth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBluetooth.ForeColor = System.Drawing.Color.White;
            this.btnBluetooth.Image = ((System.Drawing.Image)(resources.GetObject("btnBluetooth.Image")));
            this.btnBluetooth.Location = new System.Drawing.Point(47, 48);
            this.btnBluetooth.Name = "btnBluetooth";
            this.btnBluetooth.Size = new System.Drawing.Size(32, 32);
            this.btnBluetooth.TabIndex = 13;
            this.btnBluetooth.TextColor = System.Drawing.Color.White;
            this.btnBluetooth.UseVisualStyleBackColor = false;
            this.btnBluetooth.Click += new System.EventHandler(this.btnBluetooth_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Transparent;
            this.btnRefresh.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnRefresh.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRefresh.BackgroundImage")));
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRefresh.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnRefresh.BorderRadius = 0;
            this.btnRefresh.BorderSize = 0;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(9, 48);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(32, 32);
            this.btnRefresh.TabIndex = 12;
            this.btnRefresh.TextColor = System.Drawing.Color.White;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(425, 36);
            this.panel4.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 29);
            this.label2.TabIndex = 0;
            this.label2.Text = "Connect Device";
            // 
            // cmbDevices
            // 
            this.cmbDevices.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDevices.FormattingEnabled = true;
            this.cmbDevices.Location = new System.Drawing.Point(85, 48);
            this.cmbDevices.Name = "cmbDevices";
            this.cmbDevices.Size = new System.Drawing.Size(209, 33);
            this.cmbDevices.TabIndex = 4;
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.PlotArea);
            this.tabControl2.Controls.Add(this.eisPlotArea);
            this.tabControl2.Controls.Add(this.dataArea);
            this.tabControl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl2.Location = new System.Drawing.Point(43, 5);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(641, 853);
            this.tabControl2.TabIndex = 18;
            // 
            // PlotArea
            // 
            this.PlotArea.Controls.Add(this.cv_dp_plot);
            this.PlotArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlotArea.Location = new System.Drawing.Point(4, 34);
            this.PlotArea.Name = "PlotArea";
            this.PlotArea.Padding = new System.Windows.Forms.Padding(3);
            this.PlotArea.Size = new System.Drawing.Size(633, 815);
            this.PlotArea.TabIndex = 0;
            this.PlotArea.Text = "Plot";
            this.PlotArea.UseVisualStyleBackColor = true;
            // 
            // cv_dp_plot
            // 
            this.cv_dp_plot.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.cv_dp_plot.Controls.Add(this.plot);
            this.cv_dp_plot.Controls.Add(this.PlotSettings);
            this.cv_dp_plot.Controls.Add(this.flowLayoutPanel4);
            this.cv_dp_plot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cv_dp_plot.Location = new System.Drawing.Point(3, 3);
            this.cv_dp_plot.Name = "cv_dp_plot";
            this.cv_dp_plot.Size = new System.Drawing.Size(627, 809);
            this.cv_dp_plot.TabIndex = 1;
            // 
            // plot
            // 
            this.plot.BackColor = System.Drawing.Color.White;
            this.plot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plot.Location = new System.Drawing.Point(0, 33);
            this.plot.Margin = new System.Windows.Forms.Padding(9);
            this.plot.MarkerSize = 5;
            this.plot.MarkerType = OxyPlot.MarkerType.Circle;
            this.plot.Name = "plot";
            this.plot.Size = new System.Drawing.Size(627, 776);
            this.plot.TabIndex = 10;
            this.plot.Title = null;
            this.plot.XAxisLabel = null;
            this.plot.XAxisType = SDKPlot.AxisType.Linear;
            this.plot.YAxisLabel = null;
            this.plot.YAxisSecondaryLabel = null;
            this.plot.YAxisSecondaryType = SDKPlot.AxisType.Linear;
            this.plot.YAxisType = SDKPlot.AxisType.Linear;
            // 
            // PlotSettings
            // 
            this.PlotSettings.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.PlotSettings.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.PlotSettings.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.PlotSettings.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plotToolStripMenuItem,
            this.clearToolStripMenuItem,
            this.filterToolStripMenuItem,
            this.regressionAnalysisToolStripMenuItem,
            this.TSMILoadPeakLOD,
            this.exportsToolStripMenuItem});
            this.PlotSettings.Location = new System.Drawing.Point(0, 0);
            this.PlotSettings.Name = "PlotSettings";
            this.PlotSettings.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.PlotSettings.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.PlotSettings.Size = new System.Drawing.Size(627, 33);
            this.PlotSettings.TabIndex = 9;
            this.PlotSettings.Text = "menuStrip2";
            // 
            // plotToolStripMenuItem
            // 
            this.plotToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smoothCurveToolStripMenuItem,
            this.detectPeaksToolStripMenuItem});
            this.plotToolStripMenuItem.Name = "plotToolStripMenuItem";
            this.plotToolStripMenuItem.Size = new System.Drawing.Size(59, 29);
            this.plotToolStripMenuItem.Text = "Plot";
            // 
            // smoothCurveToolStripMenuItem
            // 
            this.smoothCurveToolStripMenuItem.Name = "smoothCurveToolStripMenuItem";
            this.smoothCurveToolStripMenuItem.Size = new System.Drawing.Size(217, 30);
            this.smoothCurveToolStripMenuItem.Text = "Smooth Curve";
            // 
            // detectPeaksToolStripMenuItem
            // 
            this.detectPeaksToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allPlotsToolStripMenuItem});
            this.detectPeaksToolStripMenuItem.Name = "detectPeaksToolStripMenuItem";
            this.detectPeaksToolStripMenuItem.Size = new System.Drawing.Size(217, 30);
            this.detectPeaksToolStripMenuItem.Text = "Detect Peaks";
            // 
            // allPlotsToolStripMenuItem
            // 
            this.allPlotsToolStripMenuItem.Name = "allPlotsToolStripMenuItem";
            this.allPlotsToolStripMenuItem.Size = new System.Drawing.Size(166, 30);
            this.allPlotsToolStripMenuItem.Text = "All Plots";
            this.allPlotsToolStripMenuItem.Click += new System.EventHandler(this.allPlotsToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearPlotToolStripMenuItem,
            this.clearAllToolStripMenuItem});
            this.clearToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(70, 29);
            this.clearToolStripMenuItem.Text = "Clear";
            // 
            // clearPlotToolStripMenuItem
            // 
            this.clearPlotToolStripMenuItem.Name = "clearPlotToolStripMenuItem";
            this.clearPlotToolStripMenuItem.Size = new System.Drawing.Size(180, 30);
            this.clearPlotToolStripMenuItem.Text = "Clear Plot";
            // 
            // clearAllToolStripMenuItem
            // 
            this.clearAllToolStripMenuItem.Name = "clearAllToolStripMenuItem";
            this.clearAllToolStripMenuItem.Size = new System.Drawing.Size(180, 30);
            this.clearAllToolStripMenuItem.Text = "Clear All";
            this.clearAllToolStripMenuItem.Click += new System.EventHandler(this.clearAllToolStripMenuItem_Click);
            // 
            // filterToolStripMenuItem
            // 
            this.filterToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            this.filterToolStripMenuItem.Size = new System.Drawing.Size(73, 29);
            this.filterToolStripMenuItem.Text = "Filter ";
            // 
            // regressionAnalysisToolStripMenuItem
            // 
            this.regressionAnalysisToolStripMenuItem.Name = "regressionAnalysisToolStripMenuItem";
            this.regressionAnalysisToolStripMenuItem.Size = new System.Drawing.Size(190, 29);
            this.regressionAnalysisToolStripMenuItem.Text = "Regression Analysis";
            this.regressionAnalysisToolStripMenuItem.Click += new System.EventHandler(this.regressionAnalysisToolStripMenuItem_Click);
            // 
            // TSMILoadPeakLOD
            // 
            this.TSMILoadPeakLOD.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importFrompssessionFileToolStripMenuItem,
            this.importFromxlsxFileToolStripMenuItem});
            this.TSMILoadPeakLOD.Name = "TSMILoadPeakLOD";
            this.TSMILoadPeakLOD.Size = new System.Drawing.Size(90, 29);
            this.TSMILoadPeakLOD.Text = "Imports";
            // 
            // importFrompssessionFileToolStripMenuItem
            // 
            this.importFrompssessionFileToolStripMenuItem.Name = "importFrompssessionFileToolStripMenuItem";
            this.importFrompssessionFileToolStripMenuItem.Size = new System.Drawing.Size(325, 30);
            this.importFrompssessionFileToolStripMenuItem.Text = "Import From .pssession File";
            this.importFrompssessionFileToolStripMenuItem.Click += new System.EventHandler(this.importFrompssessionFileToolStripMenuItem_Click);
            // 
            // importFromxlsxFileToolStripMenuItem
            // 
            this.importFromxlsxFileToolStripMenuItem.Name = "importFromxlsxFileToolStripMenuItem";
            this.importFromxlsxFileToolStripMenuItem.Size = new System.Drawing.Size(325, 30);
            this.importFromxlsxFileToolStripMenuItem.Text = "Load Data From .xlsx File";
            this.importFromxlsxFileToolStripMenuItem.Click += new System.EventHandler(this.importFromxlsxFileToolStripMenuItem_Click);
            // 
            // exportsToolStripMenuItem
            // 
            this.exportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pssessionExport,
            this.xlsxFileToolStripMenuItem,
            this.exportGraphToolStripMenuItem});
            this.exportsToolStripMenuItem.Name = "exportsToolStripMenuItem";
            this.exportsToolStripMenuItem.Size = new System.Drawing.Size(88, 29);
            this.exportsToolStripMenuItem.Text = "Exports";
            // 
            // pssessionExport
            // 
            this.pssessionExport.Name = "pssessionExport";
            this.pssessionExport.Size = new System.Drawing.Size(291, 30);
            this.pssessionExport.Text = ".pssession File";
            this.pssessionExport.Click += new System.EventHandler(this.pssessionExport_Click);
            // 
            // xlsxFileToolStripMenuItem
            // 
            this.xlsxFileToolStripMenuItem.Name = "xlsxFileToolStripMenuItem";
            this.xlsxFileToolStripMenuItem.Size = new System.Drawing.Size(291, 30);
            this.xlsxFileToolStripMenuItem.Text = ".xlsx File";
            this.xlsxFileToolStripMenuItem.Click += new System.EventHandler(this.xlsxFileToolStripMenuItem_Click);
            // 
            // exportGraphToolStripMenuItem
            // 
            this.exportGraphToolStripMenuItem.Name = "exportGraphToolStripMenuItem";
            this.exportGraphToolStripMenuItem.Size = new System.Drawing.Size(291, 30);
            this.exportGraphToolStripMenuItem.Text = "Export Graph As Image";
            this.exportGraphToolStripMenuItem.Click += new System.EventHandler(this.exportGraphToolStripMenuItem_Click);
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.rjButton2);
            this.flowLayoutPanel4.Controls.Add(this.rjButton22);
            this.flowLayoutPanel4.Controls.Add(this.rjButton23);
            this.flowLayoutPanel4.Controls.Add(this.rjButton24);
            this.flowLayoutPanel4.Controls.Add(this.rjButton25);
            this.flowLayoutPanel4.Controls.Add(this.rjButton26);
            this.flowLayoutPanel4.Controls.Add(this.rjButton27);
            this.flowLayoutPanel4.Controls.Add(this.rjButton28);
            this.flowLayoutPanel4.Controls.Add(this.rjButton29);
            this.flowLayoutPanel4.Controls.Add(this.rjButton30);
            this.flowLayoutPanel4.Location = new System.Drawing.Point(605, 184);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(467, 51);
            this.flowLayoutPanel4.TabIndex = 25;
            // 
            // rjButton2
            // 
            this.rjButton2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.rjButton2.BackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.rjButton2.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton2.BorderRadius = 2;
            this.rjButton2.BorderSize = 0;
            this.rjButton2.FlatAppearance.BorderSize = 0;
            this.rjButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton2.ForeColor = System.Drawing.Color.White;
            this.rjButton2.Location = new System.Drawing.Point(3, 3);
            this.rjButton2.Name = "rjButton2";
            this.rjButton2.Size = new System.Drawing.Size(40, 40);
            this.rjButton2.TabIndex = 23;
            this.rjButton2.Text = "100 pA";
            this.rjButton2.TextColor = System.Drawing.Color.White;
            this.rjButton2.UseVisualStyleBackColor = false;
            // 
            // rjButton22
            // 
            this.rjButton22.BackColor = System.Drawing.Color.CornflowerBlue;
            this.rjButton22.BackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.rjButton22.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton22.BorderRadius = 2;
            this.rjButton22.BorderSize = 0;
            this.rjButton22.FlatAppearance.BorderSize = 0;
            this.rjButton22.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton22.ForeColor = System.Drawing.Color.White;
            this.rjButton22.Location = new System.Drawing.Point(49, 3);
            this.rjButton22.Name = "rjButton22";
            this.rjButton22.Size = new System.Drawing.Size(40, 40);
            this.rjButton22.TabIndex = 24;
            this.rjButton22.Text = "1 nA";
            this.rjButton22.TextColor = System.Drawing.Color.White;
            this.rjButton22.UseVisualStyleBackColor = false;
            // 
            // rjButton23
            // 
            this.rjButton23.BackColor = System.Drawing.Color.CornflowerBlue;
            this.rjButton23.BackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.rjButton23.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton23.BorderRadius = 2;
            this.rjButton23.BorderSize = 0;
            this.rjButton23.FlatAppearance.BorderSize = 0;
            this.rjButton23.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton23.ForeColor = System.Drawing.Color.White;
            this.rjButton23.Location = new System.Drawing.Point(95, 3);
            this.rjButton23.Name = "rjButton23";
            this.rjButton23.Size = new System.Drawing.Size(40, 40);
            this.rjButton23.TabIndex = 25;
            this.rjButton23.Text = "10 nA";
            this.rjButton23.TextColor = System.Drawing.Color.White;
            this.rjButton23.UseVisualStyleBackColor = false;
            // 
            // rjButton24
            // 
            this.rjButton24.BackColor = System.Drawing.Color.CornflowerBlue;
            this.rjButton24.BackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.rjButton24.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton24.BorderRadius = 2;
            this.rjButton24.BorderSize = 0;
            this.rjButton24.FlatAppearance.BorderSize = 0;
            this.rjButton24.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton24.ForeColor = System.Drawing.Color.White;
            this.rjButton24.Location = new System.Drawing.Point(141, 3);
            this.rjButton24.Name = "rjButton24";
            this.rjButton24.Size = new System.Drawing.Size(40, 40);
            this.rjButton24.TabIndex = 26;
            this.rjButton24.Text = "100 nA";
            this.rjButton24.TextColor = System.Drawing.Color.White;
            this.rjButton24.UseVisualStyleBackColor = false;
            // 
            // rjButton25
            // 
            this.rjButton25.BackColor = System.Drawing.Color.CornflowerBlue;
            this.rjButton25.BackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.rjButton25.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton25.BorderRadius = 2;
            this.rjButton25.BorderSize = 0;
            this.rjButton25.FlatAppearance.BorderSize = 0;
            this.rjButton25.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton25.ForeColor = System.Drawing.Color.White;
            this.rjButton25.Location = new System.Drawing.Point(187, 3);
            this.rjButton25.Name = "rjButton25";
            this.rjButton25.Size = new System.Drawing.Size(40, 40);
            this.rjButton25.TabIndex = 27;
            this.rjButton25.Text = "1 uA";
            this.rjButton25.TextColor = System.Drawing.Color.White;
            this.rjButton25.UseVisualStyleBackColor = false;
            // 
            // rjButton26
            // 
            this.rjButton26.BackColor = System.Drawing.Color.CornflowerBlue;
            this.rjButton26.BackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.rjButton26.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton26.BorderRadius = 2;
            this.rjButton26.BorderSize = 0;
            this.rjButton26.FlatAppearance.BorderSize = 0;
            this.rjButton26.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton26.ForeColor = System.Drawing.Color.White;
            this.rjButton26.Location = new System.Drawing.Point(233, 3);
            this.rjButton26.Name = "rjButton26";
            this.rjButton26.Size = new System.Drawing.Size(40, 40);
            this.rjButton26.TabIndex = 28;
            this.rjButton26.Text = "10 uA";
            this.rjButton26.TextColor = System.Drawing.Color.White;
            this.rjButton26.UseVisualStyleBackColor = false;
            // 
            // rjButton27
            // 
            this.rjButton27.BackColor = System.Drawing.Color.CornflowerBlue;
            this.rjButton27.BackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.rjButton27.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton27.BorderRadius = 2;
            this.rjButton27.BorderSize = 0;
            this.rjButton27.FlatAppearance.BorderSize = 0;
            this.rjButton27.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton27.ForeColor = System.Drawing.Color.White;
            this.rjButton27.Location = new System.Drawing.Point(279, 3);
            this.rjButton27.Name = "rjButton27";
            this.rjButton27.Size = new System.Drawing.Size(40, 40);
            this.rjButton27.TabIndex = 29;
            this.rjButton27.Text = "100 uA";
            this.rjButton27.TextColor = System.Drawing.Color.White;
            this.rjButton27.UseVisualStyleBackColor = false;
            // 
            // rjButton28
            // 
            this.rjButton28.BackColor = System.Drawing.Color.CornflowerBlue;
            this.rjButton28.BackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.rjButton28.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton28.BorderRadius = 2;
            this.rjButton28.BorderSize = 0;
            this.rjButton28.FlatAppearance.BorderSize = 0;
            this.rjButton28.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton28.ForeColor = System.Drawing.Color.White;
            this.rjButton28.Location = new System.Drawing.Point(325, 3);
            this.rjButton28.Name = "rjButton28";
            this.rjButton28.Size = new System.Drawing.Size(40, 40);
            this.rjButton28.TabIndex = 30;
            this.rjButton28.Text = "1 mA";
            this.rjButton28.TextColor = System.Drawing.Color.White;
            this.rjButton28.UseVisualStyleBackColor = false;
            // 
            // rjButton29
            // 
            this.rjButton29.BackColor = System.Drawing.Color.CornflowerBlue;
            this.rjButton29.BackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.rjButton29.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton29.BorderRadius = 2;
            this.rjButton29.BorderSize = 0;
            this.rjButton29.FlatAppearance.BorderSize = 0;
            this.rjButton29.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton29.ForeColor = System.Drawing.Color.White;
            this.rjButton29.Location = new System.Drawing.Point(371, 3);
            this.rjButton29.Name = "rjButton29";
            this.rjButton29.Size = new System.Drawing.Size(40, 40);
            this.rjButton29.TabIndex = 31;
            this.rjButton29.Text = "10 mA";
            this.rjButton29.TextColor = System.Drawing.Color.White;
            this.rjButton29.UseVisualStyleBackColor = false;
            // 
            // rjButton30
            // 
            this.rjButton30.BackColor = System.Drawing.Color.CornflowerBlue;
            this.rjButton30.BackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.rjButton30.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton30.BorderRadius = 2;
            this.rjButton30.BorderSize = 0;
            this.rjButton30.FlatAppearance.BorderSize = 0;
            this.rjButton30.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton30.ForeColor = System.Drawing.Color.White;
            this.rjButton30.Location = new System.Drawing.Point(417, 3);
            this.rjButton30.Name = "rjButton30";
            this.rjButton30.Size = new System.Drawing.Size(40, 40);
            this.rjButton30.TabIndex = 32;
            this.rjButton30.Text = "100 mA";
            this.rjButton30.TextColor = System.Drawing.Color.White;
            this.rjButton30.UseVisualStyleBackColor = false;
            // 
            // eisPlotArea
            // 
            this.eisPlotArea.Controls.Add(this.eisPlot);
            this.eisPlotArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eisPlotArea.Location = new System.Drawing.Point(4, 34);
            this.eisPlotArea.Name = "eisPlotArea";
            this.eisPlotArea.Padding = new System.Windows.Forms.Padding(3);
            this.eisPlotArea.Size = new System.Drawing.Size(633, 815);
            this.eisPlotArea.TabIndex = 1;
            this.eisPlotArea.Text = "EIS Plot";
            this.eisPlotArea.UseVisualStyleBackColor = true;
            // 
            // eisPlot
            // 
            this.eisPlot.BackColor = System.Drawing.Color.White;
            this.eisPlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eisPlot.Location = new System.Drawing.Point(3, 3);
            this.eisPlot.Margin = new System.Windows.Forms.Padding(6);
            this.eisPlot.MarkerSize = 5;
            this.eisPlot.MarkerType = OxyPlot.MarkerType.Circle;
            this.eisPlot.Name = "eisPlot";
            this.eisPlot.Size = new System.Drawing.Size(627, 809);
            this.eisPlot.TabIndex = 0;
            this.eisPlot.Title = null;
            this.eisPlot.XAxisLabel = null;
            this.eisPlot.XAxisType = SDKPlot.AxisType.Linear;
            this.eisPlot.YAxisLabel = null;
            this.eisPlot.YAxisSecondaryLabel = null;
            this.eisPlot.YAxisSecondaryType = SDKPlot.AxisType.Linear;
            this.eisPlot.YAxisType = SDKPlot.AxisType.Linear;
            // 
            // dataArea
            // 
            this.dataArea.Controls.Add(this.dgvMeasurement);
            this.dataArea.Controls.Add(this.btnDataViewSave);
            this.dataArea.Controls.Add(this.btnLoad);
            this.dataArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataArea.Location = new System.Drawing.Point(4, 34);
            this.dataArea.Name = "dataArea";
            this.dataArea.Padding = new System.Windows.Forms.Padding(3);
            this.dataArea.Size = new System.Drawing.Size(633, 815);
            this.dataArea.TabIndex = 2;
            this.dataArea.Text = "Data";
            this.dataArea.UseVisualStyleBackColor = true;
            // 
            // dgvMeasurement
            // 
            this.dgvMeasurement.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMeasurement.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvMeasurement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMeasurement.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvMeasurement.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvMeasurement.Location = new System.Drawing.Point(4, 73);
            this.dgvMeasurement.Margin = new System.Windows.Forms.Padding(4);
            this.dgvMeasurement.Name = "dgvMeasurement";
            this.dgvMeasurement.RowHeadersVisible = false;
            this.dgvMeasurement.RowHeadersWidth = 51;
            this.dgvMeasurement.Size = new System.Drawing.Size(622, 639);
            this.dgvMeasurement.TabIndex = 8;
            // 
            // btnDataViewSave
            // 
            this.btnDataViewSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDataViewSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDataViewSave.Location = new System.Drawing.Point(435, 751);
            this.btnDataViewSave.Name = "btnDataViewSave";
            this.btnDataViewSave.Size = new System.Drawing.Size(191, 49);
            this.btnDataViewSave.TabIndex = 10;
            this.btnDataViewSave.Text = "Save";
            this.btnDataViewSave.UseVisualStyleBackColor = true;
            this.btnDataViewSave.Click += new System.EventHandler(this.btnDataViewSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.Location = new System.Drawing.Point(4, 751);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(192, 49);
            this.btnLoad.TabIndex = 9;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // section2_btn
            // 
            this.section2_btn.BackColor = System.Drawing.Color.LightSteelBlue;
            this.section2_btn.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.section2_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("section2_btn.BackgroundImage")));
            this.section2_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.section2_btn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.section2_btn.BorderRadius = 0;
            this.section2_btn.BorderSize = 0;
            this.section2_btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.section2_btn.FlatAppearance.BorderSize = 0;
            this.section2_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.section2_btn.ForeColor = System.Drawing.Color.White;
            this.section2_btn.Location = new System.Drawing.Point(694, 0);
            this.section2_btn.Name = "section2_btn";
            this.section2_btn.Size = new System.Drawing.Size(32, 891);
            this.section2_btn.TabIndex = 17;
            this.section2_btn.TextColor = System.Drawing.Color.White;
            this.section2_btn.UseVisualStyleBackColor = false;
            this.section2_btn.Click += new System.EventHandler(this.section2_btn_Click_1);
            // 
            // section1_btn
            // 
            this.section1_btn.BackColor = System.Drawing.Color.LightSteelBlue;
            this.section1_btn.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.section1_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("section1_btn.BackgroundImage")));
            this.section1_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.section1_btn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.section1_btn.BorderRadius = 0;
            this.section1_btn.BorderSize = 0;
            this.section1_btn.Dock = System.Windows.Forms.DockStyle.Left;
            this.section1_btn.FlatAppearance.BorderSize = 0;
            this.section1_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.section1_btn.ForeColor = System.Drawing.Color.White;
            this.section1_btn.Location = new System.Drawing.Point(0, 0);
            this.section1_btn.Name = "section1_btn";
            this.section1_btn.Size = new System.Drawing.Size(32, 891);
            this.section1_btn.TabIndex = 14;
            this.section1_btn.TextColor = System.Drawing.Color.White;
            this.section1_btn.UseVisualStyleBackColor = false;
            this.section1_btn.Click += new System.EventHandler(this.section1_btn_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 36);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.saveSettingsInInternalStorage);
            this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanel3);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.currentRangeSettings1);
            this.splitContainer1.Panel2.Controls.Add(this.btnRun);
            this.splitContainer1.Panel2.Controls.Add(this.measurement_type);
            this.splitContainer1.Size = new System.Drawing.Size(1632, 891);
            this.splitContainer1.SplitterDistance = 1155;
            this.splitContainer1.TabIndex = 14;
            // 
            // saveSettingsInInternalStorage
            // 
            this.saveSettingsInInternalStorage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveSettingsInInternalStorage.AutoSize = true;
            this.saveSettingsInInternalStorage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveSettingsInInternalStorage.Location = new System.Drawing.Point(12, 849);
            this.saveSettingsInInternalStorage.Name = "saveSettingsInInternalStorage";
            this.saveSettingsInInternalStorage.Size = new System.Drawing.Size(250, 29);
            this.saveSettingsInInternalStorage.TabIndex = 30;
            this.saveSettingsInInternalStorage.Text = "Save on Internal Storage";
            this.saveSettingsInInternalStorage.UseVisualStyleBackColor = true;
            this.saveSettingsInInternalStorage.CheckedChanged += new System.EventHandler(this.saveSettingsInInternalStorage_CheckedChanged);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel3.AutoScroll = true;
            this.flowLayoutPanel3.Controls.Add(this.pretreatmentSettings1);
            this.flowLayoutPanel3.Controls.Add(this.isSettings1);
            this.flowLayoutPanel3.Controls.Add(this.dpSettings1);
            this.flowLayoutPanel3.Controls.Add(this.cvSettings1);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 262);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(467, 568);
            this.flowLayoutPanel3.TabIndex = 27;
            // 
            // pretreatmentSettings1
            // 
            this.pretreatmentSettings1.Location = new System.Drawing.Point(3, 3);
            this.pretreatmentSettings1.Name = "pretreatmentSettings1";
            this.pretreatmentSettings1.Size = new System.Drawing.Size(435, 331);
            this.pretreatmentSettings1.TabIndex = 11;
            // 
            // isSettings1
            // 
            this.isSettings1.Location = new System.Drawing.Point(3, 340);
            this.isSettings1.Name = "isSettings1";
            this.isSettings1.Size = new System.Drawing.Size(435, 460);
            this.isSettings1.TabIndex = 11;
            // 
            // dpSettings1
            // 
            this.dpSettings1.Location = new System.Drawing.Point(3, 806);
            this.dpSettings1.Name = "dpSettings1";
            this.dpSettings1.Size = new System.Drawing.Size(435, 380);
            this.dpSettings1.TabIndex = 11;
            // 
            // cvSettings1
            // 
            this.cvSettings1.Location = new System.Drawing.Point(3, 1192);
            this.cvSettings1.Name = "cvSettings1";
            this.cvSettings1.Size = new System.Drawing.Size(435, 380);
            this.cvSettings1.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 25);
            this.label5.TabIndex = 21;
            this.label5.Text = "Technique:";
            // 
            // currentRangeSettings1
            // 
            this.currentRangeSettings1.Location = new System.Drawing.Point(2, 87);
            this.currentRangeSettings1.Name = "currentRangeSettings1";
            this.currentRangeSettings1.Size = new System.Drawing.Size(469, 150);
            this.currentRangeSettings1.TabIndex = 29;
            // 
            // btnRun
            // 
            this.btnRun.Dock = System.Windows.Forms.DockStyle.None;
            this.btnRun.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnRun.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.btnRun.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.btnRun.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.measurementBtn});
            this.btnRun.Location = new System.Drawing.Point(359, 26);
            this.btnRun.Name = "btnRun";
            this.btnRun.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.btnRun.Size = new System.Drawing.Size(87, 32);
            this.btnRun.TabIndex = 19;
            this.btnRun.Text = "toolStrip1";
            // 
            // measurementBtn
            // 
            this.measurementBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newRunBtn,
            this.overlayRunBtn});
            this.measurementBtn.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.measurementBtn.Image = ((System.Drawing.Image)(resources.GetObject("measurementBtn.Image")));
            this.measurementBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.measurementBtn.Name = "measurementBtn";
            this.measurementBtn.Size = new System.Drawing.Size(84, 29);
            this.measurementBtn.Text = "Run";
            this.measurementBtn.ButtonClick += new System.EventHandler(this.measurementBtn_ButtonClick);
            // 
            // newRunBtn
            // 
            this.newRunBtn.Name = "newRunBtn";
            this.newRunBtn.Size = new System.Drawing.Size(240, 30);
            this.newRunBtn.Text = "New";
            this.newRunBtn.Click += new System.EventHandler(this.newRunBtn_Click);
            // 
            // overlayRunBtn
            // 
            this.overlayRunBtn.Name = "overlayRunBtn";
            this.overlayRunBtn.Size = new System.Drawing.Size(240, 30);
            this.overlayRunBtn.Text = "Overlay (Default)";
            this.overlayRunBtn.Click += new System.EventHandler(this.overlayRunBtn_Click);
            // 
            // measurement_type
            // 
            this.measurement_type.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.measurement_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.measurement_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.measurement_type.FormattingEnabled = true;
            this.measurement_type.Location = new System.Drawing.Point(124, 25);
            this.measurement_type.Name = "measurement_type";
            this.measurement_type.Size = new System.Drawing.Size(232, 33);
            this.measurement_type.TabIndex = 7;
            this.measurement_type.SelectedIndexChanged += new System.EventHandler(this.measurement_type_SelectedIndexChanged);
            // 
            // rjDropdownMenu1
            // 
            this.rjDropdownMenu1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.rjDropdownMenu1.IsMainMenu = false;
            this.rjDropdownMenu1.MenuItemHeight = 25;
            this.rjDropdownMenu1.MenuItemTextColor = System.Drawing.Color.Empty;
            this.rjDropdownMenu1.Name = "rjDropdownMenu1";
            this.rjDropdownMenu1.PrimaryColor = System.Drawing.Color.Empty;
            this.rjDropdownMenu1.Size = new System.Drawing.Size(61, 4);
            // 
            // psCommSimpleWinForms
            // 
            this.psCommSimpleWinForms.EnableBluetooth = false;
            this.psCommSimpleWinForms.EnableSerialPort = false;
            this.psCommSimpleWinForms.Parent = this;
            this.psCommSimpleWinForms.ReceiveStatus += new PalmSens.Comm.StatusEventHandler(this.psCommSimpleWinForms_ReceiveStatus);
            this.psCommSimpleWinForms.MeasurementStarted += new System.EventHandler(this.psCommSimpleWinForms_MeasurementStarted);
            this.psCommSimpleWinForms.MeasurementEnded += new System.EventHandler<System.Exception>(this.psCommSimpleWinForms_MeasurementEnded);
            this.psCommSimpleWinForms.SimpleCurveStartReceivingData += new PalmSens.Core.Simplified.PSCommSimple.SimpleCurveStartReceivingDataHandler(this.psCommSimpleWinForms_SimpleCurveStartReceivingData);
            this.psCommSimpleWinForms.StateChanged += new PalmSens.Comm.CommManager.StatusChangedEventHandler(this.psCommSimpleWinForms_StateChanged);
            this.psCommSimpleWinForms.Disconnected += new PalmSens.Core.Simplified.DisconnectedEventHandler(this.psCommSimpleWinForms_Disconnected);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1632, 953);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainPage";
            this.Load += new System.EventHandler(this.MainPage_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.PlotArea.ResumeLayout(false);
            this.cv_dp_plot.ResumeLayout(false);
            this.cv_dp_plot.PerformLayout();
            this.PlotSettings.ResumeLayout(false);
            this.PlotSettings.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.eisPlotArea.ResumeLayout(false);
            this.dataArea.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeasurement)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.btnRun.ResumeLayout(false);
            this.btnRun.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem methodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem measurementToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel status_statusbar;
        private System.Windows.Forms.ToolStripStatusLabel potential_statusbar;
        private System.Windows.Forms.ToolStripStatusLabel current_statusbar;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private RJCodeAdvance.RJControls.RJButton section1_btn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbConsole;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label connectionLabel;
        private RJCodeAdvance.RJControls.RJButton btnConnect;
        private RJCodeAdvance.RJControls.RJButton btnRefresh;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbDevices;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private RJCodeAdvance.RJControls.RJButton section2_btn;
        private System.Windows.Forms.Panel panel5;
        public System.Windows.Forms.ComboBox measurement_type;
        private System.Windows.Forms.ToolStrip btnRun;
        private System.Windows.Forms.ToolStripSplitButton measurementBtn;
        private System.Windows.Forms.ToolStripMenuItem newRunBtn;
        private System.Windows.Forms.ToolStripMenuItem overlayRunBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage PlotArea;
        private System.Windows.Forms.Panel cv_dp_plot;
        private System.Windows.Forms.MenuStrip PlotSettings;
        private System.Windows.Forms.ToolStripMenuItem plotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearPlotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pssessionExport;
        private System.Windows.Forms.ToolStripMenuItem TSMILoadPeakLOD;
        private System.Windows.Forms.TabPage eisPlotArea;
        private System.Windows.Forms.TabPage dataArea;
        private System.Windows.Forms.DataGridView dgvMeasurement;
        private System.Windows.Forms.Button btnDataViewSave;
        private System.Windows.Forms.Button btnLoad;
        private RJCodeAdvance.RJControls.RJDropdownMenu rjDropdownMenu1;
        private SDKPlot.WinForms.Plot plot;
        private RJCodeAdvance.RJControls.RJButton btnBluetooth;
        private PalmSens.Core.Simplified.WinForms.PSCommSimpleWinForms psCommSimpleWinForms;
        private components.cvSettings cvSettings1;
        private components.dpSettings dpSettings1;
        private components.isSettings isSettings1;
        private components.pretreatmentSettings pretreatmentSettings1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private RJCodeAdvance.RJControls.RJButton rjButton2;
        private RJCodeAdvance.RJControls.RJButton rjButton22;
        private RJCodeAdvance.RJControls.RJButton rjButton23;
        private RJCodeAdvance.RJControls.RJButton rjButton24;
        private RJCodeAdvance.RJControls.RJButton rjButton25;
        private RJCodeAdvance.RJControls.RJButton rjButton26;
        private RJCodeAdvance.RJControls.RJButton rjButton27;
        private RJCodeAdvance.RJControls.RJButton rjButton28;
        private RJCodeAdvance.RJControls.RJButton rjButton29;
        private RJCodeAdvance.RJControls.RJButton rjButton30;
        private components.currentRangeSettings currentRangeSettings1;
        private components.calculators calculators1;
        private System.Windows.Forms.CheckBox saveSettingsInInternalStorage;
        private SDKPlot.WinForms.Plot eisPlot;
        private System.Windows.Forms.ToolStripMenuItem smoothCurveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detectPeaksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allPlotsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xlsxFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportGraphToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importFrompssessionFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importFromxlsxFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMethodAspssessionFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadMethodFrompssessionFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importFrompssessionFileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem importFromxlsxFileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exportDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportAspssessionFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportAsxlsxFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportGraphAsImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadMeasurementDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMeasurementDaaToLocalStorageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startWithNewPlotToolStripMenuItem;
        private components.regeneration regeneration1;
        private System.Windows.Forms.ToolStripMenuItem regressionAnalysisToolStripMenuItem;
    }
}
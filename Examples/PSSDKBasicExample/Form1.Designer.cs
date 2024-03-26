using System;

namespace PSSDKBasicExample
{
    partial class Form1
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
            this.cmbDevices = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnMeasure = new System.Windows.Forms.Button();
            this.grpConnection = new System.Windows.Forms.GroupBox();
            this.grpDevice = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDeviceStatus = new System.Windows.Forms.TextBox();
            this.lblCurrentRange = new System.Windows.Forms.Label();
            this.lblCurrent = new System.Windows.Forms.Label();
            this.tbCurrent = new System.Windows.Forms.TextBox();
            this.lblVolt = new System.Windows.Forms.Label();
            this.tbPotential = new System.Windows.Forms.TextBox();
            this.lblPotential = new System.Windows.Forms.Label();
            this.grpMeasurement = new System.Windows.Forms.GroupBox();
            this.dgvMeasurement = new System.Windows.Forms.DataGridView();
            this.grpConsole = new System.Windows.Forms.GroupBox();
            this.lbConsole = new System.Windows.Forms.ListBox();
            this.psCommSimpleWinForms = new PalmSens.Core.Simplified.WinForms.PSCommSimpleWinForms(this.components);
            this.grpConnection.SuspendLayout();
            this.grpDevice.SuspendLayout();
            this.grpMeasurement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeasurement)).BeginInit();
            this.grpConsole.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbDevices
            // 
            this.cmbDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDevices.FormattingEnabled = true;
            this.cmbDevices.Location = new System.Drawing.Point(8, 23);
            this.cmbDevices.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbDevices.Name = "cmbDevices";
            this.cmbDevices.Size = new System.Drawing.Size(205, 24);
            this.cmbDevices.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(8, 57);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 28);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Enabled = false;
            this.btnConnect.Location = new System.Drawing.Point(115, 57);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(100, 28);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnMeasure
            // 
            this.btnMeasure.Enabled = false;
            this.btnMeasure.Location = new System.Drawing.Point(8, 23);
            this.btnMeasure.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMeasure.Name = "btnMeasure";
            this.btnMeasure.Size = new System.Drawing.Size(100, 28);
            this.btnMeasure.TabIndex = 3;
            this.btnMeasure.Text = "Measure";
            this.btnMeasure.UseVisualStyleBackColor = true;
            this.btnMeasure.Click += new System.EventHandler(this.btnMeasure_Click);
            // 
            // grpConnection
            // 
            this.grpConnection.Controls.Add(this.cmbDevices);
            this.grpConnection.Controls.Add(this.btnRefresh);
            this.grpConnection.Controls.Add(this.btnConnect);
            this.grpConnection.Location = new System.Drawing.Point(16, 12);
            this.grpConnection.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpConnection.Name = "grpConnection";
            this.grpConnection.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpConnection.Size = new System.Drawing.Size(228, 97);
            this.grpConnection.TabIndex = 4;
            this.grpConnection.TabStop = false;
            this.grpConnection.Text = "Connection";
            // 
            // grpDevice
            // 
            this.grpDevice.Controls.Add(this.label1);
            this.grpDevice.Controls.Add(this.tbDeviceStatus);
            this.grpDevice.Controls.Add(this.lblCurrentRange);
            this.grpDevice.Controls.Add(this.lblCurrent);
            this.grpDevice.Controls.Add(this.tbCurrent);
            this.grpDevice.Controls.Add(this.lblVolt);
            this.grpDevice.Controls.Add(this.tbPotential);
            this.grpDevice.Controls.Add(this.lblPotential);
            this.grpDevice.Location = new System.Drawing.Point(253, 12);
            this.grpDevice.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpDevice.Name = "grpDevice";
            this.grpDevice.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpDevice.Size = new System.Drawing.Size(395, 97);
            this.grpDevice.TabIndex = 5;
            this.grpDevice.TabStop = false;
            this.grpDevice.Text = "Device Status";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(252, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Status:";
            // 
            // tbDeviceStatus
            // 
            this.tbDeviceStatus.Location = new System.Drawing.Point(256, 55);
            this.tbDeviceStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbDeviceStatus.Name = "tbDeviceStatus";
            this.tbDeviceStatus.ReadOnly = true;
            this.tbDeviceStatus.Size = new System.Drawing.Size(129, 22);
            this.tbDeviceStatus.TabIndex = 6;
            // 
            // lblCurrentRange
            // 
            this.lblCurrentRange.AutoSize = true;
            this.lblCurrentRange.Location = new System.Drawing.Point(187, 59);
            this.lblCurrentRange.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCurrentRange.Name = "lblCurrentRange";
            this.lblCurrentRange.Size = new System.Drawing.Size(52, 16);
            this.lblCurrentRange.TabIndex = 5;
            this.lblCurrentRange.Text = "* 10 mA";
            // 
            // lblCurrent
            // 
            this.lblCurrent.AutoSize = true;
            this.lblCurrent.Location = new System.Drawing.Point(9, 59);
            this.lblCurrent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(52, 16);
            this.lblCurrent.TabIndex = 4;
            this.lblCurrent.Text = "Current:";
            // 
            // tbCurrent
            // 
            this.tbCurrent.Location = new System.Drawing.Point(85, 55);
            this.tbCurrent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbCurrent.Name = "tbCurrent";
            this.tbCurrent.ReadOnly = true;
            this.tbCurrent.Size = new System.Drawing.Size(92, 22);
            this.tbCurrent.TabIndex = 3;
            // 
            // lblVolt
            // 
            this.lblVolt.AutoSize = true;
            this.lblVolt.Location = new System.Drawing.Point(187, 27);
            this.lblVolt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVolt.Name = "lblVolt";
            this.lblVolt.Size = new System.Drawing.Size(16, 16);
            this.lblVolt.TabIndex = 2;
            this.lblVolt.Text = "V";
            // 
            // tbPotential
            // 
            this.tbPotential.Location = new System.Drawing.Point(85, 23);
            this.tbPotential.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbPotential.Name = "tbPotential";
            this.tbPotential.ReadOnly = true;
            this.tbPotential.Size = new System.Drawing.Size(92, 22);
            this.tbPotential.TabIndex = 1;
            this.tbPotential.TextChanged += new System.EventHandler(this.tbPotential_TextChanged);
            // 
            // lblPotential
            // 
            this.lblPotential.AutoSize = true;
            this.lblPotential.Location = new System.Drawing.Point(9, 27);
            this.lblPotential.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPotential.Name = "lblPotential";
            this.lblPotential.Size = new System.Drawing.Size(62, 16);
            this.lblPotential.TabIndex = 0;
            this.lblPotential.Text = "Potential:";
            // 
            // grpMeasurement
            // 
            this.grpMeasurement.Controls.Add(this.dgvMeasurement);
            this.grpMeasurement.Controls.Add(this.btnMeasure);
            this.grpMeasurement.Location = new System.Drawing.Point(253, 118);
            this.grpMeasurement.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpMeasurement.Name = "grpMeasurement";
            this.grpMeasurement.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpMeasurement.Size = new System.Drawing.Size(395, 373);
            this.grpMeasurement.TabIndex = 6;
            this.grpMeasurement.TabStop = false;
            this.grpMeasurement.Text = "Measurement";
            // 
            // dgvMeasurement
            // 
            this.dgvMeasurement.AllowUserToAddRows = false;
            this.dgvMeasurement.AllowUserToDeleteRows = false;
            this.dgvMeasurement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMeasurement.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvMeasurement.Location = new System.Drawing.Point(9, 60);
            this.dgvMeasurement.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvMeasurement.Name = "dgvMeasurement";
            this.dgvMeasurement.ReadOnly = true;
            this.dgvMeasurement.RowHeadersVisible = false;
            this.dgvMeasurement.RowHeadersWidth = 51;
            this.dgvMeasurement.Size = new System.Drawing.Size(377, 305);
            this.dgvMeasurement.TabIndex = 4;
            // 
            // grpConsole
            // 
            this.grpConsole.Controls.Add(this.lbConsole);
            this.grpConsole.Location = new System.Drawing.Point(16, 118);
            this.grpConsole.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpConsole.Name = "grpConsole";
            this.grpConsole.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpConsole.Size = new System.Drawing.Size(229, 373);
            this.grpConsole.TabIndex = 7;
            this.grpConsole.TabStop = false;
            this.grpConsole.Text = "Console";
            // 
            // lbConsole
            // 
            this.lbConsole.FormattingEnabled = true;
            this.lbConsole.ItemHeight = 16;
            this.lbConsole.Location = new System.Drawing.Point(9, 23);
            this.lbConsole.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbConsole.Name = "lbConsole";
            this.lbConsole.Size = new System.Drawing.Size(204, 340);
            this.lbConsole.TabIndex = 0;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 506);
            this.Controls.Add(this.grpConsole);
            this.Controls.Add(this.grpMeasurement);
            this.Controls.Add(this.grpDevice);
            this.Controls.Add(this.grpConnection);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.grpConnection.ResumeLayout(false);
            this.grpDevice.ResumeLayout(false);
            this.grpDevice.PerformLayout();
            this.grpMeasurement.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeasurement)).EndInit();
            this.grpConsole.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private PalmSens.Core.Simplified.WinForms.PSCommSimpleWinForms psCommSimpleWinForms;
        private System.Windows.Forms.Button btnMeasure;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox cmbDevices;
        private System.Windows.Forms.GroupBox grpConnection;
        private System.Windows.Forms.GroupBox grpDevice;
        private System.Windows.Forms.GroupBox grpMeasurement;
        private System.Windows.Forms.DataGridView dgvMeasurement;
        private System.Windows.Forms.GroupBox grpConsole;
        private System.Windows.Forms.ListBox lbConsole;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDeviceStatus;
        private System.Windows.Forms.Label lblCurrentRange;
        private System.Windows.Forms.Label lblCurrent;
        private System.Windows.Forms.TextBox tbCurrent;
        private System.Windows.Forms.Label lblVolt;
        private System.Windows.Forms.TextBox tbPotential;
        private System.Windows.Forms.Label lblPotential;
    }
}


using OxyPlot;

namespace PalmSense4
{
    partial class Main
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
            this.Connection = new System.Windows.Forms.GroupBox();
            this.Properties = new System.Windows.Forms.GroupBox();
            this.Measurements = new System.Windows.Forms.GroupBox();
            this.Plot = new System.Windows.Forms.GroupBox();
            this.psCommSimpleWinForms = new PalmSens.Core.Simplified.WinForms.PSCommSimpleWinForms(this.components);
            this.Title = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Close = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Connection
            // 
            this.Connection.Location = new System.Drawing.Point(12, 66);
            this.Connection.Name = "Connection";
            this.Connection.Size = new System.Drawing.Size(251, 116);
            this.Connection.TabIndex = 0;
            this.Connection.TabStop = false;
            this.Connection.Text = "Connection";
            this.Connection.Enter += new System.EventHandler(this.Connection_Enter);
            // 
            // Properties
            // 
            this.Properties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Properties.Location = new System.Drawing.Point(269, 66);
            this.Properties.Name = "Properties";
            this.Properties.Size = new System.Drawing.Size(871, 116);
            this.Properties.TabIndex = 1;
            this.Properties.TabStop = false;
            this.Properties.Text = "Device Properties";
            // 
            // Measurements
            // 
            this.Measurements.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Measurements.Location = new System.Drawing.Point(12, 188);
            this.Measurements.Name = "Measurements";
            this.Measurements.Size = new System.Drawing.Size(251, 509);
            this.Measurements.TabIndex = 1;
            this.Measurements.TabStop = false;
            this.Measurements.Text = "Measurements";
            // 
            // Plot
            // 
            this.Plot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Plot.Location = new System.Drawing.Point(269, 188);
            this.Plot.Name = "Plot";
            this.Plot.Size = new System.Drawing.Size(871, 509);
            this.Plot.TabIndex = 2;
            this.Plot.TabStop = false;
            this.Plot.Text = "Plot";
            // 
            // psCommSimpleWinForms
            // 
            this.psCommSimpleWinForms.EnableBluetooth = false;
            this.psCommSimpleWinForms.EnableSerialPort = false;
            this.psCommSimpleWinForms.Parent = this;
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(10, 13);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(270, 24);
            this.Title.TabIndex = 3;
            this.Title.Text = "PalmSense4 Control Center";
            this.Title.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.Close);
            this.panel1.Controls.Add(this.Title);
            this.panel1.Location = new System.Drawing.Point(-3, -4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1160, 48);
            this.panel1.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(1026, 10);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(35, 35);
            this.button2.TabIndex = 6;
            this.button2.Text = "_";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(1067, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 35);
            this.button1.TabIndex = 5;
            this.button1.Text = "[ ]";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Close
            // 
            this.Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Close.Location = new System.Drawing.Point(1108, 10);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(35, 35);
            this.Close.TabIndex = 4;
            this.Close.Text = "X";
            this.Close.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1152, 709);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Plot);
            this.Controls.Add(this.Measurements);
            this.Controls.Add(this.Properties);
            this.Controls.Add(this.Connection);
            this.Name = "Main";
            this.TransparencyKey = System.Drawing.Color.Black;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Connection;
        private System.Windows.Forms.GroupBox Properties;
        private System.Windows.Forms.GroupBox Measurements;
        private System.Windows.Forms.GroupBox Plot;
        private PalmSens.Core.Simplified.WinForms.PSCommSimpleWinForms psCommSimpleWinForms;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}


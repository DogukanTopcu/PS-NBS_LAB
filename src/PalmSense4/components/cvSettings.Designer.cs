namespace PalmSense4.components
{
    partial class cvSettings
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cvSettings));
            this.rjButton1 = new RJCodeAdvance.RJControls.RJButton();
            this.tbNumberOfScan = new RJCodeAdvance.RJControls.RJTextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.tbScanRate = new RJCodeAdvance.RJControls.RJTextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.tbEStep = new RJCodeAdvance.RJControls.RJTextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.tbEVertex2 = new RJCodeAdvance.RJControls.RJTextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.tbEVertex1 = new RJCodeAdvance.RJControls.RJTextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.tbEBegin = new RJCodeAdvance.RJControls.RJTextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbTEq = new RJCodeAdvance.RJControls.RJTextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rjButton1
            // 
            this.rjButton1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.rjButton1.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.rjButton1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton1.BorderRadius = 0;
            this.rjButton1.BorderSize = 0;
            this.rjButton1.Dock = System.Windows.Forms.DockStyle.Top;
            this.rjButton1.FlatAppearance.BorderSize = 0;
            this.rjButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjButton1.ForeColor = System.Drawing.Color.Black;
            this.rjButton1.Image = ((System.Drawing.Image)(resources.GetObject("rjButton1.Image")));
            this.rjButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rjButton1.Location = new System.Drawing.Point(0, 0);
            this.rjButton1.Name = "rjButton1";
            this.rjButton1.Size = new System.Drawing.Size(435, 41);
            this.rjButton1.TabIndex = 0;
            this.rjButton1.Text = "Cyclic Voltammetry Settings";
            this.rjButton1.TextColor = System.Drawing.Color.Black;
            this.rjButton1.UseVisualStyleBackColor = false;
            this.rjButton1.Click += new System.EventHandler(this.rjButton1_Click);
            // 
            // tbNumberOfScan
            // 
            this.tbNumberOfScan.BackColor = System.Drawing.SystemColors.Window;
            this.tbNumberOfScan.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.tbNumberOfScan.BorderFocusColor = System.Drawing.Color.HotPink;
            this.tbNumberOfScan.BorderRadius = 0;
            this.tbNumberOfScan.BorderSize = 2;
            this.tbNumberOfScan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNumberOfScan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbNumberOfScan.Location = new System.Drawing.Point(203, 325);
            this.tbNumberOfScan.Margin = new System.Windows.Forms.Padding(4);
            this.tbNumberOfScan.Multiline = false;
            this.tbNumberOfScan.Name = "tbNumberOfScan";
            this.tbNumberOfScan.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tbNumberOfScan.PasswordChar = false;
            this.tbNumberOfScan.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.tbNumberOfScan.PlaceholderText = "";
            this.tbNumberOfScan.Size = new System.Drawing.Size(134, 35);
            this.tbNumberOfScan.TabIndex = 71;
            this.tbNumberOfScan.Texts = "";
            this.tbNumberOfScan.UnderlinedStyle = false;
            this.tbNumberOfScan._TextChanged += new System.EventHandler(this.tbNumberOfScan__TextChanged);
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.Location = new System.Drawing.Point(35, 333);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(165, 25);
            this.label41.TabIndex = 70;
            this.label41.Text = "Number of scans:";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.Location = new System.Drawing.Point(344, 288);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(42, 25);
            this.label38.TabIndex = 66;
            this.label38.Text = "V/s";
            // 
            // tbScanRate
            // 
            this.tbScanRate.BackColor = System.Drawing.SystemColors.Window;
            this.tbScanRate.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.tbScanRate.BorderFocusColor = System.Drawing.Color.HotPink;
            this.tbScanRate.BorderRadius = 0;
            this.tbScanRate.BorderSize = 2;
            this.tbScanRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbScanRate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbScanRate.Location = new System.Drawing.Point(203, 282);
            this.tbScanRate.Margin = new System.Windows.Forms.Padding(4);
            this.tbScanRate.Multiline = false;
            this.tbScanRate.Name = "tbScanRate";
            this.tbScanRate.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tbScanRate.PasswordChar = false;
            this.tbScanRate.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.tbScanRate.PlaceholderText = "";
            this.tbScanRate.Size = new System.Drawing.Size(134, 35);
            this.tbScanRate.TabIndex = 68;
            this.tbScanRate.Texts = "";
            this.tbScanRate.UnderlinedStyle = false;
            this.tbScanRate._TextChanged += new System.EventHandler(this.tbScanRate__TextChanged);
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.Location = new System.Drawing.Point(35, 294);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(102, 25);
            this.label39.TabIndex = 67;
            this.label39.Text = "Scan rate:";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(344, 245);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(26, 25);
            this.label36.TabIndex = 63;
            this.label36.Text = "V";
            // 
            // tbEStep
            // 
            this.tbEStep.BackColor = System.Drawing.SystemColors.Window;
            this.tbEStep.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.tbEStep.BorderFocusColor = System.Drawing.Color.HotPink;
            this.tbEStep.BorderRadius = 0;
            this.tbEStep.BorderSize = 2;
            this.tbEStep.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEStep.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbEStep.Location = new System.Drawing.Point(203, 239);
            this.tbEStep.Margin = new System.Windows.Forms.Padding(4);
            this.tbEStep.Multiline = false;
            this.tbEStep.Name = "tbEStep";
            this.tbEStep.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tbEStep.PasswordChar = false;
            this.tbEStep.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.tbEStep.PlaceholderText = "";
            this.tbEStep.Size = new System.Drawing.Size(134, 35);
            this.tbEStep.TabIndex = 65;
            this.tbEStep.Texts = "";
            this.tbEStep.UnderlinedStyle = false;
            this.tbEStep._TextChanged += new System.EventHandler(this.tbEStep__TextChanged);
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.Location = new System.Drawing.Point(35, 245);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(73, 25);
            this.label37.TabIndex = 64;
            this.label37.Text = "E step:";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(344, 202);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(26, 25);
            this.label34.TabIndex = 60;
            this.label34.Text = "V";
            // 
            // tbEVertex2
            // 
            this.tbEVertex2.BackColor = System.Drawing.SystemColors.Window;
            this.tbEVertex2.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.tbEVertex2.BorderFocusColor = System.Drawing.Color.HotPink;
            this.tbEVertex2.BorderRadius = 0;
            this.tbEVertex2.BorderSize = 2;
            this.tbEVertex2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEVertex2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbEVertex2.Location = new System.Drawing.Point(203, 196);
            this.tbEVertex2.Margin = new System.Windows.Forms.Padding(4);
            this.tbEVertex2.Multiline = false;
            this.tbEVertex2.Name = "tbEVertex2";
            this.tbEVertex2.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tbEVertex2.PasswordChar = false;
            this.tbEVertex2.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.tbEVertex2.PlaceholderText = "";
            this.tbEVertex2.Size = new System.Drawing.Size(134, 35);
            this.tbEVertex2.TabIndex = 62;
            this.tbEVertex2.Texts = "";
            this.tbEVertex2.UnderlinedStyle = false;
            this.tbEVertex2._TextChanged += new System.EventHandler(this.tbEVertex2__TextChanged);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.Location = new System.Drawing.Point(35, 202);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(100, 25);
            this.label35.TabIndex = 61;
            this.label35.Text = "E vertex2:";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(344, 159);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(26, 25);
            this.label32.TabIndex = 57;
            this.label32.Text = "V";
            // 
            // tbEVertex1
            // 
            this.tbEVertex1.BackColor = System.Drawing.SystemColors.Window;
            this.tbEVertex1.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.tbEVertex1.BorderFocusColor = System.Drawing.Color.HotPink;
            this.tbEVertex1.BorderRadius = 0;
            this.tbEVertex1.BorderSize = 2;
            this.tbEVertex1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEVertex1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbEVertex1.Location = new System.Drawing.Point(203, 153);
            this.tbEVertex1.Margin = new System.Windows.Forms.Padding(4);
            this.tbEVertex1.Multiline = false;
            this.tbEVertex1.Name = "tbEVertex1";
            this.tbEVertex1.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tbEVertex1.PasswordChar = false;
            this.tbEVertex1.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.tbEVertex1.PlaceholderText = "";
            this.tbEVertex1.Size = new System.Drawing.Size(134, 35);
            this.tbEVertex1.TabIndex = 59;
            this.tbEVertex1.Texts = "";
            this.tbEVertex1.UnderlinedStyle = false;
            this.tbEVertex1._TextChanged += new System.EventHandler(this.tbEVertex1__TextChanged);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(35, 159);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(100, 25);
            this.label33.TabIndex = 58;
            this.label33.Text = "E vertex1:";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(344, 116);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(26, 25);
            this.label30.TabIndex = 54;
            this.label30.Text = "V";
            // 
            // tbEBegin
            // 
            this.tbEBegin.BackColor = System.Drawing.SystemColors.Window;
            this.tbEBegin.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.tbEBegin.BorderFocusColor = System.Drawing.Color.HotPink;
            this.tbEBegin.BorderRadius = 0;
            this.tbEBegin.BorderSize = 2;
            this.tbEBegin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEBegin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbEBegin.Location = new System.Drawing.Point(203, 110);
            this.tbEBegin.Margin = new System.Windows.Forms.Padding(4);
            this.tbEBegin.Multiline = false;
            this.tbEBegin.Name = "tbEBegin";
            this.tbEBegin.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tbEBegin.PasswordChar = false;
            this.tbEBegin.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.tbEBegin.PlaceholderText = "";
            this.tbEBegin.Size = new System.Drawing.Size(134, 35);
            this.tbEBegin.TabIndex = 56;
            this.tbEBegin.Texts = "";
            this.tbEBegin.UnderlinedStyle = false;
            this.tbEBegin._TextChanged += new System.EventHandler(this.tbEBegin__TextChanged);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(35, 116);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(84, 25);
            this.label31.TabIndex = 55;
            this.label31.Text = "E begin:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(344, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 25);
            this.label3.TabIndex = 51;
            this.label3.Text = "s";
            // 
            // tbTEq
            // 
            this.tbTEq.BackColor = System.Drawing.SystemColors.Window;
            this.tbTEq.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.tbTEq.BorderFocusColor = System.Drawing.Color.HotPink;
            this.tbTEq.BorderRadius = 0;
            this.tbTEq.BorderSize = 2;
            this.tbTEq.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTEq.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbTEq.Location = new System.Drawing.Point(203, 68);
            this.tbTEq.Margin = new System.Windows.Forms.Padding(4);
            this.tbTEq.Multiline = false;
            this.tbTEq.Name = "tbTEq";
            this.tbTEq.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tbTEq.PasswordChar = false;
            this.tbTEq.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.tbTEq.PlaceholderText = "";
            this.tbTEq.Size = new System.Drawing.Size(134, 35);
            this.tbTEq.TabIndex = 53;
            this.tbTEq.Texts = "";
            this.tbTEq.UnderlinedStyle = false;
            this.tbTEq._TextChanged += new System.EventHandler(this.tbTEq__TextChanged);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(35, 72);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(132, 25);
            this.label29.TabIndex = 52;
            this.label29.Text = "t equilibration:";
            // 
            // cvSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbNumberOfScan);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.label38);
            this.Controls.Add(this.tbScanRate);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.tbEStep);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.tbEVertex2);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.tbEVertex1);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.tbEBegin);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbTEq);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.rjButton1);
            this.Name = "cvSettings";
            this.Size = new System.Drawing.Size(435, 380);
            this.Load += new System.EventHandler(this.cvSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RJCodeAdvance.RJControls.RJButton rjButton1;
        private RJCodeAdvance.RJControls.RJTextBox tbNumberOfScan;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label38;
        private RJCodeAdvance.RJControls.RJTextBox tbScanRate;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label36;
        private RJCodeAdvance.RJControls.RJTextBox tbEStep;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label34;
        private RJCodeAdvance.RJControls.RJTextBox tbEVertex2;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label32;
        private RJCodeAdvance.RJControls.RJTextBox tbEVertex1;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label30;
        private RJCodeAdvance.RJControls.RJTextBox tbEBegin;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label3;
        private RJCodeAdvance.RJControls.RJTextBox tbTEq;
        private System.Windows.Forms.Label label29;
    }
}

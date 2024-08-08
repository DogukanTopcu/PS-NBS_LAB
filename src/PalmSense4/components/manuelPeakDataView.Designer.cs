namespace PalmSense4.components
{
    partial class manuelPeakDataView
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
            this.peakCount = new System.Windows.Forms.Label();
            this.xVal = new System.Windows.Forms.Label();
            this.yVal = new System.Windows.Forms.Label();
            this.xValInput = new RJCodeAdvance.RJControls.RJTextBox();
            this.yValInput = new RJCodeAdvance.RJControls.RJTextBox();
            this.SuspendLayout();
            // 
            // peakCount
            // 
            this.peakCount.AutoSize = true;
            this.peakCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.peakCount.Location = new System.Drawing.Point(2, 18);
            this.peakCount.Name = "peakCount";
            this.peakCount.Size = new System.Drawing.Size(79, 25);
            this.peakCount.TabIndex = 0;
            this.peakCount.Text = "Peak 1:";
            // 
            // xVal
            // 
            this.xVal.AutoSize = true;
            this.xVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xVal.Location = new System.Drawing.Point(78, 18);
            this.xVal.Name = "xVal";
            this.xVal.Size = new System.Drawing.Size(26, 25);
            this.xVal.TabIndex = 1;
            this.xVal.Text = "X";
            this.xVal.Click += new System.EventHandler(this.xVal_Click);
            // 
            // yVal
            // 
            this.yVal.AutoSize = true;
            this.yVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yVal.Location = new System.Drawing.Point(223, 18);
            this.yVal.Name = "yVal";
            this.yVal.Size = new System.Drawing.Size(63, 25);
            this.yVal.TabIndex = 2;
            this.yVal.Text = "Value";
            // 
            // xValInput
            // 
            this.xValInput.BackColor = System.Drawing.SystemColors.Window;
            this.xValInput.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.xValInput.BorderFocusColor = System.Drawing.Color.HotPink;
            this.xValInput.BorderRadius = 0;
            this.xValInput.BorderSize = 2;
            this.xValInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xValInput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.xValInput.Location = new System.Drawing.Point(111, 13);
            this.xValInput.Margin = new System.Windows.Forms.Padding(4);
            this.xValInput.Multiline = false;
            this.xValInput.Name = "xValInput";
            this.xValInput.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.xValInput.PasswordChar = false;
            this.xValInput.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.xValInput.PlaceholderText = "";
            this.xValInput.Size = new System.Drawing.Size(105, 35);
            this.xValInput.TabIndex = 3;
            this.xValInput.Texts = "";
            this.xValInput.UnderlinedStyle = false;
            this.xValInput._TextChanged += new System.EventHandler(this.xValInput__TextChanged);
            // 
            // yValInput
            // 
            this.yValInput.BackColor = System.Drawing.SystemColors.Window;
            this.yValInput.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.yValInput.BorderFocusColor = System.Drawing.Color.HotPink;
            this.yValInput.BorderRadius = 0;
            this.yValInput.BorderSize = 2;
            this.yValInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yValInput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.yValInput.Location = new System.Drawing.Point(283, 13);
            this.yValInput.Margin = new System.Windows.Forms.Padding(4);
            this.yValInput.Multiline = false;
            this.yValInput.Name = "yValInput";
            this.yValInput.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.yValInput.PasswordChar = false;
            this.yValInput.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.yValInput.PlaceholderText = "";
            this.yValInput.Size = new System.Drawing.Size(105, 35);
            this.yValInput.TabIndex = 4;
            this.yValInput.Texts = "";
            this.yValInput.UnderlinedStyle = false;
            this.yValInput._TextChanged += new System.EventHandler(this.yValInput__TextChanged);
            // 
            // manuelPeakDataView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.yValInput);
            this.Controls.Add(this.xValInput);
            this.Controls.Add(this.yVal);
            this.Controls.Add(this.xVal);
            this.Controls.Add(this.peakCount);
            this.Name = "manuelPeakDataView";
            this.Size = new System.Drawing.Size(388, 60);
            this.Load += new System.EventHandler(this.manuelPeakDataView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label peakCount;
        private System.Windows.Forms.Label xVal;
        private System.Windows.Forms.Label yVal;
        private RJCodeAdvance.RJControls.RJTextBox xValInput;
        private RJCodeAdvance.RJControls.RJTextBox yValInput;
    }
}

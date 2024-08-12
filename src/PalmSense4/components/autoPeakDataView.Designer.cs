namespace PalmSense4.components
{
    partial class autoPeakDataView
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
            this.plotName = new System.Windows.Forms.Label();
            this.concentration_value = new RJCodeAdvance.RJControls.RJTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbPeaks = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.duplicateBtn = new System.Windows.Forms.Button();
            this.removeBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // plotName
            // 
            this.plotName.AutoSize = true;
            this.plotName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plotName.Location = new System.Drawing.Point(3, 0);
            this.plotName.Name = "plotName";
            this.plotName.Size = new System.Drawing.Size(102, 20);
            this.plotName.TabIndex = 0;
            this.plotName.Text = "Plot Name:";
            // 
            // concentration_value
            // 
            this.concentration_value.BackColor = System.Drawing.SystemColors.Window;
            this.concentration_value.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.concentration_value.BorderFocusColor = System.Drawing.Color.HotPink;
            this.concentration_value.BorderRadius = 0;
            this.concentration_value.BorderSize = 2;
            this.concentration_value.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.concentration_value.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.concentration_value.Location = new System.Drawing.Point(7, 49);
            this.concentration_value.Margin = new System.Windows.Forms.Padding(4);
            this.concentration_value.Multiline = false;
            this.concentration_value.Name = "concentration_value";
            this.concentration_value.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.concentration_value.PasswordChar = false;
            this.concentration_value.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.concentration_value.PlaceholderText = "";
            this.concentration_value.Size = new System.Drawing.Size(161, 35);
            this.concentration_value.TabIndex = 1;
            this.concentration_value.Texts = "";
            this.concentration_value.UnderlinedStyle = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Concentration:";
            // 
            // cbPeaks
            // 
            this.cbPeaks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPeaks.FormattingEnabled = true;
            this.cbPeaks.Location = new System.Drawing.Point(188, 49);
            this.cbPeaks.Name = "cbPeaks";
            this.cbPeaks.Size = new System.Drawing.Size(161, 33);
            this.cbPeaks.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(184, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Current:";
            // 
            // duplicateBtn
            // 
            this.duplicateBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.duplicateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.duplicateBtn.Location = new System.Drawing.Point(363, 36);
            this.duplicateBtn.Name = "duplicateBtn";
            this.duplicateBtn.Size = new System.Drawing.Size(30, 30);
            this.duplicateBtn.TabIndex = 5;
            this.duplicateBtn.Text = "+";
            this.duplicateBtn.UseVisualStyleBackColor = true;
            this.duplicateBtn.Click += new System.EventHandler(this.duplicateBtn_Click);
            // 
            // removeBtn
            // 
            this.removeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.removeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeBtn.Location = new System.Drawing.Point(363, 36);
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.Size = new System.Drawing.Size(30, 30);
            this.removeBtn.TabIndex = 6;
            this.removeBtn.Text = "-";
            this.removeBtn.UseVisualStyleBackColor = true;
            this.removeBtn.Click += new System.EventHandler(this.removeBtn_Click);
            // 
            // autoPeakDataView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.removeBtn);
            this.Controls.Add(this.duplicateBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbPeaks);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.concentration_value);
            this.Controls.Add(this.plotName);
            this.Name = "autoPeakDataView";
            this.Size = new System.Drawing.Size(396, 88);
            this.Load += new System.EventHandler(this.autoPeakDataView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label plotName;
        private RJCodeAdvance.RJControls.RJTextBox concentration_value;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbPeaks;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button duplicateBtn;
        private System.Windows.Forms.Button removeBtn;
    }
}

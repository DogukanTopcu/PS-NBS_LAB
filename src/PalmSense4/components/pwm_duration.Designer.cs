namespace PalmSense4.components
{
    partial class pwm_duration
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pwm_duration));
            this.label1 = new System.Windows.Forms.Label();
            this.rjButton1 = new RJCodeAdvance.RJControls.RJButton();
            this.rjButton2 = new RJCodeAdvance.RJControls.RJButton();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.refr = new RJCodeAdvance.RJControls.RJButton();
            this.cbPorts = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pump Settings";
            // 
            // rjButton1
            // 
            this.rjButton1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.rjButton1.BackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.rjButton1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton1.BorderRadius = 0;
            this.rjButton1.BorderSize = 0;
            this.rjButton1.FlatAppearance.BorderSize = 0;
            this.rjButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjButton1.ForeColor = System.Drawing.Color.White;
            this.rjButton1.Location = new System.Drawing.Point(162, 50);
            this.rjButton1.Name = "rjButton1";
            this.rjButton1.Size = new System.Drawing.Size(120, 32);
            this.rjButton1.TabIndex = 1;
            this.rjButton1.Text = "Low";
            this.rjButton1.TextColor = System.Drawing.Color.White;
            this.rjButton1.UseVisualStyleBackColor = false;
            this.rjButton1.Click += new System.EventHandler(this.rjButton1_Click);
            // 
            // rjButton2
            // 
            this.rjButton2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.rjButton2.BackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.rjButton2.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton2.BorderRadius = 0;
            this.rjButton2.BorderSize = 0;
            this.rjButton2.FlatAppearance.BorderSize = 0;
            this.rjButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjButton2.ForeColor = System.Drawing.Color.White;
            this.rjButton2.Location = new System.Drawing.Point(288, 50);
            this.rjButton2.Name = "rjButton2";
            this.rjButton2.Size = new System.Drawing.Size(120, 32);
            this.rjButton2.TabIndex = 2;
            this.rjButton2.Text = "High";
            this.rjButton2.TextColor = System.Drawing.Color.White;
            this.rjButton2.UseVisualStyleBackColor = false;
            this.rjButton2.Click += new System.EventHandler(this.rjButton2_Click);
            // 
            // refr
            // 
            this.refr.BackColor = System.Drawing.Color.Transparent;
            this.refr.BackgroundColor = System.Drawing.Color.Transparent;
            this.refr.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("refr.BackgroundImage")));
            this.refr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.refr.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.refr.BorderRadius = 0;
            this.refr.BorderSize = 0;
            this.refr.FlatAppearance.BorderSize = 0;
            this.refr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refr.ForeColor = System.Drawing.Color.White;
            this.refr.Location = new System.Drawing.Point(425, 14);
            this.refr.Name = "refr";
            this.refr.Size = new System.Drawing.Size(32, 32);
            this.refr.TabIndex = 13;
            this.refr.TextColor = System.Drawing.Color.White;
            this.refr.UseVisualStyleBackColor = false;
            this.refr.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cbPorts
            // 
            this.cbPorts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPorts.FormattingEnabled = true;
            this.cbPorts.Location = new System.Drawing.Point(162, 12);
            this.cbPorts.Name = "cbPorts";
            this.cbPorts.Size = new System.Drawing.Size(246, 33);
            this.cbPorts.TabIndex = 14;
            this.cbPorts.SelectedIndexChanged += new System.EventHandler(this.cbPorts_SelectedIndexChanged);
            // 
            // pwm_duration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbPorts);
            this.Controls.Add(this.refr);
            this.Controls.Add(this.rjButton2);
            this.Controls.Add(this.rjButton1);
            this.Controls.Add(this.label1);
            this.Name = "pwm_duration";
            this.Size = new System.Drawing.Size(469, 94);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private RJCodeAdvance.RJControls.RJButton rjButton1;
        private RJCodeAdvance.RJControls.RJButton rjButton2;
        private System.IO.Ports.SerialPort serialPort1;
        private RJCodeAdvance.RJControls.RJButton refr;
        private System.Windows.Forms.ComboBox cbPorts;
    }
}

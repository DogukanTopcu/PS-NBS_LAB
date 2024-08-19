namespace PalmSense4
{
    partial class RegressionAnalysis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegressionAnalysis));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.autoDetectedPlots = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.decreaseBtn = new RJCodeAdvance.RJControls.RJButton();
            this.increaseBtn = new RJCodeAdvance.RJControls.RJButton();
            this.manuelPeaks = new System.Windows.Forms.FlowLayoutPanel();
            this.lblManuelPeaks = new System.Windows.Forms.Label();
            this.plotsList = new System.Windows.Forms.CheckedListBox();
            this.calculateBtn = new RJCodeAdvance.RJControls.RJButton();
            this.lblPlots = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.formul = new System.Windows.Forms.Label();
            this.plot1 = new SDKPlot.WinForms.Plot();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.plot2 = new SDKPlot.WinForms.Plot();
            this.rjButton1 = new RJCodeAdvance.RJControls.RJButton();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.exportToolStripMenuItem,
            this.importDataToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1243, 36);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(14, 32);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(129, 32);
            this.exportToolStripMenuItem.Text = "Export Data";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // importDataToolStripMenuItem
            // 
            this.importDataToolStripMenuItem.Name = "importDataToolStripMenuItem";
            this.importDataToolStripMenuItem.Size = new System.Drawing.Size(132, 32);
            this.importDataToolStripMenuItem.Text = "Import Data";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 36);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel2.Controls.Add(this.rjButton1);
            this.splitContainer1.Size = new System.Drawing.Size(1243, 761);
            this.splitContainer1.SplitterDistance = 464;
            this.splitContainer1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.autoDetectedPlots);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.decreaseBtn);
            this.panel1.Controls.Add(this.increaseBtn);
            this.panel1.Controls.Add(this.manuelPeaks);
            this.panel1.Controls.Add(this.lblManuelPeaks);
            this.panel1.Controls.Add(this.plotsList);
            this.panel1.Controls.Add(this.calculateBtn);
            this.panel1.Controls.Add(this.lblPlots);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(464, 761);
            this.panel1.TabIndex = 0;
            // 
            // autoDetectedPlots
            // 
            this.autoDetectedPlots.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.autoDetectedPlots.AutoScroll = true;
            this.autoDetectedPlots.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.autoDetectedPlots.Location = new System.Drawing.Point(18, 198);
            this.autoDetectedPlots.Name = "autoDetectedPlots";
            this.autoDetectedPlots.Size = new System.Drawing.Size(435, 258);
            this.autoDetectedPlots.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 679);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(334, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "C: Concentration, Cur: Current Value";
            // 
            // decreaseBtn
            // 
            this.decreaseBtn.BackColor = System.Drawing.Color.CornflowerBlue;
            this.decreaseBtn.BackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.decreaseBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.decreaseBtn.BorderRadius = 0;
            this.decreaseBtn.BorderSize = 0;
            this.decreaseBtn.FlatAppearance.BorderSize = 0;
            this.decreaseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.decreaseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.decreaseBtn.ForeColor = System.Drawing.Color.White;
            this.decreaseBtn.Location = new System.Drawing.Point(351, 462);
            this.decreaseBtn.Name = "decreaseBtn";
            this.decreaseBtn.Size = new System.Drawing.Size(48, 40);
            this.decreaseBtn.TabIndex = 6;
            this.decreaseBtn.Text = "-";
            this.decreaseBtn.TextColor = System.Drawing.Color.White;
            this.decreaseBtn.UseVisualStyleBackColor = false;
            this.decreaseBtn.Click += new System.EventHandler(this.decreaseBtn_Click);
            // 
            // increaseBtn
            // 
            this.increaseBtn.BackColor = System.Drawing.Color.CornflowerBlue;
            this.increaseBtn.BackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.increaseBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.increaseBtn.BorderRadius = 0;
            this.increaseBtn.BorderSize = 0;
            this.increaseBtn.FlatAppearance.BorderSize = 0;
            this.increaseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.increaseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.increaseBtn.ForeColor = System.Drawing.Color.White;
            this.increaseBtn.Location = new System.Drawing.Point(405, 462);
            this.increaseBtn.Name = "increaseBtn";
            this.increaseBtn.Size = new System.Drawing.Size(48, 40);
            this.increaseBtn.TabIndex = 5;
            this.increaseBtn.Text = "+";
            this.increaseBtn.TextColor = System.Drawing.Color.White;
            this.increaseBtn.UseVisualStyleBackColor = false;
            this.increaseBtn.Click += new System.EventHandler(this.increaseBtn_Click);
            // 
            // manuelPeaks
            // 
            this.manuelPeaks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.manuelPeaks.AutoScroll = true;
            this.manuelPeaks.Location = new System.Drawing.Point(18, 508);
            this.manuelPeaks.Name = "manuelPeaks";
            this.manuelPeaks.Size = new System.Drawing.Size(435, 168);
            this.manuelPeaks.TabIndex = 4;
            // 
            // lblManuelPeaks
            // 
            this.lblManuelPeaks.AutoSize = true;
            this.lblManuelPeaks.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManuelPeaks.Location = new System.Drawing.Point(12, 469);
            this.lblManuelPeaks.Name = "lblManuelPeaks";
            this.lblManuelPeaks.Size = new System.Drawing.Size(224, 36);
            this.lblManuelPeaks.TabIndex = 3;
            this.lblManuelPeaks.Text = "Manuel Peaks:";
            // 
            // plotsList
            // 
            this.plotsList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plotsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plotsList.FormattingEnabled = true;
            this.plotsList.Location = new System.Drawing.Point(18, 62);
            this.plotsList.Name = "plotsList";
            this.plotsList.Size = new System.Drawing.Size(435, 130);
            this.plotsList.TabIndex = 0;
            this.plotsList.SelectedIndexChanged += new System.EventHandler(this.plotsList_SelectedIndexChanged);
            // 
            // calculateBtn
            // 
            this.calculateBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.calculateBtn.BackColor = System.Drawing.Color.CornflowerBlue;
            this.calculateBtn.BackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.calculateBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.calculateBtn.BorderRadius = 20;
            this.calculateBtn.BorderSize = 0;
            this.calculateBtn.FlatAppearance.BorderSize = 0;
            this.calculateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.calculateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calculateBtn.ForeColor = System.Drawing.Color.White;
            this.calculateBtn.Location = new System.Drawing.Point(18, 709);
            this.calculateBtn.Name = "calculateBtn";
            this.calculateBtn.Size = new System.Drawing.Size(435, 40);
            this.calculateBtn.TabIndex = 2;
            this.calculateBtn.Text = "Analysis";
            this.calculateBtn.TextColor = System.Drawing.Color.White;
            this.calculateBtn.UseVisualStyleBackColor = false;
            this.calculateBtn.Click += new System.EventHandler(this.calculateBtn_Click);
            // 
            // lblPlots
            // 
            this.lblPlots.AutoSize = true;
            this.lblPlots.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlots.Location = new System.Drawing.Point(12, 23);
            this.lblPlots.Name = "lblPlots";
            this.lblPlots.Size = new System.Drawing.Size(96, 36);
            this.lblPlots.TabIndex = 0;
            this.lblPlots.Text = "Plots:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(42, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(733, 761);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.formul);
            this.tabPage1.Controls.Add(this.plot1);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(725, 723);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Analysis Result";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // formul
            // 
            this.formul.AutoSize = true;
            this.formul.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.formul.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formul.Location = new System.Drawing.Point(3, 691);
            this.formul.Name = "formul";
            this.formul.Size = new System.Drawing.Size(121, 29);
            this.formul.TabIndex = 1;
            this.formul.Text = "y = mx + b";
            // 
            // plot1
            // 
            this.plot1.BackColor = System.Drawing.Color.White;
            this.plot1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plot1.Location = new System.Drawing.Point(3, 3);
            this.plot1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.plot1.MarkerSize = 5;
            this.plot1.MarkerType = OxyPlot.MarkerType.Circle;
            this.plot1.Name = "plot1";
            this.plot1.Size = new System.Drawing.Size(719, 717);
            this.plot1.TabIndex = 0;
            this.plot1.Title = null;
            this.plot1.XAxisLabel = null;
            this.plot1.XAxisType = SDKPlot.AxisType.Linear;
            this.plot1.YAxisLabel = null;
            this.plot1.YAxisSecondaryLabel = null;
            this.plot1.YAxisSecondaryType = SDKPlot.AxisType.Linear;
            this.plot1.YAxisType = SDKPlot.AxisType.Linear;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.plot2);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(725, 723);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Plot Previewer";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // plot2
            // 
            this.plot2.BackColor = System.Drawing.Color.White;
            this.plot2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plot2.Location = new System.Drawing.Point(3, 3);
            this.plot2.Margin = new System.Windows.Forms.Padding(6);
            this.plot2.MarkerSize = 5;
            this.plot2.MarkerType = OxyPlot.MarkerType.Circle;
            this.plot2.Name = "plot2";
            this.plot2.Size = new System.Drawing.Size(719, 717);
            this.plot2.TabIndex = 0;
            this.plot2.Title = null;
            this.plot2.XAxisLabel = null;
            this.plot2.XAxisType = SDKPlot.AxisType.Linear;
            this.plot2.YAxisLabel = null;
            this.plot2.YAxisSecondaryLabel = null;
            this.plot2.YAxisSecondaryType = SDKPlot.AxisType.Linear;
            this.plot2.YAxisType = SDKPlot.AxisType.Linear;
            // 
            // rjButton1
            // 
            this.rjButton1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.rjButton1.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.rjButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rjButton1.BackgroundImage")));
            this.rjButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.rjButton1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton1.BorderRadius = 0;
            this.rjButton1.BorderSize = 0;
            this.rjButton1.Dock = System.Windows.Forms.DockStyle.Left;
            this.rjButton1.FlatAppearance.BorderSize = 0;
            this.rjButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton1.ForeColor = System.Drawing.Color.White;
            this.rjButton1.Location = new System.Drawing.Point(0, 0);
            this.rjButton1.Name = "rjButton1";
            this.rjButton1.Size = new System.Drawing.Size(42, 761);
            this.rjButton1.TabIndex = 1;
            this.rjButton1.TextColor = System.Drawing.Color.White;
            this.rjButton1.UseVisualStyleBackColor = false;
            this.rjButton1.Click += new System.EventHandler(this.rjButton1_Click);
            // 
            // RegressionAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1243, 797);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "RegressionAnalysis";
            this.Text = "regression_analysis";
            this.Load += new System.EventHandler(this.regression_analysis_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importDataToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private SDKPlot.WinForms.Plot plot1;
        private RJCodeAdvance.RJControls.RJButton rjButton1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblPlots;
        private RJCodeAdvance.RJControls.RJButton calculateBtn;
        private System.Windows.Forms.CheckedListBox plotsList;
        private SDKPlot.WinForms.Plot plot2;
        private System.Windows.Forms.Label lblManuelPeaks;
        private System.Windows.Forms.FlowLayoutPanel manuelPeaks;
        private RJCodeAdvance.RJControls.RJButton decreaseBtn;
        private RJCodeAdvance.RJControls.RJButton increaseBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel autoDetectedPlots;
        private System.Windows.Forms.Label formul;
    }
}
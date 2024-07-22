namespace PalmSense4
{
    partial class FilteredPlot
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.plotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smoothCurveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.averageBaselineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subtractBaselineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detectPeaksToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.plot1 = new SDKPlot.WinForms.Plot();
            this.pssessionFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xlsxFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportAsImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regressionAnalysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.plotToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.regressionAnalysisToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1110, 36);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(14, 32);
            // 
            // plotToolStripMenuItem
            // 
            this.plotToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smoothCurveToolStripMenuItem,
            this.averageBaselineToolStripMenuItem,
            this.subtractBaselineToolStripMenuItem,
            this.detectPeaksToolStripMenuItem1});
            this.plotToolStripMenuItem.Name = "plotToolStripMenuItem";
            this.plotToolStripMenuItem.Size = new System.Drawing.Size(61, 32);
            this.plotToolStripMenuItem.Text = "Plot";
            // 
            // smoothCurveToolStripMenuItem
            // 
            this.smoothCurveToolStripMenuItem.Name = "smoothCurveToolStripMenuItem";
            this.smoothCurveToolStripMenuItem.Size = new System.Drawing.Size(247, 32);
            this.smoothCurveToolStripMenuItem.Text = "Smooth Curve";
            this.smoothCurveToolStripMenuItem.Click += new System.EventHandler(this.smoothCurveToolStripMenuItem_Click);
            // 
            // averageBaselineToolStripMenuItem
            // 
            this.averageBaselineToolStripMenuItem.Name = "averageBaselineToolStripMenuItem";
            this.averageBaselineToolStripMenuItem.Size = new System.Drawing.Size(247, 32);
            this.averageBaselineToolStripMenuItem.Text = "Average Baseline";
            this.averageBaselineToolStripMenuItem.Click += new System.EventHandler(this.averageBaselineToolStripMenuItem_Click);
            // 
            // subtractBaselineToolStripMenuItem
            // 
            this.subtractBaselineToolStripMenuItem.Name = "subtractBaselineToolStripMenuItem";
            this.subtractBaselineToolStripMenuItem.Size = new System.Drawing.Size(247, 32);
            this.subtractBaselineToolStripMenuItem.Text = "Subtract Baseline";
            this.subtractBaselineToolStripMenuItem.Click += new System.EventHandler(this.subtractBaselineToolStripMenuItem_Click);
            // 
            // detectPeaksToolStripMenuItem1
            // 
            this.detectPeaksToolStripMenuItem1.Name = "detectPeaksToolStripMenuItem1";
            this.detectPeaksToolStripMenuItem1.Size = new System.Drawing.Size(247, 32);
            this.detectPeaksToolStripMenuItem1.Text = "Detect Peaks";
            this.detectPeaksToolStripMenuItem1.Click += new System.EventHandler(this.detectPeaksToolStripMenuItem1_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pssessionFileToolStripMenuItem,
            this.xlsxFileToolStripMenuItem,
            this.txtFileToolStripMenuItem,
            this.exportAsImageToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(83, 32);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // plot1
            // 
            this.plot1.BackColor = System.Drawing.Color.White;
            this.plot1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plot1.Location = new System.Drawing.Point(0, 36);
            this.plot1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.plot1.MarkerSize = 5;
            this.plot1.MarkerType = OxyPlot.MarkerType.Circle;
            this.plot1.Name = "plot1";
            this.plot1.Size = new System.Drawing.Size(1110, 674);
            this.plot1.TabIndex = 1;
            this.plot1.Title = null;
            this.plot1.XAxisLabel = null;
            this.plot1.XAxisType = SDKPlot.AxisType.Linear;
            this.plot1.YAxisLabel = null;
            this.plot1.YAxisSecondaryLabel = null;
            this.plot1.YAxisSecondaryType = SDKPlot.AxisType.Linear;
            this.plot1.YAxisType = SDKPlot.AxisType.Linear;
            // 
            // pssessionFileToolStripMenuItem
            // 
            this.pssessionFileToolStripMenuItem.Name = "pssessionFileToolStripMenuItem";
            this.pssessionFileToolStripMenuItem.Size = new System.Drawing.Size(296, 32);
            this.pssessionFileToolStripMenuItem.Text = ".pssession File";
            this.pssessionFileToolStripMenuItem.Click += new System.EventHandler(this.pssessionFileToolStripMenuItem_Click);
            // 
            // xlsxFileToolStripMenuItem
            // 
            this.xlsxFileToolStripMenuItem.Name = "xlsxFileToolStripMenuItem";
            this.xlsxFileToolStripMenuItem.Size = new System.Drawing.Size(296, 32);
            this.xlsxFileToolStripMenuItem.Text = ".xlsx File";
            this.xlsxFileToolStripMenuItem.Click += new System.EventHandler(this.xlsxFileToolStripMenuItem_Click);
            // 
            // txtFileToolStripMenuItem
            // 
            this.txtFileToolStripMenuItem.Name = "txtFileToolStripMenuItem";
            this.txtFileToolStripMenuItem.Size = new System.Drawing.Size(237, 32);
            this.txtFileToolStripMenuItem.Text = ".txt File";
            // 
            // exportAsImageToolStripMenuItem
            // 
            this.exportAsImageToolStripMenuItem.Name = "exportAsImageToolStripMenuItem";
            this.exportAsImageToolStripMenuItem.Size = new System.Drawing.Size(296, 32);
            this.exportAsImageToolStripMenuItem.Text = "Export Graph as Image";
            // 
            // regressionAnalysisToolStripMenuItem
            // 
            this.regressionAnalysisToolStripMenuItem.Name = "regressionAnalysisToolStripMenuItem";
            this.regressionAnalysisToolStripMenuItem.Size = new System.Drawing.Size(195, 32);
            this.regressionAnalysisToolStripMenuItem.Text = "Regression Analysis";
            // 
            // FilteredPlot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 710);
            this.Controls.Add(this.plot1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FilteredPlot";
            this.Text = "FilteredPlot";
            this.Load += new System.EventHandler(this.FilteredPlot_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem plotToolStripMenuItem;
        private SDKPlot.WinForms.Plot plot1;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smoothCurveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem averageBaselineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subtractBaselineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detectPeaksToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pssessionFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xlsxFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem txtFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportAsImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regressionAnalysisToolStripMenuItem;
    }
}
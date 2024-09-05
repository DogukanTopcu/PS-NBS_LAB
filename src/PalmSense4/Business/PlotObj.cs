using OxyPlot.Series;
using PalmSens.Core.Simplified.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalmSense4.Business
{
    public class PlotObj
    {
        private int id;
        private int tabIndex;
        private TabPage tabPage;
        private string name;
        private string toolstripname;
        private bool isSmoothed;
        private bool isDetected;
        private bool isImported;
        private bool isImportedAsXlsx;
        private SimpleCurve curve;
        private List<List<double>> data;

        private ToolStripItem smoothItem;
        private ToolStripItem detectItem;
        private ToolStripItem filterItem;
        private ToolStripItem clearItem;

        private LineSeries ls;

        public PlotObj(int id,
            int tabIndex,
            TabPage tabPage,
            string name,
            string toolstripname,
            bool isImported,
            bool isImportedAsXlsx,
            SimpleCurve curve,
            List<List<double>> data,
            ToolStripItem smoothItem,
            ToolStripItem detectItem,
            ToolStripItem filterItem,
            ToolStripItem clearItem,
            LineSeries ls
        )
        {
            this.id = id;
            this.tabIndex = tabIndex;
            this.tabPage = tabPage;
            this.name = name;
            this.toolstripname = toolstripname;
            this.isSmoothed = false;
            this.isDetected = false;
            this.isImported = isImported;
            this.isImportedAsXlsx = isImportedAsXlsx;
            this.curve = curve;
            this.data = data;

            this.smoothItem = smoothItem;
            this.detectItem = detectItem;
            this.filterItem = filterItem;
            this.clearItem = clearItem;

            this.ls = ls;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Toolstripname { get => toolstripname; set => toolstripname = value; }
        public bool IsSmoothed { get => isSmoothed; set => isSmoothed = value; }
        public bool IsDetected { get => isDetected; set => isDetected = value; }
        public SimpleCurve Curve { get => curve; set => curve = value; }
        public List<List<double>> Data { get => data; set => data = value; }
        public int TabIndex { get => tabIndex; set => tabIndex = value; }
        public bool IsImported { get => isImported; set => isImported = value; }
        public bool IsImportedAsXlsx { get => isImportedAsXlsx; set => isImportedAsXlsx = value; }
        public TabPage TabPage { get => tabPage; set => tabPage = value; }
        public ToolStripItem SmoothItem { get => smoothItem; set => smoothItem = value; }
        public ToolStripItem DetectItem { get => detectItem; set => detectItem = value; }
        public ToolStripItem FilterItem { get => filterItem; set => filterItem = value; }
        public ToolStripItem ClearItem { get => clearItem; set => clearItem = value; }
        public LineSeries Ls { get => ls; set => ls = value; }
    }
}

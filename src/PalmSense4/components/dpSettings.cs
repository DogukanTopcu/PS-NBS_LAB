using RJCodeAdvance.RJControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalmSense4.components
{
    public partial class dpSettings : UserControl
    {
        public dpSettings()
        {
            InitializeComponent();
        }

        private void dpSettingsBtn_Click(object sender, EventArgs e)
        {
            dpSettingsBtn.Image.RotateFlip(RotateFlipType.Rotate180FlipX);

            if (Height == dpSettingsBtn.Height)
            {
                Height = 380;
            }
            else
            {
                Height = dpSettingsBtn.Height;
            }
        }
    }
}

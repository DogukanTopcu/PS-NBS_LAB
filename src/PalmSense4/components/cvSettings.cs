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
    public partial class cvSettings : UserControl
    {
        public cvSettings()
        {
            InitializeComponent();
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            rjButton1.Image.RotateFlip(RotateFlipType.Rotate180FlipX);

            if (Height == rjButton1.Height)
            {
                Height = 380;
            }
            else
            {
                Height = rjButton1.Height;
            }

        }
    }
}

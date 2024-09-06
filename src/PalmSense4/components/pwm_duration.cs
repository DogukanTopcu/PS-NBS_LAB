using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PalmSense4.components
{
    public partial class pwm_duration : UserControl
    {
        
        public static SerialPort serialPort;
        public pwm_duration()
        {
            InitializeComponent();

            cbPorts.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            foreach (var item in ports)
            {
                cbPorts.Items.Add(item);
            }

            rjButton1.Enabled = true;
            rjButton2.Enabled = true;

            serialPort = serialPort1;
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {

            serialPort1 = new SerialPort(serialPort1.PortName, 9600);
            serialPort1.DataBits = 8;
            serialPort1.Parity = Parity.None;
            serialPort1.StopBits = StopBits.One;

            serialPort1.Open();


            // High
            serialPort1.WriteLine("250~60000");
            rjButton1.Enabled = false;
            rjButton2.Enabled = false;
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            

            serialPort1 = new SerialPort(serialPort1.PortName, 9600);
            serialPort1.DataBits = 8;
            serialPort1.Parity = Parity.None;
            serialPort1.StopBits = StopBits.One;

            serialPort1.Open();

            // Low
            serialPort1.WriteLine("250~15000");
            rjButton1.Enabled = false;
            rjButton2.Enabled = false;
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            cbPorts.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            foreach (var item in ports)
            {
                cbPorts.Items.Add(item);
            }

            rjButton1.Enabled = true;
            rjButton2.Enabled = true;
        }

        private void cbPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.Close();

            serialPort1.PortName = cbPorts.SelectedItem.ToString();
        }
    }
}

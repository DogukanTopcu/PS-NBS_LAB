using PalmSense4.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalmSense4
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            InitializeData data = new InitializeData();
            List<Chemical_Combinations> _cc = data.InitializeChemicalCombinations();


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainPage());
            //Application.Run(new Form1(_cc));
            //Application.Run(new Main());
        }
    }
}

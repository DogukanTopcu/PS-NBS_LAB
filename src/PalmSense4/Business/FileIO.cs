using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace PalmSense4.Business
{
    public class FileIO
    {
        Microsoft.Office.Interop.Excel.Application excelApp;
        public FileIO()
        {
            excelApp = new Microsoft.Office.Interop.Excel.Application();
        }

        public bool SaveDataToExcel(string filePath, List<List<double>> measurementData)
        {
            try
            {
            Workbook wb = excelApp.Workbooks.Add();
            Worksheet ws = wb.ActiveSheet;

            ws.Cells[1, 1].Value = "ID";
            ws.Cells[1, 2].Value = "Potential (V)";
            ws.Cells[1, 3].Value = "Current";

            for (int i = 0; i < measurementData.Count; i++)
            {
                for (int j = 0; j < measurementData[i].Count; j++)
                {
                    ws.Cells[i + 2, j + 1].Value = measurementData[i][j];
                }
            }

            wb.SaveAs(filePath);

            wb.Save();
            wb.Close();
            excelApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

            }
            catch
            {
                return false;
            }
            return true;
        }

        public void LoadDataFromExcel(string filePath, DataView data, Form1 view)
        {
            // TODO: Excel dosyasındaki verileri dataview ile oluştur ve form1 arayüzünde plot ile birlikte göster
        }

        public void SaveImageOfPlot(string filePath, DataView data) 
        { 
            
        }
    }
}

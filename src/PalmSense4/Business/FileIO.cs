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
        
        public FileIO()
        {

        }

        //public bool SaveDataToExcel(string filePath, List<List<double>> measurementData)
        //{
        //    Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();

        //    try
        //    {
        //    Workbook wb = excelApp.Workbooks.Add();
        //    Worksheet ws = wb.ActiveSheet;

        //    ws.Cells[1, 1].Value = "ID";
        //    ws.Cells[1, 2].Value = "Potential (V)";
        //    ws.Cells[1, 3].Value = "Current";

        //    for (int i = 0; i < measurementData.Count; i++)
        //    {
        //        for (int j = 0; j < measurementData[i].Count; j++)
        //        {
        //            ws.Cells[i + 2, j + 1].Value = measurementData[i][j];
        //        }
        //    }

        //    wb.SaveAs(filePath);

        //    wb.Close();
        //    excelApp.Quit();
        //    System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.ToString());
        //        return false;
        //    }
        //    return true;
        //}

        public bool SaveDataToExcel(string filePath, Dictionary<string, List<List<double>>> measurementData)
        {
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();

            try
            {
                Workbook wb = excelApp.Workbooks.Add();

                List<List<double>> measurement = new List<List<double>>();


                foreach (var item in measurementData)
                {
                    Worksheet ws = wb.Worksheets.Add();
                    ws.Name = item.Key;
                    measurement = item.Value;

                    ws.Cells[1, 1].Value = "ID";
                    ws.Cells[1, 2].Value = "Potential (V)";
                    ws.Cells[1, 3].Value = "Current";

                    for (int i = 0; i < measurement.Count; i++)
                    {
                        for (int j = 0; j < measurement[i].Count; j++)
                        {
                            ws.Cells[i + 2, j + 1].Value = measurement[i][j];
                        }
                    }
                }

                wb.SaveAs(filePath);

                wb.Close();
                excelApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
            return true;
        }

        //public List<List<double>> LoadDataFromExcel(string filePath)
        //{
        //    try
        //    {
        //        Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();

        //        List<List<double>> data = new List<List<double>>();
        //        Workbook wb = excelApp.Workbooks.Open(filePath);
        //        Worksheet ws = wb.ActiveSheet;

        //        int i = 1;
        //        while (ws.Cells[i + 1, 1].Value != null)
        //        {
        //            data.Add(new List<double> { 
        //                ws.Cells[i + 1, 1].Value, 
        //                ws.Cells[i + 1, 2].Value, 
        //                ws.Cells[i + 1, 3].Value });
        //            i++;
        //        }

        //        wb.Close();
        //        excelApp.Quit();
        //        System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

        //        return data;

        //    }
        //    catch { return null; }
        //}

        public Dictionary<string, List<List<double>>> LoadDataFromExcel(string filePath)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();

                List<List<double>> data = new List<List<double>>();
                Dictionary<string, List<List<double>>> allData = new Dictionary<string, List<List<double>>>();

                Workbook wb = excelApp.Workbooks.Open(filePath);

                foreach (Worksheet sheet in wb.Worksheets)
                {
                    if (sheet.Cells[1, 1].Value != null)
                    {
                        int i = 1;
                        while (sheet.Cells[i + 1, 1].Value != null)
                        {
                            data.Add(new List<double> {
                                sheet.Cells[i + 1, 1].Value,
                                sheet.Cells[i + 1, 2].Value,
                                sheet.Cells[i + 1, 3].Value });
                            i++;
                        }
                        allData.Add(sheet.Name, new List<List<double>>(data));
                        data.Clear();
                    }
                }

                wb.Close();
                excelApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

                return allData;

            }
            catch { return null; }
        }

        public void SaveImageOfPlot(string filePath, DataView data) 
        { 
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Office.Interop.Excel;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            WebClient Client = new WebClient();
            Client.DownloadFile("https://download.samplelib.com/xls/sample-simple-1.xls", "sample-simple-1.xls");
            Application excelApp = new Application();

            if (excelApp == null)
            {
                Console.WriteLine("Excel is not installed!");
                return;
            }
            Workbook excelBook = excelApp.Workbooks.Open(@"C:\Users\23_ИП-291к\source\repos\ConsoleApp3\ConsoleApp3\bin\Debug\sample-simple-1.xls");
            _Worksheet excelSheet = excelBook.Sheets[1];
            Range excelRange = excelSheet.UsedRange;

            int rows = excelRange.Rows.Count;
            int cols = excelRange.Columns.Count;

            for (int i = 1; i <= rows; i++)
            {
                Console.Write("\r\n");
                for (int j = 1; j <= cols; j++)
                {
                    if (excelRange.Cells[i, j] != null && excelRange.Cells[i, j].Value2 != null)
                        Console.Write(excelRange.Cells[i, j].Value2.ToString() + "\t");
                }
            }

            excelApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            Console.ReadLine();

        }
    }
}

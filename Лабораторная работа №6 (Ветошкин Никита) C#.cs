using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ЛБ6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Application excelApp = new Application();

            if (excelApp == null)
            {
                Console.WriteLine("Excel is not installed!");
                return;
            }
            Workbook excelBook = excelApp.Workbooks.Open(@"C:\Users\23_ИП-291к\Desktop\readExample.xlsx");

            Thread potok1 = new Thread(vivod1);
            potok1.Name = "Поток 1";

            Thread potok2 = new Thread(vivod2);
            potok1.Name = "Поток 2";

            Console.WriteLine($"Имя потока: {potok1.Name}");
            Console.WriteLine($"Статус потока: {potok1.ThreadState}");

            Console.WriteLine($"Имя потока: {potok2.Name}");
            Console.WriteLine($"Статус потока: {potok2.ThreadState}");

            potok1.Start();
            potok2.Start();

            Thread.Sleep(100);
            Console.WriteLine($"Имя потока: {potok1.Name}");
            Console.WriteLine($"Статус потока: {potok1.ThreadState}");

            Console.WriteLine($"Имя потока: {potok2.Name}");
            Console.WriteLine($"Статус потока: {potok2.ThreadState}\n");

            void vivod1()
            {
                _Worksheet excelSheet1 = excelBook.Sheets[1];
                Range excelRange1 = excelSheet1.UsedRange;

                int rows1 = excelRange1.Rows.Count;
                int cols1 = excelRange1.Columns.Count;

                for (int i = 1; i <= rows1; i++)
                {
                    Console.Write("\r\n");
                    for (int j = 1; j <= cols1; j++)
                    {
                        if (excelRange1.Cells[i, j] != null && excelRange1.Cells[i, j].Value2 != null)
                            Console.Write(excelRange1.Cells[i, j].Value2.ToString() + "\t");
                    }
                }
            }
            void vivod2()
            {
                Thread.Sleep(5000);
                _Worksheet excelSheet2 = excelBook.Sheets[2];
                Range excelRange2 = excelSheet2.UsedRange;

                int rows2 = excelRange2.Rows.Count;
                int cols2 = excelRange2.Columns.Count;

                for (int i = 1; i <= rows2; i++)
                {
                    Console.Write("\r\n");
                    for (int j = 1; j <= cols2; j++)
                    {
                        if (excelRange2.Cells[i, j] != null && excelRange2.Cells[i, j].Value2 != null)
                            Console.Write(excelRange2.Cells[i, j].Value2.ToString() + "\t");
                    }
                }
            }
            Console.ReadLine();
            Console.WriteLine($"Имя потока: {potok1.Name}");
            Console.WriteLine($"Статус потока: {potok1.ThreadState}");

            Console.WriteLine($"Имя потока: {potok2.Name}");
            Console.WriteLine($"Статус потока: {potok2.ThreadState}\n");

            excelApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
        }
    }
}

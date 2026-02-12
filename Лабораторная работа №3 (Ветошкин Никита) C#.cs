using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace Пример_приложения_чтение_данных_из_xcel_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Application excelApp = new Application();

            if(excelApp == null)
            {
                Console.WriteLine("Excel is not installed!");
                return;
            }
            Workbook excelBook = excelApp.Workbooks.Open(@"C:\Users\23_ИП-291к\Desktop\readExample.xlsx");
            bool not_error = false;
            int list_nomber = 1;
            while (!not_error) 
            { 
                Console.Write("Выберите страницу: ");
                list_nomber = int.Parse(Console.ReadLine());
                if (list_nomber == 0) 
                {
                    Console.WriteLine("Нулевого листа не существует");
                }
                else
                {
                    not_error = true;
                }
            }   
            _Worksheet excelSheet = excelBook.Sheets[list_nomber];
            Range excelRange = excelSheet.UsedRange;

            int rows = excelRange.Rows.Count;
            int cols = excelRange.Columns.Count;

            for (int i = 1; i <= rows; i++) 
            {
                Console.Write("\r\n");
                for(int j = 1;  j <= cols; j++)
                {
                    if(excelRange.Cells[i, j] != null && excelRange.Cells[i, j].Value2 != null)
                        Console.Write(excelRange.Cells[i, j].Value2.ToString() + "\t");
                }
            }

            excelApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            Console.ReadLine();
        }
    }
}

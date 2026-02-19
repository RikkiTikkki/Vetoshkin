using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace LB4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вывод всех процессов:");
            foreach (Process process in Process.GetProcesses())
            {
                Console.WriteLine($"Id: {process.Id} Name: {process.ProcessName}");
            }


            Console.WriteLine("\n=================================================================");
            Console.WriteLine("Вывод всех потоков процесса Visual Studio:");
            Process proc = Process.GetProcessesByName("devenv")[0];
            ProcessThreadCollection processThread = proc.Threads;
            foreach (ProcessThread thread in processThread)
            {
                Console.WriteLine($"ThreadId: {thread.Id}");
            }


            Console.WriteLine("\n=================================================================");
            Console.WriteLine("Запус нескольких сторонних процессов:");
            Process.Start(@"C:\Program Files\Google\Chrome\Application\chrome");
            Process.Start(@"C:\Program Files\Microsoft Office\Office16\EXCEL");
            Process.Start("mspaint.exe");
            Console.WriteLine("Chrome\nExcel\nPaint");
        }
    }
}

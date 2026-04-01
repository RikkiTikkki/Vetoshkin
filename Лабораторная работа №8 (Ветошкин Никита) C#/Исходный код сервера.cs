using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛБ8
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] a = new byte[10];
            using (var s = new NamedPipeServerStream("Pipe_lab8"))
            {
                Random rnd = new Random();
                Console.WriteLine("Массив создан: ");
                for (int i = 0; i < 10; i++)
                {
                    a[i] = (byte)(rnd.Next() % 101);
                    Console.Write(a[i] + "\t");
                }
                Console.WriteLine();
                s.WaitForConnection();
                for (int i = 0; i < 10; i++)
                    s.WriteByte(a[i]);
                for (int i = 0; i < 10; i++)
                    a[i] = (byte)(s.ReadByte());
                Console.WriteLine("Массив после сортировки: ");
                for (int i = 0; i < 10; i++)
                    Console.Write(a[i] + "\t");
                Console.WriteLine();
            }
            Console.WriteLine("Сеанс сервера закончен");
            Console.ReadLine();
        }
    }
}

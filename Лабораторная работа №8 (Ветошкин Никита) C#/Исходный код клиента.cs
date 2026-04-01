using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛБ8_2
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] a = new byte[10];
            using (var s = new NamedPipeClientStream("Pipe_lab8"))
            {
                Console.WriteLine("Начинает работать клиент");
                byte b;
                s.Connect();
                for (int i = 0; i < 10; i++)
                    a[i] = (byte)(s.ReadByte());
                Console.WriteLine("Полученный массив байтов:");
                for (int i = 0; i < 10; i++)
                    Console.Write(a[i] + "\t");
                Console.WriteLine();
                for (int i = 0; i < 9; i++)
                    for (int j = i + 1; j < 10; j++)
                        if (a[i] < a[j])
                        { b = a[i]; a[i] = a[j]; a[j] = b; }
                Console.WriteLine("Массив после сортировки:");
                for (int i = 0; i < 10; i++)
                    Console.Write(a[i] + "\t");
                Console.WriteLine();
                for (int i = 0; i < 10; i++)
                    s.WriteByte(a[i]);
            }
            Console.WriteLine("Сеанс клиента закончен");
            Console.ReadLine();
        }
    }
}

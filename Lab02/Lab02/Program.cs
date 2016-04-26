using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Lab02
{
    class Program
    {
        static void Main(string[] args)
        {
            // Used in Lab1 example
            Thread t1 = new Thread(new ThreadStart(Print));
            t1.Start();

            // New thread with arguments
            Thread t2 = new Thread(new ParameterizedThreadStart(PrintArg));
            t2.Start(200);

            // Using lambda expression
            Thread t3 = new Thread(() => Print3(123.456));
            t3.Start();

        }

        static void Print()
        {
            Console.WriteLine("Print Screen");
        }

        static void PrintArg(object obj)
        {
            int a = (int)obj;
            int total = a * 100;
            Console.WriteLine("Print Screen 2. total=" + total);
        }

        private static void Print3(object obj)
        {
            double b = (double)obj;
            double total2 = b * 3.1415926;
            Console.WriteLine(total2);
        }
    }
}

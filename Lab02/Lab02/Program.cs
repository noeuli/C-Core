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
            //// Used in Lab1 example
            //Thread t1 = new Thread(new ThreadStart(Print));
            //t1.Start();

            //// New thread with arguments
            //Thread t2 = new Thread(new ParameterizedThreadStart(PrintArg));
            //t2.Start(200);

            //// Using lambda expression
            Thread t3 = new Thread(() => Print3(123.456));
            t3.Start();

            // Background Thread
            // Foreground vs Background
            // Default: Foreground
            //  Main thread가 종료되면
            // Foreground는 main thread 죽어도 foreground thread는 살아있음
            // Background는 main thread가 죽으면 같이 죽는다.
            Thread t4 = new Thread(new ParameterizedThreadStart(Print4));
            t4.IsBackground = true;
            t4.Start(200.1);

            Thread.Sleep(1);
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
            Console.WriteLine("Print screen 3: " + total2);
        }

        private static void Print4(object obj)
        {
            double b = (double)obj;
            double total4 = b * 3.1415926;
            Console.WriteLine("Print screen 4: " + total4);
        }
    }
}

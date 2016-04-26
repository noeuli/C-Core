using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab11
{
    class Program
    {
        const int LOOP_MAX = 100;
        static void Main(string[] args)
        {
            // General loop
            for (int i=0; i< LOOP_MAX; i++)
            {
                Console.WriteLine("{0}: {1}", 
                    Thread.CurrentThread.ManagedThreadId, i);
            }

            Console.Read();

            //// Parallel loop
            //Parallel.For(0, LOOP_MAX,
            //    (i) => { Console.WriteLine("{0}: {1}", 
            //        Thread.CurrentThread.ManagedThreadId, i); }
            //);

            // Invoke를 사용하는 방법
            Program app = new Program();
            Parallel.Invoke(() => { app.PrintThread(1); },
                () => { app.PrintThread(2); },
                () => { app.PrintThread(3); },
                () => { app.PrintThread(4); },
                () => { app.PrintThread(5); },
                () => { app.PrintThread(6); }
            );
        }

        void PrintThread(int i)
        {
            for (int idx = 0; idx < LOOP_MAX; idx++)
            {
                Console.WriteLine("{0}: {1}: {2}",
                        Thread.CurrentThread.ManagedThreadId, idx, i);
            }
        }
    }
}

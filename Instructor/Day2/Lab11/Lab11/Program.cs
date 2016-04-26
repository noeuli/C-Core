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
        static void Main(string[] args)
        {
            // 일반적인 반복처리
            for (int i = 0; i <= 10000; i++)
            {
                Console.WriteLine(
                    "{0}: {1}",
                    Thread.CurrentThread.ManagedThreadId, i
                    );
            }

            Console.Read();
            // 병렬 처리..
            Parallel.For(0, 10001, (i) => {
                    Console.WriteLine(
                        "{0}: {1}",
                        Thread.CurrentThread.ManagedThreadId, i
                        );
                }
                );

            // 
            //Parallel.Invoke(
            //        () => { 메서드1; }
            //        ...... 56
            //    );

        }
    }
}

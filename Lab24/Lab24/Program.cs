using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab24
{

    class Program
    {
        private object mLock = new object();

        int counter = 100000;

        static void Main(string[] args)
        {
            new Program().testLock();
        }

        private void testLock()
        {
            for (int i = 0; i < 5; i++)
            {
                new Thread(Total).Start();
            }
        }
        private void Total()
        {

            int loopCount = 1;

            // Monitor와 Lock의 차이점은, Monitor는 중간에 잠시 멈출 수 있다. (Wait)
            Monitor.Enter(mLock);
            try
            {
                counter -= 5000;
                loopCount = counter;

                for (int i = 0; i < loopCount; i++)
                {
                    for (int j = 0; j < loopCount; j++)
                    {
                        ;
                    }
                }

                Console.WriteLine("Done. counter=" + loopCount + " ThreadID = " + Thread.CurrentThread.ManagedThreadId);
            }
            finally
            {
                Monitor.Exit(mLock);
            }
        }
    }
}

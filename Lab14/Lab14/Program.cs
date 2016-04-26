using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab14
{
    class Program
    {
        private const int LOOP_MAX = 10000;

        static void Main(string[] args)
        {
            // Thread를 사용. old style
            ThreadStart ts = new ThreadStart(PrintScreen);
            Thread th = new Thread(ts);

            // Thread start
            th.Start();

            // Thread priority change
            //th.Priority = ThreadPriority.Highest;
            //th.Suspend();   // 4.6에서는 안된단다. async task를 쓰라는거란다.

            //th.Abort();     // Force kill thread.   // abort를 하면, 실제로는 thread를 언제 죽일지 모른단다.
            // 만약 thread가 일이 많으면, 해당 thread가 늦게 죽을 수도 있단다. 케바케.

            th.Join();  // thread working을 완료하고 나서 종료시킨단다.
            // fg, bg 모두 사용 가능
        }

        static void PrintScreen()
        {
            for (int i=0; i< LOOP_MAX; i++)
            {
                Console.WriteLine("Count = {0}", i);
            }
        }
    }
}

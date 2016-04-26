using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Lab03
{
    class Program
    {
        static void Main(string[] args)
        {
            // Thread pool
            // pool 안에 있는 녀석을 .. 넣음
            // 넣는 메서드는 PrintScreen
            ThreadPool.SetMinThreads(10, 10);   // thread pool을 몇개를 쓸지 정하고 쓰는걸 권장. // 이렇게 안하면 0~249를 다 쓴다. // Thread throttling을 피할 수 있게.
            ThreadPool.QueueUserWorkItem(PrintScreen);
        }

        // Thread pool
        // .net 2.0 service pack 1 250개 thread 생성 CPU 개당 0~249
        // 100번째 thread를 사용하다가, 100번째 thread를 다 사용하고 빈 공간을 두면, 그 공간을 재사용 가능
        static void PrintScreen(object obj)
        {
            Console.WriteLine("Print Screen for Thread pool");
        }
    }
}

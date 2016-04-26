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
            // 스레드 풀....
            // 풀 안에 있는 녀석을.. 넣음.
            // 넣는 메서드는 PrintScreen
            //ThreadPool.SetMinThreads(10,10); // Thread Throtting 지연을 피할수있게
            ThreadPool.QueueUserWorkItem(PrintScreen);

        }

        // 스레드 풀...
        // .NET 2.0 SP1 250개 스레드 생성 CPU 개당 0~249
        // 100번째 스레드를 사용하다.. 100번째를 다 사용하고
        // 빈 공간을 두면 재사용 가능
        static void PrintScreen(object obj)
        {
            Console.WriteLine("화면출력");
        }
    }
}

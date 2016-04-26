using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab09
{
    class Program
    {
        static void Main(string[] args)
        {
            // Above C# 4.0
            // ThreadPool의 thread를 가져와서 async로 작업을 실행하는 것

            // Task
            // Thread를 생성하고 시작
            Task.Factory.StartNew(new Action<object>(PrintScreen), null);
        }

        static void PrintScreen(object obj)
        {
            Console.WriteLine(obj == null ? "Print Screen" : obj);
        }
    }
}

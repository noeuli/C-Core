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
            // C# 4.0 이상.. 
            // 스레드 풀..의 스레드를 가져와서
            // 비동기 작업을 실행하는 것..

            // Task
            // 스레드를 생성하고 시작
            Task.Factory.StartNew
                (new Action<object>(PrientScreen),null);

        }

        static void PrientScreen(object obj)
        {
            Console.WriteLine
                (obj == null ? "화면출력" : obj);
        }
    }
}

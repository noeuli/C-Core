using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            // 정의를 하고(인스턴스 선언만..)
            // 시작은 하지 않고...
            Task t1 =
                new Task(new Action(PrintScreen));

            // 생성만 함....
            Task t2 = new Task
                (
                    () =>
                    {
                        Console.WriteLine("람다로 Task");
                    }
                );
            // 스레드 시작
            t1.Start();
            t2.Start();

            //Thread.Sleep()

            // Task 작업이 완료 될때까지 대기
            t1.Wait();
            t2.Wait();
        }

        static void PrintScreen()
        {
            Console.WriteLine("첫 태스크 출력");
        }
    }
}

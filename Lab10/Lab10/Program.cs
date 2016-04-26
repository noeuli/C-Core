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
            // 정의를 하고 instance 생성만 함. 시작은 하지 않음.
            Task t1 = new Task(new Action(PrintScreen));
            // 생성만 함. 단지 lambda expression을 사용함.
            Task t2 = new Task(() => { Console.WriteLine("Lambda Task"); });

            t1.Start();
            Console.WriteLine("1");
            // Thread.sleep()을 여기에 쓰면, t1 task 안에 있는 thread가 sleep이 된단다.
            Thread.Sleep(5000);
            Console.WriteLine("2");
            t2.Start();
            Console.WriteLine("3");
            // Thread.sleep()을 여기에 쓰면, t2 task 안에 있는 thread가 sleep이 된단다.
            Thread.Sleep(5000);
            Console.WriteLine("4");

            // Task가 완료될 때 까지 기다림
            // ==> 이게 없으면 화면에 출력되지 않는다.
            t1.Wait();
            t2.Wait();

            // Task는 무조건 Foreground thread로 동작한다.
            // Task는 return 값을 돌려받지 못한다.
        }

        static void PrintScreen()
        {
            Console.WriteLine("Print Screen");
        }
    }
}

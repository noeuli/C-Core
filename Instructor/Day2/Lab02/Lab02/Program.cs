using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Lab02
{
    class Program
    {
        static void Main(string[] args)
        {
            // 랩 1에서 연습
            Thread t1 = new 
                Thread
                    (new ThreadStart(Print));
            t1.Start();

            //매개변수 (파라미터) 전달 스레드
            Thread t2 = new Thread
                (new ParameterizedThreadStart(Print2));
            t2.Start(200);

            Thread t3 = new Thread
                (
                    () => Print3(192.23)
                );
            t3.Start();

            // Background Thread
            // Foreground VS Background
            // 기본 Foreground 
            // 메인 스레드 -> 종료(죽음)
            // Foreground Thread 살아있으면... 메인 스레드 종료(죽어도) 
            // 살아 있음..
            // Background Thread 메인 스레드 죽으면
            // 같이 죽어요...
            Thread t4 = new Thread
                (new ParameterizedThreadStart(Print4));
            t4.IsBackground = true;
            t4.Start(200);
        }

        private static void Print4(object obj)
        {
            int a = (int)obj;
            int total = a * 100;
            Console.WriteLine(total);
        }

        private static void Print3(object obj)
        {
            double b = (double)obj;
            double total2 = b * 1254.2512;
            Console.WriteLine(total2);
        }

        private static void Print2(object obj)
        {
            int a = (int)obj;
            int total = a * 100;
            Console.WriteLine(total);
        }

        static void Print()
        {
            Console.WriteLine("화면출력");
        }
    }
}

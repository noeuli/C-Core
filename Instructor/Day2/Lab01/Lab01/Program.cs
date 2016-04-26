using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Lab01
{
    class Program
    {
        static void Main(string[] args)
        {
            //PrintScreen();
            new Program().TStart();

        }

        // 스레드 정의
        void TStart()
        {
            // 새로운 스레드 새성
            // 화면 출력에 대한 메서드를 입력
            // 대리자를 통해서 개체를 생성
            // Thread 클래스 전달..
            //Thread t1 = new
            //    Thread
            //        (new ThreadStart(PrintScreen)); // 호출하는 메서드

            // 컴파일러... 화면출력 메서드의 함수
            // 프로퍼티타입.. ThreadStart Delegate 개체를
            // 추상화?? 추론... 생성..
            Thread t1 = new Thread (PrintScreen);


            t1.Start();

            // 람다식을 이용한 간략한 방법
            new Thread(() => PrintScreen()).Start();

            // 메인 스레드 실행..
            //PrintScreen();
        }

        // 스레드가 호출 화면 출력
        void PrintScreen()
        {
            Console.WriteLine("화면출력1");

            Thread.Sleep(3000);

            Console.WriteLine("화면출력2");


        }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;   // need 4.0


namespace Lab01
{
    class Program
    {
        static void Main(string[] args)
        {
            //PrintScreen();

            new Program().TStart();
        }

        // thread 정의
        void TStart()
        {
            // 새로운 thread 생성
            // 화면 출력에 대한 메서드를 입력 받아서, 
            // 대리자를 통해서 개체를 생성.
            // 객체 = 개체 란다.
            // Thread 클래스 전달
            //Thread t1 = new Thread(new ThreadStart(PrintScreen)); // create1

            // 컴파일러가 결정.. 화면 출력 메서드의 함수 property type
            // ThreadStart delegate 개체를 생성한다. 내부적으로. 컴파일러가.
            Thread t1 = new Thread(PrintScreen);    // create2

            // 결국, create1과 create2는 단순한 표현의 차이. 실제 동작은 동일하다.

            // 비슷한 동작을 lambda expression으로 표현하면
            // 람다식을 이용한 간략한 방법
            new Thread(() => PrintScreen()).Start();


            t1.Start();

            // main thread 실행
            PrintScreen();
        }

        // Thread 호출 화면 출력
        void PrintScreen()
        {
            Console.WriteLine("Print Screen 1");

            Thread.Sleep(3000);

            Console.WriteLine("Print Screen 2");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab25
{
    class Program
    {
        static void Main(string[] args)
        {
            // 스레드 생성하고 실행..
            Thread t1 = new Thread(() => MutexClassTest.AddList(10));
            Thread t2 = new Thread(() => MutexClassTest.AddList(20));
            //MutexClassTest m = new MutexClassTest();  // static 사용하지 않을 경우
            //Thread t1 = new Thread(() => m.AddList(10));
            //Thread t2 = new Thread(() => m.AddList(20));
            t1.Start();
            t2.Start();

            // 스레드가 실행완료 할때까지 대기
            t1.Join();
            t2.Join();

            // 주 스레드에서 뮤텍스 사용함..
            using (Mutex m = new Mutex(false, "mName1"))
            {
            }

            // 화면 출력
            MutexClassTest.PrintScreen();
        }
    }

    class MutexClassTest
    {
        // 뮤텍스 생성
        private static Mutex mtx = new Mutex(false, "mName1");
        //데이터 목록.. 
        public static List<int> l = new List<int>();

        //데이터를 추가...목록에..
        public static void AddList(int i)
        {
            // 뮤텍스 올때까지?? 취득할때가지.. 대기
            mtx.WaitOne();
            l.Add(i); //  뮤텍스가 어떤 프로세스.. 정하고,, 난 다음 추가
            // 뮤텍스 해제.. 어느 프로세스 사용했는지. 그거 해제
            mtx.ReleaseMutex();
        }

        // 목록 출력..
        public static void PrintScreen()
        {
            l.ForEach(p => Console.WriteLine(p));
        }
    }
}

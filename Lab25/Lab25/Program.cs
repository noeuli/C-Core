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
            // 2개의 Thread를 실행
            Thread t1 = new Thread(() => MutexTestClass.AddList(100));
            t1.Name = "Thread1";
            Thread t2 = new Thread(() => MutexTestClass.AddList(200));
            t2.Name = "Thread2";

            t1.Start();
            t2.Start();

            // 2개의 Thread 실행 완료까지 대기
            t1.Join();
            t2.Join();

            // Main Thread에서 Mutex를 사용
            using (Mutex m = new Mutex(false, "MyFirstMutex"))
            {
                MutexTestClass.MyList.Add(300);

                //// Mutex를 취득하기 위해 10ms 대기
                //if (m.WaitOne(10))
                //{
                //    // Mutex 취득 후 MyList를 사용
                //    MutexTestClass.MyList.Add(300);
                //}
                //else
                //{
                //    Console.WriteLine("Can not acquire mutex");
                //}
            }

            MutexTestClass.PrintScreen();
        }

        class MutexTestClass
        {
            // Create Mutex
            private static Mutex mMutex = new Mutex(false, "MyFirstMutex");

            // Data Member
            public static List<int> MyList = new List<int>();

            // value를 MyList에 넣기 위해.
            public static void AddList(int value)
            {
                // Mutex를 얻을 때 까지 대기
                mMutex.WaitOne();

                // Mutex를 얻어 왔다면 작업 내용을 수행
                MyList.Add(value);

                // Mutex 해제
                mMutex.ReleaseMutex();
            }

            // MyList 내용을 출력
            public static void PrintScreen()
            {
                MyList.ForEach(item => Console.WriteLine(item + " "));
            }
        }
    }
}

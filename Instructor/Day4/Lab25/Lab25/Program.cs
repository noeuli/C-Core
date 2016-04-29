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
                // 뮤텍스를 취득하기 위한.. 대기 시간
                if (m.WaitOne(100))
                {
                    // 뮤텍스 취득하고.. 사용
                    MutexClassTest.l.Add(30);
                }
                else
                {
                    Console.WriteLine("뮤텍스 취득 없음..");
                }
            }

            // 화면 출력
            MutexClassTest.PrintScreen();

            // 프로세스간 뮤텍스. 사용
            // 고유한 GUID 값을 생성함..
            string mGUID = "7E6894CD-49CF-4DA2-A658-C34DAFBF2257";

            // 뮤텍스 이름으로 개체 생성
            // 뮤텍스 값을 확인해서 맞으면 true
            bool checkMutex;
            Mutex gmtx = new Mutex(true, mGUID, out checkMutex);

            // 뮤텍스 가져왔는지...
            if (!checkMutex)
            {
                Console.WriteLine("못가져옴.. 실행중...이라..");
                return;
            }

            // 가져왔으면.. 일을 시키면 됨.
            MutexClassTest.l.Add(40);

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

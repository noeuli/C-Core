using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab26
{
    class Program
    {
        // Semaphore : 10개나 20개 라면, 자원은 동시에 사용 가능
        // 단, 10개라면 11번째 자원이 thread를 사용하려하면, 일단 그걸 막음
        // 그리고 10개 중에 1개라도 끝나면, 즉 빈자리가 생기면
        // 그 때 11번째 실행 요청 자원은 그 빈자리 1개를 사용하여 실행 됨

        static void Main(string[] args)
        {
            SemaphoreClass s = new SemaphoreClass();

            // 20개 Thread를 실행
            // 처음 10개는 동시에 실행될 테고, 나머지는 1개씩 순차적으로 실행되겠지
            for (int i=0; i<20; i++)
            {
                new Thread(s.SemaphoreProcess).Start(i);
            }
        }

        class SemaphoreClass
        {
            private Semaphore mSema;

            // Constructor
            public SemaphoreClass()
            {
                // Max 10개의 Thread를 허용 
                mSema = new Semaphore(10, 10);
            }

            public void SemaphoreProcess(object obj)
            {
                // Thread가 가진 일련 번호를 obj로 받을거다
                Console.WriteLine(Now() + "Enter: " + obj);

                // 최대 10개의 Thread만 아래 문장을 실행한다.
                mSema.WaitOne();

                Console.WriteLine(Now() + "Running# " + obj);
                Thread.Sleep(500);

                // Semaphore 1개 해제
                //해제하면 빈 공간을 다음 Thread가 사용 가능함
                mSema.Release();
            }

            private string Now()
            {
                return DateTime.Now.ToString("[hh:mm:ss.fff] ");
            }
        }
    }
}

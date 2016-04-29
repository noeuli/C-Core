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
        // 쉐마포어 : 10개 20개 라면.. 자원은 동시 사용가능
        // 단.. 10개 하면.. 11번째 자원이 스레드 사용하면 일단 막음.
        // 10개 중에 1개라 끝나면 즉. 빈자리 생기면 그 때 11번째는
        // 10개 중에 1개로.. 됨.

        static void Main(string[] args)
        {
            ShemaPhoreClass s = new ShemaPhoreClass();

            // 스레드를 15개 정도.. 실행
            // 초기에 10개... 나머지는 해제가 되면.. 그때 됨
            for (int i = 1; i <= 15; i++)
            {
                new Thread(s.SHProcess).Start();
            }
        }
    }

    class ShemaPhoreClass
    {
        private Semaphore sh;

        public ShemaPhoreClass()
        {
            // 10개의 스레드만 허용
            sh = new Semaphore(10, 10);
        }

        public void SHProcess(object obj)
        {
            // 스레드가 가진 번호... (일련번호)
            Console.WriteLine(obj);

            // 10개의 스레드허용 최대 스레드만 실행하게..
            sh.WaitOne();

            Console.WriteLine("SH 실행 : " + obj);
            Thread.Sleep(1000);

            // 쉐마포어 해제.. 1개씩 해제..
            // 이후 스레드는 WaitOne() 에서 사용가능..
            sh.Release();
        }
    }
}

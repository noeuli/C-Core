using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab23
{
    class Program
    {
        static void Main(string[] args)
        {
            LockClassTest l = new LockClassTest();
            l.testLock();
        }        
    }

    class LockClassTest
    {
        // Lock(스레드 동기화)할 개체 명..
        object lobj = new object();
        int counter = 10000;
        public void testLock()
        {
            // 스레드를 5개 실행..
            for (int i = 0; i < 5; i++)
            {
                new Thread(Total).Start();
            }

        }
        private void Total()
        {
            // lock 을 사용함.
            // 한번에 하나의 스레드만 해라..
            lock (lobj)
            {
                // 필드 값 변경..
                counter++;

                for (int i = 0; i < counter; i++)
                {
                    for (int j = 0; j < counter; j++)
                    {
                    }
                }

                Console.WriteLine("메서드 출력");
            }
        }
    }
}

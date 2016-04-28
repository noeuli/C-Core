using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab24
{
    class Program
    {
        static void Main(string[] args)
        {
            MonitorClassTest m = new MonitorClassTest();
            m.testLock();
        }
    }

    class MonitorClassTest
    {
        // Monitor(스레드 동기화)할 개체 명..
        object mobj = new object();
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
            //Monitor
            // 한번에 하나의 스레드만 해라..
            Monitor.Enter(mobj);
            try
            {
                // 필드 값 변경..
                counter++;

                for (int i = 0; i < counter; i++)
                {
                    for (int j = 0; j < counter; j++)
                    {
                    }
                }

                Console.WriteLine(counter);
            }
            finally
            {
                Monitor.Exit(mobj);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab14
{
    class Program
    {
        static void Main(string[] args)
        {
            // 스레드를 사용.. 옛날..
            ThreadStart t = new ThreadStart(PrintScreen);
            Thread tx = new Thread(t);

            tx.Start(); // 시작..

            //tx.Abort(); // 강제 종료... 언제 스레드를 죽일지ㅣ..
            tx.Join();  // 안정적으로 운영...

        }

        static void PrintScreen()
        {
            for (int i = 0; i < 10000; i++)
            {
                Console.WriteLine("Count = {0}", i);
            }
        }
    }
}

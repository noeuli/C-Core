using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab12
{
    class Program
    {
        static void Main(string[] args)
        {
            RunC50();
        }

        private static async void RunC50()
        {
            // 시간이 많이 걸리는 것..
            // 메서드를 비동기로 호출
            Task<double> t = Task<double>.Factory.StartNew(
                    () => PrintScreen(10.0)
                );

            // Task 끝나기를 기다려야.. UI 화면에 표시...
            // UI 스레드 블록되지 않도록 하는.. 기능..
            await t;
            
            // 해당 컨트롤에 데이터를 넣기..
            // Invoke
            // TextBox = t.result.ToString();

        }

        private static double PrintScreen(double v)
        {
            Thread.Sleep(3000);

            return v * 1999;
        }
    }
}

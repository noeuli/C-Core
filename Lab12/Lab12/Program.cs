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
            RunCS50();
        }

        private static async void RunCS50()
        {
            // 시간이 많이 걸리는 것...
            // method를 비동기로 호출
            Task<double> t = Task<double>.Factory.StartNew(
                    () => PrintScreen(10.0)
                );

            // Task가 끝나기를기다려야.. UI 화면에 표시
            // UI thread block 되지 않도록 하는 기능
            await t;

            // 해당 control에 data를 넣기
            // Invoke
            // TextBox = t.result.ToString();

            // universal web이나 modern ui 일 때는 async/await을 사용하지 않으면 UI가 반영되지 않는다고 한다.

        }

        private static double PrintScreen(double v)
        {
            Thread.Sleep(3000);

            return v * 1999;
        }
    }
}

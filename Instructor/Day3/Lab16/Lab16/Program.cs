// 심볼.. 기호..
#define Test_Process


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab16
{
    class Program
    {
        #region 메인 메서드 처리
        static void Main(string[] args)
        {
            int a = 100;
            int b = 200;

            int total = a + b;
            int total2 = total * 100;
#if (Test_Process)
            Console.WriteLine(total);
#else
            Console.WirteLine("Dubug_Process :" total);      
#endif
        }
#endregion

    }
}

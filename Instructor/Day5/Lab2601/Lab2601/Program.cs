using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataProCLS;

namespace Lab2601
{
    class Program 
    {

        // 중매 쟁이를 통해서 가져옴..
        static void Main(string[] args)
        {
            //uInfo u = new uInfo();
            //// 속성..
            //Console.WriteLine(u.UserName);
            //// 필드..
            //Console.WriteLine(u.userName);
            IuInfo iu = new uInfo();
            Console.WriteLine(iu.UserName);
            Console.WriteLine(iu.ProcessName(10).ToString());


        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab28
{
    class Program
    {
        string mStrA = "aaa";
        String mStrB = "bbb";
        

        static void Main(string[] args)
        {
            Print();
        }

        unsafe static void Print()
        {
            int a = 100;
            Int64 b = 200;
            IntPtr ptr = new IntPtr(&b);
            string strC = "ccc";
            String strD = "ddd";
            Program p = new Program();

            Console.WriteLine("0x" + ptr.ToString("x8"));
        }
    }
}

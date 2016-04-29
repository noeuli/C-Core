using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab28
{
    class Program
    {
        static void Main(string[] args)
        {
            Print();
        }

        unsafe static void Print()
        {
            int a = 125135613;
            Int64 a64 = 125135235613;

            IntPtr ip = new IntPtr(&a64);
            Console.WriteLine(ip.ToString());
            Console.WriteLine(ip.ToString("x"));

            IntPtr ip2 = new IntPtr(&a);
            Console.WriteLine(ip2.ToString());
            Console.WriteLine(ip2.ToString("x"));

        }
    }
}

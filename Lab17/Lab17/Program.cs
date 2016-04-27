using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab17
{
    class Program
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool Beep(uint dwFreq, uint dwDuration);

        static void Main(string[] args)
        {
            Exchange();

            // audio frequency band is between 20Hz and 20kHz
            for (uint i = 20; i <= 20000; i++)
            {
                Beep(i, 5);
            }
        }

        static void Exchange()
        {
            int a = 123;
            int b = 789;

            Console.WriteLine("[1] a={0} b={1}", a, b);
            a ^= b;
            Console.WriteLine("[2] a={0} b={1}", a, b);
            b ^= a;
            Console.WriteLine("[3] a={0} b={1}", a, b);
            a ^= b;
            Console.WriteLine("[4] a={0} b={1}", a, b);

        }
    }
}

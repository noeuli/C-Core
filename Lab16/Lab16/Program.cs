﻿#define DEFINE_VARIABLE


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab16
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 100;
            int b = 200;
            int total = a * b;
            int total2 = total * 100;

            Console.WriteLine("total={0} total2={1}", total, total2);


        }
    }
}

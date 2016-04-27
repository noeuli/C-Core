using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab18
{
    class Program
    {
        static void Main(string[] args)
        {
            MyNameCLS m = new MyNameCLS();
            defaultNameProcess(m);
            Console.WriteLine(m.MyName);
        }

        private static void defaultNameProcess(object m)
        {
            // MyNameCLS 에서 MyName 속성이 있는지??
            PropertyInfo pInfo =
                m.GetType().GetProperty("MyName");

            // 속성이 있으면.. 설정
            if (pInfo != null)
                pInfo.SetValue(m, "홍길동", null);
        }
    }

    class MyNameCLS
    {
        public string MyName { get; set; }        
    }
}

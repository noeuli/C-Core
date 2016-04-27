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
            MyNameClass m = new MyNameClass();
            defaultNameProcess(m);
            Console.WriteLine("Get Value=" + m.MyName);
        }

        private static void defaultNameProcess(object m)
        {
            // MyNameClass에서 MyName 속성이 있는지를 확인하는 코드
            PropertyInfo pInfo = m.GetType().GetProperty("MyName");

            // 해당하는 property가 있을 경우, 값을 설정
            if (pInfo != null)
            {
                pInfo.SetValue(m, "Michael Jackson");
            }
        }
    }

    class MyNameClass
    {
        public string MyName { get; set; }
    }
}

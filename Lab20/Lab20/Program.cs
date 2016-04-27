using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab20
{
    class Program
    {
        static void Main(string[] args)
        {
            // 타입을 확인하기 위해 namespace와 class name까지 정확히 기입
            Type cType = Type.GetType("Lab20.MyClass");

            // Type에서 가져온 class의 instance를 생성
            if (cType != null)
            {
                object obj = Activator.CreateInstance(cType);

                // Use that instance
                if (obj != null)
                {
                    string name = ((MyClass)obj).MyName;
                    Console.WriteLine(name);
                }
            }

            // All this code is equivalant with below
            MyClass m = new MyClass();
            Console.WriteLine(m.MyName);
        }
    }

    class MyClass
    {
        public MyClass()
        {
            MyName = "Default value from Constructor";
        }

        public string MyName { get; set; }

    }
}

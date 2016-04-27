using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab19
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass1 m1 = new MyClass1();
            MyClass2 m2 = new MyClass2();
            MyClass3 m3 = new MyClass3();

            ReflectMethod(m1);
            ReflectMethod(m2);
            ReflectMethod(m3);
        }

        private static void ReflectMethod(object m)
        {
            // argument object에서 해당하는 method가 있는지를 확인
            MethodInfo mInfo = m.GetType().GetMethod("ClassMethod");

            if (mInfo != null)
            {
                mInfo.Invoke(m, null);
            }
            else
            {
                Console.WriteLine("There's no such method found.");
            }
        }
    }

    class MyClass1
    {
        public void ClassMethod()
        {
            Console.WriteLine("Class 1 method");
        }
    }

    class MyClass2
    {
        public void ClassMethod()
        {
            Console.WriteLine("Class 2 method");
        }
    }

    class MyClass3
    {
        public void Class3Method()
        {
            Console.WriteLine("Class 3 method");
        }
    }
}

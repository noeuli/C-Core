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
            MyCLS01 m1 = new MyCLS01();
            MyCLS02 m2 = new MyCLS02();
            MyCLS03 m3 = new MyCLS03();

            ReMethod(m1);
            ReMethod(m2);
            ReMethod(m3);
        }

        private static void ReMethod(object m1)
        {
            // 가져온 개체에서.. CLSMethod 메서드가 있는지.. 확인...
            // 첫번째 , 두번째는 있고,, 세번째는 없다..
            MethodInfo m = m1.GetType().GetMethod("CLSMethod");

            if (m != null)
                m.Invoke(m1, null); // 메서드 있으면 출력
            else
                Console.WriteLine("메서드 없음.."); // 메서드 없으면 . 출력..
        }
    }

    class MyCLS01
    {
        public void CLSMethod()
        {
            Console.WriteLine("첫번째 클래스 메서드");
        }
    }
    class MyCLS02
    {
        public void CLSMethod()
        {
            Console.WriteLine("두번째 클래스 메서드");
        }
    }
    class MyCLS03
    {
        public void CLS03Method()
        {
            Console.WriteLine("세번째 클래스 메서드");
        }
    }
}

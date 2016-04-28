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
            // 타입을 확인하기 위해 네임스페이에서 해당되는 클래스까지 정확히
            Type cType = Type.GetType("Lab20.MyCLS");

            // Type에서 가져온 클래스의 개체를 생성
            object obj = Activator.CreateInstance(cType);
            int a = 10;
            int c = 1000;

            // 사용함..
            string name = ((MyCLS)obj).MyName;
            Console.WriteLine(name);

            MyCLS m = new MyCLS();
            Console.WriteLine(m.MyName);
        }
    }

    class MyCLS
    {
        public MyCLS()
        {
            MyName = "누구세요?";
        }
        public string MyName { get; set; }
    }
}

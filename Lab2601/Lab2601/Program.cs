using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// custom class library
using DataProCls;

namespace Lab2601
{
    class Program
    {
        static void Main(string[] args)
        {

            IUserInfo iUser = new UserInfo();
            Console.WriteLine("Name=" + iUser.UserName);
            Console.WriteLine("Age=" + iUser.ProcessName(20));

        }
    }
}

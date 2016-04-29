using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProCls
{
    public class UserInfo : IUserInfo
    {
        //public string UserName { get; set; }

        public UserInfo()
        {
            UserName = "Michael Jackson";
        }

        //public string fUserName = "Bart Simpson";

        //public string GetUserName()
        //{
        //    return "John Doe";
        //}

        // Interface implementation
        public string UserName { get; set; }

        public int ProcessName(int age)
        {
            return age + 1;
        }
    }

}

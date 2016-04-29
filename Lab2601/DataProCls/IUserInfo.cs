using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProCls
{
    public interface IUserInfo
    {
        string UserName { get; set; }

        int ProcessName(int age);
    }
}

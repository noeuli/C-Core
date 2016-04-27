using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Lab17
{
    [SuppressUnmanagedCodeSecurity]
    class Win32APISafe
    {
        [DllImport("user32.dll")]
        internal static extern void CreateFile(string filename);
        // internal keyword는 "관리자 권한으로 실행"하는 거란다.
    }

    class Win32API2
    {
        [DllImport("user32.dll")]
        internal static extern void CreateFile(string filename);
        // internal keyword는 "관리자 권한으로 실행"하는 거란다.
    }

    class Win32APIUnsafe
    {
        // "다른 사용자로 실행"
    }
}

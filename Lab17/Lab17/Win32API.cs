using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Lab17
{
    // 우리가 만든 dll이 있다면, 이런것들에 대한 권한 문제가 생기는데
    // 이것을 3개의 class로 나눈다.
    // UAC(User Access Control)
    // 실행할 때, 권한을 무시하는 방법 : SuppressUnmanagedCodeSecurity
    // 처리 속도가 조금 더 빠를 수 있고, 권한이 안되서 실행되지 않는 현상을 방지할 수 있다.

    // 안전한 것을 호출할 때 이 키워드를 사용한다.
    [SuppressUnmanagedCodeSecurity]
    class Win32APISafe
    {
        [DllImport("user32.dll")]
        internal static extern void MessageBox(string msg);
        // internal keyword는 "관리자 권한으로 실행"하는 거란다.
    }

    // 아무 키워드도 사용하지 않을 경우:기본. (attribute 없이 사용)
    // UAC 같음.
    // 실행할 때 마다 권한을 확인
    class Win32API2
    {
        [DllImport("user32.dll")]
        internal static extern void FormatDrive(string drive);
    }

    // 보안 체크를 하는게 원칙이겠으나, 하지 않도록 한다.
    // 권장하지 않는 방법.
    [SuppressUnmanagedCodeSecurity]
    class Win32APIUnsafe
    {
        [DllImport("user32.dll")]
        internal static extern void CreateFile(string filename);
    }
}

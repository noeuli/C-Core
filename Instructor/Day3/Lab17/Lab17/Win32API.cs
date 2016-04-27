using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Security;

namespace Lab17
{
    // 우리가만든 DLL MFC  VB6.0
    // 권한 문제가 생기는데..
    // 이것을 3개 나누기
    // 실행할때 권한 무시할 수 있음..
    // 처리 속도.. 권한으로 실행되지 않는 것을 방지
    
    // 안전한 것.. 호출
    [SuppressUnmanagedCodeSecurity]
    class Win32APISafe
    {
        [DllImport("user32.dll")]
        internal static extern void MessageBox(string s);
    }

    // 어트리뷰트.. 없이.. 사용 기본..
    // UAC 같음..
    // 실행할때 마다 권한 화깅ㄴ..
    class Win32API2
    {
        [DllImport("user32.dll")]
        internal static extern void FormatDrive(string s);
    }

    [SuppressUnmanagedCodeSecurity]
    class Win32API3Unsafe
    {
        [DllImport("user32.dll")]
        internal static extern void CreateFile(string s);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices; //SDK Full 버전.. 됨.

namespace Lab17
{
    class Program
    {
        //MSDN 샘플..
        [DllImport("msvcrt.dll")]        
        public static extern int puts(string s);

        //[DllImport("msvcrt.dll",EntryPoint ="puts")]
        //public static extern int puts(string s);

        static void Main(string[] args)
        {
            // Sqlcmd.ExcuteNonQeury("쿼리문");
            // int 영향을 받는 행수..\
            // 0 i.u.d 1이상이면 실행.. 
            // 이것처럼 결과값 확인 후 처리결과 표시 
            // 및 화면 처리를 권장

           int result = puts("안녕");

            if (result > 0)
            {
                // 정상? 비정상?
            } 
            else
            {
                // 비정상?
            }           
        }
    }
}

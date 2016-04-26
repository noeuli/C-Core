using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab04
{
    class Program
    {
        static void Main(string[] args)
        {
            //PrintScreen 메서드.. 사용
            // FUNC 대리자 인스턴스 생성
            // 2개 정수값을 입력하고,
            // 마지막 1개의 정수값은 결과값..
            Func<int, int, int> p = PrinteScreen;

            // Invoke 시작....
            // 정수값 2개를 지정...
            IAsyncResult aResult = 
                p.BeginInvoke(100, 200, null, null);

            // Invoke 종료.. 실행 하고 종료..
            // 스레드가 완료되길.. 대기..
            // 돌려받는 값을 가져와서 result 저장(int)
            int result = p.EndInvoke(aResult);

            Console.WriteLine(result);

        }

        static int PrinteScreen(int a, int b)
        {
            int total = a * b;
            return total;
        }

        // 비동기 대리자(Asynchronous Delegate)
    }
}

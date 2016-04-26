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
            // PrintScreen method 사용
            // Func delegate instance p를 생성
            // 2개의 정수값을 입력하고, 마지막 1개의 정수값은 결과값을 저장
            Func<int, int, int> p = PrintScreen;

            // Invoke 시작
            // 정수값 2개를 지정
            IAsyncResult aResult = p.BeginInvoke(100, 200, null, null);

            // Invoke 종료. 실행하고 종료
            // thread가 완료되기를 대기
            // return value를 가져와서 result에 저장한다.
            int result = p.EndInvoke(aResult);

            Console.WriteLine("result=" + result);
        }

        // Asynchronous Delegate
        static int PrintScreen(int a, int b)
        {
            int total = a * b;
            return total;
        }
    }
}

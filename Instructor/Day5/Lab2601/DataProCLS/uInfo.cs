using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProCLS
{
    public class uInfo : IuInfo
    {
        // 묵시적으로 구현(수정함)
        public string UserName
        {
            get;
            set;
        }

        // 묵시적으로 선언만 하고..
        // 해당 내용을 직접 코딩..
        public int ProcessName(int iAge)
        {
            return iAge;
        }

        // 명시적으로 구현하면.. 선언을 
        // 명시적으로 표시해줌..
        // 이름 앞에.. 해당 인터페이스 이름
        //string IuInfo.UserName
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }

        //    set
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        // 명시적으로 구현요청하면
        // 메서드 앞에 인터페이스 이름
        // 사용후에 메서드 이름 쓰고
        // 기본적인 골격 정조만.. 구현되고
        // 내용은 직접 구현해야 함.
        //int IuInfo.ProcessName(int iAge)
        //{
        //    throw new NotImplementedException();
        //}
    }
}

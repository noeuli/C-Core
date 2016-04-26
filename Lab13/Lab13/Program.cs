using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Lab13
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer t = new Timer();
            t.Interval = 6000;
            t.Elapsed += new ElapsedEventHandler(tProcess);
            t.Start();
        }

        private static void tProcess(object sender, ElapsedEventArgs e)
        {
            // 검사 후 통보
            WebClient web = new WebClient();
            string page = web.DownloadString("http://www.bandaimall.co.kr/xxxx....");
        }
    }
}

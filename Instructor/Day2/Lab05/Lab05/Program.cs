using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Lab05
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().PrintScreen();
        }

        private BackgroundWorker w;

        public void PrintScreen()
        {
            // BackgroundWork 정의
            // Thread 를 랩핑하여 필요한 부분만 정의하여
            // 쉽게 Thread를 구현할 수있도록 함
            w = new BackgroundWorker();
            w.DoWork += new DoWorkEventHandler(Print); // 실제 실행될 메서드 정의
            w.RunWorkerAsync(); // 실제 메서드 실행
        }

        void Print(object sender, DoWorkEventArgs e)
        {
        }

        
    }
}

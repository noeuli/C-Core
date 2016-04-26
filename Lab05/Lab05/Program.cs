using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading;

namespace Lab05
{
    class Program
    {
        static void Main(string[] args)
        {
            // Background Worker
            // WinForm 때문에 나온거란다.
            // WPF에서도 using만 제대로 해주면 BackgroundWorker를 사용할 수 있다.

            new Program().PrintScreen();
        }

        private BackgroundWorker w;

        public void PrintScreen()
        {
            w = new BackgroundWorker();
            w.DoWork += new DoWorkEventHandler(Print);
            w.RunWorkerCompleted += new RunWorkerCompletedEventHandler(PrintCompleted);
            Console.WriteLine(Now() + "[");
            w.RunWorkerAsync();
            Console.WriteLine(Now() + "=");
            Thread.Sleep(1);
            Console.WriteLine(Now() + "]");
        }

        string Now()
        {
            return "[" + DateTime.Now.ToString("hh:mm:ss.fff") + "] ";
        }
        void Print(object sender, DoWorkEventArgs e)
        {
            Console.WriteLine(Now() + "Hello");
        }

        void PrintCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine(Now() + "Bye");
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Lab07
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().StartBK();
        }

        private BackgroundWorker work;

        public void StartBK()
        {
            work = new BackgroundWorker();
            work.WorkerReportsProgress = true;  // 진행률 표시
            work.WorkerSupportsCancellation = true; // 취소 부분 구현

            work.DoWork += new DoWorkEventHandler(workRun); // 실행 method
            work.ProgressChanged += new ProgressChangedEventHandler(workProgress);  // 진행율을 표시하는 method 처리
            work.RunWorkerCompleted += new RunWorkerCompletedEventHandler(workCompleted);   // 일이 끝났을 때...
        }

        // cancelation
        private void CancelProcess()
        {
            // cancel
            work.CancelAsync();
        }

        private void workRun(object sender, DoWorkEventArgs e)
        {
            int count = 10000;

            for (int i=0; i<count; i++)
            {
                // cancelation handling
                if (work.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }

                // actual working : display progress rate
                work.ReportProgress(i);
            }

            // working done
            if (!e.Cancel)
            {
                e.Result = count;
            }
        }

        private void workProgress(object sender, ProgressChangedEventArgs e)
        {
            // display progress
        }

        private void workCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // UI process whatever WinForm or WPF

            if (e.Cancelled)
            {
                // display it has been canceled

            }
            else if (e.Error != null)
            {
                // throw error
                throw e.Error;
            }
            else
            {
                // notify or display it has been completed successfully.
            }
        }
    }
}

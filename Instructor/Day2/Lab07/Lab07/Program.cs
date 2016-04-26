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
            work.WorkerReportsProgress = true; // 진행율 표시
            work.WorkerSupportsCancellation = true; // 취소 부분 구현

            work.DoWork += 
                new DoWorkEventHandler(workRun); // 실행 메서드
            work.ProgressChanged += 
                new ProgressChangedEventHandler(workProgress);
            // 진행율 표시하는 메서드 처리
            work.RunWorkerCompleted +=
                new RunWorkerCompletedEventHandler(workCompleted);
            // 일이 끝났을 때.....

            work.RunWorkerAsync();
        }

        // 취소일때..
        private void CancelProcess()
        {
            // 취소..

            //진행율 표시 desible
            work.CancelAsync();
        }

        private void workRun(object sender, DoWorkEventArgs e)
        {
            // 반복문으로 처리... 10000

            int count = 10000;
            // 진행율 표시 .. enable
            for (int i = 1; i < count; i++)
            {
                // 취소가 나올때.. 처리
                if (work.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                //일을 처리함.. 그때... 진행율 표시..
                work.ReportProgress(i);
            }
            // 일이 다 끝나면...
            e.Result = count;
        }

        private void workProgress
            (object sender, ProgressChangedEventArgs e)
        {
            // 진행율 표시 도구상자.. 
        }

        private void workCompleted
            (object sender,RunWorkerCompletedEventArgs e)
        {
            // UI./.. 윈폼. WPF

            if (e.Cancelled)
            {
                // 취소했다는 것을 표시.. 통지...
            }
            else if (e.Error != null)
            {
                // 오류가 발생했을때.. 처리
                throw e.Error;
            }
            else
            {
                // 완료되었다는 통지 또는 표시
            }

        }
    }
}

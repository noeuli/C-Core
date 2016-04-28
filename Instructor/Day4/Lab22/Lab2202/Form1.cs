using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2202
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintScreen();  // UI Thread 실행..
        }

        private async void PrintScreen()
        {
            //// 비동기... 작업 스레드..에서 task 사용
            //var task = Task<int>.Run(() => TotalAync(200));

            //// task 끝날때 까지 기다림..
            //// 끝나면.. 그 결과를 total에 저장..
            //int total = await task;

            //// UI 스레드... 에서 실행..
            //// Control.Invoke (BeginInvoke) 없이 바로 사용..
            //this.label1.Text = "결과값 : " + total;

            // 위의 내용을 단 두줄에...
            int total = await TotalAync(4000);
            label1.Text = total.ToString();


        }

        //private int TotalAync(int count)
        //{
        //    int result = 0;

        //    for (int i = 0; i < count; i++)
        //    {
        //        result += i;
        //        Thread.Sleep(1000);
        //    }
        //    return result;
        //}

        private async Task<int> TotalAync(int count)
        {
            int result = 0;

            for (int i = 0; i < count; i++)
            {
                result += i;
                await Task.Delay(1000); 
                // UI 스레드.. Thread.Sleep 동급?
                //Thread.Sleep(1000);
            }
            return result;
        }
    }
}

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
            PrintScreen();
        }
        
        private async void PrintScreen()
        {
            // asynchronous. worker thread에서 task를 사용함.
            var task = Task<int>.Run(() => TotalAsync(200));

            // task 끝날때 까지 기다림
            // 끝나면 그 결과를 total에 저장
            int total = await task;

            // UI Thread에서 실행
            // Control.Invoke 또는 Control.BeginInvoke 없이 바로 사용.
            label1.Text = "Done";
        }

        private int TotalAsync(int count)
        {
            int result = 0;

            for (int i = 0; i < count; i++)
            {
                result += i;
                Thread.Sleep(1000);
            }

            return result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
    }
}

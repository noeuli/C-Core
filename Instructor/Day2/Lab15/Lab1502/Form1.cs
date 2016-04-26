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

namespace Lab1502
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread work = new Thread(PrintScreen);
            work.Start();
        }

        private void PrintScreen()
        {
            if (textBox1.InvokeRequired)
            {
                // 작업 스레드.. 크로스 스레드 오류
                //textBox1.Text = "작업 스레드";
                textBox1.BeginInvoke
                    (new Action(
                        () => textBox1.Text = "작업스레드")
                    );

            }
            else

            {
                //ui 스레드..
                textBox1.Text = "UI 스레드..";
            }
        }
    }
}

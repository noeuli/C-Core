using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lab05_Form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Step = 1;

            w.RunWorkerAsync();
        }

        private string Now()
        {
            return "[" + DateTime.Now.ToString("hh:mm:ss.fff") + "] ";
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            label1.Text = Now() + "backgroundWorker1_DoWork\n";
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            label1.Text = Now() + "backgroundWorker1_ProgressChanged(" + e.ProgressPercentage + ")\n";
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            label1.Text += Now() + "backgroundWorker1_RunWorkerCompleted\n";
        }
    }
}

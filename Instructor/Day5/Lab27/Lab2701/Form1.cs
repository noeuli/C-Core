using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2701
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IFormExchange f2 = new Form2();
            //Form2 f2 = new Form2();
            this.textBox1.Text = f2.GetLabel1Data;
            
        }

        private void Form1_MouseEnter(object sender, EventArgs e)
        {

        }
    }
}

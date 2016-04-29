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
    public partial class Form2 : Form , IFormExchange
    {
        public string GetLabel1Data
        {
            get
            {
                return this.label1.Text; ;
            }            
        }

        public Form2()
        {
            InitializeComponent();
        }

        
    }
}

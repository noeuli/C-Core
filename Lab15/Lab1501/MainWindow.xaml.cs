﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

namespace Lab1501
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Task.Factory.StartNew(UIProcess);
        }

        private void UIProcess()
        {
            if (textBox.Dispatcher.CheckAccess())
            {
                // UI Thread
                textBox.Text = "UI";
            }
            else
            {
                //textBox.Text = "Working Thread";
                // 작업 thread인지 아닌지를 확인할 때
                textBox.Dispatcher.BeginInvoke(new Action(UIProcess));
            }
        }
    }
}

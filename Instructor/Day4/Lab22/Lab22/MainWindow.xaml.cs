using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Lab22
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
            PrintScreen();  // UI Thread 실행..
        }

        private async void PrintScreen()
        {
            // 비동기... 작업 스레드..에서 task 사용
            //var task = Task<int>.Run(() => TotalAync(200));
            var task = Task.Run(() => TotalAync(200));

            // task 끝날때 까지 기다림..
            // 끝나면.. 그 결과를 total에 저장..
            int total = await task;

            // UI 스레드... 에서 실행..
            // Control.Invoke (BeginInvoke) 없이 바로 사용..
            this.label.Content = "결과값 : " + total;

            //
            //int total = await TotalAync(4000);
            //label.Content = total.ToString();
        }

        private int TotalAync(int count)
        {
            int result = 0;

            for (int i = 0; i < count; i++)
            {
                result += i;
                Thread.Sleep(1000);
            }
            return result;
        }

        //private async Task<int> TotalAync(int count)
        //{
        //    int result = 0;

        //    for (int i = 0; i < count; i++)
        //    {
        //        result += i;
        //        await Task.Delay(1000);
        //    }
        //    return result;
        //}
    }
}

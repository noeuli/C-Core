using System;
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

using System.Runtime.InteropServices;

namespace Lab2901
{
    // dll에 배열 2개 데이터 타입 2개 선언..
    public struct DLLInput
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public String strInput;

        public int intInput;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] byteArray;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public UInt32[] uIntInput;
    }


    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //[DllImport("TestSample.dll")]
        //extern public static void OnTest1();

        [DllImport("TestSample.dll",CallingConvention= CallingConvention.Cdecl)]
        extern public static int intOnTest2(int iobj);

        // 포인터 함수.. Return 값은 문자...
        [DllImport("TestSample.dll", CharSet=CharSet.Auto)]
        extern public static IntPtr strOnTest3() ;

        // 구조체형으로.. 포인터 출력..
        [DllImport("TestSample.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static void OnTest4(ref DLLInput dlli);

        private void button_Click(object sender, RoutedEventArgs e)
        {
            // OnTest2
            int a = 10;
            a = intOnTest2(a);
            MessageBox.Show(a.ToString());

            // OnTest3
            IntPtr sampleCMd = strOnTest3();
            string print = Marshal.PtrToStringAuto(sampleCMd);
            MessageBox.Show(print);

            // OnTest4
            DLLInput i = new DLLInput();
            i.byteArray = new byte[64];
            i.uIntInput = new uint[4];
            i.strInput = "홍길동";
            i.intInput = 20;
            i.byteArray[0] = (byte)'h';
            i.uIntInput[0] = 30;
            OnTest4(ref i);
            MessageBox.Show(i.strInput);

        }
        unsafe static void ONTest()
        {
            DLLInput i = new DLLInput();
            i.byteArray = new byte[64];
            i.uIntInput = new uint[4];
            i.strInput = "홍길동";
            i.intInput = 20;
            i.byteArray[0] = (byte)'h';
            i.uIntInput[0] = 30;
            OnTest4(ref i);
            MessageBox.Show(i.strInput);
        }
    }
}

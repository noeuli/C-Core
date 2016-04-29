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
using System.Diagnostics;

namespace Lab2901
{
    // dll에 배열 2개, data type 2개 선언되어 있음
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
        [DllImport("dll_sample.dll")]
        extern public static void OnTest1();

        [DllImport("dll_sample.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int intOnTest2(int arg1);

        // pointer function. return value is string
        [DllImport("dll_sample.dll", CharSet=CharSet.Auto)]
        extern public static IntPtr strOnTest3();

        // strcut type return. pointer out
        [DllImport("dll_sample.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static void OnTest4(ref DLLInput dllOut);

        [DllImport("dll_sample.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static void OnTest5();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            int a = 10;
            int b = intOnTest2(a);
            Trace.WriteLine(b);

            IntPtr sampleCmd = strOnTest3();
            string msg = Marshal.PtrToStringAuto(sampleCmd);
            Trace.WriteLine(msg);

            DLLInput i = new DLLInput();
            i.byteArray = new byte[64];
            i.uIntInput = new uint[4];
            i.strInput = "Michael Jackson";
            i.intInput = 20;
            i.byteArray[0] = (byte)'m';
            i.uIntInput[0] = 30;

            OnTest4(ref i);
            // unsafe를 사용해서 OnTest4(&i); 처럼 사용할 수도 있다.
            // 당연히 MS 권장사항은 ref keyword를 사용하는 것.

            Trace.WriteLine(i.strInput + ", " + i.intInput + ", " + i.byteArray[0] + ", " + i.uIntInput[0]);
        }

        unsafe void TestAnotherWay()
        {
            DLLInput i = new DLLInput();
            i.byteArray = new byte[64];
            i.uIntInput = new uint[4];
            i.strInput = "Michael Jackson";
            i.intInput = 20;
            i.byteArray[0] = (byte)'m';
            i.uIntInput[0] = 30;

            // 근데 안되네?
            OnTest4(&i);

            Trace.WriteLine(i.strInput + ", " + i.intInput + ", " + i.byteArray[0] + ", " + i.uIntInput[0]);
        }
    }
}

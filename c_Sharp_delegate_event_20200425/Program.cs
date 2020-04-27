using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_Sharp_delegate_event_20200425
{
    public delegate void SaySomething_Dlg(string somebody);
    public delegate void Delegate_1(string somebody);
    public delegate void Delegate_2(string somebody);

    //public event SaySomething_Dlg SaySomething_Event;//事件SaySomething_Event的定义
    class Program
    {
        public static event SaySomething_Dlg SaySomething_Event;//事件SaySomething_Event的定义

        static void Main(string[] args)
        {
            //*** *** *** 委托(链) *** *** *** 
            SaySomething_Dlg SaySomethingDlg = SayHello;
            //SaySomethingDlg -= SayHello;
            SaySomethingDlg += SayGoodbye;
            //SaySomethingDlg -= SayGoodbye;
            SaySomethingDlg("老王");

            //*** *** *** 匿名函数 *** *** *** 
            Delegate_1 Dlg1 = delegate(string name)
            {
                Console.WriteLine("{0}，我是匿名函数！", name);
            };
            Dlg1("老王");

            //*** *** *** lamda语句 *** *** *** 
            Delegate_2 Dlg2 = (name) =>
            {
                Console.WriteLine("{0}，我是lamda语句！", name);
            };
            Dlg2("老王");

            //*** *** *** 事件 *** *** *** 
            Console.WriteLine("Befor...SaySomething_Event=>{0}", SaySomething_Event);
            //事件SaySomething_Event注册方法Program_SaySomething_Event
            SaySomething_Event += Program_SaySomething_Event;
            //事件SaySomething_Event注销方法Program_SaySomething_Event
            //SaySomething_Event -= Program_SaySomething_Event;
            Console.WriteLine("After...SaySomething_Event=>{0}", SaySomething_Event);
            if (SaySomething_Event != null)
            {
                //事件SaySomething_Event调用方法Program_SaySomething_Event
                SaySomething_Event("老王");
            }
            Console.ReadKey();
        }

        static void Program_SaySomething_Event(string name)
        {
            Console.WriteLine("{0}，我是事件！", name); 
        }
        public static void SayHello(string name)
        {
            Console.WriteLine("{0}，你好呀！", name);
        }
        public static void SayGoodbye(string name)
        {
            Console.WriteLine("{0}，再见呀！", name);
        }
        
    }
}

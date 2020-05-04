using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading;
using System.Threading.Tasks;
using System.IO.Ports;//SerialPort port = new SerialPort("COM4")

namespace CSapp_XMP_6004_TEST_20200425
{
    class Program
    {
        static void Main(string[] args)
        {
            mySerialPort myPort = new mySerialPort();
            myPort.Send();
            myPort.Close();
            
            //「LittleHUANG: 坦克 教程 握手挥手 232 485 422」
            //—————————
            //************"短路"运算符************
            //Console.WriteLine("-&-运行结果为:");
            //Console.WriteLine("firstMethod() & secondMethod():={0}", firstMethod() & secondMethod());
            //Console.WriteLine("******************************************");
            //Console.WriteLine("-&&-运行结果为:");
            //Console.WriteLine("firstMethod() && secondMethod():={0}", firstMethod() && secondMethod());
            //Console.WriteLine("******************************************");
            //Console.WriteLine("-|-运行结果为:");
            //Console.WriteLine("firstMethod() | secondMethod():={0}", firstMethod() | secondMethod());
            //Console.WriteLine("******************************************");
            //Console.WriteLine("-||-运行结果为:");
            //Console.WriteLine("firstMethod() || secondMethod():={0}", firstMethod() || secondMethod());
            //Console.ReadKey();

            //Console.WriteLine("//************字符转为ASCII************");
            //int int1 = (int)'a';  //第一种方式
            //Console.WriteLine("int1: HEX->{0:X2},DEC->{1}", int1, int1);
            //Console.ReadKey();
            //string str1 = "a";    //第二种方式
            //byte[] array1 = System.Text.Encoding.ASCII.GetBytes(str1);
            //int asciicode1 = (int)(array1[0]);
            //string ASCIIstr1 = Convert.ToString(asciicode1);
            //Console.WriteLine("array1[0]: HEX->{0:X2},DEC->{1}", array1[0], array1[0]);
            //Console.WriteLine("ASCIIstr1: {0}", ASCIIstr1);
            //Console.ReadKey();

            //Console.WriteLine("//************字符串转为ASCII************");
            //string str2 = "SessionN";
            //byte[] array2 = System.Text.Encoding.ASCII.GetBytes(str2);      
            //string ASCIIstr2 = null;
            //for (int i = 0; i < array2.Length; i++)
            //{
            //    int asciicode2 = (int)(array2[i]);
            //    ASCIIstr2 += Convert.ToString(asciicode2);
            //    Console.WriteLine("array2[{0}]: HEX->{1:X2},DEC->{2}", i, array2[i], array2[i]);
            //}
            //Console.WriteLine("ASCIIstr2: {0}", ASCIIstr2);
            //Console.ReadKey();

            //Console.WriteLine("//************ASCII转为字符************");
            ////char alpha = (char)97;   //第一种方式
            //char char1 = (char)0X61;
            //Console.WriteLine("char1: {0}", char1);
            //Console.ReadKey();
            ////byte[] array3 = { 97 };  //第二种方式
            //byte[] array3 = { 0X61 };
            //string str3 =System.Text.Encoding.ASCII.GetString(array3);
            //Console.WriteLine("str3: {0}", str3);
            //Console.ReadKey();

            //Console.WriteLine("//************ASCII转为字符串************");
            ////byte[] array4 = { 83, 101, 115, 115, 105, 111, 110, 78 };
            //byte[] array4 = { 0X53, 0X65, 0X73, 0X73, 0X69, 0X6F, 0X6E, 0X4E };
            //string str4 = System.Text.Encoding.ASCII.GetString(array4);
            //Console.WriteLine("str4: {0}", str4);
            //Console.ReadKey();
        }
        //************"短路"运算符************
        //public static bool firstMethod()
        //{
        //    Console.WriteLine("这是第一个方法...");
        //    return false;
        //}
        //public static bool secondMethod()
        //{
        //    Console.WriteLine("这是第二个方法...");
        //    return true;
    }
     
    public class mySerialPort
    {
        SerialPort port;
        public mySerialPort() 
        {
            port = new SerialPort("COM10");// --- --- //
            port.BaudRate = 9600;// --- --- //      
            try
            {
                port.Open();// --- --- // 
                Console.WriteLine("The COM10 is opened...");                
                Receieve();
            }
            catch (Exception)
            {
                Console.WriteLine("The COM10 Open failed!");
            } 
        }

        private void Receieve()
        {
            port.DataReceived += port_DataReceived;// 委托与事件
            //Console.WriteLine("port.DataReceived:={0}",port.DataReceived);
        }

        void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Console.WriteLine("port_DataReceived() is Running");
            //延时200ms接收数据，解决port_DataReceived()执行多次导致接收数据分段不全的问题。
            System.Threading.Thread.Sleep(200);
            string ReceiveData = string.Empty;
            if (port != null)
            {
                int n = port.BytesToRead;//接收到的数据的字节数
                byte[] ReceiveData_Array = new byte[n];
                port.Read(ReceiveData_Array, 0, n);
                Console.WriteLine("ReceiveData_Array: " + ReceiveData_Array);
                for (int i = 0; i < ReceiveData_Array.Length; i++)
                {
                    Console.WriteLine("ReceiveData_Array[{0}]: Hex->{1:X2},Dec->{2}", i, ReceiveData_Array[i], ReceiveData_Array[i]);
                }
                ReceiveData = System.Text.Encoding.ASCII.GetString(ReceiveData_Array);
                //ReceiveData = System.Text.Encoding.UTF8.GetString(ReceiveData_Array);
                Console.WriteLine("ReceiveData: " + ReceiveData);
             }
         }

        public void Send() 
        {
            Console.Write("SendData:");
            string SendData = Console.ReadLine();
            while (SendData != "q")//输入"q"即退出
            {
                SendData = SendData.Trim();//删除字符串首部和尾部的空格
                if (!SendData.Equals(""))
                {
                    //控制台输入SendData:"/1ZR"结尾之后，键盘回车或再输入"\r\n"等转义字符，结果依然 -ng；
                    //使用for循环，控制台输出SendData_Array即可发现问题:其缺少"0X0D"，并解决问题:SendData=SendData+"\r"。
                    //SendData: *** /1ZR *** 2F 31 5A 52 0D *** 
                    //byte[] SendData_Array = {0X2F,0X31,0X5A,0X52,0X0D};
                    SendData =SendData + "\r";// -ok
                    byte[] SendData_Array = System.Text.Encoding.ASCII.GetBytes(SendData);
                    for (int i = 0; i < SendData_Array.Length; i++)
                    {
                        Console.WriteLine("SendData_Array[{0}]: Hex->{1:X2},Dec->{2}", i, SendData_Array[i], SendData_Array[i]);
                    }
                    port.Write(SendData_Array, 0, SendData_Array.Length);// --- --- //
                    //延时500ms接收数据，控制台发送完数据之后，延时写入"SendData:"。
                    System.Threading.Thread.Sleep(500);
                }
                Console.Write("SendData:");
                SendData = Console.ReadLine();
            }
        }

        public void Close() 
        {
            if (port != null && port.IsOpen)// --- --- //
            {
                port.Close();// --- --- //
                port.Dispose();// --- --- //
                Console.WriteLine("The COM4 is closed...");
            }
        }
 
    }
}
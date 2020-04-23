using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;//port = new SerialPort("COM4")

namespace CSapp_XMP_6004_TEST_20200425
{
    class Program
    {
        static void Main(string[] args)
        {
            //mySerialPort myPort = new mySerialPort();
            //myPort.Send();
            //myPort.Close();

            //************短路运算符************
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

            string str1 = "a";
            byte[] array1 = System.Text.Encoding.ASCII.GetBytes(str1);
            Console.WriteLine("HEX->{0 :X2}", array1[0]);
            int asciicode1 = (int)(array1[0]);
            string ASCIIstr1 = Convert.ToString(asciicode1);
            Console.WriteLine("DEC->{0}", ASCIIstr1);
            Console.ReadKey();

            string str2 = "SessionN";
            byte[] array2 = System.Text.Encoding.ASCII.GetBytes(str2);     
            string ASCIIstr2 = null;
            for (int i = 0; i < array2.Length; i++)
            {
                Console.WriteLine("HEX->{0 :X2}", array2[i]);
                int asciicode2 = (int)(array2[i]);
                ASCIIstr2 += Convert.ToString(asciicode2) + " ";
            }
            Console.WriteLine("DEC->{0}",ASCIIstr2);
            Console.ReadKey();

            //byte[] array3 = { 65 };
            byte[] array3 = { 0X41 };
            string str3 =
                System.Text.Encoding.ASCII.GetString(array3);
            Console.WriteLine(str3);
            Console.ReadKey();

            byte[] array4 = { 83, 101, 115, 115, 105, 111, 110, 78 };
            string str4 = System.Text.Encoding.ASCII.GetString(array4);
            Console.WriteLine(str4);
            Console.ReadKey();
        }
        public static bool firstMethod()
        {
            Console.WriteLine("这是第一个方法...");
            return true;
        }
        public static bool secondMethod()
        {
            Console.WriteLine("这是第二个方法...");
            return true;
        }
    }
     
    public class mySerialPort
    {
        SerialPort port;
        public mySerialPort() 
        {
            port = new SerialPort("COM4");// --- ---
            port.BaudRate = 9600;// --- ---      
            try
            {
                port.Open();// --- --- 
                Console.WriteLine("The COM4 is opened...");                
                Receieve();
            }
            catch (Exception)
            {
                Console.WriteLine("The COM4 Open failed!");
            } 
        }

        //接收数据
        private void Receieve()
        {
            //接收到数据就会触发port_DataReceived方法
            port.DataReceived += port_DataReceived;
        }
        void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //存储接收的字符串
            string strReceive = string.Empty;
            if (port != null)
            {
                //读取接收到的字节长度
                int n = port.BytesToRead;
                //定义字节存储器数组
                byte[] byteReceive = new byte[n];
                //接收的字节存入字节存储器数组
                port.Read(byteReceive, 0, n);
                //把接收的的字节数组转成字符串
                strReceive = Encoding.UTF8.GetString(byteReceive);
                Console.WriteLine("接收到的数据是: " + strReceive);
             }
         }

        public void Send() 
        {
            Console.WriteLine("SendData:");
            string SendData = Console.ReadLine();
            while (SendData != "q")//输入"q"即退出
            {
                SendData = SendData.Trim();//删除字符串首部和尾部的空格
                if (!SendData.Equals(""))
                {
                    port.WriteLine(SendData);// --- ---
                }
                Console.WriteLine("SendData:");
                SendData = Console.ReadLine();
            }
        }

        public void Close() 
        {
            if (port != null && port.IsOpen)// --- ---
            {
                port.Close();// --- ---
                port.Dispose();// --- ---
                Console.WriteLine("The COM4 is closed...");
            }
        }
 
    }
}
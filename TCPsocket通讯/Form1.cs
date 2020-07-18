using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCPsocket通讯
{
    public partial class Form1 : Form
    {
        delegate void AddOnlineDelegate(string  str ,bool bl);
        delegate void RecMegDelegate(string str);
        Dictionary<string, Socket> DicSocket = new Dictionary<string, Socket>();
        public Form1()
        {
            InitializeComponent();
            myAddOnlineDelegate = AddOnline;
            myRecMegDelegate = AddRecMsg;
        }
        Socket socket = null;
        Thread threadListen = null;
        AddOnlineDelegate myAddOnlineDelegate;
        RecMegDelegate myRecMegDelegate;
        private void btn_StartServer_Click(object sender, EventArgs e)
        {
            socket = new Socket( AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress iPAddress = IPAddress.Parse(txt_IP.Text.Trim());
            IPEndPoint iPEndPoint = new IPEndPoint(iPAddress,int.Parse(txt_Port.Text.Trim()));
            try
            {
                socket.Bind(iPEndPoint);
                MessageBox.Show("服务开启成功" );
            }
            catch (Exception ex)
            {

                MessageBox.Show("服务开启失败"+ex);
                return;
            }
            socket.Listen(10);
            threadListen = new Thread(ListenConnecting1);
            threadListen.IsBackground=true;
            threadListen.Start();
            btn_StartServer.Enabled = false;
        }

        private void ListenConnecting1()
        {
            while (true)
            {
                Socket socketClient = socket.Accept();
                string client = socketClient.RemoteEndPoint.ToString();
                DicSocket.Add(client,socketClient);
               
                Invoke(myAddOnlineDelegate, client,true);
                
                Thread thr = new Thread(RecieveMsg);
                
                thr.IsBackground = true;
                thr.Start(socketClient);
            }

        }

        private void RecieveMsg(object socketClient)
        {
            Socket scketClient = socketClient as Socket;
            while (true)
            {
                byte[] arrMsgRec = new byte[1024 * 1024 * 2];
                int length = -1;
                try
                {
                    length = scketClient.Receive(arrMsgRec);

                }
                catch (Exception)
                {

                    string str = scketClient.RemoteEndPoint.ToString();
                    Invoke(myRecMegDelegate, str + "下线了");
                    Invoke(myAddOnlineDelegate,str,false);
                    DicSocket.Remove(str);
                    break;
                }
               
                if (length == 0)
                {
                    string str = scketClient.RemoteEndPoint.ToString();
                    Invoke(myAddOnlineDelegate, str, false) ;
                    DicSocket.Remove(str);
                    break;
                }
                else
                {
                    string strMsg = Encoding.UTF8.GetString(arrMsgRec,0, length);
                    Invoke(myRecMegDelegate , strMsg+ Environment.NewLine);
                }
            }
        }
        #region 委托更新UI
        private void AddOnline(string str,bool bl)
        {
            if (bl)
            {
                txt_Online.Items.Add(str);
            }
            else
            {
                txt_Online.Items.Remove(str);
            }
            
        }
        private void AddRecMsg(string str)
        {
            txt_Rcv.AppendText(str);
        }
        #endregion

        private void btn_SendToSingle_Click(object sender, EventArgs e)
        {
            string StrMsg = this.txt_Send.Text.Trim();
            byte[] arrMsg = Encoding.UTF8.GetBytes(StrMsg);
            if (this.txt_Online.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择要发送的对象");
                return;
            }
            else
            {
                foreach (String item in this.txt_Online.SelectedItems)
                {
                    DicSocket[item].Send(arrMsg);
                    string Msg = "[发送]  " + item + "   " + StrMsg;
                    Invoke(myRecMegDelegate,Msg+Environment.NewLine);
                }
            }
        }

        private void OpenClient_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}

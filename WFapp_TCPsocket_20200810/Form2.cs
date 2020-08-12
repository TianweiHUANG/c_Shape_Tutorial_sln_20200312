using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace WFapp_TCPsocket_20200810
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        Socket myClientSocket = null;
        Thread thr_myClientRcvMsg = null;
        private bool IsRunning_From2 = true;

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            myClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress myServerIPAddress = IPAddress.Parse(this.text_IPAddress.Text.Trim());
            IPEndPoint myServerIPEndPoint = new IPEndPoint(myServerIPAddress, int.Parse(this.text_PORT.Text.Trim()));

            try
            {
                this.text_RcvMsg.AppendText("Connecting..." + Environment.NewLine);
                myClientSocket.Connect(myServerIPEndPoint);
            }
            catch (Exception)
            {
                MessageBox.Show("The Connection failed !");
                return;
            }
            this.text_RcvMsg.AppendText("The Connection successfully..." + Environment.NewLine);

            thr_myClientRcvMsg = new Thread(func_myClientRcvMsg);
            thr_myClientRcvMsg.IsBackground = true;
            thr_myClientRcvMsg.Start();
        }

        private void func_myClientRcvMsg()
        {
            while (IsRunning_From2)
            {
                byte[] arr_myClientRcvMsg = new byte[1024 * 1024 * 2];
                int len_myClientRcvMsg = -1;
                try
                {
                    len_myClientRcvMsg = myClientSocket.Receive(arr_myClientRcvMsg);
                }
                catch (SocketException)
                {
                    break;
                }
                catch (Exception)
                {
                    Invoke(new Action(() => this.text_RcvMsg.AppendText("Disconnection !" + Environment.NewLine)));
                }

                if (len_myClientRcvMsg == 0)
                {
                    Invoke(new Action(() => this.text_RcvMsg.AppendText("Disconnection !" + Environment.NewLine)));
                    break;
                }
                else
                {
                    string str_myClientRcvMsg = Encoding.UTF8.GetString(arr_myClientRcvMsg, 0, len_myClientRcvMsg);
                    string Content_myClientRcvMsg = "RcvMsg From Server: " + str_myClientRcvMsg + Environment.NewLine;
                    Invoke(new Action(() => this.text_RcvMsg.AppendText(Content_myClientRcvMsg)));
                }
            }
        }

        private void btn_SendMsg_Click(object sender, EventArgs e)
        {
            string Content_myClientSendMsg = "<" + this.text_Name.Text.Trim() + "> " + this.text_SendMsg.Text.Trim();
            byte[] arr_myClientSendMsg = Encoding.UTF8.GetBytes(Content_myClientSendMsg);
            myClientSocket.Send(arr_myClientSendMsg);
            Invoke(new Action(() => this.text_RcvMsg.AppendText("SendMsg To  Server: " + this.text_SendMsg.Text.Trim() + Environment.NewLine)));
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            IsRunning_From2 = false;
            //myClientSocket?.Close();
            if (myClientSocket != null)
            {
                myClientSocket.Close();
            }
        }
    }
}

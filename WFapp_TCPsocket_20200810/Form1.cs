using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace WFapp_TCPsocket_20200810
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void text_RcvMsg_TextChanged(object sender, EventArgs e)
        {

        }

        private void text_SendMsg_TextChanged(object sender, EventArgs e)
        {

        }

        private void lab_IPAddress_Click(object sender, EventArgs e)
        {

        }

        private void text_IPAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void lab_PORT_Click(object sender, EventArgs e)
        {

        }

        private void text_PORT_TextChanged(object sender, EventArgs e)
        {

        }

        private void list_OneLine_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        Socket mySocket = null;
        private void btn_StartServer_Click(object sender, EventArgs e)
        {
            mySocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress myIPAddress = IPAddress.Parse(text_IPAddress.Text.Trim());
            IPEndPoint myIPEndPoint = new IPEndPoint(myIPAddress, int.Parse(text_PORT.Text.Trim()));
            try
            {
                mySocket.Bind(myIPEndPoint);
            }
            catch (Exception)
            {
                MessageBox.Show("StartServer Failed");
            }
            MessageBox.Show("StartServer Successfully");
            btn_StartServer.Enabled = false;
            mySocket.Listen(10);

            Thread thr_myAccept = new Thread(func_myAccept);
            thr_myAccept.IsBackground = true;
            thr_myAccept.Start();           
        }

        private void func_myAccept()
        {
            while (true)
            {
                Socket socket_myAccept = mySocket.Accept();
                string str_myRemoteEndPoint = socket_myAccept.RemoteEndPoint.ToString();

                Thread thr_myRcvMsg = new Thread(func_myRcvMsg);
                thr_myRcvMsg.IsBackground = true;
                thr_myRcvMsg.Start(socket_myAccept);
            }

        }

        private void func_myRcvMsg(object object_socket)
        {
            Socket socket_myAccept = object_socket as Socket;
            while (true)
            {
                byte[] arr_myRcvMsg = new byte[1024 * 1024 * 2];
                int Len_myRcvMsg = -1;
                Len_myRcvMsg = socket_myAccept.Receive(arr_myRcvMsg);

                if (Len_myRcvMsg == 0)
                {
                    break;
                }
                else
                {
                    string str_myRcvMsg = Encoding.UTF8.GetString(arr_myRcvMsg);
                }   
            }
        }

        private void btn_SendMsg_Click(object sender, EventArgs e)
        {

        }

        private void btn_WFapp_TCPsocket_Client_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}

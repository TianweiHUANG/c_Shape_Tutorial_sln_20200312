//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TCP_Socket_Server_TEST_20200321
{
    /// <summary>
    /// 服务端
    /// </summary>
    class Serversocket
    {
        /// <summary>
        /// 服务端入口
        /// </summary>
        private static Serversocket socketserver;
        public static Serversocket Instance()
        {
            if (socketserver == null)
            {
                socketserver = new Serversocket();
            }
            return socketserver;
        }

        private Socket server;
        private IPAddress iPAddress;
        private int port;

        /// <summary>
        /// 初始化数据
        /// </summary>
        public void Init()
        {
            iPAddress = IPAddress.Parse("127.0.0.1");
            port = 8888;
            CreateSocket();
            BindAndListen();
            WaitClientConnection();
        }

        /// <summary>
        /// 1.创建服务端的套接字
        /// </summary>
        private void CreateSocket()
        {
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        }
        /// <summary>
        /// 2.绑定服务器ip和端口
        /// </summary>
        private void BindAndListen()
        {
            server.Bind(new IPEndPoint(iPAddress, port));
            server.Listen(100);
        }

        /// <summary>
        /// 用一个列表储存连接成功的客户端
        /// </summary>
        private List<Socket> ConnectSockeList = new List<Socket>();
        /// <summary>
        /// 用一个字典储存所有接受客户端消息以及发送给客户端消息的线程
        /// </summary>
        private Dictionary<int, List<Thread>> recvThreadList = new Dictionary<int, List<Thread>>();

        /// <summary>
        /// 3.等待客户端的连接
        /// </summary>
        private void WaitClientConnection()
        {
            int index = 1;
            while (true)
            {
                Console.WriteLine("当前链接数量：" + recvThreadList.Count);
                Console.WriteLine("等待客户端的链接：");
                Socket ClientSocket = server.Accept();
                if (ClientSocket != null)
                {
                    Console.WriteLine("{0}连接成功！", ClientSocket.RemoteEndPoint);
                    ConnectSockeList.Add(ClientSocket);
                    //创建接受客户端消息的线程，并将其启动
                    Thread recv = new Thread(RecvMessage);
                    recv.Start(new ArrayList { index, ClientSocket });
                    Thread send = new Thread(SendMessage);
                    send.Start(new ArrayList { index, ClientSocket });
                    recvThreadList.Add(index, new List<Thread> { recv, send });
                    index++;
                }
            }
        }

        /// <summary>
        /// 接受客户端的消息
        /// </summary>
        /// <param name="clientsocket"></param>
        private void RecvMessage(object client_socket)
        {
            ArrayList arraylist = client_socket as ArrayList;
            int index = (int)arraylist[0];
            Socket clientsocket = arraylist[1] as Socket;
            while (true)
            {
                try
                {
                    byte[] strbyte = new byte[1024];
                    int count = clientsocket.Receive(strbyte);
                    string ret = Encoding.UTF8.GetString(strbyte, 0, count);
                    Console.WriteLine("{0}给你发送了消息：{1}", clientsocket.RemoteEndPoint, ret);
                }
                catch (Exception)
                {
                    //客户端离去时终止线程
                    Console.WriteLine("代号为:{0}的客户端已经离去！", index);
                    recvThreadList[index][0].Abort();
                }
            }
        }

        /// <summary>
        /// 向客户端返回消息
        /// </summary>
        private void SendMessage(object client_socket)
        {
            ArrayList arraylist = client_socket as ArrayList;
            int index = (int)arraylist[0];
            Socket clientsocket = arraylist[1] as Socket;
            while (true)
            {
                try
                {
                    Console.WriteLine("请输入要发送的消息：");
                    string str = Console.ReadLine();
                    byte[] strbyte = Encoding.UTF8.GetBytes(str);
                    clientsocket.Send(strbyte);
                }
                catch (Exception)
                {

                    Console.WriteLine("代号为：{0}的客户端已经离去！消息发送失败！");
                    recvThreadList[index][1].Abort();
                    recvThreadList.Remove(index);
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Serversocket.Instance().Init();
            Console.ReadKey();
        }
    }
}

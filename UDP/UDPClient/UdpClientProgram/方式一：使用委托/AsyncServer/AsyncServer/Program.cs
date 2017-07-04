using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace AsyncServer
{
    class Program
    {
        private static IPEndPoint epServer;
        private static IPEndPoint epClient;
        private static UdpClient server;

        static void Main(string[] args)
        {
            epServer = new IPEndPoint(IPAddress.Any, 11000);    //设置服务器端口，IP是本程序所在PC的内网IP
            epClient = new IPEndPoint(IPAddress.Any, 0);    //设置客户端，任意IP，任意端口号
            server = new UdpClient(epServer);   //绑定设置的服务器端口和IP
            Console.WriteLine("listening...");
            while (true) {
                //下面三行代码经过修改，原代码如下
                //server.BeginReceive(new AsyncCallback(ReceiveCallback), null);
                //该代码会被挂起，接收到一个消息时启动一个线程，该线程启动函数是：ReceiveCallback，在该函数中
                //会修改epClient的值，但程序会继续向下执行，执行到server.BeginSend时，发现epClient是无效的，报异常
                //所以改为如下代码，可以正常运行
                IAsyncResult iar = server.BeginReceive(null, null);
                byte[] receiveData = server.EndReceive(iar, ref epClient);
                Console.WriteLine("Received a message from [{0}]: {1}", epClient, Encoding.ASCII.GetString(receiveData));
                //以下是发送消息回客户端
                string strSend = "hello " + epClient.ToString();
                byte[] sendData = Encoding.ASCII.GetBytes(strSend);
                //下面一行代码，将启动一个线程，该线程启动函数：SendCallback，该函数结束挂起的异步发送
                server.BeginSend(sendData, sendData.Length, epClient, new AsyncCallback(SendCallback), null);
            }
        }
        //此函数未被使用，如需使用，可以借鉴
        private static void ReceiveCallback(IAsyncResult iar)
        {
            byte[] receiveData = server.EndReceive(iar, ref epClient);
            Console.WriteLine("Received a message from [{0}]: {1}", epClient, Encoding.ASCII.GetString(receiveData));
        }

        private static void SendCallback(IAsyncResult iar)
        {
            int sendCount = server.EndSend(iar);
            if (sendCount == 0)
            { Console.WriteLine("Send a message failure..."); }
        }
    }
}

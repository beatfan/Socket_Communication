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
            IPEndPoint epServer = new IPEndPoint(IPAddress.Any, 11000);    //设置服务器端口，IP是本程序所在PC的内网IP
            IPEndPoint epClient = new IPEndPoint(IPAddress.Any, 0);    //设置客户端，任意IP，任意端口号
            UdpClient server = new UdpClient(epServer);   //绑定设置的服务器端口和IP
            Console.WriteLine("listening...");
            while (true) {
                //下面开始接收，不使用委托，开始异步接收，在接收到消息后，马上结束挂起的异步接收
                IAsyncResult iarReceive = server.BeginReceive(null, null);
                byte[] receiveData = server.EndReceive(iarReceive, ref epClient);
                Console.WriteLine("Received a message from [{0}]: {1}", epClient, Encoding.ASCII.GetString(receiveData));
                //以下是发送消息回客户端
                string strSend = "hello " + epClient.ToString();
                byte[] sendData = Encoding.ASCII.GetBytes(strSend);
                //下面一行代码，不使用委托，开始异步发送后马上结束挂起的异步发送
                IAsyncResult iarSend = server.BeginSend(sendData, sendData.Length, epClient, null, null);
                int sendCount = server.EndSend(iarSend);
                if (sendCount == 0)
                { Console.WriteLine("Send a message failure..."); }
            }
        }
    }
}

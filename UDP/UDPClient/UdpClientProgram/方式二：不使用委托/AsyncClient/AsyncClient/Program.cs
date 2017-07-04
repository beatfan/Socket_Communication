using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace AsyncClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //设置服务器端IP和端口
            IPEndPoint epServer = new IPEndPoint(IPAddress.Parse("192.168.1.175"), 11000);
            UdpClient local = new UdpClient(9001);  //绑定本机IP和端口，端口号是9001，不需要设置IP
            while (true) {
                string strSend = Console.ReadLine();
                if (strSend == "exit") break;
                byte[] sendData = Encoding.ASCII.GetBytes(strSend);
                //下面开始异步发送，不使用委托，开始发送后马上结束挂起的异步发送
                IAsyncResult iarSend = local.BeginSend(sendData, sendData.Length, epServer, null, null);
                int sendCount = local.EndSend(iarSend);
                if (sendCount <= 0) {
                    Console.WriteLine("Send a message failure...");
                    continue;
                }
                //下面开始异步接收，不使用委托，开始接收，接收到后马上结束挂起的异步接收
                IAsyncResult iarReceive = local.BeginReceive(null, null);
                byte[] receiveData = local.EndReceive(iarReceive, ref epServer);
                Console.WriteLine("Server: {0}", Encoding.ASCII.GetString(receiveData));
            }
        }
    }
}

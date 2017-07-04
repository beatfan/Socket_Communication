using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace Scan_Gun
{
    public static class SocketServerListen
    {
        
        static Socket serverSocket;

        public static void SocketListen(string myip, int myProt)
        {
            //服务器IP地址   
            IPAddress ip = IPAddress.Parse(myip);
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(new IPEndPoint(ip, myProt));  //绑定IP地址：端口   
            serverSocket.Listen(10);    //设定最多10个排队连接请求   
            //Console.WriteLine("启动监听{0}成功", serverSocket.LocalEndPoint.ToString());
            //通过Clientsoket发送数据   
            Thread myThread = new Thread(ListenClientConnect);
            myThread.Start();
            //Console.ReadLine();
        }

        /// <summary>   
        /// 监听客户端连接   
        /// </summary>   
        public static void ListenClientConnect()
        {
            CommonData.ListeningFlag = true;
            while (CommonData.ListeningFlag)
            {
                try
                {
                    Socket clientSocket = serverSocket.Accept();
                    clientSocket.Send(Encoding.ASCII.GetBytes("Server Say Hello"));

                    //新建线程给客户端发消息
                    test.clientSocket = clientSocket;
                    Thread receiveThread = new Thread(test.ReceiveMessage);
                    receiveThread.Start();
                }
                catch
                { }
            }
            //serverSocket.Close();
            //serverSocket.Dispose();
        }

        /// <summary>
        /// 停止监听
        /// </summary>
        public static void StopListen()
        {
            try
            {
                if (serverSocket != null)
                {
                    serverSocket.Close();
                    serverSocket.Dispose();
                }
            }
            catch
            { }
        }

    }

    public static class test
    {
        public static byte[] result = new byte[1024];
        public static object clientSocket = new object();
        /// <summary>   
        /// 接收消息   
        /// </summary>   
        /// <param name="clientSocket"></param>   
        public delegate void ct(string message);
        public static ct delecheckSet;
        public static void ReceiveMessage()
        {
            Socket myClientSocket = (Socket)clientSocket;
            //while (true)  
            {
                try
                {
                    //通过clientSocket接收数据   
                    int receiveNumber = myClientSocket.Receive(result);

                    string s = Encoding.ASCII.GetString(result, 0, receiveNumber);

                    delecheckSet(s);  //委托到主线程

                    //Console.WriteLine("接收客户端{0} 消息{1}", myClientSocket.RemoteEndPoint.ToString(),s );
                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex.ToString());
                    myClientSocket.Shutdown(SocketShutdown.Both);
                    myClientSocket.Close();
                    //break;  
                }
            }
        }  
    }
}

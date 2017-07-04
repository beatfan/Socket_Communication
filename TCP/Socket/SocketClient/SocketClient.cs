using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace SocketClient
{
    public class SocketClient
    {
        Socket SktClient ;

        /// <summary>
        /// 连接
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public bool Connect(string ip, int port)
        {
            SktClient = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
            IPAddress ServerIP = IPAddress.Parse(ip);
            IPEndPoint RePoint = new IPEndPoint(ServerIP, port);
            SktClient.SendTimeout = 300;
            SktClient.ReceiveTimeout = 300;
            try
            {
                SktClient.Connect(RePoint);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="sData"></param>
        /// <returns></returns>
        public Boolean SendData(string sData)
        {
            try
            {
                SktClient.Send(Encoding.ASCII.GetBytes(sData));
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 接收数据
        /// </summary>
        /// <returns></returns>
        public byte[] RecData()
        {
            try
            {
                byte[] buf = new byte[1024];
                //SocketFlags t = SktClient.;
                SktClient.Receive(buf);
                return buf;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 关闭Socket连接
        /// </summary>
        /// <returns></returns>
        public Boolean StopSocket()
        {
            try
            {
                SktClient.Shutdown(SocketShutdown.Both);
                SktClient.Close();
                SktClient = null;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

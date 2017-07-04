using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace TCPClientTest
{
    public class Tcp
    {
        public delegate void PushTcpData(byte[] data);
        public PushTcpData PushTcpDatas;  //推送委托

        public bool isConnect;
        public bool isFileMode;

        TcpClient tcpClient;
        NetworkStream workStream;

        IPEndPoint RemotePoint;

        string RemoteIP;
        int RemotePort;

        #region 发送tcp
        public void SendData(string str)
        {
            byte[] data = Encoding.ASCII.GetBytes(str);
            workStream.Write(data, 0, data.Length);
            workStream.Flush();
        }

        public void connect(string ip,string port)
        {
            RemoteIP = ip;
            RemotePort = Convert.ToInt32(port);

            if (!isConnect)  //当前未连接，将连接
            {
                //UIConnect(true);
                isConnect = true;

                RemotePoint = new IPEndPoint(IPAddress.Parse(ip), Convert.ToInt32(port));
                tcpClient = new TcpClient();
                tcpClient.Connect(RemotePoint);

                workStream = tcpClient.GetStream();

                asyncread(tcpClient);  //启动异步接收
            }
            else  //将断开
            {
                //UIConnect(false);
                isConnect = false;
                tcpClient.Close();
                workStream.Close();
            }
        }

        public void SendFile(string str, string filepath)
        {
            //Step 1  file name
            //Step 2  file sizes
            //Step 3  file md5
            //Step 4  receiver mode
            //Step 5  raw data*(only file data)
            //Step 6  response checksum


            FileStream fs = new FileStream(filepath, FileMode.Open);

            string filename = "PFN = " + filepath.Split('\\')[filepath.Split('\\').Length - 1];

            string filesize = "PFS = " + fs.Length.ToString();

            string md5checksum = "PFC = " + GetMd5.getMD5Hash(filepath);

            //文件名
            SendData(filename);
            Thread.Sleep(20);

            //文件大小
            SendData(filesize);
            Thread.Sleep(20);

            //文件MD5
            SendData(md5checksum);
            Thread.Sleep(20);

            //发送命令
            SendData(str);
            Thread.Sleep(20);

            //发送文件

            int size = 0;//初始化读取的流量为0   
            long len = 0;//初始化已经读取的流量   
            while (len < fs.Length)
            {
                byte[] buffer = new byte[512];
                size = fs.Read(buffer, 0, buffer.Length);
                workStream.Write(buffer, 0, size);
                len += size;

                fs.Flush();
                //Pro((long)len);   
            }
            
            workStream.Flush();
            fs.Close();
        }
        #endregion

        #region 异步读tcp
        /// <summary>
        /// 异步读TCP数据
        /// </summary>
        /// <param name="sock"></param>
        private void asyncread(TcpClient sock)
        {
            StateObject state = new StateObject();
            state.client = sock;
            NetworkStream stream = sock.GetStream();

            if (stream.CanRead)
            {
                try
                {
                    IAsyncResult ar = stream.BeginRead(state.buffer, 0, StateObject.BufferSize,
                            new AsyncCallback(TCPReadCallBack), state);
                }
                catch (Exception e)
                {

                }
            }
        }



        /// <summary>
        /// TCP读数据的回调函数
        /// </summary>
        /// <param name="ar"></param>

        private void TCPReadCallBack(IAsyncResult ar)
        {
            StateObject state = (StateObject)ar.AsyncState;
            //主动断开时

            if ((state.client == null) || (!state.client.Connected))
                return;

            int numberOfBytesRead;
            NetworkStream Workstream1 = state.client.GetStream();

            numberOfBytesRead = Workstream1.EndRead(ar);
            state.totalBytesRead += numberOfBytesRead;

            if (numberOfBytesRead > 0)
            {
                byte[] dd = new byte[numberOfBytesRead];
                Array.Copy(state.buffer, 0, dd, 0, numberOfBytesRead);

                PushTcpDatas(dd);
                Workstream1.BeginRead(state.buffer, 0, StateObject.BufferSize,
                        new AsyncCallback(TCPReadCallBack), state);
            }
            else
            {
                //被动断开时 

                Workstream1.Close();
                state.client.Close();

                Workstream1 = null;
                state = null;

                //UIConnect(false);
                isConnect = false;
            }
        }
        #endregion
    }


    #region 异步接收 object
    internal class StateObject
    {
        public TcpClient client = null;
        public int totalBytesRead = 0;
        public const int BufferSize = 1024;
        public string readType = null;
        public byte[] buffer = new byte[BufferSize];
        public StringBuilder messageBuffer = new StringBuilder();

    }
    #endregion
}

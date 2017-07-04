using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Client
{
    public partial class SendForm : Form
    {
        bool isConnect;
        TcpClient tcpClient;
        NetworkStream workStream;

        bool isSend;

        IPEndPoint RemotePoint;

        public SendForm()
        {
            InitializeComponent();
            UIConnect(false);
            lbResult.Text = "";
            btnSend.Enabled = false;
        }

        #region UI关于连接
        void UIConnect(bool isConnected)
        {
            isConnect = tbFilePath.Enabled = isConnected;

            tbRemoteIP.Enabled = tbRemotePort.Enabled = !isConnected;

            if (isConnected)
                btnConnect.Text = "disConnect";
            else
                btnConnect.Text = "Connect";
        }
        #endregion

        #region 选择文件
        private void tbFilePath_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "压缩文件(*.zip)|*.zip";
            ofd.InitialDirectory = Directory.GetCurrentDirectory();
            //string filepath;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                tbFilePath.Text = ofd.FileName;
            }
        }
        #endregion

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (!isConnect)  //当前未连接，将连接
            {
                UIConnect(true);

                RemotePoint = new IPEndPoint(IPAddress.Parse(tbRemoteIP.Text), Convert.ToInt32(tbRemotePort.Text));
                tcpClient = new TcpClient();
                tcpClient.Connect(RemotePoint);

                workStream = tcpClient.GetStream();

                asyncread(tcpClient);  //启动异步接收
            }
            else  //将断开
            {
                UIConnect(false);
                tcpClient.Close();
                workStream.Close();
            }
        }

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
        /// 异步接收到数据
        /// </summary>
        /// <param name="data"></param>
        private void OnGetData(byte[] data)
        {
            string sdata = Encoding.ASCII.GetString(data);
            if (sdata.ToLower() == "ok")
            {
                isSend = true;
            }
            else
            {
                isSend = false;
            }

            waitRec.Set();

            this.Invoke(new MethodInvoker(delegate {
                lbResult.Text = sdata;
            }));
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

                OnGetData(dd);
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

                UIConnect(false);
            }
        }
        #endregion

        //等待回应
        AutoResetEvent waitRec = new AutoResetEvent(false);
        //发送数据
        private void SendData(string str)
        {
            byte[] data = Encoding.ASCII.GetBytes(str);
            workStream.Write(data, 0, data.Length);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (!File.Exists(tbFilePath.Text))
                return;
            
            FileStream fs = new FileStream(tbFilePath.Text, FileMode.Open);

            string sd = tbFilePath.Text.Split('\\')[tbFilePath.Text.Split('\\').Length - 1]
                +":"+fs.Length.ToString();

            SendData(sd);
            waitRec.WaitOne();  //等待对方回应

            if (!isSend)  //对方回复非OK
                return;

            btnConnect.Enabled = tbFilePath.Enabled = btnSend.Enabled = false;
            
            Thread a = new Thread(() =>
            {
                //发送文件
                int size = 0;//初始化读取的流量为0   
                long len = 0;//初始化已经读取的流量   
                while (len < fs.Length)
                {
                    byte[] buffer = new byte[512];
                    size = fs.Read(buffer, 0, buffer.Length);
                    workStream.Write(buffer, 0, size);
                    len += size;
                    //Pro((long)len);   
                    this.Invoke(new MethodInvoker(delegate
                    {
                        pbState.Value = (int)(len * 100 / fs.Length);
                    }));
                }
                fs.Flush();
                workStream.Flush();
                fs.Close();
                this.Invoke(new MethodInvoker(delegate
                {
                    pbState.Value = 0;
                    btnConnect.Enabled = tbFilePath.Enabled = btnSend.Enabled = false;
                }));
                
            });
            a.Start();
            
        }

        private void tbFilePath_TextChanged(object sender, EventArgs e)
        {
            if (tbFilePath.Text == "" || tbFilePath.Text == "双击选择文件")
                btnSend.Enabled = false;
            else
                btnSend.Enabled = true;
        }
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

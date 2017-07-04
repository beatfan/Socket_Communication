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

namespace Server
{
    public partial class Receive : Form
    {
        public Receive()
        {
            InitializeComponent();
            cbIPBox.Items.AddRange(GetLocalIP().ToArray());
            cbIPBox.SelectedIndex = 1;
            ListBox.CheckForIllegalCrossThreadCalls = false;//关闭跨线程对ListBox的检查

        }


        TcpListener listener;
        bool isStart;

        long filesize=1;
        string filename;

        #region 服务器启动监听服务，并开始接收文件
        private void btnBegin_Click(object sender, EventArgs e)
        {
            isStart = true;
            btnCancel.Enabled = !(btnBegin.Enabled = false);
            
            listener = new TcpListener(IPAddress.Parse(cbIPBox.Text), int.Parse(tbPort.Text));
            listener.Start();
            ShwMsgForView.ShwMsgforView(lstbxMsgView, "服务器开始监听");
            Thread th = new Thread(ReceiveMsg);
            th.Start();
            th.IsBackground = true;
        }

        public void ReceiveMsg()
        {
            while (isStart)
            {
                try
                {
                    
                    TcpClient client = listener.AcceptTcpClient();

                    if (client.Connected)
                    {
                        //向列表控件中添加一个客户端的Ip和端口，作为发送时客户的唯一标识
                        listbOnline.Items.Add(client.Client.RemoteEndPoint);
                        ShwMsgForView.ShwMsgforView(lstbxMsgView, "客户端连接成功" + client.Client.RemoteEndPoint.ToString());
                    }

                    NetworkStream stream = client.GetStream();


                    byte[] buffer = new byte[512];

                    //while (true)
                    //{
                    //    byte[] send = Encoding.ASCII.GetBytes("12121212");
                    //    stream.Write(send, 0, send.Length);
                    //    stream.Flush();
                    //    Thread.Sleep(100);
                    //}

                    int size;
                    while ((size = stream.Read(buffer, 0, buffer.Length)) > 0 || isStart)
                    {
                        byte[] recData = new byte[size];
                        Array.Copy(buffer, recData, size);
                        string recsData = Encoding.ASCII.GetString(recData);
                        string[] rec = recsData.Split(':');
                        if (rec.Length == 2)
                        {
                            filename = rec[0];
                            filesize = Convert.ToInt64(rec[1]);
                            byte[] send = Encoding.ASCII.GetBytes("OK");
                            stream.Write(send, 0, send.Length);
                            break;
                        }
                    }

                    
                    if (stream != null && isStart)
                    {
                        SaveFileDialog sfd = new SaveFileDialog();
                        sfd.FileName = filename;
                        if (sfd.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                        {
                            string fileSavePath = sfd.FileName;//获得用户保存文件的路径
                            writeStream(stream, fileSavePath);
                        }
                    }
                }
                catch (Exception ex)
                {
                    
                    ShwMsgForView.ShwMsgforView(lstbxMsgView, "出现异常：" + ex.Message);
                }
            }
        }
        #endregion

        #region 写文件
        private void writeStream(NetworkStream nstream,string fileSavePath)
        {
            int size = 0;
            long len = 0;
            using (FileStream fs = new FileStream(fileSavePath, FileMode.Create, FileAccess.Write))
            {
                byte[] buffer = new byte[512];
                while ((size = nstream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    fs.Write(buffer, 0, size);
                    len += size;
                    pbState.Value = (int)(len * 100 / filesize);
                    if (len == filesize)
                        break;
                }
                fs.Flush();
                nstream.Flush();
                nstream.Close();
                pbState.Value = 0;
            }
            ShwMsgForView.ShwMsgforView(lstbxMsgView, "文件接受成功" + fileSavePath);
        }
        #endregion

        #region 获取ip
        public List<string> GetLocalIP()
        {
            try
            {
                List<string> ipgroup = new List<string>();

                string HostName = Dns.GetHostName(); //得到主机名
                IPHostEntry IpEntry = Dns.GetHostEntry(HostName);
                for (int i = 0; i < IpEntry.AddressList.Length; i++)
                {
                    //从IP地址列表中筛选出IPv4类型的IP地址
                    //AddressFamily.InterNetwork表示此IP为IPv4,
                    //AddressFamily.InterNetworkV6表示此地址为IPv6类型
                    if (IpEntry.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                    {
                        ipgroup.Add(IpEntry.AddressList[i].ToString());
                    }
                }
                return ipgroup;
            }
            catch (Exception ex)
            {
                MessageBox.Show("获取本机IP出错:" + ex.Message);
                return null;
            }
        }
        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            isStart = false;
            btnCancel.Enabled = !(btnBegin.Enabled = true);
            listener.Stop();
        }
    }
}

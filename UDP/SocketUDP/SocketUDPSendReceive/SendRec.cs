using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketUDPSendReceive
{
    public partial class SendRec : Form
    {
        bool isStart;

        EndPoint LocalPoint = null;
        EndPoint RemotePoint = null;
        Socket SocketUdp = null;

        int LocalPort = 1122;  //远程端口
        int RemotePort = 1111;  //本地端口

        public SendRec()
        {
            InitializeComponent();

            btnSend.Enabled = false;

            IPBox.Items.AddRange(GetLocalIP().ToArray());
            IPBox.SelectedIndex = 1;
        }

        private void btnStartUDP_Click(object sender, EventArgs e)
        {
            isStart = true;

            LocalPort = Convert.ToInt32(tbLocalPort.Text);  //远程端口
            RemotePort = Convert.ToInt32(tbRemotePort.Text);  //本地端口

            btnStartUDP.Enabled = false;
            btnSend.Enabled = true;
            IPBox.Enabled = false;
            tbLocalPort.Enabled = false;
            tbRemotePort.Enabled = false;

            LocalPoint = new IPEndPoint(IPAddress.Parse(IPBox.Text), LocalPort);

            SocketUdp = new Socket(AddressFamily.InterNetwork,SocketType.Dgram,ProtocolType.Udp);
            SocketUdp.Bind(LocalPoint); //本地发送IP 端口
            SocketUdp.SetSocketOption(SocketOptionLevel.Socket,SocketOptionName.Broadcast, 1);

            RemotePoint = new IPEndPoint(IPAddress.Broadcast, RemotePort);  //广播发送

            RecvThread();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            SendBroadcast();
        }

        private void SendBroadcast()
        {
            byte[] sendData = Encoding.ASCII.GetBytes(tbSend.Text);

            SocketUdp.SendTo(sendData, RemotePoint);

        }

        private void RecvThread()
        {
            string receiveString = null;
            byte[] receiveData = new byte[1024];
            EndPoint remotePoint1 = new IPEndPoint(IPAddress.Any, 111);

            Thread a = new Thread(() =>
            {
                while (isStart)
                {
                    try
                    {
                        int len = SocketUdp.ReceiveFrom(receiveData, ref remotePoint1);//接收数据 

                        if (receiveData == null)
                            continue;
                        receiveString = Encoding.ASCII.GetString(receiveData,0,len);
                        this.Invoke(new MethodInvoker(delegate
                        {
                            tbReceive.Text += ((IPEndPoint)remotePoint1).Address + ":" + 
                            ((IPEndPoint)remotePoint1).Port + "," + receiveString + "\r\n";

                            tbReceive.Focus();//获取焦点
                            tbReceive.Select(tbReceive.TextLength, 0);//光标定位到文本最后
                            tbReceive.ScrollToCaret();//滚动到光标处
                        }));
                        //client.Close();
                    }
                    catch
                    { }
                }
            });
            a.Start();
        }


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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                timer1.Enabled = true;
                timer1.Start();
            }
            else
            {
                timer1.Stop();
                timer1.Enabled = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SendBroadcast();
        }

        private void btnStopUdp_Click(object sender, EventArgs e)
        {
            EndUDP();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            EndUDP();
            Application.Exit();
        }

        private void EndUDP()
        {
            try
            {
                isStart = false;
                SocketUdp.Close();
            }
            catch
            { }
        }
    }
}

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

namespace UDPSendReceive
{
    public partial class Form1 : Form
    {
        bool isStart;

        IPEndPoint LocalPoint = null;
        IPEndPoint RemotePoint = null;
        UdpClient clients = null;

        int LocalPort = 1122;  //远程端口
        int RemotePort = 1111;  //本地端口

        public Form1()
        {
            InitializeComponent();

            //IP
            IPBox.Items.AddRange(GetLocalIP().ToArray());
            IPBox.SelectedIndex = 1;

            btnSend.Enabled = false;
        }

        void UIStart(bool bState)
        {
            isStart = bState;
            btnStartUDP.Enabled = !bState;
            btnSend.Enabled = bState;
            IPBox.Enabled = !bState;
            tbLocalPort.Enabled = !bState;
            tbRemotePort.Enabled = !bState;
        }

        private void btnStartUDP_Click(object sender, EventArgs e)
        {
            

            LocalPort = Convert.ToInt32(tbLocalPort.Text);  //远程端口
            RemotePort = Convert.ToInt32(tbRemotePort.Text);  //本地端口

            

            LocalPoint = new IPEndPoint(IPAddress.Parse(IPBox.Text), LocalPort);

            clients = new UdpClient(LocalPoint);  //本地发送IP 端口

            RemotePoint = new IPEndPoint(IPAddress.Broadcast, RemotePort);  //广播发送

            RecvThread();
            UIStart(true);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {

            SendBroadcast();
        }

        private void SendBroadcast()
        {
            byte[] sendData;//= Encoding.ASCII.GetBytes(tbSend.Text);
            sendData = new byte[] {0x03,0x05,0xaa,0x44,0x78,0x26,0x99,0xfa };
            clients.Send(sendData, sendData.Length, RemotePoint);//将数据发送到远程端点 
            //Console.WriteLine("Send Port:" + ((IPEndPoint)client.Client.LocalEndPoint).Port);
            //clients.Close();//关闭连接 
            
        }

        private void RecvThread()
        {

            string receiveString = null;
            byte[] receiveData = null;
            IPEndPoint remotePoint1 = new IPEndPoint(IPAddress.Any ,111);

            Thread a = new Thread(() =>
            {
                while (isStart)
                {
                    try
                    {
                        receiveData = clients.Receive(ref remotePoint1);//接收数据 
                        if (receiveData == null)
                            continue;
                        receiveString = Encoding.ASCII.GetString(receiveData);
                        this.Invoke(new MethodInvoker(delegate
                        {
                            tbReceive.Text += remotePoint1.Address + ":" + remotePoint1.Port + "," + receiveString + "\r\n";
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
            UIStart(false);
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
                clients.Close();
            }
            catch
            { }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

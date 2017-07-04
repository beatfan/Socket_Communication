using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace SocketClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            SocketClient skt = new SocketClient();
            string ip = IP.Text;
            int port = Convert.ToInt32(Port.Text);
            Thread con = new Thread(() =>
                {
                    skt.Connect(ip, port);
                });
            con.Start();
            Thread.Sleep(300);
            skt.SendData(SendData.Text);
                
            Thread.Sleep(30);
            try
            {
                byte[] bs = skt.RecData();
                 label1.Text = Encoding.ASCII.GetString(bs);
            }
            catch(Exception ex)
            {
                label1.Text = "远程设备已经关闭"; 
            }
            skt.StopSocket();
            try
            {
                if (!string.IsNullOrEmpty(SendData.Text))
                    SendData.Text = (Convert.ToInt32(SendData.Text) + 1).ToString();
            }
            catch
            { }

        }
    }
}

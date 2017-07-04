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

namespace TCPClientTest
{
    public partial class TcpShow : Form
    {

        Udp udp = new Udp();
        Tcp tcp = new Tcp();


        public TcpShow()
        {
            InitializeComponent();
            InsertCommandList();

            udp.GetIPof3DP(ref cbRemoteIP);

            UIConnect(false);
            tbFilePath.Enabled = false;
        }

        #region UI关于连接
        void UIConnect(bool isConnected)
        {
            tcp.isConnect = btnSend.Enabled =cbCommanList.Enabled =
                cbState.Enabled = tbValueA.Enabled = tbValueB.Enabled = isConnected;

            btnRefresh.Enabled = cbRemoteIP.Enabled = tbRemotePort.Enabled = !isConnected;

            if (isConnected)
                btnConnect.Text = "disConnect";
            else
                btnConnect.Text = "Connect";
        }
        #endregion

        #region 连接按钮

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            
            udp.GetIPof3DP(ref cbRemoteIP);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            
            tcp.PushTcpDatas = OnGetData;  //委托赋值
            tcp.connect(cbRemoteIP.Text,tbRemotePort.Text);
            UIConnect(true);

        }
        #endregion

        #region 发送按钮
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (tcp.isFileMode)
            {
                if (File.Exists(tbFilePath.Text))
                {
                    tcp.SendFile(tbSend.Text, tbFilePath.Text);
                }
                else
                    tbFilePath.Text = "File is not exist";
            }
            else
                tcp.SendData(tbSend.Text);

        }
        #endregion

        /// <summary>
        /// 异步接收tcp到数据
        /// </summary>
        /// <param name="data"></param>
        private void OnGetData(byte[] data)
        {
            string sdata = Encoding.ASCII.GetString(data);

            this.Invoke(new MethodInvoker(delegate {
                tbReceive.Text = sdata;
            }));
        }


        #region 命令列表

        private void InsertCommandList()
        {
            string[] commands = new string[]
            {
                "PRS","PPA","FET","EET","LWT" ,"EDD","ZAR" ,"MUS" ,"MDS" ,"SIX" ,"SIY" ,"PFN" ,"PFS" ,"PFD" ,"PFC" ,"PLF" ,"GTL" ,"GPL"
            };
            cbCommanList.Items.AddRange(commands);
            cbCommanList.SelectedIndex = 0;
            cbState.SelectedIndex = 0;
        }
        

        private void cbCommanList_SelectedIndexChanged(object sender, EventArgs e)
        {
            commandChange();
        }

        private void cbState_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(cbState.Text.ToLower())
            {
                case "get":
                    tbValueA.Text = " ?";
                    tbValueB.Text = "";
                    tbValueB.Visible = false;
                    break;

                case "set":
                    tbValueA.Text = " = ";
                    tbValueB.Text = "";
                    tbValueB.Visible = true;
                    break;

                case "sendfile":
                    tbValueA.Text = " = ";
                    tbValueB.Text = "1";
                    tbValueB.Visible = true;
                    break;

                default:
                    break;

            }


            commandChange();
        }

        private void tbValueA_TextChanged(object sender, EventArgs e)
        {

            commandChange();
        }

        private void tbValueB_TextChanged(object sender, EventArgs e)
        {
            commandChange();
        }

        private void commandChange()
        {
            if (cbCommanList.Text == "PFD" && cbState.Text == "SendFile")
                tcp.isFileMode=tbFilePath.Enabled = true;

            tbSend.Text = cbCommanList.Text + tbValueA.Text+tbValueB.Text;
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
    }

}

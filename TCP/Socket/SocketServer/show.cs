using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;

namespace Scan_Gun
{
    public partial class show : Form
    {
        public show()
        {
            InitializeComponent();
        }

        #region<启动加载>
        Thread CheckNet; //检查联网线程
        private void show_Load(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;

            try
            {
                CommonData.Write2File("192.168.10.180,12345", CommonData.ServerIPpath);
                List<string> str1 = CommonData.GetStringFromFile(CommonData.ServerIPpath);  //获取IP和端口
                CommonData.serverIP = str1[0].Split(',')[0];
                CommonData.serverPort = int.Parse(str1[0].Split(',')[1]);

                CommonData.Write2File("http://192.168.10.180/webservice/MeasurationMgr.asmx", CommonData.WebServicepath);
                List<string> str2 = CommonData.GetStringFromFile(CommonData.WebServicepath);  //获取数据库以及WebService地址
                CommonData.WebServiceaddress = str2[0];
            }
            catch(Exception ex)
            {
                MessageBox.Show("write"+ex.ToString());
            }

            if (!CheckNetwork())
            {
                return;
            }

            if (!CheckArea())
            {
                closeform();
                return;
            }

            label1.Text = CommonData.localIP + " " + CommonData.Area;


            //barcode21.EnableScanner = true;

            SocketServerListen.SocketListen(CommonData.localIP, CommonData.ListenPort);  //Socket监听远程设备的更改
            test.delecheckSet = ListenRec;

            CheckNet = new Thread(Thread_Chknet);
            CheckNet.IsBackground = true;
            CheckNet.Start();
        }
        #endregion

        #region<检查配置区域>
        /// <summary>
        /// 检查配置区域
        /// </summary>
        /// <returns></returns>
        public Boolean CheckArea()
        {
            //查看是否已经配置
            Check ck = new Check();
            if (!ck.CheckIP())
            {
                if (MessageBox.Show("设备未联网") == DialogResult.OK)
                {
                    closeform();
                    return false;
                }

            }

            //检查配置区域
            switch (ck.checkSet())
            {
                case CommonData.CherckErrors.WebServiceError:
                    if (MessageBox.Show("WebService地址错误") == DialogResult.OK)
                    {
                        closeform();
                        return false;
                    }
                    break;
                case CommonData.CherckErrors.SqlAddrError:
                    if (MessageBox.Show("Sql地址错误") == DialogResult.OK)
                    {
                        closeform();
                        return false;
                    }
                    break;
                case CommonData.CherckErrors.NoDevice:
                    if (MessageBox.Show("数据库无扫描枪") == DialogResult.OK)
                    {
                        closeform();
                        return false;
                    }
                    break;
                case CommonData.CherckErrors.DevRemove:
                    if (MessageBox.Show("本设备被移除") == DialogResult.OK)
                    {
                        closeform();
                        return false;
                    }
                    break;
                default:
                    return true;
                    break;

            }

            return true;
        }

        #endregion

        #region<检查联网状态>
        /// <summary>
        /// 检查网络
        /// </summary>
        /// <returns></returns>
        public Boolean CheckNetwork()
        {
            //查看是否已经配置
            Check ck = new Check();
            if (!ck.CheckIP())
            {
                if (MessageBox.Show("设备未联网") == DialogResult.OK)
                {
                    closeform();
                    return false;
                }

            }
            return true;
        }

        /// <summary>
        /// 检查网络线程
        /// </summary>
        public void Thread_Chknet()
        {
            while (CommonData.ListeningFlag)
            {
                try
                {
                    Thread.Sleep(1000);
                    CheckNetwork();
                }
                catch { }
            }
        }
        #endregion

        #region<接收到Socket动态>
        /// <summary>
        /// Socket 监听到之后触发
        /// </summary>
        /// <param name="message"></param>
        delegate void Invok(string se);
        
        public void ListenRec(string message)
        {
            
            Invok voke = new Invok(dlgshow);
            this.Invoke(voke, message);
            CheckArea();
        }

        public void dlgshow(string me)
        {
            statue.Text = "Remote Send: " + me + ",Check Device Start!";
        }
        #endregion

        #region< 关闭窗体函数>
        delegate void CloseInvok();

        public void closeform()
        {
            try
            {
                CloseInvok CloseInvoks = new CloseInvok(closeformInvoke);
                this.Invoke(CloseInvoks);
            }
            catch
            { }
        }
        private void closeformInvoke()
        {

            try
            {
                CommonData.ListeningFlag = false;
                SocketServerListen.StopListen();
            }
            catch (Exception ex1)
            { MessageBox.Show("1:\r\n" + ex1.ToString()); }
            Thread.Sleep(500);

            try
            {
                this.Close();
            }
            catch (Exception ex3)
            { MessageBox.Show("2:\r\n" + ex3.ToString()); }


        }
        #endregion


        private void show_FormClosing(object sender, FormClosingEventArgs e)
        {
            CommonData.ListeningFlag = false;
            SocketServerListen.StopListen();
        }


    }
}

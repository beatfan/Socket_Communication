using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCPClientTest
{
    public class ClassGetIP
    {
        #region 获取ip
        public static List<string> GetLocalIP()
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
                //MessageBox.Show("获取本机IP出错:" + ex.Message);
                return null;
            }
        }
        #endregion
    }
}

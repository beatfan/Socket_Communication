using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Net;

namespace Scan_Gun
{
    public static class CommonData
    {
        /// <summary>
        /// 本地可用IP
        /// </summary>
        public static string localIP;
        /// <summary>
        /// 配置区域
        /// </summary>
        public static string Area;  //配置区域

        /// <summary>
        /// IVS socket 远程端口 文件地址
        /// </summary>
        //public static string ServerIPpath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase.ToString()) + "\\" + "Server.txt";
        public static string ServerIPpath = Directory.GetCurrentDirectory() + "\\" + "Server.txt";
        /// <summary>
        /// 数据库地址以及WebService地址存放文件的地址
        /// </summary>
        //public static string WebServicepath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase.ToString()) + "\\" + "WebServiceAddress.txt";
        public static string WebServicepath = Directory.GetCurrentDirectory() + "\\" + "WebServiceAddress.txt";

        /// <summary>
        /// socket 远程 IP
        /// </summary>
        public static string serverIP = string.Empty;
        /// <summary>
        /// Socket 远程 Port
        /// </summary>
        public static int serverPort = 0;
        /// <summary>
        /// WebService地址
        /// </summary>
        public static string WebServiceaddress;  //WebService地址

        /// <summary>
        /// 本地监听端口，用于远程设备通知本机进行检查
        /// </summary>
        public static int ListenPort = 45678;

        /// <summary>
        /// 监听状态
        /// </summary>
        public static Boolean ListeningFlag = true;

        #region<检查错误枚举>
        /// <summary>
        /// 检查的错误类型枚举
        /// </summary>
        public enum CherckErrors
        {
            /// <summary>
            /// 数据库地址错误
            /// </summary>
            SqlAddrError,
            /// <summary>
            /// 没有任何设备
            /// </summary>
            NoDevice,
            /// <summary>
            /// WebService地址错误
            /// </summary>
            WebServiceError,
            /// <summary>
            /// 本设备被移除
            /// </summary>
            DevRemove,
            /// <summary>
            /// 一切正常
            /// </summary>
            AllRight
        };
        #endregion

        #region<从文件中获取字符串>
        /// <summary>
        /// 从文件中获取字符串
        /// </summary>
        /// <param name="path1"></param>
        /// <returns></returns>
        public static List<string> GetStringFromFile(string path1)
        {
            try
            {
                List<string> slist = new List<string>();
                if (File.Exists(path1))
                {
                    //获取IP和Port
                    using (StreamReader objReader = new StreamReader(path1, Encoding.ASCII))
                    {
                        string str = string.Empty;

                        while (!string.IsNullOrEmpty(str = objReader.ReadLine()))
                        {
                            slist.Add(str);
                        }
                        objReader.Close();
                    }
                }
                else
                    return null;
                return slist;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region<查看文件是否存在，不存在则写入>
        /// <summary>
        /// 查看文件是否存在，不存在则写入
        /// </summary>
        /// <param name="str"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Boolean Write2File(string str, string path)
        {
            try
            {
                if (!File.Exists(path))  //判断文件是否存在
                {
                    //创建配置文件
                    using (StreamWriter sw = new StreamWriter(path))
                    {
                        sw.WriteLine(str);
                        sw.Close();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}

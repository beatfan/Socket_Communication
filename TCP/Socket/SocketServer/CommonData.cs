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
        /// ���ؿ���IP
        /// </summary>
        public static string localIP;
        /// <summary>
        /// ��������
        /// </summary>
        public static string Area;  //��������

        /// <summary>
        /// IVS socket Զ�̶˿� �ļ���ַ
        /// </summary>
        //public static string ServerIPpath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase.ToString()) + "\\" + "Server.txt";
        public static string ServerIPpath = Directory.GetCurrentDirectory() + "\\" + "Server.txt";
        /// <summary>
        /// ���ݿ��ַ�Լ�WebService��ַ����ļ��ĵ�ַ
        /// </summary>
        //public static string WebServicepath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase.ToString()) + "\\" + "WebServiceAddress.txt";
        public static string WebServicepath = Directory.GetCurrentDirectory() + "\\" + "WebServiceAddress.txt";

        /// <summary>
        /// socket Զ�� IP
        /// </summary>
        public static string serverIP = string.Empty;
        /// <summary>
        /// Socket Զ�� Port
        /// </summary>
        public static int serverPort = 0;
        /// <summary>
        /// WebService��ַ
        /// </summary>
        public static string WebServiceaddress;  //WebService��ַ

        /// <summary>
        /// ���ؼ����˿ڣ�����Զ���豸֪ͨ�������м��
        /// </summary>
        public static int ListenPort = 45678;

        /// <summary>
        /// ����״̬
        /// </summary>
        public static Boolean ListeningFlag = true;

        #region<������ö��>
        /// <summary>
        /// ���Ĵ�������ö��
        /// </summary>
        public enum CherckErrors
        {
            /// <summary>
            /// ���ݿ��ַ����
            /// </summary>
            SqlAddrError,
            /// <summary>
            /// û���κ��豸
            /// </summary>
            NoDevice,
            /// <summary>
            /// WebService��ַ����
            /// </summary>
            WebServiceError,
            /// <summary>
            /// ���豸���Ƴ�
            /// </summary>
            DevRemove,
            /// <summary>
            /// һ������
            /// </summary>
            AllRight
        };
        #endregion

        #region<���ļ��л�ȡ�ַ���>
        /// <summary>
        /// ���ļ��л�ȡ�ַ���
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
                    //��ȡIP��Port
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

        #region<�鿴�ļ��Ƿ���ڣ���������д��>
        /// <summary>
        /// �鿴�ļ��Ƿ���ڣ���������д��
        /// </summary>
        /// <param name="str"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Boolean Write2File(string str, string path)
        {
            try
            {
                if (!File.Exists(path))  //�ж��ļ��Ƿ����
                {
                    //���������ļ�
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

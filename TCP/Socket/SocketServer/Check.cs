using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Scan_Gun.pd;
using System.Net;

namespace Scan_Gun
{
    /// <summary>
    /// ����Ƿ����� & ���� ��
    /// </summary>
    public class Check
    {
        #region<�鿴�Ƿ��Ѿ����ã����õ��ĸ�����>
        /// <summary>
        /// ��� �Ƿ����� & ���õ��ĸ�������ҪCommonData.strConnect,CommonData.WebServiceaddress,CommonData.ips_Local �����úõ�ǰ����IP�Լ����� �� CommonData.localIp,  CommonData.Area
        /// </summary>
        /// <returns></returns>
        public CommonData.CherckErrors checkSet()
        {

            //�鿴���豸�Ƿ��Ѿ�������

            DataSet ds = new DataSet();

            try
            {
                using ( MeasurationMgr mm = new MeasurationMgr())
                {
                    string strCommand = "select a.str_DeviceIP,c.str_AreaNameSimplify from C_DeviceInfo a right join C_AreaDevConfig b on a.int_DeviceIndex=b.int_DeviceIndex left join C_AreaInfo c on b.int_AreaNO=c.int_AreaNO where a.int_Category = '2'  order by a.str_DeviceIP";
                    mm.Url = CommonData.WebServiceaddress;
                    ds = mm.Scanlist(strCommand);
                    mm.Dispose();
                }
            }
            catch
            { return CommonData.CherckErrors.WebServiceError; }  //WebService��ַ����

            if (ds == null)
                return CommonData.CherckErrors.SqlAddrError;   //���ݿ����Ӵ���


            if (ds.Tables[0].Rows.Count < 1)  //û�л�ȡ���豸
                return CommonData.CherckErrors.NoDevice;  //û���豸

            Boolean isSqlExistThisScanGun = false;  //�Ƿ��Ѿ�����
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                if (ds.Tables[0].Rows[i][0].ToString() == CommonData.localIP)  //�豸�����
                {
                    CommonData.Area = ds.Tables[0].Rows[i][1].ToString();   //��������
                    isSqlExistThisScanGun = true;
                    break;
                }

            }


            if (!isSqlExistThisScanGun)  //���豸δ���
                return CommonData.CherckErrors.DevRemove;  //�豸���Ƴ�

            return CommonData.CherckErrors.AllRight;  //һ������

        }
        #endregion

        #region<����豸�Ƿ�����������ȡIP>
        /// <summary>
        /// ����豸�Ƿ�����������ȡIP
        /// </summary>
        /// <returns></returns>
        public Boolean CheckIP()
        {
            //ȡ����IP�б� 
            IPAddress[] ips_Local = Dns.GetHostEntry(Dns.GetHostName()).AddressList;

            //��ʾ����IP
            foreach (IPAddress v in ips_Local)
            {
                CommonData.localIP = v.ToString();
            }
            if (CommonData.localIP == "127.0.0.1")  //δ��ȡ��IP
                return false;
            else
                return true;
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Scan_Gun.pd;
using System.Net;

namespace Scan_Gun
{
    /// <summary>
    /// 检测是否配置 & 联网 等
    /// </summary>
    public class Check
    {
        #region<查看是否已经配置，配置到哪个区域>
        /// <summary>
        /// 检查 是否配置 & 配置到哪个区域，需要CommonData.strConnect,CommonData.WebServiceaddress,CommonData.ips_Local 并配置好当前可用IP以及区域 ， CommonData.localIp,  CommonData.Area
        /// </summary>
        /// <returns></returns>
        public CommonData.CherckErrors checkSet()
        {

            //查看此设备是否已经被配置

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
            { return CommonData.CherckErrors.WebServiceError; }  //WebService地址错误

            if (ds == null)
                return CommonData.CherckErrors.SqlAddrError;   //数据库连接错误


            if (ds.Tables[0].Rows.Count < 1)  //没有获取到设备
                return CommonData.CherckErrors.NoDevice;  //没有设备

            Boolean isSqlExistThisScanGun = false;  //是否已经配置
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                if (ds.Tables[0].Rows[i][0].ToString() == CommonData.localIP)  //设备已添加
                {
                    CommonData.Area = ds.Tables[0].Rows[i][1].ToString();   //配置区域
                    isSqlExistThisScanGun = true;
                    break;
                }

            }


            if (!isSqlExistThisScanGun)  //此设备未添加
                return CommonData.CherckErrors.DevRemove;  //设备被移除

            return CommonData.CherckErrors.AllRight;  //一切正常

        }
        #endregion

        #region<检查设备是否联网，并获取IP>
        /// <summary>
        /// 检查设备是否联网，并获取IP
        /// </summary>
        /// <returns></returns>
        public Boolean CheckIP()
        {
            //取本机IP列表 
            IPAddress[] ips_Local = Dns.GetHostEntry(Dns.GetHostName()).AddressList;

            //显示本机IP
            foreach (IPAddress v in ips_Local)
            {
                CommonData.localIP = v.ToString();
            }
            if (CommonData.localIP == "127.0.0.1")  //未获取到IP
                return false;
            else
                return true;
        }
        #endregion
    }
}

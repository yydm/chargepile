using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using ChargingPile.BLL;
using System.Data;
using ChargingPile.Model;
using ChargingPile.UI.WEB.Common;
using System.Web.SessionState;
using System.Data.OleDb;
using System.IO;
using Newtonsoft.Json;
namespace ChargingPile.UI.WEB.WebService
{
    /// <summary>
    /// RequestHandling 的摘要说明
    /// </summary>
    public class RequestHandling : IHttpHandler, IRequiresSessionState
    {
        protected log4net.ILog Log = log4net.LogManager.GetLogger("ChargPileCollectionManage");
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request["action"];
            if (string.IsNullOrEmpty(action))
            {
                return;
            }
            if (action.Equals("getListQuery"))
            {
                GetListQuery(context);
            }
            if (action.Equals("getListTotal"))
            {
                GetListTotal(context);
            }
            if (action.Equals("getChargStation"))
            {
                GetChargStation(context);
            }
            if (action.Equals("CardTotalOutExcel"))
            {
                CardTotalOutExcel(context);
            }
            if (action.Equals("CardQueryOutExcel"))
            {
                CardQueryOutExcel(context);
            }
            if (action.Equals("setView"))
            {
                SetView(context);
            }
            if(action.Equals("getPileLockQuery"))
            {
                GetPileLockQuery(context);
            }
            if (action.Equals("PileLockQueryOutExcel"))
            {
                PileLockQueryOutExcel(context);
            }
            if (action.Equals("getPileTelemetryQuery"))
            {
                GetPileTelemetryQuery(context);
            }
            if (action.Equals("PileTelemetryQueryOutExcel"))
            {
                PileTelemetryQueryOutExcel(context);
            }
            if (action.Equals("gisAdd"))
            {
                GisFunction(context, "gisAdd");
            }
            if (action.Equals("gisDelete"))
            {
                GisFunction(context, "gisDelete");
            }
        }
        /// <summary>
        ///充电站GIS地图上标住
        /// </summary>
        /// <param name="context"></param>
        public void GisFunction(HttpContext context,string strSort)
        {
            string strMsg = "{\"success\":false,\"msg\":\"标注失败！\"}";
            string zhanbh = context.Request["zhanbh"].ToString();
            if (zhanbh != "")
            {
                ChargStationBll cdzBll = new ChargStationBll();
                DataTable tb=cdzBll.GetstationByid(decimal.Parse(zhanbh));
                if (tb.Rows.Count > 0)
                {
                    
                    //充电站编号
                    string ZHAN_BH = tb.Rows[0]["ZHAN_BH"].ToString();
                    //充电点名称
                    string ZHUAN_MC = tb.Rows[0]["ZHUAN_MC"].ToString();
                    //场地业主单位
                    string YEZHU_DW = tb.Rows[0]["YEZHU_DW"].ToString();
                    //联系人
                    string LIANXI_R = tb.Rows[0]["LIANXI_R"].ToString();
                    //联系电话
                    string LIANXI_DH = tb.Rows[0]["LIANXI_DH"].ToString();
                    //桩类型
                    string ZHUANGLEI_X = tb.Rows[0]["ZHUANGLEI_X"].ToString();
                    //桩厂家
                    string ZHUANGCHANG_J = tb.Rows[0]["ZHUANGCHANG_J"].ToString();
                    //详细地址
                    string XIANGXI_DZ = tb.Rows[0]["XIANGXI_DZ"].ToString();
                    //经度坐标
                    string LONGTUDE = tb.Rows[0]["LONGTUDE"].ToString();
                    //维度坐标
                    string LATITUDE = tb.Rows[0]["LATITUDE"].ToString();
                    //创建时间
                    string CREATEDT = tb.Rows[0]["CREATEDT"].ToString();
                    //更新时间
                    string UPDATEDT = tb.Rows[0]["UPDATEDT"].ToString();

                    //整合JSON
                    string gisJson = "{";
                    gisJson += "\"ZHAN_BH\":\"" + ZHAN_BH + "\",";
                    gisJson += "\"ZHUAN_MC\":\"" + ZHUAN_MC + "\",";
                    gisJson += "\"YEZHU_DW\":\"" + YEZHU_DW + "\",";
                    gisJson += "\"LIANXI_R\":\"" + LIANXI_R + "\",";
                    gisJson += "\"LIANXI_DH\":\"" + LIANXI_DH + "\",";
                    gisJson += "\"ZHUANGLEIX\":\"" + ZHUANGLEI_X + "\",";
                    gisJson += "\"ZHUANGCJ\":\"" + ZHUANGCHANG_J + "\",";
                    gisJson += "\"XIANGXI_DZ\":\"" + XIANGXI_DZ + "\",";
                    gisJson += "\"LONGTUDE\":\"" + LONGTUDE + "\",";
                    gisJson += "\"LATITUDE\":\"" + LATITUDE + "\",";

                    gisJson += "\"CREATEDT\":\"\",";
                    gisJson += "\"UPDATEDT\":\"\"";

                    //gisJson += "\"CREATEDT\":\"" + CREATEDT + "\",";
                    //gisJson += "\"UPDATEDT\":\"" + UPDATEDT+"\"";
                    gisJson += "}";
                    try
                    {
                        CdzWebService.CDZWebServiceClient objGis = new CdzWebService.CDZWebServiceClient();
                        if (strSort == "gisAdd")
                        {
                            objGis.DeleteCDZ(gisJson);
                            string result = objGis.InsertIntoCDZ(gisJson);
                            if (result == "OK")
                            {
                                strMsg = "{\"success\":true,\"msg\":\"标注成功！\"}";
                            }
                        }
                        else if (strSort == "gisDelete")
                        {
                            if (objGis.DeleteCDZ(gisJson) == "OK")
                            {
                                strMsg = "{\"success\":true,\"msg\":\"删除成功！\"}";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        strMsg = "{\"success\":false,\"msg\":\"操作出现异常！\"}";
                    }
                }
            }
            context.Response.Write(strMsg);
            
        }
        /// <summary>
        ///获取死锁的充电桩数据
        /// </summary>
        /// <param name="context"></param>
        public void GetPileLockQuery(HttpContext context)
        {
            try
            {
                int page = 1, rows =10, total = 0;
                string tmp = context.Request["page"].ToString();
                if (!string.IsNullOrEmpty(tmp))
                {
                    page = int.Parse(tmp);
                }
                tmp = context.Request["rows"].ToString();
                if (!string.IsNullOrEmpty(tmp))
                {
                    rows = int.Parse(tmp);
                }

                string strUrl = CodeAnywhere.Util.Platframework.Current.ReadCfg("url", "http://wl715.mooo.com:90/PowerpileService/rpc/JsonRpcService.rpc");
                RequestHandling_BLL gdrBll = new RequestHandling_BLL();
                DataTable dt = gdrBll.GetPileLockQuery(page, rows, ref total, strUrl);
                string strJson = JSonHandle.ToJson(dt, total, "yyyy-MM-dd");
                context.Response.Write(strJson);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
        /// <summary>
        ///获取遥测明细数据
        /// </summary>
        /// <param name="context"></param>
        public void GetPileTelemetryQuery(HttpContext context)
        {
            try
            {
                int page = 1, rows = 10, total = 0;
                string tmp = context.Request["page"].ToString();
                if (!string.IsNullOrEmpty(tmp))
                {
                    page = int.Parse(tmp);
                }
                tmp = context.Request["rows"].ToString();
                if (!string.IsNullOrEmpty(tmp))
                {
                    rows = int.Parse(tmp);
                }
                string pileno = context.Request["pileno"].ToString();
                DateTime sdt = new DateTime();
                string sj = context.Request["sdt"] ?? "";
                if (sj.Length > 0)
                {
                    sdt = DateTime.Parse(sj);
                }
                DateTime edt = new DateTime();
                string ej = context.Request["edt"] ?? "";
                if (ej.Length > 0)
                {
                    edt = DateTime.Parse(ej);
                }
                string itemname = context.Request["itemname"].ToString();
                string strUrl = CodeAnywhere.Util.Platframework.Current.ReadCfg("url", "http://wl715.mooo.com:90/PowerpileService/rpc/JsonRpcService.rpc");
                RequestHandling_BLL gdrBll = new RequestHandling_BLL();
                DataTable dt = gdrBll.GetPileTelemetryQuery(pileno,sdt,edt,itemname, page, rows, ref total, strUrl);

                string strJson = JSonHandle.ToJson(dt, total, "yyyy-MM-dd HH:mm:ss");
                context.Response.Write(strJson);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        } 
        /// <summary>
        ///死锁的充电桩数据导出Excel
        /// </summary>
        /// <param name="context"></param>
        public void PileLockQueryOutExcel(HttpContext context)
        {
            try
            {
                string strUrl = CodeAnywhere.Util.Platframework.Current.ReadCfg("url", "http://wl715.mooo.com:90/PowerpileService/rpc/JsonRpcService.rpc");
                RequestHandling_BLL gdrBll = new RequestHandling_BLL();
                DataTable dt = gdrBll.PileLockQueryOutExcel(strUrl);
                if (dt.Rows.Count > 0)
                {
                    DataTableExcel(context, dt, "查询导出" + DateTime.Now.ToString("yyyy年MM月dd日HH时mm分ss秒"));
                }
                else
                {
                    context.Response.Write("<script type='javascript'>alert('当前没有数据要导出！');<script>");
                }
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
        /// <summary>
        ///遥测明细数据导出Excel
        /// </summary>
        /// <param name="context"></param>
        public void PileTelemetryQueryOutExcel(HttpContext context)
        {
            try
            {
                string pileno = context.Request["pileno"].ToString();
                DateTime sdt = new DateTime();
                string sj = context.Request["sdt"] ?? "";
                if (sj.Length > 0)
                {
                    sdt = DateTime.Parse(sj);
                }
                DateTime edt = new DateTime();
                string ej = context.Request["edt"] ?? "";
                if (ej.Length > 0)
                {
                    edt = DateTime.Parse(ej);
                }
                string itemname = context.Request["itemname"].ToString();
                string strUrl = CodeAnywhere.Util.Platframework.Current.ReadCfg("url", "http://wl715.mooo.com:90/PowerpileService/rpc/JsonRpcService.rpc");
                RequestHandling_BLL gdrBll = new RequestHandling_BLL();
                DataTable dt = gdrBll.PileTelemetryQueryOutExcel(pileno, sdt, edt, itemname, strUrl);
                if (dt.Rows.Count > 0)
                {
                    DataTableExcel(context, dt, "查询导出" + DateTime.Now.ToString("yyyy年MM月dd日HH时mm分ss秒"));
                }
                else
                {
                    context.Response.Write("<script type='javascript'>alert('当前没有数据要导出！');<script>");
                }
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
        /// <summary>
        ///设置监视配置点
        /// </summary>
        /// <param name="context"></param>
        public void SetView(HttpContext context)
        {
            int zhanid = int.Parse(context.Request["zhanid"]);
            int sort = int.Parse(context.Request["sort"]);
            RequestHandling_BLL gdrBll = new RequestHandling_BLL();
            int intCt = gdrBll.SetView(zhanid, sort);
            if (intCt > 0)
            {
                context.Response.Write("{\"success\":true,\"msg\":\"设置成功！\"}");
            }
            else
            {
                context.Response.Write("{\"success\":false,\"msg\":\"设置失败！\"}");
            }

        }
        /// <summary>
        /// 充电卡统计数据导出Excel
        /// </summary>
        /// <param name="context"></param>
        private void CardTotalOutExcel(HttpContext context)
        {
            try
            {
                string zhanid = context.Request["zhanid"].ToString();
                DateTime sdt = new DateTime();
                string sj = context.Request["sdt"] ?? "";
                if (sj.Length > 0)
                {
                    sdt = DateTime.Parse(sj);
                }
                DateTime edt = new DateTime();
                string ej = context.Request["edt"] ?? "";
                if (ej.Length > 0)
                {
                    edt = DateTime.Parse(ej).AddDays(1);
                }
                RequestHandling_BLL gdrBll = new RequestHandling_BLL();
                DataTable dt = gdrBll.CardTotalOutExcel(zhanid, sdt, edt);
                if (dt.Rows.Count > 0)
                {
                    DataTableExcel(context,dt, "查询导出" + DateTime.Now.ToString("yyyy年MM月dd日HH时mm分ss秒"));
                }
                else
                {
                    context.Response.Write("<script type='javascript'>alert('当前没有数据要导出！');<script>");
                }
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
        /// <summary>
        /// 充电卡明细查询数据导出Excel
        /// </summary>
        /// <param name="context"></param>
        private void CardQueryOutExcel(HttpContext context)
        {
            try
            {
                string cardno = context.Request["cardno"].ToString();
                DateTime sdt = new DateTime();
                string sj = context.Request["sdt"] ?? "";
                if (sj.Length > 0)
                {
                    sdt = DateTime.Parse(sj);
                }
                DateTime edt = new DateTime();
                string ej = context.Request["edt"] ?? "";
                if (ej.Length > 0)
                {
                    edt = DateTime.Parse(ej).AddDays(1);
                }
                string zhanid = "";
                try
                {
                    zhanid = context.Request["zhanid"].ToString();
                }
                catch (Exception ex)
                {
                    zhanid = "";
                }
                RequestHandling_BLL gdrBll = new RequestHandling_BLL();
                DataTable dt = gdrBll.CardQueryOutExcel(cardno, sdt, edt,zhanid);
                if (dt.Rows.Count > 0)
                {
                    DataTableExcel(context,dt, "查询导出" + DateTime.Now.ToString("yyyy年MM月dd日HH时mm分ss秒"));
                }
                else
                {
                    context.Response.Write("<script type='javascript'>alert('当前没有数据要导出！');<script>");
                }
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
        /// <summary>
        /// 充电卡明细记录查询
        /// </summary>
        /// <param name="context"></param>
        private void GetListQuery(HttpContext context)
        {
            try
            {
                int page = 1, rows = 10, total = 0;
                string tmp = context.Request["page"].ToString();
                if (!string.IsNullOrEmpty(tmp))
                {
                    page = int.Parse(tmp);
                }
                tmp = context.Request["rows"].ToString();
                if (!string.IsNullOrEmpty(tmp))
                {
                    rows = int.Parse(tmp);
                }

                string cardno = context.Request["cardno"].ToString();
                DateTime sdt = new DateTime();
                string sj = context.Request["sdt"] ?? "";
                if (sj.Length > 0)
                {
                    sdt = DateTime.Parse(sj);
                }
                DateTime edt = new DateTime();
                string ej = context.Request["edt"] ?? "";
                if (ej.Length > 0)
                {
                    edt = DateTime.Parse(ej).AddDays(1);
                }
                string zhanid = "";
                try { 
                    zhanid = context.Request["zhanid"].ToString(); 
                }
                catch (Exception ex) 
                { 
                    zhanid = ""; 
                }
                RequestHandling_BLL gdrBll = new RequestHandling_BLL();
                DataTable dt = gdrBll.GetDataTableQuery(cardno, sdt, edt,zhanid, page, rows, ref total);

                //List<GatDataRecord> list = ConvertHelper<GatDataRecord>.ConvertToList(dt);
                //PageObject<GatDataRecord> pageO = new PageObject<GatDataRecord>();
                //pageO.total = list.Count;
                //pageO.rows = list;
                //var strJson = jss.Serialize(pageO);

                string strJson = JSonHandle.ToJson(dt, total, "yyyy-MM-dd HH:mm");
                

                context.Response.Write(strJson);


            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
        /// <summary>
        /// 充电卡数据汇总
        /// </summary>
        /// <param name="context"></param>
        private void GetListTotal(HttpContext context)
        {
            try
            {
                int page = 1, rows = 10, total = 0;
                string tmp = context.Request["page"].ToString();
                if (!string.IsNullOrEmpty(tmp))
                {
                    page = int.Parse(tmp);
                }
                tmp = context.Request["rows"].ToString();
                if (!string.IsNullOrEmpty(tmp))
                {
                    rows = int.Parse(tmp);
                }

                string zhanid = context.Request["zhanid"].ToString();
                DateTime sdt = new DateTime();
                string sj = context.Request["sdt"] ?? "";
                if (sj.Length > 0)
                {
                    sdt = DateTime.Parse(sj);
                }
                DateTime edt = new DateTime();
                string ej = context.Request["edt"] ?? "";
                if (ej.Length > 0)
                {
                    edt = DateTime.Parse(ej).AddDays(1);
                }
                RequestHandling_BLL gdrBll = new RequestHandling_BLL();
                DataTable dt = gdrBll.GetDataTableTotal(zhanid, sdt, edt, page, rows, ref total);
                string strJson = JSonHandle.ToJson(dt, total, "yyyy-MM-dd");
                context.Response.Write(strJson);



            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }

        /// <summary>
        /// 获取充电站
        /// </summary>
        /// <param name="context"></param>
        private void GetChargStation(HttpContext context)
        {

                try
                {
                    int page = 1, rows = 10, total = 0;
                    string tmp = context.Request["page"].ToString();
                    if (!string.IsNullOrEmpty(tmp))
                    {
                        page = int.Parse(tmp);
                    }
                    tmp = context.Request["rows"].ToString();
                    if (!string.IsNullOrEmpty(tmp))
                    {
                        rows = int.Parse(tmp);
                    }
                    RequestHandling_BLL gdrBll = new RequestHandling_BLL();
                    DataTable dt = gdrBll.GetChargStationQuery(page, rows, ref total);
                    string strJson = JSonHandle.ToJson(dt, total, "yyyy-MM-dd");
                    context.Response.Write(strJson);


                }
                catch (Exception e)
                {
                    Log.Error(e);
                }

        }
        private static void DataTableExcel(HttpContext Context,DataTable dtData, String FileName)
        {
            //获取当前参数对象
            //System.Web.HttpContext curContext = System.Web.HttpContext.Current;
            if (dtData != null)
            {
                //临时存放路径
                string strTo = System.Web.HttpContext.Current.Server.MapPath("~/WebService/") + FileName + ".xls";
                //将DataTable写入到Excel文件(临时存放路径)
                OutExcel.DataTableToExcel(strTo, dtData, "数据");
                //读取
                FileStream MyFileStream = new FileStream(strTo, FileMode.Open);
                long FileSize = MyFileStream.Length;
                byte[] Buffer = new byte[(int)FileSize];
                MyFileStream.Read(Buffer, 0, (int)FileSize);
                MyFileStream.Close();
                //删除临时存放路径
                if (File.Exists(strTo) == true)
                {
                    File.Delete(strTo);
                }
                //流输出excel
                Context.Response.AddHeader("content-disposition", "attachment;filename=" + System.Web.HttpUtility.UrlEncode(FileName, System.Text.Encoding.UTF8) + ".xls");
                Context.Response.ContentType = "application nd.ms-excel";
                Context.Response.ContentEncoding = System.Text.Encoding.Default;
                Context.Response.Charset = "UTF-8";
                Context.Response.BinaryWrite(Buffer);
                Context.Response.Flush();
                Context.Response.Close();
                Context.Response.End();

            }
            else
            {
                Context.Response.Write("导出错误！");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
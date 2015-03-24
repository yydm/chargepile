using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using ChargingPile.BLL;
using ChargingPile.Model;
using ChargingPile.UI.WEB.Common;

namespace ChargingPile.UI.WEB.WebService
{
    /// <summary>
    /// ChargRecordService 的摘要说明
    /// </summary>
    public class ChargRecordService : IHttpHandler
    {

        protected log4net.ILog Log = log4net.LogManager.GetLogger("ChargRecordService");
        JavaScriptSerializer jss = new JavaScriptSerializer();
        ChargRecordBll crbll = new ChargRecordBll();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request["action"];
            if (string.IsNullOrEmpty(action))
            {
                return;
            }
            if (action.Equals("getcdjl"))
            {
                GetCdjl(context);
            }
            else if (action.Equals("getyspm"))
            {
                GetSypm(context);
            }
            else if (action.Equals("getcdtj"))
            {
                GetCdtj(context);
            }
        }
        /// <summary>
        /// 获取充电桩使用排名
        /// </summary>
        /// <param name="context"></param>
        private void GetSypm(HttpContext context)
        {
            try
            {
                //获取分页数据
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

                string zhanbh = context.Request["zhanbh"].ToString();

                List<ChargRecord> sypmList = crbll.GetSYPMList(zhanbh, page, rows, ref total);
                PageObject<ChargRecord> pageO = new PageObject<ChargRecord>();
                pageO.total = total;
                pageO.rows = sypmList;
                var str = jss.Serialize(pageO);
                context.Response.Write(str);
            }
            catch (Exception e)
            {
                Log.Debug(e);
            }
        }
        /// <summary>
        /// 查询桩充电数据统计
        /// </summary>
        /// <param name="context"></param>
        private void GetCdtj(HttpContext context)
        {
            try
            {
                //获取分页数据
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

                //接收参数
                string zhanbh = context.Request["zhanbh"].ToString();
                string zhuangbh = context.Request["zhuangbh"].ToString();
                DateTime begintime = new DateTime();
                string sj = context.Request["begintime"] ?? "";
                if (sj.Length > 0)
                {
                    begintime = DateTime.Parse(sj);
                }
                DateTime endtime = new DateTime();
                string ej = context.Request["endtime"] ?? "";
                if (ej.Length > 0)
                {
                    endtime = DateTime.Parse(ej);
                }

                List<ChargRecord> cdjlList = crbll.GetCDTJList(zhanbh, zhuangbh, begintime, endtime, page, rows, ref total);
                PageObject<ChargRecord> pageO = new PageObject<ChargRecord>();
                pageO.total = total;
                pageO.rows = cdjlList;
                var str = jss.Serialize(pageO);
                context.Response.Write(str);
            }
            catch (Exception e)
            {
                Log.Debug(e);
            }
        }
        /// <summary>
        /// 获取桩充电记录
        /// </summary>
        /// <param name="context"></param>
        private void GetCdjl(HttpContext context)
        {
            try
            {
                //获取分页数据
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
                //接收参数
                string zhanbh = context.Request["zhanbh"].ToString();
                string zhuangbh = context.Request["zhuangbh"].ToString();
                DateTime begintime = new DateTime();
                string sj = context.Request["begintime"] ?? "";
                if (sj.Length > 0)
                {
                    begintime = DateTime.Parse(sj);
                }
                DateTime endtime = new DateTime();
                string ej = context.Request["endtime"] ?? "";
                if (ej.Length > 0)
                {
                    endtime = DateTime.Parse(ej);
                }

                List<ChargRecord> cdjlList = crbll.GetCDJLList(zhanbh, zhuangbh, begintime, endtime, page, rows, ref total);
                PageObject<ChargRecord> pageO = new PageObject<ChargRecord>();
                pageO.total = total;
                pageO.rows = cdjlList;
                var str = jss.Serialize(pageO);
                context.Response.Write(str);
            }
            catch (Exception e)
            {
                Log.Error(e);
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
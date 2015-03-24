using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;
using ChargingPile.BLL;
using ChargingPile.Model;
using ChargingPile.Model.WarnRecService;
using ChargingPile.UI.WEB.Common;
using log4net;
using ChargingPile.Model.ChargePile;

namespace ChargingPile.UI.WEB.WebService
{
    /// <summary>
    /// Summary description for IndexService
    /// </summary>
    public class IndexService : IHttpHandler
    {
        protected ILog Log = LogManager.GetLogger("PriceAdjustmentService");
        readonly OprLogBll _oprLogBll = new OprLogBll();
        readonly JavaScriptSerializer _jss = new JavaScriptSerializer();
        private const string ErrorJson = "{\"total\":0,\"rows\":[],\"status\":\"0\",\"msg\":\"error\"}";
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            var action = context.Request.Params["action"];
            var str = ErrorJson;
            switch (action.ToLower())
            {
                case "findbychargingpileinfo":
                    str = FindByChargingPileInfo(context);
                    break;
                case "findbywarninfo":
                    str = FindByWarnInfo(context);
                    break;
                case "findbywarninfo2":
                    str = FindByWarnInfo2(context);
                    break;
                case "findbycardwarninfo":
                    str = FindByCardWarnInfo(context);
                    break;
                case "findbychargingpilecount":
                    str = FindByChargingPileCount();
                    break;
                case "findbychargepilecount":
                    str = FindByChargePileCount();
                    break;
                case "findbychargingpilezdl":
                    str = FindByChargingPileZdl();
                    break;
                case "findbychargingpilezje":
                    str = FindByChargingPileZje();
                    break;
                case "findbychargingpilezsc":
                    str = FindByChargingPileZsc();
                    break;
                case "findbyrankzje":
                    str = FindByRankZje();
                    break;
                case "findbyrankzje2":
                    str = FindByRankZje2(context);
                    break;
                case "findbyrankcardzje":
                    str = FindByRankCardZje();
                    break;
                case "findbyrankcardzje2":
                    str = FindByRankCardZje2(context);
                    break;
                case "findbyrankavgzdl":
                    str = FindByRankAvgZdl();
                    break;
                case "findbyrankavgzdl2":
                    str = FindByRankAvgZdl2(context);
                    break;
                case "findbyrankfailurerate":
                    str = FindByRankFailureRate();
                    break;
                case "findbyrankfailurerate2":
                    str = FindByRankFailureRate2(context);
                    break;
                case "findwarncount":
                    str = FindWarnCount(context);
                    break;
                case "queryzzt":
                    str = QueryZzt(context);
                    break;
                default:
                    break;
            }
            context.Response.Write(str);
        }

        /// <summary>
        /// 查询充电桩充电信息
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string FindByChargingPileInfo(HttpContext context)
        {
            string ret = null;
            var message = new Message<ChargingInfoParam>();
            var chargrecordbll = new ChargRecordBll();
            try
            {
                var dt = chargrecordbll.FindByChargingPileInfo();
                if (dt.Rows.Count > 0)
                {
                    var list = ConvertHelper<ChargingInfoParam>.ConvertToList(dt);
                    message.Rows = list;
                    message.Total = dt.Rows.Count;
                    ret = _jss.Serialize(message);
                }
                ret = ret.Replace("Total", "total");
                ret = ret.Replace("Rows", "rows");
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return ret;
        }

        /// <summary>
        /// 查询异常告警信息
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string FindByWarnInfo(HttpContext context)
        {
            string ret = null;
            var message = new Message<TelesignallingParam3>();
            var warnrecbll = new WarnRecBll();
            try
            {
                var dt = warnrecbll.FindByTelesignallingWarn();
                var list = ConvertHelper<TelesignallingParam3>.ConvertToList(dt);
                message.Rows = list;
                message.Total = dt.Rows.Count;
                ret = _jss.Serialize(message);
                ret = ret.Replace("Total", "total");
                ret = ret.Replace("Rows", "rows");
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return ret;
        }

        /// <summary>
        /// 查询异常告警信息
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string FindByWarnInfo2(HttpContext context)
        {
            string ret = null;
            var message = new Message<TelesignallingParam2>();
            var warnrecbll = new WarnRecBll();
            var warnid = context.Request.Params["id"];
            try
            {
                var dt = warnrecbll.FindByTelesignallingWarn2(warnid);
                var list = ConvertHelper<TelesignallingParam2>.ConvertToList(dt);
                message.Rows = list;
                message.Total = dt.Rows.Count;
                ret = _jss.Serialize(message);
                ret = ret.Replace("Total", "total");
                ret = ret.Replace("Rows", "rows");
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return ret;
        }

        /// <summary>
        /// 查找未处理告警总数
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string FindWarnCount(HttpContext context)
        {
            try
            {
                WarnRecBll wrBll = new WarnRecBll();
                int count = wrBll.FindByTelesignallingWarnCount();
                return "{\"count\":\"" + count + "\",\"msg\":\"error\"}";
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return "{\"count\":\"0\",\"msg\":\"error\"}";
            }
        }

        /// <summary>
        /// 查询充电卡告警信息
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string FindByCardWarnInfo(HttpContext context)
        {
            string ret = null;
            var message = new Message<CardParam>();
            var warnrecbll = new WarnRecBll();
            try
            {
                var dt = warnrecbll.FindByCardWarn();
                var list = ConvertHelper<CardParam>.ConvertToList(dt);
                message.Rows = list;
                message.Total = dt.Rows.Count;
                ret = _jss.Serialize(message);
                ret = ret.Replace("Total", "total");
                ret = ret.Replace("Rows", "rows");
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return ret;
        }

        /// <summary>
        /// 查询充电桩充电中总数量
        /// </summary>
        /// <returns></returns>
        public string FindByChargingPileCount()
        {
            string ret = null;
            var message = new JsonMessage<string>();
            var chargrecordbll = new ChargRecordBll();
            try
            {
                var count = chargrecordbll.FindByChargingPileCount();
                message.Total = count;
                message.Status = 1;
                message.JsExecuteMethod = "ajaxsuccess_setChargeingPileCount";
                ret = _jss.Serialize(message);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return ret;
        }

        /// <summary>
        /// 查询充电桩总数量
        /// </summary>
        /// <returns></returns>
        public string FindByChargePileCount()
        {
            string ret = null;
            var message = new JsonMessage<string>();
            var chargpilebll = new ChargPileBll();
            try
            {
                var count = chargpilebll.FindByChargePileCount();
                message.Total = count;
                message.Status = 1;
                message.JsExecuteMethod = "ajaxsuccess_setChargePileCount";
                ret = _jss.Serialize(message);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return ret;
        }


        /// <summary>
        /// 查询本月累计充电总电量
        /// </summary>
        /// <returns></returns>
        public string FindByChargingPileZdl()
        {
            string ret = null;
            var message = new JsonMessage<string>();
            var chargrecordbll = new ChargRecordBll();
            try
            {
                var year = DateTime.Now.Year;
                var month = DateTime.Now.Month;
                var zdl = chargrecordbll.FindByChargingPileZdl(year, month);
                message.Msg = zdl.ToString();
                message.Status = 1;
                message.JsExecuteMethod = "ajaxsuccess_setChargingPileZdl";
                ret = _jss.Serialize(message);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return ret;
        }


        /// <summary>
        /// 查询本月累计充电总金额
        /// </summary>
        /// <returns></returns>
        public string FindByChargingPileZje()
        {
            string ret = null;
            var message = new JsonMessage<string>();
            var chargrecordbll = new ChargRecordBll();
            try
            {
                var year = DateTime.Now.Year;
                var month = DateTime.Now.Month;
                var zje = chargrecordbll.FindByChargingPileZje(year, month);
                message.Msg = zje;
                message.Status = 1;
                message.JsExecuteMethod = "ajaxsuccess_setChargingPileZje";
                ret = _jss.Serialize(message);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return ret;
        }


        /// <summary>
        /// 查询本月累计充电总时长
        /// </summary>
        /// <returns></returns>
        public string FindByChargingPileZsc()
        {
            string ret = null;
            var message = new JsonMessage<string>();
            var chargrecordbll = new ChargRecordBll();
            try
            {
                var year = DateTime.Now.Year;
                var month = DateTime.Now.Month;
                var zsc = chargrecordbll.FindByChargingPileZsc(year, month);
                message.Msg = zsc;
                message.Status = 1;
                message.JsExecuteMethod = "ajaxsuccess_setChargingPileZsc";
                ret = _jss.Serialize(message);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return ret;
        }


        /// <summary>
        /// 查询充电总金额排行
        /// </summary>
        /// <returns></returns>
        public string FindByRankZje()
        {
            string ret = null;
            var message = new JsonMessage<RankParam>();
            var chargrecordbll = new ChargRecordBll();
            try
            {
                var year = DateTime.Now.Year;
                var month = DateTime.Now.Month;
                var dt = chargrecordbll.FindByRankZje(year, month);
                var list = ConvertHelper<RankParam>.ConvertToList(dt);
                message.Rows = list;
                ret = _jss.Serialize(message);
                ret = ret.Replace("Total", "total");
                ret = ret.Replace("Rows", "rows");
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return ret;
        }


        /// <summary>
        /// 查询充电总金额排行
        /// </summary>
        /// <returns></returns>
        public string FindByRankZje2(HttpContext context)
        {
            string ret = null;
            var message = new JsonMessage<RankParam>();
            var chargrecordbll = new ChargRecordBll();
            var page = context.Request.Params["page"];
            var rows = context.Request.Params["rows"];
            var pageIndex = 0;
            var size = 0;
            var count = 0;
            if (!string.IsNullOrEmpty(page))
                pageIndex = int.Parse(page);

            if (!string.IsNullOrEmpty(rows))
                size = int.Parse(rows);
            try
            {
                var kssj = context.Request.Params["kssj"];
                var jssj = context.Request.Params["jssj"];
                var dt = chargrecordbll.FindByRankZje(kssj, jssj, pageIndex, size, ref count);
                var list = ConvertHelper<RankParam>.ConvertToList(dt);
                message.Rows = list;
                message.Total = count;
                ret = _jss.Serialize(message);
                ret = ret.Replace("Total", "total");
                ret = ret.Replace("Rows", "rows");
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return ret;
        }

        /// <summary>
        /// 查询卡消费总额
        /// </summary>
        /// <returns></returns>
        public string FindByRankCardZje()
        {
            string ret = null;
            var message = new JsonMessage<RankParam2>();
            var chargrecordbll = new ChargRecordBll();
            try
            {
                var year = DateTime.Now.Year;
                var month = DateTime.Now.Month;
                var dt = chargrecordbll.FindByRankCardZje(year, month);
                if (dt != null && dt.Rows.Count > 0)
                {
                    var list = ConvertHelper<RankParam2>.ConvertToList(dt);
                    message.Rows = list;
                    ret = _jss.Serialize(message);
                    ret = ret.Replace("Total", "total");
                    ret = ret.Replace("Rows", "rows");
                }
                else
                {
                    ret = _jss.Serialize(message);
                    ret = ret.Replace("Total", "total");
                    ret = ret.Replace("\"Rows\":null", "\"rows\":[]");
                }


            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return ret;
        }

        /// <summary>
        /// 查询卡消费总额
        /// </summary>
        /// <returns></returns>
        public string FindByRankCardZje2(HttpContext context)
        {
            string ret = null;
            var message = new JsonMessage<RankParam>();
            var chargrecordbll = new ChargRecordBll();
            var page = context.Request.Params["page"];
            var rows = context.Request.Params["rows"];
            var pageIndex = 0;
            var size = 0;
            var count = 0;
            if (!string.IsNullOrEmpty(page))
                pageIndex = int.Parse(page);

            if (!string.IsNullOrEmpty(rows))
                size = int.Parse(rows);
            try
            {
                var kssj = context.Request.Params["kssj"];
                var jssj = context.Request.Params["jssj"];
                var dt = chargrecordbll.FindByRankCardZje(kssj, jssj, pageIndex, size, ref count);
                var list = ConvertHelper<RankParam>.ConvertToList(dt);
                message.Rows = list;
                message.Total = count;
                ret = _jss.Serialize(message);
                ret = ret.Replace("Total", "total");
                ret = ret.Replace("Rows", "rows");
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return ret;
        }


        /// <summary>
        /// 查询本月平均充电量
        /// </summary>
        /// <returns></returns>
        public string FindByRankAvgZdl()
        {
            string ret = null;
            var message = new JsonMessage<RankParam>();
            var chargrecordbll = new ChargRecordBll();
            try
            {
                var year = DateTime.Now.Year;
                var month = DateTime.Now.Month;
                var dt = chargrecordbll.FindByRankAvgZdl(year, month);
                var list = ConvertHelper<RankParam>.ConvertToList(dt);
                message.Rows = list;
                ret = _jss.Serialize(message);
                ret = ret.Replace("Total", "total");
                ret = ret.Replace("Rows", "rows");
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return ret;
        }


        /// <summary>
        /// 查询本月平均充电量
        /// </summary>
        /// <returns></returns>
        public string FindByRankAvgZdl2(HttpContext context)
        {
            string ret = null;
            var message = new JsonMessage<RankParam>();
            var chargrecordbll = new ChargRecordBll();
            var page = context.Request.Params["page"];
            var rows = context.Request.Params["rows"];
            var pageIndex = 0;
            var size = 0;
            var count = 0;
            if (!string.IsNullOrEmpty(page))
                pageIndex = int.Parse(page);

            if (!string.IsNullOrEmpty(rows))
                size = int.Parse(rows);
            try
            {
                var kssj = context.Request.Params["kssj"];
                var jssj = context.Request.Params["jssj"];
                var dt = chargrecordbll.FindByRankAvgZdl(kssj, jssj, pageIndex, size, ref count);
                var list = ConvertHelper<RankParam>.ConvertToList(dt);
                message.Rows = list;
                message.Total = count;
                ret = _jss.Serialize(message);
                ret = ret.Replace("Total", "total");
                ret = ret.Replace("Rows", "rows");
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return ret;
        }


        /// <summary>
        /// 查询本月运行故障率
        /// </summary>
        /// <returns></returns>
        public string FindByRankFailureRate()
        {
            string ret = null;
            var message = new JsonMessage<RankParam>();
            var chargrecordbll = new ChargRecordBll();
            try
            {
                var year = DateTime.Now.Year;
                var month = DateTime.Now.Month;
                var dt = chargrecordbll.FindByRankFailureRate(year, month);
                var list = ConvertHelper<RankParam>.ConvertToList(dt);
                message.Rows = list;
                ret = _jss.Serialize(message);
                ret = ret.Replace("Total", "total");
                ret = ret.Replace("Rows", "rows");
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return ret;
        }

        /// <summary>
        /// 查询本月运行故障率
        /// </summary>
        /// <returns></returns>
        public string FindByRankFailureRate2(HttpContext context)
        {
            string ret = null;
            var message = new JsonMessage<RankParam>();
            var chargrecordbll = new ChargRecordBll();
            var page = context.Request.Params["page"];
            var rows = context.Request.Params["rows"];
            var pageIndex = 0;
            var size = 0;
            var count = 0;
            if (!string.IsNullOrEmpty(page))
                pageIndex = int.Parse(page);

            if (!string.IsNullOrEmpty(rows))
                size = int.Parse(rows);
            try
            {
                var kssj = context.Request.Params["kssj"];
                var jssj = context.Request.Params["jssj"];
                var dt = chargrecordbll.FindByRankFailureRate(kssj, jssj, pageIndex, size, ref count);
                var list = ConvertHelper<RankParam>.ConvertToList(dt);
                message.Rows = list.OrderBy(gzl => gzl.Gzl).ToList();
                message.Total = count;
                ret = _jss.Serialize(message);
                ret = ret.Replace("Total", "total");
                ret = ret.Replace("Rows", "rows");
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return ret;
        }

        /// <summary>
        /// 查询桩状态
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string QueryZzt(HttpContext context)
        {
            string ret = ErrorJson;
            var message = new Message<ChargingInfoParam>();
            var chargrecordbll = new ChargRecordBll();
            try
            {
                string cdcz = context.Request["cdcz"] ?? "",
                       zbh = context.Request["zbh"] ?? "";
                int page = int.Parse(context.Request["page"] ?? "1"),
                    rows = int.Parse(context.Request["rows"] ?? "20");

                string tmp = context.Request["dateBegin"] ?? "";
                DateTime dateEnd = DateTime.MinValue,
                         dateBegin = DateTime.MinValue;
                if (!string.IsNullOrEmpty(tmp))
                {
                    dateBegin = DateTime.Parse(tmp);
                }
                tmp = context.Request["dateEnd"] ?? "";
                if (!string.IsNullOrEmpty(tmp))
                {
                    dateEnd = DateTime.Parse(tmp);
                }
                var count = 0;
                var dt = chargrecordbll.FindByCondition(cdcz, zbh, dateBegin, dateEnd, page, rows, ref count);
                var list = ConvertHelper<ChargingInfoParam>.ConvertToList(dt);
                message.Rows = list;
                message.Total = count;
                ret = _jss.Serialize(message);
                ret = ret.Replace("Total", "total");
                ret = ret.Replace("Rows", "rows");
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return ret;
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
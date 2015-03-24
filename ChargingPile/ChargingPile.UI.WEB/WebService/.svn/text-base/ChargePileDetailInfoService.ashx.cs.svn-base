using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;
using ChargingPile.BLL;
using ChargingPile.Model;
using ChargingPile.UI.WEB.Common;
using ChargingPile.Model.Param;
using log4net;

namespace ChargingPile.UI.WEB.WebService
{
    /// <summary>
    /// Summary description for ChargePileDetailInfoService
    /// </summary>
    public class ChargePileDetailInfoService : IHttpHandler, IRequiresSessionState
    {
        protected ILog Log = LogManager.GetLogger("PriceAdjustmentService");
        readonly OprLogBll _oprLogBll = new OprLogBll();

        readonly JavaScriptSerializer _jss = new JavaScriptSerializer();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            var action = context.Request.Params["action"];
            var str = string.Empty;
            switch (action)
            {
                case "offPolice":
                    str = OffPolice(context);
                    break;
                case "getItem":
                    str = GetItem(context);
                    break;
                case "queryItemsName":
                    str = QueryItemsName(context);
                    break;
                case "getBusinessInfo":
                    str = GetBusinessInfo(context);
                    break;
                case "getDetailInfo":
                    str = GetDetailInfo(context);
                    break;
                case "getChargePileStatus":
                    str = GetChargePileStates(context);
                    break;
                case "getDJZMData":
                    getDJZMData(context);
                    break;
                default:
                    break;
            }

            context.Response.Write(str);
        }
        /// <summary>
        /// 获取桩最后一次充电记录信息
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string getDJZMData(HttpContext context)
        {
            string ret = null;
            var message = new JsonMessage<ChargePileDetailInfo>();
            var chargPileBll = new ChargPileBll();
            var id = context.Request.Params["zhuanid"];
            if (string.IsNullOrEmpty(id))
            {
                return ret;
            }
            var zhuanid = int.Parse(id);

            try
            {
                var dt = chargPileBll.FindByChargePileDetailInfo(zhuanid);
                var list = ConvertHelper<ChargePileDetailInfo>.ConvertToList(dt);
                message.Rows = list;
                message.Status = 1;
                message.Msg = "返回成功";
                message.JsExecuteMethod = "ajaxSuccess_setChargePileInfo";
                ret = _jss.Serialize(message);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return ret;
        }
        /// <summary>
        /// 获取充电桩状态
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetChargePileStates(HttpContext context)
        {
            string ret = null;
            var message = new JsonMessage<ChargePileStates>();
            var chargePileStatesBll = new ChargePileStatesBll();
            var id = context.Request.Params["zhuanid"];
            if (string.IsNullOrEmpty(id))
            {
                return ret;
            }
            var zhuanid = int.Parse(id);
            var chargePileStates = new ChargePileStates()
                {
                    PowerPileNo = zhuanid
                };
            try
            {
                var dt = chargePileStatesBll.Query(chargePileStates);
                var list = ConvertHelper<ChargePileStates>.ConvertToList(dt);
                message.Rows = list;
                message.Status = 1;
                message.Msg = "返回成功";
                message.JsExecuteMethod = "ajaxSuccess_queryChargePileStates";
                ret = _jss.Serialize(message);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return ret;
        }

        /// <summary>
        /// 获取充电桩交易信息
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetBusinessInfo(HttpContext context)
        {
            string ret = null;
            var message = new JsonMessage<ChargePileRecordParam>();
            var chargRecordBll = new ChargRecordBll();
            var id = context.Request.Params["zhuanid"];
            var state = context.Request.Params["zhuanstates"];
            if (string.IsNullOrEmpty(id))
            {
                return ret;
            }

            var zhuanid = int.Parse(id);

            try
            {
                DataTable dt;
                switch (state)
                {
                    case "1": //待充电  1 如果是待机，就要显示最近一次交易信息 
                        dt = chargRecordBll.FindByStandbyInfo(zhuanid);
                        var list0 = ConvertHelper<ChargePileRecordParam>.ConvertToList(dt);
                        message.Rows = list0;
                        message.Status = 1;
                        message.Msg = state;
                        message.JsExecuteMethod = "ajaxSuccess_setBusinessInfo";
                        ret = _jss.Serialize(message);
                        break;
                    case "3": //已充满  3 
                        //dt = chargRecordBll.FindByBusinessInfo(zhuanid);
                        dt = chargRecordBll.FindByStandbyInfo(zhuanid);
                        var list1 = ConvertHelper<ChargePileRecordParam>.ConvertToList(dt);
                        message.Rows = list1;
                        message.Status = 1;
                        message.Msg = state;
                        message.JsExecuteMethod = "ajaxSuccess_setBusinessInfo";
                        ret = _jss.Serialize(message);
                        break;
                    case "2": //充电中  2 
                        dt = chargRecordBll.FindByChargingPileBusinessInfo(zhuanid);
                        var list2 = ConvertHelper<ChargePileRecordParam>.ConvertToList(dt);
                        message.Rows = list2;
                        message.Status = 1;
                        message.Msg = state;
                        message.JsExecuteMethod = "ajaxSuccess_setBusinessInfo";
                        ret = _jss.Serialize(message);
                        break;
                    case "5": //故障异常  5
                        //dt = chargRecordBll.FindByBusinessInfo(zhuanid);
                        //var list3 = ConvertHelper<ChargePileRecordParam>.ConvertToList(dt);
                        //message.Rows = list3;
                        //message.Status = 1;
                        //message.Msg = state;
                        //message.JsExecuteMethod = "ajaxSuccess_setBusinessInfo";
                        //ret = _jss.Serialize(message);
                        break;
                    case "4": //离线  4 未知
                        break;
                }
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return ret;
        }

        /// <summary>
        /// 获取桩基本信息
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetDetailInfo(HttpContext context)
        {
            string ret = null;
            var message = new JsonMessage<ChargePileDetailInfo>();
            var chargPileBll = new ChargPileBll();
            var id = context.Request.Params["zhuanid"];
            if (string.IsNullOrEmpty(id))
            {
                return ret;
            }
            var zhuanid = int.Parse(id);

            try
            {
                var dt = chargPileBll.FindByChargePileDetailInfo(zhuanid);
                var list = ConvertHelper<ChargePileDetailInfo>.ConvertToList(dt);
                message.Rows = list;
                message.Status = 1;
                message.Msg = "返回成功";
                message.JsExecuteMethod = "ajaxSuccess_setChargePileInfo";
                ret = _jss.Serialize(message);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return ret;
        }

        /// <summary>
        /// 获取采集项(复杂sql查询)
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetItem(HttpContext context)
        {
            string ret = null;
            var message = new JsonMessage<GatItem>();
            var gatItemBll = new GatItemBll();
            var id = context.Request.Params["zhuanid"];
            if (string.IsNullOrEmpty(id))
            {
                return ret;
            }
            var zhuanid = int.Parse(id);

            try
            {
                var dt = gatItemBll.FindByItemName(zhuanid);
                var list = ConvertHelper<GatItem>.ConvertToList(dt);
                message.Rows = list;
                message.Status = 1;
                message.Msg = "返回成功";
                message.JsExecuteMethod = "ajaxSuccess_responseBtnHtml";
                ret = _jss.Serialize(message);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return ret;
        }

        /// <summary>
        /// 获取采集项(单纯query方法)
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string QueryItemsName(HttpContext context)
        {
            string ret = null;
            var message = new JsonMessage<Dictionary<string, string>>();
            var gatItemBll = new GatItemBll();
            var id = context.Request.Params["itemid"];
            var list = new List<Dictionary<string, string>>();
            if (string.IsNullOrEmpty(id))
            {
                return ret;
            }
            var idlist = id.Split('|');

            try
            {
                foreach (var s in idlist)
                {
                    var listItem = new Dictionary<string, string>();
                    var gatItem = new GatItem()
                    {
                        ITEMNO = s
                    };
                    var dt = gatItemBll.Query(gatItem);
                    if (dt.Rows.Count <= 0)
                        continue;
                    var name = dt.Rows[0]["itemname"].ToString();
                    listItem.Add(s, name);

                    list.Add(listItem);
                }
                //var list = ConvertHelper<GatItem>.ConvertToList(dt);
                //var list = _jss.Serialize(listItem);
                message.Rows = list;
                message.Status = 1;
                message.Msg = "返回成功";
                message.JsExecuteMethod = "ajaxSuccess_remoteAjaxSuccess_setCurrentTimeInfo";
                ret = _jss.Serialize(message);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return ret;
        }

        /// <summary>
        /// 灭警
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string OffPolice(HttpContext context)
        {
            var message = new JsonMessage<WarnRec>();
            var list = new List<WarnRec>();
            string ret = null;
            try
            {
                var zhuanid = context.Request["zhuanid"] ?? "";
                var itemno = context.Request["itemno"] ?? "";
                if (zhuanid.Length == 0 || itemno.Length == 0)
                {
                    message.Status = 0;
                    message.Msg = "页面有错误!";
                    ret = _jss.Serialize(message);
                    return ret;
                }
                var id = int.Parse(zhuanid);
                var wrBll = new WarnRecBll();
                var empid = "";
                var name = "";
                if (null != context.Session[Constant.LoginUser])
                {
                    empid = (context.Session[Constant.LoginUser] as Employer ?? new Employer()).Id;
                    name = (context.Session[Constant.LoginUser] as Employer ?? new Employer()).Name;
                }
                var warnRec = new WarnRec()
                    {
                        //TODO:这里id可能要改
                        DataItemId = itemno,
                        TargetDev = id.ToString(),
                        ProcessFlag = Constant.MjfsSd,
                        ProcessDt = DateTime.Now,
                        ProcesseEp = empid,
                    };
                list.Add(warnRec);
                wrBll.EditBy(warnRec);
                message.Rows = list;
                message.Status = 1;
                message.Msg = "灭警成功";
                message.JsExecuteMethod = "ajaxSuccess_btn_ok";
                ret = _jss.Serialize(message);

                new OprLogBll().Add(new OprLog
                    {
                        Operator = name,
                        OprSrc = "灭警",
                        OperResult = "成功",
                        LogDate = DateTime.Now
                    });
            }
            catch (Exception e)
            {
                message.Status = 0;
                message.Msg = "修改失败";
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
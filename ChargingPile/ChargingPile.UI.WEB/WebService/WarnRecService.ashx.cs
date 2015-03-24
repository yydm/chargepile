using System;
using System.Collections.Generic;
using System.Collections;
using System.Configuration;
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
using CodeAnywhere.Json.Rpc;
using CodeAnywhere.Json.Rpc.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ChargingPile.UI.WEB.WebService
{
    /// <summary>
    /// Summary description for WarnRecService
    /// </summary>
    public class WarnRecService : IHttpHandler, IRequiresSessionState
    {
        static readonly string Url = ConfigurationSettings.AppSettings["url"];
        protected ILog Log = LogManager.GetLogger("PriceAdjustmentService");
        readonly OprLogBll _oprLogBll = new OprLogBll();
        readonly JavaScriptSerializer _jss = new JavaScriptSerializer();

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            var action = context.Request.Params["action"];
            var str = string.Empty;
            switch (action.ToLower())
            {
                case "findbytelesignallingwarn":
                    str = FindByTelesignallingWarn(context);
                    break;
                case "findbytelesignallingwarn2":
                    str = FindByTelesignallingWarn2(context);
                    break;
                case "offpolice":
                    str = OffPoliceInvoke(context);
                    break;
                case "settelesignallingwarncount":
                    str = SetTelesignallingWarnCount(context);
                    break;
                case "findbycardwarn":
                    str = FindByCardWarn(context);
                    break;
                case "findbycommunicationwarn":
                    str = FindByCommunicationWarn(context);
                    break;
                case "findbypowerfailure":
                    str = FindByPowerFailure(context);
                    break;
                case "getwarntype":
                    str = GetWarnType(context);
                    break;
                case "getzhanmc":
                    str = GetZhanMc(context);
                    break;
                case "getxunxingbh":
                    str = GetXunXingBh(context);
                    break;
                default:
                    break;
            }

            context.Response.Write(str);
        }

        /// <summary>
        /// 获取异常告警
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string FindByTelesignallingWarn(HttpContext context)
        {
            string ret = null;
            //var message = new JsonMessage<TelesignallingWarn>();
            var json = new Hashtable();
            var warnrecbll = new WarnRecBll();
            var zhanbh = context.Request.Params["zhanbh"];
            try
            {
                //保存工号
                var worknum = ((Employer)(context.Session[Constant.LoginUser])).WorkNum;
                var dt = warnrecbll.FindByTelesignallingWarn(zhanbh);
                var list = ConvertHelper<TelesignallingWarn>.ConvertToList(dt);
                foreach (var li in list)
                {
                    li.WorkNum = worknum;
                }
                json["rows"] = list;
                json["total"] = dt.Rows.Count;
                json["status"] = warnrecbll.FindByTelesignallingWarnCount();
                ret = _jss.Serialize(json);
                return ret;
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return null;
        }

        /// <summary>
        /// 获取异常告警未处理数量
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string SetTelesignallingWarnCount(HttpContext context)
        {
            string ret = null;
            var message = new JsonMessage<TelesignallingWarn>();
            var warnrecbll = new WarnRecBll();
            try
            {
                message.Total = warnrecbll.FindByTelesignallingWarnCount();
                message.Status = 1;
                message.Msg = "返回成功";
                message.JsExecuteMethod = "ajaxSuccess_SetTelesignallingWarnCount";
                ret = _jss.Serialize(message);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            message.Status = 0;
            message.Msg = "发生异常";
            return ret;
        }

        /// <summary>
        /// 获取异常告警
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string FindByTelesignallingWarn2(HttpContext context)
        {
            string ret = null;
            //var message = new JsonMessage<TelesignallingWarn>();
            var json = new Hashtable();
            var warnrecbll = new WarnRecBll();
            var telesignallingParam = new TelesignallingParam();
            var zhanbh = context.Request.Params["zhanbh"];
            var warnType = context.Request.Params["warnType"];
            var yunXinbh = context.Request.Params["yunXinbh"];
            var kssj = context.Request.Params["kssj"];
            var jssj = context.Request.Params["jssj"];
            var clfs = context.Request.Params["clfs"];
            telesignallingParam.Zhanbh = zhanbh;
            telesignallingParam.WarnType = warnType;
            telesignallingParam.ZhanYxBh = yunXinbh;
            telesignallingParam.Kssj = kssj;
            telesignallingParam.Jssj = jssj;
            telesignallingParam.Clfs = clfs;
            try
            {
                var page = context.Request.Params["page"];
                var rows = context.Request.Params["rows"];
                var pageIndex = 0;
                var size = 0;
                var count = 0;
                if (!string.IsNullOrEmpty(page))
                    pageIndex = int.Parse(page);

                if (!string.IsNullOrEmpty(rows))
                    size = int.Parse(rows);
                //保存工号
                var worknum = ((Employer)(context.Session[Constant.LoginUser])).WorkNum;
                var dt = warnrecbll.FindByTelesignallingWarn(telesignallingParam, pageIndex, size, ref count);
                var list = ConvertHelper<TelesignallingWarn>.ConvertToList(dt);
                foreach (var li in list)
                {
                    li.WorkNum = worknum;
                }
                json["rows"] = list;
                json["total"] = count;
                ret = _jss.Serialize(json);
                return ret;
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return null;
        }

        /// <summary>
        /// 获取充电卡异常使用告警
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string FindByCardWarn(HttpContext context)
        {
            string ret = null;
            //var message = new JsonMessage<CardWarn>();
            var json = new Hashtable();
            var warnrecbll = new WarnRecBll();
            var zhanbh = context.Request.Params["zhanbh"];
            try
            {
                //保存工号
                var worknum = ((Employer)(context.Session[Constant.LoginUser])).WorkNum;
                var dt = warnrecbll.FindByCardWarn(zhanbh);
                var list = ConvertHelper<CardWarn>.ConvertToList(dt);
                foreach (var li in list)
                {
                    li.WorkNum = worknum;
                }
                json["rows"] = list;
                json["total"] = dt.Rows.Count;
                json["status"] = warnrecbll.FindByCardWarnCount();
                ret = _jss.Serialize(json);
                return ret;
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return null;
        }

        /// <summary>
        /// 获取通信告警告警
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string FindByCommunicationWarn(HttpContext context)
        {
            string ret = null;
            //var message = new JsonMessage<CommunicationWarn>();
            var warnrecbll = new WarnRecBll();
            var zhanbh = context.Request.Params["zhanbh"];
            var json = new Hashtable();
            try
            {
                //保存工号
                var worknum = ((Employer)(context.Session[Constant.LoginUser])).WorkNum;
                var dt = warnrecbll.FindByCommunicationWarn2(zhanbh);
                var list = ConvertHelper<CommunicationWarn>.ConvertToList(dt);
                foreach (var li in list)
                {
                    li.WorkNum = worknum;
                }
                json["rows"] = list;
                json["total"] = dt.Rows.Count;
                json["status"] = warnrecbll.FindByCommunicationWarnCount();
                ret = _jss.Serialize(json);
                return ret;
            }
            catch (Exception e)
            {
                Log.Error(e);
            }

            return null;
        }

        /// <summary>
        /// 获取停电告警
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string FindByPowerFailure(HttpContext context)
        {
            string ret = null;
            //var message = new JsonMessage<PowerFailureWarn>();
            var warnrecbll = new WarnRecBll();
            var zhanbh = context.Request.Params["zhanbh"];
            var json = new Hashtable();
            try
            {
                //保存工号
                var worknum = ((Employer)(context.Session[Constant.LoginUser])).WorkNum;
                var dt = warnrecbll.FindByPowerFailure3(zhanbh);
                var list = ConvertHelper<PowerFailureWarn>.ConvertToList(dt);
                foreach (var li in list)
                {
                    li.WorkNum = worknum;
                }
                json["rows"] = list;
                json["total"] = dt.Rows.Count;
                json["status"] = warnrecbll.FindByPowerFailureCount();

                ret = _jss.Serialize(json);
                return ret;
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return null;
        }

        /// <summary>
        /// 获取停电告警
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetWarnType(HttpContext context)
        {
            string ret = null;
            var message = new JsonMessage<CodeInfo>();
            var warnrecbll = new WarnRecBll();
            try
            {
                var dt = warnrecbll.FindByWarnType();
                var list = ConvertHelper<CodeInfo>.ConvertToList(dt);
                message.Rows = list;
                message.Status = 1;
                message.Msg = "返回成功";
                message.JsExecuteMethod = "ajaxSuccess_bindWarnType";
                ret = _jss.Serialize(message);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            message.Status = 0;
            message.Msg = "发生异常";
            return ret;
        }

        /// <summary>
        /// 获取充电站名称
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetZhanMc(HttpContext context)
        {
            string ret = null;
            var message = new JsonMessage<ChargeStation>();
            var warnrecbll = new WarnRecBll();
            try
            {
                var dt = warnrecbll.FindByZhanMc();
                var list = ConvertHelper<ChargeStation>.ConvertToList(dt);
                message.Rows = list;
                message.Status = 1;
                message.Msg = "返回成功";
                message.JsExecuteMethod = "ajaxSuccess_bindZhanMc";
                ret = _jss.Serialize(message);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            message.Status = 0;
            message.Msg = "发生异常";
            return ret;
        }

        /// <summary>
        /// 获取运行编号
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetXunXingBh(HttpContext context)
        {
            string ret = null;
            var message = new JsonMessage<ChargPile>();
            var warnrecbll = new WarnRecBll();
            var zhanBh = context.Request.Params["zhanBh"];
            try
            {
                var dt = warnrecbll.FindByYunXinBh(zhanBh);
                var list = ConvertHelper<ChargPile>.ConvertToList(dt);
                message.Rows = list;
                message.Status = 1;
                message.Msg = "返回成功";
                message.JsExecuteMethod = "ajaxSuccess_bindXunXinBh";
                ret = _jss.Serialize(message);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            message.Status = 0;
            message.Msg = "发生异常";
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
                var warnid = context.Request["warnid"] ?? "";
                var warntype = context.Request["warntype"] ?? "";
                if (warnid.Length == 0)
                {
                    message.Status = 0;
                    message.Msg = "页面有错误!";
                    ret = _jss.Serialize(message);
                    return ret;
                }
                var wrBll = new WarnRecBll();
                var name = "";
                if (null != context.Session[Constant.LoginUser])
                {
                    name = (context.Session[Constant.LoginUser] as Employer ?? new Employer()).Name;
                }
                var warnRec = new WarnRec()
                {
                    Id = warnid,
                    ProcessFlag = Constant.MjfsSd,
                    ProcessDt = DateTime.Now,
                    ProcesseEp = name,
                };
                list.Add(warnRec);
                wrBll.Modify(warnRec);
                //message.Rows = list;
                message.Status = 1;
                message.Msg = warntype;
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
            message.Status = 0;
            message.Msg = "发生异常";
            return ret;
        }

        /// <summary>
        /// 灭警(通过接口)
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string OffPoliceInvoke(HttpContext context)
        {
            var message = new JsonMessage<WarnRec>();
            string ret = null;
            var name = "";
            try
            {
                var warnid = context.Request["warnid"] ?? "";
                var warntype = context.Request["warntype"] ?? "";
                if (warnid.Length == 0)
                {
                    message.Status = 0;
                    message.Msg = "页面有错误!";
                    ret = _jss.Serialize(message);
                    return ret;
                }
                if (null != context.Session[Constant.LoginUser])
                {
                    name = (context.Session[Constant.LoginUser] as Employer ?? new Employer()).Name;
                }

                var jsonSetting = InvokeSetting(warnid);
                var c = new RpcClient { RpcUrl = Url };
                var req = JsonConvert.DeserializeObject<JsonRequest>(jsonSetting);

                var resp = c.Invoke(req);
                var success = resp.Success;
                var messages = resp.Message;
                switch (success)
                {
                    case true:
                        message.Status = 1;
                        message.Msg = warntype;
                        message.Msg = "返回成功";
                        break;
                    case false:
                        message.Status = 0;
                        message.Msg = messages;
                        break;
                }
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
            message.Status = 0;
            message.Msg = "发生异常";
            return ret;
        }

        public static string InvokeSetting(string id)
        {
            var req = new JsonRequest
            {
                ClassType = "DataGatherRpc",
                Scope = RequestScope.Singleton,
                Method = "ManBreakWarn"
            };
            req.AddParam(id);
            var setting = new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore };
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss.fff" };
            setting.Converters.Add(timeConverter);

            var json = JsonConvert.SerializeObject(req, Formatting.Indented, setting);
            return json;
        }

        public static string MjLog(HttpContext context)
        {
            var cg = context.Request["cg"] ?? "true";
            var name = "";
            if (null != context.Session[Constant.LoginUser])
            {
                name = (context.Session[Constant.LoginUser] as Employer ?? new Employer()).Name;
            }
            var cgStr = bool.Parse(cg);
            new OprLogBll().Add(new OprLog
            {
                Operator = name,
                OprSrc = "灭警",
                OperResult = cgStr ? "成功" : "失败",
                LogDate = DateTime.Now
            });
            return "{\"cg\":true}";
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
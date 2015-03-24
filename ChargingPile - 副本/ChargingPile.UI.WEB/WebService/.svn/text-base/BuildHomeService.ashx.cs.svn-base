using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using ChargingPile.BLL;
using ChargingPile.Model;
using log4net;
using ChargingPile.Model.Param.WarnRec;

namespace ChargingPile.UI.WEB.WebService
{
    /// <summary>
    /// Summary description for BuildHomeService
    /// </summary>
    public class BuildHomeService : IHttpHandler
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
                case "queryWarnInfo":
                    str = QueryWarnInfo(context);
                    break;
                case "queryWarnInfoByZhuanId":
                    str = QueryWarnInfoByZhuanId(context);
                    break;
            }

            context.Response.Write(str);
        }

        /// <summary>
        /// 查询告警信息
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string QueryWarnInfo(HttpContext context)
        {
            var message = new JsonMessage<WarnParam>();
            var warnrecbll = new WarnRecBll();
            string ret = null;
            try
            {
                var zhanid = context.Request.Params["zhanid"];
                var dt = warnrecbll.FindBy(zhanid);
                var list = ConvertHelper<WarnParam>.ConvertToList(dt);
                message.Rows = list;
                message.Status = 1;
                message.Msg = "返回成功";
                ret = _jss.Serialize(message);
            }
            catch (Exception)
            {
                message.Status = 0;
                message.Msg = "返回失败";
                Log.Error(message.ToString());
            }
            return ret;
        }


        /// <summary>
        /// 根据桩id查询告警信息
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string QueryWarnInfoByZhuanId(HttpContext context)
        {
            string ret = null;
            var message = new JsonMessage<WarnRec>();
            var warnrecbll = new WarnRecBll();
            var id = context.Request.Params["zhuanid"];
            if (string.IsNullOrEmpty(id))
            {
                return ret;
            }
            var zhuanid = int.Parse(id);
            try
            {
                var dt = warnrecbll.FindBy(zhuanid);
                var list = ConvertHelper<WarnRec>.ConvertToList(dt);
                message.Rows = list;
                message.Status = 1;
                message.Msg = "返回成功";
                message.JsExecuteMethod = "ajaxSuccess_warnInfoQuery";
                ret = _jss.Serialize(message);
            }
            catch (Exception)
            {
                message.Status = 0;
                message.Msg = "返回失败";
                Log.Error(message.ToString());
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
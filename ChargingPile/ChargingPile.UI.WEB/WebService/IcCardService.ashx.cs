using System;
using System.Data;
using System.Web;
using ChargingPile.BLL;
using ChargingPile.Model;

namespace ChargingPile.UI.WEB.WebService
{
    /// <summary>
    /// IcCardService 的摘要说明
    /// </summary>
    public class IcCardService : IHttpHandler
    {
        private const string ErrorJson = "{\"total\":0,\"rows\":[],\"status\":\"0\",\"msg\":\"error\"}";
        protected log4net.ILog Log = log4net.LogManager.GetLogger("IcCardService");
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request["action"] ?? "";
            action = action.ToLower();
            string ret = ErrorJson;
            switch (action)
            {
                case "queryinfo":
                    ret = QueryInfo(context.Request);
                    break;
                case "getzjmc":
                    ret = GetZjmc(context.Request);
                    break;
                case "getkzt":
                    ret = GetKzt(context.Request);
                    break;
                case "getklx":
                    ret = GetKlx(context.Request);
                    break;
                case "getczfs":
                    ret = GetCzfs(context.Request);
                    break;
                case "queryczjl":
                    ret = QueryCzjl(context.Request);
                    break;
                case "querygs":
                    ret = QueryGs(context.Request);
                    break;
                case "queryexp":
                    ret = QueryExp(context.Request);
                    break;
                default:
                    break;
            }
            context.Response.Write(ret);
        }

        /// <summary>
        /// 查询充电卡信息
        /// </summary>
        /// <param name="httpRequest"></param>
        /// <returns></returns>
        private string QueryInfo(HttpRequest httpRequest)
        {
            try
            {
                string cardNum = httpRequest["cardNum"] ?? "",
                       name = httpRequest["name"] ?? "",
                       zjmc = httpRequest["zjmc"] ?? "",
                       zjhm = httpRequest["zjhm"] ?? "",
                       kzt = httpRequest["kzt"] ?? "",
                       klx = httpRequest["klx"] ?? "",
                       dateBegin = httpRequest["dateBegin"],
                       dateEnd = httpRequest["dateEnd"];
                int page = int.Parse(httpRequest["page"] ?? "1"),
                    rows = int.Parse(httpRequest["rows"] ?? "20");
                CardInfo ci = new CardInfo()
                    {
                        CardId = cardNum,
                        Name = name,
                        Zjmc = zjmc,
                        Zjhm = zjhm,
                        Kzt = kzt,
                        Klx = klx,
                    };
                if (!string.IsNullOrEmpty(dateBegin))
                {
                    ci.DateBegin = DateTime.Parse(dateBegin);
                }
                if (!string.IsNullOrEmpty(dateEnd))
                {
                    ci.DateEnd = DateTime.Parse(dateEnd);
                }
                IcCardBll icCardBll = new IcCardBll();
                int count = 0;
                DataTable dt = icCardBll.QueryCardInfo(ci, page, rows, ref count);
                var str = ConvertToJson.DataTableToJson("rows", dt);
                str = str.Substring(1, str.Length - 2);
                return "{\"total\":\"" + count + "\"," + str + "}";
            }
            catch (Exception e)
            {
                Log.Error(e);
                return ErrorJson;
            }
        }

        /// <summary>
        /// 查询充值记录
        /// </summary>
        /// <param name="httpRequest"></param>
        /// <returns></returns>
        private string QueryCzjl(HttpRequest httpRequest)
        {
            try
            {
                string cardNum = httpRequest["cardNum"] ?? "",
                       czy = httpRequest["czy"] ?? "",
                       czwd = httpRequest["czwd"] ?? "",
                       czfs = httpRequest["czfs"] ?? "",
                       dateBegin = httpRequest["dateBegin"],
                       dateEnd = httpRequest["dateEnd"];
                int page = int.Parse(httpRequest["page"] ?? "1"),
                    rows = int.Parse(httpRequest["rows"] ?? "20");
                CardInfo ci = new CardInfo()
                {
                    CardId = cardNum,
                    Czy = czy,
                    Czwd = czwd,
                    Czfs = czfs,
                };
                if (!string.IsNullOrEmpty(dateBegin))
                {
                    ci.DateBegin = DateTime.Parse(dateBegin);
                }
                if (!string.IsNullOrEmpty(dateEnd))
                {
                    ci.DateEnd = DateTime.Parse(dateEnd);
                }
                IcCardBll icCardBll = new IcCardBll();
                int count = 0;
                DataTable dt = icCardBll.QueryCzjl(ci, page, rows, ref count);
                var str = ConvertToJson.DataTableToJson("rows", dt);
                str = str.Substring(1, str.Length - 2);
                return "{\"total\":\"" + count + "\"," + str + "}";
            }
            catch (Exception e)
            {
                Log.Error(e);
                return ErrorJson;
            }
        }

        /// <summary>
        /// 查询挂失信息
        /// </summary>
        /// <param name="httpRequest"></param>
        /// <returns></returns>
        private string QueryGs(HttpRequest httpRequest)
        {
            try
            {
                int page = int.Parse(httpRequest["page"] ?? "1"),
                    rows = int.Parse(httpRequest["rows"] ?? "20");
                IcCardBll icCardBll = new IcCardBll();
                int count = 0;
                DataTable dt = icCardBll.QueryGs(new CardInfo(), page, rows, ref count);
                var str = ConvertToJson.DataTableToJson("rows", dt);
                str = str.Substring(1, str.Length - 2);
                return "{\"total\":\"" + count + "\"," + str + "}";
            }
            catch (Exception e)
            {
                Log.Error(e);
                return ErrorJson;
            }
        }
        /// <summary>
        /// 获取卡异常结算数据
        /// </summary>
        /// <param name="httpRequest"></param>
        /// <returns></returns>
        private string QueryExp(HttpRequest httpRequest)
        {
            try
            {
                int page = int.Parse(httpRequest["page"] ?? "1"),
                    rows = int.Parse(httpRequest["rows"] ?? "20");
                IcCardBll icCardBll = new IcCardBll();
                int count = 0;
                DataTable dt = icCardBll.QueryExp(new CardInfo(), page, rows, ref count);
                var str = ConvertToJson.DataTableToJson("rows", dt);
                str = str.Substring(1, str.Length - 2);
                return "{\"total\":\"" + count + "\"," + str + "}";
            }
            catch (Exception e)
            {
                Log.Error(e);
                return ErrorJson;
            }
        }

        /// <summary>
        /// 获取证件名称
        /// </summary>
        /// <param name="httpRequest"></param>
        /// <returns></returns>
        private string GetZjmc(HttpRequest httpRequest)
        {
            try
            {
                IcCardBll icCardBll = new IcCardBll();
                DataTable dt = icCardBll.QueryPsysDic("证件名称");
                return ConvertToJson.DataTableToJson("zjmc", dt);
            }
            catch (Exception e)
            {
                Log.Error(e);
                return ErrorJson;
            }
        }

        /// <summary>
        /// 获取卡状态
        /// </summary>
        /// <param name="httpRequest"></param>
        /// <returns></returns>
        private string GetKzt(HttpRequest httpRequest)
        {
            try
            {
                IcCardBll icCardBll = new IcCardBll();
                DataTable dt = icCardBll.QueryPsysDic("卡状态");
                return ConvertToJson.DataTableToJson("kzt", dt);
            }
            catch (Exception e)
            {
                Log.Error(e);
                return ErrorJson;
            }
        }

        /// <summary>
        /// 获取卡类型
        /// </summary>
        /// <param name="httpRequest"></param>
        /// <returns></returns>
        private string GetKlx(HttpRequest httpRequest)
        {
            try
            {
                IcCardBll icCardBll = new IcCardBll();
                DataTable dt = icCardBll.QueryPsysDic("卡类型");
                return ConvertToJson.DataTableToJson("klx", dt);
            }
            catch (Exception e)
            {
                Log.Error(e);
                return ErrorJson;
            }
        }

        /// <summary>
        /// 获取充值方式
        /// </summary>
        /// <param name="httpRequest"></param>
        /// <returns></returns>
        private string GetCzfs(HttpRequest httpRequest)
        {
            try
            {
                IcCardBll icCardBll = new IcCardBll();
                DataTable dt = icCardBll.QueryPsysDic("充值方式");
                return ConvertToJson.DataTableToJson("czfs", dt);
            }
            catch (Exception e)
            {
                Log.Error(e);
                return ErrorJson;
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
using System;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;
using ChargingPile.BLL;
using ChargingPile.Model;
using ChargingPile.UI.WEB.Common;
using log4net;

namespace ChargingPile.UI.WEB.WebService
{
    /// <summary>
    /// Summary description for PriceService
    /// </summary>
    public class PriceService : IHttpHandler, IRequiresSessionState
    {
        protected ILog Log = LogManager.GetLogger("PriceManage");
        readonly OprLogBll _oprLogBll = new OprLogBll();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            var action = context.Request.Params["action"];
            var str = string.Empty;
            switch (action)
            {
                case "inittable":
                    str = InitTable(context);
                    break;
                case "addchargprice":
                    str = SaveChargPrice(context);
                    break;
            }

            context.Response.Write(str);
        }

        public string SaveChargPrice(HttpContext context)
        {
            var chargpricebll = new ChargPriceBll();
            var id = context.Request.Params["id"];
            var beforePrice = context.Request.Params["before_price"];
            var afterPrice = context.Request.Params["after_price"];
            var rowname = context.Request.Params["rowname"];
            var chargprice = new ChargPrice
                {
                    Id = id,
                    Price = decimal.Parse(afterPrice) * 100,
                    UpdateDT = DateTime.Now
                };
            try
            {
                chargpricebll.Modify(chargprice);
            }
            catch (Exception e)
            {
                Log.Error(e);
                return "{\"status\":false}"; ;
            }

            //操作日志
            if (null == context.Session[Constant.LoginUser])
            {
                return "{\"total\":0,\"rows\":[],\"status\":\"2\",\"msg\":\"修改成功！\"}";
            }
            var oprlog = new OprLog
            {
                Operator = ((Employer)(context.Session[Constant.LoginUser])).Name,
                OperResult = "成功",
                OprSrc = rowname + "修改前价格:" + beforePrice +
                        "元，" + rowname + "修改后价格:" + afterPrice + "元",
                LogDate = DateTime.Now
            };
            _oprLogBll.Add(oprlog);
            return "{\"status\":true}";
        }

        public string InitTable(HttpContext context)
        {
            var chargpricebll = new ChargPriceBll();
            var chargprice = new ChargPrice();
            var jss = new JavaScriptSerializer();
            string str;
            const int count = 0;
            try
            {
                var dt = chargpricebll.Query(chargprice);
                var list = ConvertHelper<ChargPrice>.ConvertToList(dt);
                str = jss.Serialize(list);
                str = str.Substring(1, str.Length - 2);
                str = "{\"total\":\"" + count + "\",\"rows\":[" + str + "]}";
            }
            catch (Exception e)
            {
                Log.Error(e);
                throw;
            }
            return str;
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
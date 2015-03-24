using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using ChargingPile.UI.WEB.Common;

namespace ChargingPile.UI.WEB.WebService
{
    /// <summary>
    /// Common 的摘要说明
    /// </summary>
    public class Common : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request["action"];
            if (string.IsNullOrEmpty(action))
            {
                return;
            }
            action = action.ToLower();
            if (action.Equals("isoverdue"))
            {
                if (context.Session[Constant.LoginUser] == null)
                {
                    context.Response.Write("location.href='../../Login.aspx';");
                }
            }
            else if (action.Equals("getdate"))
            {
                DateTime now = DateTime.Now;
                string ret = "{\"now\":\"" + now.ToString("yyyy-MM-dd") + "\",\"d1ago\":\"" +
                             now.AddDays(-1).ToString("yyyy-MM-dd") + "\",\"d7ago\":\"" +
                             now.AddDays(-7).ToString("yyyy-MM-dd") + "\"}";
                context.Response.Write(ret);
            }
            else if (action.Equals("getdatetime"))
            {
                DateTime now = DateTime.Now;
                string ret = "{\"now\":\"" + now.ToString("yyyy-MM-dd HH:mm:ss") + "\",\"h1ago\":\"" +
                             now.AddHours(1).ToString("yyyy-MM-dd HH:mm:ss") + "\"}";
                context.Response.Write(ret);
            }
            else
            {
                return;
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
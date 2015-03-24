using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using ChargingPile.Model;
using ChargingPile.BLL;

namespace ChargingPile.UI.WEB.WebService
{
    /// <summary>
    /// Summary description for UseRoleService
    /// </summary>
    public class UseRoleService : IHttpHandler
    {
        protected log4net.ILog Log = log4net.LogManager.GetLogger("UseRoleService");
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            var action = context.Request.Params["action"];
            var sb = new StringBuilder();
            switch (action)
            {
                case "getRole":
                    sb = GetRole(context);
                    break;
              
            }
            context.Response.Write(sb.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public StringBuilder GetRole(HttpContext context)
        {
            var userolebll = new UseRolesBll();
            var str=new StringBuilder();
            var empid = context.Request.Params["Id"];
            var jss = new JavaScriptSerializer();
            try
            {
                var dt = userolebll.FindBy(empid);
                var list = ConvertHelper<UseRoles>.ConvertToList(dt);
                str.Append(jss.Serialize(list));
                //str = str.Substring(1, str.Length - 2);
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
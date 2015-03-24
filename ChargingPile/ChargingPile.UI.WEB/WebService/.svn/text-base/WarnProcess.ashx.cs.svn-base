using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;
using ChargingPile.BLL;
using ChargingPile.Model;
using ChargingPile.UI.WEB.Common;

namespace ChargingPile.UI.WEB.WebService
{
    /// <summary>
    /// WarnProcess 的摘要说明
    /// </summary>
    public class WarnProcess : IHttpHandler, IRequiresSessionState
    {
        readonly JavaScriptSerializer _jss = new JavaScriptSerializer();
        protected log4net.ILog Log = log4net.LogManager.GetLogger("WarnProcess");
        private const string ErrorJson = "{\"total\":0,\"rows\":[],\"status\":\"0\",\"msg\":\"error\"}";

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request["action"] ?? "";
            action = action.ToLower();
            switch (action)
            {
                case "getdata":
                    GetData(context);
                    break;
                case "gjcl":
                    Gjcl(context);
                    break;
                default:
                    context.Response.Write(ErrorJson);
                    break;
            }
        }

        /// <summary>
        /// 查询告警记录
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private void GetData(HttpContext context)
        {
            try
            {
                string yclx = context.Request["yclx"] ?? "";
                yclx = yclx.ToUpper();
                WarnRecBll wrBll = new WarnRecBll();
                int page = int.Parse(context.Request["page"] ?? "1");
                int rows = int.Parse(context.Request["rows"] ?? "10");
                int count = 0;
                DataTable dt = wrBll.QueryByType(yclx, page, rows, ref count);
                List<YxYcErrorProcess> list = ConvertHelper<YxYcErrorProcess>.ConvertToList(dt);
                PageObject<YxYcErrorProcess> pObject = new PageObject<YxYcErrorProcess>(count, list);
                context.Response.Write(_jss.Serialize(pObject));
            }
            catch (Exception e)
            {
                Log.Error(e);
                context.Response.Write(ErrorJson);
            }
        }

        /// <summary>
        /// 灭警
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private void Gjcl(HttpContext context)
        {
            try
            {
                string id = context.Request["id"] ?? "";
                if (id.Length != 0)
                {
                    var wrBll = new WarnRecBll();
                    string name = "";
                    string empId = "";
                    if (null != context.Session[Constant.LoginUser])
                    {
                        name = (context.Session[Constant.LoginUser] as Employer ?? new Employer()).Name;
                        empId = (context.Session[Constant.LoginUser] as Employer ?? new Employer()).Id;
                    }
                    wrBll.Modify(new WarnRec()
                        {
                            Id = id,
                            ProcessFlag = Constant.MjfsSd,
                            ProcessDt = DateTime.Now,
                            ProcesseEp = empId,
                        });
                    new OprLogBll().Add(new OprLog()
                    {
                        Operator = name,
                        OprSrc = "灭警",
                        OperResult = "成功",
                        LogDate = DateTime.Now
                    });
                }
                GetData(context);
            }
            catch (Exception e)
            {
                Log.Error(e);
                context.Response.Write(ErrorJson);
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChargingPile.BLL;
using System.Data;
using ChargingPile.Model;
using ChargingPile.UI.WEB.Common;
using System.Web.Script.Serialization;
using System.Web.SessionState;

namespace ChargingPile.UI.WEB.WebService
{
    /// <summary>
    /// ChargPileCollectionManage 的摘要说明
    /// </summary>
    public class ChargPileCollectionManage : IHttpHandler, IRequiresSessionState
    {
        protected log4net.ILog Log = log4net.LogManager.GetLogger("ChargPileCollectionManage");
        JavaScriptSerializer jss = new JavaScriptSerializer();
        ChargPileCollectionBll cpcbll = new ChargPileCollectionBll();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string action = context.Request["action"];
            if (string.IsNullOrEmpty(action))
            {
                return;
            }
            if (action.Equals("getcpc"))
            {
                GetCPC(context);
            }
            else if (action.Equals("getcollect"))
            {
                GetCollectBYID(context);
            }
            else if (action.Equals("savepzx"))
            {
                try
                {
                    string typeid = context.Request["typeid"].ToString();
                    string pzxs = context.Request["pzxs"].ToString();
                    cpcbll.AddPZX(typeid, pzxs);
                    context.Response.Write("{\"success\":true,\"msg\":\"保存成功！\"}");
                }
                catch (Exception e)
                {
                    Log.Error(e);
                    context.Response.Write("{\"success\":false,\"msg\":\"保存失败！\"}");
                }

            }
        }
        /// <summary>
        /// 查看配置项
        /// </summary>
        /// <param name="context"></param>
        private void GetCollectBYID(HttpContext context)
        {
            string id = context.Request["id"];
            DataTable dt = cpcbll.QueryCollection(id);
            var list = ConvertHelper<GatItem>.ConvertToList(dt);
            PageObject<GatItem> pageO = new PageObject<GatItem>();
            pageO.total = list.Count;
            pageO.rows = list;
            var str = jss.Serialize(pageO);
            context.Response.Write(str);
        }
        /// <summary>
        /// 获取采集项数据
        /// </summary>
        /// <param name="context"></param>
        private void GetCPC(HttpContext context)
        {
            try
            {
                ChargPileCollectionBll cpcbll = new ChargPileCollectionBll();
                DataTable dt = cpcbll.QueryChargPileCollection();
                var list = ConvertHelper<ChargPileTypes>.ConvertToList(dt);
                PageObject<ChargPileTypes> pageO = new PageObject<ChargPileTypes>();
                pageO.total = list.Count;
                pageO.rows = list;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using ChargingPile.BLL;
using System.Data;
using ChargingPile.Model;
using ChargingPile.UI.WEB.Common;
using System.Web.SessionState;

namespace ChargingPile.UI.WEB.WebService
{
    /// <summary>
    /// ChargPileTypeService 的摘要说明
    /// </summary>
    public class ChargPileTypeService : IHttpHandler, IRequiresSessionState
    {
        protected log4net.ILog Log = log4net.LogManager.GetLogger("ChargPileTypeService");
        JavaScriptSerializer jss = new JavaScriptSerializer();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request["action"];
            if (string.IsNullOrEmpty(action))
            {
                return;
            }
            if (action.Equals("getcpt"))
            {
                GetChargPileType(context);
            }
            else if (action.Equals("addtype"))
            {
                AddChargPileType(context);
            }
            else if (action.Equals("edittype"))
            {
                EditChargPileType(context);
            }
            else if (action.Equals("deltype"))
            {
                DelChargPileType(context);
            }
        }
        /// <summary>
        /// 删除充电桩类型
        /// </summary>
        /// <param name="context"></param>
        private void DelChargPileType(HttpContext context)
        {
            try
            {
                string PARSERKEY = context.Request["PARSERKEY"].ToString();
                ChargPileTypeBll cpcbll = new ChargPileTypeBll();
                cpcbll.DelType(PARSERKEY);
                context.Response.Write("{\"success\":true,\"msg\":\"删除成功！\"}");
            }
            catch (Exception e)
            {
                Log.Error(e);
                context.Response.Write("{\"success\":false,\"msg\":\"删除失败！\"}");
            }
        }
        /// <summary>
        /// 修改充电桩类型
        /// </summary>
        /// <param name="context"></param>
        private void EditChargPileType(HttpContext context)
        {
            try
            {
                string PARSERKEY = context.Request["PARSERKEY"].ToString();
                string CHANGJIA = context.Request["CHANGJIA"].ToString();
                string ZHUANGLEI_X = context.Request["ZHUANGLEI_X"].ToString();
                string ZHUANGXING_H = context.Request["ZHUANGXING_H"].ToString();
                string REMARK = context.Request["REMARK"].ToString();
                DateTime CREATEDT = DateTime.Parse(context.Request["CREATEDT"].ToString());
                ChargPileTypes chargtype = new ChargPileTypes();
                chargtype.PARSERKEY = PARSERKEY;
                chargtype.CHANGJIA = CHANGJIA;
                chargtype.ZHUANGLEI_X = ZHUANGLEI_X;
                chargtype.ZHUANGXING_H = ZHUANGXING_H;
                chargtype.REMARK = REMARK;
                chargtype.CREATEDT = CREATEDT;
                chargtype.UPDATEDT = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));

                ChargPileTypeBll cpcbll = new ChargPileTypeBll();
                cpcbll.EditType(chargtype);

                context.Response.Write("{\"success\":true,\"msg\":\"保存成功！\"}");
            }
            catch (Exception e)
            {
                Log.Error(e);
                context.Response.Write("{\"success\":false,\"msg\":\"保存失败！\"}");
            }
        }
        /// <summary>
        /// 添加充电桩类型
        /// </summary>
        /// <param name="context"></param>
        private void AddChargPileType(HttpContext context)
        {
            try
            {
                string PARSERKEY = context.Request["PARSERKEY"].ToString();
                string CHANGJIA = context.Request["CHANGJIA"].ToString();
                string ZHUANGLEI_X = context.Request["ZHUANGLEI_X"].ToString();
                string ZHUANGXING_H = context.Request["ZHUANGXING_H"].ToString();
                string REMARK = context.Request["REMARK"].ToString();
                DateTime CREATEDT = DateTime.Parse(context.Request["CREATEDT"].ToString());
                ChargPileTypes chargtype = new ChargPileTypes();
                chargtype.PARSERKEY = PARSERKEY;
                chargtype.CHANGJIA = CHANGJIA;
                chargtype.ZHUANGLEI_X = ZHUANGLEI_X;
                chargtype.ZHUANGXING_H = ZHUANGXING_H;
                chargtype.REMARK = REMARK;
                chargtype.CREATEDT = CREATEDT;

                ChargPileTypeBll cpcbll = new ChargPileTypeBll();
                cpcbll.AddType(chargtype);

                context.Response.Write("{\"success\":true,\"msg\":\"保存成功！\"}");
            }
            catch (Exception e)
            {
                Log.Error(e);
                context.Response.Write("{\"success\":false,\"msg\":\"保存失败！\"}");
            }
        }
        /// <summary>
        /// 获取充电桩类型
        /// </summary>
        /// <param name="context"></param>
        private void GetChargPileType(HttpContext context)
        {
            try
            {
                ChargPileTypeBll cpcbll = new ChargPileTypeBll();
                DataTable dt = cpcbll.QueryChargPileType();
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
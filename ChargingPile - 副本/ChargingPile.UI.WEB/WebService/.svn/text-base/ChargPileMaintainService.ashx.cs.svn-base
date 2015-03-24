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
    /// ChargPileMaintainService 的摘要说明
    /// </summary>
    public class ChargPileMaintainService : IHttpHandler, IRequiresSessionState
    {
        protected log4net.ILog Log = log4net.LogManager.GetLogger("ChargPileCollectionManage");
        JavaScriptSerializer jss = new JavaScriptSerializer();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string action = context.Request["action"];
            if (string.IsNullOrEmpty(action))
            {
                return;
            }
            if (action.Equals("getstation"))
            {
                GetStation(context);
            }
            else if (action.Equals("getyxbh"))
            {
                GetYXBH(context);
            }
            else if (action.Equals("getcjlx"))
            {
                GetCJLX(context);
            }
            else if (action.Equals("getjl"))
            {
                GetJXJL(context);
            }
            else if (action.Equals("getpilejl"))
            {
                GetPileJL(context);
            }
            else if (action.Equals("addjl"))
            {
                AddJXJL(context);
            }
            else if (action.Equals("editjl"))
            {
                EditJXJL(context);
            }
            else if (action.Equals("deljl"))
            {
                DelJXJL(context);
            }
            else if(action.Equals("getjxlx"))
            {
                GetJXLX(context);
            }
            else if (action.Equals("getjxjb"))
            {
                GetJXJB(context);
            }
            else if (action.Equals("getzyxbh"))
            {
                Getzyxbh(context);
            }
        }
        /// <summary>
        /// 根据桩编号查询运行编号
        /// </summary>
        /// <param name="context"></param>
        private void Getzyxbh(HttpContext context)
        {
            try
            {
                string zhuan_bh = context.Request["zhuang_bh"].ToString();
                ChargPileMainTainBll cpmtbll = new ChargPileMainTainBll();
                DataTable dt = cpmtbll.QueryZYunxingbh(zhuan_bh);
                var list = ConvertHelper<ChargPile>.ConvertToList(dt);
                PageObject<ChargPile> pageO = new PageObject<ChargPile>();
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
        /// <summary>
        /// 分页查询桩运维记录
        /// </summary>
        /// <param name="context"></param>
        private void GetPileJL(HttpContext context)
        {
            try
            {
                //获取分页数据
                int page = 1, rows = 10, total = 0;
                string tmp = context.Request["page"].ToString();
                if (!string.IsNullOrEmpty(tmp))
                {
                    page = int.Parse(tmp);
                }
                tmp = context.Request["rows"].ToString();
                if (!string.IsNullOrEmpty(tmp))
                {
                    rows = int.Parse(tmp);
                }

                string zhanbh = context.Request["zhanbh"].ToString();
                string zhuangbh = context.Request["zhuangbh"].ToString();

                DateTime begintime = new DateTime();
                string sj = context.Request["begintime"] ?? "";
                if (sj.Length > 0)
                {
                    begintime = DateTime.Parse(sj);
                }
                DateTime endtime = new DateTime();
                string ej = context.Request["endtime"] ?? "";
                if (ej.Length > 0)
                {
                    endtime = DateTime.Parse(ej);
                }
                string jxlx = context.Request["jxlx"].ToString();

                ChargPileMainTainBll cpmtbll = new ChargPileMainTainBll();
                List<ChargPileJianXiuJL> jxjlList = cpmtbll.GetJxjlList(zhanbh, zhuangbh, begintime, endtime, jxlx, page, rows, ref total);
                PageObject<ChargPileJianXiuJL> pageO = new PageObject<ChargPileJianXiuJL>();
                pageO.total = total;
                pageO.rows = jxjlList;
                var str = jss.Serialize(pageO);
                context.Response.Write(str);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
        /// <summary>
        /// 获取检修级别
        /// </summary>
        /// <param name="context"></param>
        private void GetJXJB(HttpContext context)
        {
            try
            {
                string codename = "检修级别";
                ChargPileMainTainBll cpmtbll = new ChargPileMainTainBll();
                DataTable dt = cpmtbll.QueryCode(codename);
                var list = ConvertHelper<CodeInfo>.ConvertToList(dt);
                PageObject<CodeInfo> pageO = new PageObject<CodeInfo>();
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
        /// <summary>
        /// 获取检修类型
        /// </summary>
        /// <param name="context"></param>
        private void GetJXLX(HttpContext context)
        {
            try
            {
                string codename = "检修类型";
                ChargPileMainTainBll cpmtbll = new ChargPileMainTainBll();
                DataTable dt = cpmtbll.QueryCode(codename);
                var list = ConvertHelper<CodeInfo>.ConvertToList(dt);
                PageObject<CodeInfo> pageO = new PageObject<CodeInfo>();
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
        /// <summary>
        /// 删除检修记录
        /// </summary>
        /// <param name="context"></param>
        private void DelJXJL(HttpContext context)
        {
            try
            {
                string id = context.Request["id"].ToString();
                ChargPileMainTainBll cpcbll = new ChargPileMainTainBll();
                cpcbll.Delete(id);
                //操作日志
                string name = "";
                if (null != context.Session[Constant.LoginUser])
                {
                    name = (context.Session[Constant.LoginUser] as Employer ?? new Employer()).Name;
                }
                else
                {
                    context.Response.Write("{\"success\":true,\"msg\":\"删除成功！\"}");
                }
                new OprLogBll().Add(new OprLog()
                {
                    Operator =name,
                    OprSrc = "删除充电桩检修记录，记录id：" + id,
                    OperResult = "成功",
                    LogDate = DateTime.Now
                });
                context.Response.Write("{\"success\":true,\"msg\":\"删除成功！\"}");
            }
            catch (Exception e)
            {
                Log.Error(e);
                context.Response.Write("{\"success\":false,\"msg\":\"删除失败！\"}");
            }
        }
        /// <summary>
        /// 修改检修记录
        /// </summary>
        /// <param name="context"></param>
        private void EditJXJL(HttpContext context)
        {
            try
            {
                string id = context.Request["id"].ToString();
                string zhanBh = context.Request["ZHUAN_MC"];
                string YUNXING_BH = context.Request["YUNXING_BH"].ToString();
                string JIANXIU_LX = context.Request["JIANXIU_LX"].ToString();
                string JIANXIU_JB = context.Request["JIANXIU_JB"].ToString();
                string JIANXIU_JL = context.Request["JIANXIU_JL"].ToString();
                string JIANXIU_R = context.Request["JIANXIU_R"].ToString();
                DateTime UPDATEDT = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                string sj = context.Request["JIANXIU_SJ"] ?? "";
                DateTime JIANXIU_SJ = new DateTime();
                if (sj.Length > 0)
                {
                    JIANXIU_SJ = DateTime.Parse(sj);
                }
                ChargPileJianXiuJL chargpile = new ChargPileJianXiuJL();
                chargpile.Id = id;
                chargpile.ZhanBh = zhanBh;
                chargpile.YunXing_Bh = YUNXING_BH;
                chargpile.JianXiu_Lx = JIANXIU_LX;
                chargpile.JianXiu_Jb = JIANXIU_JB;
                chargpile.JianXiu_Jl = JIANXIU_JL;
                chargpile.JianXiu_R = JIANXIU_R;
                chargpile.JianXiu_Sj = JIANXIU_SJ;
                chargpile.UpdateDt = UPDATEDT;

                ChargPileMainTainBll cpbll = new ChargPileMainTainBll();
                
                cpbll.EditJianXiuJL(chargpile);
                //操作日志
                string name = "";
                if (null != context.Session[Constant.LoginUser])
                {
                    name = (context.Session[Constant.LoginUser] as Employer ?? new Employer()).Name;
                }
                else
                {
                    context.Response.Write("{\"success\":true,\"msg\":\"保存成功！\"}");
                }
                new OprLogBll().Add(new OprLog()
                {
                    Operator = name,
                    OprSrc = "修改充电桩检修记录，记录id：" + id,
                    OperResult = "成功",
                    LogDate = DateTime.Now
                });
                context.Response.Write("{\"success\":true,\"msg\":\"保存成功！\"}");
            }
            catch (Exception e)
            {
                Log.Error(e);
                context.Response.Write("{\"success\":false,\"msg\":\"保存失败！\"}");
            }
        }
        /// <summary>
        /// 添加检修记录
        /// </summary>
        /// <param name="context"></param>
        private void AddJXJL(HttpContext context)
        {
            try
            {
                string zhanBh = context.Request["ZHUAN_MC"];
                string YUNXING_BH = context.Request["YUNXING_BH"].ToString();
                string JIANXIU_LX = context.Request["JIANXIU_LX"].ToString();
                string JIANXIU_JB = context.Request["JIANXIU_JB"].ToString();
                string JIANXIU_JL = context.Request["JIANXIU_JL"].ToString();
                string JIANXIU_R = context.Request["JIANXIU_R"].ToString();
                DateTime CREATEDT = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                string sj = context.Request["JIANXIU_SJ"] ?? "";
                DateTime JIANXIU_SJ = new DateTime();
                if (sj.Length > 0)
                {
                    JIANXIU_SJ = DateTime.Parse(sj);
                }
                ChargPileJianXiuJL chargpile = new ChargPileJianXiuJL();
                chargpile.ZhanBh = zhanBh;
                chargpile.YunXing_Bh = YUNXING_BH;
                chargpile.JianXiu_Lx = JIANXIU_LX;
                chargpile.JianXiu_Jb = JIANXIU_JB;
                chargpile.JianXiu_Jl = JIANXIU_JL;
                chargpile.JianXiu_R = JIANXIU_R;
                chargpile.JianXiu_Sj = JIANXIU_SJ;
                chargpile.CreateDt = CREATEDT;

                ChargPileMainTainBll cpbll = new ChargPileMainTainBll();
                cpbll.AddJianXiuJL(chargpile);
                //操作日志
                string name = "";
                if (null != context.Session[Constant.LoginUser])
                {
                    name = (context.Session[Constant.LoginUser] as Employer ?? new Employer()).Name;
                }
                else
                {
                    context.Response.Write("{\"success\":true,\"msg\":\"保存成功！\"}");
                }
                new OprLogBll().Add(new OprLog()
                {
                    Operator = name,
                    OprSrc = "添加充电桩检修记录",
                    OperResult = "成功",
                    LogDate = DateTime.Now
                });
                context.Response.Write("{\"success\":true,\"msg\":\"保存成功！\"}");
            }
            catch (Exception e)
            {
                Log.Error(e);
                context.Response.Write("{\"success\":false,\"msg\":\"保存失败！\"}");
            }
        }
        /// <summary>
        /// 查询检修记录
        /// </summary>
        /// <param name="context"></param>
        private void GetJXJL(HttpContext context)
        {
            try
            {
                int page = 1, rows = 10, total = 0;
                string tmp = context.Request["page"].ToString();
                if (!string.IsNullOrEmpty(tmp))
                {
                    page = int.Parse(tmp);
                }
                tmp = context.Request["rows"].ToString();
                if (!string.IsNullOrEmpty(tmp))
                {
                    rows = int.Parse(tmp);
                }

                string zhanbh = context.Request["zhanbh"].ToString();
                string zhuangbh = context.Request["zhuangbh"].ToString();
                DateTime begintime = new DateTime();
                string sj = context.Request["begintime"] ?? "";
                if (sj.Length > 0)
                {
                    begintime = DateTime.Parse(sj);
                }
                DateTime endtime = new DateTime();
                string ej = context.Request["endtime"] ?? "";
                if (ej.Length > 0)
                {
                    endtime = DateTime.Parse(ej);
                }
                string jxlx = context.Request["jxlx"].ToString();

                ChargPileMainTainBll cpmtbll = new ChargPileMainTainBll();
                List<ChargPileJianXiuJL> jxjlList = cpmtbll.GetJxjlList(zhanbh,zhuangbh, begintime, endtime, jxlx, page, rows, ref total);
                PageObject<ChargPileJianXiuJL> pageO = new PageObject<ChargPileJianXiuJL>();
                pageO.total = total;
                pageO.rows = jxjlList;
                var str = jss.Serialize(pageO);
                context.Response.Write(str);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
        /// <summary>
        /// 获取厂家和类型
        /// </summary>
        /// <param name="context"></param>
        private void GetCJLX(HttpContext context)
        {
            try
            {
                string yxbh = context.Request["yxbh"].ToString();
                string zhanBh = context.Request["zhanbh"];
                ChargPileMainTainBll cpmtbll = new ChargPileMainTainBll();
                DataTable dt = cpmtbll.QueryCJLX(yxbh,zhanBh);
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
        /// <summary>
        /// 获取运行编号
        /// </summary>
        /// <param name="context"></param>
        private void GetYXBH(HttpContext context)
        {
            try
            {
                string zhuan_bh = context.Request["zhuan_bh"].ToString();
                ChargPileMainTainBll cpmtbll = new ChargPileMainTainBll();
                DataTable dt = cpmtbll.QueryYunxingbh(zhuan_bh);
                var list = ConvertHelper<ChargPile>.ConvertToList(dt);
                PageObject<ChargPile> pageO = new PageObject<ChargPile>();
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
        /// <summary>
        /// 获取充电站
        /// </summary>
        /// <param name="context"></param>
        private void GetStation(HttpContext context)
        {
            try
            {
                ChargPileMainTainBll cpmtbll = new ChargPileMainTainBll();
                DataTable dt = cpmtbll.QueryChargStation();
                var list = ConvertHelper<ChargStation>.ConvertToList(dt);
                PageObject<ChargStation> pageO = new PageObject<ChargStation>();
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
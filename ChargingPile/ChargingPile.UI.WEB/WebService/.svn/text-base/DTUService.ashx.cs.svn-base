using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using ChargingPile.BLL;
using ChargingPile.Model;
using ChargingPile.UI.WEB.Common;
using System.Web.SessionState;
using System.Data;

namespace ChargingPile.UI.WEB.WebService
{
    /// <summary>
    /// DTUService 的摘要说明
    /// </summary>
    public class DTUService : IHttpHandler, IRequiresSessionState
    {
        protected log4net.ILog Log = log4net.LogManager.GetLogger("DTUService");
        JavaScriptSerializer jss = new JavaScriptSerializer();
        DTUBll dtubll = new DTUBll();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string action = context.Request["action"];
            if (string.IsNullOrEmpty(action))
            {
                return;
            }
            if (action.Equals("getdtu"))
            {
                GetDtu(context);
            }
            else if (action.Equals("getunit"))
            {
                GetUnit(context);
            }
            else if (action.Equals("save"))
            {
                SaveUnit(context);
            }
            else if(action.Equals("adddtu"))
            {
                AddDTU(context);
            }
            else if(action.Equals("deldtu"))
            {
                DelDTU(context);
            }
            else if (action.Equals("editdtu"))
            {
                EditDTU(context);
            }
            else if (action.Equals("gettxwarn"))
            {
                GetTXWarn(context);
            }
            else if (action.Equals("gettdwarn"))
            {
                GetTDWarn(context);
            }
            else if (action.Equals("getcardwarn"))
            {
                GetCardWarn(context);
            }
            else if (action.Equals("getworklog"))
            {
                //接收分页数据
                int page = 1, rows = 15, total = 0;
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
                //接收参数
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

                List<OprLog> dtuList = dtubll.GetWorkLogList(begintime, endtime, page, rows, ref total);
                PageObject<OprLog> pageO = new PageObject<OprLog>();
                pageO.total = total;
                pageO.rows = dtuList;
                var str = jss.Serialize(pageO);
                context.Response.Write(str);
            }

        }
        /// <summary>
        /// 查询卡异常告警
        /// </summary>
        /// <param name="context"></param>
        private void GetCardWarn(HttpContext context)
        {
            //接收分页数据
            int page = 1, rows = 15, total = 0;
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
            //接收参数
            string zhanbh = context.Request["zhanbh"].ToString();
            string yxbh = context.Request["yxbh"].ToString();
            string protype = context.Request["processtype"].ToString();
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

            List<WarnRec> dtuList = dtubll.GetCardWarnList(zhanbh, yxbh, protype, begintime, endtime, page, rows, ref total);

            var worknum = ((Employer)(context.Session[Constant.LoginUser])).WorkNum;
            foreach (var li in dtuList)
            {
                li.WorkNum = worknum;
            }

            PageObject<WarnRec> pageO = new PageObject<WarnRec>();
            pageO.total = total;
            pageO.rows = dtuList;
            var str = jss.Serialize(pageO);
            context.Response.Write(str);
        }
        /// <summary>
        /// 查询通信告警
        /// </summary>
        /// <param name="context"></param>
        private void GetTXWarn(HttpContext context)
        {
            //接收分页数据
            int page = 1, rows = 15, total = 0;
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
            //接收参数
            string zhanbh = context.Request["zhanbh"].ToString();
            string protype = context.Request["processtype"].ToString();
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

            List<WarnRec> dtuList = dtubll.GetTXWarnList(zhanbh, protype, begintime, endtime, page, rows, ref total);

            var worknum = ((Employer)(context.Session[Constant.LoginUser])).WorkNum;
            foreach (var li in dtuList)
            {
                li.WorkNum = worknum;
            }

            PageObject<WarnRec> pageO = new PageObject<WarnRec>();
            pageO.total = total;
            pageO.rows = dtuList;
            var str = jss.Serialize(pageO);
            context.Response.Write(str);
        }
        /// <summary>
        /// 查询停电告警
        /// </summary>
        /// <param name="context"></param>
        private void GetTDWarn(HttpContext context)
        {
            //接收分页数据
            int page = 1, rows = 15, total = 0;
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
            //接收参数
            string zhanbh = context.Request["zhanbh"].ToString();
            string protype = context.Request["processtype"].ToString();
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

            List<WarnRec> dtuList = dtubll.GetTDWarnList(zhanbh, protype, begintime, endtime, page, rows, ref total);

            var worknum = ((Employer)(context.Session[Constant.LoginUser])).WorkNum;
            foreach (var li in dtuList)
            {
                li.WorkNum = worknum;
            }

            PageObject<WarnRec> pageO = new PageObject<WarnRec>();
            pageO.total = total;
            pageO.rows = dtuList;
            var str = jss.Serialize(pageO);
            context.Response.Write(str);
        }
        /// <summary>
        /// 修改dtu
        /// </summary>
        /// <param name="context"></param>
        private void EditDTU(HttpContext context)
        {
            try
            {
                string id = context.Request["id"].ToString();
                
                decimal zhanbh = decimal.Parse(context.Request["ZHUAN_MC"].ToString());
                DataTable dt = dtubll.QueryBYdtuid(id);
                if (dt.Rows.Count > 0)
                {
                    var qZhanbh =decimal.Parse(dt.Rows[0]["DEV_CHARGPILE"].ToString().Substring(0,3));
                    if (qZhanbh != zhanbh)
                    {
                        context.Response.Write("{\"success\":false,\"msg\":\"此DTU关联了充电桩，不能改变其所属场站！\"}");
                        return;
                    }
                }
                string serid = context.Request["SERVERID"].ToString();
                string dtuid = context.Request["DTUID"].ToString();
                string dtuxh = context.Request["DTUTYPE"].ToString();
                string dtuname = context.Request["DTUNAME"].ToString();
                string sim = context.Request["PHONE"].ToString();
                string spswd = context.Request["SVRPWD"].ToString();
                DTUInfo dtu = new DTUInfo();
                dtu.ID = id;
                dtu.ZHUAN_BH = zhanbh;
                dtu.SERVERID = serid;
                dtu.DTUID = dtuid;
                dtu.DTUTYPE = dtuxh;
                dtu.DTUNAME = dtuname;
                dtu.PHONE = sim;
                dtu.SVRPWD = spswd;
                dtubll.EditDTU(dtu);

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
                    OprSrc = "修改DTU设备，id：" + id,
                    OperResult = "成功",
                    LogDate = DateTime.Now
                });

                context.Response.Write("{\"success\":true,\"msg\":\"保存成功！\"}");
            }
            catch (Exception e)
            {
                Log.Debug(e);
                context.Response.Write("{\"success\":false,\"msg\":\"保存失败！\"}");
            }
        }
        /// <summary>
        /// 删除dtu
        /// </summary>
        /// <param name="context"></param>
        private void DelDTU(HttpContext context)
        {
            try
            {
                string id = context.Request["id"].ToString();
                DataTable dt = dtubll.QueryBYdtuid(id);
                if(dt.Rows.Count>0)
                {
                    context.Response.Write("{\"success\":false,\"msg\":\"此DTU关联了充电桩，不能删除！\"}");
                    return;
                }
                dtubll.DelDTU(id);

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
                    Operator = name,
                    OprSrc = "删除DTU设备，id：" + id,
                    OperResult = "成功",
                    LogDate = DateTime.Now
                });

                context.Response.Write("{\"success\":true,\"msg\":\"删除成功！\"}");
            }
            catch (Exception e)
            {
                Log.Debug(e);
                context.Response.Write("{\"success\":false,\"msg\":\"删除失败！\"}");
            }
        }
        /// <summary>
        /// 添加dtu
        /// </summary>
        /// <param name="context"></param>
        private void AddDTU(HttpContext context)
        {
            try
            {
                decimal zhanbh = decimal.Parse(context.Request["ZHUAN_MC"].ToString());
                string serid = context.Request["SERVERID"].ToString();
                string dtuid = context.Request["DTUID"].ToString();
                string dtuxh = context.Request["DTUTYPE"].ToString();
                string dtuname = context.Request["DTUNAME"].ToString();
                string sim = context.Request["PHONE"].ToString();
                string spswd = context.Request["SVRPWD"].ToString();
                string id = Guid.NewGuid().ToString();
                DTUInfo dtu = new DTUInfo();
                dtu.ID = id;
                dtu.ZHUAN_BH = zhanbh;
                dtu.SERVERID = serid;
                dtu.DTUID = dtuid;
                dtu.DTUTYPE = dtuxh;
                dtu.DTUNAME = dtuname;
                dtu.PHONE = sim;
                dtu.SVRPWD = spswd;
                dtubll.AddDTU(dtu);

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
                    OprSrc = "添加DTU设备，id：" + id,
                    OperResult = "成功",
                    LogDate = DateTime.Now
                });

                context.Response.Write("{\"success\":true,\"msg\":\"保存成功！\"}");
            }
            catch (Exception e)
            {
                Log.Debug(e);
                context.Response.Write("{\"success\":false,\"msg\":\"保存失败！\"}");
            }
        }
        /// <summary>
        /// 保存dtu和桩的关系
        /// </summary>
        /// <param name="context"></param>
        private void SaveUnit(HttpContext context)
        {
            try
            {
                string dtuid = context.Request["dtuid"].ToString();
                string pileid = context.Request["pileid"].ToString();
                dtubll.AddUnit(dtuid, pileid);
                context.Response.Write("{\"success\":true,\"msg\":\"保存成功！\"}");
            }
            catch (Exception e)
            {
                Log.Error(e);
                context.Response.Write("{\"success\":false,\"msg\":\"保存失败！\"}");
            }
        }
        /// <summary>
        /// 查询dtu和桩的关系
        /// </summary>
        /// <param name="context"></param>
        private void GetUnit(HttpContext context)
        {
            string dtuid = context.Request["dtuid"].ToString();
            decimal zhanid = decimal.Parse(context.Request["zhanid"].ToString());

            DataTable dt = dtubll.QueryUnit(dtuid, zhanid);
            var list = ConvertHelper<ChargPile>.ConvertToList(dt);
            PageObject<ChargPile> pageO = new PageObject<ChargPile>();
            pageO.total = list.Count;
            pageO.rows = list;
            var str = jss.Serialize(pageO);
            context.Response.Write(str);
        }
        /// <summary>
        /// 查询dtu
        /// </summary>
        /// <param name="context"></param>
        private void GetDtu(HttpContext context)
        {
            //接收分页数据
            int page = 1, rows = 15, total = 0;
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

            List<DTUInfo> dtuList = dtubll.GetDTUList(zhanbh, page, rows, ref total);
            PageObject<DTUInfo> pageO = new PageObject<DTUInfo>();
            pageO.total = total;
            pageO.rows = dtuList;
            var str = jss.Serialize(pageO);
            context.Response.Write(str);
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
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
    /// ChargPileService 的摘要说明
    /// </summary>
    public class ChargPileService : IHttpHandler, IRequiresSessionState
    {
        protected log4net.ILog Log = log4net.LogManager.GetLogger("ChargPileCollectionManage");
        JavaScriptSerializer jss = new JavaScriptSerializer();
        ChargStationBll csbll = new ChargStationBll();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request["action"];
            if (string.IsNullOrEmpty(action))
            {
                return;
            }
            if (action.Equals("getcp"))
            {
                GetChargPile(context);
            }
            else if (action.Equals("addpile"))
            {
                AddChargPile(context);
            }
            else if (action.Equals("editpile"))
            {
                EditChargPile(context);
            }
            else if (action.Equals("delpile"))
            {
                DelChargPile(context);
            }
            else if (action.Equals("getbox"))
            {
                GetBranch(context);
            }
            else if (action.Equals("getcj"))
            {
                GetChangJia(context);
            }
            else if (action.Equals("getcj1"))
            {
                GetChangJia1(context);
            }
            else if (action.Equals("getxh"))
            {
                GetXingHao(context);
            }
            else if (action.Equals("getxh1"))
            {
                GetXingHao1(context);
            }
            else if (action.Equals("getlx"))
            {
                GetLeiXing(context);
            }

        }
        /// <summary>
        /// 根据桩型号获取桩类型
        /// </summary>
        /// <param name="context"></param>
        private void GetLeiXing(HttpContext context)
        {
            try
            {
                ChargPileBll cpbll = new ChargPileBll();
                string xh = context.Request["xh"].ToString();
                string cj = context.Request["cj"].ToString();
                DataTable dt = cpbll.QueryLXBYXH(xh,cj);
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
        /// 根据桩厂家获取桩型号
        /// </summary>
        /// <param name="context"></param>
        private void GetXingHao1(HttpContext context)
        {
            try
            {
                ChargPileBll cpbll = new ChargPileBll();
                string cj = context.Request["cj"].ToString();
                DataTable dt = cpbll.QueryXHBYCJ(cj);
                var list = ConvertHelper<ChargPileTypes>.ConvertToList(dt);
                var str = jss.Serialize(list);
                context.Response.Write(str);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
        /// <summary>
        /// 根据桩厂家获取桩型号
        /// </summary>
        /// <param name="context"></param>
        private void GetXingHao(HttpContext context)
        {
            try
            {
                ChargPileBll cpbll = new ChargPileBll();
                string cj = context.Request["cj"].ToString();
                DataTable dt = cpbll.QueryXHBYCJ(cj);
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
        /// 获取桩厂家
        /// </summary>
        /// <param name="context"></param>
        private void GetChangJia1(HttpContext context)
        {
            try
            {
                ChargPileBll cpbll = new ChargPileBll();
                DataTable dt = cpbll.QueryChangJia();
                var list = ConvertHelper<ChargPileTypes>.ConvertToList(dt);
                var str = jss.Serialize(list);
                context.Response.Write(str);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
        /// <summary>
        /// 获取桩厂家
        /// </summary>
        /// <param name="context"></param>
        private void GetChangJia(HttpContext context)
        {
            try
            {
                ChargPileBll cpbll = new ChargPileBll();
                DataTable dt = cpbll.QueryChangJia();
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
        /// 根据充电站获取分支箱
        /// </summary>
        /// <param name="context"></param>
        private void GetBranch(HttpContext context)
        {
            try
            {
                string zhanbh = context.Request["zhanbh"].ToString();
                ChargPileBll cpbll = new ChargPileBll();
                DataTable dt = cpbll.QueryBranch(zhanbh);
                var list = ConvertHelper<Branch>.ConvertToList(dt);
                PageObject<Branch> pageO = new PageObject<Branch>();
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
        /// 根据桩id删除充电桩
        /// </summary>
        /// <param name="context"></param>
        private void DelChargPile(HttpContext context)
        {
            try
            {
                string chargPileId = context.Request["pileid"].ToString();
                ChargPileBll cpbll = new ChargPileBll();
                cpbll.DelChargPile(chargPileId);


                decimal zhanbh = decimal.Parse(chargPileId.ToString().Substring(0, 3));

                //保存桩厂家和装类型到充电站表里
                DataTable dtable = csbll.QueryTypes(zhanbh);
                List<string> listcj = new List<string>();
                List<string> listlx = new List<string>();

                for (int i = 0; i < dtable.Rows.Count; i++)
                {
                    if (listcj.Count <= 0)
                    {
                        listcj.Add(dtable.Rows[i]["CHANGJIA"].ToString());

                    }
                    else
                    {
                        for (int j = 0; j < listcj.Count; j++)
                        {
                            if (listcj[j] == dtable.Rows[i]["CHANGJIA"].ToString())
                            { break; }
                            if (j == listcj.Count - 1)
                            {
                                listcj.Add(dtable.Rows[i]["CHANGJIA"].ToString());
                            }
                        }
                    }
                }
                for (int i = 0; i < dtable.Rows.Count; i++)
                {
                    if (listlx.Count <= 0)
                    {
                        listlx.Add(dtable.Rows[i]["ZHUANGLEI_X"].ToString());

                    }
                    else
                    {
                        for (int j = 0; j < listlx.Count; j++)
                        {
                            if (listlx[j] == dtable.Rows[i]["ZHUANGLEI_X"].ToString())
                            { break; }
                            if (j == listlx.Count - 1)
                            {
                                listlx.Add(dtable.Rows[i]["ZHUANGLEI_X"].ToString());
                            }
                        }
                    }
                }

                string cj = "";
                string zlx = "";

                for (int i = 0; i < listcj.Count; i++)
                {
                    cj += listcj[i].ToString();
                    if (i < listcj.Count - 1)
                    {
                        cj += ",";
                    }
                }
                for (int i = 0; i < listlx.Count; i++)
                {
                    zlx += listlx[i].ToString();
                    if (i < listlx.Count - 1)
                    {
                        zlx += ",";
                    }
                }
                ChargStation cstion = new ChargStation();
                cstion.ZhuangLeiX = zlx;
                cstion.ZhuangChangJ = cj;
                cstion.ZhanBh = zhanbh;
                csbll.SaveZhan(cstion);


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
                    OprSrc = "删除充电桩,桩id：" + chargPileId,
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
        /// 修改充电桩
        /// </summary>
        /// <param name="context"></param>
        private void EditChargPile(HttpContext context)
        {
            try
            {
                ChargPileBll cpbll = new ChargPileBll();
                int pileID = int.Parse(context.Request["pileID"].ToString());
                int BOX_ID = int.Parse(context.Request["BOX_ID"].ToString());
                string CHANGJIAO_BH = context.Request["CHANGJIAO_BH"].ToString();
                string YUNXING_BH = context.Request["YUNXING_BH"].ToString();
                DataTable dt = cpbll.QueryPileByYXBH(YUNXING_BH);
                if (dt.Rows.Count > 0 && !int.Parse(dt.Rows[0]["DEV_CHARGPILE"].ToString()).Equals(pileID))
                {
                    context.Response.Write("{\"success\":false,\"msg\":\"运行编号已存在！\"}");
                    return;
                }
                string CHANGJIA = context.Request["CHANGJIA"].ToString();
                string ZHUANGXING_H = context.Request["ZHUANGXING_H"].ToString();
                string ZHUANGLEI_X = context.Request["ZHUANGLEI_X"].ToString();
                string ZHUANGTAI = context.Request["ZHUANGTAI"].ToString();
                string sj = context.Request["TOUYOU_SJ"] ?? "";
                DateTime TOUYOU_SJ = new DateTime();
                if (sj.Length > 0)
                {
                    TOUYOU_SJ = DateTime.Parse(sj);
                }
                ChargPile chargpile = new ChargPile();
                chargpile.DEV_CHARGPILE = pileID;
                chargpile.BOX_ID = BOX_ID;
                chargpile.CHANGJIAO_BH = CHANGJIAO_BH;
                chargpile.YUNXING_BH = YUNXING_BH;
                chargpile.CHANGJIA = CHANGJIA;
                chargpile.ZHUANGXING_H = ZHUANGXING_H;
                chargpile.ZHUANGLEI_X = ZHUANGLEI_X;
                chargpile.ZHUANGTAI = ZHUANGTAI;
                chargpile.TOUYOU_SJ = TOUYOU_SJ;

                cpbll.EditChargPile(chargpile);


                decimal zhanbh = decimal.Parse(pileID.ToString().Substring(0, 3));

                //保存桩厂家和装类型到充电站表里
                DataTable dtable = csbll.QueryTypes(zhanbh);
                List<string> listcj = new List<string>();
                List<string> listlx = new List<string>();

                for (int i = 0; i < dtable.Rows.Count; i++)
                {
                    if (listcj.Count <= 0)
                    {
                        listcj.Add(dtable.Rows[i]["CHANGJIA"].ToString());

                    }
                    else
                    {
                        for (int j = 0; j < listcj.Count; j++)
                        {
                            if (listcj[j] == dtable.Rows[i]["CHANGJIA"].ToString())
                            { break; }
                            if (j == listcj.Count - 1)
                            {
                                listcj.Add(dtable.Rows[i]["CHANGJIA"].ToString());
                            }
                        }
                    }
                }
                for (int i = 0; i < dtable.Rows.Count; i++)
                {
                    if (listlx.Count <= 0)
                    {
                        listlx.Add(dtable.Rows[i]["ZHUANGLEI_X"].ToString());

                    }
                    else
                    {
                        for (int j = 0; j < listlx.Count; j++)
                        {
                            if (listlx[j] == dtable.Rows[i]["ZHUANGLEI_X"].ToString())
                            { break; }
                            if (j == listlx.Count - 1)
                            {
                                listlx.Add(dtable.Rows[i]["ZHUANGLEI_X"].ToString());
                            }
                        }
                    }
                }

                string cj = "";
                string zlx = "";

                for (int i = 0; i < listcj.Count; i++)
                {
                    cj += listcj[i].ToString();
                    if (i < listcj.Count - 1)
                    {
                        cj += ",";
                    }
                }
                for (int i = 0; i < listlx.Count; i++)
                {
                    zlx += listlx[i].ToString();
                    if (i < listlx.Count - 1)
                    {
                        zlx += ",";
                    }
                }
                ChargStation cstion = new ChargStation();
                cstion.ZhuangLeiX = zlx;
                cstion.ZhuangChangJ = cj;
                cstion.ZhanBh = zhanbh;
                csbll.SaveZhan(cstion);


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
                    OprSrc = "修改充电桩,桩id：" + pileID,
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
        /// 添加充电桩
        /// </summary>
        /// <param name="context"></param>
        private void AddChargPile(HttpContext context)
        {
            try
            {
                ChargPileBll cpbll = new ChargPileBll();
                int BOX_ID = int.Parse(context.Request["BOX_ID"].ToString());
                string CHANGJIAO_BH = context.Request["CHANGJIAO_BH"].ToString();
                string YUNXING_BH = context.Request["YUNXING_BH"].ToString();
                DataTable dt = cpbll.QueryPileByYXBH(YUNXING_BH);
                if(dt.Rows.Count>0)
                {
                    context.Response.Write("{\"success\":false,\"msg\":\"运行编号已存在！\"}");
                    return;
                }
                string CHANGJIA = context.Request["CHANGJIA"].ToString();
                string ZHUANGXING_H = context.Request["ZHUANGXING_H"].ToString();
                string ZHUANGLEI_X = context.Request["ZHUANGLEI_X"].ToString();
                string ZHUANGTAI = context.Request["ZHUANGTAI"].ToString();
                string sj = context.Request["TOUYOU_SJ"] ?? "";
                DateTime TOUYOU_SJ = new DateTime();
                if (sj.Length > 0)
                {
                    TOUYOU_SJ = DateTime.Parse(sj);
                }
                ChargPile chargpile = new ChargPile();
                chargpile.BOX_ID = BOX_ID;
                chargpile.CHANGJIAO_BH = CHANGJIAO_BH;
                chargpile.YUNXING_BH = YUNXING_BH;
                chargpile.CHANGJIA = CHANGJIA;
                chargpile.ZHUANGXING_H = ZHUANGXING_H;
                chargpile.ZHUANGLEI_X = ZHUANGLEI_X;
                chargpile.ZHUANGTAI = ZHUANGTAI;
                chargpile.TOUYOU_SJ = TOUYOU_SJ;

                cpbll.AddChargPile(chargpile);

                decimal zhanbh = decimal.Parse(BOX_ID.ToString().Substring(0, 3));

                //保存桩厂家和装类型到充电站表里
                DataTable dtable = csbll.QueryTypes(zhanbh);
                List<string> listcj = new List<string>();
                List<string> listlx = new List<string>();

                for (int i = 0; i < dtable.Rows.Count; i++)
                {
                    if (listcj.Count <= 0)
                    {
                        listcj.Add(dtable.Rows[i]["CHANGJIA"].ToString());

                    }
                    else
                    {
                        for (int j = 0; j < listcj.Count; j++)
                        {
                            if (listcj[j] == dtable.Rows[i]["CHANGJIA"].ToString())
                            { break; }
                            if (j == listcj.Count - 1)
                            {
                                listcj.Add(dtable.Rows[i]["CHANGJIA"].ToString());
                            }
                        }
                    }
                }
                for (int i = 0; i < dtable.Rows.Count; i++)
                {
                    if (listlx.Count <= 0)
                    {
                        listlx.Add(dtable.Rows[i]["ZHUANGLEI_X"].ToString());

                    }
                    else
                    {
                        for (int j = 0; j < listlx.Count; j++)
                        {
                            if (listlx[j] == dtable.Rows[i]["ZHUANGLEI_X"].ToString())
                            { break; }
                            if (j == listlx.Count - 1)
                            {
                                listlx.Add(dtable.Rows[i]["ZHUANGLEI_X"].ToString());
                            }
                        }
                    }
                }

                string cj = "";
                string zlx = "";

                for (int i = 0; i < listcj.Count; i++)
                {
                    cj += listcj[i].ToString();
                    if (i < listcj.Count - 1)
                    {
                        cj += ",";
                    }
                }
                for (int i = 0; i < listlx.Count; i++)
                {
                    zlx += listlx[i].ToString();
                    if (i < listlx.Count - 1)
                    {
                        zlx += ",";
                    }
                }
                ChargStation cstion = new ChargStation();
                cstion.ZhuangLeiX = zlx;
                cstion.ZhuangChangJ = cj;
                cstion.ZhanBh = zhanbh;
                csbll.SaveZhan(cstion);


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
                    Operator =name,
                    OprSrc = "保存充电桩",
                    OperResult = "成功",
                    TargetDev = BOX_ID,
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
        /// 获取充电桩
        /// </summary>
        /// <param name="context"></param>
        private void GetChargPile(HttpContext context)
        {
            try
            {

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
                decimal zhanbh = decimal.Parse(context.Request["zhanbh"].ToString());
                ChargPileBll cpbll = new ChargPileBll();
                List<ChargPile> personnelList = cpbll.GetChargPileList(zhanbh, page, rows, ref total);
                PageObject<ChargPile> pageO = new PageObject<ChargPile>();
                pageO.total = total;
                pageO.rows = personnelList;
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
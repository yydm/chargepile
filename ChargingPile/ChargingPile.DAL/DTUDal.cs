using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChargingPile.Model;
using System.Data;

namespace ChargingPile.DAL
{
    public class DTUDal:BaseDal<DTUInfo>
    {
        /// <summary>
        /// 添加DTU
        /// </summary>
        /// <param name="bean"></param>
        public void AddDTU(DTUInfo bean)
        {
            Log.Debug("Add方法参数：" + bean.ToString());
            var sql1 = new StringBuilder();
            var sql2 = new StringBuilder();
            var i = 0;
            var list = new List<object>();
            if (!string.IsNullOrEmpty(bean.ID))
            {
                sql1.Append(" ID,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.ID);
            }
            if (!string.IsNullOrEmpty(bean.SERVERID))
            {
                sql1.Append(" SERVERID,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.SERVERID);
            }
            if (bean.ZHUAN_BH != null)
            {
                sql1.Append(" ZHUAN_BH,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.ZHUAN_BH);
            }
            if (!string.IsNullOrEmpty(bean.DTUID))
            {
                sql1.Append(" DTUID,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.DTUID);
            }
            if (!string.IsNullOrEmpty(bean.DTUTYPE))
            {
                sql1.Append(" DTUTYPE,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.DTUTYPE);
            }
            if (!string.IsNullOrEmpty(bean.DTUNAME))
            {
                sql1.Append(" DTUNAME,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.DTUNAME);
            }
            if (!string.IsNullOrEmpty(bean.PHONE))
            {
                sql1.Append(" PHONE,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.PHONE);
            }
            if (!string.IsNullOrEmpty(bean.SVRPWD))
            {
                sql1.Append(" SVRPWD,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.SVRPWD);
            }
            if (sql1.Length > 0)
            {
                sql1 = sql1.Remove(sql1.Length - 1, 1);
                sql2 = sql2.Remove(sql2.Length - 1, 1);
            }
            var sql = "insert into dev_dtu(" + sql1 + ",CREATEDT) values(" + sql2 + ",sysdate)";
            Oop.Execute(sql, list.ToArray());
        }
        /// <summary>
        /// 删除dtu
        /// </summary>
        /// <param name="id"></param>
        public void DelDTU(string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" delete from dev_dtu where ID={0}");
            object[] parameters = new object[] {
                id
            };
            try
            {
                Oop.Execute(strSql.ToString(), parameters);
            }
            catch (Exception e)
            {
                Log.Error("删除dtu设备失败！", e);
            }
        }
        /// <summary>
        /// 修改dtu
        /// </summary>
        /// <param name="bean"></param>
        public void EditDTU(DTUInfo bean)
        {
            Log.Debug("Modify方法参数：" + bean.ToString());
            StringBuilder sql = new StringBuilder();
            sql.Append(" update dev_dtu set ");
            var i = 0;
            var dList = new List<object>();
            if (!string.IsNullOrEmpty(bean.SERVERID))
            {
                sql.Append(" SERVERID={" + i++ + "},");
                dList.Add(bean.SERVERID);
            }
            if (bean.ZHUAN_BH!=null)
            {
                sql.Append(" ZHUAN_BH={" + i++ + "},");
                dList.Add(bean.ZHUAN_BH);
            }
            if (!string.IsNullOrEmpty(bean.DTUID))
            {
                sql.Append(" DTUID={" + i++ + "},");
                dList.Add(bean.DTUID);
            }
            if (!string.IsNullOrEmpty(bean.DTUNAME))
            {
                sql.Append(" DTUNAME={" + i++ + "},");
                dList.Add(bean.DTUNAME);
            }
            if (!string.IsNullOrEmpty(bean.PHONE))
            {
                sql.Append(" PHONE={" + i++ + "},");
                dList.Add(bean.PHONE);
            }
            if (!string.IsNullOrEmpty(bean.SVRPWD))
            {
                sql.Append(" SVRPWD={" + i++ + "},");
                dList.Add(bean.SVRPWD);
            }
            if (sql.Length > 0)
            {
                sql = sql.Remove(sql.Length - 1, 1);
            }
            sql.Append(" ,UPDATEDT=sysdate where ID={" + i++ + "}");
            dList.Add(bean.ID);
            Log.Debug("SQL :" + sql + ",params:" + dList.ToString());
            Oop.Execute(sql.ToString(), dList.ToArray());
        }
        /// <summary>
        /// 查询dtu
        /// </summary>
        /// <param name="bean"></param>
        /// <returns></returns>
        public DataTable QueryDTU(DTUInfo bean)
        {
            Log.Debug("Query方法参数：" + bean);
            var sql = new StringBuilder();
            sql.Append("select t.* from dev_dtu t where 1=1 ");
            var list = new List<object>();
            var i = -1;
            if (!string.IsNullOrEmpty(bean.ID))
            {
                sql.Append(" and ID={" + ++i + "}");
                list.Add(bean.ID);
            }
            if (!string.IsNullOrEmpty(bean.SERVERID))
            {
                sql.Append(" and SERVERID={" + ++i + "}");
                list.Add(bean.SERVERID);
            }
            if (bean.ZHUAN_BH!=null)
            {
                sql.Append(" and ZHUAN_BH={" + ++i + "}");
                list.Add(bean.ZHUAN_BH);
            }
            if (!string.IsNullOrEmpty(bean.DTUID))
            {
                sql.Append(" and DTUID={" + ++i + "}");
                list.Add(bean.DTUID);
            }
            if (!string.IsNullOrEmpty(bean.DTUTYPE))
            {
                sql.Append(" and DTUTYPE={" + ++i + "}");
                list.Add(bean.DTUTYPE);
            }
            if (!string.IsNullOrEmpty(bean.DTUNAME))
            {
                sql.Append(" and DTUNAME={" + ++i + "}");
                list.Add(bean.DTUNAME);
            }
            if (!string.IsNullOrEmpty(bean.PHONE))
            {
                sql.Append(" and PHONE={" + ++i + "}");
                list.Add(bean.PHONE);
            }
            if (!string.IsNullOrEmpty(bean.SVRPWD))
            {
                sql.Append(" and SVRPWD={" + ++i + "}");
                list.Add(bean.SVRPWD);
            }
            if (!string.IsNullOrEmpty(bean.DTUSTATUS))
            {
                sql.Append(" and DTUSTATUS={" + ++i + "}");
                list.Add(bean.DTUSTATUS);
            }
            return Oop.GetDataTable(sql.ToString(), list.ToArray());
        }
        /// <summary>
        /// 获取卡异常使用告警信息
        /// </summary>
        /// <param name="zhanbh"></param>
        /// <param name="yxbh"></param>
        /// <param name="protype"></param>
        /// <param name="begintime"></param>
        /// <param name="endtime"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public List<WarnRec> GetCardWarnList(string zhanbh,string yxbh, string protype, DateTime begintime, DateTime endtime, int page, int rows, ref int total)
        {
            List<WarnRec> dtulist = new List<WarnRec>();
            DataTable dt1 = GetCardWarn(zhanbh,yxbh, protype, begintime, endtime, page, rows);
            DataTable dt2 = GetCardWarnTotal(zhanbh,yxbh, protype, begintime, endtime);
            total = dt2.Rows.Count;
            if (dt1.Rows.Count > 0)
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    WarnRec bean = new WarnRec();
                    DataRow dr = dt1.Rows[i];
                    bean.Id = dr["ID"].ToString();
                    if (dr["OCCURDT"].ToString() != "")
                        bean.Occurdt = DateTime.Parse(dr["OCCURDT"].ToString());
                    if (dr["PROCESSFLAG"].ToString() != "")
                        bean.ProcessFlag = int.Parse(dr["PROCESSFLAG"].ToString());
                    if (dr["WARNFLAG"].ToString() != "")
                        bean.WarnFlag = int.Parse(dr["WARNFLAG"].ToString());
                    bean.ZHANMC = dr["zhanmc"].ToString();
                    bean.YUNXING_BH = dr["yunxing_bh"].ToString();
                    bean.TARGETDATAKEY = dr["TARGETDATAKEY"].ToString();
                    bean.TargetDev = dr["TargetDev"].ToString();
                    bean.DataItemId = dr["DataItemId"].ToString();
                    dtulist.Add(bean);
                }
            }
            return dtulist;
        }
        /// <summary>
        /// 分页查询卡异常使用告警信息
        /// </summary>
        /// <param name="zhanbh"></param>
        /// <param name="yxbh"></param>
        /// <param name="protype"></param>
        /// <param name="begintime"></param>
        /// <param name="endtime"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public DataTable GetCardWarn(string zhanbh,string yxbh, string protype, DateTime begintime, DateTime endtime, int page, int rows)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select B.* from (select A.*,rownum rn from (select a.*,c.zhuan_mc as zhanmc,d.yunxing_bh as yunxing_bh  from oth_warnrec a, ");
            strSql.Append(" dev_chargstation c,dev_chargpile d,dev_branch e  ");
            strSql.Append(" where a.targettype='003' and a.targetdev=d.dev_chargpile and d.box_id=e.branchno and e.zhuan_bh=c.zhan_bh  ");
            var i = -1;
            List<object> list = new List<object>();
            if (!string.IsNullOrEmpty(zhanbh))
            {
                strSql.Append(" and c.ZHAN_BH={" + ++i + "} ");
                list.Add(zhanbh);
            }
            if (!string.IsNullOrEmpty(yxbh))
            {
                strSql.Append(" and d.YUNXING_BH={" + ++i + "} ");
                list.Add(yxbh);
            }
            if (!string.IsNullOrEmpty(protype))
            {
                strSql.Append(" and a.PROCESSFLAG={" + ++i + "} ");
                list.Add(protype);
            }
            if (begintime != new DateTime() && endtime != new DateTime())
            {
                strSql.Append(" and a.occurdt between {" + ++i + "} and {" + ++i + "} ");
                list.AddRange(new object[] { begintime, endtime.AddDays(1) });
            }
            strSql.Append(" order by a.occurdt desc ");
            strSql.Append(" ) A where rownum<='" + page + "'*'" + rows + "') B where rn>('" + page + "'-1)*'" + rows + "' ");

            DataTable dt = new DataTable();
            try
            {
                dt = Oop.GetDataTable(strSql.ToString(), list.ToArray());
            }
            catch (Exception e)
            {
                Log.Error("查询卡异常告警失败！", e);
            }
            return dt;
        }
        /// <summary>
        /// 查询卡使用异常告警总数
        /// </summary>
        /// <param name="zhanbh"></param>
        /// <param name="protype"></param>
        /// <param name="begintime"></param>
        /// <param name="endtime"></param>
        /// <returns></returns>
        public DataTable GetCardWarnTotal(string zhanbh,string yxbh, string protype, DateTime begintime, DateTime endtime)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select a.*,c.zhuan_mc as zhanmc,d.yunxing_bh as yunxing_bh  from oth_warnrec a, ");
            strSql.Append(" dev_chargstation c,dev_chargpile d,dev_branch e  ");
            strSql.Append(" where a.targettype='003' and a.targetdev=d.dev_chargpile and d.box_id=e.branchno and e.zhuan_bh=c.zhan_bh  ");
            var i = -1;
            List<object> list = new List<object>();
            if (!string.IsNullOrEmpty(zhanbh))
            {
                strSql.Append(" and c.ZHAN_BH={" + ++i + "} ");
                list.Add(zhanbh);
            }
            if (!string.IsNullOrEmpty(yxbh))
            {
                strSql.Append(" and d.YUNXING_BH={" + ++i + "} ");
                list.Add(yxbh);
            }
            if (!string.IsNullOrEmpty(protype))
            {
                strSql.Append(" and a.PROCESSFLAG={" + ++i + "} ");
                list.Add(protype);
            }
            if (begintime != new DateTime() && endtime != new DateTime())
            {
                strSql.Append(" and a.occurdt between {" + ++i + "} and {" + ++i + "} ");
                list.AddRange(new object[] { begintime, endtime.AddDays(1) });
            }
            strSql.Append(" order by a.occurdt desc ");
            DataTable dt = new DataTable();
            try
            {
                dt = Oop.GetDataTable(strSql.ToString(), list.ToArray());
            }
            catch (Exception e)
            {
                Log.Error("查询卡异常告警失败！", e);
            }
            return dt;
        }
        /// <summary>
        /// 获取停电告警信息
        /// </summary>
        /// <param name="zhanbh"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public List<WarnRec> GetTDWarnList(string zhanbh, string protype, DateTime begintime, DateTime endtime, int page, int rows, ref int total)
        {
            List<WarnRec> dtulist = new List<WarnRec>();
            DataTable dt1 = GetTDWarn(zhanbh, protype, begintime, endtime, page, rows);
            DataTable dt2 = GetTDWarnTotal(zhanbh, protype, begintime, endtime);
            total = dt2.Rows.Count;
            if (dt1.Rows.Count > 0)
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    WarnRec bean = new WarnRec();
                    DataRow dr = dt1.Rows[i];
                    bean.Id = dr["ID"].ToString();
                    if (dr["OCCURDT"].ToString() != "")
                        bean.Occurdt = DateTime.Parse(dr["OCCURDT"].ToString());
                    if (dr["PROCESSFLAG"].ToString() != "")
                        bean.ProcessFlag = int.Parse(dr["PROCESSFLAG"].ToString());
                    if (dr["WARNFLAG"].ToString() != "")
                        bean.WarnFlag = int.Parse(dr["WARNFLAG"].ToString());
                    bean.ZHANMC = dr["zhanmc"].ToString();
                    bean.TargetDev = dr["TargetDev"].ToString();
                    bean.DataItemId = dr["DataItemId"].ToString();
                    dtulist.Add(bean);
                }
            }
            return dtulist;
        }

        /// <summary>
        /// 查询停电告警
        /// </summary>
        /// <param name="zhanbh"></param>
        /// <param name="protype"></param>
        /// <param name="begintime"></param>
        /// <param name="endtime"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public DataTable GetTDWarn(string zhanbh, string protype, DateTime begintime, DateTime endtime, int page, int rows)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select B.* from (select A.*,rownum rn from (select a.*,c.zhuan_mc as zhanmc from oth_warnrec a,dev_chargstation c  ");
            strSql.Append(" where a.targettype='001' and a.targetdev=c.ZHAN_BH ");
            var i = -1;
            List<object> list = new List<object>();
            if (!string.IsNullOrEmpty(zhanbh))
            {
                strSql.Append(" and c.ZHAN_BH={" + ++i + "} ");
                list.Add(zhanbh);
            }
            if (!string.IsNullOrEmpty(protype))
            {
                strSql.Append(" and a.PROCESSFLAG={" + ++i + "} ");
                list.Add(protype);
            }
            if (begintime != new DateTime() && endtime != new DateTime())
            {
                strSql.Append(" and a.occurdt between {" + ++i + "} and {" + ++i + "} ");
                list.AddRange(new object[] { begintime, endtime.AddDays(1) });
            }
            strSql.Append(" order by a.occurdt desc ");
            strSql.Append(" ) A where rownum<='" + page + "'*'" + rows + "') B where rn>('" + page + "'-1)*'" + rows + "' ");

            DataTable dt = new DataTable();
            try
            {
                dt = Oop.GetDataTable(strSql.ToString(), list.ToArray());
            }
            catch (Exception e)
            {
                Log.Error("查询停电告警失败！", e);
            }
            return dt;
        }
        /// <summary>
        /// 查询停电告警总数
        /// </summary>
        /// <param name="zhanbh"></param>
        /// <param name="protype"></param>
        /// <param name="begintime"></param>
        /// <param name="endtime"></param>
        /// <returns></returns>
        public DataTable GetTDWarnTotal(string zhanbh, string protype, DateTime begintime, DateTime endtime)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select a.*,c.zhuan_mc as zhanmc from oth_warnrec a,dev_chargstation c  ");
            strSql.Append(" where a.targettype='001' and a.targetdev=c.zhan_bh ");
            var i = -1;
            List<object> list = new List<object>();
            if (!string.IsNullOrEmpty(zhanbh))
            {
                strSql.Append(" and c.ZHAN_BH={" + ++i + "} ");
                list.Add(zhanbh);
            }
            if (!string.IsNullOrEmpty(protype))
            {
                strSql.Append(" and a.PROCESSFLAG={" + ++i + "} ");
                list.Add(protype);
            }
            if (begintime != new DateTime() && endtime != new DateTime())
            {
                strSql.Append(" and a.occurdt between {" + ++i + "} and {" + ++i + "} ");
                list.AddRange(new object[] { begintime, endtime.AddDays(1) });
            }
            strSql.Append(" order by a.occurdt desc ");
            DataTable dt = new DataTable();
            try
            {
                dt = Oop.GetDataTable(strSql.ToString(), list.ToArray());
            }
            catch (Exception e)
            {
                Log.Error("查询停电告警失败！", e);
            }
            return dt;
        }
        /// <summary>
        /// 获取运行日志
        /// </summary>
        /// <param name="begintime"></param>
        /// <param name="endtime"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public List<OprLog> GetWorkLogList(DateTime begintime, DateTime endtime, int page, int rows, ref int total)
        {
            List<OprLog> loglist = new List<OprLog>();
            DataTable dt1 = GetWorkLog(begintime, endtime, page, rows);
            DataTable dt2 = GetWorkLogTotal(begintime, endtime);
            total = dt2.Rows.Count;
            if (dt1.Rows.Count > 0)
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    OprLog bean = new OprLog();
                    DataRow dr = dt1.Rows[i];
                    bean.Id = dr["ID"].ToString();
                    if (dr["logdate"].ToString() != "")
                        bean.LogDate = DateTime.Parse(dr["logdate"].ToString());
                    bean.Worknum = dr["worknum"].ToString();
                    bean.Operator = dr["operator"].ToString();
                    bean.OprSrc = dr["oprsrc"].ToString();
                    loglist.Add(bean);
                }
            }
            return loglist;
        }
        /// <summary>
        /// 查询运行日志
        /// </summary>
        /// <param name="begintime"></param>
        /// <param name="endtime"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public DataTable GetWorkLog(DateTime begintime, DateTime endtime, int page, int rows)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select B.* from (select A.*,rownum rn from (select a.*,b.worknum from oth_oprlog a, t_employer b  ");
            strSql.Append(" where a.operator=b.name  ");
            var i = -1;
            List<object> list = new List<object>();
            if (begintime != new DateTime() && endtime != new DateTime())
            {
                strSql.Append(" and a.logdate between {" + ++i + "} and {" + ++i + "} ");
                list.AddRange(new object[] { begintime, endtime.AddDays(1) });
            }
            strSql.Append(" order by a.logdate desc ");
            strSql.Append(" ) A where rownum<='" + page + "'*'" + rows + "') B where rn>('" + page + "'-1)*'" + rows + "' ");

            DataTable dt = new DataTable();
            try
            {
                dt = Oop.GetDataTable(strSql.ToString(), list.ToArray());
            }
            catch (Exception e)
            {
                Log.Error("查询运行日志失败！", e);
            }
            return dt;
        }
        /// <summary>
        /// 查询运行日志总数
        /// </summary>
        /// <param name="begintime"></param>
        /// <param name="endtime"></param>
        /// <returns></returns>
        public DataTable GetWorkLogTotal(DateTime begintime, DateTime endtime)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select a.*,b.worknum from oth_oprlog a, t_employer b  ");
            strSql.Append(" where a.operator=b.name  ");
            var i = -1;
            List<object> list = new List<object>();
            if (begintime != new DateTime() && endtime != new DateTime())
            {
                strSql.Append(" and a.logdate between {" + ++i + "} and {" + ++i + "} ");
                list.AddRange(new object[] { begintime, endtime.AddDays(1) });
            }
            strSql.Append(" order by a.logdate desc ");
            DataTable dt = new DataTable();
            try
            {
                dt = Oop.GetDataTable(strSql.ToString(), list.ToArray());
            }
            catch (Exception e)
            {
                Log.Error("查询运行日志失败！", e);
            }
            return dt;
        }
        /// <summary>
        /// 获取通信告警信息
        /// </summary>
        /// <param name="zhanbh"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public List<WarnRec> GetTXWarnList(string zhanbh, string protype, DateTime begintime, DateTime endtime, int page, int rows, ref int total)
        {
            List<WarnRec> dtulist = new List<WarnRec>();
            DataTable dt1 = GetTXWarn(zhanbh, protype, begintime, endtime, page, rows);
            DataTable dt2 = GetTXWarnTotal(zhanbh, protype, begintime, endtime);
            total = dt2.Rows.Count;
            if (dt1.Rows.Count > 0)
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    WarnRec bean = new WarnRec();
                    DataRow dr = dt1.Rows[i];
                    bean.Id = dr["ID"].ToString();
                    if (dr["OCCURDT"].ToString()!="")
                        bean.Occurdt =DateTime.Parse(dr["OCCURDT"].ToString());
                    if (dr["PROCESSFLAG"].ToString()!="")
                        bean.ProcessFlag =int.Parse(dr["PROCESSFLAG"].ToString());
                    if (dr["WARNFLAG"].ToString() != "")
                        bean.WarnFlag = int.Parse(dr["WARNFLAG"].ToString());
                    bean.ZHANMC = dr["zhanmc"].ToString();
                    bean.DTUMC = dr["dtumc"].ToString();
                    bean.TargetDev = dr["TargetDev"].ToString();
                    bean.DataItemId = dr["DataItemId"].ToString();
                    dtulist.Add(bean);
                }
            }
            return dtulist;
        }

        /// <summary>
        /// 查询通信告警
        /// </summary>
        /// <param name="zhanbh"></param>
        /// <param name="protype"></param>
        /// <param name="begintime"></param>
        /// <param name="endtime"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public DataTable GetTXWarn(string zhanbh, string protype, DateTime begintime, DateTime endtime, int page, int rows)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select B.* from (select A.*,rownum rn from (select a.*,b.dtuname as dtumc,c.zhuan_mc as zhanmc from oth_warnrec a,dev_dtu b,dev_chargstation c  ");
            strSql.Append(" where a.targettype='002' and a.targetdev=b.dtuid and b.zhuan_bh=c.zhan_bh ");
            var i = -1;
            List<object> list = new List<object>();
            if (!string.IsNullOrEmpty(zhanbh))
            {
                strSql.Append(" and b.ZHUAN_BH={" + ++i + "} ");
                list.Add(zhanbh);
            }
            if (!string.IsNullOrEmpty(protype))
            {
                strSql.Append(" and a.PROCESSFLAG={" + ++i + "} ");
                list.Add(protype);
            }
            if (begintime != new DateTime() && endtime != new DateTime())
            {
                strSql.Append(" and a.occurdt between {" + ++i + "} and {" + ++i + "} ");
                list.AddRange(new object[] { begintime, endtime.AddDays(1) });
            }
            strSql.Append(" order by a.occurdt desc ");
            strSql.Append(" ) A where rownum<='" + page + "'*'" + rows + "') B where rn>('" + page + "'-1)*'" + rows + "' ");

            DataTable dt = new DataTable();
            try
            {
                dt = Oop.GetDataTable(strSql.ToString(), list.ToArray());
            }
            catch (Exception e)
            {
                Log.Error("查询通信告警失败！", e);
            }
            return dt;
        }
        /// <summary>
        /// 查询通信告警总数
        /// </summary>
        /// <param name="zhanbh"></param>
        /// <param name="protype"></param>
        /// <param name="begintime"></param>
        /// <param name="endtime"></param>
        /// <returns></returns>
        public DataTable GetTXWarnTotal(string zhanbh, string protype, DateTime begintime, DateTime endtime)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select a.*,b.dtuname as dtuname,c.zhuan_mc as zhanmc from oth_warnrec a,dev_dtu b,dev_chargstation c  ");
            strSql.Append(" where a.targettype='002' and a.targetdev=b.dtuid and b.zhuan_bh=c.zhan_bh ");
            var i = -1;
            List<object> list = new List<object>();
            if (!string.IsNullOrEmpty(zhanbh))
            {
                strSql.Append(" and b.ZHUAN_BH={" + ++i + "} ");
                list.Add(zhanbh);
            }
            if (!string.IsNullOrEmpty(protype))
            {
                strSql.Append(" and a.PROCESSFLAG={" + ++i + "} ");
                list.Add(protype);
            }
            if (begintime != new DateTime() && endtime != new DateTime())
            {
                strSql.Append(" and a.occurdt between {" + ++i + "} and {" + ++i + "} ");
                list.AddRange(new object[] { begintime, endtime.AddDays(1) });
            }
            strSql.Append(" order by a.occurdt desc ");
            DataTable dt = new DataTable();
            try
            {
                dt = Oop.GetDataTable(strSql.ToString(), list.ToArray());
            }
            catch (Exception e)
            {
                Log.Error("查询通信告警失败！", e);
            }
            return dt;
        }

        /// <summary>
        /// 查询dtu显示list
        /// </summary>
        /// <param name="zhanbh"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public List<DTUInfo> GetDTUList(string zhanbh,int page,int rows,ref int total) 
        {
            List<DTUInfo> dtulist = new List<DTUInfo>();
            DataTable dt1 = GetDTU(zhanbh, page, rows);
            DataTable dt2 = GetDTUTotal(zhanbh);
            total = dt2.Rows.Count;
            if (dt1.Rows.Count > 0)
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    DTUInfo bean = new DTUInfo();
                    DataRow dr = dt1.Rows[i];
                    bean.ID = dr["ID"].ToString();
                    bean.SERVERID = dr["SERVERID"].ToString();
                    bean.DTUID = dr["DTUID"].ToString();
                    bean.DTUTYPE = dr["DTUTYPE"].ToString();
                    bean.DTUNAME = dr["DTUNAME"].ToString();
                    bean.PHONE = dr["PHONE"].ToString();
                    bean.SVRPWD = dr["SVRPWD"].ToString();
                    bean.ZHUAN_BH = decimal.Parse(dr["ZHUAN_BH"].ToString());
                    bean.ZHAN_MC = dr["ZHAN_MC"].ToString();
                    bean.PILECOUNTS = dr["PILECOUNTS"].ToString();
                    bean.CREATEDT = DateTime.Parse(dr["CREATEDT"].ToString());
                    dtulist.Add(bean);
                }
            }
            return dtulist;
        }


        /// <summary>
        /// 获取dtu数据
        /// </summary>
        /// <param name="zhanbh"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public DataTable GetDTU(string zhanbh,int page,int rows) 
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select B.* from (select A.*,rownum rn from (select a.*,(select b.ZHAN_JC from dev_chargstation b ");
            strSql.Append(" where a.ZHUAN_BH=b.ZHAN_BH) as ZHAN_MC, (select count(c.dev_chargpile) from dev_chargpile c where c.dtu_id = a.id) as PILECOUNTS ");
            strSql.Append(" from dev_dtu a  where 1=1 ");
            var i = -1;
            List<object> list = new List<object>();
            if (!string.IsNullOrEmpty(zhanbh))
            {
                strSql.Append(" and a.ZHUAN_BH={" + ++i + "} ");
                list.Add(zhanbh);
            }
            strSql.Append(" order by a.CREATEDT desc ");
            strSql.Append(" ) A where rownum<='" + page + "'*'" + rows + "') B where rn>('" + page + "'-1)*'" + rows + "' ");

            DataTable dt = new DataTable();
            try
            {
                dt = Oop.GetDataTable(strSql.ToString(), list.ToArray());
            }
            catch (Exception e)
            {
                Log.Error("查询DTU失败！", e);
            }
            return dt;
        }
        /// <summary>
        /// 查询dtu总数
        /// </summary>
        /// <param name="zhanbh"></param>
        /// <returns></returns>
        public DataTable GetDTUTotal(string zhanbh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select a.*,(select b.ZHUAN_MC from dev_chargstation b where a.ZHUAN_BH=b.ZHAN_BH) as ZHAN_MC ");
            strSql.Append(" from dev_dtu a  where 1=1 ");
            var i = -1;
            List<object> list = new List<object>();
            if (!string.IsNullOrEmpty(zhanbh))
            {
                strSql.Append(" and a.ZHUAN_BH={" + ++i + "} ");
                list.Add(zhanbh);
            }
            strSql.Append(" order by a.CREATEDT desc ");
            DataTable dt = new DataTable();
            try
            {
                dt = Oop.GetDataTable(strSql.ToString(), list.ToArray());
            }
            catch (Exception e)
            {
                Log.Error("查询DTU失败！", e);
            }
            return dt;
        }

        public override bool Exist(DTUInfo bean)
        {
            throw new NotImplementedException();
        }

        public override void Add(DTUInfo bean)
        {
            throw new NotImplementedException();
        }

        public override void Del(DTUInfo bean)
        {
            throw new NotImplementedException();
        }

        public override void Modify(DTUInfo bean)
        {
            throw new NotImplementedException();
        }

        public override System.Data.DataTable Query(DTUInfo bean)
        {
            throw new NotImplementedException();
        }

        public override System.Data.DataTable QueryByPage(DTUInfo bean, int page, int rows)
        {
            throw new NotImplementedException();
        }

        public override System.Data.DataTable QueryByPage(DTUInfo bean, int page, int rows, ref int count)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 查询UNIT
        /// </summary>
        /// <param name="dtuid"></param>
        /// <param name="zhanid"></param>
        /// <returns></returns>
        public DataTable QueryUnit(string dtuid,decimal zhanid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select a.*,(select 1 from dev_dtu c where c.id=a.dtu_id and c.id='" + dtuid + "' ) note  ");
            strSql.Append(" from dev_chargpile a,dev_branch b where a.box_id=b.branchno and b.zhuan_bh='" + zhanid + "' and a.deleteflag is null ");
            strSql.Append(" and ( a.dtu_id='" + dtuid + "' or a.dtu_id is null) order by a.dev_chargpile ");
            return Oop.GetDataTable(strSql.ToString());
        }
        /// <summary>
        /// 查询DTU关联的充电桩
        /// </summary>
        /// <param name="dtuid"></param>
        /// <returns></returns>
        public DataTable GetDTUUnid(string dtuid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select b.* from dev_chargpile b where b.dtu_id='"+dtuid+"'");
            DataTable dt = new DataTable();
            try
            {
                dt = Oop.GetDataTable(strSql.ToString());
            }
            catch (Exception e)
            {
                Log.Error("查询DTU关联的充电桩失败！", e);
            }
            return dt;
        }
        /// <summary>
        /// 检查dtu和桩关系是否存在
        /// </summary>
        /// <param name="dtuid"></param>
        /// <param name="pileid"></param>
        /// <returns></returns>
        public DataTable CheckDTUUnid(string dtuid,string pileid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select b.* from dev_chargpile b where b.dtu_id='" + dtuid + "' and b.dev_chargpile='"+pileid+"' ");
            DataTable dt = new DataTable();
            try
            {
                dt = Oop.GetDataTable(strSql.ToString());
            }
            catch (Exception e)
            {
                Log.Error("查询DTU关联的充电桩失败！", e);
            }
            return dt;
        }
        /// <summary>
        /// 添加DTU关联的充电桩
        /// </summary>
        /// <param name="bean"></param>
        public void AddDTUUnit(string dtuid,string pileid)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" update dev_chargpile set dtu_id='" + dtuid + "' where dev_chargpile='" + pileid + "' ");
            try
            {
                Oop.Execute(sql.ToString()); 
            }
            catch (Exception e)
            {
                Log.Error("添加DTU关联的充电桩失败！", e);
            }
            
        }
        /// <summary>
        /// 删除DTU关联的充电桩
        /// </summary>
        /// <param name="dtuid"></param>
        /// <param name="pileid"></param>
        public void DelDTUUnit(string dtuid, string pileid)
        {
            dtuid = "";
            StringBuilder sql = new StringBuilder();
            sql.Append(" update dev_chargpile set dtu_id='" + dtuid + "' where dev_chargpile='" + pileid + "' ");
            try
            {
                Oop.Execute(sql.ToString());
            }
            catch (Exception e)
            {
                Log.Error("删除DTU关联的充电桩失败！", e);
            }

        }

    }
}

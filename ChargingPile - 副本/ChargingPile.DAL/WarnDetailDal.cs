using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ChargingPile.Model;

namespace ChargingPile.DAL
{
    public class WarnDetailDal : BaseDal<WarnDetail>
    {
        public override bool Exist(WarnDetail bean)
        {
            Log.Debug("exist方法" + bean);
            var sql = "select * from gat_warndetail t where Id='" + bean.Id + "'";
            Log.Debug("SQL :" + sql);
            var dt = Oop.GetDataTable(sql);
            return dt.Rows.Count > 0;
        }

        public override void Add(WarnDetail bean)
        {
            Log.Debug("Add方法参数：" + bean.ToString());
            var sql1 = new StringBuilder();
            var sql2 = new StringBuilder();
            var i = 0;
            var list = new List<object>();
            if (!string.IsNullOrEmpty(bean.Id))
            {
                sql1.Append(" Id,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.Id);
            }
            if (!string.IsNullOrEmpty(bean.WarnId))
            {
                sql1.Append(" WarnId,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.WarnId);
            }
            if (!string.IsNullOrEmpty(bean.GatherId))
            {
                sql1.Append(" GatherId,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.GatherId);
            }
            if (!string.IsNullOrEmpty(bean.Address))
            {
                sql1.Append(" Address,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.Address);
            }
            if (bean.IsSuccess != null)
            {
                sql1.Append(" IsSuccess,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.IsSuccess);
            }
            if (bean.SendDT != null)
            {
                sql1.Append(" SendDT,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.SendDT);
            }
            if (string.IsNullOrEmpty(bean.WarnContext))
            {
                sql1.Append(" WarnContext,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.WarnContext);
            }
            if (string.IsNullOrEmpty(bean.WarnType))
            {
                sql1.Append(" WarnType,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.WarnType);
            }
            if (bean.ProcessFlag != null)
            {
                sql1.Append(" ProcessFlag,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.ProcessFlag);
            }
            if (bean.CreateDT != null)
            {
                sql1.Append(" CreateDT,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.CreateDT);
            }
            if (sql1.Length > 0)
            {
                sql1 = sql1.Remove(sql1.Length - 1, 1);
                sql2 = sql2.Remove(sql2.Length - 1, 1);
            }

            var sql = "insert into gat_warndetail(" + sql1 + ") values(" + sql2 + ")";
            Log.Debug("SQL :" + sql + ",params:" + list.ToString());
            Oop.Execute(sql, list.ToArray());
        }

        public override void Del(WarnDetail bean)
        {
            Log.Debug("del方法参数：" + bean);
            var sql = "delete from gat_warndetail where Id='" + bean.Id + "'";
            Log.Debug("SQL :" + sql);
            Oop.Execute(sql);
        }

        public override void Modify(WarnDetail bean)
        {
            Log.Debug("Modify方法参数：" + bean);
            var sql = new StringBuilder();
            sql.Append("update gat_warndetail set");
            var i = 0;
            var dList = new List<object>();
            if (bean.IsSuccess != null)
            {
                sql.Append(" IsSuccess={" + i++ + "},");
                dList.Add(bean.IsSuccess);
            }
            if (bean.ProcessFlag != null)
            {
                sql.Append(" ProcessFlag={" + i++ + "},");
                dList.Add(bean.ProcessFlag);
            }
            if (bean.UpdateDT != null)
            {
                sql.Append(" UpdateDT={" + i++ + "}");
                dList.Add(bean.UpdateDT);
            }
            sql.Append(" where Id={" + i++ + "}");
            dList.Add(bean.Id);
            Log.Debug("SQL :" + sql + ",params:" + dList.ToString());
            Oop.Execute(sql.ToString(), dList.ToArray());

        }

        public void ModifyByGatherId(WarnDetail bean)
        {
            Log.Debug("ModifyByGatherId方法参数：" + bean);
            var sql = new StringBuilder();
            sql.Append("update gat_warndetail set");
            var i = 0;
            var dList = new List<object>();

            if (!string.IsNullOrEmpty(bean.WarnId))
            {
                sql.Append(" WarnId={" + i++ + "},");
                dList.Add(bean.WarnId);
            }
            if (!string.IsNullOrEmpty(bean.Address))
            {
                sql.Append(" Address={" + i++ + "},");
                dList.Add(bean.Address);
            }
            if (bean.IsSuccess != null)
            {
                sql.Append(" IsSuccess={" + i++ + "},");
                dList.Add(bean.IsSuccess);
            }
            if (bean.SendDT != null)
            {
                sql.Append(" SendDT={" + i++ + "},");
                dList.Add(bean.SendDT);
            }
            if (!string.IsNullOrEmpty(bean.WarnContext))
            {
                sql.Append(" WarnContext={" + i++ + "},");
                dList.Add(bean.UpdateDT);
            }
            if (!string.IsNullOrEmpty(bean.WarnType))
            {
                sql.Append(" WarnType={" + i++ + "},");
                dList.Add(bean.WarnType);
            }
            if (bean.ProcessFlag != null)
            {
                sql.Append(" ProcessFlag={" + i++ + "},");
                dList.Add(bean.ProcessFlag);
            }
            if (sql.Length > 0)
            {
                sql = sql.Remove(sql.Length - 1, 1);
            }
            sql.Append(" UpdateDT=sysdate where GatherId={" + i++ + "}");
            dList.Add(bean.GatherId);
            Oop.Execute(sql.ToString(), dList.ToArray());
        }
        public override DataTable Query(WarnDetail bean)
        {
            Log.Debug("Query方法参数：" + bean.ToString());
            var sql = new StringBuilder();
            sql.Append("select * from gat_warndetail where 1=1 ");
            var list = new List<object>();
            var i = -1;
            if (!string.IsNullOrEmpty(bean.Id))
            {
                sql.Append(" and Id={" + ++i + "}");
                list.Add(bean.Id);
            }
            if (!string.IsNullOrEmpty(bean.WarnId))
            {
                sql.Append(" and WarnId={" + ++i + "}");
                list.Add(bean.WarnId);
            }
            if (!string.IsNullOrEmpty(bean.GatherId))
            {
                sql.Append(" and GatherId={" + ++i + "}");
                list.Add(bean.GatherId);
            }
            if (!string.IsNullOrEmpty(bean.Address))
            {
                sql.Append(" and Address={" + ++i + "}");
                list.Add(bean.Address);
            }
            if (bean.IsSuccess != null)
            {
                sql.Append(" and IsSuccess={" + ++i + "}");
                list.Add(bean.IsSuccess);
            }
            if (bean.SendDT != null)
            {
                sql.Append(" and SendDT={" + ++i + "}");
                list.Add(bean.SendDT);
            }
            if (!string.IsNullOrEmpty(bean.WarnContext))
            {
                sql.Append(" and WarnContext={" + ++i + "}");
                list.Add(bean.WarnContext);
            }
            if (!string.IsNullOrEmpty(bean.WarnType))
            {
                sql.Append(" and WarnType={" + ++i + "}");
                list.Add(bean.WarnType);
            }
            if (bean.ProcessFlag != null)
            {
                sql.Append(" and ProcessFlag={" + ++i + "}");
                list.Add(bean.ProcessFlag);
            }
            if (bean.UpdateDT != null)
            {
                sql.Append(" and UpdateDT={" + ++i + "}");
                list.Add(bean.UpdateDT);
            }
            if (bean.CreateDT != null)
            {
                sql.Append(" and CreateDT={" + ++i + "}");
                list.Add(bean.CreateDT);
            }
            Log.Debug("SQL :" + sql + ",params:" + list.ToString());
            return Oop.GetDataTable(sql.ToString(), list.ToArray());
        }

        public override DataTable QueryByPage(WarnDetail bean, int page, int rows)
        {
            throw new NotImplementedException();
        }

        public override DataTable QueryByPage(WarnDetail bean, int page, int rows, ref int count)
        {
            Log.Debug("QueryByPage方法参数：" + bean);
            var getpage = new GetPage();
            var sql = new StringBuilder();
            sql.Append("select * from gat_warndetail where 1=1 ");

            if (!string.IsNullOrEmpty(bean.Id))
                sql.Append(" and Id={" + bean.Id + "}");

            if (!string.IsNullOrEmpty(bean.WarnId))
                sql.Append(" and WarnId={" + bean.WarnId + "}");

            if (!string.IsNullOrEmpty(bean.GatherId))
                sql.Append(" and GatherId={" + bean.GatherId + "}");

            if (!string.IsNullOrEmpty(bean.Address))
                sql.Append(" and Address={" + bean.Address + "}");

            if (bean.IsSuccess != null)
                sql.Append(" and IsSuccess={" + bean.IsSuccess + "}");

            if (bean.SendDT != null)
                sql.Append(" and SendDT={" + bean.SendDT + "}");

            if (string.IsNullOrEmpty(bean.WarnContext))
                sql.Append(" and WarnContext={" + bean.WarnContext + "}");

            if (string.IsNullOrEmpty(bean.WarnType))
                sql.Append(" and WarnType={" + bean.WarnType + "}");

            if (bean.ProcessFlag != null)
                sql.Append(" and ProcessFlag={" + bean.ProcessFlag + "}");

            if (bean.UpdateDT != null)
                sql.Append(" and UpdateDT={" + bean.UpdateDT + "}");

            if (bean.CreateDT != null)
                sql.Append(" and CreateDT={" + bean.CreateDT + "}");
            Log.Debug("SQL :" + sql);
            return getpage.GetPageByProcedure(page, rows, sql.ToString(), ref count);
        }

        public DataTable FindByEmail()
        {
            Log.Debug("Query方法参数：");
            var sql = new StringBuilder();
            sql.Append("select gwd.warntype title, gwd.warncontext body,gwd.address,gwd.warntype type ");
            sql.Append("from gat_warndetail gwd inner join gat_warn gw on gwd.warnid=gw.id ");
            sql.Append("where gwd.warntype='Email'  and gwd.processflag='1'");
            return Oop.GetDataTable(sql.ToString());
        }


        public DataTable FindBySms()
        {
            Log.Debug("Query方法参数：");
            var sql = new StringBuilder();
            sql.Append("select gwd.Id,gwd.WARNID,gwd.WARNCONTEXT,gw.WARNTARGET ");
            sql.Append("from gat_warndetail gwd inner join gat_warn gw on gwd.warnid=gw.id ");
            sql.Append("where gwd.warntype='SMS'  and gwd.processflag='0' and rownum<=100");
            return Oop.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 查找站简称
        /// </summary>
        /// <param name="warnid"></param>
        /// <returns></returns>
        public DataTable FindZhanJc(string warnid)
        {
            var sql = new StringBuilder();
            sql.Append("select dcs.zhan_jc ");
            sql.Append("from gat_warndetail gwd  ");
            sql.Append("inner join oth_warnrec owr on gwd.warnrecid=owr.id ");
            sql.Append("inner join dev_chargstation dcs on owr.targetdev=dcs.zhan_bh ");
            sql.Append("where owr.targettype=001 and gwd.warnid={0} ");

            return Oop.GetDataTable(sql.ToString(), warnid);
        }


        /// <summary>
        /// 查找桩编号
        /// </summary>
        /// <param name="warnid">告警id</param>
        /// <returns></returns>
        public DataTable FindZhuanBh(string warnid)
        {
            var sql = new StringBuilder();
            sql.Append("select dcp.yunxing_bh ");
            sql.Append("from gat_warndetail gwd  ");
            sql.Append("inner join oth_warnrec owr on gwd.warnrecid=owr.id ");
            sql.Append("inner join dev_chargpile dcp on owr.targetdev=dcp.dev_chargpile ");
            sql.Append("where owr.targettype=000 and gwd.warnid={0} ");

            return Oop.GetDataTable(sql.ToString(), warnid);
        }

        /// <summary>
        /// 查找数据项
        /// </summary>
        /// <param name="warnid">告警id</param>
        /// <returns></returns>
        public DataTable FindItemName(string warnid)
        {
            var sql = new StringBuilder();
            sql.Append("select gi.itemname ");
            sql.Append("from gat_warndetail gwd  ");
            sql.Append("inner join oth_warnrec owr on gwd.warnrecid=owr.id ");
            sql.Append("inner join gat_item gi on owr.dataitemid=gi.itemno ");
            sql.Append("where gwd.warnid={0} ");

            return Oop.GetDataTable(sql.ToString(), warnid);
        }

        /// <summary>
        /// 查找告警原因
        /// </summary>
        /// <param name="warnid">告警id</param>
        /// <returns></returns>
        public DataTable FindWarn(string warnid)
        {
            var sql = new StringBuilder();
            sql.Append("select owr.m_value,owr.logdesc ");
            sql.Append("from gat_warndetail gwd  ");
            sql.Append("inner join oth_warnrec owr on gwd.warnrecid=owr.id ");
            sql.Append("where gwd.warnid={0} ");

            return Oop.GetDataTable(sql.ToString(), warnid);
        }
    }
}

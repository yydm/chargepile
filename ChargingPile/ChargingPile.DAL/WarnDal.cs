using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ChargingPile.Model;

namespace ChargingPile.DAL
{
    public class WarnDal : BaseDal<Warn>
    {
        public override bool Exist(Warn bean)
        {
            Log.Debug("exist方法"+bean);
            var sql = "select * from gat_warn t where Id='" + bean.Id + "'";
            Log.Debug("SQL :" + sql);
            var dt = Oop.GetDataTable(sql);
            return dt.Rows.Count > 0;
        }

        public override void Add(Warn bean)
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
            if (!string.IsNullOrEmpty(bean.WarnType))
            {
                sql1.Append(" WarnType,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.WarnType);
            }
            if (!string.IsNullOrEmpty(bean.WarnTarget))
            {
                sql1.Append(" WarnTarget,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.WarnTarget);
            }
            if (!string.IsNullOrEmpty(bean.WarnContext))
            {
                sql1.Append(" WarnContext,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.WarnContext);
            }
            if (bean.CreateDT != null)
            {
                sql1.Append(" CreateDT,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.CreateDT);
            }
            if (bean.UpdateDT != null)
            {
                sql1.Append(" UpdateDT,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.UpdateDT);
            }

            if (sql1.Length > 0)
            {
                sql1 = sql1.Remove(sql1.Length - 1, 1);
                sql2 = sql2.Remove(sql2.Length - 1, 1);
            }

            var sql = "insert into gat_warn(" + sql1 + ") values(" + sql2 + ")";
            Log.Debug("SQL :" + sql + ",params:" + list.ToString());
            Oop.Execute(sql, list.ToArray());
        }

        public override void Del(Warn bean)
        {
            Log.Debug("del方法参数："+bean);
            var sql = "delete from gat_warn where Id='" + bean.Id + "'";
            Log.Debug("SQL :" + sql);
            Oop.Execute(sql);
        }

        public override void Modify(Warn bean)
        {
            Log.Debug("Modify方法参数：" + bean);
            var sql = new StringBuilder();
            sql.Append("update sm_role set");
            var i = 0;
            var dList = new List<object>();
            if (string.IsNullOrEmpty(bean.WarnType))
            {
                sql.Append(" WarnType={" + i++ + "}");
                dList.Add(bean.WarnType);
            }
            if (string.IsNullOrEmpty(bean.WarnTarget))
            {
                sql.Append(" WarnTarget={" + i++ + "}");
                dList.Add(bean.WarnTarget);
            }
            if (string.IsNullOrEmpty(bean.WarnContext))
            {
                sql.Append(" WarnContext={" + i++ + "}");
                dList.Add(bean.WarnContext);
            }
            if (bean.CreateDT != null)
            {
                sql.Append(" CreateDT={" + i++ + "}");
                dList.Add(bean.CreateDT);
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

        public override DataTable Query(Warn bean)
        {
            Log.Debug("Query方法参数：" + bean.ToString());
            var sql = new StringBuilder();
            sql.Append("select * from gat_warn where 1=1 ");
            var list = new List<object>();
            var i = -1;
            if (!string.IsNullOrEmpty(bean.Id))
            {
                sql.Append(" and Id={" + ++i + "}");
                list.Add(bean.Id);
            }
            if (!string.IsNullOrEmpty(bean.WarnType))
            {
                sql.Append(" and WarnType={" + ++i + "}");
                list.Add(bean.WarnType);
            }
            if (!string.IsNullOrEmpty(bean.WarnTarget))
            {
                sql.Append(" and WarnTarget={" + ++i + "}");
                list.Add(bean.WarnTarget);
            }
            if (!string.IsNullOrEmpty(bean.WarnContext))
            {
                sql.Append(" and WarnContext={" + ++i + "}");
                list.Add(bean.WarnContext);
            }
            if (bean.CreateDT != null)
            {
                sql.Append(" and CreateDT={" + ++i + "}");
                list.Add(bean.CreateDT);
            }
            if (bean.UpdateDT != null)
            {
                sql.Append(" and UpdateDT={" + ++i + "}");
                list.Add(bean.UpdateDT);
            }
            Log.Debug("SQL :" + sql + ",params:" + list.ToString());
            return Oop.GetDataTable(sql.ToString(), list.ToArray());
        }

        public override DataTable QueryByPage(Warn bean, int page, int rows)
        {
            throw new NotImplementedException();
        }

        public override DataTable QueryByPage(Warn bean, int page, int rows, ref int count)
        {
            Log.Debug("QueryByPage方法参数：" + bean);
            var getpage = new GetPage();
            var sql = new StringBuilder();
            sql.Append("select * from gat_warn where 1=1 ");

            if (!string.IsNullOrEmpty(bean.Id))
                sql.Append(" and Id={" + bean.Id + "}");

            if (!string.IsNullOrEmpty(bean.WarnTarget))
                sql.Append(" and WarnTarget={" + bean.WarnTarget + "}");

            if (!string.IsNullOrEmpty(bean.WarnType))
                sql.Append(" and WarnType={" + bean.WarnType + "}");

            if (!string.IsNullOrEmpty(bean.WarnContext))
                sql.Append(" and WarnContext={" + bean.WarnContext + "}");

            if (bean.CreateDT != null)
                sql.Append(" and CreateDT={" + bean.CreateDT + "}");

            if (bean.UpdateDT != null)
                sql.Append(" and UpdateDT={" + bean.UpdateDT + "}");
            Log.Debug("SQL :" + sql);
            return getpage.GetPageByProcedure(page, rows, sql.ToString(), ref count);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ChargingPile.Model;

namespace ChargingPile.DAL
{
    public class JobsDetailsDal : BaseDal<JobsDetails>
    {
        public override bool Exist(JobsDetails bean)
        {
            Log.Debug("exist方法"+bean);
            var sql = new StringBuilder();
            sql.Append("select * from cmd_jobsdetails t where id='" + bean.Id + "'");
            Log.Debug("SQL :" + sql);
            var dt = Oop.GetDataTable(sql.ToString());
            return dt.Rows.Count > 0;
        }

        public override void Add(JobsDetails bean)
        {
            Log.Debug("Add方法参数：" + bean);
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
            if (bean.PowerpileId != null)
            {
                sql1.Append(" PowerpileId,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.PowerpileId);
            }
           
            if (!string.IsNullOrEmpty(bean.TaskId))
            {
                sql1.Append(" TaskId,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.TaskId);
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
            var sql = "insert into cmd_jobsdetails(" + sql1 + ") values(" + sql2 + ")";
            Log.Debug("SQL :" + sql + ",params:" + list.ToString());
            Oop.Execute(sql, list.ToArray());
        }

        public override void Del(JobsDetails bean)
        {
            Log.Debug("del方法参数："+bean);
            var sql = new StringBuilder();
            sql.Append("delete from cmd_jobsdetails where id='" + bean.Id + "'");
            Log.Debug("SQL :" + sql);
            Oop.Execute(sql.ToString());
        }

        public override void Modify(JobsDetails bean)
        {
            Log.Debug("Modify方法参数：" + bean);
            var sql = new StringBuilder();
            sql.Append("update cmd_jobsdetails set");
            var i = 0;
            var dList = new List<object>();
            if (bean.PowerpileId != null)
            {
                sql.Append(" PowerpileId={" + i++ + "}");
                dList.Add(bean.PowerpileId);
            }

            if (!string.IsNullOrEmpty(bean.TaskId))
            {
                sql.Append(" TaskId={" + i++ + "}");
                dList.Add(bean.TaskId);
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

            sql.Append(" where id={" + i++ + "}");
            dList.Add(bean.Id);
            Log.Debug("SQL :" + sql + ",params:" + dList.ToString());
            Oop.Execute(sql.ToString(), dList.ToArray());
        }

        public override DataTable Query(JobsDetails bean)
        {
            Log.Debug("Query方法参数：" + bean);
            var sql = new StringBuilder();
            sql.Append("select t.* from cmd_jobsdetails t where 1=1 ");
            var list = new List<object>();
            var i = -1;
            if (!string.IsNullOrEmpty(bean.Id))
            {
                sql.Append(" and Id={" + ++i + "}");
                list.Add(bean.Id);
            }
            if (bean.PowerpileId != null)
            {
                sql.Append(" and PowerpileId={" + ++i + "}");
                list.Add(bean.PowerpileId);
            }

            if (!string.IsNullOrEmpty(bean.TaskId))
            {
                sql.Append(" and TaskId={" + ++i + "}");
                list.Add(bean.TaskId);
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

        public override DataTable QueryByPage(JobsDetails bean, int page, int rows)
        {
            throw new NotImplementedException();
        }

        public override DataTable QueryByPage(JobsDetails bean, int page, int rows, ref int count)
        {
            Log.Debug("QueryByPage方法参数：" + bean);
            var getpage = new GetPage();
            var sql = new StringBuilder();
            sql.Append("select * from cmd_jobsdetails where 1=1 ");

            if (string.IsNullOrEmpty(bean.Id))
                sql.Append(" and Id={" + bean.Id + "}");
            
            if (bean.PowerpileId != null)
                sql.Append(" and Id={" + bean.PowerpileId + "}");

            if (!string.IsNullOrEmpty(bean.TaskId))
                sql.Append(" and Id={" + bean.TaskId + "}");

            if (bean.CreateDT != null)
                sql.Append(" and CreateDT={" + bean.CreateDT + "}");

            if (bean.UpdateDT != null)
                sql.Append(" and UpdateDT={" + bean.UpdateDT + "}");
            Log.Debug("SQL :" + sql);
            return getpage.GetPageByProcedure(page, rows, sql.ToString(), ref count);
        }
    }
}

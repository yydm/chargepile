using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ChargingPile.Model;

namespace ChargingPile.DAL
{
    public class RoleDal : BaseDal<Role>
    {
        public override bool Exist(Role bean)
        {
            Log.Debug("exist方法"+bean);
            var sql = "select * from sm_role t where RoleId='" + bean.RoleId + "'";
            Log.Debug("SQL :" + sql);
            var dt = Oop.GetDataTable(sql);
            return dt.Rows.Count > 0;
        }

        public override void Add(Role bean)
        {
            Log.Debug("Add方法参数：" + bean.ToString());
            var sql1 = new StringBuilder();
            var sql2 = new StringBuilder();
            var i = 0;
            var list = new List<object>();
            if (!string.IsNullOrEmpty(bean.RoleId))
            {
                sql1.Append(" RoleId,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.RoleId);
            }
            if (!string.IsNullOrEmpty(bean.AppId))
            {
                sql1.Append(" AppId,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.AppId);
            }
            if (!string.IsNullOrEmpty(bean.RoleName))
            {
                sql1.Append(" RoleName,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.RoleName);
            }
            if (!string.IsNullOrEmpty(bean.RoleDesc))
            {
                sql1.Append(" RoleDesc,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.RoleDesc);
            }
            if (bean.RoleNo != null)
            {
                sql1.Append(" RoleNo,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.RoleNo);
            }
            if (bean.StaGrade != null)
            {
                sql1.Append(" StaGrade,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.StaGrade);
            }
            if (bean.CreateDT != null)
            {
                sql1.Append(" StaGrade,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.StaGrade);
            }
            if (bean.UpdateDT != null)
            {
                sql1.Append(" StaGrade,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.StaGrade);
            }
            if (sql1.Length > 0)
            {
                sql1 = sql1.Remove(sql1.Length - 1, 1);
                sql2 = sql2.Remove(sql2.Length - 1, 1);
            }

            var sql = "insert into sm_role(" + sql1 + ") values(" + sql2 + ")";
            Log.Debug("SQL :" + sql + ",params:" + list.ToString());
            Oop.Execute(sql, list.ToArray());
        }

        public override void Del(Role bean)
        {
            Log.Debug("del方法参数："+bean);
            var sql = "delete from sm_role where RoleId='" + bean.RoleId + "'";
            Log.Debug("SQL :" + sql);
            Oop.Execute(sql);
        }

        public override void Modify(Role bean)
        {
            Log.Debug("Modify方法参数：" + bean);
            var sql = new StringBuilder();
            sql.Append("update sm_role set");
            var i = 0;
            var dList = new List<object>();
            if (string.IsNullOrEmpty(bean.AppId))
            {
                sql.Append(" AppId={" + i++ + "}");
                dList.Add(bean.AppId);
            }
            if (string.IsNullOrEmpty(bean.RoleName))
            {
                sql.Append(" RoleName={" + i++ + "}");
                dList.Add(bean.RoleName);
            }
            if (string.IsNullOrEmpty(bean.RoleDesc))
            {
                sql.Append(" RoleDesc={" + i++ + "}");
                dList.Add(bean.RoleDesc);
            }
            if (bean.RoleNo != null)
            {
                sql.Append(" RoleNo={" + i++ + "}");
                dList.Add(bean.RoleNo);
            }
            if (bean.StaGrade != null)
            {
                sql.Append(" StaGrade={" + i++ + "}");
                dList.Add(bean.StaGrade);
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
            sql.Append(" where RoleId={" + i++ + "}");
            dList.Add(bean.RoleId);
            Log.Debug("SQL :" + sql + ",params:" + dList.ToString());
            Oop.Execute(sql.ToString(), dList.ToArray());
        }

        public override DataTable Query(Role bean)
        {
            Log.Debug("Query方法参数：" + bean.ToString());
            var sql = new StringBuilder();
            sql.Append("select * from sm_role where 1=1 ");
            var list = new List<object>();
            var i = -1;
            if (!string.IsNullOrEmpty(bean.RoleId))
            {
                sql.Append(" and RoleId={" + ++i + "}");
                list.Add(bean.RoleId);
            }
            if (!string.IsNullOrEmpty(bean.AppId))
            {
                sql.Append(" and AppId={" + ++i + "}");
                list.Add(bean.AppId);
            }
            if (!string.IsNullOrEmpty(bean.RoleName))
            {
                sql.Append(" and RoleName={" + ++i + "}");
                list.Add(bean.RoleName);
            }
            if (!string.IsNullOrEmpty(bean.RoleDesc))
            {
                sql.Append(" and RoleDesc={" + ++i + "}");
                list.Add(bean.RoleDesc);
            }
            if (bean.RoleNo != null)
            {
                sql.Append(" and RoleNo={" + ++i + "}");
                list.Add(bean.RoleNo);
            }
            if (bean.StaGrade != null)
            {
                sql.Append(" and StaGrade={" + ++i + "}");
                list.Add(bean.StaGrade);
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

        public override DataTable QueryByPage(Role bean, int page, int rows)
        {
            Log.Debug("QueryByPage方法参数：" + bean);
            var recordcount = 0;
            return QueryByPage(bean, page, rows, ref recordcount);
        }

        public override DataTable QueryByPage(Role bean, int page, int rows, ref int recordcount)
        {
            Log.Debug("QueryByPage方法参数：" + bean);
            var getpage = new GetPage();
            var sql = new StringBuilder();
            sql.Append("select * from sm_role where 1=1 ");

            if (!string.IsNullOrEmpty(bean.RoleId))
                sql.Append(" and RoleId={" + bean.RoleId + "}");

            if (!string.IsNullOrEmpty(bean.AppId))
                sql.Append(" and AppId={" + bean.AppId + "}");

            if (!string.IsNullOrEmpty(bean.RoleName))
                sql.Append(" and RoleName={" + bean.RoleName + "}");

            if (!string.IsNullOrEmpty(bean.RoleDesc))
                sql.Append(" and RoleDesc={" + bean.RoleDesc + "}");

            if (bean.RoleNo != null)
                sql.Append(" and RoleNo={" + bean.RoleNo + "}");

            if (bean.StaGrade != null)
                sql.Append(" and StaGrade={" + bean.StaGrade + "}");

            if (bean.CreateDT != null)
                sql.Append(" and CreateDT={" + bean.CreateDT + "}");

            if (bean.UpdateDT != null)
                sql.Append(" and UpdateDT={" + bean.UpdateDT + "}");
            Log.Debug("SQL :" + sql);
            return getpage.GetPageByProcedure(page, rows, sql.ToString(), ref recordcount);
        }
    }
}

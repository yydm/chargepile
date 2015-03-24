using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ChargingPile.Model;

namespace ChargingPile.DAL
{
    public class UseRolesDal : BaseDal<UseRoles>
    {
        public override bool Exist(UseRoles bean)
        {
            Log.Debug("exist方法"+bean);
            var sql = "select * from sm_useroles t where roleid='" + bean.RoleId + "'";
            Log.Debug("SQL :" + sql);
            var dt = Oop.GetDataTable(sql);
            return dt.Rows.Count > 0;
        }

        public override void Add(UseRoles bean)
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
            if (!string.IsNullOrEmpty(bean.LoginName))
            {
                sql1.Append(" LoginName,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.LoginName);
            }
            if (sql1.Length > 0)
            {
                sql1 = sql1.Remove(sql1.Length - 1, 1);
                sql2 = sql2.Remove(sql2.Length - 1, 1);
            }
            var sql = "insert into sm_useroles(" + sql1 + ") values(" + sql2 + ")";
            Log.Debug("SQL :" + sql + ",params:" + list.ToString());
            Oop.Execute(sql, list.ToArray());
        }

        public override void Del(UseRoles bean)
        {
            Log.Debug("del方法参数："+bean);
            var sql = "delete from sm_useroles where loginname='" + bean.LoginName + "'";
            Log.Debug("SQL :" + sql);
            Oop.Execute(sql);
        }

        public void Del2(UseRoles bean)
        {
            Log.Debug("del方法参数：" + bean);
            var sql = "delete from sm_useroles where roleid='" + bean.RoleId + "'";
            Log.Debug("SQL :" + sql);
            Oop.Execute(sql);
        }

        public override void Modify(UseRoles bean)
        {
            Log.Debug("Modify方法参数：" + bean);
            var sql = new StringBuilder();
            sql.Append("update sm_useroles set");
            var i = 0;
            var dList = new List<object>();
            if (string.IsNullOrEmpty(bean.LoginName))
            {
                sql.Append(" LoginName={" + i++ + "}");
                dList.Add(bean.LoginName);
            }
            sql.Append(" where RoleId={" + i++ + "}");
            dList.Add(bean.RoleId);
            Log.Debug("SQL :" + sql + ",params:" + dList.ToString());
            Oop.Execute(sql.ToString(), dList.ToArray());
            
        }

        public override DataTable Query(UseRoles bean)
        {
            Log.Debug("Query方法参数：" + bean);
            var sql = new StringBuilder();
            sql.Append("select t.*,(select rolename from sm_role s where s.roleid=t.roleid) rolename from sm_useroles t where 1=1 ");
            var list = new List<object>();
            var i = -1;
            if (!string.IsNullOrEmpty(bean.RoleId))
            {
                sql.Append(" and RoleId={" + ++i + "}");
                list.Add(bean.RoleId);
            }
            if (!string.IsNullOrEmpty(bean.LoginName))
            {
                sql.Append(" and LoginName={" + ++i + "}");
                list.Add(bean.LoginName);
            }
            Log.Debug("SQL :" + sql + ",params:" + list.ToString());
            return Oop.GetDataTable(sql.ToString(), list.ToArray());
        }

        public override DataTable QueryByPage(UseRoles bean, int page, int rows)
        {
            throw new NotImplementedException();
        }

        public override DataTable QueryByPage(UseRoles bean, int page, int rows, ref int recordcount)
        {
            Log.Debug("QueryByPage方法参数：" + bean);
            var getpage = new GetPage();
            var sql = new StringBuilder();
            sql.Append("select * from sm_useroles where 1=1 ");

            if (!string.IsNullOrEmpty(bean.RoleId))
                sql.Append(" and RoleId={" + bean.RoleId + "}");

            if (!string.IsNullOrEmpty(bean.LoginName))
                sql.Append(" and LoginName={" + bean.LoginName + "}");
            Log.Debug("SQL :" + sql);
            return getpage.GetPageByProcedure(page, rows, sql.ToString(), ref recordcount);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="empid"></param>
        /// <returns></returns>
        public DataTable FindBy(string empid)
        {
            Log.Debug("FindBy方法参数：");
            var sql = new StringBuilder();
            sql.Append("select sr.rolename  ");
            sql.Append("from sm_role sr inner join sm_useroles su on sr.roleid=su.roleid inner join t_employer te on su.loginname=te.id  ");
            sql.Append("where te.id='" + empid + "'  ");
            return Oop.GetDataTable(sql.ToString());
        }
    }
}

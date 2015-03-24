using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ChargingPile.Model;

namespace ChargingPile.DAL
{
    public class MenuPowerDal : BaseDal<MenuPower>
    {
        public override bool Exist(MenuPower bean)
        {
            Log.Debug("exist方法" + bean);
            var sql = new StringBuilder();
            sql.Append("select * from t_menu_power t where menuid='" + bean.MenuId);
            sql.Append("' and powerid='" + bean.PowerId + "'");
            Log.Debug("SQL :" + sql);
            var dt = Oop.GetDataTable(sql.ToString());
            return dt.Rows.Count > 0;
        }

        public override void Add(MenuPower bean)
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
            if (!string.IsNullOrEmpty(bean.MenuId))
            {
                sql1.Append(" MenuId,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.MenuId);
            }

            if (!string.IsNullOrEmpty(bean.PowerId))
            {
                sql1.Append(" PowerId,");
                sql2.Append(" {" + i + "},");
                list.Add(bean.PowerId);
            }

            if (sql1.Length > 0)
            {
                sql1 = sql1.Remove(sql1.Length - 1, 1);
                sql2 = sql2.Remove(sql2.Length - 1, 1);
            }

            var sql = "insert into t_menu_power(" + sql1 + ") values(" + sql2 + ")";
            Log.Debug("SQL :" + sql + ",params:" + list.ToString());
            Oop.Execute(sql, list.ToArray());
        }

        public override void Del(MenuPower bean)
        {
            Log.Debug("del方法参数：" + bean);
            var sql = "delete from t_menu_power where powerid='" + bean.PowerId + "'";
            Log.Debug("SQL :" + sql);
            Oop.Execute(sql);
        }

        public override void Modify(MenuPower bean)
        {
            Log.Debug("Modify方法参数：" + bean);
            var sql = new StringBuilder();
            sql.Append("update t_menu_power set");
            var i = 0;
            var dList = new List<object>();

            if (string.IsNullOrEmpty(bean.MenuId))
            {
                sql.Append(" MenuId={" + i++ + "}");
                dList.Add(bean.MenuId);
            }

            if (string.IsNullOrEmpty(bean.PowerId))
            {
                sql.Append(" PowerId={" + i++ + "}");
                dList.Add(bean.PowerId);
            }

            sql.Append(" where Id={" + i + "}");
            dList.Add(bean.Id);
            Log.Debug("SQL :" + sql + ",params:" + dList.ToString());
            Oop.Execute(sql.ToString(), dList.ToArray());

        }

        public override DataTable Query(MenuPower bean)
        {
            Log.Debug("Query方法参数：" + bean);
            var sql = new StringBuilder();
            sql.Append("select * from t_menu_power where 1=1 ");
            var list = new List<object>();
            var i = -1;
            if (!string.IsNullOrEmpty(bean.Id))
            {
                sql.Append(" and Id={" + ++i + "}");
                list.Add(bean.Id);
            }
            if (!string.IsNullOrEmpty(bean.MenuId))
            {
                sql.Append(" and MenuId={" + ++i + "}");
                list.Add(bean.MenuId);
            }

            if (!string.IsNullOrEmpty(bean.PowerId))
            {
                sql.Append(" and PowerId={" + ++i + "}");
                list.Add(bean.PowerId);
            }
            Log.Debug("SQL :" + sql + ",params:" + list.ToString());
            return Oop.GetDataTable(sql.ToString(), list.ToArray());
        }

        public DataTable QueryMenuByRole(string roleid)
        {
            string sql = @"select t.*,(select caption from sm_resmenu t_m where t_m.resid=t.parentid) parentname,
(select caption from sm_resmenu t_m where t_m.resid=(select parentid from sm_resmenu t_m1 where t_m1.resid=t.parentid)) ppname 
from sm_resmenu t where  t.resid in ( select resid from sm_resmenu srm inner join t_menu_power tmp on tmp.menuid=srm.resid 
inner join sm_role sr on sr.roleid=tmp.powerid inner join sm_useroles sur on sur.roleid = sr.roleid 
inner join t_employer te on te.id=sur.loginname where te.id='" + roleid + "') order by t.resid";
            return Oop.GetDataTable(sql);
        }

        public override DataTable QueryByPage(MenuPower bean, int page, int rows)
        {
            throw new NotImplementedException();
        }

        public override DataTable QueryByPage(MenuPower bean, int page, int rows, ref int count)
        {
            Log.Debug("QueryByPage方法参数：" + bean);
            var getpage = new GetPage();
            var sql = new StringBuilder();
            sql.Append("select * from t_menu_power where 1=1 ");

            if (!string.IsNullOrEmpty(bean.Id))
                sql.Append(" and Id={" + bean.Id + "}");

            if (!string.IsNullOrEmpty(bean.MenuId))
                sql.Append(" and MenuId={" + bean.MenuId + "}");

            if (!string.IsNullOrEmpty(bean.PowerId))
                sql.Append(" and PowerId={" + bean.PowerId + "}");
            Log.Debug("SQL :" + sql);
            return getpage.GetPageByProcedure(page, rows, sql.ToString(), ref count);
        }
    }
}

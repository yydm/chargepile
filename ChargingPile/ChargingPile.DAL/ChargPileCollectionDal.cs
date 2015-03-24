using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChargingPile.Model;
using System.Data;

namespace ChargingPile.DAL
{
    public class ChargPileCollectionDal : BaseDal<ChargPile>
    {
        /// <summary>
        /// 查询充电桩采集项数据
        /// </summary>
        /// <returns></returns>
        public DataTable QueryChargPileCollection() 
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select d.*,(select count(g.id) from gat_pointcfg g,gat_item m  ");
            strSql.Append(" where d.parserkey=g.piletypeid and g.gatitemid=m.itemno)as counts from dev_powerpiletypes d ");
            return Oop.GetDataTable(strSql.ToString());
        }
        /// <summary>
        /// 查看配置项
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable QueryCollection(string id) 
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select gi.*,(select 1 from gat_pointcfg t where t.gatitemid=gi.itemno and t.piletypeid='"+id+"' ) note from gat_item gi ");
            return Oop.GetDataTable(strSql.ToString());
        }
        /// <summary>
        /// 添加配置项
        /// </summary>
        /// <param name="typeid"></param>
        /// <param name="pzx"></param>
        public void AddPZX(string typeid,string pzx) 
        {
            var sql1 = new StringBuilder();
            var sql2 = new StringBuilder();
            var i = 0;
            var list = new List<object>();
            string id = Guid.NewGuid().ToString();
            sql1.Append(" ID, ");
            sql2.Append(" '"+id+"', ");
            if (!string.IsNullOrEmpty(typeid))
            {
                sql1.Append(" PILETYPEID,");
                sql2.Append(" {" + i++ + "},");
                list.Add(typeid);
            }
            if (!string.IsNullOrEmpty(pzx))
            {
                sql1.Append(" GATITEMID,");
                sql2.Append(" {" + i++ + "},");
                list.Add(pzx);
            }
            if (sql1.Length > 0)
            {
                sql1 = sql1.Remove(sql1.Length - 1, 1);
                sql2 = sql2.Remove(sql2.Length - 1, 1);
            }
            var sql = "insert into gat_pointcfg(" + sql1 + ",createdt) values(" + sql2 + ",sysdate)";
            Oop.Execute(sql, list.ToArray());

        }

        /// <summary>
        /// 删除配置项
        /// </summary>
        /// <param name="chargtype"></param>
        public void DelPZX(string typeid,string pzx)
        {
            Log.Debug("DelPZX方法参数为：" + typeid.ToString());
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" delete from gat_pointcfg ");
            strSql.Append(" where PILETYPEID={0} and GATITEMID={1} ");
            object[] parameters = new object[] {
                typeid,
                pzx
            };
            Oop.Execute(strSql.ToString(), parameters);
            Log.Debug("SQL:" + strSql.ToString() + ",params:" + parameters.ToString());

        }
        /// <summary>
        /// 查询配置项
        /// </summary>
        /// <param name="typeid"></param>
        /// <returns></returns>
        public DataTable QueryItemByTypeID(string typeid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from gat_pointcfg where PILETYPEID={0} ");
            object[] parameters = new object[] { 
                typeid
            };
            DataTable dt = new DataTable();
            try
            {
                dt = Oop.GetDataTable(strSql.ToString(), parameters);
            }
            catch (Exception e)
            {
                Log.Error("查询配置项失败！", e);
            }
            return dt;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeid"></param>
        /// <returns></returns>
        public DataTable QueryItem(string typeid,string pzx)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from gat_pointcfg where PILETYPEID={0} and GATITEMID={1} ");
            object[] parameters = new object[] { 
                typeid,
                pzx
            };
            DataTable dt = new DataTable();
            try
            {
                dt = Oop.GetDataTable(strSql.ToString(), parameters);
            }
            catch (Exception e)
            {
                Log.Error("查询配置项失败！", e);
            }
            return dt;

        }

        public override bool Exist(ChargPile bean)
        {
            throw new NotImplementedException();
        }

        public override void Add(ChargPile bean)
        {
            throw new NotImplementedException();
        }

        public override void Del(ChargPile bean)
        {
            throw new NotImplementedException();
        }

        public override void Modify(ChargPile bean)
        {
            throw new NotImplementedException();
        }

        public override DataTable Query(ChargPile bean)
        {
            throw new NotImplementedException();
        }

        public override DataTable QueryByPage(ChargPile bean, int page, int rows)
        {
            throw new NotImplementedException();
        }

        public override DataTable QueryByPage(ChargPile bean, int page, int rows, ref int count)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChargingPile.Model;
using System.Data;
namespace ChargingPile.DAL
{
    public class Common_DAl : BaseDal<Common>
    {
        /// <summary>
        /// 返回查询一页数据
        /// </summary>
        public DataTable GetQueryPage(string sql, List<object> list, int page, int rows, ref int total)
        {
            DataTable dt;
            total = GetRecordCount(sql, list);
            dt = GetRecordPage(sql, list, page, rows);
            return dt;
        }
        /// <summary>
        /// 返回查询所有数据
        /// </summary>
        public DataTable GetQuerySql(string sql, List<object> list)
        {
            DataTable dt;
            dt = QuerySql(sql, list);
            return dt;
        }

        private int GetRecordCount(string sql, List<object> list)
        {
            string strSql = @"
                            --自定义语句开始
                            SELECT 
                            count(*) as counts
                            from (" + sql + ")";
            DataTable dt = new DataTable();
            int couts = 0;
            try
            {
                dt = Oop.GetDataTable(strSql.ToString(), list.ToArray());
                couts = int.Parse(dt.Rows[0]["counts"].ToString());
            }
            catch (Exception e)
            {
                Log.Error("查询失败！", e);
            }
            return couts;
        }

        private DataTable GetRecordPage(string sql, List<object> list, int page, int rows)
        {
            string strSql = @"  
                            select B.* from 
                            (
                                select A.*,rownum rn from 
                                (
                                    @sql
                                ) A where rownum<='@page'*'@rows'
                            ) B where rn>('@page'-1)*'@rows'
                            ";
            strSql = strSql.Replace("@page", page.ToString());
            strSql = strSql.Replace("@rows", rows.ToString());
            strSql = strSql.Replace("@sql", sql);

            DataTable dt = new DataTable();
            try
            {
                dt = Oop.GetDataTable(strSql.ToString(), list.ToArray());
            }
            catch (Exception e)
            {
                Log.Error("查询失败！", e);
            }
            return dt;
        }

        public DataTable QuerySql(string sql, List<object> list)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = Oop.GetDataTable(sql, list.ToArray());
            }
            catch (Exception e)
            {
                Log.Error("查询失败！", e);
            }
            return dt;
        }

        public int ExecuteSQL(string sql, List<object> list)
        {
            int intCt = 0;
            try
            {
                intCt=Oop.Execute(sql, list.ToArray());
                
            }
            catch (Exception e)
            {
                Log.Error("设置失败！", e);
            }
            return intCt;
        }
        public override bool Exist(Common bean)
        {
            throw new NotImplementedException();
        }
        public override void Add(Common bean)
        {
            throw new NotImplementedException();
        }

        public override void Del(Common bean)
        {
            throw new NotImplementedException();
        }

        public override void Modify(Common bean)
        {
            throw new NotImplementedException();
        }

        public override DataTable Query(Common bean)
        {
            throw new NotImplementedException();
        }

        public override DataTable QueryByPage(Common bean, int page, int rows)
        {
            throw new NotImplementedException();
        }
        public override DataTable QueryByPage(Common bean, int page, int rows, ref int count)
        {
            throw new NotImplementedException();
        }
    }
}

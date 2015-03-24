using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ChargingPile.Model;

namespace ChargingPile.DAL
{
    public class ChargPriceDal : BaseDal<ChargPrice>
    {
        public override bool Exist(ChargPrice bean)
        {
            Log.Debug("exist方法"+bean);
            var sql = "select * from cfg_chargprice t where Id='" + bean.Id + "'";
            Log.Debug("SQL :" + sql);
            var dt = Oop.GetDataTable(sql);
            return dt.Rows.Count > 0;
        }

        public override void Add(ChargPrice bean)
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
            if (!string.IsNullOrEmpty(bean.Name))
            {
                sql1.Append(" Name,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.Name);
            }
            if (!string.IsNullOrEmpty(bean.PriceType))
            {
                sql1.Append(" PriceType,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.PriceType);
            }
            if (bean.Version != null)
            {
                sql1.Append(" Version,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.Version);
            }
            if (bean.BeginDT != null)
            {
                sql1.Append(" BeginDT,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.BeginDT);
            }
            if (bean.EndDT != null)
            {
                sql1.Append(" EndDT,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.EndDT);
            }
            if (bean.Price != null)
            {
                sql1.Append(" Price,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.Price);
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
           
            var sql = "insert into cfg_chargprice(" + sql1 + ") values(" + sql2 + ")";
            Log.Debug("SQL :" + sql + ",params:" + list.ToString());
            Oop.Execute(sql, list.ToArray());
        }

        public override void Del(ChargPrice bean)
        {
            Log.Debug("del方法参数："+bean);
            var sql = new StringBuilder();
            sql.Append("delete from cfg_chargprice where id='" + bean.Id + "'");
            Log.Debug("SQL :" + sql);
            Oop.Execute(sql.ToString());
        }

        public override void Modify(ChargPrice bean)
        {
            Log.Debug("Modify方法参数：" + bean);
            var sql = new StringBuilder();
            sql.Append("update cfg_chargprice set");
            var i = 0;
            var dList = new List<object>();
            if (!string.IsNullOrEmpty(bean.Name))
            {
                sql.Append(" Name={" + i++ + "},");
                dList.Add(bean.Name);
            }
            if (!string.IsNullOrEmpty(bean.PriceType))
            {
                sql.Append(" PriceType={" + i++ + "},");
                dList.Add(bean.PriceType);
            }
            if (bean.Version != null)
            {
                sql.Append(" Version={" + i++ + "},");
                dList.Add(bean.Version);
            }
            if (bean.BeginDT != null)
            {
                sql.Append(" BeginDT={" + i++ + "},");
                dList.Add(bean.BeginDT);
            }
            if (bean.EndDT != null)
            {
                sql.Append(" EndDT={" + i++ + "},");
                dList.Add(bean.EndDT);
            }
            if (bean.Price != null)
            {
                sql.Append(" Price={" + i++ + "},");
                dList.Add(bean.Price);
            }
            if (bean.CreateDT != null)
            {
                sql.Append(" CreateDT={" + i++ + "},");
                dList.Add(bean.CreateDT);
            }
            if (bean.UpdateDT != null)
            {
                sql.Append(" UpdateDT={" + i++ + "},");
                dList.Add(bean.UpdateDT);
            }
            if (sql.Length > 0)
            {
                sql = sql.Remove(sql.Length - 1, 1);
            }
            sql.Append(" where id={" + i++ + "}");
            dList.Add(bean.Id);
            Log.Debug("SQL :" + sql + ",params:" + dList.ToString());
            Oop.Execute(sql.ToString(), dList.ToArray());
        }

        public override DataTable Query(ChargPrice bean)
        {
            Log.Debug("Query方法参数：" + bean);
            var sql = new StringBuilder();
            sql.Append("select t.id,t.name,t.price/100 price from cfg_chargprice t where 1=1 ");
            var list = new List<object>();
            var i = -1;
            if (!string.IsNullOrEmpty(bean.Id))
            {
                sql.Append(" and Id={" + ++i + "}");
                list.Add(bean.Id);
            }
            if (!string.IsNullOrEmpty(bean.Name))
            {
                sql.Append(" and Name={" + ++i + "}");
                list.Add(bean.Name);
            }
            if (!string.IsNullOrEmpty(bean.PriceType))
            {
                sql.Append(" and PriceType={" + ++i + "}");
                list.Add(bean.PriceType);
            }
            if (bean.Version != null)
            {
                sql.Append(" and Version={" + ++i + "}");
                list.Add(bean.Version);
            }
            if (bean.BeginDT != null)
            {
                sql.Append(" and BeginDT={" + ++i + "}");
                list.Add(bean.BeginDT);
            }
            if (bean.EndDT != null)
            {
                sql.Append(" and EndDT={" + ++i + "}");
                list.Add(bean.EndDT);
            }
            if (bean.Price != null)
            {
                sql.Append(" and Price={" + ++i + "}");
                list.Add(bean.Price);
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

        public override DataTable QueryByPage(ChargPrice bean, int page, int rows)
        {
            throw new NotImplementedException();
        }

        public override DataTable QueryByPage(ChargPrice bean, int page, int rows, ref int count)
        {
            Log.Debug("QueryByPage方法参数：" + bean);
            var getpage = new GetPage();
            var sql = new StringBuilder();
            sql.Append("select * from sm_useroles where 1=1 ");

            if (!string.IsNullOrEmpty(bean.Id))
                sql.Append(" and Id={" + bean.Id + "}");

            if (!string.IsNullOrEmpty(bean.Name))
                sql.Append(" and Name={" + bean.Name + "}");

            if (!string.IsNullOrEmpty(bean.PriceType))
                sql.Append(" and PriceType={" + bean.PriceType + "}");

            if (bean.Version != null)
                sql.Append(" and Version={" + bean.Version + "}");

            if (bean.BeginDT != null)
                sql.Append(" and BeginDT={" + bean.BeginDT + "}");

            if (bean.EndDT != null)
                sql.Append(" and EndDT={" + bean.EndDT + "}");

            if (bean.Price != null)
                sql.Append(" and Price={" + bean.Price + "}");

            if (bean.CreateDT != null)
                sql.Append(" and CreateDT={" + bean.CreateDT + "}");

            if (bean.UpdateDT != null)
                sql.Append(" and UpdateDT={" + bean.UpdateDT + "}");
            Log.Debug("SQL :" + sql);
            return getpage.GetPageByProcedure(page, rows, sql.ToString(), ref count);
        }
    }
}

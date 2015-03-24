using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ChargingPile.Model;

namespace ChargingPile.DAL
{
    public class ResMenuDal : BaseDal<ResMenu>
    {
        public override bool Exist(ResMenu bean)
        {
            Log.Debug("exist方法");
            var sql = "select * from sm_resmenu t where ResId='" + bean.ResId + "'";
            var dt = Oop.GetDataTable(sql);
            return dt.Rows.Count > 0;
        }

        public override void Add(ResMenu bean)
        {
            Log.Debug("Add方法参数：" + bean.ToString());
            var sql1 = new StringBuilder();
            var sql2 = new StringBuilder();
            var i = 0;
            var list = new List<object>();
            if (!string.IsNullOrEmpty(bean.ResId))
            {
                sql1.Append(" ResId,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.ResId);
            }
            if (!string.IsNullOrEmpty(bean.ParentId))
            {
                sql1.Append(" ParentId,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.ParentId);
            }
            if (!string.IsNullOrEmpty(bean.Caption))
            {
                sql1.Append(" Caption,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.Caption);
            }
            if (!string.IsNullOrEmpty(bean.Href))
            {
                sql1.Append(" Href,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.Href);
            }
            if (bean.SortNo != null)
            {
                sql1.Append(" SortNo,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.SortNo);
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
            var sql = "insert into sm_resmenu(" + sql1 + ") values(" + sql2 + ")";
            Oop.Execute(sql, list.ToArray());
        }

        public override void Del(ResMenu bean)
        {
            Log.Debug("del方法参数：");
            var sql = "delete from sm_resmenu where ResId='" + bean.ResId + "'";
            Oop.Execute(sql);
        }

        public override void Modify(ResMenu bean)
        {
            Log.Debug("Modify方法参数：" + bean);
            var sql = new StringBuilder();
            sql.Append("update sm_resmenu set");
            var i = 0;
            var dList = new List<object>();
            if (string.IsNullOrEmpty(bean.ParentId))
            {
                sql.Append(" ParentId={" + i++ + "}");
                dList.Add(bean.ParentId);
            }
            if (string.IsNullOrEmpty(bean.Caption))
            {
                sql.Append(" Caption={" + i++ + "}");
                dList.Add(bean.Caption);
            }
            if (string.IsNullOrEmpty(bean.Href))
            {
                sql.Append(" Href={" + i++ + "}");
                dList.Add(bean.Href);
            }
            if (bean.SortNo != null)
            {
                sql.Append(" SortNo={" + i++ + "}");
                dList.Add(bean.SortNo);
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
            sql.Append(" where ResId={" + i++ + "}");
            dList.Add(bean.ResId);
            Oop.Execute(sql.ToString(), dList.ToArray());
        }

        public override DataTable Query(ResMenu bean)
        {
            Log.Debug("Query方法参数：" + bean);
            var sql = new StringBuilder();
            sql.Append("select * from sm_resmenu where 1=1 ");
            var list = new List<object>();
            var i = -1;
            if (!string.IsNullOrEmpty(bean.ResId))
            {
                sql.Append(" and ResId={" + ++i + "}");
                list.Add(bean.ResId);
            }
            if (!string.IsNullOrEmpty(bean.ParentId))
            {
                sql.Append(" and ParentId={" + ++i + "}");
                list.Add(bean.ParentId);
            }
            if (!string.IsNullOrEmpty(bean.Caption))
            {
                sql.Append(" and Caption={" + ++i + "}");
                list.Add(bean.Caption);
            }
            if (!string.IsNullOrEmpty(bean.Href))
            {
                sql.Append(" and Href={" + ++i + "}");
                list.Add(bean.Href);
            }
            if (bean.SortNo != null)
            {
                sql.Append(" and SortNo={" + ++i + "}");
                list.Add(bean.SortNo);
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
            sql.Append(" order by sortno");
            return Oop.GetDataTable(sql.ToString(), list.ToArray());
        }

        public override DataTable QueryByPage(ResMenu bean, int page, int rows)
        {
            throw new NotImplementedException();
        }

        public override DataTable QueryByPage(ResMenu bean, int page, int rows, ref int count)
        {
            Log.Debug("QueryByPage方法参数：" + bean);
            var getpage = new GetPage();
            var sql = new StringBuilder();
            sql.Append("select * from sm_resmenu where 1=1 ");

            if (!string.IsNullOrEmpty(bean.ResId))
                sql.Append(" and ResId={" + bean.ResId + "}");

            if (!string.IsNullOrEmpty(bean.ParentId))
                sql.Append(" and ParentId={" + bean.ParentId + "}");

            if (!string.IsNullOrEmpty(bean.Caption))
                sql.Append(" and Caption={" + bean.Caption + "}");

            if (!string.IsNullOrEmpty(bean.Href))
                sql.Append(" and Href={" + bean.Href + "}");

            if (bean.SortNo != null)
                sql.Append(" and SortNo={" + bean.SortNo + "}");

            if (bean.CreateDT != null)
                sql.Append(" and CreateDT={" + bean.CreateDT + "}");

            if (bean.UpdateDT != null)
                sql.Append(" and UpdateDT={" + bean.UpdateDT + "}");

            return getpage.GetPageByProcedure(page, rows, sql.ToString(), ref count);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable FindBy()
        {
            Log.Debug("FindBy方法参数：");
            var sql = new StringBuilder();
            sql.Append("select * from sm_resmenu where parentid is null order by sortno");
            return Oop.GetDataTable(sql.ToString());
        }
    }
}

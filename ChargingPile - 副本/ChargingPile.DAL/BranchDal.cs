using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ChargingPile.Model;

namespace ChargingPile.DAL
{
    public class BranchDal : BaseDal<Branch>
    {
        public override bool Exist(Branch bean)
        {
            Log.Debug("exist方法");
            var sql = "select * from dev_branch t where BranchNo='" + bean.BranchNo + "'";
            var dt = Oop.GetDataTable(sql);
            return dt.Rows.Count > 0;
        }

        public override void Add(Branch bean)
        {
            Log.Debug("Add方法参数：" + bean.ToString());
            var sql1 = new StringBuilder();
            var sql2 = new StringBuilder();
            var i = 0;
            var list = new List<object>();
            if (bean.BranchNo != null)
            {
                sql1.Append(" BranchNo,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.BranchNo);
            }
            if (bean.ZhuanBh != null)
            {
                sql1.Append(" ZhuanBh,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.ZhuanBh);
            }
            if (!string.IsNullOrEmpty(bean.ChanQuanGx))
            {
                sql1.Append(" ChanQuanGx,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.ChanQuanGx);
            }
            if (!string.IsNullOrEmpty(bean.YunWeiDw))
            {
                sql1.Append(" YunWeiDw,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.YunWeiDw);
            }
            if (!string.IsNullOrEmpty(bean.ChangJia))
            {
                sql1.Append(" ChangJia,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.ChangJia);
            }
            if (!string.IsNullOrEmpty(bean.FenZhiXlx))
            {
                sql1.Append(" FenZhiXlx,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.FenZhiXlx);
            }
            if (bean.Createdt != null)
            {
                sql1.Append(" Createdt,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.Createdt);
            }
            if (bean.Updatedt != null)
            {
                sql1.Append(" Updatedt,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.Updatedt);
            }
            if (!string.IsNullOrEmpty(bean.ZhiChanBh))
            {
                sql1.Append(" ZhiChanBh,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.ZhiChanBh);
            }
            if (sql1.Length > 0)
            {
                sql1 = sql1.Remove(sql1.Length - 1, 1);
                sql2 = sql2.Remove(sql2.Length - 1, 1);
            }
            var sql = "insert into dev_branch(" + sql1 + ") values(" + sql2 + ")";
            Oop.Execute(sql, list.ToArray());
        }

        public override void Del(Branch bean)
        {
            Log.Debug("del方法参数：");
            var sql = new StringBuilder();
            sql.Append("delete from dev_branch where BranchNo='" + bean.BranchNo + "'");
            Oop.Execute(sql.ToString());
        }

        public override void Modify(Branch bean)
        {
            Log.Debug("Modify方法参数：" + bean);
            var sql = new StringBuilder();
            sql.Append("update dev_branch set");
            var i = 0;
            var dList = new List<object>();

            if (bean.ZhuanBh != null)
            {
                sql.Append(" ZhuanBh={" + i++ + "},");
                dList.Add(bean.ZhuanBh);
            }
            if (!string.IsNullOrEmpty(bean.ChanQuanGx))
            {
                sql.Append(" ChanQuanGx={" + i++ + "},");
                dList.Add(bean.ChanQuanGx);
            }
            if (!string.IsNullOrEmpty(bean.YunWeiDw))
            {
                sql.Append(" YunWeiDw={" + i++ + "},");
                dList.Add(bean.YunWeiDw);
            }
            if (!string.IsNullOrEmpty(bean.ChangJia))
            {
                sql.Append(" ChangJia={" + i++ + "},");
                dList.Add(bean.ChangJia);
            }
            if (!string.IsNullOrEmpty(bean.FenZhiXlx))
            {
                sql.Append(" FenZhiXlx={" + i++ + "},");
                dList.Add(bean.FenZhiXlx);
            }
            if (bean.Createdt != null)
            {
                sql.Append(" Createdt={" + i++ + "},");
                dList.Add(bean.Createdt);
            }
            if (bean.Updatedt != null)
            {
                sql.Append(" Updatedt={" + i++ + "},");
                dList.Add(bean.Updatedt);
            }
            if (!string.IsNullOrEmpty(bean.ZhiChanBh))
            {
                sql.Append(" ZhiChanBh={" + i++ + "},");
                dList.Add(bean.ZhiChanBh);
            }
            if (sql.Length > 0)
            {
                sql = sql.Remove(sql.Length - 1, 1);
            }
            sql.Append(" where BranchNo={" + i++ + "}");
            dList.Add(bean.BranchNo);
            Oop.Execute(sql.ToString(), dList.ToArray());
        }

        public override DataTable Query(Branch bean)
        {
            Log.Debug("Query方法参数：" + bean);
            var sql = new StringBuilder();
            sql.Append("select t.* from cfg_chargprice t where 1=1 ");
            var list = new List<object>();
            var i = -1;
            if (bean.BranchNo != null)
            {
                sql.Append(" and BranchNo={" + ++i + "}");
                list.Add(bean.BranchNo);
            }
            if (bean.ZhuanBh != null)
            {
                sql.Append(" and ZhuanBh={" + ++i + "}");
                list.Add(bean.ZhuanBh);
            }
            if (!string.IsNullOrEmpty(bean.ChanQuanGx))
            {
                sql.Append(" and ChanQuanGx={" + ++i + "}");
                list.Add(bean.ChanQuanGx);
            }
            if (!string.IsNullOrEmpty(bean.YunWeiDw))
            {
                sql.Append(" and YunWeiDw={" + ++i + "}");
                list.Add(bean.YunWeiDw);
            }
            if (!string.IsNullOrEmpty(bean.ChangJia))
            {
                sql.Append(" and ChangJia={" + ++i + "}");
                list.Add(bean.ChangJia);
            }
            if (!string.IsNullOrEmpty(bean.FenZhiXlx))
            {
                sql.Append(" and FenZhiXlx={" + ++i + "}");
                list.Add(bean.FenZhiXlx);
            }
            if (bean.Createdt != null)
            {
                sql.Append(" and Createdt={" + ++i + "}");
                list.Add(bean.Createdt);
            }
            if (bean.Updatedt != null)
            {
                sql.Append(" and Updatedt={" + ++i + "}");
                list.Add(bean.Updatedt);
            }
            if (!string.IsNullOrEmpty(bean.ZhiChanBh))
            {
                sql.Append(" and ZhiChanBh={" + ++i + "}");
                list.Add(bean.ZhiChanBh);
            }
            return Oop.GetDataTable(sql.ToString(), list.ToArray());
        }

        public override DataTable QueryByPage(Branch bean, int page, int rows)
        {
            throw new NotImplementedException();
        }

        public override DataTable QueryByPage(Branch bean, int page, int rows, ref int count)
        {
            Log.Debug("QueryByPage方法参数：" + bean);
            var getpage = new GetPage();
            var sql = new StringBuilder();
            sql.Append("select * from dev_branch where 1=1 ");

            if (bean.BranchNo != null)
                sql.Append(" and BranchNo={" + bean.BranchNo + "}");

            if (bean.ZhuanBh != null)
                sql.Append(" and ZhuanBh={" + bean.ZhuanBh + "}");

            if (!string.IsNullOrEmpty(bean.ChanQuanGx))
                sql.Append(" and ChanQuanGx={" + bean.ChanQuanGx + "}");

            if (!string.IsNullOrEmpty(bean.YunWeiDw))
                sql.Append(" and YunWeiDw={" + bean.YunWeiDw + "}");

            if (!string.IsNullOrEmpty(bean.ChangJia))
                sql.Append(" and ChangJia={" + bean.ChangJia + "}");

            if (!string.IsNullOrEmpty(bean.FenZhiXlx))
                sql.Append(" and FenZhiXlx={" + bean.FenZhiXlx + "}");

            if (bean.Createdt != null)
                sql.Append(" and Createdt={" + bean.Createdt + "}");

            if (bean.Updatedt != null)
                sql.Append(" and Updatedt={" + bean.Updatedt + "}");

            if (!string.IsNullOrEmpty(bean.ZhiChanBh))
                sql.Append(" and ZhiChanBh={" + bean.ZhiChanBh + "}");

            return getpage.GetPageByProcedure(page, rows, sql.ToString(), ref count);
        }
    }
}

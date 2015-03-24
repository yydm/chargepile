using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ChargingPile.Model;
using YOUO.Framework.DataAccess;

namespace ChargingPile.DAL
{
    public class IcCard
    {
        protected SQLServerOperator Sso = new SQLServerOperator(System.Configuration.ConfigurationSettings.AppSettings["sqlserverConnectionString"]);
        protected OracleOperator Oop = new OracleOperator(System.Configuration.ConfigurationSettings.AppSettings["DBConnectionString"]);
        protected log4net.ILog Log = log4net.LogManager.GetLogger("IcCard");

        /// <summary>
        /// 查询IC卡详细信息
        /// </summary>
        /// <param name="bean"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public DataTable QueryCardInfo(CardInfo bean, int page, int rows, ref int count)
        {
            StringBuilder sql = new StringBuilder(@"SELECT [ID],[卡号] ,[户主姓名],
 (select name from [PSYSDIC] ps where ps.DICID='证件名称' and ps.VALUE=t.户主证件名称) [户主证件名称1],
(select name from [PSYSDIC] ps where ps.DICID='卡状态' and ps.VALUE=t.卡状态) [卡状态1],
(select name from [PSYSDIC] ps where ps.DICID='卡类型' and ps.VALUE=t.卡类型) [卡类型1],
[户主证件号码],[有效期],[余额],[密码],[卡地址],[电话],[固话],[邮箱],[备注]  FROM [IC卡信息表] t where 1=1 ");
            string sqlCount = "select count(*) from [IC卡信息表] where 1=1 ";
            StringBuilder sqlWhere = new StringBuilder();
            List<object> list = new List<object>();
            var i = -1;
            if (!string.IsNullOrEmpty(bean.CardId))
            {
                sqlWhere.Append(" and [卡号] like {" + ++i + "}");
                list.Add("%" + bean.CardId + "%");
            }
            if (!string.IsNullOrEmpty(bean.Name))
            {
                sqlWhere.Append(" and [户主姓名] like {" + ++i + "}");
                list.Add("%" + bean.Name + "%");
            }
            if (!string.IsNullOrEmpty(bean.Zjmc))
            {
                sqlWhere.Append(" and [户主证件名称]={" + ++i + "}");
                list.Add(bean.Zjmc);
            }
            if (!string.IsNullOrEmpty(bean.Zjhm))
            {
                sqlWhere.Append(" and [户主证件号码] like {" + ++i + "}");
                list.Add("%" + bean.Zjhm + "%");
            }
            if (!string.IsNullOrEmpty(bean.Kzt))
            {
                sqlWhere.Append(" and [卡状态]={" + ++i + "}");
                list.Add(bean.Kzt);
            }
            if (!string.IsNullOrEmpty(bean.Klx))
            {
                sqlWhere.Append(" and [卡类型]={" + ++i + "}");
                list.Add(bean.Klx);
            }
            if (bean.DateBegin != DateTime.MinValue)
            {
                sqlWhere.Append(" and [有效期] > {" + ++i + "}");
                list.Add(bean.DateBegin.AddDays(-1));
            }
            if (bean.DateEnd != DateTime.MinValue)
            {
                sqlWhere.Append(" and [有效期] < {" + ++i + "}");
                list.Add(bean.DateEnd.AddDays(1));
            }
            count = int.Parse(Sso.GetScalar(sqlCount + sqlWhere.ToString(), list.ToArray()).ToString());
            return Sso.GetDataTableByPage(sql.Append(sqlWhere).Append(" order by ID").ToString(), (page - 1) * rows, rows, list.ToArray());
        }

        /// <summary>
        /// 查询充值记录
        /// </summary>
        /// <param name="bean"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public DataTable QueryCzjl(CardInfo bean, int page, int rows, ref int count)
        {
            StringBuilder sql = new StringBuilder(@"SELECT [ID],
(select name from [PSYSDIC] ps where ps.DICID='充值方式' and ps.VALUE=t.充值方式) [充值方式1]
,[IC卡号],[充值金额],[余额],[转账卡号],[充值时间],[充值网点代码],[操作员工号]
  FROM [充值记录表] t where 1=1 ");
            string sqlCount = "select count(*) from [充值记录表] where 1=1 ";
            StringBuilder sqlWhere = new StringBuilder();
            List<object> list = new List<object>();
            var i = -1;
            if (!string.IsNullOrEmpty(bean.CardId))
            {
                sqlWhere.Append(" and [IC卡号] like {" + ++i + "}");
                list.Add("%" + bean.CardId + "%");
            }
            if (!string.IsNullOrEmpty(bean.Czy))
            {
                sqlWhere.Append(" and [操作员工号] in (select [工号] from [员工信息表] em where em.[姓名] like {" + ++i + "})");
                list.Add("%" + bean.Czy + "%");
            }
            if (!string.IsNullOrEmpty(bean.Czwd))
            {
                sqlWhere.Append(" and [充值网点代码] like {" + ++i + "}");
                list.Add("%" + bean.Czwd + "%");
            }
            if (!string.IsNullOrEmpty(bean.Czfs))
            {
                sqlWhere.Append(" and [充值方式]={" + ++i + "}");
                list.Add(bean.Czfs);
            }
            if (bean.DateBegin != DateTime.MinValue)
            {
                sqlWhere.Append(" and [充值时间] > {" + ++i + "}");
                list.Add(bean.DateBegin.AddDays(-1));
            }
            if (bean.DateEnd != DateTime.MinValue)
            {
                sqlWhere.Append(" and [充值时间] < {" + ++i + "}");
                list.Add(bean.DateEnd.AddDays(1));
            }
            count = int.Parse(Sso.GetScalar(sqlCount + sqlWhere.ToString(), list.ToArray()).ToString());
            return Sso.GetDataTableByPage(sql.Append(sqlWhere).Append(" order by ID").ToString(), (page - 1) * rows, rows, list.ToArray());
        }

        /// <summary>
        /// 查询挂失信息
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public DataTable QueryGs(CardInfo bean, int page, int rows, ref int count)
        {
            StringBuilder sql = new StringBuilder(@"SELECT [ID],[卡号] ,[户主姓名],
 (select name from [PSYSDIC] ps where ps.DICID='证件名称' and ps.VALUE=t.户主证件名称) [户主证件名称1],
(select name from [PSYSDIC] ps where ps.DICID='卡状态' and ps.VALUE=t.卡状态) [卡状态1],
(select name from [PSYSDIC] ps where ps.DICID='卡类型' and ps.VALUE=t.卡类型) [卡类型1],
[户主证件号码],[有效期],[余额],[密码],[卡地址],[电话],[固话],[邮箱],[备注]  FROM [IC卡信息表] t where t.卡状态=7 ");
            string sqlCount = "select count(*) from [IC卡信息表] t where t.卡状态=7 ";
            count = int.Parse(Sso.GetScalar(sqlCount).ToString());
            return Sso.GetDataTableByPage(sql.Append(" order by [卡号]").ToString(), (page - 1) * rows, rows);
        }

        /// <summary>
        /// 查询卡异常使用记录
        /// </summary>
        /// <param name="bean"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public DataTable QueryExp(CardInfo bean, int page, int rows, ref int count)
        {
            string sqlCardId = @"select t.targetdatakey 卡号,t.occurdt 发生时间,
(select dcs.zhan_jc from dev_chargstation dcs where dcs.zhan_bh=subStr(t.targetdev,0,3)) 站名称,
(select dcp.yunxing_bh from dev_chargpile dcp where dcp.dev_chargpile=t.targetdev) 桩运行编号 
from oth_warnrec t where t.targettype='003'  order by t.occurdt desc";
            DataTable dtCardId = Oop.GetDataTableByPage(sqlCardId, (page - 1) * rows, rows);
            string sqlCount = @"select count(*) from oth_warnrec t where t.targettype='003'";
            count = int.Parse(Oop.GetScalar(sqlCount).ToString());
            var ids = "";
            foreach (DataRow row in dtCardId.Rows)
            {
                ids += "'" + row["卡号"].ToString() + "',";
            }
            if (ids.Length > 0)
            {
                ids = ids.Substring(0, ids.Length - 1);
            }
            string sql = @"SELECT [卡号],[户主姓名],[户主证件号码],[有效期],[余额],[卡地址],[电话],[固话],[邮箱],[备注],
(select name from [PSYSDIC] ps where ps.DICID='证件名称' and ps.VALUE=t.户主证件名称) [户主证件名称],
(select name from [PSYSDIC] ps where ps.DICID='卡状态' and ps.VALUE=t.卡状态) [卡状态],
(select name from [PSYSDIC] ps where ps.DICID='卡类型' and ps.VALUE=t.卡类型) [卡类型]
  FROM [IC卡信息表] t where t.[卡号] in (" + ids + ")";
            DataTable dtCardInfo = Sso.GetDataTable(sql);
            dtCardId.Columns.Add("户主姓名", typeof(string));
            dtCardId.Columns.Add("户主证件名称", typeof(string));
            dtCardId.Columns.Add("户主证件号码", typeof(string));
            dtCardId.Columns.Add("有效期", typeof(string));
            dtCardId.Columns.Add("余额", typeof(string));
            dtCardId.Columns.Add("卡状态", typeof(string));
            dtCardId.Columns.Add("卡类型", typeof(string));
            dtCardId.Columns.Add("卡地址", typeof(string));
            dtCardId.Columns.Add("电话", typeof(string));
            dtCardId.Columns.Add("固话", typeof(string));
            dtCardId.Columns.Add("邮箱", typeof(string));
            dtCardId.Columns.Add("备注", typeof(string));
            foreach (DataRow rowId in dtCardId.Rows)
            {
                foreach (DataRow rowInfo in dtCardInfo.Rows)
                {
                    if (rowId["卡号"].ToString() == rowInfo["卡号"].ToString())
                    {
                        rowId["户主姓名"] = rowInfo["户主姓名"].ToString();
                        rowId["户主证件名称"] = rowInfo["户主证件名称"].ToString();
                        rowId["户主证件号码"] = rowInfo["户主证件号码"].ToString();
                        rowId["有效期"] = rowInfo["有效期"].ToString();
                        rowId["余额"] = rowInfo["余额"].ToString();
                        rowId["卡状态"] = rowInfo["卡状态"].ToString();
                        rowId["卡类型"] = rowInfo["卡类型"].ToString();
                        rowId["卡地址"] = rowInfo["卡地址"].ToString();
                        rowId["电话"] = rowInfo["电话"].ToString();
                        rowId["固话"] = rowInfo["固话"].ToString();
                        rowId["邮箱"] = rowInfo["邮箱"].ToString();
                        rowId["备注"] = rowInfo["备注"].ToString();
                        break;
                    }
                }
            }
            return dtCardId;
        }

        /// <summary>
        /// 查询PsysDic表
        /// </summary>
        /// <param name="dicId">根据字段dicId查询</param>
        /// <returns></returns>
        public DataTable QueryPsysDic(string dicId)
        {
            const string sql = @"SELECT [ID],[DICID],[NAME],[VALUE],[CHARVAL]
  FROM [PSYSDIC] ps where ps.DICID={0} order by ps.ID";
            return Sso.GetDataTable(sql, dicId);
        }
    }
}

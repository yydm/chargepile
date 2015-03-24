using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using ChargingPile.Model;

namespace ChargingPile.DAL
{
    public class SmsOutBoxDal : BaseDal<SmsOutBox>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bean"></param>
        /// <returns></returns>
        public override bool Exist(SmsOutBox bean)
        {
            var sql = new StringBuilder("select * from msg_outbox where 1=1");
            var list = new List<object>();
            var i = 0;
            if (!string.IsNullOrEmpty(bean.Msgid.ToString(CultureInfo.InvariantCulture)))
            {
                sql.Append(" and Msgid={" + i++ + "}");
                list.Add(bean.Msgid);
            }
            if (!string.IsNullOrEmpty(bean.Expresslevel.ToString(CultureInfo.InvariantCulture)))
            {
                sql.Append(" and Expresslevel={" + i++ + "}");
                list.Add(bean.Expresslevel);
            }
            if (!string.IsNullOrEmpty(bean.Sender))
            {
                sql.Append(" and Sender={" + i++ + "}");
                list.Add(bean.Sender);
            }
            if (!string.IsNullOrEmpty(bean.Receiver))
            {
                sql.Append(" and Receiver={" + i++ + "}");
                list.Add(bean.Receiver);
            }
            if (!string.IsNullOrEmpty(bean.Msgtype.ToString(CultureInfo.InvariantCulture)))
            {
                sql.Append(" and Msgtype={" + i++ + "}");
                list.Add(bean.Msgtype);
            }
            if (!string.IsNullOrEmpty(bean.Msgtitle))
            {
                sql.Append(" and Msgtitle={" + i++ + "}");
                list.Add(bean.Msgtitle);
            }
            if (!string.IsNullOrEmpty(bean.Mmscontentlocation))
            {
                sql.Append(" and Mmscontentlocation={" + i++ + "}");
                list.Add(bean.Mmscontentlocation);
            }
            if (!string.IsNullOrEmpty(bean.Sendtime.ToString()))
            {
                sql.Append(" and Sendtime={" + i++ + "}");
                list.Add(bean.Sendtime);
            }
            if (!string.IsNullOrEmpty(bean.Commport.ToString(CultureInfo.InvariantCulture)))
            {
                sql.Append(" and Commport={" + i + "}");
                list.Add(bean.Commport);
            }
            var dt = Oop.GetDataTable(sql.ToString(), list.ToArray());
            return dt != null && dt.Rows.Count > 0;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bean"></param>
        public override void Add(SmsOutBox bean)
        {
            var sql1 = new StringBuilder();
            var sql2 = new StringBuilder();
            var i = 0;
            var list = new List<object>();
            //if (bean.Msgid != 0)
            //{
            //    sql1.Append(" Msgid,");
            //    sql2.Append(" {" + i++ + "},");
            //    list.Add(bean.Msgid);
            //}
            // if (!string.IsNullOrEmpty(bean.Expresslevel.ToString(CultureInfo.InvariantCulture)))
            //{
            //     sql1.Append(" Expresslevel,");
            //     sql2.Append(" {" + i++ + "},");
            //    list.Add(bean.Expresslevel);
            //}
            //if (!string.IsNullOrEmpty(bean.Sender))
            //{
            //    sql1.Append(" Sender,");
            //    sql2.Append(" {" + i++ + "},");
            //    list.Add(bean.Sender);
            //}
            if (!string.IsNullOrEmpty(bean.Receiver))
            {
                sql1.Append(" Receiver,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.Receiver);
            }

            if (!string.IsNullOrEmpty(bean.Msgtype.ToString(CultureInfo.InvariantCulture)))
            {
                sql1.Append(" Msgtype,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.Msgtype);
            }

            if (!string.IsNullOrEmpty(bean.Msgtitle))
            {
                sql1.Append(" Msgtitle,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.Msgtitle);
            }

            if (!string.IsNullOrEmpty(bean.Mmscontentlocation))
            {
                sql1.Append(" Mmscontentlocation,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.Mmscontentlocation);
            }

            if (!string.IsNullOrEmpty(bean.Sendtime.ToString()))
            {
                sql1.Append(" Sendtime,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.Sendtime);
            }

            // if (!string.IsNullOrEmpty(bean.Commport.ToString(CultureInfo.InvariantCulture)))
            // {
            //    sql1.Append(" Commport,");
            //    sql2.Append(" {" + i + "},");
            //    list.Add(bean.Commport);
            //}

            if (sql1.Length > 0)
            {
                sql1 = sql1.Remove(sql1.Length - 1, 1);
                sql2 = sql2.Remove(sql2.Length - 1, 1);
            }

            var sql = "insert into msg_outbox(" + sql1 + ") values(" + sql2 + ")";
            Oop.Execute(sql, list.ToArray());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bean"></param>
        public override void Del(SmsOutBox bean)
        {
            string sql = "delete from msg_outbox p where p.msgid={0}";
            Oop.Execute(sql, bean.Msgid);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bean"></param>
        public override void Modify(SmsOutBox bean)
        {
            var sql = new StringBuilder("update msg_outbox set");
            var i = 0;
            var list = new List<object>();
            if (!string.IsNullOrEmpty(bean.Msgid.ToString(CultureInfo.InvariantCulture)))
            {
                sql.Append(" Msgid={" + i++ + "},");
                list.Add(bean.Msgid);
            }
            if (!string.IsNullOrEmpty(bean.Expresslevel.ToString(CultureInfo.InvariantCulture)))
            {
                sql.Append(" Expresslevel={" + i++ + "},");
                list.Add(bean.Expresslevel);
            }
            if (!string.IsNullOrEmpty(bean.Sender))
            {
                sql.Append(" Sender={" + i++ + "},");
                list.Add(bean.Sender);
            }
            if (!string.IsNullOrEmpty(bean.Receiver))
            {
                sql.Append(" Receiver={" + i++ + "},");
                list.Add(bean.Receiver);
            }
            if (!string.IsNullOrEmpty(bean.Msgtype.ToString(CultureInfo.InvariantCulture)))
            {
                sql.Append(" Msgtype={" + i++ + "},");
                list.Add(bean.Msgtype);
            }
            if (!string.IsNullOrEmpty(bean.Msgtitle))
            {
                sql.Append(" Msgtitle={" + i++ + "},");
                list.Add(bean.Msgtitle);
            }
            if (!string.IsNullOrEmpty(bean.Mmscontentlocation))
            {
                sql.Append(" Mmscontentlocation={" + i++ + "},");
                list.Add(bean.Mmscontentlocation);
            }
            if (!string.IsNullOrEmpty(bean.Sendtime.ToString()))
            {
                sql.Append(" Sendtime={" + i++ + "},");
                list.Add(bean.Sendtime);
            }
            if (!string.IsNullOrEmpty(bean.Commport.ToString(CultureInfo.InvariantCulture)))
            {
                sql.Append(" Commport={" + i++ + "},");
                list.Add(bean.Commport);
            }
            sql = sql.Remove(sql.Length - 1, 1);
            sql.Append(" where id={" + i + "}");
            list.Add(bean.Msgid);
            Oop.Execute(sql.ToString(), list.ToArray());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bean"></param>
        /// <returns></returns>
        public override DataTable Query(SmsOutBox bean)
        {
            var sql = new StringBuilder();
            sql.Append("select * from msg_outbox where 1=1 ");
            var list = new List<object>();
            var i = 0;
            if (!string.IsNullOrEmpty(bean.Msgid.ToString(CultureInfo.InvariantCulture)))
            {
                sql.Append(" and Msgid={" + i++ + "}");
                list.Add(bean.Msgid);
            }
            if (!string.IsNullOrEmpty(bean.Expresslevel.ToString(CultureInfo.InvariantCulture)))
            {
                sql.Append(" and Expresslevel={" + i++ + "}");
                list.Add(bean.Expresslevel);
            }
            if (!string.IsNullOrEmpty(bean.Sender))
            {
                sql.Append(" and Sender={" + i++ + "}");
                list.Add(bean.Sender);
            }
            if (!string.IsNullOrEmpty(bean.Receiver))
            {
                sql.Append(" and Receiver={" + i++ + "}");
                list.Add(bean.Receiver);
            }
            if (!string.IsNullOrEmpty(bean.Msgtype.ToString(CultureInfo.InvariantCulture)))
            {
                sql.Append(" and Msgtype={" + i++ + "}");
                list.Add(bean.Msgtype);
            }
            if (!string.IsNullOrEmpty(bean.Msgtitle))
            {
                sql.Append(" and Msgtitle={" + i++ + "}");
                list.Add(bean.Msgtitle);
            }
            if (!string.IsNullOrEmpty(bean.Mmscontentlocation))
            {
                sql.Append(" and Mmscontentlocation={" + i++ + "}");
                list.Add(bean.Mmscontentlocation);
            }
            if (!string.IsNullOrEmpty(bean.Sendtime.ToString()))
            {
                sql.Append(" and Sendtime={" + i++ + "}");
                list.Add(bean.Sendtime);
            }
            if (!string.IsNullOrEmpty(bean.Commport.ToString(CultureInfo.InvariantCulture)))
            {
                sql.Append(" and Commport={" + i + "}");
                list.Add(bean.Commport);
            }
            return Oop.GetDataTable(sql.ToString(), list.ToArray());
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="bean"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public override DataTable QueryByPage(SmsOutBox bean, int page, int rows)
        {
            var sql = new StringBuilder();
            sql.Append("select * from msg_outbox where 1=1 ");
            var list = new List<object>();
            var i = 0;
            if (!string.IsNullOrEmpty(bean.Msgid.ToString(CultureInfo.InvariantCulture)))
            {
                sql.Append(" and Msgid={" + i++ + "}");
                list.Add(bean.Msgid);
            }
            if (!string.IsNullOrEmpty(bean.Expresslevel.ToString(CultureInfo.InvariantCulture)))
            {
                sql.Append(" and Expresslevel={" + i++ + "}");
                list.Add(bean.Expresslevel);
            }
            if (!string.IsNullOrEmpty(bean.Sender))
            {
                sql.Append(" and Sender={" + i++ + "}");
                list.Add(bean.Sender);
            }
            if (!string.IsNullOrEmpty(bean.Receiver))
            {
                sql.Append(" and Receiver={" + i++ + "}");
                list.Add(bean.Receiver);
            }
            if (!string.IsNullOrEmpty(bean.Msgtype.ToString(CultureInfo.InvariantCulture)))
            {
                sql.Append(" and Msgtype={" + i++ + "}");
                list.Add(bean.Msgtype);
            }
            if (!string.IsNullOrEmpty(bean.Msgtitle))
            {
                sql.Append(" and Msgtitle={" + i++ + "}");
                list.Add(bean.Msgtitle);
            }
            if (!string.IsNullOrEmpty(bean.Mmscontentlocation))
            {
                sql.Append(" and Mmscontentlocation={" + i++ + "}");
                list.Add(bean.Mmscontentlocation);
            }
            if (!string.IsNullOrEmpty(bean.Sendtime.ToString()))
            {
                sql.Append(" and Sendtime={" + i++ + "}");
                list.Add(bean.Sendtime);
            }
            if (!string.IsNullOrEmpty(bean.Commport.ToString(CultureInfo.InvariantCulture)))
            {
                sql.Append(" and Commport={" + i + "}");
                list.Add(bean.Commport);
            }

            return Oop.GetDataTableByPage(sql.ToString(), (page - 1) * rows, rows, list.ToArray());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bean"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public override DataTable QueryByPage(SmsOutBox bean, int page, int rows, ref int count)
        {
            var getpage = new GetPage();
            var sql = new StringBuilder();
            sql.Append("select * from msg_outbox where 1=1 ");
            var list = new List<object>();
            var i = 0;
            if (!string.IsNullOrEmpty(bean.Msgid.ToString(CultureInfo.InvariantCulture)))
            {
                sql.Append(" and Msgid={" + i++ + "}");
                list.Add(bean.Msgid);
            }
            if (!string.IsNullOrEmpty(bean.Expresslevel.ToString(CultureInfo.InvariantCulture)))
            {
                sql.Append(" and Expresslevel={" + i++ + "}");
                list.Add(bean.Expresslevel);
            }
            if (!string.IsNullOrEmpty(bean.Sender))
            {
                sql.Append(" and Sender={" + i++ + "}");
                list.Add(bean.Sender);
            }
            if (!string.IsNullOrEmpty(bean.Receiver))
            {
                sql.Append(" and Receiver={" + i++ + "}");
                list.Add(bean.Receiver);
            }
            if (!string.IsNullOrEmpty(bean.Msgtype.ToString(CultureInfo.InvariantCulture)))
            {
                sql.Append(" and Msgtype={" + i++ + "}");
                list.Add(bean.Msgtype);
            }
            if (!string.IsNullOrEmpty(bean.Msgtitle))
            {
                sql.Append(" and Msgtitle={" + i++ + "}");
                list.Add(bean.Msgtitle);
            }
            if (!string.IsNullOrEmpty(bean.Mmscontentlocation))
            {
                sql.Append(" and Mmscontentlocation={" + i++ + "}");
                list.Add(bean.Mmscontentlocation);
            }
            if (!string.IsNullOrEmpty(bean.Sendtime.ToString()))
            {
                sql.Append(" and Sendtime={" + i++ + "}");
                list.Add(bean.Sendtime);
            }
            if (!string.IsNullOrEmpty(bean.Commport.ToString(CultureInfo.InvariantCulture)))
            {
                sql.Append(" and Commport={" + i + "}");
                list.Add(bean.Commport);
            }

            return getpage.GetPageByProcedure(page, rows, sql.ToString(), ref count);
        }
    }
}

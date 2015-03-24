using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ChargingPile.Model;

namespace ChargingPile.DAL
{
    public class OprLogDal : BaseDal<OprLog>
    {
        public override bool Exist(OprLog bean)
        {
            throw new NotImplementedException();
        }

        public override void Add(OprLog bean)
        {
            Log.Debug("Add方法参数：" + bean.ToString());
            var sql1 = new StringBuilder();
            var sql2 = new StringBuilder();
            var i = 0;
            var list = new List<object>();

            sql1.Append(" Id,");
            sql2.Append(" {" + i++ + "},");
            list.Add(Guid.NewGuid().ToString());

            if (!string.IsNullOrEmpty(bean.DataItemId))
            {
                sql1.Append(" DataItemId,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.DataItemId);
            }
            if (bean.TargetDev != null)
            {
                sql1.Append(" TargetDev,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.TargetDev);
            }
            if (!string.IsNullOrEmpty(bean.Operator))
            {
                sql1.Append(" Operator,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.Operator);
            }
            if (bean.LogDate != null)
            {
                sql1.Append(" LogDate,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.LogDate);
            }
            if (!string.IsNullOrEmpty(bean.OperResult))
            {
                sql1.Append(" OperResult,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.OperResult);
            }

            sql1.Append(" Createdt,");
            sql2.Append(" {" + i++ + "},");
            list.Add(DateTime.Now);

            if (!string.IsNullOrEmpty(bean.OprSrc))
            {
                sql1.Append(" OprSrc,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.OprSrc);
            }
            if (!string.IsNullOrEmpty(bean.OprDest))
            {
                sql1.Append(" OprDest,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.OprDest);
            }
            if (sql1.Length > 0)
            {
                sql1 = sql1.Remove(sql1.Length - 1, 1);
                sql2 = sql2.Remove(sql2.Length - 1, 1);
            }
            var sql = "insert into oth_oprlog(" + sql1 + ") values(" + sql2 + ")";
            Oop.Execute(sql, list.ToArray());
        }

        public override void Del(OprLog bean)
        {
            throw new NotImplementedException();
        }

        public override void Modify(OprLog bean)
        {
            throw new NotImplementedException();
        }

        public override DataTable Query(OprLog bean)
        {
            throw new NotImplementedException();
        }

        public override DataTable QueryByPage(OprLog bean, int page, int rows)
        {
            throw new NotImplementedException();
        }

        public override DataTable QueryByPage(OprLog bean, int page, int rows, ref int count)
        {
            throw new NotImplementedException();
        }
    }
}

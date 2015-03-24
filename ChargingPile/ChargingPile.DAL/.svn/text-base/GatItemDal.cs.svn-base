using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ChargingPile.Model;

namespace ChargingPile.DAL
{
    public class GatItemDal : BaseDal<GatItem>
    {

        public override bool Exist(GatItem bean)
        {
            throw new NotImplementedException();
        }

        public override void Add(GatItem bean)
        {
            throw new NotImplementedException();
        }

        public override void Del(GatItem bean)
        {
            throw new NotImplementedException();
        }

        public override void Modify(GatItem bean)
        {
            throw new NotImplementedException();
        }

        public override DataTable Query(GatItem bean)
        {
            Log.Debug("Query方法的参数为：" + bean.ToString());
            var sql = new StringBuilder();
            sql.Append("select * from gat_item where 1=1 ");
            var list = new List<object>();
            var i = -1;
            if (!string.IsNullOrEmpty(bean.ITEMNO))
            {
                sql.Append(" and itemno={" + ++i + "}");
                list.Add(bean.ITEMNO);
            }
            if (!string.IsNullOrEmpty(bean.ITEMNAME))
            {
                sql.Append(" and itemname={" + ++i + "}");
                list.Add(bean.ITEMNO);
            }
            if (!string.IsNullOrEmpty(bean.ITEMDESC))
            {
                sql.Append(" and itemdesc={" + ++i + "}");
                list.Add(bean.ITEMDESC);
            }
            if (!string.IsNullOrEmpty(bean.REFCONTEXT))
            {
                sql.Append(" and refcontext={" + ++i + "}");
                list.Add(bean.REFCONTEXT);
            }
            if (!string.IsNullOrEmpty(bean.M_UNITS))
            {
                sql.Append(" and m_units={" + ++i + "}");
                list.Add(bean.M_UNITS);
            }
            if (!string.IsNullOrEmpty(bean.DATATYPE))
            {
                sql.Append(" and datatype={" + ++i + "}");
                list.Add(bean.DATATYPE);
            }
            if (!string.IsNullOrEmpty(bean.VALUETYPE))
            {
                sql.Append(" and valuetype={" + ++i + "}");
                list.Add(bean.VALUETYPE);
            }
            return Oop.GetDataTable(sql.ToString(), list.ToArray());
        }

        public DataTable QuerySjxNotUse(string dataType, string pileTypeId)
        {
            const string sql = @"select * from gat_item t where t.datatype={0} and 
not exists (select 1 from gat_pointcfg gp where gp.piletypeid={1} and gp.gatitemid=t.itemno)";
            return Oop.GetDataTable(sql, dataType, pileTypeId);
        }

        public override DataTable QueryByPage(GatItem bean, int page, int rows)
        {
            throw new NotImplementedException();
        }

        public override DataTable QueryByPage(GatItem bean, int page, int rows, ref int count)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取采集项名称
        /// </summary>
        /// <param name="zhuanid"></param>
        /// <returns></returns>
        public DataTable FindByItemName(int zhuanid)
        {
            Log.Debug("FindByItemName:方法参数：");
            var sql = new StringBuilder();
            sql.Append("select gi.itemname,gi.itemno,gi.datatype ");
            sql.Append("from dev_chargpile dcp inner join gat_pointcfg gpc on dcp.piletypeid=gpc.piletypeid ");
            sql.Append("inner join gat_item gi on gi.itemno=gpc.gatitemid ");
            sql.Append("where dcp.dev_chargpile=" + zhuanid);
            return Oop.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 查询电流值和电压值
        /// </summary>
        /// <returns></returns>
        public DataTable FindByCurrentAndVoltage(string type, string itemno)
        {
            Log.Debug("FindByCurrent:方法参数：");
            var sql = new StringBuilder();
            sql.Append("select gi.itemname,gi.itemno ");
            sql.Append("from  gat_item gi ");
            //where (gi.itemname like '%电流%' )and gi.itemno='ChongD_JLDL_B';
            sql.Append("where ( gi.itemname like '%直流%' or gi.itemname like '%交流%') and gi.itemname like '%" + type + "%' "
                +"and gi.itemname not like '%最%' and gi.itemno='" + itemno + "'");
            return Oop.GetDataTable(sql.ToString());
        }
    }
}

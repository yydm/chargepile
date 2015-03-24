using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ChargingPile.Model;

namespace ChargingPile.DAL
{
    public class ChargePileStatesDal : BaseDal<ChargePileStates>
    {
        public override bool Exist(ChargePileStates bean)
        {
            throw new NotImplementedException();
        }

        public override void Add(ChargePileStates bean)
        {
            throw new NotImplementedException();
        }

        public override void Del(ChargePileStates bean)
        {
            throw new NotImplementedException();
        }

        public override void Modify(ChargePileStates bean)
        {
            throw new NotImplementedException();
        }

        public override DataTable Query(ChargePileStates bean)
        {
            Log.Debug("Query方法参数：" + bean.ToString());
            var sql = new StringBuilder();
            sql.Append("select * from oth_pilestates t ");
            sql.Append("where t.powerpileno='" + bean.PowerPileNo + "'");
            return Oop.GetDataTable(sql.ToString());
        }

        public override DataTable QueryByPage(ChargePileStates bean, int page, int rows)
        {
            throw new NotImplementedException();
        }

        public override DataTable QueryByPage(ChargePileStates bean, int page, int rows, ref int count)
        {
            throw new NotImplementedException();
        }
    }
}

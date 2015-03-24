using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChargingPile.Model;
using ChargingPile.DAL;
using System.Data;

namespace ChargingPile.BLL
{
    public class GatItemBll : BaseBll<GatItem>
    {
        readonly GatItemDal gatItemDal = new GatItemDal();
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
            return gatItemDal.Query(bean);
        }
        public DataTable QuerySjxNotUse(string dataType, string pileTypeId)
        {
            return gatItemDal.QuerySjxNotUse(dataType, pileTypeId);
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
            return gatItemDal.FindByItemName(zhuanid);
        }

        /// <summary>
        /// 查询电流值和电压值
        /// </summary>
        /// <returns></returns>
        public DataTable FindByCurrentAndVoltage(string type, string itemno)
        {
            return gatItemDal.FindByCurrentAndVoltage(type, itemno);
        }

    }
}

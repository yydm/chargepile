using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ChargingPile.Model;
using ChargingPile.DAL;

namespace ChargingPile.BLL
{
    public class ChargPriceBll:BaseBll<ChargPrice>
    {
        readonly ChargPriceDal _chargPriceDal = new ChargPriceDal();
        public override bool Exist(ChargPrice bean)
        {
           return _chargPriceDal.Exist(bean);
        }

        public override void Add(ChargPrice bean)
        {
            _chargPriceDal.Add(bean);
        }

        public override void Del(ChargPrice bean)
        {
            _chargPriceDal.Del(bean);
        }

        public override void Modify(ChargPrice bean)
        {
            _chargPriceDal.Modify(bean);
        }

        public override DataTable Query(ChargPrice bean)
        {
            return _chargPriceDal.Query(bean);
        }

        public override DataTable QueryByPage(ChargPrice bean, int page, int rows)
        {
            throw new NotImplementedException();
        }

        public override DataTable QueryByPage(ChargPrice bean, int page, int rows, ref int count)
        {
            return _chargPriceDal.QueryByPage(bean, page, rows, ref count);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ChargingPile.Model;
using ChargingPile.DAL;

namespace ChargingPile.BLL
{
    public class WarnBll:BaseBll<Warn>
    {
        readonly WarnDal _warnDal=new WarnDal();
        public override bool Exist(Warn bean)
        {
            return _warnDal.Exist(bean);
        }

        public override void Add(Warn bean)
        {
            _warnDal.Add(bean);
        }

        public override void Del(Warn bean)
        {
            _warnDal.Del(bean);
        }

        public override void Modify(Warn bean)
        {
            _warnDal.Modify(bean);
        }

        public override DataTable Query(Warn bean)
        {
            return _warnDal.Query(bean);
        }

        public override DataTable QueryByPage(Warn bean, int page, int rows)
        {
            throw new NotImplementedException();
        }

        public override DataTable QueryByPage(Warn bean, int page, int rows, ref int count)
        {
            return _warnDal.QueryByPage(bean, page, rows, ref count);
        }
    }
}

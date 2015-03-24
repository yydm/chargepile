using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ChargingPile.DAL;
using ChargingPile.Model;

namespace ChargingPile.BLL
{
    public class ResMenuBll:BaseBll<ResMenu>
    {
        private readonly ResMenuDal _resMenuDal = new ResMenuDal();
        public override bool Exist(ResMenu bean)
        {
            return _resMenuDal.Exist(bean);
        }

        public override void Add(ResMenu bean)
        {
            _resMenuDal.Add(bean);
        }

        public override void Del(ResMenu bean)
        {
            _resMenuDal.Del(bean);
        }

        public override void Modify(ResMenu bean)
        {
            _resMenuDal.Modify(bean);
        }

        public override DataTable Query(ResMenu bean)
        {
            return _resMenuDal.Query(bean);
        }

        public override DataTable QueryByPage(ResMenu bean, int page, int rows)
        {
            throw new NotImplementedException();
        }

        public override DataTable QueryByPage(ResMenu bean, int page, int rows, ref int count)
        {
            return _resMenuDal.QueryByPage(bean, page, rows, ref count);
        }

        public DataTable FindBy()
        {
            return _resMenuDal.FindBy();
        }
    }
}

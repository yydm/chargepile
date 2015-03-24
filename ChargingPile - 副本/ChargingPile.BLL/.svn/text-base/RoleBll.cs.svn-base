using System;
using System.Data;
using ChargingPile.Model;
using ChargingPile.DAL;

namespace ChargingPile.BLL
{
    public class RoleBll : BaseBll<Role>
    {
        readonly RoleDal _roleDal = new RoleDal();
        public override bool Exist(Role bean)
        {
            return _roleDal.Exist(bean);
        }

        public override void Add(Role bean)
        {
            _roleDal.Add(bean);
        }

        public override void Del(Role bean)
        {
            _roleDal.Del(bean);
        }

        public override void Modify(Role bean)
        {
            _roleDal.Modify(bean);
        }

        public override DataTable Query(Role bean)
        {
            return _roleDal.Query(bean);
        }

        public override DataTable QueryByPage(Role bean, int page, int rows)
        {
            throw new NotImplementedException();
        }

        public override DataTable QueryByPage(Role bean, int page, int rows, ref int count)
        {
            return _roleDal.QueryByPage(bean, page, rows, ref count);
        }
    }
}

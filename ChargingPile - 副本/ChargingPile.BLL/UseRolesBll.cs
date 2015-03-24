using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ChargingPile.Model;
using ChargingPile.DAL;

namespace ChargingPile.BLL
{
    public class UseRolesBll : BaseBll<UseRoles>
    {
        readonly UseRolesDal _useRolesDal = new UseRolesDal();
        public override bool Exist(UseRoles bean)
        {
            return _useRolesDal.Exist(bean);
        }

        public override void Add(UseRoles bean)
        {
            _useRolesDal.Add(bean);
        }

        public override void Del(UseRoles bean)
        {
            _useRolesDal.Del(bean);
        }

        public void Del2(UseRoles bean)
        {
            _useRolesDal.Del2(bean);
        }

        public override void Modify(UseRoles bean)
        {
            _useRolesDal.Modify(bean);
        }

        public override DataTable Query(UseRoles bean)
        {
            return _useRolesDal.Query(bean);
        }

        public override DataTable QueryByPage(UseRoles bean, int page, int rows)
        {
            throw new NotImplementedException();
        }

        public override DataTable QueryByPage(UseRoles bean, int page, int rows, ref int count)
        {
            return _useRolesDal.QueryByPage(bean, page, rows, ref count);
        }

        public DataTable FindBy(string empid)
        {
            return _useRolesDal.FindBy(empid);
        }
    }
}

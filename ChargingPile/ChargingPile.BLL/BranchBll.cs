using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ChargingPile.Model;
using ChargingPile.DAL;

namespace ChargingPile.BLL
{
    public class BranchBll : BaseBll<Branch>
    {
        readonly BranchDal _branchDal = new BranchDal();
        public override bool Exist(Branch bean)
        {
            return _branchDal.Exist(bean);
        }

        public override void Add(Branch bean)
        {
            _branchDal.Add(bean);
        }

        public override void Del(Branch bean)
        {
            _branchDal.Del(bean);
        }

        public override void Modify(Branch bean)
        {
            _branchDal.Modify(bean);
        }

        public override DataTable Query(Branch bean)
        {
           return  _branchDal.Query(bean);
        }

        public override DataTable QueryByPage(Branch bean, int page, int rows)
        {
            throw new NotImplementedException();
        }

        public override DataTable QueryByPage(Branch bean, int page, int rows, ref int count)
        {
           return _branchDal.QueryByPage(bean, page, rows, ref count);
        }
    }
}

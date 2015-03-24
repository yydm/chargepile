using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ChargingPile.Model;
using ChargingPile.DAL;

namespace ChargingPile.BLL
{
    public class JobsDetailsBll : BaseBll<JobsDetails>
    {
        readonly JobsDetailsDal _jobsDetailsDal = new JobsDetailsDal();
        public override bool Exist(JobsDetails bean)
        {
            return _jobsDetailsDal.Exist(bean);
        }

        public override void Add(JobsDetails bean)
        {
            _jobsDetailsDal.Add(bean);
        }

        public override void Del(JobsDetails bean)
        {
            _jobsDetailsDal.Del(bean);
        }

        public override void Modify(JobsDetails bean)
        {
            _jobsDetailsDal.Modify(bean);
        }

        public override DataTable Query(JobsDetails bean)
        {
            return _jobsDetailsDal.Query(bean);
        }

        public override DataTable QueryByPage(JobsDetails bean, int page, int rows)
        {
            throw new NotImplementedException();
        }

        public override DataTable QueryByPage(JobsDetails bean, int page, int rows, ref int count)
        {
            return _jobsDetailsDal.QueryByPage(bean, page, rows, ref count);
        }
    }
}

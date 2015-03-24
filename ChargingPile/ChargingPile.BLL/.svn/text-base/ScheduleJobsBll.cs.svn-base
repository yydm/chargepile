using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ChargingPile.Model;
using ChargingPile.DAL;

namespace ChargingPile.BLL
{
    public class ScheduleJobsBll : BaseBll<ScheduleJobs>
    {
        readonly ScheduleJobsDal _scheduleJobsDal = new ScheduleJobsDal();
        public override bool Exist(ScheduleJobs bean)
        {
            return _scheduleJobsDal.Exist(bean);
        }

        public override void Add(ScheduleJobs bean)
        {
            _scheduleJobsDal.Add(bean);
        }

        public override void Del(ScheduleJobs bean)
        {
            _scheduleJobsDal.Del(bean);
        }

        public override void Modify(ScheduleJobs bean)
        {
            _scheduleJobsDal.Modify(bean);
        }

        public override DataTable Query(ScheduleJobs bean)
        {
            return _scheduleJobsDal.Query(bean);
        }

        public override DataTable QueryByPage(ScheduleJobs bean, int page, int rows)
        {
            throw new NotImplementedException();
        }

        public override DataTable QueryByPage(ScheduleJobs bean, int page, int rows, ref int count)
        {
            return _scheduleJobsDal.QueryByPage(bean, page, rows, ref count);
        }

        public DataTable FindBy(int page, int rows, ref int count, string cmdtype)
        {
            return _scheduleJobsDal.FindBy(page, rows, ref count, cmdtype);
        }

        public DataTable FindBy(int csid)
        {
            return _scheduleJobsDal.FindBy(csid);
        }

        public DataTable FindByDetail(string taskid)
        {
            return _scheduleJobsDal.FindByDetail(taskid);
        }

        public int FindBySumCount(string taskid)
        {
            var dt = _scheduleJobsDal.FindBySumCount(taskid);
            return int.Parse(dt.Rows[0]["count"].ToString());
        }

        public int FindBySuccessCount(string taskid)
        {
            var dt = _scheduleJobsDal.FindBySuccessCount(taskid);
            return int.Parse(dt.Rows[0]["count"].ToString());
        }
    }
}

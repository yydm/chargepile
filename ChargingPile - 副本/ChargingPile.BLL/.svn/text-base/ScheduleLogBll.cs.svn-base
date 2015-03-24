using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ChargingPile.DAL;
using ChargingPile.Model;

namespace ChargingPile.BLL
{
    public class ScheduleLogBll:BaseBll<ScheduleLog>
    {
        private readonly ScheduleLogDal _scheduleLogDal = new ScheduleLogDal();
        public override bool Exist(ScheduleLog bean)
        {
            return _scheduleLogDal.Exist(bean);
        }

        public override void Add(ScheduleLog bean)
        {
            _scheduleLogDal.Add(bean);
        }

        public override void Del(ScheduleLog bean)
        {
            _scheduleLogDal.Del(bean);
        }

        public override void Modify(ScheduleLog bean)
        {
            _scheduleLogDal.Modify(bean);
        }

        public override DataTable Query(ScheduleLog bean)
        {
            return _scheduleLogDal.Query(bean);
        }

        public override DataTable QueryByPage(ScheduleLog bean, int page, int rows)
        {
            throw new NotImplementedException();
        }

        public override DataTable QueryByPage(ScheduleLog bean, int page, int rows, ref int count)
        {
            return _scheduleLogDal.QueryByPage(bean, page, rows, ref count);
        }
    }
}

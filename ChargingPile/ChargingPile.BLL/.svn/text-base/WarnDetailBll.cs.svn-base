using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ChargingPile.Model;
using ChargingPile.DAL;

namespace ChargingPile.BLL
{
    public class WarnDetailBll:BaseBll<WarnDetail>
    {
        readonly WarnDetailDal _warnDetailDal=new WarnDetailDal();
        public override bool Exist(WarnDetail bean)
        {
            return _warnDetailDal.Exist(bean);
        }

        public override void Add(WarnDetail bean)
        {
            _warnDetailDal.Add(bean);
        }

        public override void Del(WarnDetail bean)
        {
            _warnDetailDal.Del(bean);
        }

        public override void Modify(WarnDetail bean)
        {
            _warnDetailDal.Modify(bean);
        }

        public void ModifyByGatherId(WarnDetail bean)
        {
            _warnDetailDal.ModifyByGatherId(bean);
        }
        public override DataTable Query(WarnDetail bean)
        {
            return _warnDetailDal.Query(bean);
        }

        public override DataTable QueryByPage(WarnDetail bean, int page, int rows)
        {
            throw new NotImplementedException();
        }

        public override DataTable QueryByPage(WarnDetail bean, int page, int rows, ref int count)
        {
            return _warnDetailDal.QueryByPage(bean, page, rows, ref count);
        }


        public DataTable FindByEmail()
        {
            return _warnDetailDal.FindByEmail();
        }

        public DataTable FindBySms()
        {
            return _warnDetailDal.FindBySms();
        }

        /// <summary>
        /// 查找站简称
        /// </summary>
        /// <param name="warnid"></param>
        /// <returns></returns>
        public DataTable FindZhanJc(string warnid)
        {
            return _warnDetailDal.FindZhanJc(warnid);
        }

        /// <summary>
        /// 查找桩编号
        /// </summary>
        /// <param name="warnid">告警id</param>
        /// <returns></returns>
        public DataTable FindZhuanBh(string warnid)
        {
            return _warnDetailDal.FindZhuanBh(warnid);
        }

        /// <summary>
        /// 查找数据项
        /// </summary>
        /// <param name="warnid">告警id</param>
        /// <returns></returns>
        public DataTable FindItemName(string warnid)
        {
            return _warnDetailDal.FindItemName(warnid);
        }

        /// <summary>
        /// 查找告警原因
        /// </summary>
        /// <param name="warnid">告警id</param>
        /// <returns></returns>
        public DataTable FindWarn(string warnid)
        {
            return _warnDetailDal.FindWarn(warnid);
        }
    }
}

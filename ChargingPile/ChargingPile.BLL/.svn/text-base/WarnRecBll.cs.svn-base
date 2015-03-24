using System;
using System.Data;
using ChargingPile.DAL;
using ChargingPile.Model;
using ChargingPile.Model.ChargePile;

namespace ChargingPile.BLL
{
    public class WarnRecBll : BaseBll<WarnRec>
    {
        readonly WarnRecDal _warnRecDal = new WarnRecDal();
        public override bool Exist(WarnRec bean)
        {
            throw new NotImplementedException();
        }

        public override void Add(WarnRec bean)
        {
            throw new NotImplementedException();
        }

        public override void Del(WarnRec bean)
        {
            throw new NotImplementedException();
        }

        public override void Modify(WarnRec bean)
        {
            _warnRecDal.Modify(bean);
        }

        public override DataTable Query(WarnRec bean)
        {
            return _warnRecDal.Query(bean);
        }
        public DataTable QueryByType(string type, int page, int rows, ref int count)
        {
            return _warnRecDal.QueryByType(type, page, rows, ref count);
        }

        public override DataTable QueryByPage(WarnRec bean, int page, int rows)
        {
            throw new NotImplementedException();
        }

        public override DataTable QueryByPage(WarnRec bean, int page, int rows, ref int count)
        {
            throw new NotImplementedException();
        }

        public DataTable Query(string yclx, DateTime dateBegin, DateTime dateEnd)
        {
            return _warnRecDal.Query(yclx, dateBegin, dateEnd);
        }

        public DataTable QueryByPage(string yclx, DateTime dateBegin, DateTime dateEnd, int page, int rows,
                                     ref int count)
        {
            return _warnRecDal.QueryByPage(yclx, dateBegin, dateEnd, page, rows, ref count);
        }

        /// <summary>
        /// 查询格式化告警信息
        /// </summary>
        /// <returns></returns>
        public DataTable FindBy(string zhanid)
        {
            return _warnRecDal.FindBy(zhanid);
        }

        /// <summary>
        /// 根据充电桩id查询格式化告警信息
        /// </summary>
        /// <returns></returns>
        public DataTable FindBy(int zhuanid)
        {
            return _warnRecDal.FindBy(zhuanid);
        }

        /// <summary>
        /// 修改告警信息
        /// </summary>
        /// <param name="bean"></param>
        public void EditBy(WarnRec bean)
        {
            _warnRecDal.EditBy(bean);
        }

        /// <summary>
        /// 查询异常告警
        /// </summary>
        /// <returns></returns>
        public DataTable FindByTelesignallingWarn(string zhanbh)
        {
            return _warnRecDal.FindByTelesignallingWarn(zhanbh);
        }

        /// <summary>
        /// 查询异常告警
        /// </summary>
        /// <returns></returns>
        public DataTable FindByTelesignallingWarn()
        {
            return _warnRecDal.FindByTelesignallingWarn();
        }

        /// <summary>
        /// 查询异常告警
        /// </summary>
        /// <param name="warnid">告警id</param>
        /// <returns></returns>
        public DataTable FindByTelesignallingWarn2(string warnid)
        {
            return _warnRecDal.FindByTelesignallingWarn2(warnid);
        }

        /// <summary>
        /// 查询异常告警未处理个数
        /// </summary>
        /// <returns></returns>
        public int FindByTelesignallingWarnCount()
        {
            var dt = _warnRecDal.FindByTelesignallingWarnCount();
            return int.Parse(dt.Rows[0]["count"].ToString());
        }

        /// <summary>
        /// 查询充电卡异常使用告警
        /// </summary>
        /// <returns></returns>
        public DataTable FindByCardWarn(string zhanbh)
        {
            return _warnRecDal.FindByCardWarn(zhanbh);
        }

        /// <summary>
        /// 查询充电卡异常使用告警
        /// </summary>
        /// <returns></returns>
        public DataTable FindByCardWarn()
        {
            return _warnRecDal.FindByCardWarn();
        }

        /// <summary>
        /// 查询充电卡异常使用告警个数
        /// </summary>
        /// <returns></returns>
        public int FindByCardWarnCount()
        {
            var dt = _warnRecDal.FindByCardWarnCount();
            return int.Parse(dt.Rows[0]["count"].ToString());
        }

        /// <summary>
        /// 查询通信告警
        /// </summary>
        /// <returns></returns>
        public DataTable FindByCommunicationWarn(string zhanbh)
        {
            return _warnRecDal.FindByCommunicationWarn(zhanbh);
        }

        /// <summary>
        /// 查询通信告警
        /// </summary>
        /// <returns></returns>
        public DataTable FindByCommunicationWarn2(string zhanbh)
        {
            return _warnRecDal.FindByCommunicationWarn2(zhanbh);
        }

        /// <summary>
        /// 查询通信告警个数
        /// </summary>
        /// <returns></returns>
        public int FindByCommunicationWarnCount()
        {
            var dt = _warnRecDal.FindByCommunicationWarnCount();
            return int.Parse(dt.Rows[0]["count"].ToString());
        }

        /// <summary>
        /// 查询停电告警
        /// </summary>
        /// <returns></returns>
        public DataTable FindByPowerFailure(string zhanbh)
        {
            return _warnRecDal.FindByPowerFailure(zhanbh);
        }

        /// <summary>
        /// 查询停电告警3
        /// </summary>
        /// <returns></returns>
        public DataTable FindByPowerFailure3(string zhanbh)
        {
            return _warnRecDal.FindByPowerFailure3(zhanbh);
        }

        /// <summary>
        /// 查询停电告警个数
        /// </summary>
        /// <returns></returns>
        public int FindByPowerFailureCount()
        {
            var dt = _warnRecDal.FindByPowerFailureCount();
            return int.Parse(dt.Rows[0]["count"].ToString());
        }

        /// <summary>
        ///  查询异常告警
        /// </summary>
        /// <returns></returns>
        public DataTable FindByTelesignallingWarn(TelesignallingParam telesignallingParam, int page, int rows, ref int count)
        {
            return _warnRecDal.FindByTelesignallingWarn(telesignallingParam, page, rows, ref count);
        }

        /// <summary>
        /// 查询告警类型
        /// </summary>
        /// <returns></returns>
        public DataTable FindByWarnType()
        {
            return _warnRecDal.FindByWarnType();
        }

        /// <summary>
        /// 查询场站名称
        /// </summary>
        /// <returns></returns>
        public DataTable FindByZhanMc()
        {
            return _warnRecDal.FindByZhanMc();
        }

        /// <summary>
        /// 查询桩运行编号
        /// </summary>
        /// <param name="zhanBh">充电场站编号</param>
        /// <returns></returns>
        public DataTable FindByYunXinBh(string zhanBh)
        {
            return _warnRecDal.FindByYunXinBh(zhanBh);
        }

        /// <summary>
        /// 查询告警信息(根据数据采集id)
        /// </summary>
        /// <returns></returns>
        public DataTable FindByWarnRec(string datagatherid)
        {
            return _warnRecDal.FindByWarnRec(datagatherid);
        }
    }
}

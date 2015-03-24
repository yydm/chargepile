using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ChargingPile.Model;
using ChargingPile.DAL;

namespace ChargingPile.BLL
{
    public class ChargRecordBll : BaseBll<ChargRecordDal>
    {
        ChargRecordDal _chargRecordDal = new ChargRecordDal();
        /// <summary>
        /// 获取充电记录list
        /// </summary>
        /// <param name="zhuangbh"></param>
        /// <param name="begintime"></param>
        /// <param name="endtime"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public List<ChargRecord> GetCDJLList(string zhanbh, string zhuangbh, DateTime begintime, DateTime endtime, int page, int rows, ref int total)
        {
            return _chargRecordDal.GetCDJLList(zhanbh, zhuangbh, begintime, endtime, page, rows, ref total);
        }
        /// <summary>
        /// 获取充电统计list
        /// </summary>
        /// <param name="zhuangbh"></param>
        /// <param name="begintime"></param>
        /// <param name="endtime"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public List<ChargRecord> GetCDTJList(string zhanbh, string zhuangbh, DateTime begintime, DateTime endtime, int page, int rows, ref int total)
        {
            return _chargRecordDal.GetCDTJList(zhanbh, zhuangbh, begintime, endtime, page, rows, ref total);
        }
        /// <summary>
        /// 获取桩使用排名
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public List<ChargRecord> GetSYPMList(string zhanbh, int page, int rows, ref int total)
        {
            return _chargRecordDal.GetSYPMList(zhanbh, page, rows, ref total);
        }

        public override bool Exist(ChargRecordDal bean)
        {
            throw new NotImplementedException();
        }

        public override void Add(ChargRecordDal bean)
        {
            throw new NotImplementedException();
        }

        public override void Del(ChargRecordDal bean)
        {
            throw new NotImplementedException();
        }

        public override void Modify(ChargRecordDal bean)
        {
            throw new NotImplementedException();
        }

        public override DataTable Query(ChargRecordDal bean)
        {
            throw new NotImplementedException();
        }

        public override DataTable QueryByPage(ChargRecordDal bean, int page, int rows)
        {
            throw new NotImplementedException();
        }

        public override DataTable QueryByPage(ChargRecordDal bean, int page, int rows, ref int count)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据充电桩id获取交易信息(充电中)
        /// </summary>
        /// <param name="zhuanid"></param>
        /// <returns></returns>
        public DataTable FindByChargingPileBusinessInfo(int zhuanid)
        {
            return _chargRecordDal.FindByChargingPileBusinessInfo(zhuanid);
        }

        /// <summary>
        /// 根据充电桩id获取最近一次交易信息(待充电、已充满)
        /// </summary>
        /// <param name="zhuanid"></param>
        /// <returns></returns>
        public DataTable FindByChargePileRecentlyBusinessInfo(int zhuanid)
        {
            return _chargRecordDal.FindByChargePileRecentlyBusinessInfo(zhuanid);
        }

        /// <summary>
        /// 根据充电桩id获取交易信息(故障)
        /// </summary>
        /// <param name="zhuanid"></param>
        /// <returns></returns>
        public DataTable FindByProblemChargePileBusinessInfo(int zhuanid)
        {
            return _chargRecordDal.FindByProblemChargePileBusinessInfo(zhuanid);
        }

        /// <summary>
        /// 根据充电开始时间最大值，查询实时信息
        /// </summary>
        /// <param name="zhuanid"></param>
        /// <returns></returns>
        public DataTable FindByBusinessInfo(int zhuanid)
        {
            return _chargRecordDal.FindByBusinessInfo(zhuanid);
        }

        /// <summary>
        /// 查询充电桩充电信息
        /// </summary>
        /// <returns></returns>
        public DataTable FindByChargingPileInfo()
        {
            var dt = _chargRecordDal.FindByChargingPileInfo();
            if (dt.Rows.Count <= 0)
            {
                return null;
            }
            dt.Columns.Add("Note", Type.GetType("System.String"));
            dt.Columns.Add("DateTime", Type.GetType("System.String"));
            foreach (DataRow dr in dt.Rows)
            {
                var kssj = dr["startdt"].ToString();
                var jssj = dr["enddt"].ToString();
                if (!string.IsNullOrEmpty(kssj) && string.IsNullOrEmpty(jssj))
                {
                    dr["Note"] = "开始充电";
                    dr["DateTime"] = kssj;
                    continue;
                }
                if (!string.IsNullOrEmpty(kssj) && !string.IsNullOrEmpty(jssj))
                {
                    dr["Note"] = "充电结束";
                    dr["DateTime"] = jssj;
                    continue;
                }
                dr["Note"] = "";
                dr["DateTime"] = "";
            }
            return dt;
        }

        /// <summary>
        /// 根据给点的条件查询桩状态
        /// </summary>
        /// <param name="cdcz">场站编号</param>
        /// <param name="zbh">桩编号</param>
        /// <param name="dateBegin">起始日期</param>
        /// <param name="dateEnd">结束日期</param>
        /// <param name="count">查询结果行数</param>
        /// <returns></returns>
        public DataTable FindByCondition(string cdcz, string zbh, DateTime dateBegin, DateTime dateEnd, int page, int rows, ref int count)
        {
            var dt = _chargRecordDal.FindByChargingPileInfo(cdcz, zbh, dateBegin, dateEnd, page, rows, ref count);
            if (dt.Rows.Count <= 0)
            {
                return null;
            }
            dt.Columns.Add("Note", typeof(string));
            dt.Columns.Add("DateTime", typeof(string));
            dt.Columns.Add("chargeTime", typeof(string));
            foreach (DataRow dr in dt.Rows)
            {
                var kssj = dr["startdt"].ToString();
                var jssj = dr["enddt"].ToString();
                if (!string.IsNullOrEmpty(kssj) && string.IsNullOrEmpty(jssj))
                {
                    dr["Note"] = "开始充电";
                    dr["DateTime"] = kssj;
                    dr["chargeTime"] = "";
                    continue;
                }
                if (!string.IsNullOrEmpty(kssj) && !string.IsNullOrEmpty(jssj))
                {
                    dr["Note"] = "充电结束";
                    dr["DateTime"] = jssj;
                    TimeSpan ts = DateTime.Parse(jssj) - DateTime.Parse(kssj);
                    dr["chargeTime"] = ts.Days * 24 + ts.Hours + "小时" + ts.Minutes + "分钟";
                    continue;
                }
                dr["Note"] = "";
                dr["DateTime"] = "";
                dr["chargeTime"] = "";
            }
            return dt;
        }

        /// <summary>
        /// 查询充电桩充电中总数量
        /// </summary>
        /// <returns></returns>
        public int? FindByChargingPileCount()
        {
            var dt = _chargRecordDal.FindByChargingPileCount();
            if (dt.Rows.Count > 0)
            {
                return int.Parse(dt.Rows[0]["count"].ToString());
            }
            return null;
        }

        /// <summary>
        /// 查询本月充电总电量
        /// </summary>
        /// <returns></returns>
        public decimal? FindByChargingPileZdl(int year, int month)
        {
            var dt = _chargRecordDal.FindByChargingPileZdl(year, month);
            if (dt.Rows.Count > 0)
            {
                return decimal.Parse(dt.Rows[0]["zdl"].ToString());
            }
            return null;
        }

        /// <summary>
        /// 查询本月充电总金额
        /// </summary>
        /// <returns></returns>
        public string FindByChargingPileZje(int year, int month)
        {
            var dt = _chargRecordDal.FindByChargingPileZje(year, month);
            if (dt.Rows.Count > 0)
            {
                return (decimal.Parse(dt.Rows[0]["zje"].ToString())).ToString("f2");
            }
            return null;
        }

        /// <summary>
        /// 查询本月充电总时长
        /// </summary>
        /// <returns></returns>
        public string FindByChargingPileZsc(int year, int month)
        {
            var dt = _chargRecordDal.FindByChargingPileZsc(year, month);
            if (dt.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dt.Rows[0]["s"].ToString()))
                {
                    var ts = new TimeSpan(0, 0, Int32.Parse(dt.Rows[0]["s"].ToString()));
                    return ts.Days * 24 + ts.Hours + "小时" + ts.Minutes + "分钟" + ts.Seconds + "秒";
                }
                return null;
            }
            return null;
        }

        /// <summary>
        /// 查询本月充电总金额
        /// </summary>
        /// <returns></returns>
        public DataTable FindByRankZje(int year, int month)
        {
            var dt = _chargRecordDal.FindByRankZje(year, month);
            return dt;
        }

        /// <summary>
        /// 查询本月排行充电总金额
        /// </summary>
        /// <returns></returns>
        public DataTable FindByRankZje(string kssj, string jssj, int page, int rows, ref  int count)
        {
            return _chargRecordDal.FindByRankZje(kssj, jssj, page, rows, ref count);
        }

        /// <summary>
        /// 查询本月卡消费总额
        /// </summary>
        /// <returns></returns>
        public DataTable FindByRankCardZje(int year, int month)
        {
            var dt = _chargRecordDal.FindByRankCardZje(year, month);
            if (dt.Rows.Count > 0)
            {
                dt.Columns.Add("je");
                foreach (DataRow dataRow in dt.Rows)
                {
                    if (!string.IsNullOrEmpty(dataRow["zje"].ToString()))
                    {

                        dataRow["je"] = (decimal.Parse(dataRow["zje"].ToString())).ToString("f2");
                    }
                    else
                    {
                        dataRow["je"] = "0.00";
                    }
                }
                return dt;
            }
            return null;
        }

        /// <summary>
        /// 查询本月排行卡消费总额
        /// </summary>
        /// <returns></returns>
        public DataTable FindByRankCardZje(string kssj, string jssj, int page, int rows, ref  int count)
        {
            return _chargRecordDal.FindByRankCardZje(kssj, jssj, page, rows, ref count);
        }

        /// <summary>
        /// 查询本月充电量
        /// </summary>
        /// <returns></returns>
        public DataTable FindByRankZdl(int year, int month)
        {
            return _chargRecordDal.FindByRankZdl(year, month);
        }

        /// <summary>
        /// 查询本月排行充电量
        /// </summary>
        /// <returns></returns>
        public DataTable FindByRankZdl(string kssj, string jssj, int page, int rows, ref  int count)
        {
            return _chargRecordDal.FindByRankZdl(kssj, jssj, page, rows, ref count);
        }

        /// <summary>
        /// 查询本月运行故障率
        /// </summary>
        /// <returns></returns>
        public DataTable FindByRankRunCount(int year, int month)
        {
            return _chargRecordDal.FindByRankRunCount(year, month);
        }

        /// <summary>
        /// 查询本月运维次数
        /// </summary>
        /// <returns></returns>
        public DataTable FindByRankRunCount(string kssj, string jssj, int page, int rows2, ref  int count)
        {
            return _chargRecordDal.FindByRankRunCount(kssj, jssj, page, rows2, ref count);
        }

        /// <summary>
        /// 查询本月平均充电量
        /// </summary>
        /// <returns></returns>
        public DataTable FindByRankAvgZdl(int year, int month)
        {
            var chargpilebll = new ChargPileBll();
            var datatable = new DataTable();
            var dtCdl = FindByRankZdl(year, month);
            var dtCount = chargpilebll.FindByChargePileStationCount();
            datatable.Columns.Add("rownum", Type.GetType("System.Decimal"));
            datatable.Columns.Add("zhanjc", Type.GetType("System.String"));
            datatable.Columns.Add("pjcdl", Type.GetType("System.String"));
            foreach (DataRow rows in dtCdl.Rows)
            {
                foreach (DataRow row in dtCount.Rows)
                {
                    if (rows["zhanjc"].ToString() != row["zhanjc"].ToString()) continue;
                    var cdl = rows["zdl"].ToString();
                    var zdl = 0m;
                    zdl = !string.IsNullOrEmpty(cdl) ? decimal.Parse(cdl) : 0;

                    var zsl = int.Parse(row["count"].ToString());
                    try
                    {
                        var datarow = datatable.NewRow();
                        if (zsl == 0) continue;
                        var avgZdl = zdl / zsl;
                        datarow["rownum"] = rows["rownum"];
                        datarow["zhanjc"] = row["zhanjc"];
                        datarow["pjcdl"] = avgZdl.ToString("f2");
                        datatable.Rows.Add(datarow);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            return datatable;
        }

        /// <summary>
        /// 查询本月平均充电量
        /// </summary>
        /// <returns></returns>
        public DataTable FindByRankAvgZdl(string kssj, string jssj, int page, int rows2, ref  int count)
        {
            var chargpilebll = new ChargPileBll();
            var datatable = new DataTable();
            var dtCdl = FindByRankZdl(kssj, jssj, page, rows2, ref count);
            var dtCount = chargpilebll.FindByChargePileStationCount();
            datatable.Columns.Add("rownum", Type.GetType("System.Decimal"));
            datatable.Columns.Add("zhanjc", Type.GetType("System.String"));
            datatable.Columns.Add("pjcdl", Type.GetType("System.String"));
            foreach (DataRow rows in dtCdl.Rows)
            {
                foreach (DataRow row in dtCount.Rows)
                {
                    if (rows["zhanjc"].ToString() != row["zhanjc"].ToString()) continue;
                    var cdl = rows["zdl"].ToString();
                    var zdl = 0m;
                    zdl = !string.IsNullOrEmpty(cdl) ? decimal.Parse(cdl) : 0;

                    var zsl = int.Parse(row["count"].ToString());
                    try
                    {
                        var datarow = datatable.NewRow();
                        if (zsl == 0) continue;
                        var avgZdl = zdl / zsl;
                        datarow["rownum"] = rows["rownum"];
                        datarow["zhanjc"] = row["zhanjc"];
                        datarow["pjcdl"] = avgZdl.ToString("f2");
                        datatable.Rows.Add(datarow);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            return datatable;
        }

        /// <summary>
        /// 查询本月运行故障率
        /// </summary>
        /// <returns></returns>
        public DataTable FindByRankFailureRate(int year, int month)
        {
            var chargpilebll = new ChargPileBll();
            var datatable = new DataTable();
            var dtCdl = FindByRankRunCount(year, month);
            var dtCount = chargpilebll.FindByChargePileStationCount();
            datatable.Columns.Add("rownum", Type.GetType("System.Decimal"));
            datatable.Columns.Add("zhanjc", Type.GetType("System.String"));
            datatable.Columns.Add("gzl", Type.GetType("System.String"));
            foreach (DataRow rows in dtCdl.Rows)
            {
                foreach (DataRow row in dtCount.Rows)
                {
                    if (rows["zhanjc"].ToString() != row["zhanjc"].ToString()) continue;

                    var yxcl = decimal.Parse(rows["count"].ToString());
                    var zsl = int.Parse(row["count"].ToString());
                    try
                    {
                        var datarow = datatable.NewRow();
                        if (zsl == 0) continue;
                        var gzl = yxcl / zsl;
                        gzl = gzl * 100;
                        datarow["rownum"] = rows["rownum"];
                        datarow["zhanjc"] = row["zhanjc"];
                        datarow["gzl"] = gzl.ToString("f2");
                        datatable.Rows.Add(datarow);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            return datatable;
        }

        /// <summary>
        /// 查询本月运行故障率
        /// </summary>
        /// <returns></returns>
        public DataTable FindByRankFailureRate(string kssj, string jssj, int page, int rows2, ref  int count)
        {
            var chargpilebll = new ChargPileBll();
            var datatable = new DataTable();
            var dtCdl = FindByRankRunCount(kssj, jssj, page, rows2, ref count);
            var dtCount = chargpilebll.FindByChargePileStationCount();
            datatable.Columns.Add("rownum", Type.GetType("System.Decimal"));
            datatable.Columns.Add("zhanjc", Type.GetType("System.String"));
            datatable.Columns.Add("gzl", Type.GetType("System.String"));
            foreach (DataRow rows in dtCdl.Rows)
            {
                foreach (DataRow row in dtCount.Rows)
                {
                    if (rows["zhanjc"].ToString() != row["zhanjc"].ToString()) continue;

                    var yxcl = decimal.Parse(rows["count"].ToString());
                    var zsl = int.Parse(row["count"].ToString());
                    try
                    {
                        var datarow = datatable.NewRow();
                        if (zsl == 0) continue;
                        var gzl = yxcl / zsl;
                        gzl = gzl * 100;
                        datarow["rownum"] = rows["rownum"];
                        datarow["zhanjc"] = row["zhanjc"];
                        datarow["gzl"] = gzl.ToString("f2");
                        datatable.Rows.Add(datarow);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            return datatable;
        }
    }
}

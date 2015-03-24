using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChargingPile.Model;
using System.Data;

namespace ChargingPile.DAL
{
    public class ChargRecordDal : BaseDal<ChargRecord>
    {

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
            List<ChargRecord> cdjllist = new List<ChargRecord>();
            DataTable dt1 = QueryCDJLBYTJ(zhanbh, zhuangbh, begintime, endtime, page, rows);
            DataTable dt2 = QueryCDJLTotalBYTJ(zhanbh, zhuangbh, begintime, endtime);
            total = dt2.Rows.Count;
            if (dt1.Rows.Count > 0)
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    ChargRecord bean = new ChargRecord();
                    DataRow dr = dt1.Rows[i];
                    bean.YUNXING_BH = dr["YUNXING_BH"].ToString();
                    bean.ZHAN_JC = dr["ZHAN_JC"].ToString();
                    if (dr["CHARGE_POWER"].ToString() == "")
                        bean.CHARGE_POWER = 0;
                    else
                        bean.CHARGE_POWER = decimal.Parse(dr["CHARGE_POWER"].ToString());
                    if (dr["CHARGE_MONEY"].ToString() == "")
                        bean.CHARGE_MONEY = 0;
                    else
                        bean.CHARGE_MONEY = decimal.Parse(dr["CHARGE_MONEY"].ToString()) / 100;
                    bean.CARD_NO = dr["CARD_NO"].ToString();
                    if (dr["STARTDT"].ToString() == "" || dr["STARTDT"] == null)
                        bean.STARTDT = new DateTime();
                    else
                        bean.STARTDT = DateTime.Parse(dr["STARTDT"].ToString());
                    if (dr["ENDDT"].ToString() == "" || dr["ENDDT"] == null)
                        bean.ENDDT = new DateTime();
                    else
                        bean.ENDDT = DateTime.Parse(dr["ENDDT"].ToString());
                    cdjllist.Add(bean);
                }
            }
            return cdjllist;
        }
        /// <summary>
        /// 分页条件查询充电记录
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="zhuangbh"></param>
        /// <returns></returns>
        public DataTable QueryCDJLBYTJ(string zhanbh, string zhuangbh, DateTime begintime, DateTime endtime, int page, int rows)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select B.* from (select A.*,rownum rn from (select a.STARTDT,a.ENDDT,a.CHARGE_POWER,a.CHARGE_MONEY,a.CARD_NO,b.YUNXING_BH,d.zhan_jc ");
            strSql.Append(" from gat_data_record a,dev_chargpile b,dev_branch c,dev_chargstation d where a.ZHUAN_ID=b.DEV_CHARGPILE and c.branchno=b.box_id ");
            strSql.Append(" and c.zhuan_bh=d.zhan_bh ");
            var i = -1;
            List<object> list = new List<object>();
            if (!string.IsNullOrEmpty(zhuangbh))
            {
                strSql.Append(" and b.YUNXING_BH={" + ++i + "} ");
                list.Add(zhuangbh);
            }
            if (!string.IsNullOrEmpty(zhanbh))
            {
                strSql.Append(" and d.zhan_bh={" + ++i + "} ");
                list.Add(zhanbh);
            }
            if (begintime != new DateTime() && endtime != new DateTime())
            {
                strSql.Append(" and a.STARTDT >={" + ++i + "} and a.ENDDT <={" + ++i + "} ");
                list.AddRange(new object[] { begintime, endtime });
            }
            strSql.Append(" order by a.STARTDT desc ");
            strSql.Append(" ) A where rownum<='" + page + "'*'" + rows + "') B where rn>('" + page + "'-1)*'" + rows + "' ");

            DataTable dt = new DataTable();
            try
            {
                dt = Oop.GetDataTable(strSql.ToString(), list.ToArray());
            }
            catch (Exception e)
            {
                Log.Error("查询充电记录失败！", e);
            }
            return dt;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="zhuangbh"></param>
        /// <param name="begintime"></param>
        /// <param name="endtime"></param>
        /// <returns></returns>
        public DataTable QueryCDJLTotalBYTJ(string zhanbh, string zhuangbh, DateTime begintime, DateTime endtime)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select a.STARTDT,a.ENDDT,a.CHARGE_POWER,a.CHARGE_MONEY,a.CARD_NO,b.YUNXING_BH ");
            strSql.Append(" from gat_data_record a,dev_chargpile b,dev_branch c,dev_chargstation d where a.ZHUAN_ID=b.DEV_CHARGPILE and c.branchno=b.box_id ");
            strSql.Append(" and c.zhuan_bh=d.zhan_bh ");
            var i = -1;
            List<object> list = new List<object>();
            if (!string.IsNullOrEmpty(zhuangbh))
            {
                strSql.Append(" and b.YUNXING_BH={" + ++i + "} ");
                list.Add(zhuangbh);
            }
            if (!string.IsNullOrEmpty(zhanbh))
            {
                strSql.Append(" and d.zhan_bh={" + ++i + "} ");
                list.Add(zhanbh);
            }
            if (begintime != new DateTime() && endtime != new DateTime())
            {
                strSql.Append(" and a.STARTDT >={" + ++i + "} and a.ENDDT <={" + ++i + "} ");
                list.AddRange(new object[] { begintime, endtime });
            }
            strSql.Append(" order by a.STARTDT desc ");

            DataTable dt = new DataTable();
            try
            {
                dt = Oop.GetDataTable(strSql.ToString(), list.ToArray());
            }
            catch (Exception e)
            {
                Log.Error("查询充电记录失败！", e);
            }
            return dt;
        }

        /// <summary>
        /// 本月桩使用排名list
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public List<ChargRecord> GetSYPMList(string zhanbh, int page, int rows, ref int total)
        {
            List<ChargRecord> sypmlist = new List<ChargRecord>();
            DataTable dt1 = QuerySYPM(zhanbh, page, rows);
            DataTable dt2 = QuerySYPMTotal(zhanbh);
            total = dt2.Rows.Count;
            if (dt1.Rows.Count > 0)
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    ChargRecord bean = new ChargRecord();
                    DataRow dr = dt1.Rows[i];
                    if (dr["CHARGE_POWER"].ToString() == "" || dr["CHARGE_POWER"].ToString() == null)
                        bean.CHARGE_POWER = 0;
                    else
                        bean.CHARGE_POWER = decimal.Parse(dr["CHARGE_POWER"].ToString());
                    bean.YUNXING_BH = dr["YUNXING_BH"].ToString();
                    bean.ZHAN_JC = dr["zhan_jc"].ToString();
                    sypmlist.Add(bean);
                }
            }
            return sypmlist;
        }
        /// <summary>
        /// 分页查询本月桩使用排名
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public DataTable QuerySYPM(string zhanbh, int page, int rows)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select B.* from (select A.*,rownum rn from ( ");
            strSql.Append(" select a.yunxing_bh,c.zhan_jc,(select case  when ");
            strSql.Append(" sum(c.CHARGE_POWER) is null then 0 else sum(c.CHARGE_POWER) end from gat_data_record c where  ");
            strSql.Append(" c.zhuan_id=a.dev_chargpile and TO_CHAR(c.ENDDT,'MM')=TO_CHAR(SYSDATE,'MM')  ");
            strSql.Append(" ) as CHARGE_POWER from dev_chargpile a,dev_branch b,dev_chargstation c where a.box_id = b.branchno and b.zhuan_bh=c.zhan_bh and b.zhuan_bh='" + zhanbh + "' ");
            strSql.Append(" and a.YUNXING_BH is not null order by CHARGE_POWER desc ");
            strSql.Append(" ) A where rownum<='" + page + "'*'" + rows + "') B where rn>('" + page + "'-1)*'" + rows + "' ");
            DataTable dt = new DataTable();
            try
            {
                dt = Oop.GetDataTable(strSql.ToString());
            }
            catch (Exception e)
            {
                Log.Error("查询本月桩使用排名失败！", e);
            }
            return dt;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public DataTable QuerySYPMTotal(string zhanbh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select a.yunxing_bh,c.zhan_jc,(select case  when ");
            strSql.Append(" sum(c.CHARGE_POWER) is null then 0 else sum(c.CHARGE_POWER) end from gat_data_record c where  ");
            strSql.Append(" c.zhuan_id=a.dev_chargpile and TO_CHAR(c.ENDDT,'MM')=TO_CHAR(SYSDATE,'MM')  ");
            strSql.Append(" ) as CHARGE_POWER from dev_chargpile a,dev_branch b,dev_chargstation c where a.box_id = b.branchno and b.zhuan_bh=c.zhan_bh and b.zhuan_bh='" + zhanbh + "' ");
            strSql.Append(" and a.YUNXING_BH is not null order by CHARGE_POWER desc ");
            DataTable dt = new DataTable();
            try
            {
                dt = Oop.GetDataTable(strSql.ToString());
            }
            catch (Exception e)
            {
                Log.Error("查询本月桩使用排名失败！", e);
            }
            return dt;
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
            List<ChargRecord> cdtjlist = new List<ChargRecord>();
            DataTable dt1 = QueryCDTJBYTJ(zhanbh, zhuangbh, begintime, endtime, page, rows);
            DataTable dt2 = QueryCDTotalBYTJ(zhanbh, zhuangbh, begintime, endtime);
            total = dt2.Rows.Count;
            if (dt1.Rows.Count > 0)
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    ChargRecord bean = new ChargRecord();
                    DataRow dr = dt1.Rows[i];
                    if (dr["CHARGE_POWER"].ToString() == "" || dr["CHARGE_POWER"].ToString() == null)
                        bean.CHARGE_POWER = 0;
                    else
                        bean.CHARGE_POWER = decimal.Parse(dr["CHARGE_POWER"].ToString());
                    bean.YUNXING_BH = dr["YUNXING_BH"].ToString();
                    bean.ZHAN_JC = dr["zhan_jc"].ToString();
                    cdtjlist.Add(bean);
                }
            }
            return cdtjlist;
        }

        /// <summary>
        /// 分页条件查询充电量统计
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="zhuangbh"></param>
        /// <returns></returns>
        public DataTable QueryCDTJBYTJ(string zhanbh, string zhuangbh, DateTime begintime, DateTime endtime, int page, int rows)
        {
            var i = -1;
            List<object> list = new List<object>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select B.* from (select A.*,rownum rn from (select a.yunxing_bh,(select case  when ");
            strSql.Append(" sum(c.CHARGE_POWER) is null then 0 else sum(c.CHARGE_POWER) end from gat_data_record c where c.zhuan_id=a.dev_chargpile ");
            if (begintime != new DateTime() && endtime != new DateTime())
            {
                strSql.Append(" and c.STARTDT >={" + ++i + "} and c.ENDDT <={" + ++i + "} ");
                list.AddRange(new object[] { begintime, endtime });
            }
            strSql.Append(" ) as CHARGE_POWER,d.zhan_jc from dev_chargpile a,dev_branch b,dev_chargstation d where a.box_id = b.branchno and b.zhuan_bh=d.zhan_bh ");
            if (!string.IsNullOrEmpty(zhanbh))
            {
                strSql.Append(" and b.zhuan_bh={" + ++i + "} ");
                list.Add(zhanbh);
            }
            if (!string.IsNullOrEmpty(zhuangbh))
            {
                strSql.Append(" and a.YUNXING_BH={" + ++i + "} ");
                list.Add(zhuangbh);
            }
            strSql.Append(" and a.YUNXING_BH is not null order by CHARGE_POWER desc ");
            strSql.Append(" ) A where rownum<='" + page + "'*'" + rows + "') B where rn>('" + page + "'-1)*'" + rows + "' ");
            DataTable dt = new DataTable();
            try
            {
                dt = Oop.GetDataTable(strSql.ToString(), list.ToArray());
            }
            catch (Exception e)
            {
                Log.Error("查询充电量统计失败！", e);
            }
            return dt;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="zhanbh"></param>
        /// <param name="zhuangbh"></param>
        /// <param name="begintime"></param>
        /// <param name="endtime"></param>
        /// <returns></returns>
        public DataTable QueryCDTotalBYTJ(string zhanbh, string zhuangbh, DateTime begintime, DateTime endtime)
        {
            var i = -1;
            List<object> list = new List<object>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select a.yunxing_bh,(select sum(c.CHARGE_POWER) from gat_data_record c where c.zhuan_id=a.dev_chargpile  ");
            if (begintime != new DateTime() && endtime != new DateTime())
            {
                strSql.Append(" and c.STARTDT >={" + ++i + "} and c.ENDDT <={" + ++i + "} ");
                list.AddRange(new object[] { begintime, endtime });
            }
            strSql.Append(" ) as CHARGE_POWER,d.zhan_jc from dev_chargpile a,dev_branch b,dev_chargstation d where a.box_id = b.branchno and b.zhuan_bh=d.zhan_bh ");
            if (!string.IsNullOrEmpty(zhanbh))
            {
                strSql.Append(" and b.zhuan_bh={" + ++i + "} ");
                list.Add(zhanbh);
            }
            if (!string.IsNullOrEmpty(zhuangbh))
            {
                strSql.Append(" and a.YUNXING_BH={" + ++i + "} ");
                list.Add(zhuangbh);
            }
            strSql.Append(" and a.YUNXING_BH is not null order by CHARGE_POWER desc ");
            DataTable dt = new DataTable();
            try
            {
                dt = Oop.GetDataTable(strSql.ToString(), list.ToArray());
            }
            catch (Exception e)
            {
                Log.Error("查询充电量统计失败！", e);
            }
            return dt;
        }

        public override bool Exist(ChargRecord bean)
        {
            throw new NotImplementedException();
        }

        public override void Add(ChargRecord bean)
        {
            throw new NotImplementedException();
        }

        public override void Del(ChargRecord bean)
        {
            throw new NotImplementedException();
        }

        public override void Modify(ChargRecord bean)
        {
            throw new NotImplementedException();
        }

        public override DataTable Query(ChargRecord bean)
        {
            throw new NotImplementedException();
        }

        public override DataTable QueryByPage(ChargRecord bean, int page, int rows)
        {
            throw new NotImplementedException();
        }

        public override DataTable QueryByPage(ChargRecord bean, int page, int rows, ref int count)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据充电桩id获取最近一次交易信息(待充电、已充满)
        /// </summary>
        /// <param name="zhuanid"></param>
        /// <returns></returns>
        public DataTable FindByChargePileRecentlyBusinessInfo(int zhuanid)
        {
            Log.Debug("FindBy:方法参数：");
            var sql = new StringBuilder();
            sql.Append("select * ");
            sql.Append("from (select to_char(gdr.startdt,'yyyy-mm-dd HH24:mi:ss') startdt,");
            sql.Append("to_char(gdr.enddt,'yyyy-mm-dd HH24:mi:ss') enddt, ");
            sql.Append("EXTRACT(day FROM (gdr.enddt-gdr.startdt) DAY TO SECOND )*24+EXTRACT(HOUR FROM (gdr.enddt-gdr.startdt) DAY TO SECOND )|| ' 时 ' ");
            sql.Append("|| EXTRACT(MINUTE FROM (gdr.enddt-gdr.startdt) DAY TO SECOND )|| ' 分 ' ");
            sql.Append("|| EXTRACT(SECOND FROM (gdr.enddt-gdr.startdt) DAY TO SECOND )|| ' 秒 ' Interval, ");
            sql.Append("gdr.charge_power,gdr.power_high,gdr.power_low,gdr.power_tip,gdr.power_normal,gdr.charge_money/100 charge_money, ");
            sql.Append("gdr.card_no,gdr.card_end_money/100 card_end_money ");
            sql.Append("from gat_data_record gdr where gdr.zhuan_id='" + zhuanid + "' and gdr.startdt is not null and gdr.enddt is not null order by gdr.startdt desc,gdr.enddt desc) ");
            return Oop.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 根据充电桩id获取交易信息(充电中)
        /// </summary>
        /// <param name="zhuanid"></param>
        /// <returns></returns>
        public DataTable FindByChargingPileBusinessInfo(int zhuanid)
        {
            Log.Debug("FindBy:方法参数：");
            var sql = new StringBuilder();
            sql.Append("select * ");
            //sql.Append("from (select to_char(gdr.startdt,'yyyy-mm-dd HH24:mi:ss') startdt,");//2014-2-24内容
            sql.Append("from (select gdr.checkout_no,gdr.creditcarddt,to_char(gdr.startdt,'yyyy-mm-dd HH24:mi:ss') startdt,");//2014-2-24新修改内容
            //sql.Append("to_char(gdr.enddt,'yyyy-mm-dd HH24:mi:ss') enddt, ");
            sql.Append("EXTRACT(day FROM (gdr.enddt-gdr.startdt) DAY TO SECOND )*24+EXTRACT(HOUR FROM (gdr.enddt-gdr.startdt) DAY TO SECOND )|| ' 时 ' ");
            sql.Append("|| EXTRACT(MINUTE FROM (sysdate-gdr.startdt) DAY TO SECOND )|| ' 分 ' ");
            sql.Append("|| EXTRACT(SECOND FROM (sysdate-gdr.startdt) DAY TO SECOND )|| ' 秒 ' Interval, ");
            sql.Append("gdr.charge_power,gdr.power_high,gdr.power_low,gdr.power_tip,gdr.power_normal,gdr.charge_money/100 charge_money, ");
            sql.Append("gdr.card_no,gdr.card_end_money/100 card_end_money, ");
            sql.Append("gdr.VALUE_HIGH/100 VALUE_HIGH,gdr.VALUE_NORMAL/100 VALUE_NORMAL,gdr.VALUE_LOW/100 VALUE_LOW,gdr.VALUE_TIP/100 VALUE_TIP ");
            sql.Append("from gat_data_record gdr  ");
            sql.Append("where gdr.zhuan_id='" + zhuanid + "'  ");
            sql.Append("order by gdr.createdt desc)");
            sql.Append("where rownum=1 ");
            return Oop.GetDataTable(sql.ToString());
        }


        /// <summary>
        /// 根据充电桩id获取交易信息(故障)
        /// </summary>
        /// <param name="zhuanid"></param>
        /// <returns></returns>
        public DataTable FindByProblemChargePileBusinessInfo(int zhuanid)
        {
            Log.Debug("FindBy:方法参数：");
            var sql = new StringBuilder();
            sql.Append("select * ");
            sql.Append("from (select to_char(gdr.startdt,'yyyy-mm-dd HH24:mi:ss') startdt,");
            sql.Append("to_char(gdr.enddt,'yyyy-mm-dd HH24:mi:ss') enddt, ");
            sql.Append("EXTRACT(day FROM (gdr.enddt-gdr.startdt) DAY TO SECOND )*24+EXTRACT(HOUR FROM (gdr.enddt-gdr.startdt) DAY TO SECOND )|| ' 时 ' ");
            sql.Append("|| EXTRACT(MINUTE FROM (gdr.enddt-gdr.startdt) DAY TO SECOND )|| ' 分 ' ");
            sql.Append("|| EXTRACT(SECOND FROM (gdr.enddt-gdr.startdt) DAY TO SECOND )|| ' 秒 ' Interval, ");
            sql.Append("gdr.charge_power,gdr.power_high,gdr.power_low,gdr.power_tip,gdr.power_normal,gdr.charge_money/100 charge_money, ");
            sql.Append("gdr.card_no,gdr.card_end_money/100 card_end_money ");
            sql.Append("from gat_data_record gdr where gdr.zhuan_id='" + zhuanid + "' order by gdr.startdt desc,gdr.enddt desc) ");
            return Oop.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 根据充电开始时间最大值，查询实时信息
        /// </summary>
        /// <param name="zhuanid"></param>
        /// <returns></returns>
        public DataTable FindByBusinessInfo(int zhuanid)
        {
            Log.Debug("FindBy:方法参数：");
            var sql = new StringBuilder();
            sql.Append("select * ");
            // sql.Append("from (select to_char(gdr.startdt,'yyyy-mm-dd HH24:mi:ss') startdt, ");
            sql.Append("from (select gdr.checkout_no,gdr.creditcarddt, to_char(gdr.startdt,'yyyy-mm-dd HH24:mi:ss') startdt, ");//新修改内容
            sql.Append("to_char(gdr.enddt,'yyyy-mm-dd HH24:mi:ss') enddt, ");
            sql.Append("EXTRACT(day FROM (gdr.enddt-gdr.startdt) DAY TO SECOND )*24+EXTRACT(HOUR FROM (gdr.enddt-gdr.startdt) DAY TO SECOND )|| ' 时 ' ");
            sql.Append("|| EXTRACT(MINUTE FROM (gdr.enddt-gdr.startdt) DAY TO SECOND )|| ' 分 ' ");
            sql.Append("|| EXTRACT(SECOND FROM (gdr.enddt-gdr.startdt) DAY TO SECOND )|| ' 秒 ' Interval, ");
            sql.Append("gdr.charge_power,gdr.power_high,gdr.power_low,gdr.power_tip,gdr.power_normal,gdr.charge_money/100 charge_money, ");
            sql.Append("gdr.card_no,gdr.card_end_money/100 card_end_money, ");
            sql.Append("gdr.VALUE_HIGH/100 VALUE_HIGH,gdr.VALUE_NORMAL/100 VALUE_NORMAL,gdr.VALUE_LOW/100 VALUE_LOW,gdr.VALUE_TIP/100 VALUE_TIP ");
            sql.Append("from gat_data_record gdr  ");
            sql.Append("where gdr.zhuan_id='" + zhuanid + "'  ");
            sql.Append("order by gdr.createdt desc)");
            sql.Append("where rownum=1 ");
            return Oop.GetDataTable(sql.ToString());
        }        
        /// <summary>
        /// 根据充电开始时间最大值，查询实时信息
        /// </summary>
        /// <param name="zhuanid"></param>
        /// <returns></returns>
        public DataTable FindByStandbyInfo(int zhuanid)
        {
            Log.Debug("FindBy:方法参数：");
            var sql = new StringBuilder();
            sql.Append("select * ");
            sql.Append("from (select gdr.checkout_no,gdr.creditcarddt, to_char(gdr.startdt,'yyyy-mm-dd HH24:mi:ss') startdt, ");//新修改内容
            sql.Append("to_char(gdr.enddt,'yyyy-mm-dd HH24:mi:ss') enddt, ");
            sql.Append("EXTRACT(day FROM (gdr.enddt-gdr.startdt) DAY TO SECOND )*24+EXTRACT(HOUR FROM (gdr.enddt-gdr.startdt) DAY TO SECOND )|| ' 时 ' ");
            sql.Append("|| EXTRACT(MINUTE FROM (gdr.enddt-gdr.startdt) DAY TO SECOND )|| ' 分 ' ");
            sql.Append("|| EXTRACT(SECOND FROM (gdr.enddt-gdr.startdt) DAY TO SECOND )|| ' 秒 ' Interval, ");
            sql.Append("gdr.charge_power,gdr.power_high,gdr.power_low,gdr.power_tip,gdr.power_normal,gdr.charge_money/100 charge_money, ");
            sql.Append("gdr.card_no,gdr.card_end_money/100 card_end_money, ");
            sql.Append("gdr.VALUE_HIGH/100 VALUE_HIGH,gdr.VALUE_NORMAL/100 VALUE_NORMAL,gdr.VALUE_LOW/100 VALUE_LOW,gdr.VALUE_TIP/100 VALUE_TIP ");
            sql.Append("from gat_data_record gdr  ");
            sql.Append("where gdr.zhuan_id='" + zhuanid + "'");
            sql.Append("order by gdr.createdt desc)");
            sql.Append("where rownum=1 ");
            return Oop.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 查询充电桩充电信息
        /// </summary>
        /// <returns></returns>
        public DataTable FindByChargingPileInfo()
        {
            Log.Debug("FindByChargingPileInfo:方法参数：");
            var sql = new StringBuilder();
            sql.Append("select *  ");
            sql.Append("from(select dcp.dev_chargpile TARGETDEV2, ");
            sql.Append("(select dcs.zhan_jc from dev_chargstation dcs where dcs.zhan_bh = substr(dcp.dev_chargpile,0,3)) zhanjc, ");
            sql.Append("dcp.yunxing_bh YunxingBh, ");
            sql.Append("to_char(gdr.startdt,'yyyy-mm-dd hh24:mi:ss') startdt, ");
            sql.Append("to_char(gdr.enddt,'yyyy-mm-dd hh24:mi:ss') enddt, ");
            sql.Append("to_char(gdr.createdt,'yyyy-mm-dd hh24:mi:ss') CreateDtPara, ");
            sql.Append("gdr.card_no cardno ");
            sql.Append("from gat_data_record gdr ");
            sql.Append("inner join dev_chargpile dcp on gdr.zhuan_id=dcp.dev_chargpile ");
            //sql.Append("order by gdr.startdt desc,gdr.enddt desc) ");
            sql.Append("order by gdr.createdt desc) ");
            sql.Append("where rownum<=10 ");
            return Oop.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 根据给点的条件查询桩状态
        /// </summary>
        /// <param name="cdcz">场站编号</param>
        /// <param name="zbh">桩编号</param>
        /// <param name="dateBegin">起始日期</param>
        /// <param name="dateEnd">结束日期</param>
        /// <param name="page">页码</param>
        /// <param name="rows">行数</param>
        /// <param name="count">总计</param>
        /// <returns></returns>
        public DataTable FindByChargingPileInfo(string cdcz, string zbh, DateTime dateBegin, DateTime dateEnd, int page, int rows, ref  int count)
        {
            var i = -1;
            var list = new List<object>();
            Log.Debug("FindByChargingPileInfo(重载):方法参数：cdcz=" + cdcz + ",zbh=" + zbh + ",dateBegin=" +
                      dateBegin.ToString("yyyy-MM-dd") + ",dateEnd=" + dateEnd.ToString("yyyy-MM-dd"));

            var sqlCount = new StringBuilder("select count(*) ");
            var sql = new StringBuilder("select (select dcs.zhan_jc from dev_chargstation dcs where dcs.zhan_bh = substr(dcp.dev_chargpile,0,3)) zhanjc, ");
            sql.Append("dcp.yunxing_bh YunxingBh,gdr.charge_power chargepower,gdr.charge_money/100 chargemoney,gdr.card_no cardno, ");
            sql.Append("to_char(gdr.startdt,'yyyy-mm-dd hh24:mi:ss') startdt, ");
            sql.Append("to_char(gdr.enddt,'yyyy-mm-dd hh24:mi:ss') enddt ");
            var sqlWhere = new StringBuilder("");
            sqlWhere.Append("from gat_data_record gdr inner join dev_chargpile dcp on gdr.zhuan_id=dcp.dev_chargpile where 1=1 ");
            if (zbh.Length > 0)//桩编号如果存在
            {
                sqlWhere.Append(" and gdr.zhuan_id={" + ++i + "} ");
                list.Add(zbh);
            }
            else if (cdcz.Length > 0)
            {
                sqlWhere.Append(" and gdr.zhuan_id like {" + ++i + "} ");
                list.Add(cdcz + "%");
            }
            if (dateBegin != DateTime.MinValue)
            {
                sqlWhere.Append(" and gdr.startdt>to_date({" + ++i + "},'yyyy-mm-dd') ");
                list.Add(dateBegin.AddDays(-1).ToString("yyyy-MM-dd"));
            }
            if (dateEnd != DateTime.MinValue)
            {
                sqlWhere.Append(" and gdr.enddt<to_date({" + ++i + "},'yyyy-mm-dd') ");
                list.Add(dateEnd.AddDays(1).ToString("yyyy-MM-dd"));
            }
            count = int.Parse(Oop.GetScalar(sqlCount.Append(sqlWhere).ToString(), list.ToArray()).ToString());
            return Oop.GetDataTableByPage(
                sql.Append(sqlWhere).Append(" order by gdr.startdt desc,gdr.enddt desc ").ToString(),
                (page - 1) * rows, rows, list.ToArray());
        }

        /// <summary>
        /// 查询充电桩充电中总数量
        /// </summary>
        /// <returns></returns>
        public DataTable FindByChargingPileCount()
        {
            Log.Debug("FindByChargingPileCount:方法参数：");
            var sql = new StringBuilder();
            sql.Append("select count(*) count ");
            sql.Append("from (select gdr.zhuan_id, max(gdr.startdt) from gat_data_record gdr  ");
            sql.Append("where gdr.startdt is not null and gdr.enddt is null ");
            sql.Append("group by gdr.zhuan_id) ");
            return Oop.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 查询本月充电总电量
        /// </summary>
        /// <returns></returns>
        public DataTable FindByChargingPileZdl(int year, int month)
        {
            Log.Debug("FindByChargingPileZdl:方法参数：");
            var sql = new StringBuilder();
            sql.Append("select sum(gdr.charge_power) zdl ");
            sql.Append("from gat_data_record gdr ");
            if (month == 12)
            {
                sql.Append("where gdr.enddt between to_date('" + year + "-12-1','yyyy-mm-dd') and to_date('" + (year + 1) + "-1-1','yyyy-mm-dd') ");
            }
            else
            {
                sql.Append("where gdr.enddt between to_date('" + year + "-" + month + "-1','yyyy-mm-dd') and to_date('" + year + "-" + (month + 1) + "-1','yyyy-mm-dd') ");
            }

            return Oop.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 查询本月充电总金额
        /// </summary>
        /// <returns></returns>
        public DataTable FindByChargingPileZje(int year, int month)
        {
            Log.Debug("FindByChargingPileZje:方法参数：");
            var sql = new StringBuilder();
            sql.Append("select sum(gdr.charge_money)/100 zje ");
            sql.Append("from gat_data_record gdr ");
            if (month == 12)
            {
                sql.Append("where gdr.enddt between to_date('" + year + "-12-1','yyyy-mm-dd') and to_date('" + (year + 1) + "-1-1','yyyy-mm-dd') ");
            }
            else
            {
                sql.Append("where  gdr.enddt between to_date('" + year + "-" + month + "-1','yyyy-mm-dd') and to_date('" + year + "-" + (month + 1) + "-1','yyyy-mm-dd') ");
            }

            return Oop.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 查询本月充电总时长
        /// </summary>
        /// <returns></returns>
        public DataTable FindByChargingPileZsc(int year, int month)
        {
            Log.Debug("FindByChargingPileZje:方法参数：");
            var sql = new StringBuilder();
            sql.Append("select sum((gdr.enddt-gdr.startdt) * 24 * 60 *60) s ");
            sql.Append("from gat_data_record gdr ");
            if (month == 12)
            {
                sql.Append("where gdr.enddt between to_date('" + year + "-12-1','yyyy-mm-dd') and to_date('" + (year + 1) + "-1-1','yyyy-mm-dd') ");
            }
            else
            {
                sql.Append("where  gdr.enddt between to_date('" + year + "-" + month + "-1','yyyy-mm-dd') and to_date('" + year + "-" + (month + 1) + "-1','yyyy-mm-dd') ");
            }

            return Oop.GetDataTable(sql.ToString());
        }


        /// <summary>
        /// 查询本月排行充电总金额
        /// </summary>
        /// <returns></returns>
        public DataTable FindByRankZje(int year, int month)
        {
            Log.Debug("FindByRankZje:方法参数：");
            var sql = new StringBuilder();
            sql.Append("select rownum,t.* from( ");
            sql.Append("select dcs.zhan_jc zhanjc,sum(gdr.charge_money)/100 zje ");
            sql.Append("from gat_data_record gdr ");
            sql.Append("right join dev_chargpile dcp on dcp.dev_chargpile=gdr.zhuan_id ");
            sql.Append("right join dev_branch db on db.branchno=dcp.box_id ");
            sql.Append("right join dev_chargstation dcs on dcs.zhan_bh=db.zhuan_bh ");
            if (month == 12)
            {
                sql.Append("where dcp.deleteflag is null and gdr.enddt between to_date('" + year + "-12-1','yyyy-mm-dd') and to_date('" + (year + 1) + "-1-1','yyyy-mm-dd') ");
            }
            else
            {
                sql.Append("where dcp.deleteflag is null and  gdr.enddt between to_date('" + year + "-" + month + "-1','yyyy-mm-dd') and to_date('" + year + "-" + (month + 1) + "-1','yyyy-mm-dd') ");
            }
            sql.Append("group by dcs.zhan_jc ");
            sql.Append("order by zje desc nulls last ");
            sql.Append(") t where rownum<=3 ");
            return Oop.GetDataTable(sql.ToString());
        }


        /// <summary>
        /// 查询本月排行充电总金额
        /// </summary>
        /// <returns></returns>
        public DataTable FindByRankZje(string kssj, string jssj, int page, int rows, ref  int count)
        {
            Log.Debug("FindByRankZje:方法参数：");
            var getpage = new GetPage();
            var sql = new StringBuilder();
            sql.Append("select rownum,t.* from( ");
            sql.Append("select dcs.zhan_jc zhanjc,sum(gdr.charge_money)/100 zje ");
            sql.Append("from gat_data_record gdr ");
            sql.Append("right join dev_chargpile dcp on dcp.dev_chargpile=gdr.zhuan_id ");
            sql.Append("right join dev_branch db on db.branchno=dcp.box_id ");
            sql.Append("right join dev_chargstation dcs on dcs.zhan_bh=db.zhuan_bh ");
            sql.Append("where dcp.deleteflag is null and  gdr.enddt between to_date('" + kssj + "','yyyy-mm-dd') and to_date('" +DateTime.Parse(jssj).AddDays(1).ToString("yyyy-MM-dd") + "','yyyy-mm-dd') ");
            sql.Append("group by dcs.zhan_jc ");
            sql.Append("order by zje desc nulls last ");
            sql.Append(") t  ");
            return getpage.GetPageByProcedure(rows, page, sql.ToString(), ref count);
        }


        /// <summary>
        /// 查询本月排行卡消费总额
        /// </summary>
        /// <returns></returns>
        public DataTable FindByRankCardZje(int year, int month)
        {
            Log.Debug("FindByRankCardZje:方法参数：");
            var sql = new StringBuilder();
            sql.Append("select rownum,t.* from( ");
            sql.Append("select gdr.card_no cardno,sum(gdr.charge_money)/100 zje ");
            sql.Append("from gat_data_record gdr ");
            if (month == 12)
            {
                sql.Append("where gdr.charge_money is not null and gdr.enddt between to_date('" + year + "-12-1','yyyy-mm-dd') and to_date('" + (year + 1) + "-1-1','yyyy-mm-dd') ");
            }
            else
            {
                sql.Append("where gdr.charge_money is not null and  gdr.enddt between to_date('" + year + "-" + month + "-1','yyyy-mm-dd') and to_date('" + year + "-" + (month + 1) + "-1','yyyy-mm-dd') ");
            }
            sql.Append("group by gdr.card_no ");
            sql.Append("order by zje desc ");
            sql.Append(")t where rownum <=3 ");
            return Oop.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 查询本月排行卡消费总额
        /// </summary>
        /// <returns></returns>
        public DataTable FindByRankCardZje(string kssj, string jssj, int page, int rows, ref  int count)
        {
            Log.Debug("FindByRankCardZje:方法参数：");
            var sql = new StringBuilder();
            var getpage = new GetPage();
            sql.Append("select rownum,t.* from( ");
            sql.Append("select gdr.card_no cardno,sum(gdr.charge_money)/100 zje ");
            sql.Append("from gat_data_record gdr ");
            sql.Append("where gdr.charge_money is not null and  gdr.enddt between to_date('" + kssj + "','yyyy-mm-dd') and to_date('" + DateTime.Parse(jssj).AddDays(1).ToString("yyyy-MM-dd") + "','yyyy-mm-dd') ");
            sql.Append("group by gdr.card_no ");
            sql.Append("order by zje desc ");
            sql.Append(")t ");
            return getpage.GetPageByProcedure(rows, page, sql.ToString(), ref count);
        }

        /// <summary>
        /// 查询本月排行充电量
        /// </summary>
        /// <returns></returns>
        public DataTable FindByRankZdl(int year, int month)
        {
            Log.Debug("FindByRankZdl:方法参数：");
            var sql = new StringBuilder();
            sql.Append("select rownum,t.* from( ");
            sql.Append("select dcs.zhan_jc zhanjc,sum(gdr.charge_power)zdl ");
            sql.Append("from gat_data_record gdr ");
            sql.Append("right join dev_chargpile dcp on dcp.dev_chargpile=gdr.zhuan_id ");
            sql.Append("right join dev_branch db on db.branchno=dcp.box_id ");
            sql.Append("right join dev_chargstation dcs on dcs.zhan_bh=db.zhuan_bh ");
            if (month == 12)
            {
                sql.Append("where dcp.deleteflag is null and gdr.charge_money is not null and gdr.enddt between to_date('" + year + "-12-1','yyyy-mm-dd') and to_date('" + (year + 1) + "-1-1','yyyy-mm-dd') ");
            }
            else
            {
                sql.Append("where dcp.deleteflag is null and gdr.charge_money is not null and  gdr.enddt between to_date('" + year + "-" + month + "-1','yyyy-mm-dd') and to_date('" + year + "-" + (month + 1) + "-1','yyyy-mm-dd') ");
            }
            sql.Append("group by dcs.zhan_jc ");
            sql.Append("order by zdl desc nulls last ");
            sql.Append(") t where rownum <=3 ");
            return Oop.GetDataTable(sql.ToString());
        }


        /// <summary>
        /// 查询本月排行充电量
        /// </summary>
        /// <returns></returns>
        public DataTable FindByRankZdl(string kssj, string jssj, int page, int rows, ref  int count)
        {
            Log.Debug("FindByRankZdl:方法参数：");
            var sql = new StringBuilder();
            var getpage = new GetPage();
            sql.Append("select rownum,t.* from( ");
            sql.Append("select dcs.zhan_jc zhanjc,sum(gdr.charge_power)zdl ");
            sql.Append("from gat_data_record gdr ");
            sql.Append("right join dev_chargpile dcp on dcp.dev_chargpile=gdr.zhuan_id ");
            sql.Append("right join dev_branch db on db.branchno=dcp.box_id ");
            sql.Append("right join dev_chargstation dcs on dcs.zhan_bh=db.zhuan_bh ");
            sql.Append("where dcp.deleteflag is null and gdr.charge_money is not null and  gdr.enddt between to_date('" + kssj + "','yyyy-mm-dd') and to_date('" + DateTime.Parse(jssj).AddDays(1).ToString("yyyy-MM-dd") + "','yyyy-mm-dd') ");
            sql.Append("group by dcs.zhan_jc ");
            sql.Append("order by zdl desc nulls last ");
            sql.Append(") t  ");
            return getpage.GetPageByProcedure(rows, page, sql.ToString(), ref count);
        }

        /// <summary>
        /// 查询本月运维次数
        /// </summary>
        /// <returns></returns>
        public DataTable FindByRankRunCount(int year, int month)
        {
            Log.Debug("FindByRankZdl:方法参数：");
            var sql = new StringBuilder();
            sql.Append("select rownum,t.* from( ");
            sql.Append("select dcs.zhan_jc zhanjc,count(dmr.zhuan_id) count ");
            sql.Append("from dev_maintainrecord dmr ");
            sql.Append("right join dev_chargpile dcp on dcp.dev_chargpile=dmr.zhuan_id ");
            sql.Append("right join dev_branch db on db.branchno=dcp.box_id ");
            sql.Append("right join dev_chargstation dcs on dcs.zhan_bh=db.zhuan_bh ");
            if (month == 12)
            {
                sql.Append("where dcp.deleteflag is null and dmr.jianxiu_sj between to_date('" + year + "-12-1','yyyy-mm-dd') and to_date('" + (year + 1) + "-1-1','yyyy-mm-dd') ");
            }
            else
            {
                sql.Append("where dcp.deleteflag is null and dmr.jianxiu_sj between to_date('" + year + "-" + month + "-1','yyyy-mm-dd') and to_date('" + year + "-" + (month + 1) + "-1','yyyy-mm-dd') ");
            }
            sql.Append("group by dcs.zhan_jc ");
            sql.Append("order by count desc nulls last");
            sql.Append(") t where rownum <=3 ");
            return Oop.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 查询本月运维次数
        /// </summary>
        /// <returns></returns>
        public DataTable FindByRankRunCount(string kssj, string jssj, int page, int rows, ref  int count)
        {
            Log.Debug("FindByRankZdl:方法参数：");
            var sql = new StringBuilder();
            var getpage = new GetPage();
            sql.Append("select rownum,t.* from( ");
            sql.Append("select dcs.zhan_jc zhanjc,count(dmr.zhuan_id) count ");
            sql.Append("from dev_maintainrecord dmr ");
            sql.Append("right join dev_chargpile dcp on dcp.dev_chargpile=dmr.zhuan_id ");
            sql.Append("right join dev_branch db on db.branchno=dcp.box_id ");
            sql.Append("right join dev_chargstation dcs on dcs.zhan_bh=db.zhuan_bh ");
            sql.Append("where dcp.deleteflag is null and dmr.jianxiu_sj between to_date('"
                + kssj + "','yyyy-mm-dd') and to_date('" + DateTime.Parse(jssj).AddDays(1).ToString("yyyy-MM-dd") + "','yyyy-mm-dd') ");
            sql.Append("group by dcs.zhan_jc ");
            sql.Append("order by count desc nulls last");
            sql.Append(") t  ");
            return getpage.GetPageByProcedure(rows, page, sql.ToString(), ref count);
        }
    }
}

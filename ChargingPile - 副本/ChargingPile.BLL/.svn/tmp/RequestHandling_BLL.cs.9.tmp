using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChargingPile.DAL;
using System.Data;
using ChargingPile.Model;
using Headfree.PowerPile.Core.Rpc;

namespace ChargingPile.BLL
{
    public class RequestHandling_BLL
    {
        /// <summary>
        /// 充电站数据统计导出Excel
        /// </summary>
        public DataTable CardTotalOutExcel(string zhanid, DateTime sdt, DateTime edt)
        {
            string strSql = @"      
                            select 
                            A.zhuan_mc as 充电场站,
                            --A.zhuan_id as 桩编号,
                            A.ZHUANGXING_H as 桩型号,
                            A.zhuanglei_x as 桩类型,
                            A.YUNXING_BH as 桩运行编号,
                            A.CHARGE_TIME_MIN as 累计充电时长,
                            A.charge_number as 累计充电次数,
                            A.gat_data_record as 累计充电电量,
                            round(B.RUNRAT,2) as 运行率,
                            round(B.USERAT,2) as 使用率
                            from
                            (
                            SELECT 
                            dev_chargstation.zhuan_mc,
                            gat_data_record.zhuan_id,
                            dev_powerpiletypes.ZHUANGXING_H,
                            dev_powerpiletypes.zhuanglei_x,
                            dev_chargpile.YUNXING_BH,
                            sum(gat_data_record.CHARGE_TIME_MIN) as CHARGE_TIME_MIN,
                            count(*) as charge_number,
                            sum(gat_data_record.CHARGE_POWER) as gat_data_record
                            FROM gat_data_record
                            join dev_chargpile on dev_chargpile.DEV_CHARGPILE=gat_data_record.zhuan_id
                            join dev_powerpiletypes on dev_powerpiletypes.PARSERKEY=dev_chargpile.PILETYPEID
                            join DEV_BRANCH on DEV_BRANCH.BRANCHNO=dev_chargpile.BOX_ID
                            join DEV_CHARGSTATION on DEV_CHARGSTATION.ZHAN_BH=DEV_BRANCH.ZHUAN_BH
                            where 1=1 @where1
                            group by 
                            dev_chargstation.zhuan_mc,
                            gat_data_record.zhuan_id,
                            dev_powerpiletypes.ZHUANGXING_H,
                            dev_powerpiletypes.zhuanglei_x,
                            dev_chargpile.YUNXING_BH
                            ) A
                            left join 
                            (
                            select 
                            powerpileno,
                            avg(RUNRAT) as RUNRAT,
                            avg(USERAT) as USERAT 
                            from RPT_POWERPILEUSE 
                            where 1=1 and RPTTYPE='day' @where2
                            group by powerpileno
                            ) B on B.POWERPILENO=A.zhuan_id";

            DataTable dt = new DataTable();
            var i = -1;
            List<object> list = new List<object>();
            string strWhere1 = "";
            string strWhere2 = "";
            if (!string.IsNullOrEmpty(zhanid))
            {
                strWhere1 += " and DEV_CHARGSTATION.ZHAN_BH={" + ++i + "} ";
                list.Add(zhanid);
            }
            if (sdt != new DateTime())
            {
                strWhere1 += " and gat_data_record.STARTDT>={" + ++i + "} ";
                list.Add(sdt);
                strWhere2 += " and RPT_POWERPILEUSE.RPTDATE>={" + ++i + "} ";
                list.Add(sdt);
            }
            if (edt != new DateTime())
            {
                strWhere1 += " and gat_data_record.STARTDT<{" + ++i + "} ";
                list.Add(edt);
                strWhere2 += " and RPT_POWERPILEUSE.RPTDATE<{" + ++i + "} ";
                list.Add(edt);
            }
            strSql = strSql.Replace("@where1", strWhere1);
            strSql = strSql.Replace("@where2", strWhere2);
            Common_DAl comDAL = new Common_DAl();
            return comDAL.GetQuerySql(strSql, list);
        }
        /// <summary>
        /// 充电站数据查询导出Excel
        /// </summary>
        public DataTable CardQueryOutExcel(string cardno, DateTime sdt, DateTime edt,string zhanid)
        {
            string strSql = @"      
                            SELECT 
                            gat_data_record.card_no as 充值卡, 
                            dev_chargstation.zhuan_mc as 充电场站,
                            --gat_data_record.zhuan_id as 桩系统编号, 
                            dev_chargpile.yunxing_bh as 桩运行编号,
                            gat_data_record.startdt as 充电开始时间, 
                            gat_data_record.enddt as 充电结束时间, 

                            round(gat_data_record.value_high/100,2) as 电价_峰,
                            round(gat_data_record.value_normal/100,2) as 电价_平,
                            round(gat_data_record.value_low/100,2) as 电价_谷, 
                            round(gat_data_record.value_tip/100,2) as 电价_尖, 

                            gat_data_record.power_high as 电量_分, 
                            gat_data_record.power_normal as 电量_平, 
                            gat_data_record.power_low as 电量_谷, 
                            gat_data_record.money_tip as 电量_尖,
                            gat_data_record.charge_power as 电量_总, 

                            round(gat_data_record.charge_money/100,2) as 充电总金额
                            FROM gat_data_record
                            join dev_chargpile on dev_chargpile.DEV_CHARGPILE=gat_data_record.zhuan_id
                            join DEV_BRANCH on DEV_BRANCH.BRANCHNO=dev_chargpile.BOX_ID
                            join DEV_CHARGSTATION on DEV_CHARGSTATION.ZHAN_BH=DEV_BRANCH.ZHUAN_BH
                            where 1=1 @where order by gat_data_record.STARTDT desc
                            ";

            DataTable dt = new DataTable();
            var i = -1;
            List<object> list = new List<object>();
            string strWhere = "";
            if (!string.IsNullOrEmpty(cardno))
            {
                strWhere += " and gat_data_record.CARD_NO={" + ++i + "} ";
                list.Add(cardno);
            }
            if (sdt != new DateTime())
            {
                strWhere += " and gat_data_record.STARTDT>={" + ++i + "}  ";
                list.Add(sdt);
            }
            if (edt != new DateTime())
            {
                strWhere += " and gat_data_record.STARTDT<{" + ++i + "} ";
                list.Add(edt);
            }
            if (!string.IsNullOrEmpty(zhanid))
            {
                strWhere += " and DEV_CHARGSTATION.ZHAN_BH={" + ++i + "} ";
                list.Add(zhanid);
            }
            strSql = strSql.Replace("@where", strWhere);
            Common_DAl comDAL = new Common_DAl();
            return comDAL.GetQuerySql(strSql, list);
        }
        /// <summary>
        /// 充电信息查询
        /// </summary>
        public DataTable GetDataTableQuery(string cardno, DateTime sdt, DateTime edt,string zhanid, int page, int rows, ref int total)
        {
            string strSql = @"      
                            SELECT 
                            dev_chargstation.zhuan_mc,
                            gat_data_record.id, 
                            --gat_data_record.zhuan_id, 
                            dev_chargpile.YUNXING_BH,
                            gat_data_record.terminal_no, 
                            gat_data_record.checkout_no, 
                            gat_data_record.creditcarddt,
                            gat_data_record.startdt, 
                            gat_data_record.enddt, 
                            gat_data_record.card_no, 
                            gat_data_record.card_start_money,
                            gat_data_record.card_end_money, 
                            gat_data_record.power_high, 
                            gat_data_record.money_high, 
                            round(gat_data_record.value_high/100,2) value_high,
                            gat_data_record.power_low, 
                            gat_data_record.money_low, 
                            round(gat_data_record.value_low/100,2) value_low,
                            gat_data_record.power_tip, 
                            gat_data_record.money_tip,
                            round(gat_data_record.value_tip/100,2) value_tip,
                            gat_data_record.power_normal, 
                            gat_data_record.money_normal, 
                            round(gat_data_record.value_normal/100,2) value_normal,
                            gat_data_record.charge_power, 
                            round(gat_data_record.charge_money/100,2) charge_money,
                            gat_data_record.charge_time_hour,
                            gat_data_record.charge_time_min, 
                            gat_data_record.stop_type, 
                            gat_data_record.createdt, 
                            gat_data_record.updatedt
                            FROM gat_data_record
                            join dev_chargpile on dev_chargpile.DEV_CHARGPILE=gat_data_record.zhuan_id
                            join DEV_BRANCH on DEV_BRANCH.BRANCHNO=dev_chargpile.BOX_ID
                            join DEV_CHARGSTATION on DEV_CHARGSTATION.ZHAN_BH=DEV_BRANCH.ZHUAN_BH
                            where 1=1 @where order by gat_data_record.STARTDT  desc";

            DataTable dt = new DataTable();
            var i = -1;
            List<object> list = new List<object>();
            string strWhere = "";
            if (!string.IsNullOrEmpty(cardno))
            {
                strWhere += " and gat_data_record.CARD_NO={" + ++i + "} ";
                list.Add(cardno);
            }
            if (sdt != new DateTime())
            {
                strWhere += " and gat_data_record.STARTDT>={" + ++i + "} ";
                list.Add(sdt);
            }
            if (edt != new DateTime())
            {
                strWhere += " and gat_data_record.STARTDT<{" + ++i + "} ";
                list.Add(edt);
            }
            if (!string.IsNullOrEmpty(zhanid))
            {
                strWhere += " and DEV_CHARGSTATION.ZHAN_BH={" + ++i + "} ";
                list.Add(zhanid);
            }
            strSql = strSql.Replace("@where", strWhere);
            Common_DAl comDAL = new Common_DAl();
            return comDAL.GetQueryPage(strSql, list, page, rows, ref  total);
        }

        /// <summary>
        /// 充电信息统计
        /// </summary>
        public DataTable GetDataTableTotal(string zhanid, DateTime sdt, DateTime edt, int page, int rows, ref int total)
        {
            string strSql = @"      
                            select 
                            A.zhuan_mc,
                            A.ZHUANGXING_H,
                            --A.zhuan_id,
                            A.zhuanglei_x,
                            A.YUNXING_BH,
                            A.CHARGE_TIME_MIN,
                            A.charge_number,
                            A.gat_data_record,
                            round(B.RUNRAT,2) as RUNRAT,
                            round(B.USERAT,2) as USERAT
                            from
                            (
                            SELECT 
                            dev_chargstation.zhuan_mc,
                            gat_data_record.zhuan_id,
                            dev_powerpiletypes.ZHUANGXING_H,
                            dev_powerpiletypes.zhuanglei_x,
                            dev_chargpile.YUNXING_BH,
                            sum(gat_data_record.CHARGE_TIME_MIN) as CHARGE_TIME_MIN,
                            count(*) as charge_number,
                            sum(gat_data_record.CHARGE_POWER) as gat_data_record
                            FROM gat_data_record
                            join dev_chargpile on dev_chargpile.DEV_CHARGPILE=gat_data_record.zhuan_id
                            join dev_powerpiletypes on dev_powerpiletypes.PARSERKEY=dev_chargpile.PILETYPEID
                            join DEV_BRANCH on DEV_BRANCH.BRANCHNO=dev_chargpile.BOX_ID
                            join DEV_CHARGSTATION on DEV_CHARGSTATION.ZHAN_BH=DEV_BRANCH.ZHUAN_BH
                            where 1=1 @where1
                            group by 
                            dev_chargstation.zhuan_mc,
                            gat_data_record.zhuan_id,
                            dev_powerpiletypes.ZHUANGXING_H,
                            dev_powerpiletypes.zhuanglei_x,
                            dev_chargpile.YUNXING_BH
                            ) A
                            left join 
                            (
                            select 
                            powerpileno,
                            avg(RUNRAT) as RUNRAT,
                            avg(USERAT) as USERAT 
                            from RPT_POWERPILEUSE 
                            where 1=1 and RPTTYPE='day' @where2
                            group by powerpileno
                            ) B on B.POWERPILENO=A.zhuan_id";

            DataTable dt = new DataTable();
            var i = -1;
            List<object> list = new List<object>();
            string strWhere1 = "";
            string strWhere2 = "";
            if (!string.IsNullOrEmpty(zhanid))
            {
                strWhere1 += " and DEV_CHARGSTATION.ZHAN_BH={" + ++i + "} ";
                list.Add(zhanid);
            }
            if (sdt != new DateTime())
            {
                strWhere1 += " and gat_data_record.STARTDT>={" + ++i + "} ";
                list.Add(sdt);
                strWhere2 += " and RPT_POWERPILEUSE.RPTDATE>={" + ++i + "} ";
                list.Add(sdt);
            }
            if (edt != new DateTime())
            {
                strWhere1 += " and gat_data_record.STARTDT<{" + ++i + "} ";
                list.Add(edt);
                strWhere2 += " and RPT_POWERPILEUSE.RPTDATE<{" + ++i + "} ";
                list.Add(edt);
            }
            strSql = strSql.Replace("@where1", strWhere1);
            strSql = strSql.Replace("@where2", strWhere2);
            Common_DAl comDAL = new Common_DAl();
            return comDAL.GetQueryPage(strSql, list, page, rows, ref  total);
        }
        /// <summary>
        /// 充电站监视点查询
        /// </summary>
        public DataTable GetChargStationQuery(int page, int rows, ref int total)
        {
//            string strSql = @"      
//                            SELECT 
//                            dev_chargstation.zhan_bh, 
//                            dev_chargstation.zhuan_mc, 
//                            dev_chargstation.ismonitor,
//                            case when 
//                            dev_chargstation.ismonitor=1 then 'checked' when dev_chargstation.ismonitor=2 then '' end  as ismonitornew
//                            FROM dev_chargstation";
            string strSql = @"      
                                        SELECT 
                                        dev_chargstation.zhan_bh, 
                                        dev_chargstation.zhuan_mc, 
                                        nvl(dev_chargstation.ismonitor,0) as ismonitor,
                                        nvl(dev_chargstation.ismonitor,0) as ismonitornew
                                        FROM dev_chargstation";
            DataTable dt = new DataTable();
            List<object> list = new List<object>();
            Common_DAl comDAL = new Common_DAl();
            return comDAL.GetQueryPage(strSql, list, page, rows, ref  total);
        }
        /// <summary>
        /// 充电站监视点设置
        /// </summary>
        public int SetView(int zhanid, int sort)
        {
            Common_DAl comDAL = new Common_DAl();
            string sql = "update dev_chargstation set ismonitor={0} where zhan_bh={1}";
            List<object> list = new List<object>();
            list.Add(sort);
            list.Add(zhanid);
            return comDAL.ExecuteSQL(sql, list);
        }
        /// <summary>
        /// 充电桩死锁数据查询
        /// </summary>
        public DataTable GetPileLockQuery(int page, int rows, ref int total,string strUrl)
        {
            string strSql = @"      
                            select 
                            c.zhuan_mc zhuanmc,
                            --t.powerpileno,
                            a.YUNXING_BH,
                            a.powerpilename,
                            t.logdesc 
                            from oth_pilestates t 
                            join dev_chargpile a on a.dev_chargpile=t.powerpileno
                            join dev_branch b on b.branchno=a.box_id
                            join dev_chargstation c on c.zhan_bh=b.zhuan_bh
                            where t.logdesc like '%死锁%'
                            ";
            DataTable dt = new DataTable();
            MemeryDbDaoClient bll = new MemeryDbDaoClient();
            bll.RpcUrl = strUrl;
            var jq = bll.GetPages(strSql.ToUpper(), page, rows);
            total = jq.Total;
            dt = jq.Rows as DataTable;
            return dt;
        }

        /// <summary>
        /// 导出充电桩死锁数据Excel
        /// </summary>
        public DataTable PileLockQueryOutExcel(string strUrl)
        {
            string strSql = @"      
                            select 
                            c.zhuan_mc 充电场站名称,
                            --t.powerpileno 充电桩编号,
                            a.YUNXING_BH 桩运行编号,
                            a.powerpilename 充电桩名称,
                            t.logdesc 异常说明
                            from oth_pilestates t 
                            join dev_chargpile a on a.dev_chargpile=t.powerpileno
                            join dev_branch b on b.branchno=a.box_id
                            join dev_chargstation c on c.zhan_bh=b.zhuan_bh
                            where t.logdesc like '%死锁%'
                            ";
            DataTable dt = new DataTable();
            MemeryDbDaoClient bll = new MemeryDbDaoClient();
            bll.RpcUrl = strUrl;
            dt = bll.QueryDt(strSql.ToUpper());
            return dt;
        }
        /// <summary>
        /// 遥测明细数据查询
        /// </summary>
        public DataTable PileTelemetryQueryOutExcel(string pileno,DateTime sdt,DateTime edt,string itemname,string strUrl)
        {
            string strSql = @"      
                             select 
                             c.zhuan_mc 站名称,
                             --(select dc.yunxing_bh from dev_chargpile dc where dc.dev_chargpile= t.zhuan_id) zhuan_id,
                             --t.zhuan_id 充电桩编号,
                             p.yunxing_bh 桩运行编号,
                             p.ZONGXIAN_DZ 桩总线地址,
                             t.gatitemid 采集项标识,
                             i.ITEMNAME 名称,
                             i.M_UNITS 单位,
                             i.ITEMDESC 描述, 
                             strftime('@dt',t.gatdt) 采集时间, 
                             t.m_value || '' 值
                             from GAT_DATA_YC t 
                             join Gat_Item i on t.GATITEMID=i.ITEMNO 
                             join dev_chargpile p on p.DEV_CHARGPILE=t.zhuan_id
                             join dev_branch b on b.branchno=p.box_id
                             join DEV_CHARGSTATION c on c.zhan_bh=b.zhuan_bh
                             @where
                             order by t.gatdt desc
                             ";
            string strWhere = "where 1=1 ";
            if (!string.IsNullOrEmpty(pileno))
            {
                strWhere += " and (t.zhuan_id='" + pileno + "' or p.ZONGXIAN_DZ='" + pileno + "'  or p.yunxing_bh='" + pileno + "')";
            }
            if (sdt != new DateTime())
            {
                strWhere += " and t.gatdt>='" + sdt.ToString("yyyy-MM-dd") + " 00:00:00'";
            }
            if (edt != new DateTime())
            {
                strWhere += " and t.gatdt<'" + edt.AddDays(1).ToString("yyyy-MM-dd") + " 00:00:00'";
            }
            if (!string.IsNullOrEmpty(itemname))
            {
                strWhere += " and i.ITEMNAME like '%" + itemname + "%'";
            }
            strSql = strSql.Replace("@where", strWhere);
            strSql = strSql.ToUpper();
            strSql = strSql.Replace("@DT", "%Y-%m-%d %H:%M:%S");
            DataTable dt = new DataTable();
            MemeryDbDaoClient bll = new MemeryDbDaoClient();
            bll.RpcUrl = strUrl;
            dt = bll.QueryDt(strSql);
            return dt;
        }
        /// <summary>
        /// 充电桩遥测数据查询
        /// </summary>
        public DataTable GetPileTelemetryQuery(string pileno,DateTime sdt,DateTime edt,string itemname, int page, int rows, ref int total, string strUrl)
        {
            string strSql = @"     
                             select 
                             c.zhuan_mc,
                             --(select dc.yunxing_bh from dev_chargpile dc where dc.dev_chargpile= t.zhuan_id) zhuan_id,
                             --t.zhuan_id 充电桩编号,
                             p.yunxing_bh,
                             p.ZONGXIAN_DZ,
                             t.gatitemid,
                             i.ITEMNAME,
                             i.M_UNITS,
                             i.ITEMDESC, 
                             strftime('@dt',t.gatdt) GATDT, 
                             t.m_value || '' m_value
                             from GAT_DATA_YC t 
                             join Gat_Item i on t.GATITEMID=i.ITEMNO 
                             join dev_chargpile p on p.DEV_CHARGPILE=t.zhuan_id
                             join dev_branch b on b.branchno=p.box_id
                             join DEV_CHARGSTATION c on c.zhan_bh=b.zhuan_bh
                             @where
                             order by t.gatdt desc
                             ";
            string strWhere = "where 1=1 ";
            if (!string.IsNullOrEmpty(pileno))
            {
                strWhere += " and (t.zhuan_id='" + pileno + "' or p.ZONGXIAN_DZ='" + pileno + "'  or p.yunxing_bh='" + pileno + "')";
            }
            if (sdt != new DateTime())
            {
                strWhere += " and t.gatdt>='" + sdt.ToString("yyyy-MM-dd") + " 00:00:00'";
            }
            if (edt != new DateTime())
            {
                strWhere += " and t.gatdt<'" + edt.AddDays(1).ToString("yyyy-MM-dd") + " 00:00:00'";
            }
            if (!string.IsNullOrEmpty(itemname))
            {
                strWhere += " and i.ITEMNAME like '%" + itemname + "%'";
            }
            strSql = strSql.Replace("@where", strWhere);
            strSql = strSql.ToUpper();
            strSql = strSql.Replace("@DT", "%Y-%m-%d %H:%M:%S");
            DataTable dt = new DataTable();
            MemeryDbDaoClient bll = new MemeryDbDaoClient();
            bll.RpcUrl = strUrl;
            var jq = bll.GetPages(strSql, page, rows);
            total = jq.Total;
            dt = jq.Rows as DataTable;
            return dt;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ChargingPile.Model;
using ChargingPile.Model.ChargePile;

namespace ChargingPile.DAL
{
    public class WarnRecDal : BaseDal<WarnRec>
    {
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
            Log.Debug("Modify方法参数：" + bean);
            var sql = new StringBuilder("update oth_warnrec set");
            var i = 0;
            var dList = new List<object>();
            if (bean.ProcessFlag != null)
            {
                sql.Append(" processflag={" + i++ + "},");
                dList.Add(bean.ProcessFlag);
            }
            if (bean.ProcessDt != null)
            {
                sql.Append(" ProcessDt={" + i++ + "},");
                dList.Add(bean.ProcessDt);
            }
            if (bean.ProcesseEp != null)
            {
                sql.Append(" processeep={" + i++ + "},");
                dList.Add(bean.ProcesseEp);
            }
            sql.Append(" updatedt=sysdate where id={" + i++ + "}");
            dList.Add(bean.Id);
            Log.Debug("SQL:" + sql + ",params:" + dList.ToString());
            Oop.Execute(sql.ToString(), dList.ToArray());
        }

        public override DataTable Query(WarnRec bean)
        {
            Log.Debug("Query方法参数：" + bean.ToString());
            var sql = new StringBuilder();
            sql.Append("select t.*,case t.processeep when 'sys' then '系统灭警' else (select name from t_employer te where te.id=t.processeep) end as processeepname from oth_warnrec t where 1=1 ");
            var list = new List<object>();
            var i = -1;
            if (!string.IsNullOrEmpty(bean.Id))
            {
                sql.Append(" and t.Id={" + ++i + "}");
                list.Add(bean.Id);
            }
            if (!string.IsNullOrEmpty(bean.DataItemId))
            {
                sql.Append(" and t.DataItemId={" + ++i + "}");
                list.Add(bean.DataItemId);
            }
            if (!string.IsNullOrEmpty(bean.TargetDev))
            {
                sql.Append(" and t.TargetDev={" + ++i + "}");
                list.Add(bean.TargetDev);
            }
            if (!string.IsNullOrEmpty(bean.DataGatherId))
            {
                sql.Append(" and t.DataGatherId={" + ++i + "}");
                list.Add(bean.DataGatherId);
            }
            if (bean.Occurdt != null)
            {
                sql.Append(" and t.Occurdt={" + ++i + "}");
                list.Add(bean.Occurdt);
            }
            if (!string.IsNullOrEmpty(bean.LogType))
            {
                sql.Append(" and t.LogType={" + ++i + "}");
                list.Add(bean.LogType);
            }
            if (bean.M_Vlaue != 0)
            {
                sql.Append(" and t.M_Vlaue={" + ++i + "}");
                list.Add(bean.M_Vlaue);
            }
            if (!string.IsNullOrEmpty(bean.LogDesc))
            {
                sql.Append(" and t.LogDesc={" + ++i + "}");
                list.Add(bean.LogDesc);
            }
            if (bean.CreateDt != null)
            {
                sql.Append(" and t.CreateDt={" + ++i + "}");
                list.Add(bean.CreateDt);
            }
            if (bean.UpdateDt != null)
            {
                sql.Append(" and t.UpdateDt={" + ++i + "}");
                list.Add(bean.UpdateDt);
            }
            if (bean.ProcessFlag != 0)
            {
                sql.Append(" and t.ProcessFlag={" + ++i + "}");
                list.Add(bean.ProcessFlag);
            }
            Log.Debug("SQL :" + sql + ",params:" + list.ToString());
            return Oop.GetDataTable(sql.ToString(), list.ToArray());
        }

        /// <summary>
        /// 根据异常类型查询未处理异常
        /// </summary>
        /// <param name="type">异常类型</param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public DataTable QueryByType(string type, int page, int rows, ref int count)
        {
            Log.Debug("Query方法参数：type：" + type);
            const string sql = @"select ow.id, (select dcs.zhuan_mc from dev_chargstation dcs where dcs.zhan_bh = 
(select db.zhuan_bh from DEV_BRANCH db where db.branchno=dcp.box_id)) zhanmc,dppt.parserkey,dppt.zhuanglei_x zhuangleix,
ow.targetdev,(select gi.itemname from gat_item gi where gi.itemno=ow.dataitemid) itemname,gp.yxstates,
gp.yxeff,gp.yxwarn,gp.limitmin,gp.limitmax,gp.eff_min,gp.eff_max ,ow.m_value mvalue,ow.logdesc, ow.processflag as processflag
 from oth_warnrec ow left join dev_chargpile dcp on ow.targetdev=dcp.dev_chargpile left join DEV_POWERPILETYPES dppt 
on dppt.parserkey=dcp.piletypeid left join gat_pointcfg gp on gp.gatitemid=ow.dataitemid 
and gp.piletypeid=dppt.parserkey where ow.processflag=0 and ow.logtype={0} order by ow.createdt desc";
            Log.Debug("SQL语句：" + sql);

            const string sqlCount = @"select count(*) from oth_warnrec ow  
where ow.logtype={0} and ow.processflag=0 ";
            var o = Oop.GetScalar(sqlCount, type);
            count = int.Parse(o.ToString());
            return Oop.GetDataTableByPage(sql, (page - 1) * rows, rows, type);
        }
        public override DataTable QueryByPage(WarnRec bean, int page, int rows)
        {
            throw new NotImplementedException();
        }

        public override DataTable QueryByPage(WarnRec bean, int page, int rows, ref int count)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 查询异常数据
        /// </summary>
        /// <param name="yclx">异常类型</param>
        /// <param name="dateBegin">起始时间</param>
        /// <param name="dateEnd">结束时间</param>
        /// <returns></returns>
        public DataTable Query(string yclx, DateTime dateBegin, DateTime dateEnd)
        {
            Log.Debug("Query方法参数：yclx：" + yclx + " dateBegin：" + dateBegin.ToString("yyyy-MM-dd")
                      + ",dateEnd:" + dateEnd.ToString("yyyy-MM-dd"));
            const string sql = @"select (select dcs.zhuan_mc from dev_chargstation dcs where dcs.zhan_bh = 
(select db.zhuan_bh from DEV_BRANCH db where db.branchno=dcp.box_id)) zhanmc,dppt.parserkey,dppt.zhuanglei_x zhuangleix,
(select dc.yunxing_bh from dev_chargpile dc where dc.dev_chargpile=ow.targetdev) targetdev,
(select gi.itemname from gat_item gi where gi.itemno=ow.dataitemid) itemname,gp.yxstates,gp.yxeff,gp.yxwarn,
gp.limitmin,gp.limitmax,gp.eff_min,gp.eff_max ,ow.m_value mvalue,ow.logdesc,ow.processflag,'已处理' isproc,'手动灭警' procm, ow.processdt,
ow.processeep from oth_warnrec ow left join dev_chargpile dcp on ow.targetdev=dcp.dev_chargpile left join 
DEV_POWERPILETYPES dppt on dppt.parserkey=dcp.piletypeid left join gat_pointcfg gp on gp.gatitemid=ow.dataitemid 
and gp.piletypeid=dppt.parserkey where ow.logtype={0} and  ow.createdt between {1} and {2} order by ow.createdt";
            Log.Debug("SQL语句：" + sql);
            return Oop.GetDataTable(sql, yclx, dateBegin, dateEnd);
        }
        /// <summary>
        /// 异常数据查询
        /// </summary>
        /// <param name="yclx">异常类型</param>
        /// <param name="dateBegin">起始时间</param>
        /// <param name="dateEnd">结束时间</param>
        /// <param name="page">页码</param>
        /// <param name="rows">每页行数</param>
        /// <param name="count">总行数</param>
        /// <returns></returns>
        public DataTable QueryByPage(string yclx, DateTime dateBegin, DateTime dateEnd, int page, int rows, ref int count)
        {
            Log.Debug("QueryByPage方法参数：yclx：" + yclx + " dateBegin：" + dateBegin.ToString("yyyy-MM-dd")
                      + ",dateEnd:" + dateEnd.ToString("yyyy-MM-dd") + ",page:" + page + ",rows:" + rows);
            const string sql = @"select (select dcs.zhuan_mc from dev_chargstation dcs where dcs.zhan_bh = 
(select db.zhuan_bh from DEV_BRANCH db where db.branchno=dcp.box_id)) zhanmc,dppt.parserkey,dppt.zhuanglei_x zhuangleix,
(select dc.yunxing_bh from dev_chargpile dc where dc.dev_chargpile=ow.targetdev) targetdev,
(select gi.itemname from gat_item gi where gi.itemno=ow.dataitemid) itemname,gp.yxstates,ow.processeep,
gp.yxeff,gp.yxwarn,gp.limitmin,gp.limitmax,gp.eff_min,gp.eff_max ,ow.m_value mvalue,ow.processflag,ow.logdesc,ow.processdt 
from oth_warnrec ow left join dev_chargpile dcp on ow.targetdev=dcp.dev_chargpile left join DEV_POWERPILETYPES dppt 
on dppt.parserkey=dcp.piletypeid left join gat_pointcfg gp on gp.gatitemid=ow.dataitemid 
and gp.piletypeid=dppt.parserkey where ow.logtype={0} and  ow.createdt between {1} and {2} order by ow.createdt";
            Log.Debug("SQL语句：" + sql);
            const string sqlCount = @"select count(*) from oth_warnrec ow  
where ow.logtype={0} and  ow.createdt between {1} and {2} ";
            var o = Oop.GetScalar(sqlCount, yclx, dateBegin, dateEnd);
            count = int.Parse(o.ToString());
            return Oop.GetDataTableByPage(sql, (page - 1) * rows, rows, yclx, dateBegin, dateEnd);
        }

        /// <summary>
        /// 查询格式化告警信息
        /// </summary>
        /// <returns></returns>
        public DataTable FindBy(string zhanid)
        {
            Log.Debug("FindBy方法没有参数");
            var sql = new StringBuilder();
            sql.Append("select * from( ");
            sql.Append("select sc.codename logtype,occurdt,logdesc,dcp.yunxing_bh yxbh ");
            sql.Append("from oth_warnrec t ");
            sql.Append("inner join dev_chargpile dcp on (to_char(dcp.dev_chargpile))=t.targetdev ");
            sql.Append("inner join dev_branch db on db.branchno=dcp.box_id ");
            sql.Append("inner join dev_chargstation dcs on dcs.zhan_bh=db.zhuan_bh ");
            sql.Append("inner join sys_code sc on sc.code=t.logtype ");
            sql.Append("where dcs.zhan_bh=" + zhanid + "' and sc.parentid='5077B15C-4F5E-49B2-9E32-E7C1E2F1E74D' ");
            sql.Append("order by occurdt desc ");
            sql.Append(") where rownum<=4 ");
            return Oop.GetDataTable(sql.ToString());
        }


        /// <summary>
        /// 根据充电桩id查询格式化告警信息
        /// </summary>
        /// <returns></returns>
        public DataTable FindBy(int zhuanid)
        {
            Log.Debug("FindBy方法没有参数");
            var sql = new StringBuilder();
            sql.Append("select * from( ");
            sql.Append("select sc.codename logtype,occurdt,logdesc ");
            sql.Append("from oth_warnrec t ");
            sql.Append("inner join sys_code sc on sc.code=t.logtype ");
            sql.Append("where t.targetdev='" + zhuanid + "' and sc.parentid='5077B15C-4F5E-49B2-9E32-E7C1E2F1E74D' ");
            sql.Append("order by occurdt desc ");
            sql.Append(") where rownum<=4 ");
            return Oop.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 查询告警信息(根据数据采集id)
        /// </summary>
        /// <returns></returns>
        public DataTable FindByWarnRec(string datagatherid)
        {
            Log.Debug("FindByWarnRec方法没有参数");
            var sql = new StringBuilder();
            sql.Append("select t.id,t.datagatherid,t.targetdev,t.dataitemid ");
            sql.Append("from oth_warnrec t  ");
            sql.Append("where t.datagatherid={0} ");
            return Oop.GetDataTable(sql.ToString(), datagatherid);
        }

        /// <summary>
        /// 修改告警信息
        /// </summary>
        /// <param name="bean"></param>
        public void EditBy(WarnRec bean)
        {
            Log.Debug("Modify方法参数：" + bean);
            var sql = new StringBuilder("update oth_warnrec set");
            var i = 0;
            var dList = new List<object>();
            if (bean.ProcessFlag != null)
            {
                sql.Append(" processflag={" + i++ + "},");
                dList.Add(bean.ProcessFlag);
            }
            if (bean.ProcessDt != null)
            {
                sql.Append(" ProcessDt={" + i++ + "},");
                dList.Add(bean.ProcessDt);
            }
            if (bean.ProcesseEp != null)
            {
                sql.Append(" processeep={" + i++ + "},");
                dList.Add(bean.ProcesseEp);
            }
            sql.Append(" updatedt=sysdate where DATAITEMID={" + i++ + "} and TARGETDEV={" + i + "}");
            dList.Add(bean.DataItemId);
            dList.Add(bean.TargetDev);
            Log.Debug("SQL:" + sql + ",params:" + dList.ToString());
            Oop.Execute(sql.ToString(), dList.ToArray());
        }

        /// <summary>
        /// 查询异常告警
        /// </summary>
        /// <returns></returns>
        public DataTable FindByTelesignallingWarn(string zhanbh)
        {
            Log.Debug("FindByTelesignallingWarn方法没有参数");
            var sql = new StringBuilder();
            sql.Append("select * ");
            sql.Append("from (select owr.id,owr.dataitemid,owr.processeep, ");
            sql.Append("(select sc.codename from sys_code sc where sc.parentid='5077B15C-4F5E-49B2-9E32-E7C1E2F1E74D' and owr.logtype=sc.code) codename,");
            sql.Append("to_char(owr.occurdt,'yyyy-mm-dd hh24:mi:ss') occurdt,");
            sql.Append("(select dcs.zhan_jc from dev_chargstation dcs ");
            sql.Append("inner join dev_branch db on db.zhuan_bh=dcs.zhan_bh ");
            sql.Append("inner join dev_chargpile dcp on dcp.box_id=db.branchno ");
            sql.Append("where dcp.dev_chargpile=owr.targetdev) zhanjc,");
            sql.Append("(select dcp.yunxing_bh from dev_chargpile dcp where (to_char(dcp.dev_chargpile))=owr.targetdev) yunxing_bh,");
            sql.Append("(select gi.Itemname from gat_item gi where gi.itemno=owr.dataitemid) itemname, ");
            sql.Append("owr.logdesc,owr.processflag,owr.targetdev ");
            sql.Append("from oth_warnrec owr ");
            sql.Append("where owr.dataitemid!='CardExceptionState' and owr.dataitemid!='DTUStatus' and owr.dataitemid!='PowerStopState' ");
            if (!string.IsNullOrEmpty(zhanbh))
            {
                sql.Append("and owr.targetdev like '" + zhanbh + "%' ");
            }
            sql.Append("order by owr.occurdt desc)");
            sql.Append("where rownum<=10");
            return Oop.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 查询异常告警
        /// </summary>
        /// <returns></returns>
        public DataTable FindByTelesignallingWarn()
        {
            Log.Debug("FindByTelesignallingWarn方法没有参数");
            var sql = new StringBuilder();
            sql.Append("select * from (select owr.id, ");
            sql.Append("to_char(owr.updatedt,'yyyy-mm-dd hh24:mi:ss') updatedt, ");
            sql.Append("to_char(owr.createdt,'yyyy-mm-dd hh24:mi:ss') CreateDtPara, ");
            sql.Append("to_char(owr.occurdt,'yyyy-mm-dd hh24:mi:ss') occurdt, ");
            sql.Append("(select dcs.zhan_jc from dev_chargstation dcs ");
            sql.Append("inner join dev_branch db on db.zhuan_bh=dcs.zhan_bh ");
            sql.Append("inner join dev_chargpile dcp on dcp.box_id=db.branchno  ");
            sql.Append("where dcp.dev_chargpile=owr.targetdev) zhanjc, ");
            sql.Append("(select dcp.yunxing_bh from dev_chargpile dcp where (to_char(dcp.dev_chargpile))=owr.targetdev) YunXingBh, ");
            sql.Append("gi.itemname,owr.processflag,owr.Logdesc,owr.targetdev ");
            sql.Append("from oth_warnrec owr ");
            sql.Append("inner join gat_item gi on owr.dataitemid=gi.itemno ");
            sql.Append("where owr.dataitemid!='CardExceptionState' and owr.dataitemid!='DTUStatus' and owr.dataitemid!='PowerStopState' ");
            sql.Append("order by owr.occurdt desc)");
            sql.Append("where rownum<=4");
            return Oop.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 查询异常告警
        /// </summary>
        /// <param name="warnid">告警id</param>
        /// <returns></returns>
        public DataTable FindByTelesignallingWarn2(string warnid)
        {
            Log.Debug("FindByTelesignallingWarn方法没有参数");
            var sql = new StringBuilder();
            sql.Append("select * from (select owr.id, ");
            sql.Append("to_char(owr.occurdt,'yyyy-mm-dd hh24:mi:ss') occurdt, ");
            sql.Append("(select dcs.zhan_jc from dev_chargstation dcs ");
            sql.Append("inner join dev_branch db on db.zhuan_bh=dcs.zhan_bh ");
            sql.Append("inner join dev_chargpile dcp on dcp.box_id=db.branchno  ");
            sql.Append("where dcp.dev_chargpile=owr.targetdev) zhanjc, ");
            sql.Append("(select dcp.yunxing_bh from dev_chargpile dcp where (to_char(dcp.dev_chargpile))=owr.targetdev) YunXingBh, ");
            sql.Append("gi.itemname,owr.processflag,owr.Logdesc,owr.targetdev ");
            sql.Append("from oth_warnrec owr ");
            sql.Append("inner join gat_item gi on owr.dataitemid=gi.itemno ");
            sql.Append("where owr.dataitemid!='CardExceptionState' and owr.dataitemid!='DTUStatus' and owr.dataitemid!='PowerStopState' ");
            if (!string.IsNullOrEmpty(warnid))
            {
                sql.Append("and owr.id='" + warnid + "' ");
            }
            sql.Append("order by owr.occurdt desc)");
            sql.Append("where rownum<=4");
            return Oop.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 查询异常告警未处理个数
        /// </summary>
        /// <returns></returns>
        public DataTable FindByTelesignallingWarnCount()
        {
            Log.Debug("FindByTelesignallingWarnCount方法没有参数");
            var sql = new StringBuilder();
            sql.Append("select count(owr.id) count ");
            sql.Append("from oth_warnrec owr ");
            sql.Append("where owr.dataitemid!='CardExceptionState' and owr.dataitemid!='DTUStatus' and owr.dataitemid!='PowerStopState' and owr.processflag='0'");
            return Oop.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 查询充电卡异常使用告警
        /// </summary>
        /// <returns></returns>
        public DataTable FindByCardWarn(string zhanbh)
        {
            Log.Debug("FindByCardWarn方法没有参数");
            var sql = new StringBuilder();
            sql.Append("select * ");
            sql.Append("from (select owr.id,owr.targetdev,owr.dataitemid, ");
            sql.Append("to_char(owr.occurdt,'yyyy-mm-dd hh24:mi:ss') occurdt,");
            sql.Append("(select dcs.zhan_jc from dev_chargstation dcs ");
            sql.Append("inner join dev_branch db on db.zhuan_bh=dcs.zhan_bh ");
            sql.Append("inner join dev_chargpile dcp on dcp.box_id=db.branchno ");
            sql.Append("where dcp.dev_chargpile=owr.targetdev) zhanjc,");
            sql.Append("(select dcp.yunxing_bh from dev_chargpile dcp where (to_char(dcp.dev_chargpile))=owr.targetdev) yunxing_bh,");
            sql.Append("owr.processflag,owr.targetdatakey ");
            sql.Append("from oth_warnrec owr ");
            sql.Append("where owr.dataitemid='CardExceptionState' ");
            if (!string.IsNullOrEmpty(zhanbh))
            {
                sql.Append("and owr.targetdev like '" + zhanbh + "%' ");
            }
            sql.Append("order by owr.occurdt desc)");
            sql.Append("where rownum<=3");
            return Oop.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 查询充电卡异常使用告警
        /// </summary>
        /// <returns></returns>
        public DataTable FindByCardWarn()
        {
            Log.Debug("FindByCardWarn方法没有参数");
            var sql = new StringBuilder();
            sql.Append("select * ");
            sql.Append("from (select owr.id,owr.TARGETDEV, ");
            sql.Append("to_char(owr.occurdt,'yyyy-mm-dd hh24:mi:ss') occurdt,");
            sql.Append("to_char(owr.createdt,'yyyy-mm-dd hh24:mi:ss') CreateDtPara,");
            sql.Append("(select dcs.zhan_jc from dev_chargstation dcs ");
            sql.Append("inner join dev_branch db on db.zhuan_bh=dcs.zhan_bh ");
            sql.Append("inner join dev_chargpile dcp on dcp.box_id=db.branchno ");
            sql.Append("where dcp.dev_chargpile=owr.targetdev) zhanjc,");
            sql.Append("(select dcp.yunxing_bh from dev_chargpile dcp where (to_char(dcp.dev_chargpile))=owr.targetdev) yunxingbh,");
            sql.Append("owr.processflag,owr.targetdatakey ");
            sql.Append("from oth_warnrec owr ");
            sql.Append("where owr.dataitemid='CardExceptionState' ");
            sql.Append("order by owr.occurdt desc)");
            sql.Append("where rownum<=4");
            return Oop.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 查询充电卡异常使用告警个数
        /// </summary>
        /// <returns></returns>
        public DataTable FindByCardWarnCount()
        {
            Log.Debug("FindByCardWarnCount方法没有参数");
            var sql = new StringBuilder();
            sql.Append("select count(owr.id) count ");
            sql.Append("from oth_warnrec owr ");
            sql.Append("where owr.dataitemid='CardExceptionState' and owr.processflag='0'");
            return Oop.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 查询通信告警
        /// </summary>
        /// <returns></returns>
        public DataTable FindByCommunicationWarn(string zhanbh)
        {
            Log.Debug("FindByCommunicationWarn方法没有参数");
            var sql = new StringBuilder();
            sql.Append("select * ");
            sql.Append("from (select owr.id,owr.targetdev,owr.dataitemid, ");
            sql.Append("(select dd.dtuname from dev_dtu dd where owr.targetdev=dd.dtuid) dtuname, ");
            sql.Append("to_char(owr.occurdt,'yyyy-mm-dd hh24:mi:ss') occurdt,");

            sql.Append("(select dcs.zhan_jc from dev_chargstation dcs  ");
            sql.Append("inner join dev_dtu dd on dcs.zhan_bh=dd.zhuan_bh ");
            sql.Append("where dd.dtuid=owr.targetdev) zhanjc, ");

            sql.Append("(select dcp.yunxing_bh from dev_chargpile dcp where dcp.dev_chargpile=owr.targetdev) yunxing_bh,");
            sql.Append("owr.processflag ");
            sql.Append("from oth_warnrec owr ");
            sql.Append("where owr.targettype='002' ");
            if (!string.IsNullOrEmpty(zhanbh))
            {
                sql.Append("and owr.targetdev like '" + zhanbh + "%' ");
            }
            sql.Append("order by owr.occurdt desc)");
            sql.Append("where rownum<=3");
            return Oop.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 查询通信告警(针对告警服务页面中停电告警)
        /// </summary>
        /// <returns></returns>
        public DataTable FindByCommunicationWarn2(string zhanbh)
        {
            Log.Debug("FindByCommunicationWarn方法没有参数");
            var sql = new StringBuilder();
            sql.Append("select * ");
            sql.Append("from (select owr.id,owr.targetdev,owr.dataitemid, ");
            sql.Append("(select dd.dtuname from dev_dtu dd where owr.targetdev=dd.dtuid) dtuname, ");
            sql.Append("to_char(owr.occurdt,'yyyy-mm-dd hh24:mi:ss') occurdt,");

            sql.Append("(select dcs.zhan_jc from dev_chargstation dcs  ");
            sql.Append("inner join dev_dtu dd on dcs.zhan_bh=dd.zhuan_bh ");
            sql.Append("where dd.dtuid=owr.targetdev) zhanjc, ");

            sql.Append("(select dcp.yunxing_bh from dev_chargpile dcp where (to_char(dcp.dev_chargpile))=owr.targetdev) yunxing_bh,");
            sql.Append("owr.processflag ");
            sql.Append("from oth_warnrec owr ");
            sql.Append("where owr.dataitemid='DTUStatus' ");
            if (!string.IsNullOrEmpty(zhanbh))
            {
                sql.Append("and owr.targetdev like '" + zhanbh + "%' ");
            }
            sql.Append("order by owr.occurdt desc)");
            sql.Append("where rownum<=3");
            return Oop.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 查询通信告警个数
        /// </summary>
        /// <returns></returns>
        public DataTable FindByCommunicationWarnCount()
        {
            Log.Debug("FindByCommunicationWarnCount方法没有参数");
            var sql = new StringBuilder();
            sql.Append("select count(owr.id) count ");
            sql.Append("from oth_warnrec owr ");
            sql.Append("where owr.dataitemid='DTUStatus' and owr.processflag='0'");
            return Oop.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 查询停电告警
        /// </summary>
        /// <returns></returns>
        public DataTable FindByPowerFailure(string zhanbh)
        {
            Log.Debug("FindByPowerFailure方法没有参数");
            var sql = new StringBuilder();
            sql.Append("select * ");
            sql.Append("from (select owr.id,owr.targetdev,owr.dataitemid, ");
            sql.Append("(select dd.dtuname from dev_dtu dd where owr.targetdev=dd.dtuid) dtuname, ");
            sql.Append("to_char(owr.occurdt,'yyyy-mm-dd hh24:mi:ss') occurdt,");

            sql.Append("(select dcs.zhan_jc from dev_chargstation dcs  ");
            sql.Append("inner join dev_dtu dd on dcs.zhan_bh=dd.zhuan_bh ");
            sql.Append("where dd.dtuid=owr.targetdev) zhanjc, ");

            sql.Append("(select dcp.yunxing_bh from dev_chargpile dcp where (to_char(dcp.dev_chargpile))=owr.targetdev) yunxing_bh,");
            sql.Append("owr.processflag ");
            sql.Append("from oth_warnrec owr ");
            sql.Append("where owr.targettype='002' ");
            if (!string.IsNullOrEmpty(zhanbh))
            {
                sql.Append("and owr.targetdev like '" + zhanbh + "%' ");
            }
            sql.Append("order by owr.occurdt desc)");
            sql.Append("where rownum<=3");
            return Oop.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 查询停电告警(针对告警服务页面中停电告警)
        /// </summary>
        /// <returns></returns>
        public DataTable FindByPowerFailure3(string zhanbh)
        {
            Log.Debug("FindByPowerFailure方法没有参数");
            var sql = new StringBuilder();
            sql.Append("select * ");
            sql.Append("from (select owr.id,owr.targetdev,owr.dataitemid, ");
            sql.Append("to_char(owr.occurdt,'yyyy-mm-dd hh24:mi:ss') occurdt,");

            sql.Append(" (select dcs.zhan_jc from dev_chargstation dcs where dcs.zhan_bh=owr.targetdev) zhanjc,  ");

            sql.Append("(select dcp.yunxing_bh from dev_chargpile dcp where (to_char(dcp.dev_chargpile))=owr.targetdev) yunxing_bh,");
            sql.Append("owr.processflag ");
            sql.Append("from oth_warnrec owr ");
            sql.Append("where owr.dataitemid='PowerStopState' ");
            if (!string.IsNullOrEmpty(zhanbh))
            {
                sql.Append("and owr.targetdev like '" + zhanbh + "%' ");
            }
            sql.Append("order by owr.occurdt desc)");
            sql.Append("where rownum<=3");
            return Oop.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 查询通信告警个数
        /// </summary>
        /// <returns></returns>
        public DataTable FindByPowerFailureCount()
        {
            Log.Debug("FindByPowerFailureCount方法没有参数");
            var sql = new StringBuilder();
            sql.Append("select count(owr.id) count ");
            sql.Append("from oth_warnrec owr ");
            sql.Append("where owr.dataitemid='PowerStopState' and owr.processflag='0'");
            return Oop.GetDataTable(sql.ToString());
        }

        /// <summary>
        ///  查询异常告警
        /// </summary>
        /// <returns></returns>
        public DataTable FindByTelesignallingWarn(TelesignallingParam telesignallingParam, int page, int rows, ref int count)
        {
            Log.Debug("FindByTelesignallingWarn方法没有参数");
            var sql = new StringBuilder();
            var sqlWhere = new StringBuilder();
            var sqlCount = new StringBuilder("select count(*) from oth_warnrec owr  inner join dev_chargpile dcp2 on dcp2.dev_chargpile=owr.targetdev ");
            var getpage = new GetPage();
            sql.Append("select owr.id,owr.targetdev,owr.dataitemid, ");
            sql.Append("(select sc.codename from sys_code sc where sc.parentid='5077B15C-4F5E-49B2-9E32-E7C1E2F1E74D' and owr.logtype=sc.code) codename, ");
            sql.Append("to_char(owr.occurdt,'yyyy-mm-dd hh24:mi:ss') occurdt,");
            sql.Append("(select dcs.zhan_jc from dev_chargstation dcs ");
            sql.Append("inner join dev_branch db on db.zhuan_bh=dcs.zhan_bh ");
            sql.Append("inner join dev_chargpile dcp on dcp.box_id=db.branchno ");
            sql.Append("where dcp.dev_chargpile=owr.targetdev) zhanjc,");
            sql.Append("(select dcp.yunxing_bh from dev_chargpile dcp where (to_char(dcp.dev_chargpile))=owr.targetdev) yunxing_bh,");
            sql.Append("(select gi.Itemname from gat_item gi where gi.itemno=owr.dataitemid) itemname, ");
            sql.Append("owr.logdesc,owr.processflag ");
            sql.Append("from oth_warnrec owr ");
            sql.Append("inner join dev_chargpile dcp2 on (to_char(dcp2.dev_chargpile))=owr.targetdev ");
            sqlWhere.Append("where owr.dataitemid!='CardExceptionState' and owr.dataitemid!='DTUStatus' and owr.dataitemid!='PowerStopState' ");

            if (!string.IsNullOrEmpty(telesignallingParam.WarnType))
            {
                sqlWhere.Append("and owr.logtype='" + telesignallingParam.WarnType + "' ");
            }
            if (!string.IsNullOrEmpty(telesignallingParam.Zhanbh))
            {
                sqlWhere.Append("and owr.targetdev like '" + telesignallingParam.Zhanbh + "%' ");
            }
            if (!string.IsNullOrEmpty(telesignallingParam.ZhanYxBh))
            {
                sqlWhere.Append("and dcp2.yunxing_bh='" + telesignallingParam.ZhanYxBh + "' ");
            }
            if (!string.IsNullOrEmpty(telesignallingParam.Kssj) && !string.IsNullOrEmpty(telesignallingParam.Jssj))
            {
                sqlWhere.Append("and owr.occurdt between to_date('" + telesignallingParam.Kssj + "','yyyy-mm-dd') and to_date('" + telesignallingParam.Jssj + "','yyyy-mm-dd')+1 ");
            }
            if (!string.IsNullOrEmpty(telesignallingParam.Clfs))
            {
                sqlWhere.Append("and owr.processflag='" + telesignallingParam.Clfs + "' ");
            }
            sqlWhere.Append("order by owr.occurdt desc");
            count = int.Parse(Oop.GetScalar(sqlCount.Append(sqlWhere).ToString()).ToString());
            return Oop.GetDataTableByPage(sql.Append(sqlWhere).ToString(), (page - 1) * rows, rows);
        }

        /// <summary>
        /// 查询告警类型
        /// </summary>
        /// <returns></returns>
        public DataTable FindByWarnType()
        {
            Log.Debug("FindByWarnType方法没有参数");
            var sql = new StringBuilder();
            sql.Append("select sc.code,sc.codename from sys_code sc  ");
            sql.Append("where sc.parentid='5077B15C-4F5E-49B2-9E32-E7C1E2F1E74D' ");
            return Oop.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 查询场站名称
        /// </summary>
        /// <returns></returns>
        public DataTable FindByZhanMc()
        {
            Log.Debug("FindByZhanMc方法没有参数");
            var sql = new StringBuilder();
            sql.Append("select dcs.zhan_bh,dcs.zhan_jc from dev_chargstation dcs  ");
            return Oop.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 查询桩运行编号
        /// </summary>
        /// <param name="zhanBh">充电场站编号</param>
        /// <returns></returns>
        public DataTable FindByYunXinBh(string zhanBh)
        {
            Log.Debug("FindByZhanMc方法没有参数");
            var sql = new StringBuilder();
            sql.Append("select distinct dcp.yunxing_bh ");
            sql.Append("from dev_chargstation dcs  ");
            sql.Append("inner join dev_branch db on db.zhuan_bh=dcs.zhan_bh  ");
            sql.Append("inner join dev_chargpile dcp on dcp.box_id=db.branchno ");
            sql.Append("where dcs.zhan_bh='" + zhanBh + "'  ");
            return Oop.GetDataTable(sql.ToString());
        }
    }
}

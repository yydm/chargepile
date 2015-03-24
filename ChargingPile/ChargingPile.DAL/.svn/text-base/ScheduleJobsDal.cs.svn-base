using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ChargingPile.Model;

namespace ChargingPile.DAL
{
    public class ScheduleJobsDal : BaseDal<ScheduleJobs>
    {
        /// <summary>
        /// 判断是否存在计划任务
        /// </summary>
        /// <param name="bean"></param>
        /// <returns></returns>
        public override bool Exist(ScheduleJobs bean)
        {
            Log.Debug("exist方法" + bean);
            var sql = new StringBuilder();
            sql.Append("select * from cmd_schedulejobs t where id='" + bean.Id + "'");
            var dt = Oop.GetDataTable(sql.ToString());
            Log.Debug("SQL :" + sql);
            return dt.Rows.Count > 0;
        }

        /// <summary>
        /// 保存计划任务
        /// </summary>
        /// <param name="bean"></param>
        public override void Add(ScheduleJobs bean)
        {
            Log.Debug("Add方法参数：" + bean.ToString());
            var sql1 = new StringBuilder();
            var sql2 = new StringBuilder();
            var i = 0;
            var list = new List<object>();
            if (!string.IsNullOrEmpty(bean.Id))
            {
                sql1.Append(" Id,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.Id);
            }
            if (!string.IsNullOrEmpty(bean.TaskName))
            {
                sql1.Append(" TaskName,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.TaskName);
            }
            if (bean.PowerpileId != null)
            {
                sql1.Append(" PowerpileId,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.PowerpileId);
            }
            if (!string.IsNullOrEmpty(bean.Interval))
            {
                sql1.Append(" Interval,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.Interval);
            }
            if (!string.IsNullOrEmpty(bean.CmdType))
            {
                sql1.Append(" CmdType,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.CmdType);
            }
            if (!string.IsNullOrEmpty(bean.TaskState))
            {
                sql1.Append(" TaskState,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.TaskState);
            }
            if (bean.JobMonth != null)
            {
                sql1.Append(" Job_Month,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.JobMonth);
            }
            if (bean.JobWeek != null)
            {
                sql1.Append(" Job_Week,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.JobWeek);
            }
            if (bean.JobDay != null)
            {
                sql1.Append(" Job_Day,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.JobDay);
            }
            if (bean.JobHour != null)
            {
                sql1.Append(" Job_Hour,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.JobHour);
            }
            if (bean.JobMinute != null)
            {
                sql1.Append(" Job_Minute,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.JobMinute);
            }
            if (bean.JobSecond != null)
            {
                sql1.Append(" Job_Second,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.JobSecond);
            }
            if (bean.RunatDate != null)
            {
                sql1.Append(" RunatDate,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.RunatDate);
            }
            if (!string.IsNullOrEmpty(bean.Remark))
            {
                sql1.Append(" Remark,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.Remark);
            }
            if (!string.IsNullOrEmpty(bean.RefId))
            {
                sql1.Append(" RefId,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.RefId);
            }
            if (!string.IsNullOrEmpty(bean.Refenity))
            {
                sql1.Append(" Refenity,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.Refenity);
            }
            if (bean.CreateDT != null)
            {
                sql1.Append(" CreateDT,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.CreateDT);
            }
            if (bean.UpdateDT != null)
            {
                sql1.Append(" UpdateDT,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.UpdateDT);
            }
            if (sql1.Length > 0)
            {
                sql1 = sql1.Remove(sql1.Length - 1, 1);
                sql2 = sql2.Remove(sql2.Length - 1, 1);
            }
            var sql = "insert into cmd_schedulejobs(" + sql1 + ") values(" + sql2 + ")";
            Log.Debug("SQL :" + sql + ",params:" + list.ToString());
            int intCt=Oop.Execute(sql, list.ToArray());
        }


        /// <summary>
        /// 删除充电桩计划任务
        /// </summary>
        /// <param name="bean"></param>
        public override void Del(ScheduleJobs bean)
        {
            Log.Debug("del方法参数：" + bean);
            var sql = new StringBuilder();
            sql.Append("delete from cmd_schedulejobs where id='" + bean.Id + "'");
            Log.Debug("SQL :" + sql);
            Oop.Execute(sql.ToString());
        }

        /// <summary>
        /// 修改计划任务
        /// </summary>
        /// <param name="bean"></param>
        public override void Modify(ScheduleJobs bean)
        {
            Log.Debug("Modify方法参数：" + bean);
            var sql = new StringBuilder();
            sql.Append("update sm_useroles set");
            var i = 0;
            var dList = new List<object>();
            if (!string.IsNullOrEmpty(bean.TaskName))
            {
                sql.Append(" TaskName={" + i++ + "}");
                dList.Add(bean.TaskName);
            }
            if (bean.PowerpileId != null)
            {
                sql.Append(" PowerpileId={" + i++ + "}");
                dList.Add(bean.PowerpileId);
            }
            if (!string.IsNullOrEmpty(bean.Interval))
            {
                sql.Append(" Interval={" + i++ + "}");
                dList.Add(bean.Interval);
            }
            if (!string.IsNullOrEmpty(bean.CmdType))
            {
                sql.Append(" CmdType={" + i++ + "}");
                dList.Add(bean.CmdType);
            }
            if (!string.IsNullOrEmpty(bean.TaskState))
            {
                sql.Append(" TaskState={" + i++ + "}");
                dList.Add(bean.TaskState);
            }
            if (bean.JobMonth != null)
            {
                sql.Append(" JobMonth={" + i++ + "}");
                dList.Add(bean.JobMonth);
            }
            if (bean.JobWeek != null)
            {
                sql.Append(" JobWeek={" + i++ + "}");
                dList.Add(bean.JobWeek);
            }
            if (bean.JobDay != null)
            {
                sql.Append(" JobDay={" + i++ + "}");
                dList.Add(bean.JobDay);
            }
            if (bean.JobHour != null)
            {
                sql.Append(" JobHour={" + i++ + "}");
                dList.Add(bean.JobHour);
            }
            if (bean.JobMinute != null)
            {
                sql.Append(" JobMinute={" + i++ + "}");
                dList.Add(bean.JobMinute);
            }
            if (bean.JobSecond != null)
            {
                sql.Append(" JobSecond={" + i++ + "}");
                dList.Add(bean.JobSecond);
            }
            if (bean.RunatDate != null)
            {
                sql.Append(" RunatDate={" + i++ + "}");
                dList.Add(bean.RunatDate);
            }
            if (!string.IsNullOrEmpty(bean.Remark))
            {
                sql.Append(" Remark={" + i++ + "}");
                dList.Add(bean.Remark);
            }
            if (!string.IsNullOrEmpty(bean.RefId))
            {
                sql.Append(" RefId={" + i++ + "}");
                dList.Add(bean.RefId);
            }
            if (!string.IsNullOrEmpty(bean.Refenity))
            {
                sql.Append(" Refenity={" + i++ + "}");
                dList.Add(bean.Refenity);
            }
            if (bean.CreateDT != null)
            {
                sql.Append(" CreateDT={" + i++ + "}");
                dList.Add(bean.CreateDT);
            }
            if (bean.UpdateDT != null)
            {
                sql.Append(" UpdateDT={" + i++ + "}");
                dList.Add(bean.UpdateDT);
            }
            sql.Append(" where id={" + i++ + "}");
            dList.Add(bean.Id);
            Oop.Execute(sql.ToString(), dList.ToArray());
        }

        /// <summary>
        /// 查询计划任务
        /// </summary>
        /// <param name="bean"></param>
        /// <returns></returns>
        public override DataTable Query(ScheduleJobs bean)
        {
            Log.Debug("Query方法参数：" + bean);
            var sql = new StringBuilder();
            sql.Append("select t.* from cmd_schedulejobs t where 1=1 ");
            var list = new List<object>();
            var i = -1;
            if (!string.IsNullOrEmpty(bean.Id))
            {
                sql.Append(" and Id={" + ++i + "}");
                list.Add(bean.Id);
            }
            if (!string.IsNullOrEmpty(bean.TaskName))
            {
                sql.Append(" and TaskName={" + ++i + "}");
                list.Add(bean.TaskName);
            }
            if (bean.PowerpileId != null)
            {
                sql.Append(" and PowerpileId={" + ++i + "}");
                list.Add(bean.PowerpileId);
            }
            if (!string.IsNullOrEmpty(bean.Interval))
            {
                sql.Append(" and Interval={" + ++i + "}");
                list.Add(bean.Interval);
            }
            if (!string.IsNullOrEmpty(bean.CmdType))
            {
                sql.Append(" and CmdType={" + ++i + "}");
                list.Add(bean.CmdType);
            }
            if (!string.IsNullOrEmpty(bean.TaskState))
            {
                sql.Append(" and TaskState={" + ++i + "}");
                list.Add(bean.TaskState);
            }
            if (bean.JobMonth != null)
            {
                sql.Append(" and JobMonth={" + ++i + "}");
                list.Add(bean.JobMonth);
            }
            if (bean.JobWeek != null)
            {
                sql.Append(" and JobWeek={" + ++i + "}");
                list.Add(bean.JobWeek);
            }
            if (bean.JobDay != null)
            {
                sql.Append(" and JobDay={" + ++i + "}");
                list.Add(bean.JobDay);
            }
            if (bean.JobHour != null)
            {
                sql.Append(" and JobHour={" + ++i + "}");
                list.Add(bean.JobHour);
            }
            if (bean.JobMinute != null)
            {
                sql.Append(" and JobMinute={" + ++i + "}");
                list.Add(bean.JobMinute);
            }
            if (bean.JobSecond != null)
            {
                sql.Append(" and JobSecond={" + ++i + "}");
                list.Add(bean.JobSecond);
            }
            if (bean.RunatDate != null)
            {
                sql.Append(" and RunatDate={" + ++i + "}");
                list.Add(bean.RunatDate);
            }
            if (!string.IsNullOrEmpty(bean.Remark))
            {
                sql.Append(" and Remark={" + ++i + "}");
                list.Add(bean.Remark);
            }
            if (!string.IsNullOrEmpty(bean.RefId))
            {
                sql.Append(" and RefId={" + ++i + "}");
                list.Add(bean.RefId);
            }
            if (!string.IsNullOrEmpty(bean.Refenity))
            {
                sql.Append(" and Refenity={" + ++i + "}");
                list.Add(bean.Refenity);
            }
            if (bean.CreateDT != null)
            {
                sql.Append(" and CreateDT={" + ++i + "}");
                list.Add(bean.CreateDT);
            }
            if (bean.UpdateDT != null)
            {
                sql.Append(" and UpdateDT={" + ++i + "}");
                list.Add(bean.UpdateDT);
            }
            Log.Debug("SQL :" + sql + ",params:" + list.ToString());
            return Oop.GetDataTable(sql.ToString(), list.ToArray());
        }

        public override DataTable QueryByPage(ScheduleJobs bean, int page, int rows)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 分页查询计划任务
        /// </summary>
        /// <param name="bean"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public override DataTable QueryByPage(ScheduleJobs bean, int page, int rows, ref int count)
        {
            Log.Debug("QueryByPage方法参数：" + bean);
            var getpage = new GetPage();
            var sql = new StringBuilder();
            sql.Append("select * from cmd_schedulejobs where 1=1 ");
            if (!string.IsNullOrEmpty(bean.Id))
                sql.Append(" and Id={" + bean.Id + "}");

            if (!string.IsNullOrEmpty(bean.TaskName))
                sql.Append(" and TaskName={" + bean.TaskName + "}");

            if (bean.PowerpileId != null)
                sql.Append(" and PowerpileId={" + bean.PowerpileId + "}");

            if (!string.IsNullOrEmpty(bean.Interval))
                sql.Append(" and Interval={" + bean.Interval + "}");

            if (!string.IsNullOrEmpty(bean.CmdType))
                sql.Append(" and CmdType={" + bean.CmdType + "}");

            if (!string.IsNullOrEmpty(bean.TaskState))
                sql.Append(" and TaskState={" + bean.TaskState + "}");

            if (bean.JobMonth != null)
                sql.Append(" and JobMonth={" + bean.JobMonth + "}");

            if (bean.JobWeek != null)
                sql.Append(" and JobWeek={" + bean.JobWeek + "}");

            if (bean.JobDay != null)
                sql.Append(" and JobDay={" + bean.JobDay + "}");

            if (bean.JobHour != null)
                sql.Append(" and JobHour={" + bean.JobHour + "}");

            if (bean.JobMinute != null)
                sql.Append(" and JobMinute={" + bean.JobMinute + "}");

            if (bean.JobSecond != null)
                sql.Append(" and JobSecond={" + bean.JobSecond + "}");

            if (bean.RunatDate != null)
                sql.Append(" and RunatDate={" + bean.RunatDate + "}");

            if (!string.IsNullOrEmpty(bean.Remark))
                sql.Append(" and Remark={" + bean.Remark + "}");

            if (!string.IsNullOrEmpty(bean.RefId))
                sql.Append(" and RefId={" + bean.RefId + "}");

            if (!string.IsNullOrEmpty(bean.Refenity))
                sql.Append(" and Refenity={" + bean.Refenity + "}");

            if (bean.CreateDT != null)
                sql.Append(" and CreateDT={" + bean.CreateDT + "}");

            if (bean.UpdateDT != null)
                sql.Append(" and UpdateDT={" + bean.UpdateDT + "}");
            Log.Debug("SQL :" + sql);
            return getpage.GetPageByProcedure(page, rows, sql.ToString(), ref count);
        }

        /// <summary>
        /// 结合码表统计计划任务
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="count"></param>
        /// <param name="cmdtype"></param>
        /// <returns></returns>
        public DataTable FindBy(int page, int rows, ref int count, string cmdtype)
        {
            Log.Debug("FindBy方法参数：任务类型" + cmdtype);
            var getpage = new GetPage();
            var sql = new StringBuilder();
            sql.Append("select csj.id,csj.taskname,to_char(csj.runatdate,'yyyy-mm-dd HH24:mi:ss') runatdate,csj.remark,");
            sql.Append("(select codename from sys_code sc where csj.taskstate=sc.code and sc.parentid in('CD2F3398-3EC7-401C-BF49-A706AE4529D8')) taskstate ");
            sql.Append("from cmd_schedulejobs csj  ");
            sql.Append("where csj.cmdtype='" + cmdtype + "' ");
            sql.Append("order by runatdate desc");
            return getpage.GetPageByProcedure(rows, page, sql.ToString(), ref count);
        }

        /// <summary>
        /// 结合多个表统计充电桩信息
        /// </summary>
        /// <param name="csid">充电桩id</param>
        /// <returns></returns>
        public DataTable FindBy(int csid)
        {
            Log.Debug("FindBy方法参数：站id" + csid);
            var sql = new StringBuilder();
            sql.Append("select dcp.DEV_CHARGPILE zid,dcp.yunxing_bh yxid,dcp.yunxing_bh yxid,dcp.zhuangtai, dtu.dtuname, ");
            sql.Append("(select dpt.changjia from dev_powerpiletypes dpt where dpt.parserkey=dcp.piletypeid) cj, ");
            sql.Append("(select dpt.zhuanglei_x from dev_powerpiletypes dpt where dpt.parserkey=dcp.piletypeid) zlx, ");
            sql.Append("(select dpt.zhuangxing_h from dev_powerpiletypes dpt where dpt.parserkey=dcp.piletypeid) zxh ");
            sql.Append("from dev_chargpile dcp  ");
            sql.Append("inner join dev_branch db on dcp.box_id=db.branchno ");
            sql.Append("inner join dev_chargstation dcs on dcs.zhan_bh=db.zhuan_bh  ");
            sql.Append("join dev_dtu dtu on dtu.id=dcp.dtu_id  ");
            sql.Append("where dcs.zhan_bh='" + csid + "' ");
            sql.Append("order by dtu.dtuname,dcp.dev_chargpile");
            return Oop.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 结合多个表统计充电桩信息
        /// </summary>
        /// <param name="taskid"></param>
        /// <returns></returns>
        public DataTable FindByDetail(string taskid)
        {
            Log.Debug("FindBy方法参数：任务id" + taskid);
            var sql = new StringBuilder();
            sql.Append("select dcp.DEV_CHARGPILE zid,dcp.yunxing_bh yxid, ");
            sql.Append("(select dpt.changjia from dev_powerpiletypes dpt where dpt.parserkey=dcp.piletypeid) cj, ");
            sql.Append("(select dpt.zhuanglei_x from dev_powerpiletypes dpt where dpt.parserkey=dcp.piletypeid) zlx, ");
            sql.Append("(select dpt.zhuangxing_h from dev_powerpiletypes dpt where dpt.parserkey=dcp.piletypeid) zxh, ");
            sql.Append("csl.begindt rundt, ");
            sql.Append("(select codename from sys_code sc where sc.code=csl.result) result ");
            sql.Append("from dev_chargpile dcp  ");
            sql.Append("inner join dev_branch db on dcp.box_id=db.branchno ");
            sql.Append("inner join dev_chargstation dcs on dcs.zhan_bh=db.zhuan_bh  ");

            sql.Append("inner join cmd_jobsdetails cjt on cjt.powerpileid=dcp.dev_chargpile  ");
            sql.Append("left join cmd_schedulelog csl on csl.detailid=cjt.id  ");

            sql.Append("where cjt.taskid='" + taskid + "' ");
            sql.Append("order by zid");
            return Oop.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 统计计划任务里的桩数量
        /// </summary>
        /// <param name="taskid"></param>
        /// <returns></returns>
        public DataTable FindBySumCount(string taskid)
        {
            Log.Debug("FindBy方法参数：任务id" + taskid);
            var sql = new StringBuilder();
            sql.Append("select count(*) count ");
            sql.Append("from cmd_schedulejobs csj   ");
            sql.Append("inner join cmd_jobsdetails cjt on csj.id=cjt.taskid ");

            sql.Append("where csj.id='" + taskid + "'");
            return Oop.GetDataTable(sql.ToString());
        }


        /// <summary>
        /// 统计成功执行的桩数量
        /// </summary>
        /// <param name="taskid"></param>
        /// <returns></returns>
        public DataTable FindBySuccessCount(string taskid)
        {
            Log.Debug("FindBy方法参数：任务id" + taskid);
            var sql = new StringBuilder();
            sql.Append("select count(*) count ");
            sql.Append("from cmd_jobsdetails cjd inner join cmd_schedulelog csl   ");
            sql.Append("on csl.detailid=cjd.id ");

            sql.Append("where cjd.taskid='" + taskid + "' and csl.result='Success'");
            return Oop.GetDataTable(sql.ToString());
        }
    }
}

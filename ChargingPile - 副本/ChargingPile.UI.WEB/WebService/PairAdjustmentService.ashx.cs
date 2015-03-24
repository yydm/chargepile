using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ChargingPile.BLL;
using ChargingPile.Model;
using ChargingPile.UI.WEB.Common;
using System.Web.SessionState;
using log4net;

namespace ChargingPile.UI.WEB.WebService
{
    /// <summary>
    /// Summary description for PairAdjustmentService
    /// </summary>
    public class PairAdjustmentService : IHttpHandler,IRequiresSessionState
    {

        protected ILog Log = LogManager.GetLogger("PairAdjustmentService");
        readonly OprLogBll _oprLogBll = new OprLogBll();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            var action = context.Request.Params["action"];
            var str = string.Empty;
            switch (action)
            {
                case "inittable":
                    str = InitTable(context);
                    break;
                case "getchargpilepair":
                    str = GetChargPilePair(context);
                    break;
                case "getChargStation":
                    str = GetChargStation(context);
                    break;
                case "saveScheduleJobs":
                    str = SaveScheduleJobs(context);
                    break;
                case "getschedultdetail":
                    str = GetScheduleDetail(context);
                    break;
            }

            context.Response.Write(str);
        }

        public string GetScheduleDetail(HttpContext context)
        {
            var scheduledetailbll = new ScheduleJobsBll();
            var taskid = context.Request.Params["taskid"];
            string str;
            var count = 0;
            try
            {
                var dt = scheduledetailbll.FindByDetail(taskid);
                str = ConvertToJson.DataTableToJson("rows", dt);
                str = str.Substring(1, str.Length - 2);
                str = "{\"total\":\"" + count + "\"," + str + "}";
            }
            catch (Exception e)
            {
                Log.Error(e);
                throw;
            }
            return str;
        }

        public string SaveScheduleJobs(HttpContext context)
        {
            var schedulelogbll = new ScheduleLogBll();
            var schedulejobbll = new ScheduleJobsBll();
            var jobsdetailsbll = new JobsDetailsBll();
            var taskid = Guid.NewGuid().ToString();
            var cdzmc = context.Request.Params["cdzmc"];
            var zid = context.Request.Params["zid"].Split('|');
            var runtime = context.Request.Params["runtime"];
            var sort = context.Request.Params["sort"];
            try
            {
                //单次执行
                var schedulejobs = new ScheduleJobs();
                if (sort == "once")
                {
                    schedulejobs.Id = taskid;
                    schedulejobs.TaskName = "充电站:" + cdzmc + " 桩数量:" + zid.Length + "";
                    schedulejobs.TaskState = "UnExecute";
                    schedulejobs.Interval = "RunAT";
                    schedulejobs.RunatDate = DateTime.Parse(runtime);
                    schedulejobs.CmdType = "AdjustDate";
                    schedulejobs.CreateDT = DateTime.Now;
                    schedulejobs.Remark = "单次执行（执行时间" + runtime + ")";
                }
                //每天执行
                else if (sort == "day")
                {
                    schedulejobs.Id = taskid;
                    schedulejobs.TaskName = "充电站:" + cdzmc + " 桩数量:" + zid.Length + "";
                    schedulejobs.TaskState = "UnExecute";
                    schedulejobs.Interval = "Repeat";
                    schedulejobs.JobHour=decimal.Parse(DateTime.Parse(runtime).ToString("HH"));
                    schedulejobs.JobMinute=decimal.Parse(DateTime.Parse(runtime).ToString("mm"));
                    schedulejobs.JobSecond = decimal.Parse(DateTime.Parse(runtime).ToString("ss"));
                    schedulejobs.CmdType = "AdjustDate";
                    schedulejobs.CreateDT = DateTime.Now;
                    schedulejobs.Remark = "循环执行（每天" + runtime + "循环执行)";
                }
                schedulejobbll.Add(schedulejobs);
                foreach (var s in zid)
                {
                    var jobsdetail = new JobsDetails
                    {
                        Id = Guid.NewGuid().ToString(),
                        PowerpileId = decimal.Parse(s),
                        TaskId = taskid,
                        CreateDT = DateTime.Now
                    };
                    jobsdetailsbll.Add(jobsdetail);
                    //操作日志
                    if (null == context.Session[Constant.LoginUser])
                    {
                        return "2";
                    }
                    var oprlog = new OprLog
                    {
                        Operator = ((Employer)(context.Session[Constant.LoginUser])).Name,
                        OperResult = "成功",
                        OprSrc = "添加计划任务",
                        LogDate = DateTime.Now
                    };
                    _oprLogBll.Add(oprlog);

                }
            }
            catch (Exception e)
            {
                Log.Error(e);
                throw;
            }
           
            return "true";
        }

        public string GetChargStation(HttpContext context)
        {
            var chargstationbll = new ChargStationBll();
            var chargstation = new ChargStation();
            string str;
            var count = 0;
            try
            {
                var dt = chargstationbll.Query(chargstation);
                str = ConvertToJson.DataTableToJson("rows", dt);
                str += "|";
            }
            catch (Exception e)
            {
                Log.Error(e);
                throw;
            }
            return str;
        }

        public string GetChargPilePair(HttpContext context)
        {
            var schedulejobsbll = new ScheduleJobsBll();
            var csid = context.Request.Params["csid"];
            if (string.IsNullOrEmpty(csid))
            {
                return "{\"total\":0,\"rows\":[]}";
            }
            string str;
            var count = 0;
            try
            {
                var icsid = int.Parse(csid);
                var dt = schedulejobsbll.FindBy(icsid);
                str = ConvertToJson.DataTableToJson("rows", dt);
                str = str.Substring(1, str.Length - 2);
                str = "{\"total\":\"" + count + "\"," + str + "}";
            }
            catch (Exception e)
            {
                Log.Error(e);
                throw;
            }
            return str;
        }

        public string InitTable(HttpContext context)
        {
            var schedulejobsbll = new ScheduleJobsBll();
            string str;
            var page = context.Request.Params["page"];
            var rows = context.Request.Params["rows"];
            var cmdtype = context.Request.Params["cmdtype"];
            var pageIndex = 0;
            var size = 0;
            var count = 0;
            var result = "0";
            if (!string.IsNullOrEmpty(page))
                pageIndex = int.Parse(page);

            if (!string.IsNullOrEmpty(rows))
                size = int.Parse(rows);
            try
            {
                var dt = schedulejobsbll.FindBy(pageIndex, size, ref count, cmdtype);
                //TODO:
                dt.Columns.Add("rate", Type.GetType("System.String"));
                foreach (DataRow dr in dt.Rows)
                {
                    var sumcount = schedulejobsbll.FindBySumCount(dr["ID"].ToString());
                    var successcount = schedulejobsbll.FindBySuccessCount(dr["ID"].ToString());
                    if (successcount != 0)
                    {
                        double rate = successcount / (float)sumcount;
                        rate = rate * 100;
                        result = String.Format("{0:N2}", rate);
                    }
                    dr["rate"] = result;
                    result = "0";
                }
                str = ConvertToJson.DataTableToJson("rows", dt);
                str = str.Substring(1, str.Length - 2);
                str = "{\"total\":\"" + count + "\"," + str + "}";
            }
            catch (Exception e)
            {
                Log.Error(e);
                throw;
            }
            return str;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
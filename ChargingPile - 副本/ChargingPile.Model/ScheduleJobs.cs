using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChargingPile.Model
{
    /// <summary>
    /// 类CMD_SCHEDULEJOBS。
    /// </summary>
    [Serializable]
    public class ScheduleJobs
    {
        /// <summary>
        /// 唯一Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 任务名
        /// </summary>
        public string TaskName { get; set; }

        /// <summary>
        /// 目标充电桩
        /// </summary>
        public decimal? PowerpileId { get; set; }

        /// <summary>
        /// 执行频率
        /// </summary>
        public string Interval { get; set; }

        /// <summary>
        /// 任务类型
        /// </summary>
        public string CmdType { get; set; }

        /// <summary>
        /// 任务状态
        /// </summary>
        public string TaskState { get; set; }

        /// <summary>
        /// 月
        /// </summary>
        public decimal? JobMonth { get; set; }

        /// <summary>
        /// 周
        /// </summary>
        public decimal? JobWeek { get; set; }

        /// <summary>
        /// 日
        /// </summary>
        public decimal? JobDay { get; set; }

        /// <summary>
        /// 小时
        /// </summary>
        public decimal? JobHour { get; set; }

        /// <summary>
        /// 分钟
        /// </summary>
        public decimal? JobMinute { get; set; }

        /// <summary>
        /// 秒
        /// </summary>
        public decimal? JobSecond { get; set; }

        /// <summary>
        /// 指定运行日期
        /// </summary>
        public DateTime? RunatDate { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 引用Id
        /// </summary>
        public string RefId { get; set; }

        /// <summary>
        /// 引用实体
        /// </summary>
        public string Refenity { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateDT { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateDT { get; set; }


        public override string ToString()
        {
            return "Id:" + this.Id + ",TaskName:" + this.TaskName +
                ",PowerpileId:" + this.PowerpileId + ",Interval:" + this.Interval +
                ",CmdType:" + this.CmdType +
                ",TaskState:" + this.TaskState +
                ",JobMonth:" + this.JobMonth +
                ",JobWeek:" + this.JobWeek +
                ",JobDay:" + this.JobDay +
                ",JobHour:" + this.JobHour +
                ",JobMinute:" + this.JobMinute +
                ",JobSecond:" + this.JobSecond +
                ",RunatDate:" + this.RunatDate +
                ",Remark:" + this.Remark +
                ",RefId:" + this.RefId +
                ",Refenity:" + this.Refenity +
                ",CreateDT:" + this.CreateDT +
                ",UpdateDT:" + this.UpdateDT;
        }
    }
}

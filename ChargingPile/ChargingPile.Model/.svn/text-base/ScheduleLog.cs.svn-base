using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChargingPile.Model
{
    /// <summary>
	/// 类CMD_SCHEDULELOG。
	/// </summary>
	[Serializable]
	public class ScheduleLog
    {
        /// <summary>
        /// 唯一Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 计划任务Id
        /// </summary>
        public string TaskId { get; set; }

        /// <summary>
        /// 开始执行时间
        /// </summary>
        public DateTime? BeginDT { get; set; }

        /// <summary>
        /// 执行结果
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 执行结束时间
        /// </summary>
        public DateTime? EndDT { get; set; }

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
            return "Id:" + this.Id + ",TaskId:" + this.TaskId +
                ",BeginDT:" + this.BeginDT + ",Result:" + this.Result +
                ",Remark:" + this.Remark +
                ",EndDT:" + this.EndDT +
                ",CreateDT:" + this.CreateDT +
                ",UpdateDT:" + this.UpdateDT;
        }
    }
}

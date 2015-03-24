using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChargingPile.Model
{
    /// <summary>
    /// 计划任务明细表
    /// </summary>
    [Serializable]
    public class JobsDetails
    {
        /// <summary>
        /// 唯一Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 3位充电站+2位分支箱+序号(3)
        /// </summary>
        public decimal? PowerpileId { get; set; }

        /// <summary>
        /// 唯一Id
        /// </summary>
        public string TaskId { get; set; }

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
            return "Id:" + this.Id + ",PowerpileId:" + this.PowerpileId +
                ",TaskId:" + this.TaskId + ",CreateDT:" + this.CreateDT +
                ",UpdateDT:" + this.UpdateDT;
        }
    }
}

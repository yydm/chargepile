using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChargingPile.Model
{
    /// <summary>
    /// 操作日志
    /// </summary>
    [Serializable]
    public class OprLog
    {
        /// <summary>
        /// 唯一Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 数据项编码
        /// </summary>
        public string DataItemId { get; set; }

        /// <summary>
        /// 目标设备
        /// </summary>
        public decimal? TargetDev { get; set; }

        /// <summary>
        /// 操作员
        /// </summary>
        public string Operator { get; set; }

        public string Worknum { get; set; }

        /// <summary>
        /// 记录时间
        /// </summary>
        public DateTime? LogDate { get; set; }

        /// <summary>
        /// 操作结果
        /// </summary>
        public string OperResult { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? Createdt { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? Updatedt { get; set; }

        /// <summary>
        /// 操作来源
        /// </summary>
        public string OprSrc { get; set; }

        /// <summary>
        /// 操作目标
        /// </summary>
        public string OprDest { get; set; }
    }
}

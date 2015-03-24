using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChargingPile.Model.ChargePile
{
    /// <summary>
    /// 异常告警参数2
    /// </summary>
    public class TelesignallingParam2 : ChargingInfoParam
    {
        /// <summary>
        /// 告警id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 发生时间
        /// </summary>
        public string OccurDt { get; set; }

        /// <summary>
        /// 项名称
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// 处理标志
        /// </summary>
        public decimal? ProcessFlag { get; set; }

        /// <summary>
        /// 异常描述
        /// </summary>
        public string LogDesc { get; set; }

        /// <summary>
        /// 桩编号
        /// </summary>
        public string TargetDev { get; set; }
    }
}

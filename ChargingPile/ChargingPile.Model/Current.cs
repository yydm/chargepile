using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChargingPile.Model
{
    public class Current
    {
        /// <summary>
        /// 初始化构造函数
        /// </summary>
        public Current()
        {
            CurrentPointer = 180;
            CurrentEffectiveMin = 0;
            CurrentEffectiveMax = 25;
            CurrentThresholdMin = 0;
            CurrentThresholdMax = 50;
            CurrentTime = null;

        }
        /// <summary>
        /// 采集项标识
        /// </summary>
        public string ItemNo { get; set; }

        /// <summary>
        /// 电流指针值
        /// </summary>
        public decimal? CurrentPointer { get; set; }

        /// <summary>
        /// 电流有效最大值
        /// </summary>
        public decimal? CurrentEffectiveMax { get; set; }

        /// <summary>
        /// 电流有效最小值
        /// </summary>
        public decimal? CurrentEffectiveMin { get; set; }

        /// <summary>
        /// 电流阈值最大值
        /// </summary>
        public decimal? CurrentThresholdMax { get; set; }

        /// <summary>
        /// 电流阈值最小值
        /// </summary>
        public decimal? CurrentThresholdMin { get; set; }

        /// <summary>
        /// 电流表采集时间
        /// </summary>
        public string CurrentTime { get; set; }

    }
}

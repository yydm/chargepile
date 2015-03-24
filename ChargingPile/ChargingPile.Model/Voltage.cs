using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChargingPile.Model
{
    public class Voltage
    {
        /// <summary>
        /// 初始化构造函数
        /// </summary>
        public Voltage()
        {
            VoltagePointer = 580;
            VoltageEffectiveMin = 0;
            VoltageEffectiveMax = 150;
            VoltageThresholdMin = 0;
            VoltageThresholdMax = 300;
            VoltageTime = null;
        }

        /// <summary>
        /// 采集项标识
        /// </summary>
        public string ItemNo { get; set; }

        //电压指针值
        public decimal? VoltagePointer { get; set; }

        //电压有效最大值
        public decimal? VoltageEffectiveMax { get; set; }

        //电压有效最小值
        public decimal? VoltageEffectiveMin { get; set; }

        //电压阈值最大值
        public decimal? VoltageThresholdMax { get; set; }

        //电压阈值最小值
        public decimal? VoltageThresholdMin { get; set; }

        /// <summary>
        /// 电压时间
        /// </summary>
        public string VoltageTime { get; set; }
    }
}

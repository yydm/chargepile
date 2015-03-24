using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChargingPile.Model.ChargePile
{
    /// <summary>
    /// 充电信息参数
    /// </summary>
    public class ChargingInfoParam
    {
        /// <summary>
        /// 站简称
        /// </summary>
        public string ZhanJc { get; set; }

        /// <summary>
        /// 运行编号
        /// </summary>
        public string YunXingBh { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        public string DateTime { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// 充电电量
        /// </summary>
        public decimal ChargePower { get; set; }

        /// <summary>
        /// 充电金额
        /// </summary>
        public decimal ChargeMoney { get; set; }
        
        /// <summary>
        /// 充电卡号
        /// </summary>
        public string CardNo { get; set; }

        /// <summary>
        /// 充电时长
        /// </summary>
        public string ChargeTime { get; set; }


        /// <summary>
        /// 目标设备
        /// </summary>
        public decimal TargetDev2 { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateDtPara { get; set; }

    }
}

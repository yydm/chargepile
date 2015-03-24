using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChargingPile.Model
{
    /// <summary>
    /// 充电桩实时状态
    /// 待机  1 充电  2 充满  3 离线  4 异常  5
    /// </summary>
    [Serializable]
    public class ChargePileStates : BaseModel<ChargePileStates>
    {
        /// <summary>
        /// 充电站编号
        /// </summary>
        public decimal PowerPileNo { get; set; }

        /// <summary>
        /// 充电桩状态
        /// </summary>
        public decimal? PowerPileStatus { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateDt { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateDt { get; set; }


        public override string ToString()
        {
            return "PowerPileNo:'" + PowerPileNo
                + "',PowerPileStatus:'" + PowerPileStatus
                + "',CreateDT:'" + CreateDt +
               "',UpdateDT:'" + UpdateDt + "'";
        }
    }
}

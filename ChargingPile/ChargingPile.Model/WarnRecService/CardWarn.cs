using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChargingPile.Model.WarnRecService
{
    public class CardWarn :TelesignallingWarn
    {
        /// <summary>
        /// 卡号
        /// </summary>
        public string TargetDataKey { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChargingPile.BLL
{
    public class ZwMessage<T>
    {
        // 数据总数
        public int? Total { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Rows { get; set; }
    }
}

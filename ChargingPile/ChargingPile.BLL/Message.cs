using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChargingPile.BLL
{
    public class Message<T>
    {
        // 数据总数
        public int? Total { get; set; }

        // 关键数据
        public List<T> Rows { get; set; }
    }
}

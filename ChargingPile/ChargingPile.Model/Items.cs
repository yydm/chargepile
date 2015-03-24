using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChargingPile.Model
{
    /// <summary>
    /// 接口项集合参数
    /// </summary>
   public class Items
    {
       /// <summary>
       /// 数据项id
       /// </summary>
       public string DataItemId { get; set; }

       /// <summary>
       /// 数据项值
       /// </summary>
       public decimal? Value { get; set; }

       /// <summary>
       /// 此id判断是否存在warnrec表里，存在就告警
       /// </summary>
       public string DataGatherId { get; set; }

       /// <summary>
       /// 质量
       /// </summary>
       public string Quality { get; set; }


       public string GatDt { get; set; }
    }
}

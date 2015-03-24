using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChargingPile.Model
{
    public class GatItem:BaseModel<GatItem>
    {
        /// <summary>
        /// 采集项标识
        /// </summary>
        public string ITEMNO { get; set; }

        /// <summary>
        /// 采集项名称
        /// </summary>
        public string ITEMNAME { get; set; }

        /// <summary>
        /// 采集项描述
        /// </summary>
        public string ITEMDESC { get; set; }

        /// <summary>
        /// 关联主体
        /// </summary>
        public string REFCONTEXT { get; set; }
        
        /// <summary>
        /// 计量单位
        /// </summary>
        public string M_UNITS { get; set; }

        /// <summary>
        /// 数据类型
        /// </summary>
        public string DATATYPE { get; set; }

        /// <summary>
        /// 测量值类型
        /// </summary>
        public string VALUETYPE { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CREATEDT { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UPDATEDT { get; set; }

        /// <summary>
        /// 标记
        /// </summary>
        public decimal? NOTE { get; set; }

        public override string ToString()
        {
            return "ITEMNO:" + ITEMNO + ",ITEMNAME:" + ITEMNAME + ",ITEMDESC:" + ITEMDESC
                   + ",REFCONTEXT:" + REFCONTEXT + ",M_UNITS:" + M_UNITS + ",DATATYPE:" + DATATYPE
                   + ",VALUETYPE:" + VALUETYPE + ",CREATEDT:" + CREATEDT + ",UPDATEDT:" + UPDATEDT
                   + ",NOTE:" + NOTE;
        }
    }
}

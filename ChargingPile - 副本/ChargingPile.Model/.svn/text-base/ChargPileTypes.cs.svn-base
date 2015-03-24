using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChargingPile.Model
{
    public class ChargPileTypes :BaseModel<ChargPileTypes>
    {
        /// <summary>
        /// 协议标识编码
        /// </summary>
        public string PARSERKEY { get; set; }

        /// <summary>
        /// 厂家
        /// </summary>
        public string CHANGJIA { get; set; }

        /// <summary>
        /// 桩类型
        /// </summary>
        public string ZHUANGLEI_X { get; set; }

        /// <summary>
        /// 设备型号
        /// </summary>
        public string ZHUANGXING_H { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string REMARK { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CREATEDT { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UPDATEDT { get; set; }

        /// <summary>
        /// 每种充电桩总数
        /// </summary>
        public decimal? COUNTS { get; set; }

        /// <summary>
        /// 充电桩类别序号
        /// </summary>
        public decimal? XH { get; set; }

        public override string ToString()
        {
            return "PARSERKEY:" + PARSERKEY + ",CHANGJIA:" + CHANGJIA + ",ZHUANGLEI_X:" + ZHUANGLEI_X + ",ZHUANGXING_H:" +
                   ZHUANGXING_H + ",REMARK:" + REMARK + ",CREATEDT:" + CREATEDT + ",UPDATEDT:" + UPDATEDT + ",COUNTS:" +
                   COUNTS + ",XH:" + XH;
        }
    }
}

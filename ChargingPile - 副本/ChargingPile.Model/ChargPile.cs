using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChargingPile.Model
{
    public class ChargPile
    {
        /// <summary>
        /// 充电桩编号
        /// </summary>
        public decimal? DEV_CHARGPILE { get; set; }

        /// <summary>
        /// 充电桩名称
        /// </summary>
        public string POWERPILENAME { get; set; }

        /// <summary>
        /// 分支箱ID
        /// </summary>
        public decimal? BOX_ID { get; set; }

        /// <summary>
        /// 传输单元ID
        /// </summary>
        public string DTU_ID { get; set; }

        /// <summary>
        /// 充电桩类型ID
        /// </summary>
        public string PILETYPEID { get; set; }

        /// <summary>
        /// 总线地址
        /// </summary>
        public decimal? ZONGXIAN_DZ { get; set; }

        /// <summary>
        /// 厂家编号
        /// </summary>
        public string CHANGJIAO_BH { get; set; }

        /// <summary>
        /// 运行编号
        /// </summary>
        public string YUNXING_BH { get; set; }

        /// <summary>
        /// 投运时间
        /// </summary>
        public DateTime? TOUYOU_SJ { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string ZHUANGTAI { get; set; }

        /// <summary>
        /// 资产号
        /// </summary>
        public string ZHICHAN_BH { get; set; }

        /// <summary>
        /// 运维单位
        /// </summary>
        public string YUNWEI_DW { get; set; }

        public string CHANGJIA { get; set; }
        public string ZHUANGLEI_X { get; set; }
        public string ZHUANGXING_H { get; set; }
        public decimal? NOTE { get; set; }

        /// <summary>
        /// 删除标记
        /// </summary>
        public decimal? DELETEFLAG { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CREATEDT { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UPDATEDT { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string REMARK { get; set; }




    }
}

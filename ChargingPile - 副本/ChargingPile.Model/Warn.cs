using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChargingPile.Model
{
    public class Warn
    {
        /// <summary>
        /// 唯一Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 告警方式
        /// </summary>
        public string WarnType { get; set; }

        /// <summary>
        /// 告警目标
        /// </summary>
        public string WarnTarget { get; set; }

        /// <summary>
        /// 告警内容模板
        /// </summary>
        public string WarnContext { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateDT { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateDT { get; set; }


        public override string ToString()
        {
            return "Id:" + this.Id + ",WarnType:" + this.WarnType +
                ",WarnTarget:" + this.WarnTarget + ",WarnContext:" + this.WarnContext +
                ",CreateDT:" + this.CreateDT +
                ",UpdateDT:" + this.UpdateDT;
        }
    }
}

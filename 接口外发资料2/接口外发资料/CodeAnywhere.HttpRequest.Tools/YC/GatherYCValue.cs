using System;
using Newtonsoft.Json;

namespace Headfree.PowerPile.Core.Data.YC
{
    /// <summary>
    /// 一个采集点的遥测值
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GatherYCValue
    {
        /// <summary>
        /// 采集时间
        /// </summary>
        [JsonProperty(PropertyName = "values", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime GatDt { get; set; }

        /// <summary>
        /// 采集值
        /// </summary>
        [JsonProperty(PropertyName = "value", NullValueHandling = NullValueHandling.Ignore)]
        public Decimal Value { get; set; }

        /// <summary>
        /// //数据质量
        /// </summary>
        [JsonProperty(PropertyName = "quality", NullValueHandling = NullValueHandling.Ignore)]
        public string Quality { get; set; }
    }
}
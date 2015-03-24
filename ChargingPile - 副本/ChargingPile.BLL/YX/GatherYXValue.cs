using System;
using Newtonsoft.Json;

namespace Headfree.PowerPile.Core.Data.YX
{
    /// <summary>
    /// 一个采集点的遥信值
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GatherYXValue
    {
        /// <summary>
        /// 采集时间
        /// </summary>
        [JsonProperty(PropertyName = "values", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime GatDt { get; set; }

        /// <summary>
        /// 采集值
        /// </summary>
        [JsonProperty(PropertyName = "state", NullValueHandling = NullValueHandling.Ignore)]
        public string State { get; set; }

        /// <summary>
        /// //数据质量
        /// </summary>
        [JsonProperty(PropertyName = "quality", NullValueHandling = NullValueHandling.Ignore)]
        public string Quality { get; set; }
    }
}
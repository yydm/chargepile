using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Headfree.PowerPile.Core.Data.YX
{
    /// <summary>
    /// 遥信数据结构
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class YXCanData
    {
        /// <summary>
        /// 充电桩ID
        /// </summary>
        [JsonProperty(PropertyName = "powerPileId", NullValueHandling = NullValueHandling.Ignore)]
        public String PowerPileId { get; set; }

        /// <summary>
        /// 数据项标识
        /// </summary>
        [JsonProperty(PropertyName = "dataItemId", NullValueHandling = NullValueHandling.Ignore)]
        public String DataItemId { get; set; }

        /// <summary>
        /// 遥测值
        /// </summary>
        [JsonProperty(PropertyName = "values", NullValueHandling = NullValueHandling.Ignore)]
        public IList<GatherYXValue> Values { get; set; }
    }
}
using Newtonsoft.Json;

namespace Headfree.PowerPile.Core.Data.NetStatus
{
    /// <summary>
    /// 网络状态
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class NetState
    {
        /// <summary>
        /// DtuIdId
        /// </summary>
        [JsonProperty(PropertyName = "dtuId", NullValueHandling = NullValueHandling.Ignore)]
        public string DtuId { get; set; }

        /// <summary>
        /// 网络状态
        /// </summary>
        [JsonProperty(PropertyName = "state", NullValueHandling = NullValueHandling.Ignore)]
        public string State { get; set; }

        
    }
}
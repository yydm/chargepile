using System.Collections.Generic;
using Newtonsoft.Json;

namespace Headfree.PowerPile.Core.Data.NetStatus
{
    /// <summary>
    /// 网络状态数据
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class NetSateData
    {
       

        /// <summary>
        /// 命令值
        /// </summary>
        [JsonProperty(PropertyName = "netStates", NullValueHandling = NullValueHandling.Ignore)]
        public IList<NetState> Commands { get; set; }
    }
}
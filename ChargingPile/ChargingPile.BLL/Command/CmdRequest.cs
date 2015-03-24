using System;
using Newtonsoft.Json;

namespace Headfree.PowerPile.Core.Data.Command
{
    /// <summary>
    /// 遥控请求
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class CmdRequest
    {
        /// <summary>
        /// 命令Id
        /// </summary>
        [JsonProperty(PropertyName = "cmdId", NullValueHandling = NullValueHandling.Ignore)]
        public String CmdId { get; set; }
        /// <summary>
        /// 命令任务类型
        /// </summary>
        [JsonProperty(PropertyName = "cmdType", NullValueHandling = NullValueHandling.Ignore)]
        public string CmdType { get; set; }
        /// <summary>
        /// 充电桩编号
        /// </summary>
        [JsonProperty(PropertyName = "chargPileId", NullValueHandling = NullValueHandling.Ignore)]
        public Int64 ChargPileId { get; set; }
    }
}
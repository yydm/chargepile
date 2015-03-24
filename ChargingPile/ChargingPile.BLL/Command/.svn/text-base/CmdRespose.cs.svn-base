using System;
using Newtonsoft.Json;

namespace Headfree.PowerPile.Core.Data.Command
{
    /// <summary>
     /// 命令响应
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
     public class CmdRespose
    {

        /// <summary>
        /// 命令Id
        /// </summary>
        [JsonProperty(PropertyName = "cmdId", NullValueHandling = NullValueHandling.Ignore)]
        public string CmdId { get; set; }
       
        /// <summary>
        ///   是否成功
        /// </summary>
        [JsonProperty(PropertyName = "success", NullValueHandling = NullValueHandling.Ignore)]
        public bool Success { get; set; }

        /// <summary>
        ///   响应的消息
        /// </summary>
        [JsonProperty(PropertyName = "message", NullValueHandling = NullValueHandling.Ignore)]
        public String Message { get; set; }

        
    }
}
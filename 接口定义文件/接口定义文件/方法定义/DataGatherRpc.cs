using System;
using CodeAnywhere.Json.Rpc.JsonRpcAttribute;
using Headfree.PowerPile.Core.Data.Command;
using Headfree.PowerPile.Core.Data.YC;
using Headfree.PowerPile.Core.Data.YX;

namespace Headfree.PowerPile.JsonRpc.Bussiness
{
    /// <summary>
    /// 数据采集接口
    /// </summary>
    [JsonRpcClass("DataGatherRpc", Caption = "数据采集接口")]
    public class DataGatherRpc
    {
        /// <summary>
        /// 推遥测数据到实时缓存区
        /// </summary>
        /// <param name="data">推送的数据</param>
        /// <returns></returns>
        [JsonRpcMethod("推遥测数据到实时缓存区")]
        public bool PushYCData(YCCanData data)
        {
            // todo 未实现
            return true;
        }

        /// <summary>
        /// 从实时缓存区拉遥测数据
        /// </summary>
        /// <param name="stationId">充电桩Id</param>
        /// <returns></returns>
        [JsonRpcMethod("从实时缓存区拉遥测数据")]
        public YCCanData PullYCData(String stationId)
        {
            // todo 未实现
            return null;
        }

        /// <summary>
        /// 推遥信数据到实时缓存区
        /// </summary>
        /// <param name="data">推送的数据</param>
        /// <returns></returns>
        [JsonRpcMethod("推遥信数据到实时缓存区")]
        public bool PushYXData(YXCanData data)
        {
            // todo 未实现
            return true;
        }

        /// <summary>
        /// 从实时缓存区拉遥信数据
        /// </summary>
        /// <param name="stationId">充电桩Id</param>
        /// <returns></returns>
        [JsonRpcMethod("从实时缓存区拉遥信数据")]
        public YXCanData PullYXData(String stationId)
        {
            // todo 未实现
            return null;
        }

        /// <summary>
        /// 放置控制命令到命令队列
        /// </summary>
        /// <param name="data">推送的数据</param>
        /// <returns></returns>
        [JsonRpcMethod("放置控制命令到命令队列")]
        public bool PushCommand(CmdRequest data)
        {
            // todo 未实现
            return true;
        }

        /// <summary>
        /// 查询命令响应结果
        /// </summary>
        /// <param name="CmdId">命令Id</param>
        /// <returns></returns>
        [JsonRpcMethod("查询命令响应结果")]
        public CmdRespose QueryCmdResponse(String CmdId)
        {
            // todo 未实现
            return null;
        }
        /// <summary>
        /// 将当前内存数据保存为历史数据
        /// </summary>
        /// <param name="stationId">充电桩Id</param>
        /// <returns></returns>
        [JsonRpcMethod("将当前内存数据保存为历史数据")]
        public bool DumpMemeryDataToHis(String stationId)
        {
            // todo 未实现
            return false;
        }

        
    }
}
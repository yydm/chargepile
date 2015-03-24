using System;
using CodeAnywhere.Json.Rpc;
using CodeAnywhere.Json.Rpc.Core;
using CodeAnywhere.Util;
using Headfree.PowerPile.Core.Data.Command;
using Headfree.PowerPile.Core.Data.YC;
using Headfree.PowerPile.Core.Data.YX;

namespace Headfree.PowerPile.Core.Rpc
{
    /// <summary>
    ///     对DataGatherRpc包装
    /// </summary>
    public class DataGatherRpcClient : RpcClient
    {
        private static readonly DataGatherRpcClient _instance = new DataGatherRpcClient();

        /// <summary>
        ///     当前实例
        /// </summary>
        public static DataGatherRpcClient Current
        {
            get { return _instance; }
        }

        /// <summary>
        ///     创建Rpc请求
        /// </summary>
        public override JsonRequest CreateRequest(String p_MethodName)
        {
            return new JsonRequest
                {
                    ClassType = "DataGatherRpc",
                    Scope = RequestScope.Singleton,
                    Method = p_MethodName
                };
        }

        /// <summary>
        ///     推遥测数据到实时缓存区
        /// </summary>
        /// <param name="data">推送的数据</param>
        /// <returns></returns>
        public bool PushYCData(YCCanData data)
        {
            JsonRequest req = CreateRequest("PushYCData");
            req.AddParam(data);
            JsonResponse resp = Invoke(req);
            if (!resp.Success)
            {
                throw new CodeAnywhereException(resp.Message);
            }
            return (bool) resp.Data;
        }

        /// <summary>
        ///     从实时缓存区拉遥测数据
        /// </summary>
        /// <param name="stationId">充电桩Id</param>
        /// <returns></returns>
        public YCCanData PullYCData(String stationId)
        {
            JsonRequest req = CreateRequest("PullYCData");
            req.AddParam(stationId);
            JsonResponse resp = Invoke(req);
            if (!resp.Success)
            {
                throw new CodeAnywhereException(resp.Message);
            }
            return (YCCanData) resp.Data;
        }

        /// <summary>
        ///     推遥信数据到实时缓存区
        /// </summary>
        /// <param name="data">推送的数据</param>
        /// <returns></returns>
        public bool PushYXData(YXCanData data)
        {
            // todo 未实现
            JsonRequest req = CreateRequest("PushYXData");
            req.AddParam(data);
            JsonResponse resp = Invoke(req);
            if (!resp.Success)
            {
                throw new CodeAnywhereException(resp.Message);
            }
            return (bool) resp.Data;
        }

        /// <summary>
        ///     从实时缓存区拉遥信数据
        /// </summary>
        /// <param name="stationId">充电桩Id</param>
        /// <returns></returns>
        public YXCanData PullYXData(String stationId)
        {
            // todo 未实现
            JsonRequest req = CreateRequest("PullYXData");
            req.AddParam(stationId);
            JsonResponse resp = Invoke(req);
            if (!resp.Success)
            {
                throw new CodeAnywhereException(resp.Message);
            }
            return (YXCanData) resp.Data;
        }

        /// <summary>
        ///     放置控制命令到命令队列
        /// </summary>
        /// <param name="data">推送的数据</param>
        /// <returns></returns>
        public bool PushCommand(CmdRequest data)
        {
           
            JsonRequest req = CreateRequest("PushCommand");
            req.AddParam(data);
            JsonResponse resp = Invoke(req);
            if (!resp.Success)
            {
                throw new CodeAnywhereException(resp.Message);
            }
            return (bool) resp.Data;
        }

        /// <summary>
        ///     查询命令响应结果
        /// </summary>
        /// <param name="CmdId">命令Id</param>
        /// <returns></returns>
        public CmdRespose QueryCmdResponse(String CmdId)
        {
            JsonRequest req = CreateRequest("QueryCmdResponse");
            req.AddParam(CmdId);
            JsonResponse resp = Invoke(req);
            if (!resp.Success)
            {
                throw new CodeAnywhereException(resp.Message);
            }
            return (CmdRespose) resp.Data;
        }

        /// <summary>
        ///     将当前内存数据保存为历史数据
        /// </summary>
        /// <param name="CycleType">周期类型</param>
        /// <param name="p_Interval"></param>
        /// <returns></returns>
        public bool DumpMemeryDataToHis(String CycleType, int p_Interval)
        {
            JsonRequest req = CreateRequest("DumpMemeryDataToHis");
            req.AddParam(CycleType).AddParam(p_Interval);
            JsonResponse resp = Invoke(req);
            if (!resp.Success)
            {
                throw new CodeAnywhereException(resp.Message);
            }
            return (bool) resp.Data;
        }

        /// <summary>
        ///     备份当前内存数据库
        /// </summary>
        /// <returns></returns>
        public bool BackupDataBase()
        {
            JsonRequest req = CreateRequest("BackupDataBase");
            JsonResponse resp = Invoke(req);
            if (!resp.Success)
            {
                throw new CodeAnywhereException(resp.Message);
            }
            return (bool) resp.Data;
        }


    }
}
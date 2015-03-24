using System;
using System.Collections.Generic;
using System.Data;

using CodeAnywhere.Json.Rpc;
using CodeAnywhere.Json.Rpc.Core;
using CodeAnywhere.Json.Rpc.JsonRpcAttribute;

using Headfree.PowerPile.Core.Data.Command;
using Headfree.PowerPile.Core.Data.YC;
using Headfree.PowerPile.Core.Data.YX;
using Newtonsoft.Json;

namespace Headfree.CitSystem.DataAdapt.Rpc
{
    /// <summary>
    /// 对本地JDao包装
    /// </summary>
    public class RemoteDataGatherRpcDao : RpcClient
    {
        private static readonly RemoteDataGatherRpcDao _instance = new RemoteDataGatherRpcDao();

        /// <summary>
        /// 当前实例
        /// </summary>
        public static RemoteDataGatherRpcDao Current
        {
            get { return _instance; }
        }

        /// <summary>
        /// 创建Rpc请求
        /// </summary>
        public  JsonRequest CreateRequest(String p_MethodName)
        {
            return new JsonRequest
                       {
                           ClassType = "DataGatherRpc",
                           Scope = RequestScope.Singleton,
                           Method = p_MethodName
                       };
        }

        

        /// <summary>
        /// 推遥测数据到实时缓存区
        /// </summary>
        /// <param name="data">推送的数据</param>
        /// <returns></returns>
        public bool PushYCData(YCCanData data)
        {
            JsonRequest req = CreateRequest("PushYCData");
            req.AddParam(data);
          
            JsonResponse resp = Invoke(req);
            if (resp.Success)
            {
                return Convert.ToBoolean(resp.Data);
            }
            else
            {
                //记录日志
                return false;
            }
            
        }

        /// <summary>
        /// 从实时缓存区拉遥测数据
        /// </summary>
        /// <param name="stationId">充电桩Id</param>
        /// <returns></returns>
        public YCCanData PullYCData(String stationId)
        {
            // todo 未实现
            JsonRequest req = CreateRequest("PullYCData");
            req.AddParam(stationId);

            JsonResponse resp = Invoke(req);
            if (resp.Success)
            {
                return resp.Data as YCCanData;
            }
            else
            {
                //记录日志
                return null;
            }
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
            JsonRequest req = CreateRequest("PullYCData");
            req.AddParam(data);

            JsonResponse resp = Invoke(req);
            if (resp.Success)
            {
                return Convert.ToBoolean(resp.Data);
            }
            else
            {
                //记录日志
                return false;
            }
        }

        /// <summary>
        /// 从实时缓存区拉遥信数据
        /// </summary>
        /// <param name="stationId">充电桩Id</param>
        /// <returns></returns>
       
        public YXCanData PullYXData(String stationId)
        {
            // todo 未实现
            JsonRequest req = CreateRequest("PullYCData");
            req.AddParam(stationId);

            JsonResponse resp = Invoke(req);
            if (resp.Success)
            {
                return resp.Data as YXCanData;
            }
            else
            {
                //记录日志
                return null;
            }
        }

        /// <summary>
        /// 放置控制命令到命令队列
        /// </summary>
        /// <param name="data">推送的数据</param>
        /// <returns></returns>
        public bool PushCommand(CmdRequest data)
        {
            // todo 未实现
            JsonRequest req = CreateRequest("PushCommand");
            req.AddParam(data);

            JsonResponse resp = Invoke(req);
            if (resp.Success)
            {
                return Convert.ToBoolean(resp.Data);
            }
            else
            {
                //记录日志
                return false;
            }
        }

        /// <summary>
        /// 查询命令响应结果
        /// </summary>
        /// <param name="CmdId">命令Id</param>
        /// <returns></returns>
       
        public CmdRespose QueryCmdResponse(String CmdId)
        {
            // todo 未实现
            JsonRequest req = CreateRequest("QueryCmdResponse");
            req.AddParam(CmdId);

            JsonResponse resp = Invoke(req);
            if (resp.Success)
            {
                return  resp.Data as CmdRespose;
            }
            else
            {
                //记录日志
                return null;
            }
        }
        /// <summary>
        /// 将当前内存数据保存为历史数据
        /// </summary>
        /// <param name="stationId">充电桩Id</param>
        /// <returns></returns>
       
        public bool DumpMemeryDataToHis(String stationId)
        {
            // todo 未实现
            // todo 未实现
            JsonRequest req = CreateRequest("DumpMemeryDataToHis");
            req.AddParam(stationId);

            JsonResponse resp = Invoke(req);
            if (resp.Success)
            {
                return  Convert.ToBoolean(resp.Data);
            }
            else
            {
                //记录日志
                return false;
            }
        }
    }
}
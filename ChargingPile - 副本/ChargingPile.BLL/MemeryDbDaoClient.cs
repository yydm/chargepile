using System;
using System.Collections.Generic;
using System.Data;
using CodeAnywhere.Framework.DataLayer;
using CodeAnywhere.Framework.DataLayer.MetaCache;
using CodeAnywhere.Json.Rpc;
using CodeAnywhere.Json.Rpc.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Headfree.PowerPile.Core.Rpc
{
    /// <summary>
    ///     对JDao包装
    /// </summary>
    public  class MemeryDbDaoClient : RpcClient
    {
        //private static readonly MemeryDbDaoClient _instance = new MemeryDbDaoClient();

        /// <summary>
        ///     当前实例
        /// </summary>
        //public static MemeryDbDaoClient Current
        //{
        //    get { return _instance; }
        //}

        /// <summary>
        ///     创建Rpc请求
        /// </summary>
        public override JsonRequest CreateRequest(String p_MethodName)
        {
            return new JsonRequest
            {
                ClassType = "MemeryDbDao",
                Scope = RequestScope.Singleton,
                Method = p_MethodName
            };
        }

        /// <summary>
        ///     执行带有参数的查询语句
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="dicParams"></param>
        /// <returns></returns>
        public DataTable QueryDt(string strSql, IDictionary<String, object> dicParams)
        {
            JsonRequest req = CreateRequest("OrgQueryDt");
            req.AddParam(strSql);
            req.AddParam(dicParams ?? new Dictionary<String, object>());
            JsonResponse resp = Invoke(req);
            if (resp.Success)
            {
                return JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(resp.Data),new NullableDataTableConverter());
            }
            else
            {
                //记录日志
                return new DataTable();
            }
        }
        public jPageResponse GetPages(String pSql,int page, int rows, string sort="",string order="")
        {
            JsonRequest req = CreateRequest("GetPages");
            req.AddParam(pSql).AddParam(order).AddParam(page).AddParam(rows).AddParam(sort);
            JsonResponse resp = Invoke(req);
            if (resp.Success)
            {
                var rtn= JsonConvert.DeserializeObject<jPageResponse>(JsonConvert.SerializeObject(resp.Data));
                if (rtn.Rows != null)
                {
                    rtn.Rows = JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(rtn.Rows), new NullableDataTableConverter());
                }
                else
                {
                    rtn.Rows = new DataTable();
                }
                return rtn; 
            }
            else
            {
                //记录日志
                return new jPageResponse();
            }
        }

        /// <summary>
        ///     执行带有参数的查询语句
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public DataTable QueryDt(string strSql)
        {
            return QueryDt(strSql, null);
        }
        /// <summary>
        /// 返回查询一页数据
        /// </summary>


    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using CodeAnywhere.Json.Rpc;
using CodeAnywhere.Json.Rpc.Core;
using Headfree.CitSystem.DataAdapt.Rpc;
using Headfree.PowerPile.Core.Data.Command;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
namespace ChargingPile.UI.WEB.pages.RemoteControl
{
    public partial class StartStopManage : System.Web.UI.Page
    {
        static readonly string Url = ConfigurationSettings.AppSettings["url"];

        protected static log4net.ILog Log = log4net.LogManager.GetLogger("dal");
        /// <summary>
        /// 设置JsonSerializerSettings
        /// </summary>
        /// <returns></returns>
        public static JsonSerializerSettings InitSetting()
        {
            var setting = new JsonSerializerSettings
            {
                DefaultValueHandling = DefaultValueHandling.Ignore
            };
            var timeConverter = new IsoDateTimeConverter
            {
                DateTimeFormat = "yyyy-MM-dd HH:mm:ss.fff"
            };
            setting.Converters.Add(timeConverter);
            return setting;
        }

        /// <summary>
        /// 构造json请求
        /// </summary>
        /// <param name="chargpileid"></param>
        /// <param name="cmdid"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static JsonRequest SetJsonRequset(long chargpileid, string cmdid, string type)
        {
            var _type = type.Equals(CmdTaskType.Start.ToString()) ? CmdTaskType.Start.ToString() : CmdTaskType.Stop.ToString();
            var request = new JsonRequest()
            {
                ClassType = "DataGatherRpc",
                Scope = RequestScope.Singleton,
                Method = "PushCommand"
            };

            var cmdreq = new CmdRequest()
            {
                ChargPileId = chargpileid,
                CmdType = _type,
                CmdId = cmdid
            };

            request.AddParam(cmdreq);
            return request;
        }

        // 判断指令是否发送成功,success｜faile
        public static object[,] SendCommand(JsonSerializerSettings setting, RpcClient c, string[] chargpileidarrary, string type)
        {
            var objects = new object[chargpileidarrary.Length, 3];
            //var jsonResponseDic = new Dictionary<string, object>();
            for (var index = 0; index < chargpileidarrary.Length; index++)
            {
                var t = chargpileidarrary[index];
                var cmdid = Guid.NewGuid().ToString();
                var request = SetJsonRequset(long.Parse(t), cmdid, type);
                var json =
                    JsonConvert.DeserializeObject<JsonRequest>(
                    JsonConvert.SerializeObject(request, Formatting.Indented, setting));

                var response = c.Invoke(json);
                //jsonResponseDic.Add(t, response);
                objects[index, 0] = cmdid;
                objects[index, 1] = t;
                objects[index, 2] = response;
            }

            return objects;
        }

        // 指令操作设备是否成功,success｜faile
        public static string QueryCommand(object[,] objects)
        {
            var strjson = string.Empty;
            var sb = new StringBuilder();
            for (var i = 0; i < objects.GetLength(0); i++)
            {
                //var data = ((JsonResponse)(str.Value)).Data;
                var success = ((JsonResponse)(objects[i, 2])).Success;
                var message = ((JsonResponse)(objects[i, 2])).Message;

                if (success)
                {
                    var result = RemoteDataGatherRpcDao.Current.QueryCmdResponse(objects[i, 0].ToString());
                    if (result.Success)
                        strjson += "{\"ZID\":\"" + objects[i, 1] + "\",\"SUCCESS\":\"成功\",\"MESSAGE\":\""
                                   + result.Message + "\"},";
                    else
                        strjson += "{\"ZID\":\"" + objects[i, 1] + "\",\"SUCCESS\":\"失败\",\"MESSAGE\":\""
                                   + result.Message + "\"},";
                }
                else
                {
                    strjson += "{\"ZID\":\"" + objects[i, 1] + "\",\"SUCCESS\":\"失败\",\"MESSAGE\":\""
                        + message + "\"},";
                }
            }
            strjson = strjson.Substring(0, strjson.Length - 1);
            sb.Append("{\"total\":\"" + objects.GetLength(0) + "\",\"rows\":[" + strjson + "]}");
            return sb.ToString();
        }

        [System.Web.Services.WebMethod]
        public static string StartOrStop(string chargpileid, string type)
        {
            RemoteDataGatherRpcDao.Current.RpcUrl = Url;
            //Dictionary<string, object> jsonResponseDic;
            var chargpileidarrary = chargpileid.Split('|');
            var c = new RpcClient
                {
                    RpcUrl = Url
                };
            try
            {
                var setting = InitSetting();
                var objects = SendCommand(setting, c, chargpileidarrary, type);
                var str = QueryCommand(objects);
                return str;
            }
            catch (Exception e)
            {
                Log.Error(e);
                throw;
            }

        }
    }
}
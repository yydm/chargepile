using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;
using System.Web.UI;
using ChargingPile.UI.WEB.Common;
using CodeAnywhere.Json.Rpc;
using CodeAnywhere.Json.Rpc.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ChargingPile.Model;
using ChargingPile.BLL;
using ChargingPile.Model.ChargePile;
using Newtonsoft.Json.Linq;
using log4net;

namespace ChargingPile.UI.WEB.pages.ChargePileDetailInfo
{
    public partial class ChargePileDetailInfomation : Page
    {
        static readonly string Url = ConfigurationSettings.AppSettings["url"];
        protected static ILog Log = LogManager.GetLogger("PriceAdjustmentService");

        private static readonly HttpSessionState _session = HttpContext.Current.Session;
        readonly static JavaScriptSerializer Jss = new JavaScriptSerializer();

        /// <summary>
        /// 根据充电桩id获取充电站名称和充电桩编号
        /// </summary>
        /// <param name="chargpileid"></param>
        /// <returns></returns>
        [System.Web.Services.WebMethod]
        public static string QueryChargePileInfo(string chargpileid)
        {
            ChargPileBll chargPileBll = new ChargPileBll();
            JsonMessage<ChargePileInfoParam> jsonMessage = new JsonMessage<ChargePileInfoParam>();
            string ret = null;
            if (string.IsNullOrEmpty(chargpileid))
            {
                return null;
            }
            try
            {
                var dt = chargPileBll.QueryByParam(chargpileid);
                var list = ConvertHelper<ChargePileInfoParam>.ConvertToList(dt);
                jsonMessage.Rows = list;
                jsonMessage.Msg = "返回成功";
                jsonMessage.Status = 1;
            }
            catch (Exception)
            {
                jsonMessage.Msg = "返回失败";
                jsonMessage.Status = 0;
                throw;
            }
            ret = Jss.Serialize(jsonMessage);
            return ret;
        }

        /// <summary>
        /// 查询充电桩状态
        /// </summary>
        /// <param name="chargpileid">桩id</param>
        /// <returns></returns>
        [System.Web.Services.WebMethod]
        public static string ChargePileStates(string chargpileid)
        {
            var json = RequestChargePileStatesSetting(chargpileid);
            var c = new RpcClient { RpcUrl = Url };
            var req = JsonConvert.DeserializeObject<JsonRequest>(json);
            var resp = c.Invoke(req);

            return JsonConvert.SerializeObject(resp, Formatting.Indented);
        }

        /// <summary>
        /// 查询充电桩实时信息
        /// </summary>
        /// <param name="chargpileid">桩id</param>
        /// <returns></returns>
        [System.Web.Services.WebMethod]
        public static string ChargePileCurrentTime(string chargpileid)
        {
            var message = new InvokeMessage<PointCfgItem>();
            string ret;
            int id;
            if (!string.IsNullOrEmpty(chargpileid))
            {
                id = int.Parse(chargpileid);
            }
            else
            {
                message.Status = 2;
                message.Msg = "数据为空！";
                ret = Jss.Serialize(message);
                return ret;
            }

            var zhuanType = string.Empty;
            var chargepile = new ChargPileBll();
            var dt = chargepile.FindByChargePileType(id);
            if (dt.Rows.Count <= 0)
            {

            }
            else
            {
                zhuanType = dt.Rows[0]["piletypeid"].ToString();
            }
            var jsonSetting = RequestChargePileCurrentTimeSetting(chargpileid);
            var c = new RpcClient { RpcUrl = Url };
            var req = JsonConvert.DeserializeObject<JsonRequest>(jsonSetting);


            try
            {
                Log.Debug("查询接口之前时间：" + DateTime.Now);
                var resp = c.Invoke(req);
                Log.Debug("查询接口之后时间：" + DateTime.Now);
                var success = resp.Success;
                var messages = resp.Message;
                switch (success)
                {
                    case true:
                        var so = JsonConvert.SerializeObject(resp, Formatting.Indented);
                        var json = JObject.Parse(so); //创建JSON对象
                        var listItem = JsonConvertToList(json);
                        Log.Debug("转换接口数据时间：" + DateTime.Now);
                        message.Current = GetCurrent(zhuanType, listItem);//获取电流的值和范围
                        Log.Debug("获取电流时间：" + DateTime.Now);
                        message.Voltage = GetVoltage(zhuanType, listItem);//获取电压表的值和范围
                        Log.Debug("获取电压时间：" + DateTime.Now);
                        var cfgList = IsHavePointCfgAndGatItemTable(id, listItem);//判断接口数据是否存在于PointCfg和GatItem里
                        Log.Debug("判断1时间：" + DateTime.Now);
                        var warnlist = IsHaveWarnRec(cfgList);//判断接口数据是否存在于WarnRec表里
                        Log.Debug("判断2时间：" + DateTime.Now);
                        message.Rows = warnlist;
                        message.Status = 3;
                        message.Msg = "返回成功";
                        ret = Jss.Serialize(message);
                        Log.Debug("返回时间：" + DateTime.Now);
                        return ret;
                    case false:
                        message.Status = 0;
                        message.Msg = messages;
                        ret = Jss.Serialize(message);
                        return ret;
                }
            }
            catch (Exception)
            {

            }
            message.Status = 0;
            message.Msg = "返回失败";
            ret = Jss.Serialize(message);
            return ret;
        }

        /// <summary>
        /// 获取电流的值和范围
        /// </summary>
        /// <param name="ztype">桩类型</param>
        /// <param name="itemsList">接口数据项</param>
        /// <returns></returns>
        public static Current GetCurrent(string ztype, List<Items> itemsList)
        {
            var gatItemBll = new GatItemBll();
            var pointCfgBll = new PointCfgBll();
            var current = new Current();
            DataTable dtCurrent;
            foreach (var itemse in itemsList)
            {
                dtCurrent = gatItemBll.FindByCurrentAndVoltage("电流", itemse.DataItemId);
                if (dtCurrent.Rows.Count <= 0)
                    continue;
                if (itemse.Value == null)
                {
                    continue;
                }
                current.ItemNo = itemse.DataItemId;
                current.CurrentPointer = itemse.Value;
                current.CurrentTime = itemse.GatDt;
                break;//只要查到一个有值就可以了(值为空就继续查，不为空就跳出)
            }

            dtCurrent = pointCfgBll.FindByEffectiveAndThreshold(current.ItemNo, ztype);
            if (dtCurrent.Rows.Count <= 0)
                return current;
            try
            {
                if (!string.IsNullOrEmpty(dtCurrent.Rows[0]["Eff_Max"].ToString()))
                {
                    current.CurrentEffectiveMax = decimal.Parse(dtCurrent.Rows[0]["Eff_Max"].ToString());
                }
                if (!string.IsNullOrEmpty(dtCurrent.Rows[0]["Eff_Min"].ToString()))
                {
                    current.CurrentEffectiveMin = decimal.Parse(dtCurrent.Rows[0]["Eff_Min"].ToString());
                }
                if (!string.IsNullOrEmpty(dtCurrent.Rows[0]["LimitMax"].ToString()))
                {
                    current.CurrentThresholdMax = decimal.Parse(dtCurrent.Rows[0]["LimitMax"].ToString());
                }
                if (!string.IsNullOrEmpty(dtCurrent.Rows[0]["LimitMin"].ToString()))
                {
                    current.CurrentThresholdMin = decimal.Parse(dtCurrent.Rows[0]["LimitMin"].ToString());
                }
            }
            catch (Exception)
            {
                throw;
            }
            return current;
        }

        /// <summary>
        /// 获取电压表的值和范围
        /// </summary>
        /// <param name="ztype">桩类型</param>
        /// <param name="itemsList">接口数据项</param>
        /// <returns></returns>
        public static Voltage GetVoltage(string ztype, List<Items> itemsList)
        {
            var gatItemBll = new GatItemBll();
            var pointCfgBll = new PointCfgBll();
            var voltage = new Voltage();
            DataTable dtVoltage;
            foreach (var itemse in itemsList)
            {
                dtVoltage = gatItemBll.FindByCurrentAndVoltage("电压", itemse.DataItemId);
                if (dtVoltage.Rows.Count <= 0)
                    continue;
                if (itemse.Value == null)
                {
                    continue;
                }
                voltage.ItemNo = itemse.DataItemId;
                voltage.VoltagePointer = itemse.Value;
                voltage.VoltageTime = itemse.GatDt;
                break;//只要查到一个有值就可以了
            }

            dtVoltage = pointCfgBll.FindByEffectiveAndThreshold(voltage.ItemNo, ztype);
            if (dtVoltage.Rows.Count <= 0)
                return voltage;
            try
            {
                if (!string.IsNullOrEmpty(dtVoltage.Rows[0]["Eff_Max"].ToString()))
                {
                    voltage.VoltageEffectiveMax = decimal.Parse(dtVoltage.Rows[0]["Eff_Max"].ToString());
                }
                if (!string.IsNullOrEmpty(dtVoltage.Rows[0]["Eff_Min"].ToString()))
                {
                    voltage.VoltageEffectiveMin = decimal.Parse(dtVoltage.Rows[0]["Eff_Min"].ToString());
                }
                if (!string.IsNullOrEmpty(dtVoltage.Rows[0]["LimitMax"].ToString()))
                {
                    voltage.VoltageThresholdMax = decimal.Parse(dtVoltage.Rows[0]["LimitMax"].ToString());
                }
                if (!string.IsNullOrEmpty(dtVoltage.Rows[0]["LimitMin"].ToString()))
                {
                    voltage.VoltageThresholdMin = decimal.Parse(dtVoltage.Rows[0]["LimitMin"].ToString());
                }

            }
            catch (Exception)
            {
                throw;
            }
            return voltage;
        }

        /// <summary>
        /// 判断接口数据是否存在于PointCfg和GatItem里
        /// 如果不存在就显示灰色(根据DataGatherId来判断)
        /// 最后都保存到PointCfgItem 
        /// </summary>
        /// <param name="zid">桩id</param>
        /// <param name="listItem">接口数据项</param>
        /// <returns></returns>
        public static List<PointCfgItem> IsHavePointCfgAndGatItemTable(int zid, List<Items> listItem)
        {
            var gatItemBll = new GatItemBll();
            var listCfg = new List<PointCfgItem>();

            var dt = gatItemBll.FindByItemName(zid);
            if (dt.Rows.Count <= 0 || listItem == null)
            {
                return null;
            }
            var list = ConvertHelper<GatItem>.ConvertToList(dt);

            foreach (var items in list) //这是表gat_item里面的值(要全部显示)
            {
                var pointCfgItem = new PointCfgItem();
                const string isItemShowColor = "gray";
                foreach (var itemse in listItem)//这里接口里的值
                {
                    if (itemse.DataItemId != items.ITEMNO) continue;
                    pointCfgItem.DataGatherId = itemse.DataGatherId;
                    break;
                }
                pointCfgItem.ItemNo = items.ITEMNO;
                pointCfgItem.ItemName = items.ITEMNAME;
                pointCfgItem.IsItemShowColor = isItemShowColor;
                listCfg.Add(pointCfgItem);
            }
            return listCfg;
        }

        /// <summary>
        /// 判断接口数据是否存在于WarnRec表里
        /// 是，显示颜色为红色，否，显示颜色为绿色
        /// </summary>
        /// <param name="pointCfgItems">
        /// </param>
        /// <returns></returns>
        private static List<PointCfgItem> IsHaveWarnRec(List<PointCfgItem> pointCfgItems)
        {
            var warnrecBll = new WarnRecBll();
            foreach (var pointCfgItem in pointCfgItems)
            {
                if (string.IsNullOrEmpty(pointCfgItem.DataGatherId))
                    continue;
                var dt = warnrecBll.FindByWarnRec(pointCfgItem.DataGatherId);
                if (dt.Rows.Count <= 0)
                {
                    pointCfgItem.IsItemShowColor = "green";
                    continue;
                }
                var list = ConvertHelper<WarnRec>.ConvertToList(dt);
                //pointCfgItem.WarnId = warnRec.Id;
                pointCfgItem.TargetDev = list[0].TargetDev;
                //pointCfgItem.ItemNo = warnRec.DataItemId;
                //保存工号
                pointCfgItem.WorkNum = ((Employer)(_session[Constant.LoginUser])).WorkNum;
                pointCfgItem.IsItemShowColor = "red";

            }
            return pointCfgItems;
        }

        /// <summary>
        /// json转化成list<item/>数据
        /// </summary>
        /// <param name="str">接口字符串</param>
        /// <returns></returns>
        private static List<Items> JsonConvertToList(JObject str)
        {
            var listItem = new List<Items>();

            var ss = str["data"]["values"];
            foreach (var s in ss)
            {
                var value = string.Empty;
                var datagatherid = string.Empty;
                var gatdt = string.Empty;
                var itemid = s["dataItemId"].ToString();
                if (s["gatDt"] != null)
                {
                    gatdt = s["gatDt"].ToString();
                }
                if (s["value"] != null)
                {
                    value = s["value"].ToString();
                }
                if (s["id"] != null)
                {
                    datagatherid = s["id"].ToString();
                }

                decimal? values = null;
                var quality = s["quality"].ToString();
                if (!string.IsNullOrEmpty(value))
                {
                    values = decimal.Parse(value, NumberStyles.Float);
                }

                var item = new Items
                    {
                        DataItemId = itemid,
                        Value = values,
                        DataGatherId = datagatherid,
                        Quality = quality,
                        GatDt = gatdt
                    };

                listItem.Add(item);
            }
            return listItem;
        }

        /// <summary>
        /// 构建请求(查询充电桩状态)
        /// </summary>
        /// <param name="id">桩id</param>
        /// <returns></returns>
        public static string RequestChargePileStatesSetting(string id)
        {
            var req = new JsonRequest
            {
                ClassType = "MemeryDbDao",
                Scope = RequestScope.Singleton,
                Method = "QueryDt"
            };
            var dic = new Dictionary<String, object> { { "PowerPileNo", id } };

            req.AddParam(@"select * from OTH_PileStates where powerpileno=#PowerPileNo")
                .AddParam(dic);
            var setting = new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore };
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss.fff" };
            setting.Converters.Add(timeConverter);

            var json = JsonConvert.SerializeObject(req, Formatting.Indented, setting);
            return json;
        }

        /// <summary>
        /// //构建请求(查询充电桩实时信息)
        /// </summary>
        /// <param name="id">桩id</param>
        /// <returns></returns>
        public static string RequestChargePileCurrentTimeSetting(string id)
        {
            var req = new JsonRequest
            {
                ClassType = "DataGatherRpc",
                Scope = RequestScope.Singleton,
                Method = "PullYCData"
            };
            req.AddParam(id);
            var setting = new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore };
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss.fff" };
            setting.Converters.Add(timeConverter);

            var json = JsonConvert.SerializeObject(req, Formatting.Indented, setting);
            return json;
        }
    }
}
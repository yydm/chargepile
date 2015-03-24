using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using ChargingPile.BLL;
using ChargingPile.Model;

namespace ChargingPile.Service
{
    public class Sms
    {
        /// <summary>
        /// Com端口
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// 启动短信猫
        /// </summary>
        public bool StartSms()
        {
            if (Port != 0)
            {
                const uint bit = 115200;
                var cards = Encoding.Default.GetBytes("card");
                var cardNo = Encoding.Default.GetString(cards);
                var ret = SmsApi.SMSStartService(Port, bit, 2, 8, 0, 0, cardNo);
                return ret == 1;
            }
            return false;
        }

        /// <summary>
        /// 停止短信猫
        /// </summary>
        /// <returns></returns>
        public bool StopSms()
        {
            var flag = SmsApi.SMSStopSerice();
            return flag != 0;
        }

        /// <summary>
        /// 替换模板数据
        /// </summary>
        /// <param name="replacedContent">将要替换内容</param>
        /// <param name="warnId">告警id</param>
        /// <returns></returns>
        public string ResplaceTemplateStr(string replacedContent, string warnId)
        {
            var warnDetailBll = new WarnDetailBll();
            var nameStr = replacedContent;

            if (replacedContent.IndexOf("充电站简称", StringComparison.Ordinal) >= 0)
            {
                var data = warnDetailBll.FindZhanJc(warnId);
                if (data.Rows.Count > 0)
                {
                    var str = data.Rows[0]["zhan_jc"].ToString();
                    nameStr = nameStr.Replace("充电站简称", str);
                }
            }
            if (replacedContent.IndexOf("桩编号", StringComparison.Ordinal) >= 0 || replacedContent.IndexOf("装编号", StringComparison.Ordinal) >= 0)
            {
                var data = warnDetailBll.FindZhuanBh(warnId);
                if (data.Rows.Count > 0)
                {
                    var str = data.Rows[0]["yunxing_bh"].ToString();
                    nameStr = nameStr.Replace("桩编号", str).Replace("装编号", str);

                }
            }
            if (replacedContent.IndexOf("数据项", StringComparison.Ordinal) >= 0)
            {
                var data = warnDetailBll.FindItemName(warnId);
                if (data.Rows.Count > 0)
                {
                    var str = data.Rows[0]["itemname"].ToString();
                    nameStr = nameStr.Replace("数据项", str);
                }
            }
            if (replacedContent.IndexOf("告警原因", StringComparison.Ordinal) >= 0)
            {
                var data = warnDetailBll.FindWarn(warnId);
                if (data.Rows.Count > 0)
                {
                    var str1 = data.Rows[0]["m_value"].ToString();
                    var str2 = data.Rows[0]["logdesc"].ToString();
                    nameStr = nameStr.Replace("告警原因", str1 + str2);
                }

            }
            return nameStr;
        }

        /// <summary>
        /// 发送短信
        /// </summary>
        public string SendSms()
        {
            var warndetailBll = new WarnDetailBll();
            var smsSuccessList = new Dictionary<uint, string>();
            var data = warndetailBll.FindBySms();
            if (data.Rows.Count <= 0)
            {
                return "没有短信数据。";
            }

            foreach (DataRow dataRow in data.Rows)//这里是全部的信息
            {
                var id = dataRow["id"].ToString();
                var warnid = dataRow["WARNRECID"].ToString();
                var warncontext = dataRow["WARNCONTEXT"].ToString();
                var strContent = ResplaceTemplateStr(warncontext, warnid);
                var warntarget = dataRow["ADDRESS"].ToString();
                var warntargetList = warntarget.Split(';');
                foreach (var s in warntargetList)//这里是全部的电话
                {
                    try
                    {
                        var num = SmsApi.SMSSendMessage(strContent, s);
                        smsSuccessList.Add(num, id);
                        Thread.Sleep(100);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
            }
            var successNum = 0;
            var sendingNum = 0;
            var failureNum = 0;
            foreach (var u in smsSuccessList)
            {
                var queryData = SmsApi.SMSQuery(u.Key);
                WarnDetail warndetail = null;
                switch (queryData)
                {
                    //发送成功
                    case 1:
                        warndetail = new WarnDetail
                            {
                                Id = u.Value,
                                ProcessFlag = 1,
                                IsSuccess = 1,
                                SendDT = DateTime.Now,
                                UpdateDT = DateTime.Now
                            };
                        successNum++;
                        break;
                    //正在发送中
                    case -1:
                        warndetail = new WarnDetail
                            {
                                Id = u.Value,
                                IsSuccess = 0,
                                ProcessFlag = 1,
                                SendDT = DateTime.Now,
                                UpdateDT = DateTime.Now
                            };
                        sendingNum++;
                        break;
                    //发送失败
                    case 0:
                        warndetail = new WarnDetail
                            {
                                Id = u.Value,
                                ProcessFlag = 1,
                                IsSuccess = 2,
                                SendDT = DateTime.Now,
                                UpdateDT = DateTime.Now
                            };
                        failureNum++;
                        break;
                    default: break;
                }
                warndetailBll.Modify(warndetail);
            }

            return "全部已发送：" + smsSuccessList.Count + "条(其中，成功：" + successNum + "条，失败：" + failureNum + "条，正在发送：" + sendingNum + "条)";
        }
    }
}

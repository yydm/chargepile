using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChargingPile.UI.WEB.Common
{
    public class Constant
    {
        /// <summary>
        /// 登陆用户session名称
        /// </summary>
        public const string LoginUser = "user";

        /// <summary>
        /// 数据类型-遥信
        /// </summary>
        public const string SjlxYx = "YX";

        /// <summary>
        /// 数据类型-遥测
        /// </summary>
        public const string SjlxYc = "YC";

        /// <summary>
        /// 数据类型-遥控
        /// </summary>
        public const string SjlxYk = "YK";

        /// <summary>
        /// 数据类型-遥调
        /// </summary>
        public const string SjlxYt = "YT";

        /// <summary>
        /// 告警方式-短信
        /// </summary>
        public const string GjfsDx = "SMS";

        /// <summary>
        /// 告警方式-邮件
        /// </summary>
        public const string GjfsYj = "Email";

        /// <summary>
        /// 告警方式-声音
        /// </summary>
        public const string GjfsSy = "SND";

        /// <summary>
        /// 告警记录-异常类型-遥测合理性
        /// </summary>
        public const string YclxYchlx = "001";

        /// <summary>
        /// 告警记录-异常类型-遥测跳变
        /// </summary>
        public const string YclxYctb = "002";

        /// <summary>
        /// 告警记录-异常类型-遥信合理性
        /// </summary>
        public const string YclxYxhlx = "003";

        /// <summary>
        /// 告警记录-异常类型-遥信变位
        /// </summary>
        public const string YclxYxbw = "004";

        /// <summary>
        /// 灭警方式-自动
        /// </summary>
        public const int MjfsZd = 1;

        /// <summary>
        /// 灭警方式-手动
        /// </summary>
        public const int MjfsSd = 2;
    }
}
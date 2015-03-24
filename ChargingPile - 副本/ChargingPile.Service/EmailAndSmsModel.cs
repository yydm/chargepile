using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChargingPile.Service
{
    public class EmailAndSmsModel
    {
        /// <summary>
        /// 邮件或短信主题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 邮件或短信内容
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// 发送地址
        /// </summary>
        public string Address { get; set; }
    }
}

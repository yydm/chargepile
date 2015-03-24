using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChargingPile.Model
{
    public class CardInfo
    {
        /// <summary>
        /// 卡号
        /// </summary>
        public string CardId { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 证件名称
        /// </summary>
        public string Zjmc { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        public string Zjhm { get; set; }

        /// <summary>
        /// 卡状态
        /// </summary>
        public string Kzt { get; set; }

        /// <summary>
        /// 卡类型
        /// </summary>
        public string Klx { get; set; }

        /// <summary>
        /// 充值网点
        /// </summary>
        public string Czwd { get; set; }

        /// <summary>
        /// 充值起始时间
        /// </summary>
        public DateTime DateBegin { get; set; }

        /// <summary>
        /// 充值结束时间
        /// </summary>
        public DateTime DateEnd { get; set; }

        /// <summary>
        /// 操作员
        /// </summary>
        public string Czy { get; set; }

        /// <summary>
        /// 充值方式
        /// </summary>
        public string Czfs { get; set; }

        public override string ToString()
        {
            return "CardId:" + CardId + ",Name:" + Name + ",Zjmc:" + Zjmc + ",Zjhm：" + Zjhm
                   + ",Kzt:" + Kzt + ",Klx:" + Klx + ",Czwd:" + Czwd + ",CzsjBegin:"
                   + DateBegin + ",CzsjEnd:" + DateEnd + ",Czy:" + Czy + ",Czfs:" + Czfs;
        }

    }
}

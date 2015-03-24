using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChargingPile.Model
{
    public class SmsOutBox
    {
         /// <summary>
        /// 
        /// </summary>
        private decimal _expresslevel = 2;
        private decimal _msgtype = 1;
        private DateTime? _sendtime = DateTime.Now;

        /// <summary>
        /// 作为要发送信息的ID标识，用户程序无需处理
        /// </summary>
        public decimal Msgid { get; set; }

        /// <summary>
        /// 发送级别，系统分为3个级别:
        /// 0 为最高优先级
        /// 1 较高优先级
        /// 2 普通优先级
        /// 可通过此字段控制发送信息的先后顺序
        /// </summary>
        public decimal Expresslevel
        {
            get { return _expresslevel; }
            set { _expresslevel = value; }
        }

        /// <summary>
        /// 发送者名称，也可以是发送者的手机号码，
        /// 为用户程序保留的字段，
        /// 用户可根据自己的需要来填写，也可不填写。
        /// </summary>
        public string Sender { get; set; }

        /// <summary>
        /// 接收者手机号码，此字段为必填字段。
        ///	发送短信，只能填写一个手机号码
        ///	发送彩信，可填写多个手机号，
        /// 手机号之间用半角逗号分开，手机号的数量最多不超过10个，
        /// 其数值与当地彩信网关有关，
        /// 有的网关会过滤掉后面的手机号，这种情况只能填写一个手机号
        /// </summary>
        public string Receiver { get; set; }

        /// <summary>
        /// 0 = 普通短信
        /// 1 = 彩信 （系统默认为1，彩信）
        /// 2 = wap push
        /// 3 = 免提短信（快闪短信）
        /// </summary>
        public decimal Msgtype
        {
            get { return _msgtype; }
            set { _msgtype = value; }
        }

        /// <summary>
        /// 该字段包含3个作用，其含义取决于MsgType字段：
        ///	可作为普通短信的内容
        /// 可作为wap push中的提示语和URL，提示语和url之间用  ####  分隔
        /// 例如：push测试####wap.baidu.com
        ///	可作为彩信的标题
        /// </summary>
        public string Msgtitle { get; set; }

        /// <summary>
        /// 彩信内容的全路径文件名，
        /// 如发短信和wap push，则本字段不用填写，彩信内容文件以下3种方式提供：
        /// </summary>
        public string Mmscontentlocation { get; set; }


        /// <summary>
        /// 单一资源文件 （比如一个图片文件或一个声音文件）
        ///	ini简单彩信描述文件
        ///	smil标准彩信描述文件
        /// 关于ini文件和smil的文件格式，下面有详细说明
        /// </summary>
        public DateTime? Sendtime
        {
            get { return _sendtime; }
            set { _sendtime = value; }
        }

        /// <summary>
        /// 计划发送时间，必填字段，一般填写当前时间
        /// </summary>
        public decimal Commport { get; set; }

        /// <summary>
        /// 指定串口号
        /// 当彩信系统有多个设备同时工作的时候，如需指定使用某串口上的设备发送信息，则填写串口号，
        /// 如不需要指定则填写0，这时系统根据各个设备的忙闲情况自动分配使用。
        /// </summary>
        public SmsOutBox()
        {
            Commport = 0M;
        }
    }
}

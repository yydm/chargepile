
namespace ChargingPile.Model
{
    /// <summary>
    /// 向前台传递数据
    /// </summary>
    public class YxYcErrorProcess : BaseModel<YxYcErrorProcess>
    {
        /// <summary>
        /// ID
        /// </summary>
        public string  Id { get; set; }

        /// <summary>
        /// 站名称
        /// </summary>
        public string ZhanMc { get; set; }

        /// <summary>
        /// 桩型号
        /// </summary>
        public string ParserKey { get; set; }

        /// <summary>
        /// 桩类型
        /// </summary>
        public string ZhuangLeiX { get; set; }

        /// <summary>
        /// 充电桩
        /// </summary>
        public decimal TargetDev { get; set; }

        /// <summary>
        /// 数据采集Id
        /// </summary>
        public string DataGatherId { get; set; }

        /// <summary>
        /// 数据项
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// 数据值
        /// </summary>
        public decimal MValue { get; set; }

        /// <summary>
        /// 异常描述
        /// </summary>
        public string LogDesc { get; set; }

        /// <summary>
        /// 阈值最小值
        /// </summary>
        public decimal? LimitMin { get; set; }

        /// <summary>
        /// 阈值最大值
        /// </summary>
        public decimal? LimitMax { get; set; }

        /// <summary>
        /// 有效值最小值
        /// </summary>
        public decimal? EffMin { get; set; }

        /// <summary>
        /// 有效值最大值
        /// </summary>
        public decimal? EffMax { get; set; }

        /// <summary>
        /// 遥信状态值
        /// </summary>
        public string YxStates { get; set; }

        /// <summary>
        /// 遥信有效值
        /// </summary>
        public string YxEff { get; set; }

        /// <summary>
        /// 遥信告警值
        /// </summary>
        public string YxWarn { get; set; }

        /// <summary>
        /// 处理标记
        /// </summary>
        public decimal ProcessFlag { get; set; }

        /// <summary>
        /// 告警标识
        /// </summary>
        public decimal WarnFlag { get; set; }

        public override string ToString()
        {
            return "ZhanMc=" + ZhanMc + ",ParserKey=" + ParserKey + ",ZhuangLeiX=" + ZhuangLeiX + ",TargetDev=" +
                   TargetDev + ",ItemName=" + ItemName + ",MValue=" + MValue + ",ProcessFlag=" + ProcessFlag;
        }
    }
}

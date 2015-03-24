using System;

namespace ChargingPile.Model
{
    public class WarnRec : BaseModel<WarnRec>
    {
        /// <summary>
        /// ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 数据项ID
        /// </summary>
        public string DataItemId { get; set; }

        /// <summary>
        /// 目标桩
        /// </summary>
        public string TargetDev { get; set; }
        /// <summary>
        /// 目标数据
        /// </summary>
        public string TARGETDATAKEY { set; get; }
        /// <summary>
        /// 数据采集ID
        /// </summary>
        public string DataGatherId { get; set; }

        /// <summary>
        /// 采集时间
        /// </summary>
        public DateTime? Occurdt { get; set; }

        /// <summary>
        /// 异常类型
        /// </summary>
        public string LogType { get; set; }

        /// <summary>
        /// 采集值
        /// </summary>
        public int M_Vlaue { get; set; }

        /// <summary>
        /// 异常描述
        /// </summary>
        public string LogDesc { get; set; }

        /// <summary>
        /// 记录时间
        /// </summary>
        public DateTime? CreateDt { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateDt { get; set; }

        /// <summary>
        /// 处理标志
        /// </summary>
        public int? ProcessFlag { get; set; }

        /// <summary>
        /// 告警标志
        /// </summary>
        public int? WarnFlag { get; set; }

        /// <summary>
        /// 处理时间
        /// </summary>
        public DateTime? ProcessDt { get; set; }

        /// <summary>
        /// 处理人
        /// </summary>
        public string ProcesseEp { get; set; }

        /// <summary>
        /// 工号
        /// </summary>
        public string WorkNum { get; set; }

        public string ZHANMC { get; set; }
        public string DTUMC { get; set; }
        public string YUNXING_BH { get; set; }

        public override string ToString()
        {
            return "Id:" + this.Id +
                 ",DataItemId:" + this.DataItemId +
                 ",TargetDev:" + this.TargetDev +
                 ",DataGatherId:" + this.DataGatherId +
                 ",Occurdt:" + this.Occurdt +
                 ",LogType:" + this.LogType +
                 ",M_Vlaue:" + this.M_Vlaue +
                 ",LogDesc:" + this.LogDesc +
                 ",ProcessFlag:" + this.ProcessFlag +
                 ",CreateDT:" + this.CreateDt +
                 ",UpdateDT:" + this.UpdateDt +
                 ",WarnFlag:" + this.WarnFlag +
                 ",UpdateDT:" + this.UpdateDt +
                 ",ProcessDt:" + this.ProcessDt +
                 ",ProcesseEp:" + this.ProcesseEp;
        }
    }
}

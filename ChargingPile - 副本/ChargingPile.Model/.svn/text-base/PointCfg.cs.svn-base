using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChargingPile.Model
{
    public class PointCfg : BaseModel<PointCfg>
    {
        public string Id { get; set; }

        /// <summary>
        /// 桩厂家
        /// </summary>
        public string Zhuangcj { get; set; }

        /// <summary>
        /// 充电桩型号
        /// </summary>
        public string PileTypeId { get; set; }

        /// <summary>
        /// 充电桩类型
        /// </summary>
        public string ZhuangLeiX { get; set; }

        /// <summary>
        /// 数据项ID
        /// </summary>
        public string GatItemId { get; set; }

        /// <summary>
        /// 数据项ID
        /// </summary>
        public string GatItemName { get; set; }

        /// <summary>
        /// 阈值最小值
        /// </summary>
        public decimal? LimitMin { get; set; }

        /// <summary>
        /// 阈值最大值
        /// </summary>
        public decimal? LimitMax { get; set; }

        /// <summary>
        /// 超阈值告警
        /// </summary>
        public decimal? IsOverLimtWarn { get; set; }

        /// <summary>
        /// 有效值最小值
        /// </summary>
        public decimal? Eff_Min { get; set; }

        /// <summary>
        /// 有效值最大值
        /// </summary>
        public decimal? Eff_Max { get; set; }

        /// <summary>
        /// 超有效值告警
        /// </summary>
        public decimal? IsOverEffWarn { get; set; }

        /// <summary>
        /// 是否自动灭警
        /// </summary>
        public decimal? IsAutoCleanWarn { get; set; }

        /// <summary>
        /// 灭警规则
        /// </summary>
        public decimal? CleanWarnRule { get; set; }

        /// <summary>
        /// 告警类型
        /// </summary>
        public string WarnType { get; set; }

        /// <summary>
        /// 短信
        /// </summary>
        public string Dx { get; set; }

        /// <summary>
        /// 邮件
        /// </summary>
        public string Yj { get; set; }

        /// <summary>
        /// 声音
        /// </summary>
        public string Sy { get; set; }

        /// <summary>
        /// 邮件方式：邮件地址用逗号隔开 
        /// 短信方式：手机号码用逗号隔开
        /// </summary>
        public string WarnTarget { get; set; }

        public string Sjh { get; set; }

        public string Yxdz { get; set; }

        /// <summary>
        /// 告警内容模板
        /// </summary>
        public string WarnContext { get; set; }

        /// <summary>
        /// 声音文件类型
        /// </summary>
        public string SndFileType { get; set; }

        /// <summary>
        /// 声音文件对象
        /// </summary>
        public byte[] SndFileContext { get; set; }

        /// <summary>
        /// 短信模板
        /// </summary>
        public string Dxmb { get; set; }

        /// <summary>
        /// 邮件模板
        /// </summary>
        public string Yjmb { get; set; }

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
        /// 是否有效
        /// </summary>
        public decimal IsUse { get; set; }

        public override string ToString()
        {
            return "Id:" + Id + ",Zhuangcj:" + Zhuangcj + ",PileTypeId:" + PileTypeId + ",ZhuanLeiX:" + ZhuangLeiX
                   + ",GatItemId:" + GatItemId + ",LimitMin:" + LimitMin + ",LimitMax:" + LimitMax + ",IsOverLinitWarn:" +
                   IsOverLimtWarn + ",Eff_Min:" + Eff_Min + ",Eff_Max:" + Eff_Max + ",IsOverEffWarn:" + IsOverEffWarn +
                   ",IsAutoCleanWarn:" + IsAutoCleanWarn + ",CleanWarnRule:" + CleanWarnRule + ",WarnType:" + WarnType +
                   ",WarnTarget" + WarnTarget + ",WarnContext:" + WarnContext + ",SndFileType:" + SndFileType
                   + ",Dx:" + Dx + ",Yj:" + Yj + ",Sy:" + Sy + ",Sjh:" + Sjh + ",Yxdz:" + Yxdz + ",Dxmb:" + Dxmb
                   + ",Yjmb:" + Yjmb + ",YxStates:" + YxStates + ",YxEff:" + YxEff + ",YxWarn:" + YxWarn + ",IsUse:" + IsUse;
        }
    }
}

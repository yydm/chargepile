using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChargingPile.Model
{
    /// <summary>
    /// 充电桩全景图片
    /// </summary>
    [Serializable]
    public class ChargStationFile : BaseModel<ChargStationFile>
    {
        /// <summary>
        /// 充电站编号
        /// </summary>
        public decimal? ZhanBh { get; set; }

        /// <summary>
        /// 唯一Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 文件名称
        /// </summary>
        public string Filename { get; set; }

        /// <summary>
        /// 文件内容
        /// </summary>
        public byte[] Filecontext { get; set; }
        /// <summary>
        /// 文件大小
        /// </summary>
        public decimal? Filesize { get; set; }

        /// <summary>
        /// 文件MIME
        /// </summary>
        public string Filemime { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? Createdt { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? Updatedt { get; set; }

        public override string ToString()
        {
            return "ZhanBh=" + ZhanBh + ",Id=" + Id + ",Filename=" + Filename + ",Filecontext=" +
                   Filecontext + ",Filesize=" + Filesize + ",Filemime=" + Filemime + ",Createdt=" + Createdt;
        }
    }
}

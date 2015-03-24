using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChargingPile.Model
{
    public class Picture
    {
        public string Id { get; set; }

        public byte[] FileContext { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        /// <summary>
        /// 图片类型
        /// </summary>
        public string FileMime { get; set; }
    }
}

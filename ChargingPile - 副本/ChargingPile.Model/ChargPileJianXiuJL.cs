using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChargingPile.Model
{
    public class ChargPileJianXiuJL
    {
        public string Id { set; get; }
        public decimal? Zhuan_Id { set; get; }
        public DateTime CreateDt { set; get; }
        public DateTime UpdateDt { set; get; }
        public string JianXiu_Lx { set; get; }
        public string jxlx { set; get; }
        public string JianXiu_Jb { set; get; }
        public string jxjb { set; get; }
        public DateTime JianXiu_Sj { set; get; }
        public string JianXiu_Jl { set; get; }
        public string JianXiu_R { set; get; }

        public decimal? Zhan_Bh { set; get; }
        public string Zhan_Jc { set; get; }
        public string Zhuan_Mc { set; get; }
        public string YunXing_Bh { set; get; }
        public string ChangJia { set; get; }
        public string ZhuangLei_X { set; get; }
        public string ZhanBh { get; set; }
    }
}

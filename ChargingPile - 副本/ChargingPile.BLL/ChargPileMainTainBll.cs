using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChargingPile.DAL;
using System.Data;
using ChargingPile.Model;

namespace ChargingPile.BLL
{
    public class ChargPileMainTainBll
    {
        ChargPileMainTainDal cpmtd = new ChargPileMainTainDal();
        /// <summary>
        /// 获取充电站
        /// </summary>
        /// <returns></returns>
        public DataTable QueryChargStation() 
        {
            return cpmtd.QueryChargStation();
        }
        /// <summary>
        /// 获取检修类型
        /// </summary>
        /// <returns></returns>
        public DataTable QueryCode(string codename) 
        {
            return cpmtd.QueryCode(codename);
        }
        /// <summary>
        /// 获取运行编号
        /// </summary>
        /// <param name="zhuan_bh"></param>
        /// <returns></returns>
        public DataTable QueryYunxingbh(string zhuan_bh) 
        {
            return cpmtd.QueryYunxingbh(zhuan_bh);
        }
        /// <summary>
        /// 获取运行编号
        /// </summary>
        /// <param name="zhuan_bh"></param>
        /// <returns></returns>
        public DataTable QueryZYunxingbh(string zhuan_bh) 
        {
            return cpmtd.QueryZYunxingbh(zhuan_bh);
        }
        /// <summary>
        /// 获取厂家和类型
        /// </summary>
        /// <param name="yxbh"></param>
        /// <returns></returns>
        public DataTable QueryCJLX(string yxbh,string zhanbh) 
        {
            return cpmtd.QueryCJLX(yxbh,zhanbh);
        }
        /// <summary>
        /// 添加检修记录
        /// </summary>
        /// <param name="jxjl"></param>
        public void AddJianXiuJL(ChargPileJianXiuJL jxjl) 
        {
            string yxbh = jxjl.YunXing_Bh;
            string zhanBh = jxjl.ZhanBh;
            DataTable dt = cpmtd.QueryCJLX(yxbh,zhanBh);
            decimal? zhuanid = decimal.Parse(dt.Rows[0]["DEV_CHARGPILE"].ToString());
            jxjl.Zhuan_Id = zhuanid;
            cpmtd.Add(jxjl);
        }
        /// <summary>
        /// 修改检修记录
        /// </summary>
        /// <param name="jxjl"></param>
        public void EditJianXiuJL(ChargPileJianXiuJL jxjl)
        {
            string yxbh = jxjl.YunXing_Bh;
            string zhanBh = jxjl.ZhanBh;
            DataTable dt = cpmtd.QueryCJLX(yxbh, zhanBh);
            decimal? zhuanid = decimal.Parse(dt.Rows[0]["DEV_CHARGPILE"].ToString());
            jxjl.Zhuan_Id = zhuanid;
            cpmtd.Modify(jxjl);
        }
        /// <summary>
        /// 删除检修记录
        /// </summary>
        /// <param name="id"></param>
        public void Delete(string id) 
        {
            ChargPileJianXiuJL jxjl = new ChargPileJianXiuJL();
            jxjl.Id = id;
            cpmtd.Del(jxjl);
        }
        /// <summary>
        /// 查询检修记录
        /// </summary>
        /// <param name="zhanbh"></param>
        /// <param name="begintime"></param>
        /// <param name="endtime"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public List<ChargPileJianXiuJL> GetJxjlList(string zhanbh,string zhuangbh,DateTime begintime,DateTime endtime,string jxlx, int page,int rows, ref int total)
        {
            return cpmtd.GetJxjlList(zhanbh,zhuangbh, begintime, endtime,jxlx, page, rows, ref  total);
        }

    }
}

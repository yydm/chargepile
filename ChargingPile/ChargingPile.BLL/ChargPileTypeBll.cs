using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChargingPile.DAL;
using System.Data;
using ChargingPile.Model;

namespace ChargingPile.BLL
{
    public class ChargPileTypeBll
    {
        readonly ChargPileTypeDal cptd = new ChargPileTypeDal();
        /// <summary>
        /// 获取充电桩类型
        /// </summary>
        /// <returns></returns>
        public DataTable QueryChargPileType()
        {
            return cptd.QueryChargPileType();

        }
        /// <summary>
        /// 添加充电桩类型
        /// </summary>
        /// <param name="chargtype"></param>
        public void AddType(ChargPileTypes chargtype)
        {
            cptd.Add(chargtype);
        }
        /// <summary>
        /// 修改充电桩类型
        /// </summary>
        /// <param name="chargtype"></param>
        public void EditType(ChargPileTypes chargtype)
        {
            cptd.Modify(chargtype);
        }
        /// <summary>
        /// 删除充电桩类型
        /// </summary>
        /// <param name="parserkey"></param>
        public void DelType(string parserkey)
        {
            cptd.Del(new ChargPileTypes() { PARSERKEY = parserkey });
        }

        /// <summary>
        /// 获取所有厂家信息
        /// </summary>
        /// <returns></returns>
        public DataTable QueryChangJia()
        {
            return cptd.QueryChangJia();
        }

        public DataTable Query(ChargPileTypes bean)
        {
            return cptd.Query(bean);
        }
    }
}

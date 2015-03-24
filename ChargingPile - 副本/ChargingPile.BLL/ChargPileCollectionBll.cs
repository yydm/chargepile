using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChargingPile.DAL;
using System.Data;

namespace ChargingPile.BLL
{
    public class ChargPileCollectionBll
    {
        ChargPileCollectionDal cpcdal = new ChargPileCollectionDal();
        /// <summary>
        /// 获取采集项数据
        /// </summary>
        /// <returns></returns>
        public DataTable QueryChargPileCollection() 
        {
            return cpcdal.QueryChargPileCollection();
        }
        /// <summary>
        /// 查看配置项
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable QueryCollection(string id) 
        {
            return cpcdal.QueryCollection(id); 
        }
        /// <summary>
        /// 添加配置项
        /// </summary>
        /// <param name="typeid"></param>
        /// <param name="pzxs"></param>
        public void AddPZX(string typeid, string pzxs) 
        {
          //cpcdal.DelPZX(typeid);
            string[] arrpzx = pzxs.Split(':');
            DataTable dt1 = cpcdal.QueryItemByTypeID(typeid);
            if (dt1.Rows.Count > 0)
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    int a = 0;
                    int b = 0;
                    string pzx = dt1.Rows[i]["GATITEMID"].ToString();
                    for (int j = 0; j < arrpzx.Length; j++)
                    {
                        b = 0;
                        if (pzx == arrpzx[j])
                        {
                            a++;
                        }
                        if (pzx != arrpzx[j])
                        {
                            for (int k = 0; k < dt1.Rows.Count; k++)
                            {
                                if (arrpzx[j] == dt1.Rows[k]["GATITEMID"].ToString())
                                {
                                    b++;
                                }
                            }
                            if (b == 0 && i == 0)
                            {
                                cpcdal.AddPZX(typeid, arrpzx[j]);
                            }
                        }
                    }
                    if (a == 0)
                    {
                        cpcdal.DelPZX(typeid, pzx);
                    }
                }
            }
            else 
            {
                for (int j = 0; j < arrpzx.Length; j++)
                {
                    cpcdal.AddPZX(typeid, arrpzx[j]);
                }
            }
            

        }
    } 
}

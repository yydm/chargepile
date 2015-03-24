using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChargingPile.Model;
using ChargingPile.DAL;
using System.Data;

namespace ChargingPile.BLL
{
    public class DTUBll
    {
        
        DTUDal dtudal = new DTUDal();
        ChargPileDal cpdal = new ChargPileDal();
        /// <summary>
        /// 添加DTU
        /// </summary>
        /// <param name="bean"></param>
        public void AddDTU(DTUInfo bean) 
        {
            dtudal.AddDTU(bean);
        }
        /// <summary>
        /// 删除dtu
        /// </summary>
        /// <param name="id"></param>
        public void DelDTU(string id)
        {
            dtudal.DelDTU(id);
        }
        /// <summary>
        /// 修改dtu
        /// </summary>
        /// <param name="bean"></param>
        public void EditDTU(DTUInfo bean)
        {
            dtudal.EditDTU(bean);
        }
        /// <summary>
        /// 查询dtu
        /// </summary>
        /// <param name="bean"></param>
        /// <returns></returns>
        public DataTable QueryDTU(DTUInfo bean)
        {
            return dtudal.QueryDTU(bean);
        }
        /// <summary>
        /// 查询dtu分页list
        /// </summary>
        /// <param name="zhanbh"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public List<DTUInfo> GetDTUList(string zhanbh, int page, int rows, ref int total)
        {
            return dtudal.GetDTUList(zhanbh,page,rows,ref total);
        }
        /// <summary>
        /// 根据dtuid查询充电桩
        /// </summary>
        /// <param name="dtuid"></param>
        /// <returns></returns>
        public DataTable QueryBYdtuid(string dtuid) 
        {
            return cpdal.QueryBYdtuid(dtuid);
        }
        /// <summary>
        /// 获取运行日志
        /// </summary>
        /// <param name="begintime"></param>
        /// <param name="endtime"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public List<OprLog> GetWorkLogList(DateTime begintime, DateTime endtime, int page, int rows, ref int total)
        {
            return dtudal.GetWorkLogList(begintime,endtime,page,rows,ref total);
        }
        /// <summary>
        /// 获取通信告警信息
        /// </summary>
        /// <param name="zhanbh"></param>
        /// <param name="protype"></param>
        /// <param name="begintime"></param>
        /// <param name="endtime"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public List<WarnRec> GetTXWarnList(string zhanbh, string protype, DateTime begintime, DateTime endtime, int page, int rows, ref int total)
        {
            return dtudal.GetTXWarnList(zhanbh, protype, begintime, endtime, page, rows, ref total);
        }
        /// <summary>
        /// 获取停电告警信息
        /// </summary>
        /// <param name="zhanbh"></param>
        /// <param name="protype"></param>
        /// <param name="begintime"></param>
        /// <param name="endtime"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public List<WarnRec> GetTDWarnList(string zhanbh, string protype, DateTime begintime, DateTime endtime, int page, int rows, ref int total)
        {
            return dtudal.GetTDWarnList(zhanbh, protype, begintime, endtime, page, rows, ref total);
        }
        /// <summary>
        /// 获取卡异常使用告警信息
        /// </summary>
        /// <param name="zhanbh"></param>
        /// <param name="yxbh"></param>
        /// <param name="protype"></param>
        /// <param name="begintime"></param>
        /// <param name="endtime"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public List<WarnRec> GetCardWarnList(string zhanbh,string yxbh, string protype, DateTime begintime, DateTime endtime, int page, int rows, ref int total)
        {
            return dtudal.GetCardWarnList(zhanbh, yxbh, protype, begintime, endtime, page, rows, ref total);
        }
        /// <summary>
        /// 获取树节点
        /// </summary>
        public string GetAllNodes()
        {
            string nId = string.Empty; // 节点id
            string nName = string.Empty; // 节点名称 
            string pId = string.Empty; // 上级节点id
            StringBuilder NodeStr = new StringBuilder(); //节点json字符串
            ChargStation bean = new ChargStation();
            DTUInfo dtu = new DTUInfo();
            ChargStationBll csbll = new ChargStationBll();
            NodeStr.Append("[");
            DataTable dta = csbll.Queryall(bean);//查询所有充电站
            if (dta.Rows.Count > 0)
            {
                for (int a = 0; a < dta.Rows.Count; a++)
                {
                    decimal zhanbh = decimal.Parse(dta.Rows[a]["zhan_bh"].ToString());
                    string zhanmc = dta.Rows[a]["zhan_jc"].ToString();
                    dtu.ZHUAN_BH = zhanbh;
                    DataTable dt = QueryDTU(dtu);//根据充电站查询dtu
                    string zhanid = zhanbh.ToString() + ":z";
                    NodeStr.Append("{id:'" + zhanid + "',pId:0,name:'" + zhanmc + "', icon:'../../Images/1_open.png',isParent:true },");
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string dtuid = dt.Rows[i]["ID"].ToString();
                            string dtuname = dt.Rows[i]["DTUNAME"].ToString();
                            dtuid = dtuid + ":d";
                            NodeStr.Append("{id:'" + dtuid + "',pId:'" + zhanid + "',name:'" + dtuname + "', icon:'../../Images/dtu.png' },");
                           
                        }
                    }
                }

            }
            if (NodeStr.ToString() != "[")
            {
                int n = NodeStr.ToString().LastIndexOf(",");
                NodeStr.Remove(n, 1);
            }
            NodeStr.Append("]");
            return NodeStr.ToString();
        }



        /// <summary>
        /// 根据节点id获取下级节点
        /// </summary>
        /// <param name="nodeid"></param>
        /// <returns></returns>
        public string getNode(string nodeid)
        {
            string nId = string.Empty; // 节点id
            string nName = string.Empty; // 节点名称           
            StringBuilder NodeStr = new StringBuilder();//节点json字符串
            DTUInfo dtu = new DTUInfo();

            string zhanid  = nodeid.Split(':')[0];

            dtu.ZHUAN_BH = decimal.Parse(zhanid);

            NodeStr.Append("[");
            DataTable Dt = QueryDTU(dtu);

            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                string dtuid = Dt.Rows[i]["ID"].ToString();
                string dtuname = Dt.Rows[i]["DTUNAME"].ToString();
                dtuid = dtuid + ":d";
                NodeStr.Append("{id:'" + dtuid + "',pId:'" + nodeid + "' ,name:'" + dtuname + "',icon:'../../Images/dtu.png'},");
            }
            if (NodeStr.ToString() != "[")
            {
                int n = NodeStr.ToString().LastIndexOf(",");
                NodeStr.Remove(n, 1);
            }
            NodeStr.Append("]");
            return NodeStr.ToString();

        }
        /// <summary>
        /// 查询UNIT
        /// </summary>
        /// <param name="dtuid"></param>
        /// <param name="zhanid"></param>
        /// <returns></returns>
        public DataTable QueryUnit(string dtuid, decimal zhanid) 
        {
            return dtudal.QueryUnit(dtuid,zhanid);
        }

        /// <summary>
        /// 添加dtuunit关系
        /// </summary>
        /// <param name="dtuid"></param>
        /// <param name="pileids"></param>
        public void AddUnit(string dtuid, string pileids)
        {
            string[] arrpiles = pileids.Split(':');
            DataTable dt1 = dtudal.GetDTUUnid(dtuid);
            if (dt1.Rows.Count > 0)
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    int a = 0;
                    int b = 0;
                    string pileid = dt1.Rows[i]["dev_chargpile"].ToString();
                    for (int j = 0; j < arrpiles.Length; j++)
                    {
                        b = 0;
                        if (pileid == arrpiles[j])
                        {
                            a++;
                        }
                        if (pileid != arrpiles[j])
                        {
                            for (int k = 0; k < dt1.Rows.Count; k++)
                            {
                                if (arrpiles[j] == dt1.Rows[k]["dev_chargpile"].ToString())
                                {
                                    b++;
                                }
                            }
                            if (b == 0 && i == 0)
                            {
                                dtudal.AddDTUUnit(dtuid, arrpiles[j]);
                            }
                        }
                    }
                    if (a == 0)
                    {
                        dtudal.DelDTUUnit(dtuid, pileid);
                    }

                }
            }
            else
            {
                for (int j = 0; j < arrpiles.Length; j++)
                {
                    dtudal.AddDTUUnit(dtuid, arrpiles[j]);
                }
            }

        }

        
    }
}

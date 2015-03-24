using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ChargingPile.Model;
using ChargingPile.DAL;

namespace ChargingPile.BLL
{
    public class ChargStationBll:BaseBll<ChargStation>
    {
        ChargStationDal _chargStationDal = new ChargStationDal();
        /// <summary>
        /// 查询桩类型
        /// </summary>
        /// <returns></returns>
        public DataTable QueryPileType() 
        {
            return _chargStationDal.QueryPileType();
        }
        /// <summary>
        /// 通过桩厂家查询桩型号
        /// </summary>
        /// <param name="cj"></param>
        /// <returns></returns>
        public DataTable QueryPileXH(string cj) 
        {
            return _chargStationDal.QueryPileXH(cj);
        }
        /// <summary>
        /// 获取充电站id
        /// </summary>
        /// <returns></returns>
        public DataTable QueryZhanId() 
        {
            return _chargStationDal.QueryZhanId();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="zhanbh"></param>
        public void DelStationFile(decimal? zhanbh) 
        {
            _chargStationDal.DelStationFile(zhanbh);
        }
        /// <summary>
        /// 查询充电桩类型
        /// </summary>
        /// <param name="zhanbh"></param>
        /// <returns></returns>
        public DataTable QueryTypes(decimal zhanbh) 
        {
            return _chargStationDal.QueryTypes(zhanbh);
        }
        /// <summary>
        /// 通过充电站查询充电桩
        /// </summary>
        /// <param name="zhanbh"></param>
        /// <returns></returns>
        public DataTable QueryPile(string zhanbh) 
        {
            return _chargStationDal.QueryPile(zhanbh);
        }

        /// <summary>
        /// 保存充电桩
        /// </summary>
        /// <param name="bean"></param>
        public void SavePile(ChargPile bean) 
        {
            _chargStationDal.SavePile(bean);
        }
        /// <summary>
        /// 保存充电站
        /// </summary>
        /// <param name="bean"></param>
        public void SaveZhan(ChargStation bean) 
        {
            _chargStationDal.SaveZhan(bean);
        }
        /// <summary>
        /// 通过站编号查询分支箱是否存在
        /// </summary>
        /// <param name="zhanbh"></param>
        /// <returns></returns>
        public bool QueryBranch(decimal? zhanbh) 
        {
            DataTable dt = _chargStationDal.QueryBranch(zhanbh);
            if (dt.Rows.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// 根据站编号查询分支箱id
        /// </summary>
        /// <param name="zhanbh"></param>
        /// <returns></returns>
        public DataTable QueryBoxID(decimal? zhanbh) 
        {
            return _chargStationDal.QueryBranch(zhanbh);
        }
        /// <summary>
        /// 根据站编号查询分支箱id
        /// </summary>
        /// <param name="zhanbh"></param>
        /// <returns></returns>
        public DataTable QueryBranchId(decimal? zhanbh) 
        {
            return _chargStationDal.QueryBranch(zhanbh);
        }
        /// <summary>
        /// 添加分支箱
        /// </summary>
        /// <param name="bean"></param>
        public void AddBranch(Branch bean) 
        {
            _chargStationDal.AddBranch(bean);
        }
        /// <summary>
        /// 添加充电桩
        /// </summary>
        /// <param name="bean"></param>
        public void AddChargPile(ChargPile bean) 
        {
            _chargStationDal.AddChargPile(bean);
        }
        /// <summary>
        /// 删除分支箱
        /// </summary>
        /// <param name="zhanbh"></param>
        public void DelBranch(decimal? zhanbh) 
        {
            _chargStationDal.DelBranch(zhanbh);
        }
        /// <summary>
        /// 删除充电桩
        /// </summary>
        /// <param name="boxids"></param>
        public void DelPile(string boxids) 
        {
            string[] arrboxid = boxids.Split('_');
            _chargStationDal.DelPile(arrboxid);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bean"></param>
        /// <returns></returns>
        public override bool Exist(ChargStation bean)
        {
            return _chargStationDal.Exist(bean);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bean"></param>
        public override void Add(ChargStation bean)
        {
            _chargStationDal.Add(bean);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bean"></param>
        public override void Del(ChargStation bean)
        {
            _chargStationDal.Del(bean);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bean"></param>
        public override void Modify(ChargStation bean)
        {
            _chargStationDal.Modify(bean);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bean"></param>
        /// <returns></returns>
        public override DataTable Query(ChargStation bean)
        {
            return _chargStationDal.Query(bean);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bean"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public override DataTable QueryByPage(ChargStation bean, int page, int rows)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bean"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public override DataTable QueryByPage(ChargStation bean, int page, int rows, ref int count)
        {
            return _chargStationDal.QueryByPage(bean, page, rows, ref count);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public DataTable GetZhuangLei_X(string str)
        {
            return _chargStationDal.GetZhuangLei_X(str);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="zhanbh"></param>
        /// <returns></returns>
        public DataTable QueryBoxCounts(decimal zhanbh) 
        {
            return _chargStationDal.QueryBoxCounts(zhanbh);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Int32 FindByChargPileCount(Int32 id)
        {
            var dt = _chargStationDal.FindByChargPileCount(id);
            return Int32.Parse(dt.Rows[0]["count"].ToString());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="zhanbh"></param>
        /// <returns></returns>
        public DataTable QueryChargStationBYID(decimal zhanbh) 
        {
            return _chargStationDal.QueryChargStationBYID(zhanbh);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="chargpile"></param>
        public void EditPile(ChargPile chargpile) 
        {
            _chargStationDal.EditPile(chargpile);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void DelBoxByBoxid(decimal id) 
        {
            _chargStationDal.DelBoxByBoxid(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void DelPileByBoxid(decimal id) 
        {
            _chargStationDal.DelPileByBoxid(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetPictureid()
        {
            string id = System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString().PadLeft(2, '0') + System.DateTime.Now.Day.ToString().PadLeft(2, '0') + System.DateTime.Now.Hour.ToString().PadLeft(2, '0') + System.DateTime.Now.Minute.ToString().PadLeft(2, '0') + System.DateTime.Now.Millisecond.ToString().PadLeft(3, '0');
            int i = new System.Random().Next(0, 5);
            int k = new System.Random().Next(0, 9);
            id = id + i.ToString() + k.ToString();
            return id;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bean"></param>
        public void ModifyStation(ChargStation bean) 
        {
            _chargStationDal.ModifyStation(bean);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void DelStationTP(decimal id) 
        {
            _chargStationDal.DelStationTP(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="zhanmc"></param>
        /// <returns></returns>
        public DataTable QueryZhanByZMC(string zhanmc) 
        {
            return _chargStationDal.QueryZhanByZMC(zhanmc);
        }
        /// <summary>
        /// 根据站简称获取站信息
        /// </summary>
        /// <param name="zhanjc"></param>
        /// <returns></returns>
        public DataTable QueryZhanByZJC(string zhanjc)
        {
            return _chargStationDal.QueryZhanByZJC(zhanjc);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bean"></param>
        public void AddPilePicture(ChargStationFile bean) 
        {
            _chargStationDal.AddPilePicture(bean);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="zhanmc"></param>
        /// <returns></returns>
        public bool QueryZhanIFExit(string zhanmc)
        {
            DataTable dt = _chargStationDal.QueryZhanByZMC(zhanmc);
            bool b=true;
            if(dt.Rows.Count>0)
            {
                b= false;
            }
            return b;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="zhanbh"></param>
        /// <returns></returns>
        public DataTable QueryMaxBrachno(decimal zhanbh) 
        {
            return _chargStationDal.QueryMaxBrachno(zhanbh);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="zhanbh"></param>
        /// <returns></returns>
        public DataTable GetBoxByZhanID(decimal zhanbh) 
        {
            return _chargStationDal.GetBoxByZhanID(zhanbh);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="boxid"></param>
        /// <returns></returns>
        public DataTable GetPileByBoxid(decimal boxid) 
        {
            return _chargStationDal.GetPileByBoxid(boxid);
        }
        /// <summary>
        /// 通过站编号获取站信息
        /// </summary>
        /// <param name="zhanbh"></param>
        /// <returns></returns>
        public DataTable GetstationByid(decimal zhanbh) 
        {
            return _chargStationDal.GetstationByid(zhanbh);
        }
        /// <summary>
        /// 根据站编号获取树节点
        /// </summary>
        public string GetAllNodes()
        {
            string nId = string.Empty; // 节点id
            string nName = string.Empty; // 节点名称 
            string pId = string.Empty; // 上级节点id
            StringBuilder NodeStr = new StringBuilder(); //节点json字符串
            ChargStation bean = new ChargStation();
            NodeStr.Append("[");
            DataTable dta = Queryall(bean);//查询所有充电站
            if (dta.Rows.Count > 0)
            {
                for (int a = 0; a < dta.Rows.Count; a++)
                {
                    decimal zhanbh = decimal.Parse(dta.Rows[a]["zhan_bh"].ToString());
                    string zhanmc = dta.Rows[a]["zhan_jc"].ToString();
                    DataTable dt = GetBoxByZhanID(zhanbh);//根据充电站查询分支箱
                    string zhanid = zhanbh.ToString() + "_z";
                    
                    NodeStr.Append("{id:'" + zhanid + "',pId:0,name:'" + zhanmc + "', icon:'../../Images/1_open.png',isParent:true },");
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            decimal boxid = decimal.Parse(dt.Rows[i]["branchno"].ToString());//类型编号
                            nName = "分支箱—" + (i+1);
                            nId = boxid + "_f";
                            DataTable codeDt = GetPileByBoxid(boxid);//根据分支箱查询充电桩
                            var haveNodes = codeDt.Rows.Count > 0 ? "yes" : "no";
                            NodeStr.Append("{id:'" + nId + "',pId:'" + zhanid + "',name:'" + nName + "', icon:'../../Images/box.png',haveNodes:'" + haveNodes + "',isParent:true },");

                            for (int j = 0; j < codeDt.Rows.Count; j++)
                            {
                                string deleteflag = codeDt.Rows[j]["DELETEFLAG"].ToString();
                                if (deleteflag == "")
                                {
                                    string pileid = codeDt.Rows[j]["DEV_CHARGPILE"].ToString();
                                    string yxbh = codeDt.Rows[j]["YUNXING_BH"].ToString();
                                    string mc = "";
                                    if (yxbh == "")
                                    {
                                        mc = "充电桩" + yxbh;
                                    }
                                    else 
                                    {
                                        mc = "充电桩—" + yxbh;
                                    }
                                    string id = pileid + "_zu";
                                    string strPic = "pile.png";
                                    if (codeDt.Rows[j]["zhuangtai"].ToString() == "未投运")
                                    {
                                        strPic = "pileno.png";
                                    }
                                    NodeStr.Append("{id:'" + id + "',pId:'" + nId + "',name:'" + mc + "', icon:'../../Images/" + strPic + "'},");
                                }
                                
                            }
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

            string lx = nodeid.Split('_')[1];
            decimal id = decimal.Parse(nodeid.Split('_')[0].ToString());
            NodeStr.Append("[");
            if (lx == "z")
            {
                DataTable Dt = GetBoxByZhanID(id);

                for (int i = 0; i < Dt.Rows.Count; i++)
                {
                    decimal boxid = decimal.Parse(Dt.Rows[i]["branchno"].ToString());
                    nId = boxid + "_f"; // 节点id
                    nName = "分支箱—" + (i+1); // 节点名称
                    DataTable De = GetPileByBoxid(boxid);
                    var haveNodes = De.Rows.Count > 0 ? "yes" : "no";
                    NodeStr.Append("{id:'" + nId + "',pId:'" + nodeid + "' ,name:'" + nName + "',icon:'../../Images/box.png',haveNodes:'" + haveNodes + "',isParent:true},");

                    for (int j = 0; j < De.Rows.Count; j++)
                    {
                        string deleteflag = De.Rows[j]["DELETEFLAG"].ToString();
                        if (deleteflag == "")
                        {
                            string pileid = De.Rows[j]["DEV_CHARGPILE"].ToString();
                            string yxbh = De.Rows[j]["YUNXING_BH"].ToString();
                            if (yxbh == "")
                            {
                                nName = "充电桩" + yxbh;
                            }
                            else
                            {
                                nName = "充电桩—" + yxbh;
                            }
                            pileid = pileid + "_zu";
                            string strPic = "pile.png";
                            if (De.Rows[j]["zhuangtai"].ToString() == "未投运")
                            {
                                strPic = "pileno.png";
                            }
                            NodeStr.Append("{id:'" + pileid + "',pId:'" + nId + "',name:'" + nName + "', icon:'../../Images/" + strPic + "'},");
                        }
                        
                    }

                }

            }
            else if (lx == "f")
            {
                DataTable codeDt = GetPileByBoxid(id);

                for (int i = 0; i < codeDt.Rows.Count; i++)
                {
                    string deleteflag = codeDt.Rows[i]["DELETEFLAG"].ToString();
                    if (deleteflag == "")
                    {
                        decimal pileid = decimal.Parse(codeDt.Rows[i]["DEV_CHARGPILE"].ToString());
                        string yxbh = codeDt.Rows[i]["YUNXING_BH"].ToString();
                        nId = pileid + "_zu"; // 节点id
                        // 节点名称
                        string mc = "";
                        if (yxbh == "")
                        {
                            mc = "充电桩" + yxbh;
                        }
                        else
                        {
                            mc = "充电桩—" + yxbh;
                        }
                        string strPic = "pile.png";
                        if (codeDt.Rows[i]["zhuangtai"].ToString() == "未投运")
                        {
                            strPic = "pileno.png";
                        }
                        NodeStr.Append("{id:'" + nId + "',pId:'" + nodeid + "' ,name:'" + mc + "',icon:'../../Images/" + strPic + "'},");
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
        /// 查询充电站list
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public List<ChargStation> GetChargStationList(int page, int rows,ref int total) 
        {
            return _chargStationDal.GetChargStationList(page,rows,ref total);
        }

        /// <summary>
        /// 查询充电站信息
        /// </summary>
        /// <param name="bean"></param>
        /// <returns></returns>
        public DataTable Queryall(ChargStation bean) 
        {
            return _chargStationDal.Query(bean);
        }

        public DataTable GetBoxsl(decimal zhanbh) 
        {
            return _chargStationDal.GetBoxsl(zhanbh);
        }

        public DataTable GetPicture(decimal zhanbh) 
        {
            return _chargStationDal.GetPicture(zhanbh);
        }
        public void DelPicture(string id) 
        {
            _chargStationDal.DelPicture(id);
        }
    }
}

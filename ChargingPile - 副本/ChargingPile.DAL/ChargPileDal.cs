using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChargingPile.Model;
using System.Data;

namespace ChargingPile.DAL
{
    public class ChargPileDal : BaseDal<ChargPile>
    {
        /// <summary>
        /// 根据分支箱id查询充电桩
        /// </summary>
        /// <param name="boxid"></param>
        /// <returns></returns>
        public DataTable QueryBoxid(decimal? boxid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from dev_chargpile where BOX_ID={0} ");
            object[] parameters = new object[] { 
                boxid
            };
            DataTable dt = new DataTable();
            try
            {
                dt = Oop.GetDataTable(strSql.ToString(), parameters);
            }
            catch (Exception e)
            {
                Log.Error("查询充电桩失败！", e);
            }
            return dt;
        }
        /// <summary>
        /// 根据dtuid查询充电桩
        /// </summary>
        /// <param name="dtuid"></param>
        /// <returns></returns>
        public DataTable QueryBYdtuid(string dtuid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from dev_chargpile where dtu_id={0} ");
            object[] parameters = new object[] { 
                dtuid
            };
            DataTable dt = new DataTable();
            try
            {
                dt = Oop.GetDataTable(strSql.ToString(), parameters);
            }
            catch (Exception e)
            {
                Log.Error("查询充电桩失败！", e);
            }
            return dt;

        }

        /// <summary>
        /// 根据分支箱id查询充电桩
        /// </summary>
        /// <param name="boxid"></param>
        /// <returns></returns>
        public DataTable QueryChargPileID(decimal? boxid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select max(dev_chargpile)as dev_chargpile  from dev_chargpile where BOX_ID={0} ");
            object[] parameters = new object[] { 
                boxid
            };
            DataTable dt = new DataTable();
            try
            {
                dt = Oop.GetDataTable(strSql.ToString(), parameters);
            }
            catch (Exception e)
            {
                Log.Error("查询充电桩失败！", e);
            }
            return dt;
        }
        /// <summary>
        /// 根据运行编号查询充电桩
        /// </summary>
        /// <param name="yxbh"></param>
        /// <returns></returns>
        public DataTable QueryPileByYXBH(string yxbh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from dev_chargpile where YUNXING_BH={0} ");
            object[] parameters = new object[] { 
                yxbh
            };
            DataTable dt = new DataTable();
            try
            {
                dt = Oop.GetDataTable(strSql.ToString(), parameters);
            }
            catch (Exception e)
            {
                Log.Error("查询充电桩失败！", e);
            }
            return dt;
        }
        /// <summary>
        /// 根据运行编号站编号查询充电桩
        /// </summary>
        /// <param name="yxbh"></param>
        /// <returns></returns>
        public DataTable QueryPileByYXBHandZBH(string yxbh,string zhanbh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from dev_chargpile a,dev_branch b where a.box_id=b.branchno  ");
            strSql.Append(" and a.YUNXING_BH={0} and b.zhuan_bh={1} ");
            object[] parameters = new object[] { 
                yxbh,
                zhanbh
            };
            DataTable dt = new DataTable();
            try
            {
                dt = Oop.GetDataTable(strSql.ToString(), parameters);
            }
            catch (Exception e)
            {
                Log.Error("查询充电桩失败！", e);
            }
            return dt;
        }
        /// <summary>
        /// 根据运行编号和桩id查询充电桩
        /// </summary>
        /// <param name="yxbh"></param>
        /// <returns></returns>
        public DataTable QueryPileByYXBHandID(string yxbh, string id, string zhanbh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from dev_chargpile a,dev_branch b where  a.box_id=b.branchno  ");
            strSql.Append(" and a.YUNXING_BH={0} and a.DEV_CHARGPILE={1} and b.zhuan_bh={2} ");
            object[] parameters = new object[] { 
                yxbh,
                id,
                zhanbh
            };
            DataTable dt = new DataTable();
            try
            {
                dt = Oop.GetDataTable(strSql.ToString(), parameters);
            }
            catch (Exception e)
            {
                Log.Error("查询充电桩失败！", e);
            }
            return dt;
        }
        /// <summary>
        /// 根据桩名称查询充电桩
        /// </summary>
        /// <param name="zhuangmc"></param>
        /// <returns></returns>
        public DataTable QueryPileByZMC(string zhuangmc)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from dev_chargpile where POWERPILENAME={0} ");
            object[] parameters = new object[] { 
                zhuangmc
            };
            DataTable dt = new DataTable();
            try
            {
                dt = Oop.GetDataTable(strSql.ToString(), parameters);
            }
            catch (Exception e)
            {
                Log.Error("查询充电桩失败！", e);
            }
            return dt;
        }
        /// <summary>
        /// 根据充电站获取分支箱
        /// </summary>
        /// <param name="zhanbh"></param>
        /// <returns></returns>
        public DataTable QueryBranch(string zhanbh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from dev_branch where 1=1");
            if (zhanbh != "0")
            {
                strSql.Append(" and zhuan_bh='" + zhanbh + "' ");
            }
            DataTable dt = new DataTable();
            try
            {
                dt = Oop.GetDataTable(strSql.ToString());
            }
            catch (Exception e)
            {
                Log.Error("查询分支箱失败！", e);
            }
            return dt;
        }
        /// <summary>
        /// 获取桩厂家
        /// </summary>
        /// <returns></returns>
        public DataTable QueryChangJia()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select distinct CHANGJIA from dev_powerpiletypes");
            DataTable dt = new DataTable();
            try
            {
                dt = Oop.GetDataTable(strSql.ToString());
            }
            catch (Exception e)
            {
                Log.Error("查询厂家失败！", e);
            }
            return dt;
        }
        /// <summary>
        /// 根据桩厂家获取桩型号
        /// </summary>
        /// <param name="cj"></param>
        /// <returns></returns>
        public DataTable QueryXHBYCJ(string cj)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select ZHUANGXING_H,ZHUANGLEI_X from dev_powerpiletypes where 1=1 ");
            if (!string.IsNullOrEmpty(cj))
            {
                strSql.Append(" and CHANGJIA='" + cj + "' ");
            }
            DataTable dt = new DataTable();
            try
            {
                dt = Oop.GetDataTable(strSql.ToString());
            }
            catch (Exception e)
            {
                Log.Error("根据厂家查询桩型号失败！", e);
            }
            return dt;
        }
        /// <summary>
        /// 根据桩型号和桩厂家获取桩类型
        /// </summary>
        /// <param name="xh"></param>
        /// <returns></returns>
        public DataTable QueryLXBYXH(string xh,string cj)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from dev_powerpiletypes where ZHUANGXING_H={0} and CHANGJIA={1} ");
            object[] parameters = new object[] { 
                xh,
                cj
            };
            DataTable dt = new DataTable();
            try
            {
                dt = Oop.GetDataTable(strSql.ToString(), parameters);
            }
            catch (Exception e)
            {
                Log.Error("根据桩型号和桩厂家获取桩类型失败！", e);
            }
            return dt;
        }
        public DataTable QueryBoxidByPileID(decimal? pileID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from dev_chargpile where dev_chargpile={0} ");
            object[] parameters = new object[] { 
                pileID
            };
            DataTable dt = new DataTable();
            try
            {
                dt = Oop.GetDataTable(strSql.ToString(), parameters);
            }
            catch (Exception e)
            {
                Log.Error("根据桩编号查询桩信息失败！", e);
            }
            return dt;
        }
        /// <summary>
        /// 添加充电桩
        /// </summary>
        /// <param name="chargpile"></param>
        public void AddChargPile(ChargPile chargpile)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" insert into dev_chargpile(DEV_CHARGPILE,BOX_ID,DTU_ID,PILETYPEID,ZONGXIAN_DZ,CHANGJIAO_BH,YUNXING_BH,TOUYOU_SJ,ZHUANGTAI,ZHICHAN_BH,YUNWEI_DW,DELETEFLAG,CREATEDT,UPDATEDT,POWERPILENAME) values ");
            strSql.Append(" ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14})");
            object[] parameters = new object[] {
                chargpile.DEV_CHARGPILE,
                chargpile.BOX_ID,
                chargpile.DTU_ID,
                chargpile.PILETYPEID,
                chargpile.ZONGXIAN_DZ,
                chargpile.CHANGJIAO_BH,
                chargpile.YUNXING_BH,
                chargpile.TOUYOU_SJ,
                chargpile.ZHUANGTAI,
                chargpile.ZHICHAN_BH,
                chargpile.YUNWEI_DW,
                chargpile.DELETEFLAG,
                chargpile.CREATEDT,
                chargpile.UPDATEDT,
                chargpile.POWERPILENAME
            };
            try
            {
                Oop.Execute(strSql.ToString(), parameters);
            }
            catch (Exception e)
            {
                Log.Error("添加充电桩失败！", e);
            }
        }
        /// <summary>
        /// 根据桩id删除充电桩
        /// </summary>
        /// <param name="chargpile"></param>
        public void EditChargPile(ChargPile chargpile)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update dev_chargpile set ");
            strSql.Append(" BOX_ID={0},DTU_ID={1},PILETYPEID={2},ZONGXIAN_DZ={3},CHANGJIAO_BH={4},YUNXING_BH={5},TOUYOU_SJ={6},ZHUANGTAI={7},ZHICHAN_BH={8},YUNWEI_DW={9},DELETEFLAG={10},CREATEDT={11},UPDATEDT={12} ");
            strSql.Append(" where dev_chargpile={13} ");
            object[] parameters = new object[] {
                chargpile.BOX_ID,
                chargpile.DTU_ID,
                chargpile.PILETYPEID,
                chargpile.ZONGXIAN_DZ,
                chargpile.CHANGJIAO_BH,
                chargpile.YUNXING_BH,
                chargpile.TOUYOU_SJ,
                chargpile.ZHUANGTAI,
                chargpile.ZHICHAN_BH,
                chargpile.YUNWEI_DW,
                chargpile.DELETEFLAG,
                chargpile.CREATEDT,
                chargpile.UPDATEDT,
                chargpile.DEV_CHARGPILE
            };
            try
            {
                Oop.Execute(strSql.ToString(), parameters);
            }
            catch (Exception e)
            {
                Log.Error("修改充电桩失败！", e);
            }
        }
        /// <summary>
        /// 根据桩id删除充电桩
        /// </summary>
        /// <param name="pileId"></param>
        public void DelChargPile(string pileId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update dev_chargpile set DELETEFLAG={0} ");
            strSql.Append(" where DEV_CHARGPILE={1} ");
            object[] parameters = new object[] {
                1,
                pileId
            };
            try
            {
                Oop.Execute(strSql.ToString(), parameters);
            }
            catch (Exception e)
            {
                Log.Error("删除充电桩失败！", e);
            }
        }
        /// <summary>
        /// 根据充电桩id获取充电桩
        /// </summary>
        /// <param name="pilebh"></param>
        /// <returns></returns>
        public DataTable QueryChargPileByPilebh(decimal pilebh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select c.dev_chargpile,c.POWERPILENAME,c.ZONGXIAN_DZ,c.box_id ,c.dtu_id,c.changjiao_bh,c.yunxing_bh,c.touyou_sj,c.zhuangtai,c.remark,p.changjia,p.zhuanglei_x,p.zhuangxing_h ");
            strSql.Append(" from dev_chargpile c,dev_powerpiletypes p where p.parserkey=c.piletypeid and c.dev_chargpile='" + pilebh + "' ");

            DataTable dt = new DataTable();
            try
            {
                dt = Oop.GetDataTable(strSql.ToString());
            }
            catch (Exception e)
            {
                Log.Error("查询充电桩失败！", e);
            }
            return dt;
        }
        /// <summary>
        /// 获取充电桩
        /// </summary>
        /// <param name="bmbh"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public List<ChargPile> GetChargPileList(decimal zhanbh, int page, int rows, ref int total)
        {
            List<ChargPile> cplist = new List<ChargPile>();
            DataTable dt;
            if (zhanbh != 0)
            {
                total = GetCountsByZhanbh(zhanbh);
                dt = GetCpileByZHANID(zhanbh, page, rows);
            }
            else
            {
                total = GetCounts();
                dt = GetallCpile(page, rows);
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ChargPile bean = new ChargPile();
                DataRow dr = dt.Rows[i];
                bean.DEV_CHARGPILE = decimal.Parse(dr["DEV_CHARGPILE"].ToString());
                bean.BOX_ID = decimal.Parse(dr["BOX_ID"].ToString());
                bean.CHANGJIAO_BH = dr["CHANGJIAO_BH"].ToString();
                bean.YUNXING_BH = dr["YUNXING_BH"].ToString();
                if (dr["TOUYOU_SJ"].ToString() == "" || dr["TOUYOU_SJ"] == null)
                    bean.TOUYOU_SJ = new DateTime();
                else
                    bean.TOUYOU_SJ = DateTime.Parse(dr["TOUYOU_SJ"].ToString());
                bean.ZHUANGTAI = dr["ZHUANGTAI"].ToString();
                bean.CHANGJIA = dr["CHANGJIA"].ToString();
                bean.ZHUANGLEI_X = dr["ZHUANGLEI_X"].ToString();
                bean.ZHUANGXING_H = dr["ZHUANGXING_H"].ToString();

                cplist.Add(bean);
            }
            return cplist;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="zhanbh"></param>
        /// <returns></returns>
        public int GetCountsByZhanbh(decimal zhanbh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select count(t.dev_chargpile)as zcounts from dev_chargpile t,dev_branch b,dev_chargstation c where t.box_id=b.branchno and b.zhuan_bh=c.zhan_bh and c.zhan_bh={0}");
            object[] pams = new object[]
            {
                zhanbh
            };
            DataTable dt = new DataTable();
            int couts = 0;
            try
            {
                dt = Oop.GetDataTable(strSql.ToString(), pams);
                couts = int.Parse(dt.Rows[0]["zcounts"].ToString());
            }
            catch (Exception e)
            {
                Log.Error("查询充电桩失败！", e);
            }
            return couts;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="zhanbh"></param>
        /// <returns></returns>
        public int GetCounts()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select count(t.dev_chargpile)as zcounts from dev_chargpile t");
            DataTable dt = new DataTable();
            int couts = 0;
            try
            {
                dt = Oop.GetDataTable(strSql.ToString());
                couts = int.Parse(dt.Rows[0]["zcounts"].ToString());
            }
            catch (Exception e)
            {
                Log.Error("查询充电桩失败！", e);
            }
            return couts;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="zhanbh"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public DataTable GetCpileByZHANID(decimal zhanbh, int page, int rows)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select B.* from (select A.*,rownum rn from (select t.dev_chargpile,t.box_id ,t.changjiao_bh,t.yunxing_bh,t.touyou_sj,t.zhuangtai,p.changjia,p.zhuanglei_x,p.zhuangxing_h ");
            strSql.Append("  from dev_chargpile t,dev_branch b,dev_chargstation c,dev_powerpiletypes p  ");
            strSql.Append(" where t.box_id=b.branchno and b.zhuan_bh=c.zhan_bh and t.piletypeid=p.parserkey and c.zhan_bh={0} order by t.box_id ");
            strSql.Append(" ) A where rownum<='" + page + "'*'" + rows + "') B where rn>('" + page + "'-1)*'" + rows + "' ");
            try
            {
                return Oop.GetDataTable(strSql.ToString(), zhanbh);
            }
            catch (Exception e)
            {
                Log.Error("查询人员信息失败！", e);
                throw e;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="zhanbh"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public DataTable GetallCpile(int page, int rows)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select B.* from (select A.*,rownum rn from (select t.dev_chargpile,t.box_id ,t.changjiao_bh,t.yunxing_bh,t.touyou_sj,t.zhuangtai,p.changjia,p.zhuanglei_x,p.zhuangxing_h  ");
            strSql.Append("  from dev_chargpile t,dev_branch b,dev_chargstation c,dev_powerpiletypes p  ");
            strSql.Append(" where t.box_id=b.branchno and b.zhuan_bh=c.zhan_bh and t.piletypeid=p.parserkey order by t.box_id ");
            strSql.Append(" ) A where rownum<='" + page + "'*'" + rows + "') B where rn>('" + page + "'-1)*'" + rows + "' ");
            try
            {
                return Oop.GetDataTable(strSql.ToString());
            }
            catch (Exception e)
            {
                Log.Error("查询人员信息失败！", e);
                throw e;
            }
        }

        public override bool Exist(ChargPile bean)
        {
            throw new NotImplementedException();
        }

        public override void Add(ChargPile bean)
        {
            throw new NotImplementedException();
        }

        public override void Del(ChargPile bean)
        {
            throw new NotImplementedException();
        }

        public override void Modify(ChargPile bean)
        {
            throw new NotImplementedException();
        }

        public override System.Data.DataTable Query(ChargPile bean)
        {
            throw new NotImplementedException();
        }

        public override System.Data.DataTable QueryByPage(ChargPile bean, int page, int rows)
        {
            throw new NotImplementedException();
        }

        public override System.Data.DataTable QueryByPage(ChargPile bean, int page, int rows, ref int count)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// 根据桩id获取桩基本信息
        /// </summary>
        /// <param name="zhuanid"></param>
        /// <returns></returns>
        public DataTable FindByChargePileDetailInfo(int zhuanid)
        {
            Log.Debug("FindBy:方法参数：");
            var sql = new StringBuilder();
            sql.Append("select dppt.changjia,dcp.changjiao_bh,dcp.yunxing_bh,dppt.zhuanglei_x,");
            sql.Append("to_char(dcp.touyou_sj,'yyyy-MM') tysj,");
            sql.Append("(select gpc.Eff_max from gat_pointcfg gpc where gpc.gatitemid='ZhuiG_YXDL' and gpc.piletypeid=dcp.piletypeid) zgyxdl, ");
            sql.Append("(select gpc.Eff_max from gat_pointcfg gpc where gpc.gatitemid='ZhuiG_YXDY' and gpc.piletypeid=dcp.piletypeid) zgyxdy, ");
            sql.Append("(select ccp.price/100 from cfg_chargprice ccp where ccp.pricetype='000') fjg,");
            sql.Append("(select ccp.price/100 from cfg_chargprice ccp where ccp.pricetype='001') gjg,");
            sql.Append("(select ccp.price/100 from cfg_chargprice ccp where ccp.pricetype='002') pjg,");
            sql.Append("(select ccp.price/100 from cfg_chargprice ccp where ccp.pricetype='003') jjg,");
            sql.Append("(select ccp.price/100 from cfg_chargprice ccp where ccp.pricetype='004') ftjg ");
            sql.Append("from dev_chargpile dcp inner join dev_powerpiletypes dppt on dcp.piletypeid = dppt.parserkey ");
            sql.Append("where dcp.dev_chargpile=" + zhuanid + "");
            return Oop.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 根据桩id获取桩类型
        /// </summary>
        /// <param name="zhuanid"></param>
        /// <returns></returns>
        public DataTable FindByChargePileType(int zhuanid)
        {
            Log.Debug("FindBy:方法参数：");
            var sql = new StringBuilder();
            sql.Append("select t.piletypeid from dev_chargpile t ");
            sql.Append("where t.dev_chargpile=" + zhuanid + "");
            return Oop.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 查询充电桩总数量
        /// </summary>
        /// <returns></returns>
        public DataTable FindByChargePileCount()
        {
            Log.Debug("FindBy:方法参数：");
            var sql = new StringBuilder();
            sql.Append("select count(*) count ");
            sql.Append("from dev_chargpile t ");
            sql.Append("where t.deleteflag is null ");
            return Oop.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 查询场站桩数量
        /// </summary>
        /// <returns></returns>
        public DataTable FindByChargePileStationCount()
        {
            Log.Debug("FindByChargingPileZje:方法参数：");
            var sql = new StringBuilder();
            sql.Append("select dcs.zhan_jc zhanjc,count(dcp.dev_chargpile) count ");
            sql.Append("from  dev_chargpile dcp  ");
            sql.Append("inner join dev_branch db on db.branchno=dcp.box_id ");
            sql.Append("inner join dev_chargstation dcs on dcs.zhan_bh=db.zhuan_bh ");
            sql.Append("where dcp.deleteflag is null ");
            sql.Append("group by dcs.zhan_jc ");
            return Oop.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 根据充电桩id获取充电站名称和充电桩编号
        /// </summary>
        /// <param name="zhuanid"></param>
        /// <returns></returns>
        public DataTable QueryByParam(string zhuanid)
        {
            Log.Debug("FindByChargingPileZje:方法参数：");
            var sql = new StringBuilder();
            sql.Append("select dcs.zhan_jc,dcp.yunxing_bh ");
            sql.Append("from dev_chargstation dcs   ");
            sql.Append("inner join dev_branch db on db.zhuan_bh=dcs.zhan_bh ");
            sql.Append("inner join dev_chargpile dcp on dcp.box_id=db.branchno ");
            sql.Append("where dcp.dev_chargpile=" + zhuanid);
            return Oop.GetDataTable(sql.ToString());
        }
    }
}


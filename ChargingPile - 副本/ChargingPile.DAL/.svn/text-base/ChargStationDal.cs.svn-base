using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ChargingPile.Model;

namespace ChargingPile.DAL
{
    public class ChargStationDal : BaseDal<ChargStation>
    {
       
        public DataTable GetAllStation(int page, int rows)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select B.* from (select A.*,rownum rn from (select c.zhan_bh as zhanbh,c.zhuan_mc as zhuanmc,c.zhan_jc,c.xiangxi_dz as xiangxidz,c.longtude,c.latitude,c.yezhu_dw as yezhudw,c.lianxi_r as lianxir, ");
            strSql.Append(" c.lianxi_dh as lianxidh, c.zhuangchang_j as zhuangchangj,c.zhuanglei_x as zhuangleix,c.createdt,c.touyun_sj, ");
            strSql.Append(" (select count(t.dev_chargpile) from dev_chargpile t,dev_branch b where t.box_id=b.branchno and b.zhuan_bh=c.zhan_bh and t.deleteflag is null) as counts, ");
            strSql.Append(" (select count(b.branchno) from dev_branch b where b.zhuan_bh=c.zhan_bh) as boxcounts from dev_chargstation c  order by c.createdt desc,c.zhuan_mc");
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetCounts()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select count(zhan_bh)as zcounts from dev_chargstation ");
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
        /// 查询充电站list
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public List<ChargStation> GetChargStationList(int page, int rows, ref int total)
        {
            List<ChargStation> cplist = new List<ChargStation>();
            DataTable dt;
            total = GetCounts();
            dt = GetAllStation(page, rows);

            dt.Columns.Add("ZhuangXing_H");
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                var xh = "";
                string[] arrlx = dt.Rows[j]["zhuangleix"].ToString().Split(',');
                for (int i = 0; i < arrlx.Length; i++)
                {
                    if (arrlx[i] != "")
                    {
                        DataTable de = GetZhuangLei_X(arrlx[i]);
                        if(de.Rows.Count>0)
                        {
                            xh += de.Rows[0]["ZHUANGXING_H"].ToString();
                            if (i < arrlx.Length - 1)
                            {
                                xh += ",";
                            }
                        }
                        dt.Rows[j]["ZhuangXing_H"] = xh;
                    }
                    else
                    {
                        dt.Rows[j]["ZhuangXing_H"] = "";
                    }

                }
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ChargStation bean = new ChargStation();
                DataRow dr = dt.Rows[i];
                bean.ZhanBh = decimal.Parse(dr["zhanbh"].ToString());
                bean.ZhuanMc = dr["zhuanmc"].ToString();
                bean.Zhan_Jc = dr["zhan_jc"].ToString();
                bean.XiangXiDz = dr["xiangxidz"].ToString();
                bean.YeZhuDw = dr["yezhudw"].ToString();
                if (dr["latitude"].ToString()!="")
                    bean.Latitude = decimal.Parse(dr["latitude"].ToString());
                if (dr["longtude"].ToString()!= "")
                    bean.Longtude = decimal.Parse(dr["longtude"].ToString());
                bean.LianXiR = dr["lianxir"].ToString();
                bean.LianXiDh = dr["lianxidh"].ToString();
                bean.ZhuangChangJ = dr["zhuangchangj"].ToString();
                bean.ZhuangLeiX = dr["zhuangleix"].ToString();
                bean.ZhuangXing_H = dr["ZhuangXing_H"].ToString();
                bean.Counts = decimal.Parse(dr["counts"].ToString());
                bean.BoxCounts = decimal.Parse(dr["boxcounts"].ToString());
                cplist.Add(bean);
            }
            return cplist;
        }
        /// <summary>
        /// 查询桩类型
        /// </summary>
        /// <returns></returns>
        public DataTable QueryPileType()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select DISTINCT changjia from dev_powerpiletypes ");
            DataTable dt = new DataTable();
            try
            {
                dt = Oop.GetDataTable(strSql.ToString());
            }
            catch (Exception e)
            {
                Log.Error("查询充电桩类型失败！", e);
            }
            return dt;
        }

        /// <summary>
        /// 通过充电站查询充电桩
        /// </summary>
        /// <param name="zhanbh"></param>
        /// <returns></returns>
        public DataTable QueryPile(string zhanbh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select c.DEV_CHARGPILE,c.BOX_ID,c.ZHUANGTAI,c.CHANGJIAO_BH,p.CHANGJIA,p.ZHUANGLEI_X,p.ZHUANGXING_H  ");
            strSql.Append(" from dev_powerpiletypes p, dev_chargpile c,dev_branch b,dev_chargstation s ");
            strSql.Append(" where c.box_id=b.branchno and b.zhuan_bh=s.zhan_bh and p.parserkey=c.piletypeid and s.zhan_bh={0} order by c.BOX_ID asc ");
            object[] parms = new object[] 
            {
                zhanbh
            };
            DataTable dt = new DataTable();
            try
            {
                dt = Oop.GetDataTable(strSql.ToString(), parms);
            }
            catch (Exception e)
            {
                Log.Error("查询充电桩类型失败！", e);
            }
            return dt;
        }
        /// <summary>
        /// 通过桩厂家查询桩型号
        /// </summary>
        /// <param name="cj"></param>
        /// <returns></returns>
        public DataTable QueryPileXH(string cj)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select zhuangxing_h from dev_powerpiletypes where changjia='" + cj + "' ");
            DataTable dt = new DataTable();
            try
            {
                dt = Oop.GetDataTable(strSql.ToString());
            }
            catch (Exception e)
            {
                Log.Error("查询充电桩类型失败！", e);
            }
            return dt;
        }
        /// <summary>
        /// 获取充电站id
        /// </summary>
        /// <returns></returns>
        public DataTable QueryZhanId()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select max(zhan_bh) as zhanbh from dev_chargstation ");
            DataTable dt = new DataTable();
            try
            {
                dt = Oop.GetDataTable(strSql.ToString());
            }
            catch (Exception e)
            {
                Log.Error("查询充电站编号失败！", e);
            }
            return dt;
        }
        /// <summary>
        /// 通过充电站获取分支箱
        /// </summary>
        /// <param name="zhanbh"></param>
        /// <returns></returns>
        public DataTable QueryBranch(decimal? zhanbh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from dev_branch where zhuan_bh={0} ");
            object[] parameters = new object[] { 
                zhanbh
            };
            DataTable dt = new DataTable();
            try
            {
                dt = Oop.GetDataTable(strSql.ToString(), parameters);
            }
            catch (Exception e)
            {
                Log.Error("查询分支箱失败！", e);
            }
            return dt;

        }
        /// <summary>
        /// 添加分支箱
        /// </summary>
        /// <param name="bean"></param>
        public void AddBranch(Branch bean)
        {
            Log.Debug("Add方法参数：" + bean.ToString());
            var sql1 = new StringBuilder();
            var sql2 = new StringBuilder();
            var i = 0;
            var list = new List<object>();
            if (bean.BranchNo != null)
            {
                sql1.Append(" branchno,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.BranchNo);
            }
            if (bean.ZhuanBh != null)
            {
                sql1.Append(" zhuan_bh,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.ZhuanBh);
            }
            if (!string.IsNullOrEmpty(bean.ChangJia))
            {
                sql1.Append(" changjia,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.ChangJia);
            }
            if (!string.IsNullOrEmpty(bean.FenZhiXlx))
            {
                sql1.Append(" fenzhi_xlx,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.FenZhiXlx);
            }
            if (bean.Createdt!=null)
            {
                sql1.Append(" createdt,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.Createdt);
            }
            if (sql1.Length > 0)
            {
                sql1 = sql1.Remove(sql1.Length - 1, 1);
                sql2 = sql2.Remove(sql2.Length - 1, 1);
            }
            var sql = "insert into dev_branch(" + sql1 + ") values(" + sql2 + ")";
            Oop.Execute(sql, list.ToArray());
        }
        /// <summary>
        /// 添加充电桩
        /// </summary>
        /// <param name="bean"></param>
        public void AddChargPile(ChargPile bean)
        {
            Log.Debug("Add方法参数：" + bean.ToString());
            var sql1 = new StringBuilder();
            var sql2 = new StringBuilder();
            var i = 0;
            var list = new List<object>();
            if (bean.DEV_CHARGPILE != null)
            {
                sql1.Append(" DEV_CHARGPILE,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.DEV_CHARGPILE);
            }
            if (bean.BOX_ID != null)
            {
                sql1.Append(" BOX_ID,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.BOX_ID);
            }
            if (!string.IsNullOrEmpty(bean.PILETYPEID))
            {
                sql1.Append(" PILETYPEID,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.PILETYPEID);
            }
            if (!string.IsNullOrEmpty(bean.ZHUANGTAI))
            {
                sql1.Append(" ZHUANGTAI,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.ZHUANGTAI);
            }
            if (bean.CREATEDT!=null)
            {
                sql1.Append(" CREATEDT,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.CREATEDT);
            }
            if (sql1.Length > 0)
            {
                sql1 = sql1.Remove(sql1.Length - 1, 1);
                sql2 = sql2.Remove(sql2.Length - 1, 1);
            }
            var sql = "insert into DEV_CHARGPILE(" + sql1 + ") values(" + sql2 + ")";
            Oop.Execute(sql, list.ToArray());
        }
        /// <summary>
        /// 删除分支箱
        /// </summary>
        /// <param name="zhanbh"></param>
        public void DelBranch(decimal? zhanbh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" delete from DEV_BRANCH ");
            strSql.Append(" where ZHUAN_BH={0} ");
            object[] parameters = new object[] {
                zhanbh
            };
            try
            {
                Oop.Execute(strSql.ToString(), parameters);
            }
            catch (Exception e)
            {
                Log.Error("删除分支箱失败！", e);
            }
        }
        public void DelStationFile(decimal? zhanbh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" delete from DEV_CHARGSTATIONFILE ");
            strSql.Append(" where ZHAN_BH={0} ");
            object[] parameters = new object[] {
                zhanbh
            };
            try
            {
                Oop.Execute(strSql.ToString(), parameters);
            }
            catch (Exception e)
            {
                Log.Error("删除图片失败！", e);
            }
        }
        /// <summary>
        /// 删除充电桩
        /// </summary>
        /// <param name="arrboxid"></param>
        public void DelPile(string[] arrboxid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" delete from DEV_CHARGPILE where BOX_ID in( ");
            for (int i = 0; i < arrboxid.Length; i++)
            {
                strSql.Append("  '" + arrboxid[i] + "' , ");
            }
            strSql.Remove(strSql.ToString().LastIndexOf(","), 1);
            strSql.Append(")");
            try
            {
                Oop.Execute(strSql.ToString());
            }
            catch (Exception e)
            {
                Log.Error("删除充电桩失败！", e);
            }
        }

        public override bool Exist(ChargStation bean)
        {
            Log.Debug("exist方法");
            var sql = "select * from dev_chargstation t where ZhanBh='" + bean.ZhanBh + "'";
            var dt = Oop.GetDataTable(sql);
            return dt.Rows.Count > 0;
        }

        public override void Add(ChargStation bean)
        {
            Log.Debug("Add方法参数：" + bean.ToString());
            var sql1 = new StringBuilder();
            var sql2 = new StringBuilder();
            var i = 0;
            var list = new List<object>();
            sql1.Append(" Zhan_Bh,");
            sql2.Append(" seq_zhanbh.nextval ,");
            if (!string.IsNullOrEmpty(bean.ZhuanMc))
            {
                sql1.Append(" Zhuan_Mc,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.ZhuanMc);
            }
            if (!string.IsNullOrEmpty(bean.Zhan_Jc))
            {
                sql1.Append(" Zhan_Jc,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.Zhan_Jc);
            }
            if (!string.IsNullOrEmpty(bean.YeZhuDw))
            {
                sql1.Append(" YeZhu_Dw,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.YeZhuDw);
            }
            if (!string.IsNullOrEmpty(bean.LianXiR))
            {
                sql1.Append(" LianXi_R,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.LianXiR);
            }
            if (!string.IsNullOrEmpty(bean.LianXiDh))
            {
                sql1.Append(" LianXi_Dh,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.LianXiDh);
            }
            if (!string.IsNullOrEmpty(bean.ZhuangLeiX))
            {
                sql1.Append(" ZhuangLei_X,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.ZhuangLeiX);
            }
            if (!string.IsNullOrEmpty(bean.ZhuangChangJ))
            {
                sql1.Append(" ZhuangChang_J,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.ZhuangChangJ);
            }
            if (!string.IsNullOrEmpty(bean.XiangXiDz))
            {
                sql1.Append(" XiangXi_Dz,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.XiangXiDz);
            }
            if (bean.Longtude != null)
            {
                sql1.Append(" Longtude,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.Longtude);
            }
            if (bean.Latitude != null)
            {
                sql1.Append(" Latitude,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.Latitude);
            }
            if (bean.JianZhan_Sj != null)
            {
                sql1.Append(" JianZhan_Sj,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.JianZhan_Sj);
            }
            if (bean.TouYun_Sj != null)
            {
                sql1.Append(" TouYun_Sj,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.TouYun_Sj);
            }
            if (sql1.Length > 0)
            {
                sql1 = sql1.Remove(sql1.Length - 1, 1);
                sql2 = sql2.Remove(sql2.Length - 1, 1);
            }                                        
            var sql = "insert into dev_chargstation(" + sql1 + ",CreateDT) values(" + sql2 + ",sysdate)";
            Oop.Execute(sql, list.ToArray());
        }

        public override void Del(ChargStation bean)
        {
            Log.Debug("del方法参数：");
            var sql = new StringBuilder();
            sql.Append("delete from dev_chargstation where Zhan_Bh='" + bean.ZhanBh + "'");
            Oop.Execute(sql.ToString());
        }

        public override void Modify(ChargStation bean)
        {
            Log.Debug("Modify方法参数：" + bean);
            var sql = new StringBuilder();
            sql.Append("update dev_chargstation set");
            var i = 0;
            var dList = new List<object>();
            if (!string.IsNullOrEmpty(bean.ZhuanMc))
            {
                sql.Append(" ZhuanMc={" + i++ + "},");
                dList.Add(bean.ZhuanMc);
            }
            if (!string.IsNullOrEmpty(bean.YeZhuDw))
            {
                sql.Append(" YeZhuDw={" + i++ + "},");
                dList.Add(bean.YeZhuDw);
            }
            if (!string.IsNullOrEmpty(bean.LianXiR))
            {
                sql.Append(" LianXiR={" + i++ + "},");
                dList.Add(bean.LianXiR);
            }
            if (!string.IsNullOrEmpty(bean.LianXiDh))
            {
                sql.Append(" LianXiDh={" + i++ + "},");
                dList.Add(bean.LianXiDh);
            }
            if (!string.IsNullOrEmpty(bean.ZhuangLeiX))
            {
                sql.Append(" ZhuangLeiX={" + i++ + "},");
                dList.Add(bean.ZhuangLeiX);
            }
            if (!string.IsNullOrEmpty(bean.ZhuangChangJ))
            {
                sql.Append(" ZhuangChangJ={" + i++ + "},");
                dList.Add(bean.ZhuangChangJ);
            }
            if (!string.IsNullOrEmpty(bean.XiangXiDz))
            {
                sql.Append(" XiangXiDz={" + i++ + "},");
                dList.Add(bean.XiangXiDz);
            }
            if (bean.Longtude != null)
            {
                sql.Append(" Longtude={" + i++ + "},");
                dList.Add(bean.Longtude);
            }
            if (bean.Latitude != null)
            {
                sql.Append(" Latitude={" + i++ + "},");
                dList.Add(bean.Latitude);
            }
            if (bean.CreateDT != null)
            {
                sql.Append(" CreateDT={" + i++ + "},");
                dList.Add(bean.CreateDT);
            }
            if (bean.TouYun_Sj != null)
            {
                sql.Append(" UpdateDT={" + i++ + "},");
                dList.Add(bean.TouYun_Sj);
            }
            if (sql.Length > 0)
            {
                sql = sql.Remove(sql.Length - 1, 1);
            }
            sql.Append(" where ZhanBh={" + i++ + "}");
            dList.Add(bean.ZhanBh);
            Oop.Execute(sql.ToString(), dList.ToArray());
        }

        public override DataTable Query(ChargStation bean)
        {
            Log.Debug("Query方法参数：" + bean);
            var sql = new StringBuilder();
            sql.Append("select t.* from dev_chargstation t where 1=1 ");
            var list = new List<object>();
            var i = -1;
            if (bean.ZhanBh != null)
            {
                sql.Append(" and Zhan_Bh={" + ++i + "}");
                list.Add(bean.ZhanBh);
            }
            if (!string.IsNullOrEmpty(bean.ZhuanMc))
            {
                sql.Append(" and ZhuanMc={" + ++i + "}");
                list.Add(bean.ZhuanMc);
            }
            if (!string.IsNullOrEmpty(bean.YeZhuDw))
            {
                sql.Append(" and YeZhuDw={" + ++i + "}");
                list.Add(bean.YeZhuDw);
            }
            if (!string.IsNullOrEmpty(bean.LianXiR))
            {
                sql.Append(" and LianXiR={" + ++i + "}");
                list.Add(bean.LianXiR);
            }
            if (!string.IsNullOrEmpty(bean.LianXiDh))
            {
                sql.Append(" and LianXiDh={" + ++i + "}");
                list.Add(bean.LianXiDh);
            }
            if (!string.IsNullOrEmpty(bean.ZhuangLeiX))
            {
                sql.Append(" and ZhuangLeiX={" + ++i + "}");
                list.Add(bean.ZhuangLeiX);
            }
            if (!string.IsNullOrEmpty(bean.ZhuangChangJ))
            {
                sql.Append(" and ZhuangChangJ={" + ++i + "}");
                list.Add(bean.ZhuangChangJ);
            }
            if (!string.IsNullOrEmpty(bean.XiangXiDz))
            {
                sql.Append(" and XiangXiDz={" + ++i + "}");
                list.Add(bean.XiangXiDz);
            }
            if (bean.Longtude != null)
            {
                sql.Append(" and Longtude={" + ++i + "}");
                list.Add(bean.Longtude);
            }
            if (bean.Latitude != null)
            {
                sql.Append(" and Latitude={" + ++i + "}");
                list.Add(bean.Latitude);
            }
            if (bean.CreateDT != null)
            {
                sql.Append(" and CreateDT={" + ++i + "}");
                list.Add(bean.CreateDT);
            }
            if (bean.TouYun_Sj != null)
            {
                sql.Append(" and UpdateDT={" + ++i + "}");
                list.Add(bean.TouYun_Sj);
            }
            sql.Append(" order by t.createdt desc,t.zhuan_mc");
            return Oop.GetDataTable(sql.ToString(), list.ToArray());
        }

        public override DataTable QueryByPage(ChargStation bean, int page, int rows)
        {
            throw new NotImplementedException();
        }

        public override DataTable QueryByPage(ChargStation bean, int page, int rows, ref int count)
        {
            Log.Debug("QueryByPage方法参数：" + bean);
            var getpage = new GetPage();
            var sql = new StringBuilder();
            sql.Append("select * from sm_useroles where 1=1 ");

            if (bean.ZhanBh != null)
                sql.Append(" and ZhanBh={" + bean.ZhanBh + "}");

            if (!string.IsNullOrEmpty(bean.ZhuanMc))
                sql.Append(" and ZhuanMc={" + bean.ZhuanMc + "}");

            if (!string.IsNullOrEmpty(bean.YeZhuDw))
                sql.Append(" and YeZhuDw={" + bean.YeZhuDw + "}");

            if (!string.IsNullOrEmpty(bean.LianXiR))
                sql.Append(" and LianXiR={" + bean.LianXiR + "}");

            if (!string.IsNullOrEmpty(bean.LianXiDh))
                sql.Append(" and LianXiDh={" + bean.LianXiDh + "}");

            if (!string.IsNullOrEmpty(bean.ZhuangLeiX))
                sql.Append(" and ZhuangLeiX={" + bean.ZhuangLeiX + "}");

            if (!string.IsNullOrEmpty(bean.ZhuangChangJ))
                sql.Append(" and ZhuangChangJ={" + bean.ZhuangChangJ + "}");

            if (!string.IsNullOrEmpty(bean.XiangXiDz))
                sql.Append(" and XiangXiDz={" + bean.XiangXiDz + "}");

            if (bean.Longtude != null)
                sql.Append(" and Longtude={" + bean.Longtude + "}");

            if (bean.Latitude != null)
                sql.Append(" and Latitude={" + bean.Latitude + "}");

            if (bean.CreateDT != null)
                sql.Append(" and CreateDT={" + bean.CreateDT + "}");

            if (bean.TouYun_Sj != null)
                sql.Append(" and UpdateDT={" + bean.TouYun_Sj + "}");

            return getpage.GetPageByProcedure(page, rows, sql.ToString(), ref count);
        }
        /// <summary>
        /// 保存充电桩
        /// </summary>
        /// <param name="bean"></param>
        public void SavePile(ChargPile bean)
        {
            Log.Debug("Modify方法参数：" + bean);
            var sql = new StringBuilder();
            sql.Append("update dev_chargpile set");
            var i = 0;
            var dList = new List<object>();
            if (!string.IsNullOrEmpty(bean.CHANGJIAO_BH))
            {
                sql.Append(" CHANGJIAO_BH={" + i++ + "},");
                dList.Add(bean.CHANGJIAO_BH);
            }
            if (!string.IsNullOrEmpty(bean.YUNXING_BH))
            {
                sql.Append(" YUNXING_BH={" + i++ + "},");
                dList.Add(bean.YUNXING_BH);
            }
            if (!string.IsNullOrEmpty(bean.PILETYPEID))
            {
                sql.Append(" PILETYPEID={" + i++ + "},");
                dList.Add(bean.PILETYPEID);
            }
            if (!string.IsNullOrEmpty(bean.ZHUANGTAI))
            {
                sql.Append(" ZHUANGTAI={" + i++ + "},");
                dList.Add(bean.ZHUANGTAI);
            }

            if (sql.Length > 0)
            {
                sql = sql.Remove(sql.Length - 1, 1);
            }
            sql.Append(" where DEV_CHARGPILE={" + i++ + "}");
            dList.Add(bean.DEV_CHARGPILE);
            Oop.Execute(sql.ToString(), dList.ToArray());
        }
        /// <summary>
        /// 查询充电桩类型
        /// </summary>
        /// <param name="zhanbh"></param>
        /// <returns></returns>
        public DataTable QueryTypes(decimal zhanbh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select p.CHANGJIA,p.ZHUANGLEI_X,p.ZHUANGXING_H  ");
            strSql.Append(" from dev_powerpiletypes p, dev_chargpile c,dev_branch b,dev_chargstation s ");
            strSql.Append(" where c.box_id=b.branchno and b.zhuan_bh=s.zhan_bh and p.parserkey=c.piletypeid and s.zhan_bh={0} ");
            object[] parms = new object[] 
            {
                zhanbh
            };
            DataTable dt = new DataTable();
            try
            {
                dt = Oop.GetDataTable(strSql.ToString(), parms);
            }
            catch (Exception e)
            {
                Log.Error("查询充电桩类型失败！", e);
            }
            return dt;
        }

        /// <summary>
        /// 保存充电站
        /// </summary>
        /// <param name="bean"></param>
        public void SaveZhan(ChargStation bean)
        {
            Log.Debug("Modify方法参数：" + bean);
            var sql = new StringBuilder();
            sql.Append("update dev_chargstation set");
            var i = 0;
            var dList = new List<object>();
            if (bean.ZhuangChangJ!=null)
            {
                sql.Append(" zhuangchang_j={" + i++ + "},");
                dList.Add(bean.ZhuangChangJ);
            }
            if (bean.ZhuangLeiX!=null)
            {
                sql.Append(" zhuanglei_x={" + i++ + "},");
                dList.Add(bean.ZhuangLeiX);
            }

            if (sql.Length > 0)
            {
                sql = sql.Remove(sql.Length - 1, 1);
            }
            sql.Append(" where ZHAN_BH={" + i++ + "}");
            dList.Add(bean.ZhanBh);
            try
            {
                Oop.Execute(sql.ToString(), dList.ToArray());
            }
            catch (Exception e)
            {
                Log.Error("保存充电站失败！", e);
            }
            
        }

        public DataTable GetZhuangLei_X(string str)
        {
            var sql = new StringBuilder();
            sql.Append("select zhuangxing_h ");
            sql.Append("from dev_powerpiletypes t ");
            sql.Append("where zhuanglei_x='" + str + "'");
            return Oop.GetDataTable(sql.ToString());
        }

        public DataTable QueryBoxCounts(decimal zhanbh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select count(b.branchno)as boxcounts  from dev_branch b where zhuan_bh={0}  ");
            object[] parms = new object[] 
            {
                zhanbh
            };
            DataTable dt = new DataTable();
            try
            {
                dt = Oop.GetDataTable(strSql.ToString(), parms);
            }
            catch (Exception e)
            {
                Log.Error("查询充电站所属分支箱数量失败！", e);
            }
            return dt;
        }

        /// <summary>
        /// 查询统计充电站下的所有充电桩数量
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable FindByChargPileCount(Int32 id)
        {
            Log.Debug("FindBy方法参数：");
            var sql = new StringBuilder();
            sql.Append("select count(*) count ");
            sql.Append("from dev_chargstation dcs   ");
            sql.Append("inner join dev_branch db on dcs.zhan_bh=db.zhuan_bh ");
            sql.Append("inner join dev_chargpile dcp on dcp.box_id=db.branchno ");
            sql.Append("where 1=1  and Zhan_Bh=" + id + "");
            return Oop.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 根据站编号查询站信息
        /// </summary>
        /// <param name="zhanbh"></param>
        /// <returns></returns>
        public DataTable QueryChargStationBYID(decimal zhanbh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select c.zhan_bh as zhanbh,c.zhuan_mc as zhuanmc,c.zhan_jc,c.xiangxi_dz as xiangxidz,c.longtude,c.latitude,c.yezhu_dw as yezhudw,c.lianxi_r as lianxir,");
            strSql.Append(" c.lianxi_dh as lianxidh, c.zhuangchang_j as zhuangchangj,c.zhuanglei_x as zhuangleix,c.createdt,c.jianzhan_sj,c.touyun_sj ");
            strSql.Append(" from dev_chargstation c where zhan_bh={0}  ");
            object[] parms = new object[] 
            {
                zhanbh
            };
            DataTable dt = new DataTable();
            try
            {
                dt = Oop.GetDataTable(strSql.ToString(), parms);
            }
            catch (Exception e)
            {
                Log.Error("查询充电站所属分支箱数量失败！", e);
            }
            return dt;
        }
        /// <summary>
        /// 添加充电桩
        /// </summary>
        /// <param name="chargpile"></param>
        public void AddPile(ChargPile bean)
        {
            Log.Debug("Add方法参数：" + bean.ToString());
            var sql1 = new StringBuilder();
            var sql2 = new StringBuilder();
            var i = 0;
            var list = new List<object>();
            if (bean.DEV_CHARGPILE != null)
            {
                sql1.Append(" DEV_CHARGPILE,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.DEV_CHARGPILE);
            }
            if (bean.BOX_ID != null)
            {
                sql1.Append(" BOX_ID,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.BOX_ID);
            }
            if (bean.ZONGXIAN_DZ != null)
            {
                sql1.Append(" ZONGXIAN_DZ,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.ZONGXIAN_DZ);
            }
            if (!string.IsNullOrEmpty(bean.DTU_ID))
            {
                sql1.Append(" DTU_ID,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.DTU_ID);
            }
            if (!string.IsNullOrEmpty(bean.PILETYPEID))
            {
                sql1.Append(" PILETYPEID,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.PILETYPEID);
            }
            if (!string.IsNullOrEmpty(bean.CHANGJIAO_BH))
            {
                sql1.Append(" CHANGJIAO_BH,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.CHANGJIAO_BH);
            }
            if (!string.IsNullOrEmpty(bean.YUNXING_BH))
            {
                sql1.Append(" YUNXING_BH,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.YUNXING_BH);
            }
            if (bean.TOUYOU_SJ != new DateTime())
            {
                sql1.Append(" TOUYOU_SJ,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.TOUYOU_SJ);
            }
            else
            {
                sql1.Append(" TOUYOU_SJ,");
                sql2.Append(" null,");
            }
            if (!string.IsNullOrEmpty(bean.ZHUANGTAI))
            {
                sql1.Append(" ZHUANGTAI,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.ZHUANGTAI);
            }
            if (!string.IsNullOrEmpty(bean.ZHICHAN_BH))
            {
                sql1.Append(" ZHICHAN_BH,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.ZHICHAN_BH);
            }
            if (!string.IsNullOrEmpty(bean.YUNWEI_DW))
            {
                sql1.Append(" YUNWEI_DW,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.YUNWEI_DW);
            }
            if (!string.IsNullOrEmpty(bean.REMARK))
            {
                sql1.Append(" REMARK,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.REMARK);
            }
            if (sql1.Length > 0)
            {
                sql1 = sql1.Remove(sql1.Length - 1, 1);
                sql2 = sql2.Remove(sql2.Length - 1, 1);
            }
            var sql = "insert into dev_chargpile(" + sql1 + ",CREATEDT) values(" + sql2 + ",sysdate)";
            Oop.Execute(sql, list.ToArray());
        }


        /// <summary>
        /// 修改充电桩
        /// </summary>
        /// <param name="bean"></param>
        public void EditPile(ChargPile bean)
        {
            Log.Debug("Modify方法参数：" + bean);
            var sql = new StringBuilder();
            sql.Append("update dev_chargpile set");
            var i = 0;
            var dList = new List<object>();
            if (!string.IsNullOrEmpty(bean.PILETYPEID))
            {
                sql.Append(" PILETYPEID={" + i++ + "},");
                dList.Add(bean.PILETYPEID);
            }
            if (!string.IsNullOrEmpty(bean.POWERPILENAME))
            {
                sql.Append(" POWERPILENAME={" + i++ + "},");
                dList.Add(bean.POWERPILENAME);
            }
            if (bean.ZONGXIAN_DZ!=null)
            {
                sql.Append(" ZONGXIAN_DZ={" + i++ + "},");
                dList.Add(bean.ZONGXIAN_DZ);
            }
            if (!string.IsNullOrEmpty(bean.CHANGJIAO_BH))
            {
                sql.Append(" CHANGJIAO_BH={" + i++ + "},");
                dList.Add(bean.CHANGJIAO_BH);
            }
            if (!string.IsNullOrEmpty(bean.YUNXING_BH))
            {
                sql.Append(" YUNXING_BH={" + i++ + "},");
                dList.Add(bean.YUNXING_BH);
            } 
            if (!string.IsNullOrEmpty(bean.ZHUANGTAI))
            {
                sql.Append(" ZHUANGTAI={" + i++ + "},");
                dList.Add(bean.ZHUANGTAI);
            }
            if (!string.IsNullOrEmpty(bean.REMARK))
            {
                sql.Append(" REMARK={" + i++ + "},");
                dList.Add(bean.REMARK);
            }
            if (bean.TOUYOU_SJ != new DateTime())
            {
                sql.Append(" TOUYOU_SJ={" + i++ + "},");
                dList.Add(bean.TOUYOU_SJ);
            }
            else
            {
                sql.Append(" TOUYOU_SJ=null,");
            }
            if (bean.UPDATEDT != null)
            {
                sql.Append(" UPDATEDT={" + i++ + "},");
                dList.Add(bean.UPDATEDT);
            }
            if (sql.Length > 0)
            {
                sql = sql.Remove(sql.Length - 1, 1);
            }
            sql.Append(" where DEV_CHARGPILE={" + i++ + "}");
            dList.Add(bean.DEV_CHARGPILE);
            Oop.Execute(sql.ToString(), dList.ToArray());
        }

        /// <summary>
        /// 根据分支箱id删除分支箱
        /// </summary>
        /// <param name="id"></param>
        public void DelBoxByBoxid(decimal id) 
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" delete from DEV_BRANCH ");
            strSql.Append(" where branchno={0} ");
            object[] parameters = new object[] {
                id
            };
            try
            {
                Oop.Execute(strSql.ToString(), parameters);
            }
            catch (Exception e)
            {
                Log.Error("删除分支箱失败！", e);
            }
        }
        /// <summary>
        /// 根据分支箱id删除充电桩
        /// </summary>
        /// <param name="id"></param>
        public void DelPileByBoxid(decimal id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" delete from dev_chargpile ");
            strSql.Append(" where box_id={0} ");
            object[] parameters = new object[] {
                id
            };
            try
            {
                Oop.Execute(strSql.ToString(), parameters);
            }
            catch (Exception e)
            {
                Log.Error("删除分支箱失败！", e);
            }
        }
        /// <summary>
        /// 修改充电站
        /// </summary>
        /// <param name="bean"></param>
        public void ModifyStation(ChargStation bean) 
        {
            Log.Debug("Modify方法参数：" + bean);
            var sql = new StringBuilder();
            sql.Append("update dev_chargstation set");
            var i = 0;
            var dList = new List<object>();
            if (!string.IsNullOrEmpty(bean.ZhuanMc))
            {
                sql.Append(" ZHUAN_MC={" + i++ + "},");
                dList.Add(bean.ZhuanMc);
            }
            if (!string.IsNullOrEmpty(bean.Zhan_Jc))
            {
                sql.Append(" Zhan_Jc={" + i++ + "},");
                dList.Add(bean.Zhan_Jc);
            }
            if (!string.IsNullOrEmpty(bean.XiangXiDz))
            {
                sql.Append(" XIANGXI_DZ ={" + i++ + "},");
                dList.Add(bean.XiangXiDz);
            }
            if (bean.Latitude!=null)
            {
                sql.Append(" Latitude={" + i++ + "},");
                dList.Add(bean.Latitude);
            }
            if (bean.Longtude!=null)
            {
                sql.Append(" Longtude={" + i++ + "},");
                dList.Add(bean.Longtude);
            }
            if (!string.IsNullOrEmpty(bean.YeZhuDw))
            {
                sql.Append(" YEZHU_DW ={" + i++ + "},");
                dList.Add(bean.YeZhuDw);
            }
            if (!string.IsNullOrEmpty(bean.LianXiR))
            {
                sql.Append(" LIANXI_R ={" + i++ + "},");
                dList.Add(bean.LianXiR);
            }
            if (!string.IsNullOrEmpty(bean.LianXiDh))
            {
                sql.Append(" LIANXI_DH ={" + i++ + "},");
                dList.Add(bean.LianXiDh);
            }
            if (bean.JianZhan_Sj != null)
            {
                sql.Append(" JianZhan_Sj={" + i++ + "},");
                dList.Add(bean.JianZhan_Sj);
            }
            if (bean.TouYun_Sj != null)
            {
                sql.Append(" TouYun_Sj={" + i++ + "},");
                dList.Add(bean.TouYun_Sj);
            }
            if (sql.Length > 0)
            {
                sql = sql.Remove(sql.Length - 1, 1);
            }
            sql.Append(" ,UpdateDT=sysdate where ZHAN_BH={" + i++ + "}");
            dList.Add(bean.ZhanBh);
            Oop.Execute(sql.ToString(), dList.ToArray());
        }
        /// <summary>
        /// 根据站编号删除站全景图片
        /// </summary>
        /// <param name="id"></param>
        public void DelStationTP(decimal id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" delete from dev_chargstationfile ");
            strSql.Append(" where ZHAN_BH={0} ");
            object[] parameters = new object[] {
                id
            };
            try
            {
                Oop.Execute(strSql.ToString(), parameters);
            }
            catch (Exception e)
            {
                Log.Error("删除分支箱失败！", e);
            }
        }
        /// <summary>
        /// 根据站名称获取站信息
        /// </summary>
        /// <param name="zhanmc"></param>
        /// <returns></returns>
        public DataTable QueryZhanByZMC(string zhanmc) 
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from dev_chargstation ");
            strSql.Append(" where ZHUAN_MC={0} ");
            object[] parameters = new object[] {
                zhanmc
            };
            DataTable dt = new DataTable();
            try
            {
                dt=Oop.GetDataTable(strSql.ToString(), parameters);
            }
            catch (Exception e)
            {
                Log.Error("根据站名称获取站信息失败！", e);
            }
            return dt;
        }
        /// <summary>
        /// 根据站简称获取站信息
        /// </summary>
        /// <param name="zhanjc"></param>
        /// <returns></returns>
        public DataTable QueryZhanByZJC(string zhanjc)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from dev_chargstation ");
            strSql.Append(" where ZHAN_JC={0} ");
            object[] parameters = new object[] {
                zhanjc
            };
            DataTable dt = new DataTable();
            try
            {
                dt = Oop.GetDataTable(strSql.ToString(), parameters);
            }
            catch (Exception e)
            {
                Log.Error("根据站简称获取站信息失败！", e);
            }
            return dt;
        }
        /// <summary>
        /// 添加充电站全景图片
        /// </summary>
        /// <param name="bean"></param>
        public void AddPilePicture(ChargStationFile bean)
        {
            Log.Debug("Add方法参数：" + bean.ToString());
            var sql1 = new StringBuilder();
            var sql2 = new StringBuilder();
            var i = 0;
            var list = new List<object>();
            if (bean.ZhanBh!=null)
            {
                sql1.Append(" ZHAN_BH,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.ZhanBh);
            }
            if (!string.IsNullOrEmpty(bean.Id))
            {
                sql1.Append(" ID,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.Id);
            }
            if (!string.IsNullOrEmpty(bean.Filename))
            {
                sql1.Append(" FILENAME,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.Filename);
            }
            if (bean.Filecontext!=null)
            {
                sql1.Append(" FILECONTEXT,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.Filecontext);
            }
            if (bean.Filesize!=null)
            {
                sql1.Append(" FILESIZE,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.Filesize);
            }
            if (!string.IsNullOrEmpty(bean.Filemime))
            {
                sql1.Append(" FILEMIME,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.Filemime);
            }
           
            if (sql1.Length > 0)
            {
                sql1 = sql1.Remove(sql1.Length - 1, 1);
                sql2 = sql2.Remove(sql2.Length - 1, 1);
            }
            var sql = "insert into dev_chargstationfile(" + sql1 + ") values(" + sql2 + ")";
            Oop.Execute(sql, list.ToArray());
        }
        /// <summary>
        /// 根据站编号查询分支箱最大编号
        /// </summary>
        /// <param name="zhanbh"></param>
        /// <returns></returns>
        public DataTable QueryMaxBrachno(decimal zhanbh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select max(branchno) as branchno from dev_branch ");
            strSql.Append(" where ZHUAN_BH={0} ");
            object[] parameters = new object[] {
                zhanbh
            };
            DataTable dt = new DataTable();
            try
            {
                dt = Oop.GetDataTable(strSql.ToString(), parameters);
            }
            catch (Exception e)
            {
                Log.Error("删除分支箱失败！", e);
            }
            return dt;
        }
        /// <summary>
        /// 根据站编号获取分支箱信息
        /// </summary>
        /// <param name="zhanbh"></param>
        /// <returns></returns>
        public DataTable GetBoxByZhanID(decimal zhanbh) 
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from dev_branch ");
            strSql.Append(" where ZHUAN_BH={0} order by branchno ");
            object[] parameters = new object[] {
                zhanbh
            };
            DataTable dt = new DataTable();
            try
            {
                dt = Oop.GetDataTable(strSql.ToString(), parameters);
            }
            catch (Exception e)
            {
                Log.Error("根据站编号获取分支箱信息！", e);
            }
            return dt;
        }
        /// <summary>
        /// 根据分支箱id获取充电桩信息
        /// </summary>
        /// <param name="boxid"></param>
        /// <returns></returns>
        public DataTable GetPileByBoxid(decimal boxid) 
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from dev_chargpile ");
            strSql.Append(" where box_id={0} order by dev_chargpile ");
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
                Log.Error("删除分支箱失败！", e);
            }
            return dt;
        }
        /// <summary>
        /// 通过站编号获取站信息
        /// </summary>
        /// <param name="zhanbh"></param>
        /// <returns></returns>
        public DataTable GetstationByid(decimal zhanbh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from dev_chargstation ");
            strSql.Append(" where zhan_bh={0} ");
            object[] parameters = new object[] {
                zhanbh
            };
            DataTable dt = new DataTable();
            try
            {
                dt = Oop.GetDataTable(strSql.ToString(), parameters);
            }
            catch (Exception e)
            {
                Log.Error("删除分支箱失败！", e);
            }
            return dt;
        }

        /// <summary>
        /// 根据站编号获取分支箱数量
        /// </summary>
        /// <param name="zhanbh"></param>
        /// <returns></returns>
        public DataTable GetBoxsl(decimal zhanbh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select count(branchno) as boxcounts from dev_branch ");
            strSql.Append(" where ZHUAN_BH={0} ");
            object[] parameters = new object[] {
                zhanbh
            };
            DataTable dt = new DataTable();
            try
            {
                dt = Oop.GetDataTable(strSql.ToString(), parameters);
            }
            catch (Exception e)
            {
                Log.Error("根据站编号获取分支箱数量失败！", e);
            }
            return dt;
        }

        /// <summary>
        /// 根据站编号获取图片
        /// </summary>
        /// <param name="zhanbh"></param>
        /// <returns></returns>
        public DataTable GetPicture(decimal zhanbh) 
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select id,filename from dev_chargstationfile ");
            strSql.Append(" where ZHAN_BH={0} ");
            object[] parameters = new object[] {
                zhanbh
            };
            DataTable dt = new DataTable();
            try
            {
                dt = Oop.GetDataTable(strSql.ToString(), parameters);
            }
            catch (Exception e)
            {
                Log.Error("根据站编号获取图片失败！", e);
            }
            return dt;
        }

        public void DelPicture(string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" delete from dev_chargstationfile ");
            strSql.Append(" where id={0} ");
            object[] parameters = new object[] {
                id
            };
            try
            {
                Oop.Execute(strSql.ToString(), parameters);
            }
            catch (Exception e)
            {
                Log.Error("删除图片失败！", e);
            }
        }

    }
}


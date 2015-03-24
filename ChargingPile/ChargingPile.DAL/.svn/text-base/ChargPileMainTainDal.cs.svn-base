using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChargingPile.Model;
using System.Data;

namespace ChargingPile.DAL
{
    public class ChargPileMainTainDal : BaseDal<ChargPileJianXiuJL>
    {
        /// <summary>
        /// 查询充电站
        /// </summary>
        /// <returns></returns>
        public DataTable QueryChargStation()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select zhan_bh as zhanbh,zhuan_mc as zhuanmc,zhan_jc from DEV_CHARGSTATION");
            DataTable dt = new DataTable();
            try
            {
                dt = Oop.GetDataTable(strSql.ToString());
            }
            catch (Exception e)
            {
                Log.Error("查询充电站失败！", e);
            }
            return dt;
        }
        /// <summary>
        /// 查询代码表
        /// </summary>
        /// <returns></returns>
        public DataTable QueryCode(string codename)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select t2.* from sys_code t1,sys_code t2 where t2.parentid =  t1.id ");
            if(!string.IsNullOrEmpty(codename))
            {
                strSql.Append(" and t1.codename='" + codename + "' ");
            }
            DataTable dt = new DataTable();
            try
            {
                dt = Oop.GetDataTable(strSql.ToString());
            }
            catch (Exception e)
            {
                Log.Error("查询代码失败！", e);
            }
            return dt;
        }
        /// <summary>
        /// 查询运行编号
        /// </summary>
        /// <param name="zhuan_bh"></param>
        /// <returns></returns>
        public DataTable QueryYunxingbh(string zhuan_bh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select c.yunxing_bh,c.dev_chargpile from DEV_BRANCH b,DEV_CHARGPILE c where c.deleteflag is null and b.branchno=c.box_id and b.zhuan_bh={0}");
            object[] parmers = new object[] 
            {
                zhuan_bh
            };
            DataTable dt = new DataTable();
            try
            {
                dt = Oop.GetDataTable(strSql.ToString(), parmers);
            }
            catch (Exception e)
            {
                Log.Error("查询充电桩运行编号失败！", e);
            }
            return dt;
        }
        /// <summary>
        /// 查询运行编号
        /// </summary>
        /// <param name="zhuan_bh"></param>
        /// <returns></returns>
        public DataTable QueryZYunxingbh(string zhuan_bh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select yunxing_bh from DEV_CHARGPILE c where c.DEV_CHARGPILE={0}");
            object[] parmers = new object[] 
            {
                zhuan_bh
            };
            DataTable dt = new DataTable();
            try
            {
                dt = Oop.GetDataTable(strSql.ToString(), parmers);
            }
            catch (Exception e)
            {
                Log.Error("查询充电桩运行编号失败！", e);
            }
            return dt;
        }
        /// <summary>
        /// 查询厂家和类型
        /// </summary>
        /// <param name="yxbh"></param>
        /// <returns></returns>
        public DataTable QueryCJLX(string yxbh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select changjia,zhuanglei_x,DEV_CHARGPILE from DEV_POWERPILETYPES b,DEV_CHARGPILE c where b.parserkey=c.piletypeid and c.yunxing_bh={0}");
            object[] parmers = new object[] 
            {
                yxbh
            };
            DataTable dt = new DataTable();
            try
            {
                dt = Oop.GetDataTable(strSql.ToString(), parmers);
            }
            catch (Exception e)
            {
                Log.Error("查询充电桩厂家和类型失败！", e);
            }
            return dt;
        }

        /// <summary>
        /// 查询厂家和类型
        /// </summary>
        /// <param name="yxbh"></param>
        /// <param name="zhanbh"></param>
        /// <returns></returns>
        public DataTable QueryCJLX(string yxbh,string zhanbh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select  p.changjia,p.zhuanglei_x,c.DEV_CHARGPILE from DEV_POWERPILETYPES p,DEV_CHARGPILE c,dev_branch b where p.parserkey=c.piletypeid ");
            strSql.Append(" and c.yunxing_bh={0} and c.box_id = b.branchno and b.zhuan_bh={1} ");
            object[] parmers = new object[] 
            {
                yxbh,
                zhanbh
            };
            DataTable dt = new DataTable();
            try
            {
                dt = Oop.GetDataTable(strSql.ToString(), parmers);
            }
            catch (Exception e)
            {
                Log.Error("查询充电桩厂家和类型失败！", e);
            }
            return dt;
        }

        public override bool Exist(ChargPileJianXiuJL bean)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 添加检修记录
        /// </summary>
        /// <param name="bean"></param>
        public override void Add(ChargPileJianXiuJL bean)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" insert into dev_maintainrecord(ID,ZHUAN_ID,CREATEDT,JIANXIU_LX,JIANXIU_JB,JIANXIU_SJ,JIANXIU_JL,JIANXIU_R) values ");
            strSql.Append(" (SEQ_JIANXIUID.nextval,{0},{1},{2},{3},{4},{5},{6}) ");
            object[] parameters = new object[] {
                bean.Zhuan_Id,
                bean.CreateDt,
                bean.JianXiu_Lx,
                bean.JianXiu_Jb,
                bean.JianXiu_Sj,
                bean.JianXiu_Jl,
                bean.JianXiu_R
            };
            try
            {
                Oop.Execute(strSql.ToString(), parameters);
            }
            catch (Exception e)
            {
                Log.Error("添加充电桩检修记录失败！", e);
            }
        }
        /// <summary>
        /// 删除检修记录
        /// </summary>
        /// <param name="bean"></param>
        public override void Del(ChargPileJianXiuJL bean)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" delete from dev_maintainrecord ");
            strSql.Append(" where id={0} ");
            object[] parameters = new object[] {
                bean.Id
            };
            try
            {
                Oop.Execute(strSql.ToString(), parameters);
            }
            catch (Exception e)
            {
                Log.Error("删除充电桩类型失败！", e);
            }
        }
        /// <summary>
        /// 修改检修记录
        /// </summary>
        /// <param name="bean"></param>
        public override void Modify(ChargPileJianXiuJL bean)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update dev_maintainrecord set ");
            strSql.Append(" ZHUAN_ID={0},UPDATEDT={1},JIANXIU_LX={2},JIANXIU_JB={3},JIANXIU_SJ={4},JIANXIU_JL={5},JIANXIU_R={6} ");
            strSql.Append(" where id={7} ");
            object[] parameters = new object[] {
                bean.Zhuan_Id,
                bean.UpdateDt,
                bean.JianXiu_Lx,
                bean.JianXiu_Jb,
                bean.JianXiu_Sj,
                bean.JianXiu_Jl,
                bean.JianXiu_R,
                bean.Id
            };
            try
            {
                Oop.Execute(strSql.ToString(), parameters);
            }
            catch (Exception e)
            {
                Log.Error("修改充电桩检修记录失败！", e);
            }
        }
        /// <summary>
        /// 查询所有检修记录
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public DataTable QueryAllJXJL(int page, int rows)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append(" select B.* from (select A.*,rownum rn from (select t.id,t.zhuan_id,s.zhan_jc,s.zhan_bh,c.yunxing_bh,p.changjia,p.zhuanglei_x, ");
            strSql.Append(" (select t2.codename from sys_code t1,sys_code t2 where t2.parentid =  t1.id  and t1.codename='检修类型' and t.jianxiu_lx = t2.code) as jianxiu_lx, ");
            strSql.Append(" (select t2.codename from sys_code t1,sys_code t2 where t2.parentid =  t1.id  and t1.codename='检修级别' and t.jianxiu_jb = t2.code) as jianxiu_jb, ");
            strSql.Append(" t.jianxiu_lx as jxlx ,t.jianxiu_jb as jxjb,t.jianxiu_jl,t.jianxiu_r,t.jianxiu_sj ");
            strSql.Append(" from dev_maintainrecord t,dev_chargpile c,dev_chargstation s,dev_powerpiletypes p,dev_branch b  ");
            strSql.Append(" where t.zhuan_id=c.dev_chargpile and c.piletypeid=p.parserkey and c.box_id=b.branchno and b.zhuan_bh=s.zhan_bh order by t.jianxiu_sj desc ");
            strSql.Append(" ) A where rownum<='" + page + "'*'" + rows + "') B where rn>('" + page + "'-1)*'" + rows + "' ");
            DataTable dt = new DataTable();
            try
            {
                dt = Oop.GetDataTable(strSql.ToString());
            }
            catch (Exception e)
            {
                Log.Error("查询充电桩检修记录失败！", e);
            }
            return dt;
        }
        /// <summary>
        /// 根据条件查询检修记录
        /// </summary>
        /// <param name="zhanbh"></param>
        /// <param name="begintime"></param>
        /// <param name="endtime"></param>
        /// <param name="jxlx"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public DataTable QueryJXJLByTJ(string zhanbh,string zhuangbh, DateTime begintime, DateTime endtime, string jxlx,int page, int rows)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append(" select B.* from (select A.*,rownum rn from (select t.id,t.zhuan_id,s.zhan_jc,s.zhan_bh,c.yunxing_bh,p.changjia,p.zhuanglei_x, ");
            strSql.Append(" (select t2.codename from sys_code t1,sys_code t2 where t2.parentid =  t1.id  and t1.codename='检修类型' and t.jianxiu_lx = t2.code) as jianxiu_lx, ");
            strSql.Append(" (select t2.codename from sys_code t1,sys_code t2 where t2.parentid =  t1.id  and t1.codename='检修级别' and t.jianxiu_jb = t2.code) as jianxiu_jb, ");
            strSql.Append(" t.jianxiu_lx as jxlx ,t.jianxiu_jb as jxjb,t.jianxiu_jl,t.jianxiu_r,t.jianxiu_sj ");
            strSql.Append(" from dev_maintainrecord t,dev_chargpile c,dev_chargstation s,dev_powerpiletypes p,dev_branch b  ");
            strSql.Append(" where t.zhuan_id=c.dev_chargpile and c.piletypeid=p.parserkey and c.box_id=b.branchno and b.zhuan_bh=s.zhan_bh ");
            DataTable dt = new DataTable();
            var i = -1;
            List<object> list = new List<object>();
            if (!string.IsNullOrEmpty(zhanbh))
            {
                strSql.Append(" and s.zhan_bh={" + ++i + "} ");
                list.Add(zhanbh);
            }
            if (!string.IsNullOrEmpty(zhuangbh))
            {
                strSql.Append(" and c.yunxing_bh={" + ++i + "} ");
                list.Add(zhuangbh);
            }
            if (begintime != new DateTime() || endtime != new DateTime())
            {
                strSql.Append(" and t.jianxiu_sj between {" + ++i + "} and {" + ++i + "} ");
                list.AddRange(new object[] { begintime, endtime });
            }
            if (!string.IsNullOrEmpty(jxlx))
            {
                strSql.Append(" and t.jianxiu_lx={" + ++i + "} ");
                list.Add(jxlx);
            }
            strSql.Append(" order by t.jianxiu_sj desc ) A where rownum<='" + page + "'*'" + rows + "') B where rn>('" + page + "'-1)*'" + rows + "' ");
            try
            {
                dt = Oop.GetDataTable(strSql.ToString(), list.ToArray());
            }
            catch (Exception e)
            {
                Log.Error("查询充电桩检修记录失败！", e);
            }
            return dt;
        }

        /// <summary>
        /// 查询检修记录list
        /// </summary>
        /// <param name="zhanbh"></param>
        /// <param name="begintime"></param>
        /// <param name="endtime"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="total"></param>
        public List<ChargPileJianXiuJL> GetJxjlList(string zhanbh,string zhuangbh,DateTime begintime,DateTime endtime,string jxlx, int page,int rows, ref int total)
        {
            List<ChargPileJianXiuJL> jxjllist = new List<ChargPileJianXiuJL>();
            DataTable dt;
            if (zhanbh==""&&zhuangbh==""&&begintime == new DateTime()&&endtime==new DateTime()&&jxlx=="")
            {
                total = GetJLCounts();
                dt = QueryAllJXJL(page, rows);
            }
            else
            {
                total = GetJLCountsByTJ(zhanbh,zhuangbh,begintime,endtime,jxlx);
                dt = QueryJXJLByTJ(zhanbh,zhuangbh,begintime,endtime,jxlx, page, rows);
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ChargPileJianXiuJL bean = new ChargPileJianXiuJL();
                DataRow dr = dt.Rows[i];
                bean.Id = dr["id"].ToString();
                bean.Zhuan_Id =decimal.Parse(dr["zhuan_id"].ToString());
                bean.Zhan_Jc = dr["zhan_jc"].ToString();
                bean.Zhan_Bh = decimal.Parse(dr["zhan_bh"].ToString());
                bean.YunXing_Bh = dr["yunxing_bh"].ToString();
                bean.ChangJia = dr["changjia"].ToString();
                bean.ZhuangLei_X = dr["zhuanglei_x"].ToString();
                bean.JianXiu_Lx = dr["jianxiu_lx"].ToString();
                bean.jxlx = dr["jxlx"].ToString();
                bean.JianXiu_Jb = dr["jianxiu_jb"].ToString();
                bean.jxjb = dr["jxjb"].ToString();
                bean.JianXiu_Jl = dr["jianxiu_jl"].ToString();
                bean.JianXiu_R = dr["jianxiu_r"].ToString();
                if (dr["jianxiu_sj"].ToString() == "" || dr["jianxiu_sj"] == null)
                    bean.JianXiu_Sj = new DateTime();
                else
                    bean.JianXiu_Sj = DateTime.Parse(dr["jianxiu_sj"].ToString());

                jxjllist.Add(bean);
            }
            return jxjllist;
        }
        /// <summary>
        /// 查询检修记录总数
        /// </summary>
        /// <returns></returns>
        public int GetJLCounts() 
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select count(t.id)as zcounts ");
            strSql.Append(" from dev_maintainrecord t,dev_chargpile c,dev_chargstation s,dev_powerpiletypes p,dev_branch b ");
            strSql.Append(" where t.zhuan_id=c.dev_chargpile and c.piletypeid=p.parserkey and c.box_id=b.branchno and b.zhuan_bh=s.zhan_bh ");
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
        /// 根据条件查询检修记录总数
        /// </summary>
        /// <param name="zhanbh"></param>
        /// <param name="begintime"></param>
        /// <param name="endtime"></param>
        /// <param name="jxlx"></param>
        /// <returns></returns>
        public int GetJLCountsByTJ(string zhanbh, string zhuangbh, DateTime begintime, DateTime endtime, string jxlx)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select count(t.id)as zcounts ");
            strSql.Append(" from dev_maintainrecord t,dev_chargpile c,dev_chargstation s,dev_powerpiletypes p,dev_branch b ");
            strSql.Append(" where t.zhuan_id=c.dev_chargpile and c.piletypeid=p.parserkey and c.box_id=b.branchno and b.zhuan_bh=s.zhan_bh ");
            DataTable dt = new DataTable();
            var i = -1;
            int couts = 0;
            List<object> list = new List<object>();
            if (!string.IsNullOrEmpty(zhanbh))
            {
                strSql.Append(" and s.zhan_bh={" + ++i + "} ");
                list.Add(zhanbh);
            }
            if (!string.IsNullOrEmpty(zhuangbh))
            {
                strSql.Append(" and c.yunxing_bh={" + ++i + "} ");
                list.Add(zhuangbh);
            }
            if (begintime != new DateTime() || endtime != new DateTime())
            {
                strSql.Append(" and t.jianxiu_sj between {" + ++i + "} and {" + ++i + "} ");
                list.AddRange(new object[] { begintime, endtime });
            }
            if (!string.IsNullOrEmpty(jxlx))
            {
                strSql.Append(" and t.jianxiu_lx={" + ++i + "} ");
                list.Add(jxlx);
            }
            try
            {
                dt = Oop.GetDataTable(strSql.ToString(),list.ToArray());
                couts = int.Parse(dt.Rows[0]["zcounts"].ToString());
            }
            catch (Exception e)
            {
                Log.Error("查询充电桩失败！", e);
            }
            return couts;
        }
        public override DataTable QueryByPage(ChargPileJianXiuJL bean, int page, int rows)
        {
            throw new NotImplementedException();
        }
        public override DataTable QueryByPage(ChargPileJianXiuJL bean, int page, int rows, ref int count)
        {
            throw new NotImplementedException();
        }
        public override DataTable Query(ChargPileJianXiuJL bean)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ChargingPile.Model;

namespace ChargingPile.DAL
{
    public class PointCfgDal : BaseDal<PointCfg>
    {
        public override bool Exist(PointCfg bean)
        {
            throw new NotImplementedException();
        }

        public override void Add(PointCfg bean)
        {
            Log.Debug("Add方法参数：" + bean.ToString());
            var sql1 = new StringBuilder();
            var sql2 = new StringBuilder();
            var i = -1;
            var list = new List<object>();
            sql1.Append(" id,");
            sql2.Append(" {" + ++i + "},");
            var pointId = Guid.NewGuid().ToString();
            list.Add(pointId);

            if (!string.IsNullOrEmpty(bean.ZhuangLeiX))
            {
                sql1.Append(" PILETYPEID,");
                sql2.Append(" (select t.parserkey from dev_powerpiletypes t where t.zhuanglei_x={" + ++i + "}),");
                list.Add(bean.ZhuangLeiX);
            }
            if (!string.IsNullOrEmpty(bean.GatItemId))
            {
                sql1.Append(" gatitemid,");
                sql2.Append(" {" + ++i + "},");
                list.Add(bean.GatItemId);
            }
            if (bean.LimitMin != null)
            {
                sql1.Append(" limitmin,");
                sql2.Append(" {" + ++i + "},");
                list.Add(bean.LimitMin);
            }
            if (bean.LimitMax != null)
            {
                sql1.Append(" limitmax,");
                sql2.Append(" {" + ++i + "},");
                list.Add(bean.LimitMax);
            }
            if (bean.IsOverLimtWarn != null)
            {
                sql1.Append(" IsOverLimtWarn,");
                sql2.Append(" {" + ++i + "},");
                list.Add(bean.IsOverLimtWarn);
            }
            if (bean.Eff_Min != null)
            {
                sql1.Append(" Eff_Min,");
                sql2.Append(" {" + ++i + "},");
                list.Add(bean.Eff_Min);
            }
            if (bean.Eff_Max != null)
            {
                sql1.Append(" Eff_Max,");
                sql2.Append(" {" + ++i + "},");
                list.Add(bean.Eff_Max);
            }
            if (bean.IsOverEffWarn != null)
            {
                sql1.Append(" IsOverEffWarn,");
                sql2.Append(" {" + ++i + "},");
                list.Add(bean.IsOverEffWarn);
            }
            if (bean.IsAutoCleanWarn != null)
            {
                sql1.Append(" IsAutoCleanWarn,");
                sql2.Append(" {" + ++i + "},");
                list.Add(bean.IsAutoCleanWarn);
            }
            if (bean.CleanWarnRule != null)
            {
                sql1.Append(" CleanWarnRule,");
                sql2.Append(" {" + ++i + "},");
                list.Add(bean.CleanWarnRule);
            }
            if (!string.IsNullOrEmpty(bean.YxStates))
            {
                sql1.Append(" YxStates,");
                sql2.Append(" {" + ++i + "},");
                list.Add(bean.YxStates);
            }
            if (!string.IsNullOrEmpty(bean.YxEff))
            {
                sql1.Append(" YxEff,");
                sql2.Append(" {" + ++i + "},");
                list.Add(bean.YxEff);
            }
            if (!string.IsNullOrEmpty(bean.YxWarn))
            {
                sql1.Append(" YxWarn,");
                sql2.Append(" {" + ++i + "},");
                list.Add(bean.YxWarn);
            }
            sql1.Append(" IsUse,");
            sql2.Append(" {" + ++i + "},");
            list.Add(bean.IsUse);

            if (sql1.Length > 0)
            {
                sql1 = sql1.Remove(sql1.Length - 1, 1);
                sql2 = sql2.Remove(sql2.Length - 1, 1);
            }
            var sql = "insert into GAT_POINTCFG(" + sql1.ToString() + ",createdt) values(" + sql2.ToString() + ",sysdate)";

            var j = -1;
            string sqlWarn1 = "", sqlWarn2 = "", sqlWarn3 = "";
            var listWarn1 = new List<object>();
            var listWarn2 = new List<object>();
            var listWarn3 = new List<object>();
            if (!string.IsNullOrEmpty(bean.Dx))
            {
                sqlWarn1 = "insert into gat_warn (id,warntype,warntarget,warncontext,pointid,createdt) values({" + ++j + "},{" + ++j + "},{" + ++j + "},{" + ++j + "},{" + ++j + "},sysdate)";
                listWarn1.AddRange(new object[] { Guid.NewGuid().ToString(), bean.Dx, bean.Sjh, bean.Dxmb, pointId });
            }
            j = -1;
            if (!string.IsNullOrEmpty(bean.Yj))
            {
                sqlWarn2 = "insert into gat_warn(id,warntype,warntarget,warncontext,pointid,createdt) values({" + ++j + "},{" + ++j + "},{" + ++j + "},{" + ++j + "},{" + ++j + "},sysdate)";
                listWarn2.AddRange(new object[] { Guid.NewGuid().ToString(), bean.Yj, bean.Yxdz, bean.Yjmb, pointId });
            }
            j = -1;
            if (!string.IsNullOrEmpty(bean.Sy))
            {
                sqlWarn3 = "insert into gat_warn(id,warntype,pointid,sndfilecontext,sndfiletype,createdt) values({" + ++j + "},{" + ++j + "},{" + ++j + "},{" + ++j + "},{" + ++j + "},sysdate)";
                listWarn3.AddRange(new object[] { Guid.NewGuid().ToString(), bean.Sy, pointId, bean.SndFileContext, bean.SndFileType });
            }
            try
            {
                Oop.BeginTransaction();
                Oop.Execute(sql, list.ToArray());
                if (!string.IsNullOrEmpty(bean.Dx))
                {
                    Oop.Execute(sqlWarn1, listWarn1.ToArray());
                }
                if (!string.IsNullOrEmpty(bean.Yj))
                {
                    Oop.Execute(sqlWarn2, listWarn2.ToArray());
                }
                if (!string.IsNullOrEmpty(bean.Sy))
                {
                    Oop.Execute(sqlWarn3, listWarn3.ToArray());
                }
                Oop.Submit(true);
            }
            catch (Exception e)
            {
                Oop.Rollback(true);
                Log.Error("Add 方法出错：" + e);
                throw new Exception("保存出错。");
            }
        }

        public override void Del(PointCfg bean)
        {
            Log.Debug("Del方法参数：" + bean.ToString());
            try
            {
                Oop.BeginTransaction();
                Oop.Execute("delete from gat_pointcfg gp where gp.id={0}", bean.Id);
                Oop.Execute("delete from gat_warn gw where gw.pointid={0}", bean.Id);
                Oop.Submit(true);
            }
            catch (Exception e)
            {
                Oop.Rollback(true);
                Log.Error("Del出错：" + e);
                throw new Exception("删除数据出错，请稍后再试。");
            }
        }

        /// <summary>
        /// 查询符合条件的第一个对象
        /// </summary>
        /// <param name="bean"></param>
        /// <returns></returns>
        public PointCfg QueryEntity(PointCfg bean)
        {
            Log.Debug("QueryEntity方法参数：" + bean.ToString());
            var sql = new StringBuilder(@"select gp.*,(select itemname from gat_item t where t.itemno=gp.gatitemid) 
gatitemname,(select changjia from dev_powerpiletypes t where t.parserkey=gp.piletypeid) zhuangcj, 
(select zhuanglei_x from dev_powerpiletypes t where t.parserkey=gp.piletypeid) zhuangleix from gat_pointcfg gp where 1=1 ");
            var list = new List<object>();
            var i = -1;
            if (!string.IsNullOrEmpty(bean.Id))
            {
                sql.Append(" and id={" + ++i + "}");
                list.Add(bean.Id);
            }
            Log.Debug("QueryEntity方法SQL:" + sql.ToString() + ",Params:" + list.ToString());
            PointCfg pointCfg = new PointCfg();
            DataTable dt = Oop.GetDataTable(sql.ToString(), list.ToArray());
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                pointCfg.Id = dr["id"].ToString();
                pointCfg.GatItemId = dr["gatitemid"].ToString();
                pointCfg.GatItemName = dr["gatitemname"].ToString();
                pointCfg.PileTypeId = dr["piletypeid"].ToString();
                pointCfg.Zhuangcj = dr["zhuangcj"].ToString();
                pointCfg.ZhuangLeiX = dr["zhuangleix"].ToString();
                if (!string.IsNullOrEmpty(dr["limitmin"].ToString()))
                {
                    pointCfg.LimitMin = decimal.Parse(dr["limitmin"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["limitmax"].ToString()))
                {
                    pointCfg.LimitMax = decimal.Parse(dr["limitmax"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["isoverlimtwarn"].ToString()))
                {
                    pointCfg.IsOverLimtWarn = decimal.Parse(dr["isoverlimtwarn"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["eff_min"].ToString()))
                {
                    pointCfg.Eff_Min = decimal.Parse(dr["eff_min"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["eff_max"].ToString()))
                {
                    pointCfg.Eff_Max = decimal.Parse(dr["eff_max"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["yxstates"].ToString()))
                {
                    pointCfg.YxStates = dr["yxstates"].ToString();
                }
                if (!string.IsNullOrEmpty(dr["yxeff"].ToString()))
                {
                    pointCfg.YxEff = dr["yxeff"].ToString();
                }
                if (!string.IsNullOrEmpty(dr["yxwarn"].ToString()))
                {
                    pointCfg.YxWarn = dr["yxwarn"].ToString();
                }
                if (!string.IsNullOrEmpty(dr["isovereffwarn"].ToString()))
                {
                    pointCfg.IsOverEffWarn = decimal.Parse(dr["isovereffwarn"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["isautocleanwarn"].ToString()))
                {
                    pointCfg.IsAutoCleanWarn = decimal.Parse(dr["isautocleanwarn"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["cleanwarnrule"].ToString()))
                {
                    pointCfg.CleanWarnRule = decimal.Parse(dr["cleanwarnrule"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["isuse"].ToString()))
                {
                    pointCfg.IsUse = int.Parse(dr["isuse"].ToString());
                }
            }
            sql.Length = 0;
            sql.Append("select gw.id,gw.warntype,gw.warntarget,gw.warncontext,gw.pointid,gw.sndfiletype from gat_warn gw where 1=1 ");
            i = -1;
            list = new List<object>();
            if (!string.IsNullOrEmpty(bean.Id))
            {
                sql.Append(" and gw.pointid={" + ++i + "}");
                list.Add(bean.Id);
            }
            DataTable dtWarn = Oop.GetDataTable(sql.ToString(), list.ToArray());
            if (dtWarn != null && dtWarn.Rows.Count > 0)
            {
                foreach (DataRow dr in dtWarn.Rows)
                {
                    string warntype = dr["warntype"].ToString().ToUpper();
                    if (warntype.Equals("SMS"))//短信
                    {
                        pointCfg.Dx = "1";
                        pointCfg.Sjh = dr["warntarget"].ToString();
                        pointCfg.Dxmb = dr["warncontext"].ToString();
                    }
                    else if (warntype.Equals("EMAIL"))
                    {
                        pointCfg.Yj = "1";
                        pointCfg.Yxdz = dr["warntarget"].ToString();
                        pointCfg.Yjmb = dr["warncontext"].ToString();
                    }
                    else if (warntype.Equals("SND"))
                    {
                        pointCfg.Sy = "1";//如果有声音告警，声音文件不取出
                        pointCfg.SndFileType = dr["sndfiletype"].ToString();
                    }
                    else
                    {
                        Log.Info("QueryEntity方法dtWarn表warntype字段出错，错误值：" + warntype);
                    }
                }
            }
            return pointCfg;
        }

        public override void Modify(PointCfg bean)
        {
            Log.Debug("Modify方法参数：" + bean.ToString());
            var sql1 = new StringBuilder("update GAT_POINTCFG set  ");
            var i = -1;
            var list = new List<object>();
            var pointId = bean.Id;

            if (bean.LimitMin != null)
            {
                sql1.Append(" limitmin={" + ++i + "},");
                list.Add(bean.LimitMin);
            }
            if (bean.LimitMax != null)
            {
                sql1.Append(" limitmax={" + ++i + "},");
                list.Add(bean.LimitMax);
            }
            if (bean.IsOverLimtWarn != null)
            {
                sql1.Append(" IsOverLimtWarn={" + ++i + "},");
                list.Add(bean.IsOverLimtWarn);
            }
            if (bean.Eff_Min != null)
            {
                sql1.Append(" Eff_Min={" + ++i + "},");
                list.Add(bean.Eff_Min);
            }
            if (bean.Eff_Max != null)
            {
                sql1.Append(" Eff_Max={" + ++i + "},");
                list.Add(bean.Eff_Max);
            }
            if (bean.IsOverEffWarn != null)
            {
                sql1.Append(" IsOverEffWarn={" + ++i + "},");
                list.Add(bean.IsOverEffWarn);
            }
            if (bean.IsAutoCleanWarn != null)
            {
                sql1.Append(" IsAutoCleanWarn={" + ++i + "},");
                list.Add(bean.IsAutoCleanWarn);
            }
            if (bean.CleanWarnRule != null)
            {
                sql1.Append(" CleanWarnRule={" + ++i + "},");
                list.Add(bean.CleanWarnRule);
            }
            if (!string.IsNullOrEmpty(bean.YxStates))
            {
                sql1.Append(" YxStates={" + ++i + "},");
                list.Add(bean.YxStates);
            }
            if (!string.IsNullOrEmpty(bean.YxEff))
            {
                sql1.Append(" YxEff={" + ++i + "},");
                list.Add(bean.YxEff);
            }
            if (!string.IsNullOrEmpty(bean.YxWarn))
            {
                sql1.Append(" YxWarn={" + ++i + "},");
                list.Add(bean.YxWarn);
            }
            sql1.Append(" IsUse={" + ++i + "},");
            list.Add(bean.IsUse);
            var sql = sql1.ToString() + " updatedt=sysdate where id={" + ++i + "}";
            list.Add(bean.Id);
            if (list.Count <= 1)
            {
                return;
            }
            var j = -1;
            string sqlWarn1 = "", sqlWarn2 = "", sqlWarn3 = "";
            var listWarn1 = new List<object>();
            var listWarn2 = new List<object>();
            var listWarn3 = new List<object>();
            DataTable dtWarn = Oop.GetDataTable("select warntype from gat_warn where pointid={0}", pointId);
            if (dtWarn != null && dtWarn.Rows.Count > 0)
            {
                foreach (DataRow row in dtWarn.Rows)
                {
                    j = -1;
                    if (!"snd".Equals(row["warntype"].ToString().ToLower()))
                    {
                        continue;
                    }
                    if ("snd".Equals(row["warntype"].ToString().ToLower()) && !string.IsNullOrEmpty(bean.Sy))
                    {
                        string sqlF = "";
                        if (null != bean.SndFileContext)
                        {
                            sqlF = " sndfilecontext={" + ++j + "}, ";
                            listWarn3.Add(pointId);
                        }
                        sqlWarn3 = "update gat_warn set " + sqlF + " sndfiletype={" + ++j + "},updatedt=sysdate where pointid={"
                            + ++j + "} and warntype='SND'";
                        listWarn3.AddRange(new object[] { bean.SndFileType, pointId });
                    }
                    else
                    {
                        sqlWarn3 = "delete from gat_warn where pointid={" + ++j + "} and warntype='SND'";
                        listWarn3.Add(pointId);
                    }
                }
            }
            j = -1;
            if (!string.IsNullOrEmpty(bean.Sy) && sqlWarn3.Length == 0)
            {
                sqlWarn3 = "insert into gat_warn(id,warntype,pointid,sndfilecontext,sndfiletype,createdt) values({" + ++j +
                    "},{" + ++j + "},{" + ++j + "},{" + ++j + "},{" + ++j + "},sysdate)";
                listWarn3.AddRange(new object[] { Guid.NewGuid().ToString(), bean.Sy, pointId, bean.SndFileContext, bean.SndFileType });
            }
            j = -1;
            if (!string.IsNullOrEmpty(bean.Dx))
            {
                sqlWarn1 = "insert into gat_warn (id,warntype,warntarget,warncontext,pointid,createdt) values({" +
                           ++j + "},{" + ++j + "},{" + ++j + "},{" + ++j + "},{" + ++j + "},sysdate)";
                listWarn1.AddRange(new object[] { Guid.NewGuid().ToString(), bean.Dx, bean.Sjh, bean.Dxmb, pointId });
            }
            j = -1;
            if (!string.IsNullOrEmpty(bean.Yj))
            {
                sqlWarn2 = "insert into gat_warn(id,warntype,warntarget,warncontext,pointid,createdt) values({" +
                           ++j + "},{" + ++j + "},{" + ++j + "},{" + ++j + "},{" + ++j + "},sysdate)";
                listWarn2.AddRange(new object[] { Guid.NewGuid().ToString(), bean.Yj, bean.Yxdz, bean.Yjmb, pointId });
            }

            try
            {
                Oop.BeginTransaction();
                Oop.Execute(sql, list.ToArray());
                Oop.Execute("delete from gat_warn where pointid={0} and warntype != 'SND'", pointId);
                if (!string.IsNullOrEmpty(bean.Dx))
                {
                    Oop.Execute(sqlWarn1, listWarn1.ToArray());
                }
                if (!string.IsNullOrEmpty(bean.Yj))
                {
                    Oop.Execute(sqlWarn2, listWarn2.ToArray());
                }
                if (!string.IsNullOrEmpty(bean.Sy))
                {
                    Oop.Execute(sqlWarn3, listWarn3.ToArray());
                }
                Oop.Submit(true);
            }
            catch (Exception e)
            {
                Oop.Rollback(true);
                Log.Error("Modify方法出错：" + e);
                throw new Exception("修改出错。");
            }
        }

        public override DataTable Query(PointCfg bean)
        {
            Log.Debug("Query方法的参数为：" + bean.ToString());
            var sql = new StringBuilder("select * from gat_pointcfg gp where 1=1 ");
            var list = new List<object>();
            var i = -1;
            if (!string.IsNullOrEmpty(bean.Id))
            {
                sql.Append(" and id={" + ++i + "}");
                list.Add(bean.Id);
            }
            Log.Debug("Query方法SQL:" + sql.ToString() + ",Params:" + list.ToString());
            return Oop.GetDataTable(sql.ToString(), list.ToArray());
        }

        public override DataTable QueryByPage(PointCfg bean, int page, int rows)
        {
            throw new NotImplementedException();
        }

        public override DataTable QueryByPage(PointCfg bean, int page, int rows, ref int count)
        {
            throw new NotImplementedException();
        }

        public DataTable QueryBySjlx(string sjlx, string xh, string sjx, int page, int rows, ref int count)
        {
            Log.Debug("QueryBySjlx方法参数为：sjlx:" + sjlx + ",page：" + page + ",rows:" + rows + ", ref count:" + count);
            var sqlTable = new StringBuilder(@"select gp.*,
(select changjia from dev_powerpiletypes dpt where dpt.parserkey=gp.piletypeid) Zhuangcj,
(select zhuanglei_x from dev_powerpiletypes dpt where dpt.parserkey=gp.piletypeid) ZhuangLeiX,
(select itemname from gat_item t where t.itemno=gp.gatitemid) gatitemname from gat_pointcfg gp where 1=1 ");
            var sqlCount = new StringBuilder("select count(*) from gat_pointcfg gp where 1=1 ");
            var sqlWhere = new StringBuilder();
            var list = new List<object>();
            var i = -1;
            if (!string.IsNullOrEmpty(sjlx))
            {
                sqlWhere.Append(" and exists (select 1 from gat_item gi where gi.itemno=gp.gatitemid and gi.datatype={" + ++i + "}) ");
                list.Add(sjlx);
            }
            if (!string.IsNullOrEmpty(xh))
            {
                sqlWhere.Append(" and gp.piletypeid like {" + ++i + "} ");
                list.Add("%" + xh + "%");
            }
            if (!string.IsNullOrEmpty(sjx))
            {
                sqlWhere.Append(" and exists (select 1 from gat_item gi where gi.itemno=gp.gatitemid and gi.itemname like {" + ++i + "}) ");
                list.Add("%" + sjx + "%");
            }
            //DataTable dt = Oop.GetDataTableByPage(sqlTable.Append(sqlWhere).Append(" order by createdt desc").ToString(), (page - 1) * rows, rows, list.ToArray());
            DataTable dt = Oop.GetDataTableByPage(sqlTable.Append(sqlWhere).Append(" order by Zhuangcj,ZhuangLeiX,gatitemname").ToString(), (page - 1) * rows, rows, list.ToArray());
            count = int.Parse(Oop.GetScalar(sqlCount.Append(sqlWhere).ToString(), list.ToArray()).ToString());
            return dt;
        }

        /// <summary>
        /// 获取遥测有效值
        /// </summary>
        /// <returns></returns>
        public DataTable FindByMinMax(string itemno, string datatype)
        {
            Log.Debug("FindByMinMax:方法参数：");
            var sql = new StringBuilder();
            sql.Append("select t.eff_min,t.eff_max ");
            sql.Append("from gat_pointcfg t ");
            sql.Append("where t.gatitemid='" + itemno + "' and t.piletypeid='" + datatype + "' ");
            return Oop.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 获取遥信告警值
        /// </summary>
        /// <param name="itemno"></param>
        /// <param name="datatype"></param>
        /// <returns></returns>
        public DataTable FindByWarn(string itemno, string datatype)
        {
            Log.Debug("FindByWarn:方法参数：");
            var sql = new StringBuilder();
            sql.Append("select t.yxwarn ");
            sql.Append("from gat_pointcfg t ");
            sql.Append("where t.gatitemid='" + itemno + "' and t.piletypeid='" + datatype + "' ");
            return Oop.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 查询有效值和阈值
        /// </summary>
        /// <param name="itemno"></param>
        /// <param name="ztype"></param>
        /// <returns></returns>
        public DataTable FindByEffectiveAndThreshold(string itemno, string ztype)
        {
            Log.Debug("FindByWarn:方法参数：");
            var sql = new StringBuilder();
            sql.Append("select gp.limitmin,gp.limitmax,gp.eff_min,gp.eff_max ");
            sql.Append("from gat_pointcfg gp ");
            sql.Append("where gp.gatitemid='" + itemno + "' and gp.piletypeid='" + ztype + "'");
            return Oop.GetDataTable(sql.ToString());
        }
    }
}

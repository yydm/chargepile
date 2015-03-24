using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChargingPile.Model;
using System.Data;

namespace ChargingPile.DAL
{
    public class ChargPileTypeDal : BaseDal<ChargPileTypes>
    {
        /// <summary>
        /// 获取充电桩类型
        /// </summary>
        /// <returns></returns>
        public DataTable QueryChargPileType()
        {
            Log.Debug("QueryChargPileType方法参数为：");
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from dev_powerpiletypes  ");
            DataTable dt = new DataTable();
            dt = Oop.GetDataTable(strSql.ToString());
            Log.Debug("SQL:" + strSql.ToString());
            return dt;
        }

        /// <summary>
        /// 添加充电桩类型
        /// </summary>
        /// <param name="chargtype"></param>
        public override void Add(ChargPileTypes chargtype)
        {
            Log.Debug("Add方法参数为：" + chargtype.ToString());
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" insert into dev_powerpiletypes(PARSERKEY,CHANGJIA,ZHUANGLEI_X,DTUTYPE,REMARK,CREATEDT) values ");
            strSql.Append(" ({0},{1},{2},{3},{4},{5}) ");
            object[] parameters = new object[] {
                chargtype.PARSERKEY,
                chargtype.CHANGJIA,
                chargtype.ZHUANGLEI_X,
                chargtype.ZHUANGXING_H,
                chargtype.REMARK,
                chargtype.CREATEDT
            };
            Oop.Execute(strSql.ToString(), parameters);
            Log.Debug("SQL:" + strSql.ToString() + ",params:" + parameters.ToString());
            
        }
        /// <summary>
        /// 删除充电桩类型
        /// </summary>
        /// <param name="chargtype"></param>
        public override void Del(ChargPileTypes chargtype)
        {
            Log.Debug("Del方法参数为：" + chargtype.ToString());
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" delete from dev_powerpiletypes ");
            strSql.Append(" where PARSERKEY={0} ");
            object[] parameters = new object[] {
                chargtype.PARSERKEY
            };
            Oop.Execute(strSql.ToString(), parameters);
            Log.Debug("SQL:" + strSql.ToString() + ",params:" + parameters.ToString());
           
        }
        /// <summary>
        /// 修改充电桩类型
        /// </summary>
        /// <param name="chargtype"></param>
        public override void Modify(ChargPileTypes chargtype)
        {
            Log.Debug("Modify方法参数为：" + chargtype.ToString());
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update dev_powerpiletypes set ");
            strSql.Append(" PARSERKEY={0},CHANGJIA={1},ZHUANGLEI_X={2},DTUTYPE={3},REMARK={4},CREATEDT={5},UPDATEDT={6} ");
            strSql.Append(" where PARSERKEY={7} ");
            object[] parameters = new object[] {
                chargtype.PARSERKEY,
                chargtype.CHANGJIA,
                chargtype.ZHUANGLEI_X,
                chargtype.ZHUANGXING_H,
                chargtype.REMARK,
                chargtype.CREATEDT,
                chargtype.UPDATEDT,
                chargtype.PARSERKEY
            };
            Oop.Execute(strSql.ToString(), parameters);
            Log.Debug("SQL:" + strSql.ToString() + ",params:" + parameters.ToString());
            
        }

        public override DataTable Query(ChargPileTypes bean)
        {
            Log.Debug("Query方法参数为：" + bean.ToString());
            var sql = new StringBuilder();
            sql.Append("select * from dev_powerpiletypes where 1=1 ");
            var list = new List<object>();
            var i = -1;
            if (!string.IsNullOrEmpty(bean.PARSERKEY))
            {
                sql.Append(" and PARSERKEY={" + ++i + "}");
                list.Add(bean.PARSERKEY);
            }
            if (!string.IsNullOrEmpty( bean.CHANGJIA))
            {
                sql.Append(" and changjia={" + ++i + "}");
                list.Add(bean.CHANGJIA);
            }
            if (!string.IsNullOrEmpty(bean.ZHUANGLEI_X))
            {
                sql.Append(" and zhuanglei_x={" + ++i + "}");
                list.Add(bean.ZHUANGLEI_X);
            }
            if (!string.IsNullOrEmpty(bean.ZHUANGXING_H))
            {
                sql.Append(" and zhuangxing_h={" + ++i + "}");
                list.Add(bean.ZHUANGXING_H);
            }
            Log.Debug("SQL:" + sql.ToString() + ",params:" + list.ToString());
            return Oop.GetDataTable(sql.ToString(), list.ToArray());
        }

        public DataTable QueryChangJia()
        {
            const string sql = @"select distinct(changjia) from dev_powerpiletypes dp where dp.changjia is not null order by changjia desc";
            return Oop.GetDataTable(sql);
        }

        public override DataTable QueryByPage(ChargPileTypes bean, int page, int rows)
        {
            throw new NotImplementedException();
        }

        public override DataTable QueryByPage(ChargPileTypes bean, int page, int rows, ref int count)
        {
            throw new NotImplementedException();
        }

        public override bool Exist(ChargPileTypes bean)
        {
            throw new NotImplementedException();
        }
    }
}

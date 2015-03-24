using System.Collections.Generic;
using System.Data;
using System.Linq;
using ChargingPile.DAL;
using ChargingPile.Model;

namespace ChargingPile.BLL
{
    public class PointCfgBll
    {
        readonly PointCfgDal _pointCfgDal = new PointCfgDal();

        public void Add(PointCfg bean)
        {
            _pointCfgDal.Add(bean);
        }

        public DataTable QueryBySjlx(string sjlx, string xh, string sjx, int pages, int rows, ref int count)
        {
            return _pointCfgDal.QueryBySjlx(sjlx, xh, sjx, pages, rows, ref count);
        }

        public PointCfg QueryEntity(PointCfg bean)
        {
            return _pointCfgDal.QueryEntity(bean);
        }

        public void Del(PointCfg bean)
        {
            _pointCfgDal.Del(bean);
        }

        public void Modify(PointCfg bean)
        {
            _pointCfgDal.Modify(bean);
        }

        /// <summary>
        /// 获取遥测有效值
        /// </summary>
        /// <returns></returns>
        public Dictionary<long?, long?> FindByMinMax(string itemno, string datatype)
        {
            var list = new Dictionary<long?, long?>();
            var dt = _pointCfgDal.FindByMinMax(itemno, datatype);
            var longmax = 0L;
            var longmin = 0L;
            if (dt.Rows.Count <= 0)
            {
                return list;
            }
            var max = dt.Rows[0]["EFF_MAX"].ToString();
            if (!string.IsNullOrEmpty(max))
            {
                longmax = long.Parse(max);
            }
            var min = dt.Rows[0]["EFF_MIN"].ToString();
            if (!string.IsNullOrEmpty(min))
            {
                longmin = long.Parse(min);
            }
            list.Add(longmin, longmax);
            return list;
        }

        /// <summary>
        /// 获取遥信告警值
        /// </summary>
        /// <param name="itemno"></param>
        /// <param name="datatype"></param>
        /// <returns></returns>
        public List<int> FindByWarn(string itemno, string datatype)
        {
            var list = new List<int>();
            var dt = _pointCfgDal.FindByWarn(itemno, datatype);
            if (dt.Rows.Count <= 0)
            {
                return list;
            }
            var sList = dt.Rows[0]["yxwarn"].ToString().Split(',');
            list.AddRange(sList.Select(int.Parse));
            return list;
        }

        /// <summary>
        /// 查询有效值和阈值
        /// </summary>
        /// <param name="itemno"></param>
        /// <param name="ztype"></param>
        /// <returns></returns>
        public DataTable FindByEffectiveAndThreshold(string itemno, string ztype)
        {
            return _pointCfgDal.FindByEffectiveAndThreshold(itemno, ztype);
        }


    }
}

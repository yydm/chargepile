using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ChargingPile.Model;

namespace ChargingPile.DAL
{
    public class ChargStationFileDal : BaseDal<ChargStationFile>
    {
        public override bool Exist(ChargStationFile bean)
        {
            throw new NotImplementedException();
        }

        public override void Add(ChargStationFile bean)
        {
            throw new NotImplementedException();
        }

        public override void Del(ChargStationFile bean)
        {
            throw new NotImplementedException();
        }

        public override void Modify(ChargStationFile bean)
        {
            throw new NotImplementedException();
        }

        public override DataTable Query(ChargStationFile bean)
        {
            Log.Debug("Query方法参数：" + bean);
            var sql = new StringBuilder();
            sql.Append("select t.* from dev_chargstationfile t where 1=1 ");
            var list = new List<object>();
            var i = -1;
            if (bean.ZhanBh != null)
            {
                sql.Append(" and Zhan_Bh={" + ++i + "}");
                list.Add(bean.ZhanBh);
            }
            if (!string.IsNullOrEmpty(bean.Id))
            {
                sql.Append(" and Id={" + ++i + "}");
                list.Add(bean.Id);
            }
            if (!string.IsNullOrEmpty(bean.Filename))
            {
                sql.Append(" and Filename={" + ++i + "}");
                list.Add(bean.Filename);
            }
            if (bean.Filecontext != null)
            {
                sql.Append(" and Filecontext={" + ++i + "}");
                list.Add(bean.Filecontext);
            }
            if (bean.Filesize != null)
            {
                sql.Append(" and Filesize={" + ++i + "}");
                list.Add(bean.Filesize);
            }
            if (!string.IsNullOrEmpty(bean.Filemime))
            {
                sql.Append(" and Filemime={" + ++i + "}");
                list.Add(bean.Filemime);
            }

            if (bean.Createdt != null)
            {
                sql.Append(" and CreateDT={" + ++i + "}");
                list.Add(bean.Createdt);
            }
            if (bean.Updatedt != null)
            {
                sql.Append(" and UpdateDT={" + ++i + "}");
                list.Add(bean.Updatedt);
            }
            Log.Debug("SQL :" + sql + ",params:" + list.ToString());
            return Oop.GetDataTable(sql.ToString(), list.ToArray());
        }

        public override DataTable QueryByPage(ChargStationFile bean, int page, int rows)
        {
            throw new NotImplementedException();
        }

        public override DataTable QueryByPage(ChargStationFile bean, int page, int rows, ref int count)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="zhanid"></param>
        /// <returns></returns>
        public DataTable FindByCount(string zhanid)
        {
            Log.Debug("Query方法参数：");
            var sql = new StringBuilder();
            sql.Append("select count(*) count ");
            sql.Append("from dev_chargstationfile t  ");
            sql.Append("where t.zhan_bh=" + zhanid + " ");
            return Oop.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 查询充电站文件中图片文件
        /// </summary>
        /// <param name="chargStationFile"></param>
        /// <returns></returns>
        public DataTable FindBy(ChargStationFile chargStationFile)
        {
            Log.Debug("Query方法参数：");
            var sql = new StringBuilder();
            sql.Append("select t.filecontext,t.id,t.filemime  ");
            sql.Append("from dev_chargstationfile t  ");
            sql.Append("where t.zhan_bh=" + chargStationFile.ZhanBh + " ");
            return Oop.GetDataTable(sql.ToString());
        }
    }
}

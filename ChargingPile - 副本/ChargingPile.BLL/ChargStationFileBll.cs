using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ChargingPile.Model;
using ChargingPile.DAL;

namespace ChargingPile.BLL
{
    public class ChargStationFileBll:BaseBll<ChargStationFile>
    {
        readonly ChargStationFileDal _chargStationFileDal =new ChargStationFileDal();
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
            return _chargStationFileDal.Query(bean);
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
        /// <param name="id"></param>
        public int FindByCount(string id)
        {
            var dt = _chargStationFileDal.FindByCount(id);
            return int.Parse(dt.Rows[0]["count"].ToString());
        }

        /// <summary>
        /// 查询充电站文件中图片文件
        /// </summary>
        /// <param name="chargStationFile"></param>
        /// <returns></returns>
        public DataTable FindBy(ChargStationFile chargStationFile)
        {
            var dt = _chargStationFileDal.FindBy(chargStationFile);
            return dt;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using ChargingPile.BLL;
using ChargingPile.Model;
using log4net;
using System.Drawing;

namespace ChargingPile.UI.WEB.WebService
{
    /// <summary>
    /// Summary description for PictureChargStationService
    /// </summary>
    public class PictureChargStationService : IHttpHandler
    {
        protected ILog Log = LogManager.GetLogger("PriceAdjustmentService");
        readonly OprLogBll _oprLogBll = new OprLogBll();
        readonly static JavaScriptSerializer Jss = new JavaScriptSerializer();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            var action = context.Request.Params["action"];
            switch (action)
            {

                case "getChargStation":
                    GetChargStation(context);
                    break;
                case "getAddress":
                    GetAddress(context);
                    break;
                case "getChargPileCount":
                    GetChargPileCount(context);
                    break;
                case "getChargStationFile":
                    GetChargStationFile(context);
                    break;
                case "getCoordinates":
                    GetCoordinates(context);
                    break;
            }
        }

        /// <summary>
        /// 获取经纬度
        /// </summary>
        /// <param name="context"></param>
        public void GetCoordinates(HttpContext context)
        {
            var chargstationbll = new ChargStationBll();
            var chargstation = new ChargStation()
                {
                    ZhanBh = Int32.Parse(context.Request.Params["id"])
                };
            string str = "";
            try
            {
                var dt = chargstationbll.Query(chargstation);
                str = ConvertToJson.DataTableToJson("rows", dt);
                str += "|";
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            context.Response.Write(str);
        }

        /// <summary>
        /// 获取充电站
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public void GetChargStation(HttpContext context)
        {
            var chargstationbll = new ChargStationBll();
            var chargstation = new ChargStation();
            string str = "";
            var count = 0;
            try
            {
                var dt = chargstationbll.Query(chargstation);
                str = ConvertToJson.DataTableToJson("rows", dt);
                str += "|";
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            context.Response.Write(str);
        }

        /// <summary>
        /// 获取充电站地址
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public void GetAddress(HttpContext context)
        {
            var chargstationbll = new ChargStationBll();
            var chargstation = new ChargStation
                {
                    ZhanBh = Int32.Parse(context.Request.Params["id"])
                };
            string str = "";
            try
            {
                var dt = chargstationbll.Query(chargstation);
                str = ConvertToJson.DataTableToJson("rows", dt);
                str += "|";
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            context.Response.Write(str);
        }

        /// <summary>
        /// 获取充电桩数量
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public void GetChargPileCount(HttpContext context)
        {
            var chargstationbll = new ChargStationBll();
            var id = Int32.Parse(context.Request.Params["id"]);

            string str = null;
            try
            {
                var count = chargstationbll.FindByChargPileCount(id);
                str += count + "|";
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            context.Response.Write(str);
        }

        /// <summary>
        /// 获取充电站全景图片
        /// </summary>
        /// <param name="context"></param>
        public void GetChargStationFile(HttpContext context)
        {
            var chargstationfilebll = new ChargStationFileBll();
            var cPictureMessage = new Message<Picture>();
            var fileid = context.Request.Params["id"];
            string ret = null;
            if (string.IsNullOrEmpty(fileid))
            {
                cPictureMessage.Total = 0;
                return;
            }
            var chargstationfile = new ChargStationFile
                {
                    ZhanBh = int.Parse(fileid)
                };
            try
            {
                var dt = chargstationfilebll.FindBy(chargstationfile);
                var list = ConvertHelper<Picture>.ConvertToList(dt);
                foreach (var li in list)
                {
                    var bytes = li.FileContext;
                    if (bytes == null) continue;
                    var stream = new MemoryStream(bytes);
                    var img = Image.FromStream(stream);
                    string path = AppDomain.CurrentDomain.BaseDirectory;//获取文件的相对路径
                    string filePath = path + @"Scripts\pictureChargStation\SaveChargeStationFile\";
                    img.Save(filePath + li.Id + "." + li.FileMime);
                    var w = img.Width;
                    var h = img.Height;
                    li.Width = w;
                    li.Height = h;
                    li.FileContext = null;
                }

                cPictureMessage.Rows = list;
                ret = Jss.Serialize(cPictureMessage);

            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            context.Response.Write(ret);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
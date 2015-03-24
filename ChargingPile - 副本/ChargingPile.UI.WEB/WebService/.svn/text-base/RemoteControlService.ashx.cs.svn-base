using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChargingPile.BLL;
using ChargingPile.Model;
using log4net;

namespace ChargingPile.UI.WEB.WebService
{
    /// <summary>
    /// Summary description for RemoteControlService
    /// </summary>
    public class RemoteControlService : IHttpHandler
    {
        protected ILog Log = LogManager.GetLogger("RemoteControlService");
        public void ProcessRequest(HttpContext context)
        {
            var action = context.Request.Params["action"];
            var str = string.Empty;
            switch (action)
            {
                case "getchargpilestate":
                    str = GetChargPileState(context);
                    break;
                case "getChargStation":
                    str = GetChargStation(context);
                    break;
            }

            context.Response.Write(str);
        }

        public string GetChargPileState(HttpContext context)
        {
            var schedulejobsbll = new ScheduleJobsBll();
            var csid = context.Request.Params["csid"];
            if (string.IsNullOrEmpty(csid))
            {
                return "{\"total\":0,\"rows\":[]}";
            }
            string str;
            var count = 0;
            try
            {
                var icsid = int.Parse(csid);
                var dt = schedulejobsbll.FindBy(icsid);
                str = ConvertToJson.DataTableToJson("rows", dt);
                str = str.Substring(1, str.Length - 2);
                str = "{\"total\":\"" + count + "\"," + str + "}";
            }
            catch (Exception e)
            {
                Log.Error(e);
                throw;
            }
            return str;
        }

        public string GetChargStation(HttpContext context)
        {
            var chargstationbll = new ChargStationBll();
            var chargstation = new ChargStation();
            string str;
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
                throw;
            }
            return str;
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
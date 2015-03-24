using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChargingPile.BLL;

namespace ChargingPile.UI.WEB.WebService
{
    /// <summary>
    /// StationTreeService 的摘要说明
    /// </summary>
    public class StationTreeService : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string treetype = context.Request.Params["treetype"];
            string id = context.Request.Params["id"];
            DTUBll dtubll = new DTUBll();
            if (treetype.Equals("piletree"))
            {
                string strOut = "";
                string nodeid = string.Empty;
                ChargStationBll csbll = new ChargStationBll();
                if (id != null)
                {
                    nodeid = id;
                }
                if (nodeid.Length == 0)
                {
                    strOut = csbll.GetAllNodes();
                }
                else
                {
                    strOut = csbll.getNode(nodeid);
                }
                context.Response.Write(strOut);
            }
            else if (treetype.Equals("dtutree"))
            {
                string strOut = "";
                string nodeid = string.Empty;
                if (id != null)
                {
                    nodeid = id;
                }
                if (nodeid.Length == 0)
                {
                    strOut = dtubll.GetAllNodes();
                }
                else
                {
                    strOut = dtubll.getNode(nodeid);
                }
                context.Response.Write(strOut);
            }

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
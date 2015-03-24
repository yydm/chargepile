using System;
using System.Web;
using System.Web.Script.Serialization;
using ChargingPile.BLL;
using ChargingPile.UI.WEB.Common;
using System.Data;
using System.IO;

namespace ChargingPile.UI.WEB.WebService
{
    /// <summary>
    /// HistoryDetail 的摘要说明
    /// </summary>
    public class HistoryDetail : IHttpHandler
    {
        protected log4net.ILog Log = log4net.LogManager.GetLogger("HistoryDetail");
        readonly JavaScriptSerializer _jss = new JavaScriptSerializer();
        readonly WarnRecBll _wrBll = new WarnRecBll();
        private const string ErrorJson = "{\"total\":0,\"rows\":[],\"msg\":\"error\"}";
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request["action"];
            if (string.IsNullOrEmpty(action))
            {
                context.Response.Write(ErrorJson);
                return;
            }
            action = action.ToLower();
            switch (action)
            {
                case "getyxhlxls":
                    GetYxhlxls(context.Request, context.Response);
                    break;
                case "expyxhlxls":
                    ExpYxhlxls(context.Request, context.Response);
                    break;
                case "getychlxls":
                    GetYchlxls(context.Request, context.Response);
                    break;
                case "expychlxls":
                    ExpYchlxls(context.Request, context.Response);
                    break;
                case "getyxbwls":
                    GetYxbwls(context.Request, context.Response);
                    break;
                case "expyxbwls":
                    ExpYxbwls(context.Request, context.Response);
                    break;
                case "getyctbls":
                    GetYctbls(context.Request, context.Response);
                    break;
                case "expyctbls":
                    ExpYctbls(context.Request, context.Response);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 查询遥信项合理性历史记录
        /// </summary>
        /// <param name="httpRequest"></param>
        /// <param name="httpResponse"></param>
        private void GetYxhlxls(HttpRequest httpRequest, HttpResponse httpResponse)
        {
            try
            {
                string tmp = httpRequest["dateBegin"] ?? "";
                DateTime dateBegin = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")).AddDays(-1);
                DateTime dateEnd = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")).AddDays(1);
                if (!string.IsNullOrEmpty(tmp))
                {
                    dateBegin = DateTime.Parse(tmp);
                }
                tmp = httpRequest["dateEnd"] ?? "";
                if (!string.IsNullOrEmpty(tmp))
                {
                    dateEnd = DateTime.Parse(tmp).AddDays(1);
                }
                int page = int.Parse(httpRequest["page"] ?? "1");
                int rows = int.Parse(httpRequest["rows"] ?? "10");
                int count = 0;
                DataTable dt = _wrBll.QueryByPage(Constant.YclxYxhlx, dateBegin, dateEnd, page, rows, ref count);
                var str = ConvertToJson.DataTableToJson("rows", dt);
                str = str.Substring(1, str.Length - 2);
                str = "{\"total\":\"" + count + "\"," + str + "}";
                httpResponse.Write(str);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                httpResponse.Write(ErrorJson);
            }
        }

        /// <summary>
        /// 导出遥信项合理性历史记录
        /// </summary>
        /// <param name="httpRequest"></param>
        /// <param name="httpResponse"></param>
        private void ExpYxhlxls(HttpRequest httpRequest, HttpResponse httpResponse)
        {
            try
            {
                string tmp = httpRequest["dateBegin"] ?? "";
                DateTime dateBegin = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")).AddDays(-1);
                DateTime dateEnd = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")).AddDays(1);
                if (!string.IsNullOrEmpty(tmp))
                {
                    dateBegin = DateTime.Parse(tmp);
                }
                tmp = httpRequest["dateEnd"] ?? "";
                if (!string.IsNullOrEmpty(tmp))
                {
                    dateEnd = DateTime.Parse(tmp).AddDays(1);
                }
                DataTable dt = _wrBll.Query(Constant.YclxYxhlx, dateBegin, dateEnd);
                string[] title = new string[]
                    {
                        "充电站", "桩类型", "桩型号", "装编号", "数据项", "设备状态值", "有效值",
                        "告警值", "实测值", "出错原因", "是否处理", "灭警方式", "灭警时间", "灭警人"
                    };
                dt.Columns.Remove("limitmin");
                dt.Columns.Remove("limitmax");
                dt.Columns.Remove("eff_min");
                dt.Columns.Remove("eff_max");
                //dt.Columns.Remove("mvalue");

                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["processflag"].ToString() == "0")
                    {
                        dr["isproc"] = "未处理";
                        dr["procm"] = "未处理";
                    }
                    else if (dr["processflag"].ToString() == "1")
                    {
                        dr["isproc"] = "已处理";
                        dr["procm"] = "自动灭警";
                    }
                    else
                    {
                        dr["isproc"] = "已处理";
                        dr["procm"] = "手动灭警";
                    }
                }
                dt.Columns.Remove("processflag");
                NpoiHelper nh = new NpoiHelper(title, dt);
                Stream ms = nh.ToExcel();
                if (null == ms)
                {
                    return;
                }
                byte[] exp = new byte[ms.Length];
                ms.Read(exp, 0, (int)ms.Length);
                httpResponse.ContentType = "application/x-zip-compressed";
                httpResponse.AddHeader("Content-Disposition", "attachment;filename=" +
                    HttpUtility.UrlEncode("遥信合理性历史.xls", System.Text.Encoding.UTF8));
                httpResponse.BinaryWrite(exp);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                httpResponse.Write(ErrorJson);
            }
        }

        /// <summary>
        /// 查询遥测合理性历史
        /// </summary>
        /// <param name="httpRequest"></param>
        /// <param name="httpResponse"></param>
        private void GetYchlxls(HttpRequest httpRequest, HttpResponse httpResponse)
        {
            try
            {
                string tmp = httpRequest["dateBegin"] ?? "";
                DateTime dateBegin = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")).AddDays(-1);
                DateTime dateEnd = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")).AddDays(1);
                if (!string.IsNullOrEmpty(tmp))
                {
                    dateBegin = DateTime.Parse(tmp);
                }
                tmp = httpRequest["dateEnd"] ?? "";
                if (!string.IsNullOrEmpty(tmp))
                {
                    dateEnd = DateTime.Parse(tmp).AddDays(1);
                }
                int page = int.Parse(httpRequest["page"] ?? "1");
                int rows = int.Parse(httpRequest["rows"] ?? "10");
                int count = 0;
                DataTable dt = _wrBll.QueryByPage(Constant.YclxYchlx, dateBegin, dateEnd, page, rows, ref count);
                var str = ConvertToJson.DataTableToJson("rows", dt);
                str = str.Substring(1, str.Length - 2);
                str = "{\"total\":\"" + count + "\"," + str + "}";
                httpResponse.Write(str);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                httpResponse.Write(ErrorJson);
            }
        }

        /// <summary>
        /// 导出遥测合理性历史
        /// </summary>
        /// <param name="httpRequest"></param>
        /// <param name="httpResponse"></param>
        private void ExpYchlxls(HttpRequest httpRequest, HttpResponse httpResponse)
        {
            try
            {
                string tmp = httpRequest["dateBegin"] ?? "";
                DateTime dateBegin = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")).AddDays(-1);
                DateTime dateEnd = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")).AddDays(1);
                if (!string.IsNullOrEmpty(tmp))
                {
                    dateBegin = DateTime.Parse(tmp);
                }
                tmp = httpRequest["dateEnd"] ?? "";
                if (!string.IsNullOrEmpty(tmp))
                {
                    dateEnd = DateTime.Parse(tmp).AddDays(1);
                }
                DataTable dt = _wrBll.Query(Constant.YclxYchlx, dateBegin, dateEnd);
                string[] title = new string[]
                    {
                        "充电站", "桩类型", "桩型号", "装编号", "数据项", "有效值最小值", "有效值最大值",
                        "实测值", "出错原因", "是否处理", "灭警方式", "灭警时间", "灭警人"
                    };
                dt.Columns.Remove("yxstates");
                dt.Columns.Remove("yxwarn");
                dt.Columns.Remove("limitmin");
                dt.Columns.Remove("limitmax");
                //dt.Columns.Remove("mvalue");
                dt.Columns.Remove("yxeff");

                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["processflag"].ToString() == "0")
                    {
                        dr["isproc"] = "未处理";
                        dr["procm"] = "未处理";
                    }
                    else if (dr["processflag"].ToString() == "1")
                    {
                        dr["isproc"] = "已处理";
                        dr["procm"] = "自动灭警";
                    }
                    else
                    {
                        dr["isproc"] = "已处理";
                        dr["procm"] = "手动灭警";
                    }
                }
                dt.Columns.Remove("processflag");

                NpoiHelper nh = new NpoiHelper(title, dt);
                Stream ms = nh.ToExcel();
                if (null == ms)
                {
                    return;
                }
                byte[] exp = new byte[ms.Length];
                ms.Read(exp, 0, (int)ms.Length);
                httpResponse.ContentType = "application/x-zip-compressed";
                httpResponse.AddHeader("Content-Disposition", "attachment;filename=" +
                    HttpUtility.UrlEncode("遥测合理性历史.xls", System.Text.Encoding.UTF8));
                httpResponse.BinaryWrite(exp);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                httpResponse.Write(ErrorJson);
            }
        }

        /// <summary>
        /// 查询遥信变位历史记录
        /// </summary>
        /// <param name="httpRequest"></param>
        /// <param name="httpResponse"></param>
        private void GetYxbwls(HttpRequest httpRequest, HttpResponse httpResponse)
        {
            try
            {
                string tmp = httpRequest["dateBegin"] ?? "";
                DateTime dateBegin = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")).AddDays(-1);
                DateTime dateEnd = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")).AddDays(1);
                if (!string.IsNullOrEmpty(tmp))
                {
                    dateBegin = DateTime.Parse(tmp);
                }
                tmp = httpRequest["dateEnd"] ?? "";
                if (!string.IsNullOrEmpty(tmp))
                {
                    dateEnd = DateTime.Parse(tmp).AddDays(1);
                }
                int page = int.Parse(httpRequest["page"] ?? "1");
                int rows = int.Parse(httpRequest["rows"] ?? "10");
                int count = 0;
                DataTable dt = _wrBll.QueryByPage(Constant.YclxYxbw, dateBegin, dateEnd, page, rows, ref count);
                var str = ConvertToJson.DataTableToJson("rows", dt);
                str = str.Substring(1, str.Length - 2);
                str = "{\"total\":\"" + count + "\"," + str + "}";
                httpResponse.Write(str);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                httpResponse.Write(ErrorJson);
            }
        }

        /// <summary>
        /// 导出遥信变位历史记录
        /// </summary>
        /// <param name="httpRequest"></param>
        /// <param name="httpResponse"></param>
        private void ExpYxbwls(HttpRequest httpRequest, HttpResponse httpResponse)
        {
            try
            {
                string tmp = httpRequest["dateBegin"] ?? "";
                DateTime dateBegin = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")).AddDays(-1);
                DateTime dateEnd = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")).AddDays(1);
                if (!string.IsNullOrEmpty(tmp))
                {
                    dateBegin = DateTime.Parse(tmp);
                }
                tmp = httpRequest["dateEnd"] ?? "";
                if (!string.IsNullOrEmpty(tmp))
                {
                    dateEnd = DateTime.Parse(tmp).AddDays(1);
                }
                DataTable dt = _wrBll.Query(Constant.YclxYxbw, dateBegin, dateEnd);
                string[] title = new string[]
                    {
                        "充电站", "桩类型", "桩型号", "装编号", "数据项", "设备状态值", "有效值",
                        "告警值", "实测值", "出错原因", "是否处理", "灭警方式", "灭警时间", "灭警人"
                    };
                dt.Columns.Remove("limitmin");
                dt.Columns.Remove("limitmax");
                dt.Columns.Remove("eff_min");
                dt.Columns.Remove("eff_max");
                //dt.Columns.Remove("mvalue");

                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["processflag"].ToString() == "0")
                    {
                        dr["isproc"] = "未处理";
                        dr["procm"] = "未处理";
                    }
                    else if (dr["processflag"].ToString() == "1")
                    {
                        dr["isproc"] = "已处理";
                        dr["procm"] = "自动灭警";
                    }
                    else
                    {
                        dr["isproc"] = "已处理";
                        dr["procm"] = "手动灭警";
                    }
                }
                dt.Columns.Remove("processflag");

                NpoiHelper nh = new NpoiHelper(title, dt);
                Stream ms = nh.ToExcel();
                if (null == ms)
                {
                    return;
                }
                byte[] exp = new byte[ms.Length];
                ms.Read(exp, 0, (int)ms.Length);
                httpResponse.ContentType = "application/x-zip-compressed";
                httpResponse.AddHeader("Content-Disposition", "attachment;filename=" +
                    HttpUtility.UrlEncode("遥信变位历史.xls", System.Text.Encoding.UTF8));
                httpResponse.BinaryWrite(exp);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                httpResponse.Write(ErrorJson);
            }
        }

        /// <summary>
        /// 查询遥测跳变历史记录
        /// </summary>
        /// <param name="httpRequest"></param>
        /// <param name="httpResponse"></param>
        private void GetYctbls(HttpRequest httpRequest, HttpResponse httpResponse)
        {
            try
            {
                string tmp = httpRequest["dateBegin"] ?? "";
                DateTime dateBegin = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")).AddDays(-1);
                DateTime dateEnd = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")).AddDays(1);
                if (!string.IsNullOrEmpty(tmp))
                {
                    dateBegin = DateTime.Parse(tmp);
                }
                tmp = httpRequest["dateEnd"] ?? "";
                if (!string.IsNullOrEmpty(tmp))
                {
                    dateEnd = DateTime.Parse(tmp).AddDays(1);
                }
                int page = int.Parse(httpRequest["page"] ?? "1");
                int rows = int.Parse(httpRequest["rows"] ?? "10");
                int count = 0;
                DataTable dt = _wrBll.QueryByPage(Constant.YclxYctb, dateBegin, dateEnd, page, rows, ref count);
                var str = ConvertToJson.DataTableToJson("rows", dt);
                str = str.Substring(1, str.Length - 2);
                str = "{\"total\":\"" + count + "\"," + str + "}";
                httpResponse.Write(str);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                httpResponse.Write(ErrorJson);
            }
        }

        /// <summary>
        /// 导出遥测跳变历史记录
        /// </summary>
        /// <param name="httpRequest"></param>
        /// <param name="httpResponse"></param>
        private void ExpYctbls(HttpRequest httpRequest, HttpResponse httpResponse)
        {
            try
            {
                string tmp = httpRequest["dateBegin"] ?? "";
                DateTime dateBegin = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")).AddDays(-1);
                DateTime dateEnd = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")).AddDays(1);
                if (!string.IsNullOrEmpty(tmp))
                {
                    dateBegin = DateTime.Parse(tmp);
                }
                tmp = httpRequest["dateEnd"] ?? "";
                if (!string.IsNullOrEmpty(tmp))
                {
                    dateEnd = DateTime.Parse(tmp).AddDays(1);
                }
                DataTable dt = _wrBll.Query(Constant.YclxYctb, dateBegin, dateEnd);
                string[] title = new string[]
                    {
                        "充电站", "桩类型", "桩型号", "装编号", "数据项", "阈值最小值", "阈值最大值", 
                        "告警值", "出错原因","是否处理", "灭警方式", "灭警时间", "灭警人"
                    };
                dt.Columns.Remove("yxstates");
                dt.Columns.Remove("yxwarn");
                dt.Columns.Remove("eff_min");
                dt.Columns.Remove("eff_max");
                //dt.Columns.Remove("mvalue");
                dt.Columns.Remove("yxeff");

                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["processflag"].ToString() == "0")
                    {
                        dr["isproc"] = "未处理";
                        dr["procm"] = "未处理";
                    }
                    else if (dr["processflag"].ToString() == "1")
                    {
                        dr["isproc"] = "已处理";
                        dr["procm"] = "自动灭警";
                    }
                    else
                    {
                        dr["isproc"] = "已处理";
                        dr["procm"] = "手动灭警";
                    }
                }
                dt.Columns.Remove("processflag");

                NpoiHelper nh = new NpoiHelper(title, dt);
                Stream ms = nh.ToExcel();
                if (null == ms)
                {
                    return;
                }
                byte[] exp = new byte[ms.Length];
                ms.Read(exp, 0, (int)ms.Length);
                httpResponse.ContentType = "application/x-zip-compressed";
                httpResponse.AddHeader("Content-Disposition", "attachment;filename=" +
                    HttpUtility.UrlEncode("遥测跳变历史.xls", System.Text.Encoding.UTF8));
                httpResponse.BinaryWrite(exp);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                httpResponse.Write(ErrorJson);
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
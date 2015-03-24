using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;
using ChargingPile.BLL;
using ChargingPile.Model;
using ChargingPile.UI.WEB.Common;

namespace ChargingPile.UI.WEB.WebService
{
    /// <summary>
    /// Yxxpz 的摘要说明
    /// </summary>
    public class Yxxpz : IHttpHandler, IRequiresSessionState
    {
        protected log4net.ILog Log = log4net.LogManager.GetLogger("Yxxpz");
        readonly JavaScriptSerializer _jss = new JavaScriptSerializer();
        private const string ErrorJson = "{\"total\":0,\"rows\":[],\"status\":\"0\",\"msg\":\"error\"}";

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/octet-stream";
            string action = context.Request["action"];
            string ret = "{\"total\":0,\"rows\":[],\"status\":\"0\",\"msg\":\"error\"}";
            if (string.IsNullOrEmpty(action))
            {
                context.Response.Write(ErrorJson);
                return;
            }
            action = action.ToLower();
            switch (action)
            {
                case "getyxxdata":
                    ret = GetYxxData(context);
                    break;
                case "getycxdata":
                    ret = GetYcxData(context);
                    break;
                case "getchangjia":
                    ret = GetChangJia(context);
                    break;
                case "getxhbychangjia":
                    ret = GetXhByChangJia(context);
                    break;
                case "getsjx":
                    ret = GetSjx(context);
                    break;
                case "yxxsave":
                    ret = YxxSave(context);
                    break;
                case "ycxsave":
                    ret = YcxSave(context);
                    break;
                case "ycxedit":
                    ret = YcxEdit(context);
                    break;
                case "yxxedit":
                    ret = YxxEdit(context);
                    break;
                case "getsjxpz":
                    ret = GetSjxpz(context);
                    break;
                case "sjxdel":
                    ret = SjxDel(context);
                    break;
                default:
                    break;
            }
            context.Response.Write(ret);
        }

        /// <summary>
        /// 获取遥信项数据
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetYxxData(HttpContext context)
        {
            try
            {
                PointCfgBll pointCfgBll = new PointCfgBll();
                int page = int.Parse(context.Request["page"] ?? "1");
                int rows = int.Parse(context.Request["rows"] ?? "10");
                string xh = context.Request["xh"] ?? "";
                string sjx = context.Request["sjx"] ?? "";
                int count = 0;
                DataTable dt = pointCfgBll.QueryBySjlx(Constant.SjlxYx, xh, sjx, page, rows, ref count);
                List<PointCfg> list = ConvertHelper<PointCfg>.ConvertToList(dt);
                PageObject<PointCfg> pObject = new PageObject<PointCfg>(count, list);
                return _jss.Serialize(pObject);
            }
            catch (Exception e)
            {
                Log.Error("GetYxxData方法出错：" + e);
                return ErrorJson;
            }
        }



        /// <summary>
        /// 获取遥测项数据
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetYcxData(HttpContext context)
        {
            try
            {
                PointCfgBll pointCfgBll = new PointCfgBll();
                int page = int.Parse(context.Request["page"] ?? "1");
                int rows = int.Parse(context.Request["rows"] ?? "10");
                string xh = context.Request["xh"] ?? "";
                string sjx = context.Request["sjx"] ?? "";
                int count = 0;
                DataTable dt = pointCfgBll.QueryBySjlx(Constant.SjlxYc, xh, sjx, page, rows, ref count);
                List<PointCfg> list = ConvertHelper<PointCfg>.ConvertToList(dt);
                PageObject<PointCfg> pObject = new PageObject<PointCfg>(count, list);
                return _jss.Serialize(pObject);
            }
            catch (Exception e)
            {
                Log.Error("GetYcxData方法出错：" + e);
                return ErrorJson;
            }
        }

        /// <summary>
        /// 加载数据项
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetSjx(HttpContext context)
        {
            string dataType = context.Request["datatype"] ?? "";
            if (dataType.ToUpper().Equals(Constant.SjlxYx))
            {
                dataType = Constant.SjlxYx;
            }
            else if (dataType.ToUpper().Equals(Constant.SjlxYc))
            {
                dataType = Constant.SjlxYc;
            }
            else
            { }
            string zhuangxing_h = context.Request["zhuangxing_h"] ?? "";
            GatItemBll gatItemBll = new GatItemBll();
            DataTable dt = gatItemBll.QuerySjxNotUse(dataType, zhuangxing_h);
            var list = ConvertHelper<GatItem>.ConvertToList(dt);
            return _jss.Serialize(list);
        }

        /// <summary>
        /// 查询桩型号
        /// </summary>
        /// <param name="context.Request"></param>
        /// <returns></returns>
        private string GetXhByChangJia(HttpContext context)
        {
            string changJia = context.Request["changjia"] ?? "";
            ChargPileTypeBll cptb = new ChargPileTypeBll();
            DataTable dt = cptb.Query(new ChargPileTypes() { CHANGJIA = changJia });
            var list = ConvertHelper<ChargPileTypes>.ConvertToList(dt);
            return _jss.Serialize(list);
        }

        /// <summary>
        /// 查询桩厂家
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetChangJia(HttpContext context)
        {
            ChargPileTypeBll chargPileTypeBll = new ChargPileTypeBll();
            var list = ConvertHelper<ChargPileTypes>.ConvertToList(chargPileTypeBll.QueryChangJia());
            return _jss.Serialize(list);
        }

        /// <summary>
        /// 保存遥测项数据
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string YcxSave(HttpContext context)
        {
            try
            {
                string zcj = context.Request["s_zcj"] ?? "",
                       zxh = context.Request["s_zxh"] ?? "",
                       zlx = context.Request["i_zlx"] ?? "",
                       sjx = context.Request["s_sjx"] ?? "",
                       yzzxz = context.Request["i_yzzxz"],
                       yzzdz = context.Request["i_yzzdz"],
                       cyzgj = context.Request["i_cyzgj"] ?? "0",
                       yxzzxz = context.Request["i_yxzzxz"],
                       yxzzdz = context.Request["i_yxzzdz"],
                       cyxzgj = context.Request["i_cyxzgj"] ?? "0",
                       dx = context.Request["i_dx"] ?? "",
                       sjh = context.Request["i_sjh"] ?? "",
                       dxmb = context.Request["h_dxmb"] ?? "",
                       yj = context.Request["i_yj"] ?? "",
                       yxdz = context.Request["i_yxdz"] ?? "",
                       yjmb = context.Request["h_yjmb"] ?? "",
                       fs = context.Request["i_fs"] ?? "",
                       sfzdmj = context.Request["i_sfzdmj"] ?? "0",
                       zdmjgz = context.Request["s_zdmjgz"] ?? "",
                       isuse = context.Request["i_sfqy"] ?? "0";

                HttpPostedFile file = context.Request.Files["i_sywj"];
                Stream sywj = null;
                string sygs = null;
                int fileSize = 0;
                byte[] fileBuffer = null;
                if (fs.Length > 0 && file == null)
                {
                    return "{\"total\":0,\"rows\":[],\"status\":\"0\",\"msg\":\"声音文件为空。\"}";
                }
                else if (fs.Length > 0 && file != null)
                {
                    sywj = file.InputStream;
                    sygs = file.FileName.Substring(file.FileName.LastIndexOf('.')).ToLower();
                    if (!sygs.Equals("mp3") && !sygs.Equals("wma"))
                    {
                        return "{\"total\":0,\"rows\":[],\"status\":\"0\",\"msg\":\"声音格式不正确，请使用MP3、wma格式文件。\"}";
                    }
                    fileSize = file.ContentLength;
                    if (fileSize > 20480000)
                    {
                        return "{\"total\":0,\"rows\":[],\"status\":\"0\",\"msg\":\"声音文件过大，请选择其他声音文件。\"}";
                    }
                    fileBuffer = new byte[fileSize];
                    sywj.Read(fileBuffer, 0, fileSize);
                }
                PointCfg pointCfg = new PointCfg()
                    {
                        ZhuangLeiX = zlx,
                        GatItemId = sjx,
                        IsOverLimtWarn = int.Parse(cyzgj),
                        IsOverEffWarn = int.Parse(cyxzgj),
                        Dx = dx == "on" ? Constant.GjfsDx : "",
                        Yj = yj == "on" ? Constant.GjfsYj : "",
                        Sy = fs == "on" ? Constant.GjfsSy : "",
                        IsAutoCleanWarn = decimal.Parse(sfzdmj),
                        IsUse = int.Parse(isuse),
                    };
                if (!string.IsNullOrEmpty(yzzxz))
                {
                    pointCfg.LimitMin = decimal.Parse(yzzxz);
                }
                if (!string.IsNullOrEmpty(yzzdz))
                {
                    pointCfg.LimitMax = decimal.Parse(yzzdz);
                }
                if (!string.IsNullOrEmpty(yxzzxz))
                {
                    pointCfg.Eff_Min = decimal.Parse(yxzzxz);
                }
                if (!string.IsNullOrEmpty(yxzzdz))
                {
                    pointCfg.Eff_Max = decimal.Parse(yxzzdz);
                }
                if (!string.IsNullOrEmpty(pointCfg.Dx))
                {
                    pointCfg.Sjh = sjh;
                    pointCfg.Dxmb = dxmb;
                }
                if (!string.IsNullOrEmpty(pointCfg.Yj))
                {
                    pointCfg.Yxdz = yxdz;
                    pointCfg.Yjmb = yjmb;
                }
                if (!string.IsNullOrEmpty(pointCfg.Sy))
                {
                    pointCfg.SndFileContext = fileBuffer;
                    pointCfg.SndFileType = sygs;
                }
                if (pointCfg.IsAutoCleanWarn == 1)
                {
                    pointCfg.CleanWarnRule = decimal.Parse(zdmjgz);
                }
                new PointCfgBll().Add(pointCfg);
                //操作日志
                string name = "";
                if (null != context.Session[Constant.LoginUser])
                {
                    name = (context.Session[Constant.LoginUser] as Employer ?? new Employer()).Name;
                }
                else
                {
                    return "{\"total\":0,\"rows\":[],\"status\":\"2\",\"msg\":\"修改成功！\"}";
                }
                new OprLogBll().Add(new OprLog()
                    {
                        DataItemId = sjx,
                        Operator = name,
                        OprSrc = "保存遥测项数据",
                        OperResult = "成功",
                        LogDate = DateTime.Now
                    });
                return "{\"total\":0,\"rows\":[],\"status\":\"1\",\"msg\":\"保存成功！\"}";
            }
            catch (Exception e)
            {
                Log.Error("YcxSave方法报错：" + e);
                return "{\"total\":0,\"rows\":[],\"status\":\"0\",\"msg\":\"保存出错，请稍后再试。\"}";
            }
        }

        /// <summary>
        /// 保存遥测编辑数据
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string YcxEdit(HttpContext context)
        {
            try
            {
                string Id = context.Request["h_id"] ?? "",
                       zcj = context.Request["s_zcj"] ?? "",
                       zxh = context.Request["s_zxh"] ?? "",
                       zlx = context.Request["i_zlx"] ?? "",
                       sjx = context.Request["s_sjx"] ?? "",
                       yzzxz = context.Request["i_yzzxz"],
                       yzzdz = context.Request["i_yzzdz"],
                       cyzgj = context.Request["i_cyzgj"] ?? "0",
                       yxzzxz = context.Request["i_yxzzxz"],
                       yxzzdz = context.Request["i_yxzzdz"],
                       cyxzgj = context.Request["i_cyxzgj"] ?? "0",
                       dx = context.Request["i_dx"] ?? "",
                       sjh = context.Request["i_sjh"] ?? "",
                       dxmb = context.Request["h_dxmb"] ?? "",
                       yj = context.Request["i_yj"] ?? "",
                       yxdz = context.Request["i_yxdz"] ?? "",
                       yjmb = context.Request["h_yjmb"] ?? "",
                       fs = context.Request["i_fs"] ?? "",
                       sfzdmj = context.Request["i_sfzdmj"] ?? "0",
                       zdmjgz = context.Request["s_zdmjgz"] ?? "",
                       sylx = context.Request["h_sylx"] ?? "",
                       isuse = context.Request["i_sfqy"] ?? "0";

                HttpPostedFile file = context.Request.Files["i_sywj"];
                Stream sywj = null;
                string sygs = null;
                int fileSize = 0;
                byte[] fileBuffer = null;
                if (fs.Length > 0 && file == null && string.IsNullOrEmpty(sylx))
                {
                    return "{\"total\":0,\"rows\":[],\"status\":\"0\",\"msg\":\"声音文件为空。\"}";
                }
                else if (fs.Length > 0 && file != null)
                {
                    sywj = file.InputStream;
                    sygs = file.FileName.Substring(file.FileName.LastIndexOf('.') + 1).ToLower();
                    if (!sygs.Equals("mp3") && !sygs.Equals("wma"))
                    {
                        return "{\"total\":0,\"rows\":[],\"status\":\"0\",\"msg\":\"声音文件格式不正确，请使用MP3、wma格式文件。\"}";
                    }
                    fileSize = file.ContentLength;
                    if (fileSize > 20480000)
                    {
                        return "{\"total\":0,\"rows\":[],\"status\":\"0\",\"msg\":\"声音文件过大，请选择其他声音文件。\"}";
                    }
                    fileBuffer = new byte[fileSize];
                    sywj.Read(fileBuffer, 0, fileSize);
                }
                PointCfg pointCfg = new PointCfg()
                {
                    Id = Id,
                    ZhuangLeiX = zlx,
                    GatItemId = sjx,
                    IsOverLimtWarn = int.Parse(cyzgj),
                    IsOverEffWarn = int.Parse(cyxzgj),
                    Dx = dx == "on" ? Constant.GjfsDx : "",
                    Yj = yj == "on" ? Constant.GjfsYj : "",
                    Sy = fs == "on" ? Constant.GjfsSy : "",
                    IsAutoCleanWarn = decimal.Parse(sfzdmj),
                    IsUse = int.Parse(isuse),
                };
                if (!string.IsNullOrEmpty(zlx))
                {
                    pointCfg.ZhuangLeiX = zlx;
                }
                if (!string.IsNullOrEmpty(sjx))
                {
                    pointCfg.GatItemId = sjx;
                }
                if (!string.IsNullOrEmpty(yzzxz))
                {
                    pointCfg.LimitMin = decimal.Parse(yzzxz);
                }
                if (!string.IsNullOrEmpty(yzzdz))
                {
                    pointCfg.LimitMax = decimal.Parse(yzzdz);
                }
                if (!string.IsNullOrEmpty(yxzzxz))
                {
                    pointCfg.Eff_Min = decimal.Parse(yxzzxz);
                }
                if (!string.IsNullOrEmpty(yxzzdz))
                {
                    pointCfg.Eff_Max = decimal.Parse(yxzzdz);
                }
                if (!string.IsNullOrEmpty(pointCfg.Dx))
                {
                    pointCfg.Sjh = sjh;
                    pointCfg.Dxmb = dxmb;
                }
                if (!string.IsNullOrEmpty(pointCfg.Yj))
                {
                    pointCfg.Yxdz = yxdz;
                    pointCfg.Yjmb = yjmb;
                }
                if (!string.IsNullOrEmpty(pointCfg.Sy) && fileSize != 0)
                {
                    pointCfg.SndFileContext = fileBuffer;
                }
                pointCfg.SndFileType = sygs ?? sylx;
                if (pointCfg.IsAutoCleanWarn == 1)
                {
                    pointCfg.CleanWarnRule = decimal.Parse(zdmjgz);
                }
                new PointCfgBll().Modify(pointCfg);
                //操作日志
                string name = "";
                if (null != context.Session[Constant.LoginUser])
                {
                    name = (context.Session[Constant.LoginUser] as Employer ?? new Employer()).Name;
                }
                else
                {
                    return "{\"total\":0,\"rows\":[],\"status\":\"2\",\"msg\":\"修改成功！\"}";
                }
                new OprLogBll().Add(new OprLog()
                {
                    DataItemId = sjx,
                    Operator = name,
                    OprSrc = "保存遥测编辑数据",
                    OperResult = "成功",
                    LogDate = DateTime.Now
                });
                return "{\"total\":0,\"rows\":[],\"status\":\"1\",\"msg\":\"修改成功！\"}";
            }
            catch (Exception e)
            {
                Log.Error("YcxEdit方法报错：" + e);
                return "{\"total\":0,\"rows\":[],\"status\":\"0\",\"msg\":\"修改出错，请稍后再试。\"}";
            }
        }

        /// <summary>
        /// 新增遥信项数据
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string YxxSave(HttpContext context)
        {
            try
            {
                string zlx = context.Request["i_zlx"] ?? "",
                       sjx = context.Request["s_sjx"] ?? "",
                       ztz = context.Request["i_ztz"] ?? "",
                       sbzcz = context.Request["i_ztz"] ?? "",
                       sbgjz = context.Request["i_sbgjz"] ?? "",
                       cyzgj = context.Request["i_cyzgj"] ?? "0",
                       dx = context.Request["i_dx"] ?? "",
                       sjh = context.Request["i_sjh"] ?? "",
                       dxmb = context.Request["h_dxmb"] ?? "",
                       yj = context.Request["i_yj"] ?? "",
                       yxdz = context.Request["i_yxdz"] ?? "",
                       yjmb = context.Request["h_yjmb"] ?? "",
                       fs = context.Request["i_fs"] ?? "",
                       sfzdmj = context.Request["i_sfzdmj"] ?? "0",
                       zdmjgz = context.Request["s_zdmjgz"] ?? "",
                       isuse = context.Request["getYxxData"] ?? "0";

                HttpPostedFile file = context.Request.Files["i_sywj"];
                Stream sywj = null;
                string sygs = null;
                int fileSize = 0;
                byte[] fileBuffer = null;
                if (fs.Length > 0 && file == null)
                {
                    return "{\"total\":0,\"rows\":[],\"status\":\"0\",\"msg\":\"声音文件为空。\"}";
                }
                else if (fs.Length > 0 && file != null)
                {
                    sywj = file.InputStream;
                    sygs = file.FileName.Substring(file.FileName.LastIndexOf('.')).ToLower();
                    if (!sygs.Equals("mp3") && !sygs.Equals("wma"))
                    {
                        return "{\"total\":0,\"rows\":[],\"status\":\"0\",\"msg\":\"声音文件格式不正确，请使用MP3、wma格式文件。\"}";
                    }
                    fileSize = file.ContentLength;
                    if (fileSize > 20480000)
                    {
                        return "{\"total\":0,\"rows\":[],\"status\":\"0\",\"msg\":\"声音过大，请选择其他声音文件。\"}";
                    }
                    fileBuffer = new byte[fileSize];
                    sywj.Read(fileBuffer, 0, fileSize);
                }
                PointCfg pointCfg = new PointCfg()
                {
                    ZhuangLeiX = zlx,
                    GatItemId = sjx,
                    IsOverLimtWarn = int.Parse(cyzgj),
                    Dx = dx == "on" ? Constant.GjfsDx : "",
                    Yj = yj == "on" ? Constant.GjfsYj : "",
                    Sy = fs == "on" ? Constant.GjfsSy : "",
                    IsAutoCleanWarn = decimal.Parse(sfzdmj),
                    IsUse = int.Parse(isuse),
                };
                if (!string.IsNullOrEmpty(ztz))
                {
                    pointCfg.YxStates = ztz;
                }
                if (!string.IsNullOrEmpty(sbzcz))
                {
                    pointCfg.YxEff = sbzcz;
                }
                if (!string.IsNullOrEmpty(sbgjz))
                {
                    pointCfg.YxWarn = sbgjz;
                }
                if (!string.IsNullOrEmpty(pointCfg.Dx))
                {
                    pointCfg.Sjh = sjh;
                    pointCfg.Dxmb = dxmb;
                }
                if (!string.IsNullOrEmpty(pointCfg.Yj))
                {
                    pointCfg.Yxdz = yxdz;
                    pointCfg.Yjmb = yjmb;
                }
                if (!string.IsNullOrEmpty(pointCfg.Sy))
                {
                    pointCfg.SndFileContext = fileBuffer;
                    pointCfg.SndFileType = sygs;
                }
                if (pointCfg.IsAutoCleanWarn == 1)
                {
                    pointCfg.CleanWarnRule = decimal.Parse(zdmjgz);
                }
                new PointCfgBll().Add(pointCfg);
                //操作日志
                string name = "";
                if (null != context.Session[Constant.LoginUser])
                {
                    name = (context.Session[Constant.LoginUser] as Employer ?? new Employer()).Name;
                }
                else
                {
                    return "{\"total\":0,\"rows\":[],\"status\":\"2\",\"msg\":\"修改成功！\"}";
                }
                new OprLogBll().Add(new OprLog()
                {
                    DataItemId = sjx,
                    Operator = name,
                    OprSrc = "新增遥信项数据",
                    OperResult = "成功",
                    LogDate = DateTime.Now
                });
                return "{\"total\":0,\"rows\":[],\"status\":\"1\",\"msg\":\"保存成功！\"}";
            }
            catch (Exception e)
            {
                Log.Error("YxxSave方法报错：" + e);
                return "{\"total\":0,\"rows\":[],\"status\":\"0\",\"msg\":\"保存出错，请稍后再试。\"}";
            }
        }

        /// <summary>
        /// 保存遥信项编辑
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string YxxEdit(HttpContext context)
        {
            try
            {
                string id = context.Request["h_id"] ?? "",
                       zlx = context.Request["i_zlx"] ?? "",
                       sjx = context.Request["s_sjx"] ?? "",
                       ztz = context.Request["i_ztz"] ?? "",
                       sbzcz = context.Request["i_ztz"] ?? "",
                       sbgjz = context.Request["i_sbgjz"] ?? "",
                       cyzgj = context.Request["i_cyzgj"] ?? "0",
                       dx = context.Request["i_dx"] ?? "",
                       sjh = context.Request["i_sjh"] ?? "",
                       dxmb = context.Request["h_dxmb"] ?? "",
                       yj = context.Request["i_yj"] ?? "",
                       yxdz = context.Request["i_yxdz"] ?? "",
                       yjmb = context.Request["h_yjmb"] ?? "",
                       fs = context.Request["i_fs"] ?? "",
                       sfzdmj = context.Request["i_sfzdmj"] ?? "0",
                       zdmjgz = context.Request["s_zdmjgz"] ?? "",
                       sylx = context.Request["h_sylx"] ?? "",
                       isuse = context.Request["i_sfqy"] ?? "0";

                HttpPostedFile file = context.Request.Files["i_sywj"];
                Stream sywj = null;
                string sygs = null;
                int fileSize = 0;
                byte[] fileBuffer = null;
                if (fs.Length > 0 && file == null && string.IsNullOrEmpty(sylx))
                {
                    return "{\"total\":0,\"rows\":[],\"status\":\"0\",\"msg\":\"声音文件为空。\"}";
                }
                else if (fs.Length > 0 && file != null)
                {
                    sywj = file.InputStream;
                    sygs = file.FileName.Substring(file.FileName.LastIndexOf('.') + 1).ToLower();
                    if (!sygs.Equals("mp3") && !sygs.Equals("wma"))
                    {
                        return "{\"total\":0,\"rows\":[],\"status\":\"0\",\"msg\":\"声音文件格式不正确，请使用mp3、wma格式文件。\"}";
                    }
                    fileSize = file.ContentLength;
                    if (fileSize > 20480000)
                    {
                        return "{\"total\":0,\"rows\":[],\"status\":\"0\",\"msg\":\"声音文件过大，请选择其他声音文件。\"}";
                    }
                    fileBuffer = new byte[fileSize];
                    sywj.Read(fileBuffer, 0, fileSize);
                }
                PointCfg pointCfg = new PointCfg()
                {
                    Id = id,
                    ZhuangLeiX = zlx,
                    GatItemId = sjx,
                    IsOverLimtWarn = int.Parse(cyzgj),
                    Dx = dx == "on" ? Constant.GjfsDx : "",
                    Yj = yj == "on" ? Constant.GjfsYj : "",
                    Sy = fs == "on" ? Constant.GjfsSy : "",
                    IsAutoCleanWarn = decimal.Parse(sfzdmj),
                    IsUse = int.Parse(isuse),
                };
                if (!string.IsNullOrEmpty(zlx))
                {
                    pointCfg.ZhuangLeiX = zlx;
                }
                if (!string.IsNullOrEmpty(sjx))
                {
                    pointCfg.GatItemId = sjx;
                }
                if (!string.IsNullOrEmpty(ztz))
                {
                    pointCfg.YxStates = ztz;
                }
                if (!string.IsNullOrEmpty(sbzcz))
                {
                    pointCfg.YxEff = sbzcz;
                }
                if (!string.IsNullOrEmpty(sbgjz))
                {
                    pointCfg.YxWarn = sbgjz;
                }
                if (!string.IsNullOrEmpty(pointCfg.Dx))
                {
                    pointCfg.Sjh = sjh;
                    pointCfg.Dxmb = dxmb;
                }
                if (!string.IsNullOrEmpty(pointCfg.Yj))
                {
                    pointCfg.Yxdz = yxdz;
                    pointCfg.Yjmb = yjmb;
                }
                if (!string.IsNullOrEmpty(pointCfg.Sy) && fileSize != 0)
                {
                    pointCfg.SndFileContext = fileBuffer;
                }
                pointCfg.SndFileType = sygs ?? sylx;
                if (pointCfg.IsAutoCleanWarn == 1)
                {
                    pointCfg.CleanWarnRule = decimal.Parse(zdmjgz);
                }
                new PointCfgBll().Modify(pointCfg);
                //操作日志
                string name = "";
                if (null != context.Session[Constant.LoginUser])
                {
                    name = (context.Session[Constant.LoginUser] as Employer ?? new Employer()).Name;
                }
                else
                {
                    return "{\"total\":0,\"rows\":[],\"status\":\"2\",\"msg\":\"修改成功！\"}";
                }
                new OprLogBll().Add(new OprLog()
                {
                    DataItemId = sjx,
                    Operator = name,
                    OprSrc = "保存遥信项编辑",
                    OperResult = "成功",
                    LogDate = DateTime.Now
                });
                return "{\"total\":0,\"rows\":[],\"status\":\"1\",\"msg\":\"修改成功！\"}";
            }
            catch (Exception e)
            {
                Log.Error("YcxSave方法报错：" + e);
                return "{\"total\":0,\"rows\":[],\"status\":\"0\",\"msg\":\"修改出错，请稍后再试。\"}";
            }
        }

        /// <summary>
        /// 获取数据项配置
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetSjxpz(HttpContext context)
        {
            try
            {
                PointCfgBll pointCfgBll = new PointCfgBll();
                string id = context.Request["id"] ?? "";
                PointCfg pointCfg = pointCfgBll.QueryEntity(new PointCfg() { Id = id });
                return _jss.Serialize(pointCfg);
            }
            catch (Exception e)
            {
                Log.Error("GetSjxpz出错：" + e);
                return ErrorJson;
            }
        }

        /// <summary>
        /// 删除数据项，并且根据数据类型返回遥测或者遥信数据项配置列表
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string SjxDel(HttpContext context)
        {
            try
            {
                string sjlx = context.Request["sjlx"] ?? "";
                string id = context.Request["id"] ?? "";

                //删除
                PointCfgBll pointCfgBll = new PointCfgBll();
                pointCfgBll.Del(new PointCfg() { Id = id });
                //操作日志
                string name = "";
                if (null != context.Session[Constant.LoginUser])
                {
                    name = (context.Session[Constant.LoginUser] as Employer ?? new Employer()).Name;
                }
                else
                {
                    return "{\"total\":0,\"rows\":[],\"status\":\"2\",\"msg\":\"修改成功！\"}";
                }
                new OprLogBll().Add(new OprLog()
                {
                    Operator = name,
                    OprSrc = "删除数据项配置，ID：" + id,
                    OperResult = "成功",
                    LogDate = DateTime.Now
                });
                //查询
                if (sjlx.ToUpper().Equals(Constant.SjlxYc))
                {
                    return GetYcxData(context);
                }
                else if (sjlx.ToUpper().Equals(Constant.SjlxYx))
                {
                    return GetYxxData(context);
                }
                else
                {
                    return ErrorJson;
                }
            }
            catch (Exception e)
            {
                Log.Error("SjxDel出错：" + e);
                return ErrorJson;
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
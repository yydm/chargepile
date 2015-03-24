using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using ChargingPile.BLL;
using System.Data;
using ChargingPile.Model;
using ChargingPile.UI.WEB.Common;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Web.SessionState;
using System.Web.UI;


namespace ChargingPile.UI.WEB.WebService
{
    /// <summary>
    /// ChargStationService 的摘要说明
    /// </summary>
    public class ChargStationService : IHttpHandler, IRequiresSessionState
    {
        protected log4net.ILog Log = log4net.LogManager.GetLogger("ChargStationService");
        JavaScriptSerializer jss = new JavaScriptSerializer();
        ChargStationBll csbll = new ChargStationBll();
        ChargPileBll cpbll = new ChargPileBll();
        //MapService.WCFDataRequestClient mapservice = new MapService.WCFDataRequestClient();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string action = context.Request["action"];
            if (string.IsNullOrEmpty(action))
            {
                return;
            }
            if (action.Equals("getstation"))
            {
                GetChargStation(context);
            }
            else if (action.Equals("getcp"))
            {
                GetPileByStation(context);
            }
            else if (action.Equals("getboxcounts"))
            {
                GetBcountsByStation(context);
            }
            else if (action.Equals("gettype"))
            {
                GetPileType(context);
            }
            else if (action.Equals("getboxsl"))
            {
                GetBoxSl(context);
            }
            else if (action.Equals("getpicture"))
            {
                GetPictureByZhanID(context);
            }
            else if (action.Equals("delimage"))
            {
                DelImgByImgsrc(context);
            }
            else if (action.Equals("checkyxbh"))
            {
                checkYXBH(context);
            }
            else if (action.Equals("delpicture"))
            {
                DelPictureByID(context);
            }
            else if (action.Equals("gettypexh"))
            {
                GetXHByCJ(context);
            }
            else if (action.Equals("getzhanid"))
            {
                GetStationID(context);
            }
            else if (action.Equals("addBranch"))
            {
                AddBranch(context);
            }
            else if (action.Equals("d_addbranch"))
            {
                AddBranch_editstation(context);
            }
            else if (action.Equals("d_addpile"))
            {
                AddPile_editstation(context);
            }
            else if (action.Equals("addstation"))
            {
                AddStation(context);
            }
            else if (action.Equals("editstation"))
            {
                EditStation(context);
            }
            else if (action.Equals("editstation1"))
            {
                EditStation1(context);
            }
            else if (action.Equals("delstation"))
            {
                DelStation(context);
            }
            else if (action.Equals("delbranch"))
            {
                DelBranch(context);
            }
            else if (action.Equals("savepile"))
            {
                SavePile(context);
            }
            else if (action.Equals("savetypes"))
            {
                SaveTypes(context);
            }
            else if (action.Equals("getpile"))
            {
                GetPile(context);
            }
            else if (action.Equals("editbranch"))
            {
                EditBranch(context);
            }
            else if (action.Equals("delpile"))
            {
                DelPile(context);
            }
            else if (action.Equals("getstationbyid"))
            {
                GetStationByID(context);
            }
            else if (action.Equals("loadpicture"))
            {
                GetChargStationFile(context);
            }

        }
        /// <summary>
        /// 验证同一个场站内,桩运行编号是否重复
        /// </summary>
        /// <param name="context"></param>
        private void checkYXBH(HttpContext context)
        {
            try
            {
                string yxbh = context.Request["yxbh"].ToString();
                string id = context.Request["id"].ToString();
                string zhanbh = id.Substring(0,3);
                DataTable dt1 = cpbll.QueryPileByYXBHandZBH(yxbh,zhanbh);
                DataTable dt2 = cpbll.QueryPileByYXBHandID(yxbh,id,zhanbh);
                if (dt1.Rows.Count > 0 && dt2.Rows.Count <= 0)
                {
                    context.Response.Write("{\"success\":true,\"msg\":\"桩运行编号已存在！\"}");
                }
                else
                {
                    context.Response.Write("{\"success\":false,\"msg\":\"\"}");
                }
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
        /// <summary>
        /// 根据id删除图片
        /// </summary>
        /// <param name="context"></param>
        private void DelPictureByID(HttpContext context)
        {
            try
            {
                string id = context.Request["id"].ToString();
                csbll.DelPicture(id);
                context.Response.Write("{\"success\":true,\"msg\":\"删除成功！\"}");
            }
            catch (Exception e)
            {
                Log.Error(e);
                context.Response.Write("{\"success\":false,\"msg\":\"删除失败！\"}");
            }
        }
        //根据图片路径删除图片
        private void DelImgByImgsrc(HttpContext context)
        {
            try
            {
                string imgsrc = context.Request["imgSrc"].ToString();
                String strPath = System.Web.HttpContext.Current.Server.MapPath(imgsrc);
                File.Delete(strPath);
                context.Response.Write("{\"success\":true,\"msg\":\"删除成功！\"}");
            }
            catch (Exception e)
            {
                Log.Error(e);
                context.Response.Write("{\"success\":false,\"msg\":\"删除失败！\"}");
            }
        }
        /// <summary>
        /// 通过场站id获取图片
        /// </summary>
        /// <param name="context"></param>
        private void GetPictureByZhanID(HttpContext context)
        {
            try
            {
                decimal zhanbh = decimal.Parse(context.Request["zhanbh"].ToString());
                ChargStationBll csbll = new ChargStationBll();
                DataTable dt = csbll.GetPicture(zhanbh);
                var list = ConvertHelper<ChargStationFile>.ConvertToList(dt);
                PageObject<ChargStationFile> pageO = new PageObject<ChargStationFile>();
                pageO.total = list.Count;
                pageO.rows = list;
                var str = jss.Serialize(pageO);
                context.Response.Write(str);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
        /// <summary>
        /// 根据站id获取分支箱数量
        /// </summary>
        /// <param name="context"></param>
        private void GetBoxSl(HttpContext context)
        {
            try
            {
                decimal zhanbh = decimal.Parse(context.Request["zhanbh"].ToString());
                ChargStationBll csbll = new ChargStationBll();
                DataTable dt = csbll.GetBoxsl(zhanbh);
                var list = ConvertHelper<Branch>.ConvertToList(dt);
                PageObject<Branch> pageO = new PageObject<Branch>();
                pageO.total = list.Count;
                pageO.rows = list;
                var str = jss.Serialize(pageO);
                context.Response.Write(str);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
        /// <summary>
        /// 加载图片
        /// </summary>
        /// <param name="context"></param>
        public void GetChargStationFile(HttpContext context)
        {
            var chargstationfilebll = new ChargStationFileBll();
            var fileid = context.Request.Params["fileid"];
            var chargstationfile = new ChargStationFile
            {
                Id = fileid
            };
            byte[] bytes;
            try
            {
                var dt = chargstationfilebll.Query(chargstationfile);
                bytes = dt.Rows[0]["FILECONTEXT"] as byte[];

            }
            catch (Exception e)
            {
                Log.Error(e);
                throw;
            }
            if (bytes != null)
                context.Response.BinaryWrite(bytes);
        }


        /// <summary>
        /// 添加充电站
        /// </summary>
        /// <param name="context"></param>
        private void AddStation(HttpContext context)
        {
            try
            {

                string zhanbh = "";
                string ZhuanMc = context.Request["ZhuanMc"].ToString();
                bool b = csbll.QueryZhanIFExit(ZhuanMc);
                if (b == false)
                {
                    context.Response.Write("{\"success\":false,\"msg\":\"充电场站名称已存在！\"}");
                    return;
                }
                string XiangXiDz = context.Request["XiangXiDz"].ToString();
                decimal Longtude = decimal.Parse(context.Request["Longtude"].ToString());
                decimal Latitude = decimal.Parse(context.Request["Latitude"].ToString());
                string YeZhuDw = context.Request["YeZhuDw"].ToString();
                string LianXiR = context.Request["LianXiR"].ToString();
                string LianXiDh = context.Request["LianXiDh"].ToString();
                decimal BoxCounts = decimal.Parse(context.Request["BoxCounts"].ToString());
                DateTime CreateDT = DateTime.Parse(context.Request["CreateDT"].ToString());
                string sj = context.Request["TouYun_Sj"] ?? "";
                DateTime TouYun_Sj = new DateTime();
                if (sj.Length > 0)
                {
                    TouYun_Sj = DateTime.Parse(sj);
                }
                ChargStation chargstation = new ChargStation();
                chargstation.ZhuanMc = ZhuanMc;
                chargstation.XiangXiDz = XiangXiDz;
                chargstation.Longtude = Longtude;
                chargstation.Latitude = Latitude;
                chargstation.YeZhuDw = YeZhuDw;
                chargstation.LianXiDh = LianXiDh;
                chargstation.LianXiR = LianXiR;
                chargstation.BoxCounts = BoxCounts;
                chargstation.CreateDT = CreateDT;
                chargstation.TouYun_Sj = TouYun_Sj;


                csbll.Add(chargstation);

                //DataTable dte = csbll.QueryZhanIdByMC(ZhuanMc);
                //zhanbh = dte.Rows[0]["zhanbh"].ToString();
                //string json = "{\"ZHAN_BH\":" + zhanbh + ",\"ZHUAN_MC\":\"" + ZhuanMc
                //    + "\",\"YEZHU_DW\":\"" + YeZhuDw + "\", \"LIANXI_R\":\"" + LianXiR + "\",\"LIANXI_DH\":\"" + LianXiDh
                //    + "\",\"ZHUANGLEI_X\":\"\",\"ZHUANGCHANG_J\":\"\",\"XIANGXI_DZ\":\"" + XiangXiDz
                //    + "\",\"LONGTUDE\":\"" + Longtude + "\",\"LATITUDE\":\"" + Latitude
                //    + "\",\"CREATEDT\":\"" + CreateDT.ToString() + "\",\"UPDATEDT\":\"\"}";
                //string ret = mapservice.InsertIntoCDZ(json);

                //if (ret.ToLower() != "ok")
                //{
                //    context.Response.Write("{\"success\":true,\"msg\":\"保存gis地图数据失败！\"}");
                //    return;
                //}



                //HttpPostedFile file = context.Request.Files["picfile"];
                //ChargStationFile csfile = new ChargStationFile();
                //decimal fileSize = 0;
                //byte[] fileBuffer = null;
                //string hzm = file.FileName.Substring(file.FileName.LastIndexOf('.'));
                //if (file.ContentLength > 1024 * 1024 * 20)
                //{
                //    context.Response.Write("{\"success\":false,\"msg\":\"文件大小不能超过20M！\"}");
                //    return;
                //}
                //if (hzm.ToLower().Equals(".rar") || hzm.ToLower().Equals(".zip"))
                //{

                
                //    //当前虚拟目录路径  
                //    string _strPicSavePath = "../";
                //    string strGenerPath = csbll.GetPictureid();
                //    string strDirDelPath = HttpContext.Current.Server.MapPath(_strPicSavePath + "Picture/" + strGenerPath);
                //    string strDir = HttpContext.Current.Server.MapPath(_strPicSavePath + "Picture/" + strGenerPath + "/");//图片的保存目录  
                //    if (!Directory.Exists(strDir))
                //    {
                //        Directory.CreateDirectory(strDir);
                //    }
                //    string path = null;
                //    if (file.FileName.LastIndexOf("\\") > 0)
                //    {
                //        path = strDir + file.FileName.Substring(file.FileName.LastIndexOf("\\"));
                //    }
                //    else
                //    {
                //        path = strDir + file.FileName;
                //    }
                //    //string path = strDir + file.FileName;
                //    file.SaveAs(path);
                //    //Response.Write("文件上传成功：" + path);  
                //    //Response.End();  
                //    // 在此处放置用户代码以初始化页面   
                //    Process p = new Process();
                //    p.StartInfo.UseShellExecute = false;
                //    p.StartInfo.RedirectStandardInput = true;
                //    p.StartInfo.RedirectStandardOutput = true;
                //    p.StartInfo.RedirectStandardError = true;
                //    p.StartInfo.CreateNoWindow = true;
                //    p.StartInfo.FileName = "cmd.exe";
                //    p.Close();
                //    //解压Rar文件   
                //    // Response.Write(HttpContext.Current.Server.MapPath(_strPicSavePath));  
                //    string ServerDir = System.Configuration.ConfigurationSettings.AppSettings["rardir"];//rar路径   
                //    System.Diagnostics.Process Process1 = new Process();
                //    Process1.StartInfo.FileName = ServerDir + "\\Rar.exe";
                //    Directory.CreateDirectory(path + ".files"); //创建解压文件夹   
                //    string qlj = "\"" + path + "\"";
                //    string lj = path + ".files/";
                //    string hlj = "\"" + lj + "\"";
                //    Process1.StartInfo.Arguments = " x -t -o-p " + qlj + " " + hlj;
                //    Process1.Start();//解压开始   
                //    while (!Process1.HasExited) //等待解压的完成   
                //    {
                //        Thread.Sleep(1000);
                //    }
                //    File.Delete(path);//删除rar文件   
                //    string strFileName = file.FileName.Substring(0, file.FileName.LastIndexOf('.'));
                //    //解压后文件夹绝对路径  
                //    string strCurPath = path + ".files" + "\\";
                //    //解压后文件相对路径  
                //    string strSavePath = _strPicSavePath + "Picture/" + strGenerPath + "/" + strFileName + ".files/";
                //    foreach (string flName in Directory.GetFiles(strCurPath))
                //    {
                //        string strName = flName.Substring(flName.LastIndexOf("\\") + 1);//文件名  
                //        string tpid = Guid.NewGuid().ToString();  //图片id
                //        string hz = strName.Substring(strName.LastIndexOf('.') + 1);//图片后缀
                //        if (!hz.Equals("bmp") && !hz.Equals("jpg") && !hz.Equals("png") && !hz.Equals("jpeg") && !hz.Equals("gif") && !hz.Equals("bmp")
                //             && !hz.Equals("pcx") && !hz.Equals("tga") && !hz.Equals("fpx") && !hz.Equals("tiff") && !hz.Equals("exif") && !hz.Equals("svg")
                //            && !hz.Equals("psd") && !hz.Equals("cdr") && !hz.Equals("pcd") && !hz.Equals("dxf") && !hz.Equals("ufo") && !hz.Equals("eps")
                //            && !hz.Equals("hdri") && !hz.Equals("ai") && !hz.Equals("ram"))
                //        {
                //            context.Response.Write("{\"success\":false,\"msg\":\"请选择图片压缩文件！\"}");
                //            return;
                //        }
                //        string strDataPath = strCurPath + strName;//数据库保存路径  
                //        fileBuffer = File.ReadAllBytes(strDataPath); //图片内容
                //        fileSize = fileBuffer.Length;//图片大小
                //        DataTable dt = csbll.QueryZhanByZMC(ZhuanMc);
                //        csfile.ZhanBh = decimal.Parse(dt.Rows[0]["zhan_bh"].ToString());
                //        csfile.Id = tpid;
                //        csfile.Filename = strName;
                //        csfile.Filecontext = fileBuffer;
                //        csfile.Filesize = fileSize;
                //        csfile.Filemime = hz;

                //        string strProdNames = strName.Split('.')[0];//款号+序号  
                //        string strProdName;//款号  
                //        string strTitle;//标题  


                //        if (strProdNames.Split('-').Length > 1)
                //        {
                //            strProdName = strProdNames.Split('-')[0];
                //            strTitle = strProdNames;
                //        }
                //        else
                //        {
                //            strProdName = strProdNames;
                //            strTitle = strProdNames;
                //        }
                //        csbll.AddPilePicture(csfile);
                //    }
                //    //删除解压文件夹
                //    Directory.Delete(strDirDelPath, true);

                //}
                //else//不能上传  
                //{
                //    context.Response.Write("{\"success\":false,\"msg\":\"请选择rar,zip文件！\"}");
                //    return;
                //}

                //操作日志
                string name = "";
                if (null != context.Session[Constant.LoginUser])
                {
                    name = (context.Session[Constant.LoginUser] as Employer ?? new Employer()).Name;
                }
                else
                {
                    context.Response.Write("{\"success\":true,\"msg\":\"保存成功！\"}");
                }
                new OprLogBll().Add(new OprLog()
                {
                    Operator = name,
                    OprSrc = "添加充电站",
                    OperResult = "成功",
                    LogDate = DateTime.Now
                });

                context.Response.Write("{\"success\":true,\"msg\":\"保存成功！\"}");

            }
            catch (Exception e)
            {
                Log.Error(e);
                context.Response.Write("{\"success\":false,\"msg\":\"保存失败！\"}");
            }
        }




        /// <summary>
        /// 根据站编号获取充电站信息
        /// </summary>
        /// <param name="context"></param>
        private void GetStationByID(HttpContext context)
        {
            try
            {
                decimal zhanbh = decimal.Parse(context.Request["zhanbh"].ToString());
                ChargStationBll csbll = new ChargStationBll();
                DataTable dt = csbll.QueryChargStationBYID(zhanbh);
                var list = ConvertHelper<ChargStation>.ConvertToList(dt);
                PageObject<ChargStation> pageO = new PageObject<ChargStation>();
                pageO.total = list.Count;
                pageO.rows = list;
                var str = jss.Serialize(pageO);
                context.Response.Write(str);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
        /// <summary>
        /// 删除充电桩
        /// </summary>
        /// <param name="context"></param>
        private void DelPile(HttpContext context)
        {
            try
            {
                string chargPileId = context.Request["pileid"];
                decimal pileid = decimal.Parse(chargPileId);
                var cpbll = new ChargPileBll();
                var dt = cpbll.QueryChargPileByPilebh(pileid);
                if (dt.Rows.Count>0)
                {
                    var dtuid = dt.Rows[0]["dtu_id"].ToString();
                    if (!string.IsNullOrEmpty(dtuid))
                    {
                        context.Response.Write("{\"success\":false,\"msg\":\"此充电桩关联了DTU设备，不能删除！\"}");
                        return;
                    }
                }
                cpbll.DelChargPile(chargPileId);

                decimal zhanbh = decimal.Parse(chargPileId.ToString().Substring(0, 3));

                //保存桩厂家和装类型到充电站表里
                SaveTypeToZhan(zhanbh);
                //操作日志
                string name = "";
                if (null != context.Session[Constant.LoginUser])
                {
                    name = (context.Session[Constant.LoginUser] as Employer ?? new Employer()).Name;
                }
                else
                {
                    context.Response.Write("{\"success\":true,\"msg\":\"删除成功！\"}");
                }
                new OprLogBll().Add(new OprLog()
                {
                    Operator = name,
                    OprSrc = "删除充电桩，桩id：" + chargPileId,
                    OperResult = "成功",
                    LogDate = DateTime.Now
                });

                context.Response.Write("{\"success\":true,\"msg\":\"删除成功！\"}");
            }
            catch (Exception e)
            {
                Log.Error(e);
                context.Response.Write("{\"success\":false,\"msg\":\"删除失败！\"}");
            }
        }
        /// <summary>
        /// 修改充电桩
        /// </summary>
        /// <param name="context"></param>
        private void EditBranch(HttpContext context)
        {
            try
            {
                ChargPileBll cpbll = new ChargPileBll();
                string pileno = context.Request["zhuangbh"].ToString();
                string zhanno = pileno.Substring(0, 3);
                int zhuangbh = int.Parse(pileno);
                string zxdz = context.Request["d_zxdz"].ToString();
                string CHANGJIAO_BH = context.Request["d_cjbh"].ToString();
                string YUNXING_BH = context.Request["d_yxbh"].ToString();
                DataTable dt1 = cpbll.QueryPileByYXBHandZBH(YUNXING_BH, zhanno);
                if (dt1.Rows.Count > 0 && !int.Parse(dt1.Rows[0]["DEV_CHARGPILE"].ToString()).Equals(zhuangbh))
                {
                    context.Response.Write("{\"success\":false,\"msg\":\"桩运行编号已存在！\"}");
                    return;
                }

                string ZHUANGXING_H = context.Request["d_xh"].ToString();
                string CHANGJIA = context.Request["d_cj"].ToString();

                DataTable dt = cpbll.QueryLXBYXH(ZHUANGXING_H,CHANGJIA);
                string piletypeid = dt.Rows[0]["PARSERKEY"].ToString();

                string ZHUANGTAI = context.Request["d_zt"].ToString();
                string REMARK = context.Request["d_bz"].ToString();
                string sj = context.Request["d_tysj"] ?? "";
                DateTime TOUYOU_SJ = new DateTime();
                if (sj.Length > 0)
                {
                    TOUYOU_SJ = DateTime.Parse(sj);
                }
                ChargPile chargpile = new ChargPile();
                chargpile.DEV_CHARGPILE = zhuangbh;
                //chargpile.POWERPILENAME = POWERPILENAME;
                chargpile.ZONGXIAN_DZ = decimal.Parse(zxdz);
                chargpile.PILETYPEID = piletypeid;
                chargpile.CHANGJIAO_BH = CHANGJIAO_BH;
                chargpile.YUNXING_BH = YUNXING_BH;
                chargpile.ZHUANGTAI = ZHUANGTAI;
                chargpile.TOUYOU_SJ = TOUYOU_SJ;
                chargpile.REMARK = REMARK;
                chargpile.UPDATEDT = DateTime.Now;
                ChargStationBll csbll = new ChargStationBll();
                csbll.EditPile(chargpile);

                decimal zhanbh = decimal.Parse(zhuangbh.ToString().Substring(0, 3));

                //保存桩厂家和装类型到充电站表里
                SaveTypeToZhan(zhanbh);
                //操作日志
                string name = "";
                if (null != context.Session[Constant.LoginUser])
                {
                    name = (context.Session[Constant.LoginUser] as Employer ?? new Employer()).Name;
                }
                else
                {
                    context.Response.Write("{\"success\":true,\"msg\":\"保存成功！\"}");
                }
                new OprLogBll().Add(new OprLog()
                {
                    Operator = name,
                    OprSrc = "修改充电桩，桩id：" + zhuangbh,
                    OperResult = "成功",
                    LogDate = DateTime.Now
                });

                context.Response.Write("{\"success\":true,\"msg\":\"保存成功！\"}");
            }
            catch (Exception e)
            {
                Log.Error(e);
                context.Response.Write("{\"success\":false,\"msg\":\"保存失败！\"}");
            }
        }
        /// <summary>
        /// 根据id获取充电桩信息
        /// </summary>
        /// <param name="context"></param>
        private void GetPile(HttpContext context)
        {
            try
            {
                decimal zhuangbh = decimal.Parse(context.Request["zhuangbh"].ToString());
                ChargPileBll cpbll = new ChargPileBll();
                DataTable dt = cpbll.QueryChargPileByPilebh(zhuangbh);
                var list = ConvertHelper<ChargPile>.ConvertToList(dt);
                PageObject<ChargPile> pageO = new PageObject<ChargPile>();
                pageO.total = list.Count;
                pageO.rows = list;
                var str = jss.Serialize(pageO);
                context.Response.Write(str);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
        /// <summary>
        /// 保存桩类型
        /// </summary>
        /// <param name="context"></param>
        private void SaveTypes(HttpContext context)
        {
            try
            {

                decimal zhanbh = decimal.Parse(context.Request["zhanbh"].ToString());
                SaveTypeToZhan(zhanbh);
                context.Response.Write("{\"success\":true,\"msg\":\"保存成功！\"}");
            }
            catch (Exception e)
            {
                Log.Error(e);
                context.Response.Write("{\"success\":false,\"msg\":\"保存失败！\"}");
            }
        }
        /// <summary>
        /// 保存充电桩
        /// </summary>
        /// <param name="context"></param>
        private void SavePile(HttpContext context)
        {
            try
            {
                decimal id = decimal.Parse(context.Request["id"].ToString());
                string cjbh = context.Request["bh"].ToString();
                string yxbh = context.Request["yxbh"].ToString();
                //DataTable dt1 = cpbll.QueryPileByYXBH(yxbh);
                //if (dt1.Rows.Count > 0)
                //{
                //    return;
                //}

                string xh = context.Request["xh"].ToString();
                string zt = context.Request["zt"].ToString();
                string cj = context.Request["cj"].ToString();

                DataTable dt = cpbll.QueryLXBYXH(xh,cj);
                string piletypeid = dt.Rows[0]["PARSERKEY"].ToString();

                ChargPile cpile = new ChargPile();
                cpile.DEV_CHARGPILE = id;
                cpile.CHANGJIAO_BH = cjbh;
                cpile.ZHUANGTAI = zt;
                cpile.YUNXING_BH = yxbh;
                cpile.PILETYPEID = piletypeid;

                ChargStationBll csbll = new ChargStationBll();
                csbll.SavePile(cpile);


                //保存桩厂家和装类型到充电站表里
                decimal zhanbh = decimal.Parse(id.ToString().Substring(0, 3));

                SaveTypeToZhan(zhanbh);

                context.Response.Write("{\"success\":true,\"msg\":\"保存成功！\"}");
            }
            catch (Exception e)
            {
                Log.Error(e);
                context.Response.Write("{\"success\":false,\"msg\":\"保存失败！\"}");
            }
        }
        /// <summary>
        /// 删除分支箱
        /// </summary>
        /// <param name="context"></param>
        private void DelBranch(HttpContext context)
        {
            try
            {
                decimal id = decimal.Parse(context.Request["id"].ToString());
                ChargStationBll csbll = new ChargStationBll();
                DataTable datat = csbll.GetPileByBoxid(id);
                if (datat.Rows.Count > 0)
                {
                    for (int i = 0; i < datat.Rows.Count; i++)
                    {
                        string deleteflag = datat.Rows[i]["DELETEFLAG"].ToString();
                        if (deleteflag == "")
                        {
                            context.Response.Write("{\"success\":false,\"msg\":\"该分支箱下有充电桩，不能删除！\"}");
                            return;
                        }
                    }
                }

                csbll.DelBoxByBoxid(id);


                decimal zhanbh = decimal.Parse(id.ToString().Substring(0, 3));

                //保存桩厂家和装类型到充电站表里
                SaveTypeToZhan(zhanbh);
                //操作日志
                string name = "";
                if (null != context.Session[Constant.LoginUser])
                {
                    name = (context.Session[Constant.LoginUser] as Employer ?? new Employer()).Name;
                }
                else
                {
                    context.Response.Write("{\"success\":true,\"msg\":\"删除成功！\"}");
                }
                new OprLogBll().Add(new OprLog()
                {
                    Operator = name,
                    OprSrc = "删除分支箱，分支箱id：" + id,
                    OperResult = "成功",
                    LogDate = DateTime.Now
                });

                context.Response.Write("{\"success\":true,\"msg\":\"删除成功！\"}");
            }
            catch (Exception e)
            {
                Log.Error(e);
                context.Response.Write("{\"success\":false,\"msg\":\"删除失败！\"}");
            }
        }
        /// <summary>
        /// 删除充电站
        /// </summary>
        /// <param name="context"></param>
        private void DelStation(HttpContext context)
        {
            try
            {
                decimal zhanbh = decimal.Parse(context.Request["id"].ToString());
                ChargStationBll csbll = new ChargStationBll();
                ChargStation chargstation = new ChargStation();
                chargstation.ZhanBh = zhanbh;
                DataTable dt = csbll.QueryBoxID(zhanbh);
                //string boxids = null;
                if (dt.Rows.Count > 0)
                {
                    context.Response.Write("{\"success\":false,\"msg\":\"该充电站下有分支箱，不能删除！\"}");
                    return;
                    //for (int i = 0; i < dt.Rows.Count; i++)
                    //{
                    //    boxids += dt.Rows[i]["BRANCHNO"].ToString();
                    //    if (i < (dt.Rows.Count - 1))
                    //    {
                    //        boxids += "_";
                    //    }
                    //}
                    //csbll.DelBranch(zhanbh);
                    //csbll.DelPile(boxids);
                }
                csbll.DelStationTP(zhanbh);
                csbll.Del(chargstation);

                //DataTable dte = csbll.QueryZhanIdByMC(zhanmc);
                //zhanbh = dte.Rows[0]["zhanbh"].ToString();
                //string json = "{\"ZHAN_BH\":" + zhanbh + ",\"ZHUAN_MC\":\"" + zhanmc
                //    + "\",\"YEZHU_DW\":\"" + yzdw + "\", \"LIANXI_R\":\"" + lxr + "\",\"LIANXI_DH\":\"" + lxdh
                //    + "\",\"ZHUANGLEI_X\":\"\",\"ZHUANGCHANG_J\":\"\",\"XIANGXI_DZ\":\"" + xxdz
                //    + "\",\"LONGTUDE\":\"" + jd + "\",\"LATITUDE\":\"" + wd
                //    + "\",\"CREATEDT\":\"" + jzsj.ToString() + "\",\"UPDATEDT\":\"\"}";
                //string ret = mapservice.DeleteCDZ(json);

                //if (ret.ToLower() != "ok")
                //{
                //    context.Response.Write("{\"success\":true,\"msg\":\"保存gis地图数据失败！\"}");
                //    return;
                //}



                //操作日志
                string name = "";
                if (null != context.Session[Constant.LoginUser])
                {
                    name = (context.Session[Constant.LoginUser] as Employer ?? new Employer()).Name;
                }
                else
                {
                    context.Response.Write("{\"success\":true,\"msg\":\"删除成功！\"}");
                    return;
                }
                new OprLogBll().Add(new OprLog()
                {
                    Operator = name,
                    OprSrc = "删除充电站，充电站id：" + zhanbh,
                    OperResult = "成功",
                    LogDate = DateTime.Now
                });
                //string json = "{\"ZHAN_BH\":\"" + zhanbh + "\"}";
                //string ret = mapservice.DeleteCDZ(json);
                //if (ret.ToLower() != "ok")
                //{
                //    context.Response.Write("{\"success\":true,\"msg\":\"删除gis地图数据失败！\"}");
                //    return;
                //}
                context.Response.Write("{\"success\":true,\"msg\":\"删除成功！\"}");
            }
            catch (Exception e)
            {
                Log.Error(e);
                context.Response.Write("{\"success\":false,\"msg\":\"删除失败！\"}");
            }
        }
        /// <summary>
        /// 修改充电站
        /// </summary>
        /// <param name="context"></param>
        private void EditStation(HttpContext context)
        {
            try
            {
                ChargStationBll csbll = new ChargStationBll();
                decimal zhanbh = decimal.Parse(context.Request["zhanbh"].ToString());
                string ZhuanMc = context.Request["d_ZhuanMc"].ToString();
                //HttpPostedFile file = context.Request.Files["d_picfile"];
                //if (file != null)
                //{
                //    //删除以前的充电站图片
                //    csbll.DelStationTP(zhanbh);

                //    ChargStationFile csfile = new ChargStationFile();
                //    decimal fileSize = 0;
                //    byte[] fileBuffer = null;
                //    string hzm = file.FileName.Substring(file.FileName.LastIndexOf('.'));
                //    if (file.ContentLength > 1024 * 1024 * 20)
                //    {
                //        context.Response.Write("{\"success\":false,\"msg\":\"文件大小不能超过20M！\"}");
                //        return;
                //    }
                //    if (hzm.ToLower().Equals(".rar") || hzm.ToLower().Equals(".zip"))
                //    {

                //        //当前虚拟目录路径  
                //        string _strPicSavePath = "../";
                //        string strGenerPath = csbll.GetPictureid();
                //        string strDirDelPath = HttpContext.Current.Server.MapPath(_strPicSavePath + "Picture/" + strGenerPath);
                //        string strDir = HttpContext.Current.Server.MapPath(_strPicSavePath + "Picture/" + strGenerPath + "/");//图片的保存目录  
                //        if (!Directory.Exists(strDir))
                //        {
                //            Directory.CreateDirectory(strDir);
                //        }
                //        string path = null;
                //        if (file.FileName.LastIndexOf("\\") > 0)
                //        {
                //            path = strDir + file.FileName.Substring(file.FileName.LastIndexOf("\\"));
                //        }
                //        else
                //        {
                //            path = strDir + file.FileName;
                //        }
                //        //  string path = strDir + file.FileName.Substring(file.FileName.LastIndexOf("\\"));  
                //        path = strDir + file.FileName;
                //        file.SaveAs(path);
                //        //Response.Write("文件上传成功：" + path);  
                //        //Response.End();  
                //        // 在此处放置用户代码以初始化页面   
                //        Process p = new Process();
                //        p.StartInfo.UseShellExecute = false;
                //        p.StartInfo.RedirectStandardInput = true;
                //        p.StartInfo.RedirectStandardOutput = true;
                //        p.StartInfo.RedirectStandardError = true;
                //        p.StartInfo.CreateNoWindow = true;
                //        p.StartInfo.FileName = "cmd.exe";
                //        p.Close();
                //        //解压Rar文件   
                //        // Response.Write(HttpContext.Current.Server.MapPath(_strPicSavePath));  
                //        string ServerDir = @"D:\Program Files\WinRAR";//rar路径   
                //        System.Diagnostics.Process Process1 = new Process();
                //        Process1.StartInfo.FileName = ServerDir + "\\Rar.exe";
                //        Directory.CreateDirectory(path + ".files"); //创建解压文件夹   
                //        string qlj = "\"" + path + "\"";
                //        string lj = path + ".files/";
                //        string hlj = "\"" + lj + "\"";
                //        Process1.StartInfo.Arguments = " x -t -o-p " + qlj + " " + hlj;
                //        Process1.Start();//解压开始   
                //        while (!Process1.HasExited) //等待解压的完成   
                //        {
                //            Thread.Sleep(1000);
                //        }
                //        File.Delete(path);//删除rar文件   
                //        string strFileName = file.FileName.Substring(0, file.FileName.LastIndexOf('.'));
                //        //解压后文件夹绝对路径  
                //        string strCurPath = path + ".files" + "\\";
                //        //解压后文件相对路径  
                //        string strSavePath = _strPicSavePath + "Picture/" + strGenerPath + "/" + strFileName + ".files/";
                //        foreach (string flName in Directory.GetFiles(strCurPath))
                //        {
                //            string strName = flName.Substring(flName.LastIndexOf("\\") + 1);//文件名  
                //            string tpid = Guid.NewGuid().ToString();  //图片id
                //            string hz = strName.Substring(strName.LastIndexOf('.') + 1);//图片后缀
                //            if (!hz.Equals("bmp") && !hz.Equals("jpg") && !hz.Equals("png") && !hz.Equals("jpeg") && !hz.Equals("gif") && !hz.Equals("bmp")
                //                 && !hz.Equals("pcx") && !hz.Equals("tga") && !hz.Equals("fpx") && !hz.Equals("tiff") && !hz.Equals("exif") && !hz.Equals("svg")
                //                && !hz.Equals("psd") && !hz.Equals("cdr") && !hz.Equals("pcd") && !hz.Equals("dxf") && !hz.Equals("ufo") && !hz.Equals("eps")
                //                && !hz.Equals("hdri") && !hz.Equals("ai") && !hz.Equals("ram"))
                //            {
                //                context.Response.Write("{\"success\":false,\"msg\":\"请选择图片压缩文件！\"}");
                //                return;
                //            }
                //            string strDataPath = strCurPath + strName;//数据库保存路径  
                //            fileBuffer = File.ReadAllBytes(strDataPath); //图片内容
                //            fileSize = fileBuffer.Length;//图片大小
                //            DataTable dt = csbll.QueryZhanByZMC(ZhuanMc);
                //            csfile.ZhanBh = decimal.Parse(dt.Rows[0]["zhan_bh"].ToString());
                //            csfile.Id = tpid;
                //            csfile.Filename = strName;
                //            csfile.Filecontext = fileBuffer;
                //            csfile.Filesize = fileSize;
                //            csfile.Filemime = hz;

                //            string strProdNames = strName.Split('.')[0];//款号+序号  
                //            string strProdName;//款号  
                //            string strTitle;//标题  


                //            if (strProdNames.Split('-').Length > 1)
                //            {
                //                strProdName = strProdNames.Split('-')[0];
                //                strTitle = strProdNames;
                //            }
                //            else
                //            {
                //                strProdName = strProdNames;
                //                strTitle = strProdNames;
                //            }

                //            csbll.AddPilePicture(csfile);

                //        }

                //        Directory.Delete(strDirDelPath, true);

                //    }
                //    else//不能上传  
                //    {
                //        context.Response.Write("{\"success\":false,\"msg\":\"请选择rar,zip文件！\"}");
                //        return;
                //    }

                //}


                bool b = csbll.QueryZhanIFExit(ZhuanMc);
                DataTable dte = csbll.QueryZhanByZMC(ZhuanMc);
                if (b == false && !decimal.Parse(dte.Rows[0]["ZHAN_BH"].ToString()).Equals(zhanbh))
                {
                    context.Response.Write("{\"success\":false,\"msg\":\"充电场站名称已存在！\"}");
                    return;
                }

                string XiangXiDz = context.Request["d_XiangXiDz"].ToString();
                decimal Longtude = decimal.Parse(context.Request["d_Longtude"].ToString());
                decimal Latitude = decimal.Parse(context.Request["d_Latitude"].ToString());
                string YeZhuDw = context.Request["d_YeZhuDw"].ToString();
                string LianXiR = context.Request["d_LianXiR"].ToString();
                string LianXiDh = context.Request["d_LianXiDh"].ToString();
                DateTime CreateDT = DateTime.Parse(context.Request["d_CreateDT"].ToString());
                string sj = context.Request["d_TouYun_Sj"] ?? "";
                DateTime TouYun_Sj = new DateTime();
                if (sj.Length > 0)
                {
                    TouYun_Sj = DateTime.Parse(sj);
                }

                ChargStation chargstation = new ChargStation();
                chargstation.ZhanBh = zhanbh;
                chargstation.ZhuanMc = ZhuanMc;
                chargstation.XiangXiDz = XiangXiDz;
                chargstation.Longtude = Longtude;
                chargstation.Latitude = Latitude;
                chargstation.YeZhuDw = YeZhuDw;
                chargstation.LianXiDh = LianXiDh;
                chargstation.LianXiR = LianXiR;
                chargstation.CreateDT = CreateDT;
                chargstation.TouYun_Sj = TouYun_Sj;
                chargstation.UpdateDT = DateTime.Now;

                csbll.ModifyStation(chargstation);

                //DataTable dte = csbll.QueryZhanIdByMC(ZhuanMc);
                //zhanbh = dte.Rows[0]["zhanbh"].ToString();
                //string json = "{\"ZHAN_BH\":" + zhanbh + ",\"ZHUAN_MC\":\"" + ZhuanMc
                //    + "\",\"YEZHU_DW\":\"" + YeZhuDw + "\", \"LIANXI_R\":\"" + LianXiR + "\",\"LIANXI_DH\":\"" + LianXiDh
                //    + "\",\"ZHUANGLEI_X\":\"\",\"ZHUANGCHANG_J\":\"\",\"XIANGXI_DZ\":\"" + XiangXiDz
                //    + "\",\"LONGTUDE\":\"" + Longtude + "\",\"LATITUDE\":\"" + Latitude
                //    + "\",\"CREATEDT\":\"" + CreateDT.ToString() + "\",\"UPDATEDT\":\"\"}";
                //string ret = mapservice.UpdateCDZ(json);

                //if (ret.ToLower() != "ok")
                //{
                //    context.Response.Write("{\"success\":true,\"msg\":\"保存gis地图数据失败！\"}");
                //    return;
                //}


                //操作日志
                string name = "";
                if (null != context.Session[Constant.LoginUser])
                {
                    name = (context.Session[Constant.LoginUser] as Employer ?? new Employer()).Name;
                }
                else
                {
                    context.Response.Write("{\"success\":true,\"msg\":\"保存成功！\"}");
                }
                new OprLogBll().Add(new OprLog()
                {
                    Operator = name,
                    OprSrc = "修改充电站，充电站id：" + zhanbh,
                    OperResult = "成功",
                    LogDate = DateTime.Now
                });

                context.Response.Write("{\"success\":true,\"msg\":\"保存成功！\"}");
            }
            catch (Exception e)
            {
                Log.Error(e);
                context.Response.Write("{\"success\":false,\"msg\":\"保存失败！\"}");
            }
        }

        /// <summary>
        /// 修改充电站
        /// </summary>
        /// <param name="context"></param>
        private void EditStation1(HttpContext context)
        {
            try
            {
                ChargStationBll csbll = new ChargStationBll();
                decimal zhanbh = decimal.Parse(context.Request["zhanbh"].ToString());
                string ZhuanMc = context.Request["ZhuanMc"].ToString();

                bool b = csbll.QueryZhanIFExit(ZhuanMc);
                DataTable dte = csbll.QueryZhanByZMC(ZhuanMc);
                if (b == false && !decimal.Parse(dte.Rows[0]["ZHAN_BH"].ToString()).Equals(zhanbh))
                {
                    context.Response.Write("{\"success\":false,\"msg\":\"充电场站名称已存在！\"}");
                    return;
                }

                string XiangXiDz = context.Request["XiangXiDz"].ToString();
                decimal Longtude = decimal.Parse(context.Request["Longtude"].ToString());
                decimal Latitude = decimal.Parse(context.Request["Latitude"].ToString());
                string YeZhuDw = context.Request["YeZhuDw"].ToString();
                string LianXiR = context.Request["LianXiR"].ToString();
                string LianXiDh = context.Request["LianXiDh"].ToString();
                DateTime CreateDT = DateTime.Parse(context.Request["CreateDT"].ToString());
                string sj = context.Request["TouYun_Sj"] ?? "";
                DateTime TouYun_Sj = new DateTime();
                if (sj.Length > 0)
                {
                    TouYun_Sj = DateTime.Parse(sj);
                }

                ChargStation chargstation = new ChargStation();
                chargstation.ZhanBh = zhanbh;
                chargstation.ZhuanMc = ZhuanMc;
                chargstation.XiangXiDz = XiangXiDz;
                chargstation.Longtude = Longtude;
                chargstation.Latitude = Latitude;
                chargstation.YeZhuDw = YeZhuDw;
                chargstation.LianXiDh = LianXiDh;
                chargstation.LianXiR = LianXiR;
                chargstation.CreateDT = CreateDT;
                chargstation.TouYun_Sj = TouYun_Sj;


                csbll.ModifyStation(chargstation);

                //DataTable dte = csbll.QueryZhanIdByMC(ZhuanMc);
                //zhanbh = dte.Rows[0]["zhanbh"].ToString();
                //string json = "{\"ZHAN_BH\":" + zhanbh + ",\"ZHUAN_MC\":\"" + ZhuanMc
                //    + "\",\"YEZHU_DW\":\"" + YeZhuDw + "\", \"LIANXI_R\":\"" + LianXiR + "\",\"LIANXI_DH\":\"" + LianXiDh
                //    + "\",\"ZHUANGLEI_X\":\"\",\"ZHUANGCHANG_J\":\"\",\"XIANGXI_DZ\":\"" + XiangXiDz
                //    + "\",\"LONGTUDE\":\"" + Longtude + "\",\"LATITUDE\":\"" + Latitude
                //    + "\",\"CREATEDT\":\"" + CreateDT.ToString() + "\",\"UPDATEDT\":\"\"}";
                //string ret = mapservice.UpdateCDZ(json);

                //if (ret.ToLower() != "ok")
                //{
                //    context.Response.Write("{\"success\":true,\"msg\":\"保存gis地图数据失败！\"}");
                //    return;
                //}


                //操作日志
                string name = "";
                if (null != context.Session[Constant.LoginUser])
                {
                    name = (context.Session[Constant.LoginUser] as Employer ?? new Employer()).Name;
                }
                else
                {
                    context.Response.Write("{\"success\":true,\"msg\":\"保存成功！\"}");
                }
                new OprLogBll().Add(new OprLog()
                {
                    Operator = name,
                    OprSrc = "修改充电站，充电站id：" + zhanbh,
                    OperResult = "成功",
                    LogDate = DateTime.Now
                });

                context.Response.Write("{\"success\":true,\"msg\":\"保存成功！\"}");
            }
            catch (Exception e)
            {
                Log.Error(e);
                context.Response.Write("{\"success\":false,\"msg\":\"保存失败！\"}");
            }
        }

        /// <summary>
        /// 单个添加充电桩
        /// </summary>
        /// <param name="context"></param>
        private void AddPile_editstation(HttpContext context)
        {
            try
            {
                string branchno = context.Request["branchno"].ToString();
                string zhanno = branchno.Substring(0, 3);
                int BOX_ID = int.Parse(branchno);
                string ZONGXIAN_DZ = context.Request["d_zxdz"].ToString();
                string CHANGJIAO_BH = context.Request["d_cjbh"].ToString();
                string YUNXING_BH = context.Request["d_yxbh"].ToString();
                DataTable dt1 = cpbll.QueryPileByYXBHandZBH(YUNXING_BH, zhanno);
                if (dt1.Rows.Count > 0)
                {
                    context.Response.Write("{\"success\":false,\"msg\":\"桩运行编号已存在！\"}");
                    return;
                }
                string CHANGJIA = context.Request["d_cj"].ToString();
                string ZHUANGXING_H = context.Request["d_xh"].ToString();
                string ZHUANGLEI_X = context.Request["d_lx"].ToString();
                string ZHUANGTAI = context.Request["d_zt"].ToString();
                string REMARK = context.Request["d_bz"].ToString();
                string sj = context.Request["d_tysj"] ?? "";
                DateTime TOUYOU_SJ = new DateTime();
                if (sj.Length > 0)
                {
                    TOUYOU_SJ = DateTime.Parse(sj);
                }
                ChargPile chargpile = new ChargPile();
                //chargpile.POWERPILENAME = ZHUANGMC;
                chargpile.ZONGXIAN_DZ = decimal.Parse(ZONGXIAN_DZ);
                chargpile.BOX_ID = BOX_ID;
                chargpile.CHANGJIAO_BH = CHANGJIAO_BH;
                chargpile.YUNXING_BH = YUNXING_BH;
                chargpile.CHANGJIA = CHANGJIA;
                chargpile.ZHUANGXING_H = ZHUANGXING_H;
                chargpile.ZHUANGLEI_X = ZHUANGLEI_X;
                chargpile.ZHUANGTAI = ZHUANGTAI;
                chargpile.TOUYOU_SJ = TOUYOU_SJ;
                chargpile.CREATEDT = DateTime.Now;
                chargpile.REMARK = REMARK;

                cpbll.AddChargPile(chargpile);


                decimal zhanbh = decimal.Parse(BOX_ID.ToString().Substring(0, 3));

                //保存桩厂家和装类型到充电站表里
                SaveTypeToZhan(zhanbh);
                //操作日志
                string name = "";
                if (null != context.Session[Constant.LoginUser])
                {
                    name = (context.Session[Constant.LoginUser] as Employer ?? new Employer()).Name;
                }
                else
                {
                    context.Response.Write("{\"success\":true,\"msg\":\"保存成功！\"}");
                }
                new OprLogBll().Add(new OprLog()
                {
                    Operator = name,
                    OprSrc = "添加充电桩",
                    OperResult = "成功",
                    LogDate = DateTime.Now
                });

                context.Response.Write("{\"success\":true,\"msg\":\"保存成功！\"}");
            }
            catch (Exception e)
            {
                Log.Error(e);
                context.Response.Write("{\"success\":false,\"msg\":\"保存失败！\"}");
            }
        }
        /// <summary>
        /// 单个添加分支箱和多个充电桩
        /// </summary>
        /// <param name="context"></param>
        private void AddBranch_editstation(HttpContext context)
        {
            try
            {
                //保存分支箱信息
                Branch branch = new Branch();
                ChargPile cpile = new ChargPile();

                ChargStationBll csbll = new ChargStationBll();
                ChargPileBll cpbll = new ChargPileBll();

                decimal zhanbh = decimal.Parse(context.Request["zhanbh"].ToString());
                bool b = csbll.QueryBranch(zhanbh);
                string changjia = context.Request["d_changjia"].ToString();
                string xh = context.Request["d_xinghao"].ToString();
                DataTable dte = cpbll.QueryLXBYXH(xh,changjia);
                string lx = dte.Rows[0]["ZHUANGLEI_X"].ToString();
                branch.ChangJia = changjia;
                branch.FenZhiXlx = lx;
                branch.ZhuanBh = zhanbh;
                branch.Createdt = DateTime.Now;
                if (b == false)
                {
                    branch.BranchNo = zhanbh * 100 + 1;
                }
                else if (b == true)
                {
                    DataTable dta = csbll.QueryMaxBrachno(zhanbh);
                    decimal branchid = decimal.Parse(dta.Rows[0]["BRANCHNO"].ToString());
                    branch.BranchNo = branchid + 1;
                }
                csbll.AddBranch(branch);

                //保存充电桩信息
                int ZCounts = int.Parse(context.Request["d_zcounts"].ToString());
                for (int j = 0; j < ZCounts; j++)
                {
                    cpile.BOX_ID = branch.BranchNo;
                    DataTable dable = cpbll.QueryChargPileID(cpile.BOX_ID);
                    bool bl = cpbll.QueryBoxid(cpile.BOX_ID);
                    if (bl == false)
                        cpile.DEV_CHARGPILE = cpile.BOX_ID * 1000 + (j + 1);
                    else if (bl == true)
                        cpile.DEV_CHARGPILE = decimal.Parse(dable.Rows[0]["DEV_CHARGPILE"].ToString()) + 1;
                    DataTable dtb = cpbll.QueryLXBYXH(xh,changjia);
                    cpile.PILETYPEID = dtb.Rows[0]["PARSERKEY"].ToString();
                    cpile.ZHUANGTAI = "未投运";
                    cpile.CREATEDT = DateTime.Now;
                    csbll.AddChargPile(cpile);

                }

                //保存桩厂家和装类型到充电站表里
                SaveTypeToZhan(zhanbh);
                //操作日志
                string name = "";
                if (null != context.Session[Constant.LoginUser])
                {
                    name = (context.Session[Constant.LoginUser] as Employer ?? new Employer()).Name;
                }
                else
                {
                    context.Response.Write("{\"success\":true,\"msg\":\"保存成功！\"}");
                }
                new OprLogBll().Add(new OprLog()
                {
                    Operator = name,
                    OprSrc = "添加分支箱，分支箱id：" + branch.BranchNo,
                    OperResult = "成功",
                    LogDate = DateTime.Now
                });

                context.Response.Write("{\"success\":true,\"msg\":\"保存成功！\"}");
            }
            catch (Exception e)
            {
                Log.Error(e);
                context.Response.Write("{\"success\":false,\"msg\":\"保存失败！\"}");
            }
        }
        /// <summary>
        /// 批量添加分支箱和充电桩
        /// </summary>
        /// <param name="context"></param>
        private void AddBranch(HttpContext context)
        {
            try
            {
                Branch branch = new Branch();
                ChargPile cpile = new ChargPile();

                ChargStationBll csbll = new ChargStationBll();
                ChargPileBll cpbll = new ChargPileBll();

                decimal zhanbh = decimal.Parse(context.Request["zhanbh"].ToString());

                //清除方法
                DataTable dt1 = csbll.QueryBoxID(zhanbh);
                string boxids = null;
                if (dt1.Rows.Count > 0)
                {
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        boxids += dt1.Rows[i]["BRANCHNO"].ToString();
                        if (i < (dt1.Rows.Count - 1))
                        {
                            boxids += "_";
                        }
                    }
                    csbll.DelBranch(zhanbh);
                    csbll.DelPile(boxids);
                }


                bool b = csbll.QueryBranch(zhanbh);

                int BoxCounts = int.Parse(context.Request["boxcounts"].ToString());
                string changjia, xh, lx = null;
                for (int i = 0; i < BoxCounts; i++)
                {
                    changjia = context.Request["ZhuangChangJia_" + i].ToString();
                    xh = context.Request["ZhuangXingH_" + i].ToString();
                    DataTable dte = cpbll.QueryLXBYXH(xh,changjia);
                    lx = dte.Rows[0]["ZHUANGLEI_X"].ToString();
                    branch.ChangJia = changjia;
                    branch.FenZhiXlx = lx;
                    branch.ZhuanBh = zhanbh;
                    branch.Createdt = DateTime.Now;
                    if (b == false)
                    {
                        branch.BranchNo = zhanbh * 100 + (i + 1);
                    }
                    else if (b == true)
                    {
                        DataTable dta = csbll.QueryBranchId(zhanbh);
                        decimal branchid = decimal.Parse(dta.Rows[0]["BRANCHNO"].ToString());
                        branch.BranchNo = branchid + 1;
                    }
                    csbll.AddBranch(branch);

                    int ZCounts = int.Parse(context.Request["ZhuangCounts_" + i].ToString());
                    for (int j = 0; j < ZCounts; j++)
                    {
                        cpile.BOX_ID = branch.BranchNo;
                        DataTable dable = cpbll.QueryChargPileID(cpile.BOX_ID);
                        bool bl = cpbll.QueryBoxid(cpile.BOX_ID);
                        if (bl == false)
                            cpile.DEV_CHARGPILE = cpile.BOX_ID * 1000 + (j + 1);
                        else if (bl == true)
                            cpile.DEV_CHARGPILE = decimal.Parse(dable.Rows[0]["DEV_CHARGPILE"].ToString()) + 1;
                        DataTable dtb = cpbll.QueryLXBYXH(xh,changjia);
                        cpile.PILETYPEID = dtb.Rows[0]["PARSERKEY"].ToString();
                        cpile.ZHUANGTAI = "未投运";
                        cpile.CREATEDT = DateTime.Now;
                        csbll.AddChargPile(cpile);

                    }
                }
                //保存桩厂家和装类型到充电站表里
                SaveTypeToZhan(zhanbh);
                //操作日志
                string name = "";
                if (null != context.Session[Constant.LoginUser])
                {
                    name = (context.Session[Constant.LoginUser] as Employer ?? new Employer()).Name;
                }
                else
                {
                    context.Response.Write("{\"success\":true,\"msg\":\"保存成功！\"}");
                    return;
                }
                new OprLogBll().Add(new OprLog()
                {
                    Operator = name,
                    OprSrc = "添加分支箱，分支箱id：" + branch.BranchNo,
                    OperResult = "成功",
                    LogDate = DateTime.Now
                });

                context.Response.Write("{\"success\":true,\"msg\":\"保存成功！\"}");
            }
            catch (Exception e)
            {
                Log.Error(e);
                context.Response.Write("{\"success\":false,\"msg\":\"保存失败！\"}");
            }
        }
        /// <summary>
        /// 保存桩类型到场站
        /// </summary>
        /// <param name="zhanbh"></param>
        private void SaveTypeToZhan(decimal zhanbh)
        {
            DataTable dt = csbll.QueryTypes(zhanbh);
            List<string> listcj = new List<string>();
            List<string> listlx = new List<string>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (listcj.Count <= 0)
                {
                    listcj.Add(dt.Rows[i]["CHANGJIA"].ToString());

                }
                else
                {
                    for (int j = 0; j < listcj.Count; j++)
                    {
                        if (listcj[j] == dt.Rows[i]["CHANGJIA"].ToString())
                        { break; }
                        if (j == listcj.Count - 1)
                        {
                            listcj.Add(dt.Rows[i]["CHANGJIA"].ToString());
                        }
                    }
                }
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (listlx.Count <= 0)
                {
                    listlx.Add(dt.Rows[i]["ZHUANGLEI_X"].ToString());

                }
                else
                {
                    for (int j = 0; j < listlx.Count; j++)
                    {
                        if (listlx[j] == dt.Rows[i]["ZHUANGLEI_X"].ToString())
                        { break; }
                        if (j == listlx.Count - 1)
                        {
                            listlx.Add(dt.Rows[i]["ZHUANGLEI_X"].ToString());
                        }
                    }
                }
            }

            string cj = "";
            string zlx = "";

            for (int i = 0; i < listcj.Count; i++)
            {
                cj += listcj[i].ToString();
                if (i < listcj.Count - 1)
                {
                    cj += ",";
                }
            }
            for (int i = 0; i < listlx.Count; i++)
            {
                zlx += listlx[i].ToString();
                if (i < listlx.Count - 1)
                {
                    zlx += ",";
                }
            }
            ChargStation cstion = new ChargStation();
            cstion.ZhuangLeiX = zlx;
            cstion.ZhuangChangJ = cj;
            cstion.ZhanBh = zhanbh;
            csbll.SaveZhan(cstion);
        }


        /// <summary>
        /// 查询充电站id
        /// </summary>
        /// <param name="context"></param>
        private void GetStationID(HttpContext context)
        {
            try
            {
                ChargStationBll csbll = new ChargStationBll();
                DataTable dt = csbll.QueryZhanId();
                var list = ConvertHelper<ChargStation>.ConvertToList(dt);
                PageObject<ChargStation> pageO = new PageObject<ChargStation>();
                pageO.total = list.Count;
                pageO.rows = list;
                var str = jss.Serialize(pageO);
                context.Response.Write(str);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
        /// <summary>
        /// 通过厂家获取型号
        /// </summary>
        /// <param name="context"></param>
        private void GetXHByCJ(HttpContext context)
        {
            try
            {
                string cj = context.Request["cj"].ToString();
                ChargStationBll csbll = new ChargStationBll();
                DataTable dt = csbll.QueryPileXH(cj);
                var list = ConvertHelper<ChargPileTypes>.ConvertToList(dt);
                PageObject<ChargPileTypes> pageO = new PageObject<ChargPileTypes>();
                pageO.total = list.Count;
                pageO.rows = list;
                var str = jss.Serialize(pageO);
                context.Response.Write(str);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
        /// <summary>
        /// 获取充电桩类型数据
        /// </summary>
        /// <param name="context"></param>
        private void GetPileType(HttpContext context)
        {
            try
            {
                object o = context.Session[Constant.LoginUser];
                ChargStationBll csbll = new ChargStationBll();
                DataTable dt = csbll.QueryPileType();
                var list = ConvertHelper<ChargPileTypes>.ConvertToList(dt);
                PageObject<ChargPileTypes> pageO = new PageObject<ChargPileTypes>();
                pageO.total = list.Count;
                pageO.rows = list;
                var str = jss.Serialize(pageO);
                context.Response.Write(str);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
        /// <summary>
        /// 通过充电站查询分支箱数量
        /// </summary>
        /// <param name="context"></param>
        private void GetBcountsByStation(HttpContext context)
        {
            try
            {
                decimal zhanbh = decimal.Parse(context.Request["zhanbh"].ToString());
                ChargStationBll csbll = new ChargStationBll();
                DataTable dt = csbll.QueryBoxCounts(zhanbh);
                var list = ConvertHelper<Branch>.ConvertToList(dt);
                PageObject<Branch> pageO = new PageObject<Branch>();
                pageO.total = list.Count;
                pageO.rows = list;
                var str = jss.Serialize(pageO);
                context.Response.Write(str);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
        /// <summary>
        /// 根据充电站查询充电桩
        /// </summary>
        /// <param name="context"></param>
        private void GetPileByStation(HttpContext context)
        {
            try
            {
                string zhanbh = context.Request["zhanbh"].ToString();
                ChargStationBll csbll = new ChargStationBll();
                DataTable dt = csbll.QueryPile(zhanbh);
                var list = ConvertHelper<ChargPile>.ConvertToList(dt);
                PageObject<ChargPile> pageO = new PageObject<ChargPile>();
                pageO.total = list.Count;
                pageO.rows = list;
                var str = jss.Serialize(pageO);
                context.Response.Write(str);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
        /// <summary>
        /// 获取充电站
        /// </summary>
        /// <param name="context"></param>
        private void GetChargStation(HttpContext context)
        {
            try
            {
                int page = 1, rows = 15, total = 0;
                string tmp = context.Request["page"].ToString();
                if (!string.IsNullOrEmpty(tmp))
                {
                    page = int.Parse(tmp);
                }
                tmp = context.Request["rows"].ToString();
                if (!string.IsNullOrEmpty(tmp))
                {
                    rows = int.Parse(tmp);
                }

                ChargStationBll csbll = new ChargStationBll();
                List<ChargStation> list = csbll.GetChargStationList(page, rows, ref total);
                PageObject<ChargStation> pageO = new PageObject<ChargStation>();
                pageO.total = total;
                pageO.rows = list;
                var str = jss.Serialize(pageO);
                context.Response.Write(str);
            }
            catch (Exception e)
            {
                Log.Error(e);
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
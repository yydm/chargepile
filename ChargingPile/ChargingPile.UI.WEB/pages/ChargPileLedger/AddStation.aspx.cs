using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using ChargingPile.BLL;
using ChargingPile.Model;
using System.Data;
using ChargingPile.UI.WEB.Common;

namespace ChargingPile.UI.WEB.pages.ChargPileLedger
{

    public partial class AddStation : System.Web.UI.Page
    {
        //MapService.WCFDataRequestClient mapservice = new MapService.WCFDataRequestClient();
        protected static string guidString = "";
        ChargStationBll csbll = new ChargStationBll();
        ChargPileBll cpbll = new ChargPileBll();
        string gid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[Constant.LoginUser] == null)
            {
                Response.Redirect("/Login.aspx");
            }
            if (!IsPostBack)
            {
                gid = Request["gid"] ?? "";
                if (gid.Length != 0)
                {
                    guidString = gid;
                }
                else
                {
                    guidString = Guid.NewGuid().ToString();
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            // 如果没有指定上传文件，直接返回
            if (!upImage.HasFile) return;
            // 如果不是图片文件，直接返回
            if (!CheckFileType(upImage.FileName))
            {
                Response.Write("<script>alert(\"图片格式不正确！\");</script>");
                return;
            }
            long len = upImage.FileBytes.Length;
            if (len > 5 * 1024 * 1024)
            {
                Response.Write("<script>alert(\"图片不能大于5M！\");</script>");
                return;
            }
            string dirPath = "~/UpImages/" + guidString + "/";
            if (!Directory.Exists(MapPath(dirPath)))
            {
                Directory.CreateDirectory(MapPath(dirPath));
            }
            string filePath = dirPath + upImage.FileName;
            upImage.SaveAs(MapPath(filePath));
        }

        bool CheckFileType(string fileName)
        {
            string ext = Path.GetExtension(fileName);
            switch (ext.ToLower())
            {
                case ".gif":
                    return true;
                case ".png":
                    return true;
                case ".jpg":
                    return true;
                case ".jpeg":
                    return true;
                default:
                    return false;
            }
        }

        //显示图片
        public string GetNewImg()
        {
            var responseHtml = "";

            if (IsPostBack||gid.Length != 0)
            {
                string imgpath = MapPath("~/UpImages/" + guidString);

                if (Directory.Exists(imgpath))
                {
                    DirectoryInfo dirList = new DirectoryInfo(imgpath);
                    var count = dirList.GetFiles().Length;
                    for (int i = 0; i < count; i++)
                    {
                        responseHtml += "<img id='img_" + i + "' src='" + "../../UpImages/" + guidString + "/" + dirList.GetFiles()[i].Name + "' width='50px' height='40px'style='margin-bottom:5px;' />" +
                        "<img id='bj_" + i + "' src='../../images/cancel.png' width='10px' height='10px' align='top' title='删除' style='cursor:pointer;margin-right:5px;margin-bottom:5px;' onclick='delImg(" + i + ")'/> ";
                    }
                }

            }
            return responseHtml;
        }


        protected void save_Click(object sender, EventArgs e)
        {

            string zhanid = Request["zhanbh"] ?? "";
            if (zhanid.Length > 0)
            {
                string imgPath = MapPath("~/UpImages/" + guidString);
                string zhanbh = "";
                decimal stationid = decimal.Parse(zhanid.ToString());
                ChargStationBll csbll = new ChargStationBll();

                string zhanmc = ZhuanMc.Text.ToString();
                bool b = csbll.QueryZhanIFExit(zhanmc);
                DataTable dte = csbll.QueryZhanByZMC(zhanmc);
                if (b == false && !decimal.Parse(dte.Rows[0]["ZHAN_BH"].ToString()).Equals(stationid))
                {
                    Response.Write("<script>alert(\"充电场站名称已存在！\");</script>");
                    return;
                }

                string zjc = zhanjc.Text.ToString();
                DataTable dt3 = csbll.QueryZhanByZJC(zjc);
                if (dt3.Rows.Count > 0 && !decimal.Parse(dt3.Rows[0]["ZHAN_BH"].ToString()).Equals(stationid))
                {
                    Response.Write("<script>alert(\"充电场站简称已存在！\");</script>");
                    return;
                }
                

                string xxdz = XiangXiDz.Text;
                decimal jd = decimal.Parse(Longtude.Text.ToString());
                decimal wd = decimal.Parse(Latitude.Text.ToString());
                string yzdw = YeZhuDw.Text.ToString();
                string lxr = LianXiR.Text.ToString();
                string lxdh = LianXiDh.Text.ToString();
                decimal boxsl = decimal.Parse(BoxCounts.Text.ToString());
                DateTime jzsj = DateTime.Parse(JianZhan_SJ.Text.ToString());
                DateTime tysj = DateTime.Parse(TouYun_Sj.Text.ToString());
                ChargStation chargstation = new ChargStation();
                chargstation.ZhuanMc = zhanmc;
                chargstation.Zhan_Jc = zjc;
                chargstation.XiangXiDz = xxdz;
                chargstation.Longtude = jd;
                chargstation.Latitude = wd;
                chargstation.YeZhuDw = yzdw;
                chargstation.LianXiDh = lxdh;
                chargstation.LianXiR = lxr;
                chargstation.BoxCounts = boxsl;
                chargstation.JianZhan_Sj = jzsj;
                chargstation.TouYun_Sj = tysj;
                chargstation.ZhanBh = stationid;


                csbll.ModifyStation(chargstation);

                //操作日志
                string name = "";
                if (null != Session[Constant.LoginUser])
                {
                    name = (Session[Constant.LoginUser] as Employer ?? new Employer()).Name;
                }
                new OprLogBll().Add(new OprLog()
                {
                    Operator = name,
                    OprSrc = "添加充电场站",
                    OperResult = "成功",
                    LogDate = DateTime.Now
                });


                //DataTable dte = csbll.QueryZhanIdByMC(zhanmc);
                //zhanbh = dte.Rows[0]["zhanbh"].ToString();
                //string json = "{\"ZHAN_BH\":" + zhanbh + ",\"ZHUAN_MC\":\"" + zhanmc
                //    + "\",\"YEZHU_DW\":\"" + yzdw + "\", \"LIANXI_R\":\"" + lxr + "\",\"LIANXI_DH\":\"" + lxdh
                //    + "\",\"ZHUANGLEI_X\":\"\",\"ZHUANGCHANG_J\":\"\",\"XIANGXI_DZ\":\"" + xxdz
                //    + "\",\"LONGTUDE\":\"" + jd + "\",\"LATITUDE\":\"" + wd
                //    + "\",\"CREATEDT\":\"" + jzsj.ToString() + "\",\"UPDATEDT\":\"\"}";
                //string ret = mapservice.UpdateCDZ(json);

                //if (ret.ToLower() != "ok")
                //{
                //    context.Response.Write("{\"success\":true,\"msg\":\"保存gis地图数据失败！\"}");
                //    return;
                //}



                csbll.DelStationFile(stationid);

                byte[] fileBuffer = null;
                decimal fileSize = 0;
                ChargStationFile csfile = new ChargStationFile();
                if (Directory.Exists(imgPath))
                {
                    foreach (string flName in Directory.GetFiles(imgPath))
                    {
                        string strName = flName.Substring(flName.LastIndexOf("\\") + 1);//文件名  
                        string tpid = Guid.NewGuid().ToString();  //图片id
                        string hz = strName.Substring(strName.LastIndexOf('.') + 1);//图片后缀
                        string strDataPath = imgPath + "\\" + strName;//数据库保存路径  
                        fileBuffer = File.ReadAllBytes(strDataPath); //图片内容
                        fileSize = fileBuffer.Length;//图片大小
                        DataTable dt = csbll.QueryZhanByZMC(zhanmc);
                        if (dt.Rows.Count > 0)
                            csfile.ZhanBh = decimal.Parse(dt.Rows[0]["zhan_bh"].ToString());
                        csfile.Id = tpid;
                        csfile.Filename = strName;
                        csfile.Filecontext = fileBuffer;
                        csfile.Filesize = fileSize;
                        csfile.Filemime = hz;

                        csbll.AddPilePicture(csfile);
                    }
                    //删除解压文件夹
                    //Directory.Delete(imgPath, true);
                }


                //添加分支箱

                //清除方法
                DataTable dt2 = csbll.QueryBoxID(stationid);
                string boxids = null;
                if (dt2.Rows.Count > 0)
                {
                    for (int i = 0; i < dt2.Rows.Count; i++)
                    {
                        boxids += dt2.Rows[i]["BRANCHNO"].ToString();
                        if (i < (dt2.Rows.Count - 1))
                        {
                            boxids += "_";
                        }
                    }
                    csbll.DelBranch(stationid);
                    csbll.DelPile(boxids);
                }

                Branch branch = new Branch();
                DataTable dt1 = csbll.QueryZhanByZMC(zhanmc);
                if (dt1.Rows.Count > 0)
                    branch.ZhuanBh = decimal.Parse(dt1.Rows[0]["zhan_bh"].ToString()); ;
                bool a = csbll.QueryBranch(branch.ZhuanBh);
                for (int i = 0; i < boxsl; i++)
                {
                    branch.Createdt = DateTime.Now;
                    if (a == false)
                    {
                        branch.BranchNo = branch.ZhuanBh * 100 + (i + 1);
                    }
                    else if (a == true)
                    {
                        DataTable dta = csbll.QueryBranchId(branch.ZhuanBh);
                        decimal branchid = decimal.Parse(dta.Rows[0]["BRANCHNO"].ToString());
                        branch.BranchNo = branchid + 1;
                    }
                    csbll.AddBranch(branch);
                }


                string Id = (Session[Constant.LoginUser] as Employer ?? new Employer()).Id;
                decimal zhan_id = decimal.Parse(csbll.QueryZhanByZMC(zhanmc).Rows[0]["zhan_bh"].ToString());
                Response.Redirect("/pages/ChargPileLedger/AddBranch.htm?bs=" + boxsl + "&Id=" + Id + "&gid=" + guidString+"&zhanbh="+zhan_id);


            }
            else
            {
                string imgPath = MapPath("~/UpImages/" + guidString);
                

                string zhanbh = "";
                string zmc = ZhuanMc.Text.ToString();
                bool b = csbll.QueryZhanIFExit(zmc);
                if (b == false)
                {
                    Response.Write("<script>alert(\"充电场站名称已存在！\")</script>");
                    return;
                }

                string zjc = zhanjc.Text.ToString();
                DataTable dt2 = csbll.QueryZhanByZJC(zjc);
                if (dt2.Rows.Count > 0 )
                {
                    Response.Write("<script>alert(\"充电场站简称已存在！\");</script>");
                    return;
                }

                string xxdz = XiangXiDz.Text;
                decimal jd = decimal.Parse(Longtude.Text.ToString());
                decimal wd = decimal.Parse(Latitude.Text.ToString());
                string yzdw = YeZhuDw.Text.ToString();
                string lxr = LianXiR.Text.ToString();
                string lxdh = LianXiDh.Text.ToString();
                decimal boxsl = decimal.Parse(BoxCounts.Text.ToString());
                DateTime jzsj = DateTime.Parse(JianZhan_SJ.Text.ToString()); ;
                DateTime tysj = DateTime.Parse(TouYun_Sj.Text.ToString());
                ChargStation chargstation = new ChargStation();
                chargstation.ZhuanMc = zmc;
                chargstation.Zhan_Jc = zjc;
                chargstation.XiangXiDz = xxdz;
                chargstation.Longtude = jd;
                chargstation.Latitude = wd;
                chargstation.YeZhuDw = yzdw;
                chargstation.LianXiDh = lxdh;
                chargstation.LianXiR = lxr;
                chargstation.BoxCounts = boxsl;
                chargstation.JianZhan_Sj = jzsj;
                chargstation.TouYun_Sj = tysj;

                csbll.Add(chargstation);
                //操作日志
                string name = "";
                if (null != Session[Constant.LoginUser])
                {
                    name = (Session[Constant.LoginUser] as Employer ?? new Employer()).Name;
                }
                new OprLogBll().Add(new OprLog()
                {
                    Operator = name,
                    OprSrc = "添加充电场站",
                    OperResult = "成功",
                    LogDate = DateTime.Now
                });

                //DataTable dte = csbll.QueryZhanIdByMC(zmc);
                //zhanbh = dte.Rows[0]["zhanbh"].ToString();
                //string json = "{\"ZHAN_BH\":" + zhanbh + ",\"ZHUAN_MC\":\"" + zmc
                //    + "\",\"YEZHU_DW\":\"" + yzdw + "\", \"LIANXI_R\":\"" + lxr + "\",\"LIANXI_DH\":\"" + lxdh
                //    + "\",\"ZHUANGLEI_X\":\"\",\"ZHUANGCHANG_J\":\"\",\"XIANGXI_DZ\":\"" + xxdz
                //    + "\",\"LONGTUDE\":\"" + jd + "\",\"LATITUDE\":\"" + wd
                //    + "\",\"CREATEDT\":\"" + jzsj.ToString() + "\",\"UPDATEDT\":\"\"}";
                //string ret = mapservice.InsertIntoCDZ(json);

                //if (ret.ToLower() != "ok")
                //{
                //    context.Response.Write("{\"success\":true,\"msg\":\"保存gis地图数据失败！\"}");
                //    return;
                //}


                //如果存在guid文件夹，则执行图片保存
                if (Directory.Exists(imgPath))
                {
                    byte[] fileBuffer = null;
                    decimal fileSize = 0;
                    ChargStationFile csfile = new ChargStationFile();

                    foreach (string flName in Directory.GetFiles(imgPath))
                    {
                        string strName = flName.Substring(flName.LastIndexOf("\\") + 1);//文件名  
                        string tpid = Guid.NewGuid().ToString();  //图片id
                        string hz = strName.Substring(strName.LastIndexOf('.') + 1);//图片后缀
                        string strDataPath = imgPath + "\\" + strName;//数据库保存路径  
                        fileBuffer = File.ReadAllBytes(strDataPath); //图片内容
                        fileSize = fileBuffer.Length;//图片大小
                        DataTable dt = csbll.QueryZhanByZMC(zmc);
                        if (dt.Rows.Count > 0)
                            csfile.ZhanBh = decimal.Parse(dt.Rows[0]["zhan_bh"].ToString());
                        csfile.Id = tpid;
                        csfile.Filename = strName;
                        csfile.Filecontext = fileBuffer;
                        csfile.Filesize = fileSize;
                        csfile.Filemime = hz;

                        csbll.AddPilePicture(csfile);
                    }
                }
                //删除解压文件夹
                //Directory.Delete(imgPath, true);


                //添加分支箱
                Branch branch = new Branch();
                DataTable dt1 = csbll.QueryZhanByZMC(zmc);
                if (dt1.Rows.Count > 0)
                    branch.ZhuanBh = decimal.Parse(dt1.Rows[0]["zhan_bh"].ToString()); ;
                bool a = csbll.QueryBranch(branch.ZhuanBh);
                for (int i = 0; i < boxsl; i++)
                {
                    branch.Createdt = DateTime.Now;
                    if (a == false)
                    {
                        branch.BranchNo = branch.ZhuanBh * 100 + (i + 1);
                    }
                    else if (a == true)
                    {
                        DataTable dta = csbll.QueryBranchId(branch.ZhuanBh);
                        decimal branchid = decimal.Parse(dta.Rows[0]["BRANCHNO"].ToString());
                        branch.BranchNo = branchid + 1;
                    }
                    csbll.AddBranch(branch);
                }

                string Id = (Session[Constant.LoginUser] as Employer ?? new Employer()).Id;
                decimal zhan_id = decimal.Parse(csbll.QueryZhanByZMC(zmc).Rows[0]["zhan_bh"].ToString());
                Response.Redirect("/pages/ChargPileLedger/AddBranch.htm?bs=" + boxsl + "&Id=" + Id + "&gid=" + guidString + "&zhanbh=" + zhan_id);
            }



        }

    }
}
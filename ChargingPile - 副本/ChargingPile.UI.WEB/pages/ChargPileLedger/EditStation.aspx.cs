using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ChargingPile.BLL;
using ChargingPile.UI.WEB.Common;
using System.IO;
using ChargingPile.Model;
using System.Data;

namespace ChargingPile.UI.WEB.pages.ChargPileLedger
{
    public partial class EditStation : System.Web.UI.Page
    {

        protected static string guidString = "";
        ChargStationBll csbll = new ChargStationBll();
        ChargPileBll cpbll = new ChargPileBll();
        decimal zhanbh = 0;
        bool ifexitdDirectory = true;
        protected static string ifonesave = "";
        protected static string sign = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            zhanbh = decimal.Parse(Request["zhanbh"].ToString());
            sign = "";
            if (!IsPostBack)
            {
                guidString = Guid.NewGuid().ToString();
                ifonesave = "true";
            }
        }
        //上传图片
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
            if (len>5*1024*1024)
            {
                Response.Write("<script>alert(\"图片不能大于5M！\");</script>");
                return;
            }
            string dirPath = "~/EditImages/" + guidString + "/";
            if (!Directory.Exists(MapPath(dirPath)))
            {
                Directory.CreateDirectory(MapPath(dirPath));
            }
            string filePath = dirPath + upImage.FileName;
            upImage.SaveAs(MapPath(filePath));
            GetNewImg();
        }

        //验证图片
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
            if (IsPostBack)
            {
                string imgpath = MapPath("~/EditImages/" + guidString);
                if (ifonesave == "true")
                {
                    if (ifexitdDirectory == true)
                    {
                        if (Directory.Exists(imgpath))
                        {
                            DirectoryInfo dirList = new DirectoryInfo(imgpath);
                            var count = dirList.GetFiles().Length;
                            for (int i = 0; i < count; i++)
                            {
                                responseHtml += "<img id='pic_" + i + "' src='" + "../../EditImages/" + guidString + "/" + dirList.GetFiles()[i].Name + "' width='50px' height='40px' style='margin-bottom:5px;' />"+
                                "<img id='delpic_" + i + "' src='../../images/cancel.png' width='10px' height='10px' align='top' title='删除' style='cursor:pointer;margin-right:5px;margin-bottom:5px;' onclick='delImg(" + i + ")'/>";
                            }
                        }
                    }
                }
            }

            return responseHtml;
        }

        protected void save_Click(object sender, EventArgs e)
        {
            
            string imgPath = MapPath("~/EditImages/" + guidString);
            decimal stationid = zhanbh;

            string zhanmc = d_ZhuanMc.Text.ToString();
            bool b = csbll.QueryZhanIFExit(zhanmc);
            DataTable dte = csbll.QueryZhanByZMC(zhanmc);
            if (b == false && !decimal.Parse(dte.Rows[0]["ZHAN_BH"].ToString()).Equals(stationid))
            {
                Response.Write("<script>alert(\"充电场站名称已存在！\");</script>");
                return;
            }

            string zhanjc = d_zhanjc.Text.ToString();
            DataTable dt3 = csbll.QueryZhanByZJC(zhanjc);
            if (dt3.Rows.Count > 0 && !decimal.Parse(dt3.Rows[0]["ZHAN_BH"].ToString()).Equals(stationid))
            {
                Response.Write("<script>alert(\"充电场站简称已存在！\");</script>");
                return;
            }
            

            string xxdz = d_XiangXiDz.Text;
            decimal jd = decimal.Parse(d_Longtude.Text.ToString());
            decimal wd = decimal.Parse(d_Latitude.Text.ToString());
            string yzdw = d_YeZhuDw.Text.ToString();
            string lxr = d_LianXiR.Text.ToString();
            string lxdh = d_LianXiDh.Text.ToString();
            DateTime JianZhan_SJ = DateTime.Parse(Request.Form["d_JianZhan_SJ"].ToString());
            DateTime tysj = DateTime.Parse(Request.Form["d_TouYun_Sj"].ToString());
            ChargStation chargstation = new ChargStation();
            chargstation.ZhuanMc = zhanmc;
            chargstation.Zhan_Jc = zhanjc;
            chargstation.XiangXiDz = xxdz;
            chargstation.Longtude = jd;
            chargstation.Latitude = wd;
            chargstation.YeZhuDw = yzdw;
            chargstation.LianXiDh = lxdh;
            chargstation.LianXiR = lxr;
            chargstation.JianZhan_Sj = JianZhan_SJ;
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
                OprSrc = "修改充电站，充电站id:" + zhanbh,
                OperResult = "成功",
                LogDate = DateTime.Now
            });

            //DataTable dte = csbll.QueryZhanIdByMC(zhanmc);
            //zhanbh = dte.Rows[0]["zhanbh"].ToString();
            //string json = "{\"ZHAN_BH\":" + stationid + ",\"ZHUAN_MC\":\"" + zhanmc
            //    + "\",\"YEZHU_DW\":\"" + yzdw + "\", \"LIANXI_R\":\"" + lxr + "\",\"LIANXI_DH\":\"" + lxdh
            //    + "\",\"ZHUANGLEI_X\":\"\",\"ZHUANGCHANG_J\":\"\",\"XIANGXI_DZ\":\"" + xxdz
            //    + "\",\"LONGTUDE\":\"" + jd + "\",\"LATITUDE\":\"" + wd
            //    + "\",\"CREATEDT\":\"" + CreateDT.ToString() + "\",\"UPDATEDT\":\"\"}";
            //string ret = mapservice.UpdateCDZ(json);

            //if (ret.ToLower() != "ok")
            //{
            //    context.Response.Write("{\"success\":true,\"msg\":\"保存gis地图数据失败！\"}");
            //    return;
            //}

            if (ifonesave == "true")
            {
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
                    ifonesave = "false";
                    ifexitdDirectory = false;

                    //string Id = (Session[Constant.LoginUser] as Employer ?? new Employer()).Id;
                    //Response.Redirect("/pages/ChargPileLedger/ChargStationEdit.htm?Id=" + Id );

                }
            }
            //Response.Write("<script>alert(\"保存成功！\");</script>");
            sign = "refresh";


        }




    }
}
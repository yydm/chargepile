using System;
using System.Data;
using ChargingPile.BLL;
using ChargingPile.UI.WEB.Common;
using ChargingPile.Model;

namespace ChargingPile.UI.WEB
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (null == Session[Constant.LoginUser])
            {
                Response.Redirect("Login.aspx");
                return;
            }
            Employer emp = (Session[Constant.LoginUser]) as Employer;
            txtWelcome.Text = "欢迎您：" + emp.Name;
        }

        /// <summary>
        /// 生成菜单html代码
        /// </summary>
        /// <returns></returns>
        public string OutPutMenu()
        {
            if (null == Session[Constant.LoginUser])
            {
                return "<script>location.href ='Login.aspx'</script>";
            }
            //菜单功能
            DataTable dt = (new MenuPowerBll()).QueryMenuByRole(((Employer)(Session[Constant.LoginUser])).Id);
            string menuStr = "";
            if (null == dt || dt.Rows.Count == 0)
            {
                return "<script>alert(\"没有分配权限。\");location.href ='Login.aspx'</script>";
            }
            int count = dt.Rows.Count;
            foreach (DataRow row in dt.Rows) //使所有的ppname不为空
            {
                if (row["ppname"].ToString().Length == 0)
                {
                    row["ppname"] = row["parentname"];
                }
            }
            for (int i = 0; i < count; i++)
            {
                if (i == 0 && count > 1) //第一个菜单项
                {
                    if (dt.Rows[i]["level_id"].ToString() == "1") //二级菜单
                    {
                        if (dt.Rows[i]["parentname"].ToString() != dt.Rows[i + 1]["parentname"].ToString())
                        {
                            menuStr += "<li><a href=\"javascript:void(0)\" onclick=\"sf('" +
                                       dt.Rows[i]["href"] + "',null)\">" + dt.Rows[i]["caption"] + "</a></li>";
                        }
                        else
                        {
                            menuStr += "<li><a href=\"javascript:void(0)\" >" + dt.Rows[i]["parentname"].ToString()
                                       + "</a><ul><li><a href=\"javascript:void(0)\" onclick=\"sf('" +
                                       dt.Rows[i]["href"] + "',this)\">" + dt.Rows[i]["caption"] + "</a></li>";
                        }
                    }
                    else //三级菜单
                    {
                        if (dt.Rows[i]["ppname"].ToString() != dt.Rows[i + 1]["ppname"].ToString())
                        {
                            menuStr += "<li><a href=\"javascript:void(0)\" >" + dt.Rows[i]["ppname"]
                                       + "</a><ul><li><a href=\"javascript:void(0)\">" + dt.Rows[i]["parentname"]
                                       + "</a><ul><li><a href=\"javascript:void(0)\" onclick=\"sf('" +
                                       dt.Rows[i]["href"] + "',this)\">" + dt.Rows[i]["caption"]
                                       + "</a></li></ul></li></ul></li>";
                            //三级菜单只有一个菜单项
                        }
                        else if (dt.Rows[i]["parentname"].ToString() != dt.Rows[i + 1]["parentname"].ToString())
                        {
                            menuStr += "<li><a href=\"javascript:void(0)\" >" + dt.Rows[i]["ppname"]
                                       + "</a><ul><li><a href=\"javascript:void(0)\">" + dt.Rows[i]["parentname"]
                                       + "</a><ul><li><a href=\"javascript:void(0)\" onclick=\"sf('" +
                                       dt.Rows[i]["href"] + "',this)\">" + dt.Rows[i]["caption"]
                                       + "</a></li></ul></li>"; //三级菜单多个菜单项-起始
                        }
                        else
                        {
                            menuStr += "<li><a href=\"javascript:void(0)\" >" + dt.Rows[i]["ppname"]
                                       + "</a><ul><li><a href=\"javascript:void(0)\">" + dt.Rows[i]["parentname"]
                                       + "</a><ul><li><a href=\"javascript:void(0)\" onclick=\"sf('" +
                                       dt.Rows[i]["href"] + "',this)\">" + dt.Rows[i]["caption"] + "</a></li>";
                        }
                    }
                }
                else if (i < count - 1) //中间菜单项
                {
                    if (dt.Rows[i]["level_id"].ToString() == "1") //二级菜单
                    {
                        #region 二级菜单

                        if (dt.Rows[i]["parentname"].ToString() != dt.Rows[i - 1]["parentname"].ToString() &&
                            dt.Rows[i]["parentname"].ToString() != dt.Rows[i + 1]["parentname"].ToString())
                        {
                            menuStr += "<li><a href=\"javascript:void(0)\" onclick=\"sf('" +
                                       dt.Rows[i]["href"].ToString() +
                                       "',null)\">" + dt.Rows[i]["parentname"].ToString() + "</a><ul>";
                        }
                        else if (dt.Rows[i]["parentname"].ToString() != dt.Rows[i - 1]["parentname"].ToString() &&
                                 dt.Rows[i]["parentname"].ToString() == dt.Rows[i + 1]["parentname"].ToString())
                        {
                            menuStr += "<li><a href=\"javascript:void(0)\" >" + dt.Rows[i]["parentname"].ToString()
                                       + "</a><ul><li><a href=\"javascript:void(0)\" onclick=\"sf('" +
                                       dt.Rows[i]["href"].ToString() +
                                       "',this)\">" + dt.Rows[i]["caption"].ToString() + "</a></li>";
                        }
                        else if (dt.Rows[i]["parentname"].ToString() == dt.Rows[i - 1]["parentname"].ToString() &&
                                 dt.Rows[i]["parentname"].ToString() != dt.Rows[i + 1]["parentname"].ToString())
                        {
                            menuStr += "<li><a href=\"javascript:void(0)\" onclick=\"sf('" +
                                       dt.Rows[i]["href"].ToString() +
                                       "',this)\">" + dt.Rows[i]["caption"].ToString() + "</a></li></ul>";
                        }
                        else
                        {
                            menuStr += "<li><a href=\"javascript:void(0)\" onclick=\"sf('" +
                                       dt.Rows[i]["href"].ToString() +
                                       "',this)\">" + dt.Rows[i]["caption"].ToString() + "</a></li>";
                        }

                        #endregion
                    }
                    else //三级菜单
                    {
                        if (dt.Rows[i]["ppname"].ToString() != dt.Rows[i - 1]["ppname"].ToString() &&
                            dt.Rows[i]["ppname"].ToString() != dt.Rows[i + 1]["ppname"].ToString())
                        {
                            if (dt.Rows[i]["parentname"].ToString() == dt.Rows[i]["ppname"].ToString())
                            {
                                menuStr += "<li><a href=\"javascript:void(0)\" onclick=\"sf('"
                                           + dt.Rows[i]["href"] + "',this)\">" + dt.Rows[i]["caption"]
                                           + "</a></li></ul></li>";
                            }
                            else
                            {
                                menuStr += "<li><a href=\"javascript:void(0)\" >" + dt.Rows[i]["ppname"]
                                           + "</a><ul><li><a href=\"javascript:void(0)\">" + dt.Rows[i]["parentname"]
                                           + "</a><ul><li><a href=\"javascript:void(0)\" onclick=\"sf('"
                                           + dt.Rows[i]["href"] + "',this)\">" + dt.Rows[i]["caption"]
                                           + "</a></li></ul></li></ul></li>";
                                //三级菜单只有一个菜单项
                            }
                        }
                        else if (dt.Rows[i]["ppname"].ToString() != dt.Rows[i - 1]["ppname"].ToString() &&
                                 dt.Rows[i]["ppname"].ToString() == dt.Rows[i + 1]["ppname"].ToString())
                        {
                            if (dt.Rows[i]["parentname"].ToString() == dt.Rows[i]["ppname"].ToString())
                            {
                                menuStr += "<li><a href=\"javascript:void(0)\" >" + dt.Rows[i]["ppname"]
                                           + "</a><ul><li><a href=\"javascript:void(0)\" onclick=\"sf('"
                                           + dt.Rows[i]["href"] + "',this)\">" + dt.Rows[i]["caption"]
                                           + "</a></li>";
                            }
                            else
                            {
                                if (dt.Rows[i]["parentname"].ToString() != dt.Rows[i + 1]["parentname"].ToString())
                                {
                                    menuStr += "<li><a href=\"javascript:void(0)\" >" + dt.Rows[i]["ppname"]
                                               + "</a><ul><li><a href=\"javascript:void(0)\">" +
                                               dt.Rows[i]["parentname"]
                                               + "</a><ul><li><a href=\"javascript:void(0)\" onclick=\"sf('" +
                                               dt.Rows[i]["href"] +
                                               "',this)\">" + dt.Rows[i]["caption"] + "</a></li></ul></li>";
                                    //三级菜单多个菜单项-起始
                                }
                                else
                                {
                                    menuStr += "<li><a href=\"javascript:void(0)\" >" + dt.Rows[i]["ppname"]
                                               + "</a><ul><li><a href=\"javascript:void(0)\">" +
                                               dt.Rows[i]["parentname"]
                                               + "</a><ul><li><a href=\"javascript:void(0)\" onclick=\"sf('" +
                                               dt.Rows[i]["href"] +
                                               "',this)\">" + dt.Rows[i]["caption"] + "</a></li>"; //三级菜单多个菜单项-多个三级子菜单
                                }
                            }
                        }
                        else if (dt.Rows[i]["ppname"].ToString() == dt.Rows[i - 1]["ppname"].ToString() &&
                                 dt.Rows[i]["ppname"].ToString() != dt.Rows[i + 1]["ppname"].ToString())
                        {
                            if (dt.Rows[i]["parentname"].ToString() == dt.Rows[i]["ppname"].ToString())
                            {
                                menuStr += "<li><a href=\"javascript:void(0)\" onclick=\"sf('"
                                           + dt.Rows[i]["href"] + "',this)\">" + dt.Rows[i]["caption"]
                                           + "</a></li></ul></li>";
                            }
                            else
                            {
                                if (dt.Rows[i]["parentname"].ToString() != dt.Rows[i - 1]["parentname"].ToString())
                                {
                                    menuStr += "<li><a href=\"javascript:void(0)\">" +
                                               dt.Rows[i]["parentname"] +
                                               "</a><ul><li><a href=\"javascript:void(0)\" onclick=\"sf('" +
                                               dt.Rows[i]["href"] + "',this)\">" + dt.Rows[i]["caption"] +
                                               "</a></li></ul></li></ul></li>";
                                }
                                else
                                {
                                    menuStr += "<li><a href=\"javascript:void(0)\" onclick=\"sf('" +
                                               dt.Rows[i]["href"] + "',this)\">" + dt.Rows[i]["caption"]
                                               + "</a></li></ul></li></ul></li>";
                                }
                            }
                        }
                        else //ppname等于前等于后
                        {
                            if (dt.Rows[i]["parentname"].ToString() == dt.Rows[i]["ppname"].ToString())
                            {
                                menuStr += "<li><a href=\"javascript:void(0)\" onclick=\"sf('"
                                           + dt.Rows[i]["href"] + "',this)\">" + dt.Rows[i]["caption"]
                                           + "</a></li>";
                            }
                            else
                            {
                                if (dt.Rows[i]["parentname"].ToString() != dt.Rows[i + 1]["parentname"].ToString() &&
                                    dt.Rows[i]["parentname"].ToString() != dt.Rows[i - 1]["parentname"].ToString())
                                {
                                    menuStr += "<li><a href=\"javascript:void(0)\">" +
                                               dt.Rows[i]["parentname"] +
                                               "</a><ul><li><a href=\"javascript:void(0)\" onclick=\"sf('" +
                                               dt.Rows[i]["href"] + "',this)\">" + dt.Rows[i]["caption"] +
                                               "</a></li></ul></li>";
                                }
                                else if (dt.Rows[i]["parentname"].ToString() != dt.Rows[i + 1]["parentname"].ToString() &&
                                         dt.Rows[i]["parentname"].ToString() == dt.Rows[i - 1]["parentname"].ToString())
                                {
                                    menuStr += "<li><a href=\"javascript:void(0)\" onclick=\"sf('" +
                                               dt.Rows[i]["href"] + "',this)\">" + dt.Rows[i]["caption"] +
                                               "</a></li></ul></li>";
                                }
                                else if (dt.Rows[i]["parentname"].ToString() ==
                                         dt.Rows[i + 1]["parentname"].ToString() &&
                                         dt.Rows[i]["parentname"].ToString() !=
                                         dt.Rows[i - 1]["parentname"].ToString())
                                {
                                    menuStr += "<li><a href=\"javascript:void(0)\">" +
                                               dt.Rows[i]["parentname"] +
                                               "</a><ul><li><a href=\"javascript:void(0)\" onclick=\"sf('" +
                                               dt.Rows[i]["href"] + "',this)\">" + dt.Rows[i]["caption"] +
                                               "</a></li>";
                                }
                                else
                                {
                                    menuStr += "<li><a href=\"javascript:void(0)\" onclick=\"sf('" +
                                               dt.Rows[i]["href"] + "',this)\">" + dt.Rows[i]["caption"] +
                                               "</a></li>";
                                }
                            }
                        }
                    }
                }
                else if (i == count - 1 && count > 1) //最后一个菜单项
                {
                    if (dt.Rows[i]["level_id"].ToString() == "1") //二级菜单
                    {
                        if (dt.Rows[i]["parentname"].ToString() != dt.Rows[i - 1]["parentname"].ToString())
                        {
                            menuStr += "<li><a href=\"javascript:void(0)\" onclick=\"sf('" +
                                       dt.Rows[i]["href"].ToString() +
                                       "',null)\">" + dt.Rows[i]["parentname"].ToString() + "</a></li>";
                        }
                        else
                        {
                            menuStr += "<li><a href=\"javascript:void(0)\" onclick=\"sf('" +
                                       dt.Rows[i]["href"].ToString() +
                                       "',this)\">" + dt.Rows[i]["caption"].ToString() + "</a></li></ul>";
                        }
                    }
                    else //三级菜单
                    {
                        if (dt.Rows[i]["parentname"].ToString() == dt.Rows[i]["ppname"].ToString())
                        {
                            menuStr += "<li><a href=\"javascript:void(0)\" onclick=\"sf('"
                                       + dt.Rows[i]["href"] + "',this)\">" + dt.Rows[i]["caption"]
                                       + "</a></li></ul></li>";
                        }
                        else
                        {
                            if (dt.Rows[i]["ppname"].ToString() != dt.Rows[i - 1]["ppname"].ToString())
                            {
                                if (dt.Rows[i]["parentname"].ToString() != dt.Rows[i - 1]["parentname"].ToString())
                                {
                                    menuStr += "<li><a href=\"javascript:void(0)\" >" + dt.Rows[i]["ppname"]
                                               + "</a><ul><li><a href=\"javascript:void(0)\">" +
                                               dt.Rows[i]["parentname"]
                                               + "</a><ul><li><a href=\"javascript:void(0)\" onclick=\"sf('" +
                                               dt.Rows[i]["href"] +
                                               "',this)\">" + dt.Rows[i]["caption"] + "</a></li></ul></li></ul></li>";
                                    //三级菜单只有一个菜单项
                                }
                                else
                                {
                                    menuStr += "<li><a href=\"javascript:void(0)\" onclick=\"sf('" + dt.Rows[i]["href"] +
                                               "',this)\">" + dt.Rows[i]["caption"] + "</a></li></ul></li></ul></li>";
                                }
                            }
                            else
                            {
                                if (dt.Rows[i]["parentname"].ToString() != dt.Rows[i - 1]["parentname"].ToString())
                                {
                                    menuStr += "<li><a href=\"javascript:void(0)\">" + dt.Rows[i]["parentname"]
                                               + "</a><ul><li><a href=\"javascript:void(0)\" onclick=\"sf('" +
                                               dt.Rows[i]["href"] +
                                               "',this)\">" + dt.Rows[i]["caption"] + "</a></li></ul></li></ul></li>";
                                }
                                else
                                {
                                    menuStr += "<li><a href=\"javascript:void(0)\" onclick=\"sf('" + dt.Rows[i]["href"] +
                                               "',this)\">" + dt.Rows[i]["caption"] + "</a></li></ul></li></ul></li>";
                                }
                            }
                        }
                    }
                }
                else //只有一个菜单项
                {
                    menuStr += "<li><a href=\"javascript:void(0)\" onclick=\"sf('" + dt.Rows[i]["href"].ToString() +
                               "',null)\">" + dt.Rows[i]["caption"].ToString() + "</a></li>";
                }
            }
            menuStr += "<script>var mainSrc ='" + dt.Rows[0]["href"].ToString() +
                       "'</script>";
            return menuStr;
        }
    }
}
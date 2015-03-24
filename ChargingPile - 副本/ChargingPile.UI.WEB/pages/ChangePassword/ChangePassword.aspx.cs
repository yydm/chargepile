using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ChargingPile.UI.WEB.Common;

namespace ChargingPile.UI.WEB.pages.ChangePassword
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string GetUserName()
        {
            var user = Session[Constant.LoginUser];
            if (user != null)
            {
                return ((Model.Employer)(user)).Name;
            }
            Response.Redirect("../../Login.aspx");
            return "";
        }

        public string GetWorkNum()
        {
            var user = Session[Constant.LoginUser];
            if (user != null)
            {
                return ((Model.Employer)(user)).WorkNum;
            }
            Response.Redirect("../../Login.aspx");
            return "";
        }
    }
}
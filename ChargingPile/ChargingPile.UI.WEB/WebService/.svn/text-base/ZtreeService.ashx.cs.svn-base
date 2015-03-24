using System;
using System.Text;
using System.Web;
using ChargingPile.Model;
using ChargingPile.BLL;

namespace ChargingPile.UI.WEB.WebService
{
    /// <summary>
    /// Summary description for ZtreeService
    /// </summary>
    public class ZtreeService : IHttpHandler
    {

        readonly DepartmentBLL _departmentBll = new DepartmentBLL();
        readonly EmployerBll _employerBll = new EmployerBll();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            var action = context.Request.Params["action"];
            var id = context.Request.Params["id"];
            string str;
            if (!String.IsNullOrEmpty(id))
            {
                var nodeid = id;
                switch (action)
                {
                    case "dep": str = GetDeptNodesStr(nodeid); break;
                    case "emp": str = GetDeptNodesStr2(nodeid); break;
                    default:
                        str = ""; break;
                }

            }
            else
            {
                str = GetTreeStr(action);
            }
            context.Response.Write(str);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        protected string GetTreeStr(string action)
        {
            var str = new StringBuilder();
            var dt = _departmentBll.GetRootDepts();
            str.Append("[");
            if (dt.Rows.Count > 0)
            {
                var rId = dt.Rows[0]["Id"].ToString();
                var rName = dt.Rows[0]["Name"].ToString();
                str.Append("{id:'" + rId + "',pId:'0' ,name:'" + rName + "',icon:'../../images/homepage.gif',isParent:true,open:true,nocheck:true }");

            }
            switch (action)
            {
                case "dep":
                    str.Append(GetDeptNode());
                    break;
                case "emp":
                    str.Append(GetDeptNode2());
                    break;
            }

            str.Append("]");
            return str.ToString();
        }


        protected string GetDeptNode()
        {
            var dt = _departmentBll.GetTreeList();
            var nodeStr = new StringBuilder(); //节点json字符串

            if (dt.Rows.Count <= 0) // 没有数据退出
            {
                return string.Empty;
            }
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var nId = dt.Rows[i]["id"].ToString(); // 节点id
                var nName = dt.Rows[i]["name"].ToString(); // 节点名称 
                var pId = dt.Rows[i]["parentdept"].ToString(); // 上级节点id


                var department = new Department { Id = pId };
                var employee = new Employer { DeptId = nId };
                var pNameDt = _departmentBll.Query(department);
                var pName = pNameDt.Rows.Count <= 0 ? "" : pNameDt.Rows[0]["name"].ToString();
                var ndt = _employerBll.QueryNodeTree2(employee);
                var haveNodes = ndt.Rows.Count > 0 ? "yes" : "no";

                nodeStr.Append(",");
                nodeStr.Append("{id:'" + nId + "',pId:'" + pId + "',pName:'" + pName + "' ,name:'" + nName + "',haveNodes:'" + haveNodes + "',icon:'../../images/bumen.png',open:true }");
            }
            return nodeStr.ToString();
        }

        protected string GetDeptNode2()
        {
            var dt = _employerBll.GetTreeList();
            var nodeStr = new StringBuilder(); //节点json字符串

            if (dt.Rows.Count <= 0) // 没有数据退出
            {
                return string.Empty;
            }
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var nId = dt.Rows[i]["id"].ToString(); // 节点id

                var nName = dt.Rows[i]["name"].ToString(); // 节点名称 
                var pId = dt.Rows[i]["parentdept"].ToString(); // 上级节点id
                var department = new Department { Id = pId };
                var employee = new Employer { Id = nId };
                var pNameDt = _departmentBll.Query(department);
                var pName = pNameDt.Rows.Count <= 0 ? "" : pNameDt.Rows[0]["name"].ToString();
                nodeStr.Append(",");
                var flag = nId.Substring(0, 1);
                switch (flag)
                {
                    case "D":
                        nodeStr.Append("{id:'" + nId + "',pId:'" + pId + "',pName:'" + pName + "' ,name:'" + nName + "',icon:'../../images/bumen.png',open:true }");
                        break;
                    case "E":
                        var pMailDt = _employerBll.Query(employee);
                        var pMail = pMailDt.Rows.Count <= 0 ? "" : pMailDt.Rows[0]["email"].ToString();
                        nodeStr.Append("{id:'" + nId + "',pId:'" + pId + "',pName:'" + pName + "',pMail:'" + pMail + "' ,name:'" + nName + "',icon:'../../images/renyuan.png',open:true }");
                        break;
                }

            }
            return nodeStr.ToString();
        }

        protected string GetDeptNodesStr(string parentId)
        {
            var nodeStr = new StringBuilder(); //节点json字符串
            try
            {
                var dt = _departmentBll.GetDepartmentAndNode(parentId);
                if (dt.Rows.Count <= 0)
                {
                    return string.Empty;
                }
                nodeStr.Append("[");
                for (var i = 0; i < dt.Rows.Count; i++)
                {
                    var nId = dt.Rows[i]["id"].ToString(); // 节点id
                    var nName = dt.Rows[i]["name"].ToString(); // 节点名称
                    var pId = dt.Rows[i]["parentdept"].ToString(); // 上级节点id
                    //
                    var department = new Department { Id = pId };
                    var employee = new Employer { DeptId = nId };
                    //
                    var pName = _departmentBll.Query(department).Rows[0]["name"].ToString();
                    //
                    var ndt = _employerBll.QueryNodeTree2(employee);
                    var haveNodes = ndt.Rows.Count > 0 ? "yes" : "no";
                    //
                    nodeStr.Append("{id:'" + nId + "',pId:'" + pId + "',pName:'" + pName + "' ,name:'" + nName + "',haveNodes:'" + haveNodes + "',icon:'../../images/bumen.png',open:true }");
                    if (i < dt.Rows.Count - 1)
                    {
                        nodeStr.Append(",");
                    }
                }
                nodeStr.Append("]");
                return nodeStr.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        protected string GetDeptNodesStr2(string parentId)
        {
            var nodeStr = new StringBuilder(); //节点json字符串
            try
            {
                var dt = _employerBll.GetDepartmentAndNode(parentId);
                if (dt.Rows.Count <= 0)
                {
                    return string.Empty;
                }
                nodeStr.Append("[");
                for (var i = 0; i < dt.Rows.Count; i++)
                {
                    var nId = dt.Rows[i]["id"].ToString(); // 节点id
                    var nName = dt.Rows[i]["name"].ToString(); // 节点名称
                    var pId = dt.Rows[i]["parentdept"].ToString(); // 上级节点id
                    var department = new Department { Id = pId };
                    var employee = new Employer { Id = nId };
                    var pName = _departmentBll.Query(department).Rows[0]["name"].ToString();
                    var flag = nId.Substring(0, 1);
                    switch (flag)
                    {
                        case "D":
                            nodeStr.Append("{id:'" + nId + "',pId:'" + pId + "',pName:'" + pName + "' ,name:'" + nName + "',icon:'../../images/bumen.png',open:true }");
                            break;
                        case "E":
                            var pMailDt = _employerBll.Query(employee);
                            var pMail = pMailDt.Rows.Count <= 0 ? "" : pMailDt.Rows[0]["email"].ToString();
                            nodeStr.Append("{id:'" + nId + "',pId:'" + pId + "',pName:'" + pName + "',pMail:'" + pMail + "' ,name:'" + nName + "',icon:'../../images/renyuan.png',open:true }");
                            break;
                    }


                    if (i < dt.Rows.Count - 1)
                    {
                        nodeStr.Append(",");
                    }
                }
                nodeStr.Append("]");
                return nodeStr.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
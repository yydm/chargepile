using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;
using ChargingPile.Model;
using ChargingPile.BLL;
using ChargingPile.UI.WEB.Common;

namespace ChargingPile.UI.WEB.WebService
{
    /// <summary>
    /// Summary description for DepAndEmpManage
    /// </summary>
    public class DepAndEmpManage : IHttpHandler, IRequiresSessionState
    {

        protected log4net.ILog Log = log4net.LogManager.GetLogger("DepAndEmpManage");
        readonly OprLogBll _oprLogBll = new OprLogBll();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            var action = context.Request.Params["action"];
            var str = string.Empty;
            const string restr = "{\"total\":0,\"rows\":[],\"msg\":\"error\"}";
            switch (action)
            {
                case "addDep":
                    str = AddDepartment(context);
                    break;
                case "addDep2":
                    str = AddDepartment2(context);
                    break;
                case "addEmp":
                    str = AddEmployee(context);
                    break;
                case "delDep":
                    str = DelDepartment(context);
                    break;
                case "editDep":
                    str = EditDepartment(context);
                    break;
                case "editEmp":
                    str = EditEmployee(context);
                    break;
                case "delEmp":
                    str = DelEmployee(context);
                    break;
                case "getEmp":
                    str = GetEmp(context);
                    break;
                case "getDept":
                    str = GetDept(context);
                    break;
                case "queryEmp":
                    str = QueryEmp(context);
                    break;
                case "queryDep":
                    str = QueryDep(context);
                    break;
                case "getrole":
                    str = GetRole(context);
                    break;
                case "getrole2":
                    str = GetRole2(context);
                    break;
                case "null":
                    str = restr;
                    break;
                default: break;
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

        /// <summary>
        /// 添加部门
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string AddDepartment(HttpContext context)
        {
            var departmentBll = new DepartmentBLL();
            var depId = context.Request.Params["id"];
            var parentId = context.Request.Params["parid"];
            var depname = context.Request.Params["depName"];
            var department = new Department { Id = depId, Name = depname, ParentDept = parentId };
            try
            {
                var bdata = departmentBll.Exist(department);
                switch (bdata)
                {
                    case "1":
                        return "exist";
                    case "0":
                        departmentBll.AddDepartment(department);
                        break;
                }

            }
            catch (Exception e)
            {
                Log.Error(e);
                return "false";
            }
            //操作日志
            if (null == context.Session[Constant.LoginUser])
            {
                return "2";
            }
            var oprlog = new OprLog
                {
                    Operator = ((Employer)(context.Session[Constant.LoginUser])).Name,
                    OperResult = "成功",
                    OprSrc = "添加部门",
                    LogDate = DateTime.Now
                };
            _oprLogBll.Add(oprlog);
            return "true";
        }


        public string AddDepartment2(HttpContext context)
        {
            var departmentBll = new DepartmentBLL();
            var depId = Guid.NewGuid().ToString();
            var parentId = context.Request.Params["parid"];
            var depname = context.Request.Params["name"];
            var department = new Department { Id = depId, Name = depname, ParentDept = parentId };
            try
            {
                var bdata = departmentBll.Exist2(department);
                switch (bdata)
                {
                    case "1":
                        return "exist";
                    case "0":
                        departmentBll.AddDepartment(department);
                        break;
                }

            }
            catch (Exception e)
            {
                Log.Error(e);
                return "false";
            }
            //操作日志
            if (null == context.Session[Constant.LoginUser])
            {
                return "2";
            }
            var oprlog = new OprLog
            {
                Operator = ((Employer)(context.Session[Constant.LoginUser])).Name,
                OperResult = "成功",
                OprSrc = "添加部门",
                LogDate = DateTime.Now
            };
            _oprLogBll.Add(oprlog);
            return "true";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string GetEmp(HttpContext context)
        {
            var employeeBll = new EmployerBll();
            var depid = context.Request.Params["id"];
            var employee = new Employer() { DeptId = depid };
            string str;
            var jss = new JavaScriptSerializer();
            var count = 0;
            try
            {
                var dt = employeeBll.QueryEmp(employee);
                var list = ConvertHelper<Employer>.ConvertToList(dt);
                str = jss.Serialize(list);
                str = str.Substring(1, str.Length - 2);
                str = "{\"total\":\"" + count + "\",\"rows\":[" + str + "]}";
            }
            catch (Exception e)
            {
                Log.Error(e);
                return "false";
            }

            return str;
        }

        public string GetDept(HttpContext context)
        {
            var departmentBll = new DepartmentBLL();
            var depid = context.Request.Params["id"];
            var department = new Department() { ParentDept = depid };
            string str;
            var jss = new JavaScriptSerializer();
            var count = 0;
            var page = context.Request.Params["page"];
            var rows = context.Request.Params["rows"];
            var pageIndex = 0;
            var size = 0;
            if (!string.IsNullOrEmpty(page))
            {
                pageIndex = int.Parse(page);
            }
            if (!string.IsNullOrEmpty(rows))
                size = int.Parse(rows);
            try
            {
                var dt = departmentBll.QueryDept(department, pageIndex, size, ref count);
                var list = ConvertHelper<Department>.ConvertToList(dt);
                str = jss.Serialize(list);
                str = str.Substring(1, str.Length - 2);
                str = "{\"total\":\"" + count + "\",\"rows\":[" + str + "]}";
            }
            catch (Exception e)
            {
                Log.Error(e);
                return "false";
            }

            return str;
        }

        /// <summary>
        /// 添加员工
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string AddEmployee(HttpContext context)
        {
            var employeeBll = new EmployerBll();
            var useRolesBll = new UseRolesBll();
            var empid = Guid.NewGuid().ToString();
            var depid = context.Request.Params["parid"];
            var worknum = context.Request.Params["worknum"];
            var empname = context.Request.Params["empname"];
            var phonenum = context.Request.Params["phonenum"];
            var empmail = context.Request.Params["empmail"];
            var roleid = context.Request.Params["roleid"].Split('—');
            var employee = new Employer()
                {
                    Id = empid, 
                    WorkNum = worknum,
                    Name = empname, 
                    DeptId = depid, 
                    PhoneNum = phonenum,
                    Email = empmail
                };
            try
            {
                var bdata = employeeBll.Exist4(employee);
                switch (bdata)
                {
                    case "1":
                        return "exist";
                    case "0":
                        employeeBll.AddEmployee(employee);
                        foreach (var s in roleid)
                        {
                            var useroles = new UseRoles
                                {
                                    RoleId = s,
                                    LoginName = empid
                                };
                            useRolesBll.Add(useroles);
                        }
                        break;
                }

            }
            catch (Exception e)
            {
                Log.Error(e);
                return "false";
            }
            //操作日志
            if (null == context.Session[Constant.LoginUser])
            {
                return "2";
            }
            var oprlog = new OprLog
            {
                Operator = ((Employer)(context.Session[Constant.LoginUser])).Name,
                OperResult = "成功",
                OprSrc = "添加人员",
                LogDate = DateTime.Now
            };
            _oprLogBll.Add(oprlog);
            return "true";
        }

        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string DelDepartment(HttpContext context)
        {
            var departmentBll = new DepartmentBLL();
            var employeeBll = new EmployerBll();
            var id = context.Request.Params["id"];
            var name = context.Request.Params["name"];
            var employee = new Employer
                {
                    DeptId = id,
                    Name = name
                };
            try
            {
                var bdata = employeeBll.Exist(employee);
                
                switch (bdata)
                {
                    case "1":
                        return "exist";
                    case "0":
                        var bdata2 = departmentBll.Exist3(id);
                        switch (bdata2)
                        {
                            case "1":
                                return "exist2";
                        }
                        departmentBll.DelDepartment(id);
                        break;
                }

            }
            catch (Exception e)
            {
                Log.Error(e);
                return "false";
            }
            //操作日志
            if (null == context.Session[Constant.LoginUser])
            {
                return "2";
            }
            var oprlog = new OprLog
            {
                Operator = ((Employer)(context.Session[Constant.LoginUser])).Name,
                OperResult = "成功",
                OprSrc = "删除部门",
                LogDate = DateTime.Now
            };
            _oprLogBll.Add(oprlog);
            return "true";

        }


        /// <summary>
        /// 修改部门
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string EditDepartment(HttpContext context)
        {
            var departmentBll = new DepartmentBLL();
            var depid = context.Request.Params["depid"];
            var depname = context.Request.Params["depName"];
            var parId = context.Request.Params["pId"];
            var department = new Department { Id = depid, Name = depname, ParentDept = parId };
            try
            {
                var bdata = departmentBll.Exist2(department);
                switch (bdata)
                {
                    case "1":
                        return "exist";
                    case "0":
                        departmentBll.UpdateDepartment(department);
                        break;
                }

            }
            catch (Exception e)
            {
                Log.Error(e);
                return "false";
            }
            //操作日志
            if (null == context.Session[Constant.LoginUser])
            {
                return "2";
            }
            var oprlog = new OprLog
            {
                Operator = ((Employer)(context.Session[Constant.LoginUser])).Name,
                OperResult = "成功",
                OprSrc = "编辑部门",
                LogDate = DateTime.Now
            };
            _oprLogBll.Add(oprlog);
            return "true";
        }

        /// <summary>
        /// 编辑员工数据
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string EditEmployee(HttpContext context)
        {
            var employeeBll = new EmployerBll();
            var useRolesBll = new UseRolesBll();
            var id = context.Request.Params["empid"];
            var worknum = context.Request.Params["worknum"];
            var empname = context.Request.Params["empname"];
            var phonenum = context.Request.Params["phonenum"];
            var parid = context.Request.Params["parid"];
            var empmail = context.Request.Params["empmail"];
            var roleid = context.Request.Params["roleid"].Split('—');
            var employee = new Employer
                {
                    Id = id,
                    DeptId = parid,
                    WorkNum = worknum,
                    Name = empname,
                    PhoneNum = phonenum,
                    Email = empmail
                };
            try
            {

                var userolesdel = new UseRoles
                {
                    LoginName = id
                };
                useRolesBll.Del(userolesdel);
                foreach (var s in roleid)
                {
                    var useroles = new UseRoles
                    {
                        RoleId = s,
                        LoginName = id
                    };
                    useRolesBll.Add(useroles);
                }

                var bdata = employeeBll.Exist5(employee);
                switch (bdata)
                {
                    case "1":
                        return "exist";
                    case "0":
                        employeeBll.UpdateEmployee(employee);
                        break;
                }
            }
            catch (Exception e)
            {
                Log.Error(e);
                return "false";
            }
            //操作日志
            if (null == context.Session[Constant.LoginUser])
            {
                return "2";
            }
            var oprlog = new OprLog
            {
                Operator = ((Employer)(context.Session[Constant.LoginUser])).Name,
                OperResult = "成功",
                OprSrc = "编辑人员",
                LogDate = DateTime.Now
            };
            _oprLogBll.Add(oprlog);
            return "true";
        }


        /// <summary>
        /// 删除员工数据
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string DelEmployee(HttpContext context)
        {
            var employeeBll = new EmployerBll();
            var id = context.Request.Params["id"];
            try
            {
                employeeBll.DelEmployee(id);
            }
            catch (Exception e)
            {
                Log.Error(e);
                return e.Message;
            }
            //操作日志
            if (null == context.Session[Constant.LoginUser])
            {
                return "2";
            }
            var oprlog = new OprLog
            {
                Operator = ((Employer)(context.Session[Constant.LoginUser])).Name,
                OperResult = "成功",
                OprSrc = "删除人员",
                LogDate = DateTime.Now
            };
            _oprLogBll.Add(oprlog);
            return "true";
        }


        public string QueryEmp(HttpContext context)
        {
            var employeeBll = new EmployerBll();
            string str;
            var jss = new JavaScriptSerializer();
            var id = context.Request.Params["empid"];
            var employee = new Employer() { Id = id };
            try
            {
                var dt = employeeBll.Query(employee);
                var list = ConvertHelper<Employer>.ConvertToList(dt);
                str = jss.Serialize(list);
                str += "|";
            }
            catch (Exception e)
            {
                Log.Error(e);
                str = "0|false";
                return str;
            }
            return str;
        }

        public string QueryDep(HttpContext context)
        {
            var departmentBll = new DepartmentBLL();
            var jss = new JavaScriptSerializer();


            string str;
            var id = context.Request.Params["deptid"];
            var department = new Department() { Id = id };
            try
            {
                var dt = departmentBll.Query(department);
                var list = ConvertHelper<Department>.ConvertToList(dt);
                str = jss.Serialize(list);
                str += "|";
            }
            catch (Exception e)
            {
                Log.Error(e);
                str = "0|false";
                return str;
            }
            return str;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string GetRole(HttpContext context)
        {
            var rolebll = new RoleBll();
            var role = new Role();
            var jss = new JavaScriptSerializer();

            string str;
            try
            {
                var dt = rolebll.Query(role);
                var list = ConvertHelper<Role>.ConvertToList(dt);
                str = jss.Serialize(list);
                str += "|";
            }
            catch (Exception e)
            {
                Log.Error(e);
                str = "0|false";
                return str;
            }
            return str;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string GetRole2(HttpContext context)
        {

            var userolesbll = new UseRolesBll();
            var empid = context.Request.Params["empid"];
            var jss = new JavaScriptSerializer();

            var useroles = new UseRoles
            {
                LoginName = empid
            };

            string str;
            try
            {
                var dt = userolesbll.Query(useroles);
                var list = ConvertHelper<Role>.ConvertToList(dt);
                str = jss.Serialize(list);
                str += "|";
            }
            catch (Exception e)
            {
                Log.Error(e);
                str = "0|false";
                return str;
            }
            return str;
        }
    }
}
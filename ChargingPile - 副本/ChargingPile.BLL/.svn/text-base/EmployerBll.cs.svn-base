using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ChargingPile.DAL;
using ChargingPile.Model;

namespace ChargingPile.BLL
{
    public class EmployerBll
    {
        private static readonly EmployerDal EmployerDal = new EmployerDal();
        public bool Login(string workNum, string pwd)
        {
            var emp = new Employer { WorkNum = workNum, Password = pwd, };
            var dt = EmployerDal.Query(emp);
            return dt != null && dt.Rows.Count > 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bean"></param>
        /// <returns></returns>
        public string Exist(Employer bean)
        {
            var bdata = EmployerDal.Exist(bean);
            return bdata ? "1" : "0";
        }

        public string Exist2(Employer bean)
        {
            var bdata = EmployerDal.Exist2(bean);
            return bdata ? "1" : "0";
        }

        public string Exist3(Employer bean)
        {
            var bdata = EmployerDal.Exist3(bean);
            return bdata ? "1" : "0";
        }

        public string Exist4(Employer bean)
        {
            var bdata = EmployerDal.Exist4(bean);
            return bdata ? "1" : "0";
        }

        public string Exist5(Employer bean)
        {
            var bdata = EmployerDal.Exist5(bean);
            return bdata ? "1" : "0";
        }

        public void AddEmployee(Employer employer)
        {
            EmployerDal.Add(employer);
        }


        public DataTable GetTreeList()
        {
            return EmployerDal.QueryNode();
        }


        public DataTable GetDepartmentAndNode(string parentId)
        {
            return EmployerDal.QueryNodeTree(parentId);
        }


        public void UpdateEmployee(Employer employer)
        {
            EmployerDal.UpdateEmployee(employer);
        }


        public DataTable Query(Employer employer)
        {
            return EmployerDal.Query(employer);
        }
        /// <summary>
        /// 根据给定的条件查询符合的条件的第一个对象
        /// </summary>
        /// <param name="employer"></param>
        /// <returns></returns>
        public Employer GetEntity(Employer employer)
        {
            DataTable dt = EmployerDal.Query(employer);
            Employer emp = new Employer();
            if (null != dt && dt.Rows.Count > 0)
            {
                emp.Id = dt.Rows[0]["id"].ToString();
                emp.DeptId = dt.Rows[0]["deptid"].ToString();
                emp.Email = dt.Rows[0]["email"].ToString();
                emp.Name = dt.Rows[0]["name"].ToString();
                emp.WorkNum = dt.Rows[0]["worknum"].ToString();
            }
            return emp;
        }

        public DataTable QueryNodeTree2(Employer employer)
        {
            return EmployerDal.QueryNodeTree2(employer);
        }

        /// <summary>
        /// 删除人员，删除前要检查是否有订阅报刊
        /// </summary>
        /// <param name="id"></param>
        public void DelEmployee(string id)
        {
            EmployerDal.DelEmployee(id);
        }

        public void Modify(Employer bean)
        {
            EmployerDal.Modify(bean);
        }


        public DataTable QueryEmp(Employer bean)
        {
            return EmployerDal.QueryEmp(bean);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ChargingPile.Model;
using ChargingPile.DAL;

namespace ChargingPile.BLL
{
    public class DepartmentBLL
    {
        readonly DepartmentDal _departmentDal = new DepartmentDal();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bean"></param>
        /// <returns></returns>
        public string Exist(Department bean)
        {
            var bdata = _departmentDal.Exist(bean);
            return bdata ? "1" : "0";
        }

        public string Exist2(Department bean)
        {
            var bdata = _departmentDal.Exist2(bean);
            return bdata ? "1" : "0";
        }

        public string Exist3(string pid)
        {
            var bdata = _departmentDal.Exist3(pid);
            return bdata ? "1" : "0";
        }

        /// <summary>
        /// 获取根部门
        /// </summary>
        /// <returns></returns>
        public DataTable GetRootDepts()
        {
            var department = new Department { Id = "0001" };
            return _departmentDal.Query(department);
        }

        public DataTable GetTreeList()
        {
            return _departmentDal.QueryNode();
        }

        public DataTable GetDepartmentAndNode(string parentDept)
        {
            return _departmentDal.QueryNodeTree(parentDept);
        }

        public DataTable Query(Department department)
        {
            return _departmentDal.Query(department);
        }

        /// <summary>
        /// 添加部门
        /// </summary>
        /// <param name="department"></param>
        public void AddDepartment(Department department)
        {
            _departmentDal.Add(department);
        }

        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="id"></param>
        public void DelDepartment(string id)
        {
            _departmentDal.DelDepartment(id);
        }

        /// <summary>
        /// 更新部门
        /// </summary>
        /// <param name="department"></param>
        public void UpdateDepartment(Department department)
        {
            _departmentDal.UpdateDepartment(department);
        }
        public DataTable QueryDept(Department bean, int page, int rows, ref int recordcount)
        {
            return _departmentDal.QueryDept(bean, page, rows, ref recordcount);
        }
    }
}

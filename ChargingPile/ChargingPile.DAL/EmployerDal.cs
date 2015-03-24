using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ChargingPile.Model;

namespace ChargingPile.DAL
{
    public class EmployerDal : BaseDal<Employer>
    {
        public override bool Exist(Employer bean)
        {
            Log.Debug("exist方法"+bean);
            var sql = "select * from t_employer t where deptid='" + bean.DeptId + "'";
            Log.Debug("SQL :" + sql);
            var dt = Oop.GetDataTable(sql);
            return dt.Rows.Count > 0;
        }

        public bool Exist2(Employer bean)
        {
            Log.Debug("exist方法");
            var sql = "select * from t_employer t where name='" + bean.Name + "' and deptid='" + bean.DeptId + "'";
            var dt = Oop.GetDataTable(sql);
            return dt.Rows.Count > 0;
        }

        public bool Exist3(Employer bean)
        {
            Log.Debug("exist方法");
            var sql = "select * from t_employer t where name='" + bean.Name + "' and deptid !='" + bean.DeptId + "'";
            var dt = Oop.GetDataTable(sql);
            return dt.Rows.Count > 0;
        }

        public bool Exist4(Employer bean)
        {
            Log.Debug("exist方法");
            var sql = "select * from t_employer t where worknum='" + bean.WorkNum + "'";
            var dt = Oop.GetDataTable(sql);
            return dt.Rows.Count > 0;
        }

        public bool Exist5(Employer bean)
        {
            Log.Debug("exist方法");
            var sql = "select * from t_employer t where worknum='" + bean.WorkNum + "' and id !='" + bean.Id + "'";
            var dt = Oop.GetDataTable(sql);
            return dt.Rows.Count > 0;
        }

        public override void Add(Employer bean)
        {

            Log.Debug("Add方法接收的参数：" + bean.ToString());
            var sql1 = new StringBuilder();
            var sql2 = new StringBuilder();
            var i = 0;
            var list = new List<object>();
            if (!string.IsNullOrEmpty(bean.Id))
            {
                sql1.Append(" id,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.Id);
            }
            if (!string.IsNullOrEmpty(bean.WorkNum))
            {
                sql1.Append(" WorkNum,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.WorkNum);
            }
            if (!string.IsNullOrEmpty(bean.Name))
            {
                sql1.Append(" name,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.Name);
            }
            if (!string.IsNullOrEmpty(bean.DeptId))
            {
                sql1.Append(" deptid,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.DeptId);
            }
            if (!string.IsNullOrEmpty(bean.PhoneNum))
            {
                sql1.Append(" PhoneNum,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.PhoneNum);
            }
            if (!string.IsNullOrEmpty(bean.Email))
            {
                sql1.Append(" Email,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.Email);
            }
            if (sql1.Length > 0)
            {
                sql1 = sql1.Remove(sql1.Length - 1, 1);
                sql2 = sql2.Remove(sql2.Length - 1, 1);
            }

            var sql = "insert into t_employer(" + sql1 + ") values(" + sql2 + ")";
            Log.Debug("SQL :" + sql + ",params:" + list.ToString());
            Oop.Execute(sql, list.ToArray());
        }

        public override void Del(Employer bean)
        {
            throw new NotImplementedException();
        }

        public void DelEmployee(string id)
        {
            Log.Debug("del方法接收的参数：");
            var sql = "delete from t_employer where id='" + id + "'";
            Oop.Execute(sql);
        }

        public override void Modify(Employer employer)
        {
            Log.Debug("更新人员");
            var sql = "update t_employer set password='" + employer.Password + "' where WorkNum='" + employer.WorkNum + "'";
            Oop.Execute(sql);
        }

        public void ModifyEmail(Employer bean)
        {
            Log.Debug("ModifyById方法参数：" + bean.ToString());
            string sql = "update t_employer set email={0} where id={1}";
            Oop.Execute(sql, bean.Email, bean.Id);
        }

        public void UpdateEmployee(Employer employer)
        {
            Log.Debug("更新人员");
            var sql = "update t_employer set worknum='" + employer.WorkNum +
                "',name='" + employer.Name +
                "',phonenum='" + employer.PhoneNum +
                "',email='" + employer.Email +
                "' where id='" + employer.Id + "'";
            Oop.Execute(sql);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bean"></param>
        /// <returns></returns>
        public override DataTable Query(Employer bean)
        {
            Log.Debug("Query方法参数：" + bean.ToString());
            var sql = new StringBuilder();
            sql.Append("select * from t_employer where 1=1 ");
            var list = new List<object>();
            var i = -1;
            if (!string.IsNullOrEmpty(bean.Id))
            {
                sql.Append(" and id={" + ++i + "}");
                list.Add(bean.Id);
            }
            if (!string.IsNullOrEmpty(bean.WorkNum))
            {
                sql.Append(" and WorkNum={" + ++i + "}");
                list.Add(bean.WorkNum);
            }
            if (!string.IsNullOrEmpty(bean.Name))
            {
                sql.Append(" and name={" + ++i + "}");
                list.Add(bean.Name);
            }
            if (!string.IsNullOrEmpty(bean.DeptId))
            {
                sql.Append(" and deptid={" + ++i + "}");
                list.Add(bean.DeptId);
            }
            if (!string.IsNullOrEmpty(bean.PhoneNum))
            {
                sql.Append(" and PhoneNum={" + ++i + "}");
                list.Add(bean.PhoneNum);
            }
            if (!string.IsNullOrEmpty(bean.Email))
            {
                sql.Append(" and email={" + ++i + "}");
                list.Add(bean.Email);
            }
            if (!string.IsNullOrEmpty(bean.Password))
            {
                sql.Append(" and Password={" + ++i + "}");
                list.Add(bean.Password);
            }
            Log.Debug("SQL :" + sql + ",params:" + list.ToString());
            return Oop.GetDataTable(sql.ToString(), list.ToArray());
        }


        public DataTable QueryEmp(Employer bean)
        {
            Log.Debug("QueryNode方法参数：" + bean.ToString());
            var sql2 = "select t.*,(select name from t_department tt where t.deptid=tt.id) deptname from t_employer t where deptid='" + bean.DeptId + "'";
            return Oop.GetDataTable(sql2);
        }
        /// <summary>
        /// 查询不是根结点的所有数据
        /// </summary>
        /// <returns></returns>
        public DataTable QueryNode()
        {
            Log.Debug("QueryNode方法参数：");
            var sql = new StringBuilder();
            sql.Append("select * from t_department where parentdept is not null  ");
            sql.Append(" union select id,name,deptid from t_employer where deptid is not null");
            return Oop.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 查询子节点下所有节点(包括部门和人员)
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public DataTable QueryNodeTree(string parentId)
        {
            Log.Debug("QueryNodeTree方法参数：");
            var strSql = new StringBuilder();
            strSql.Append("select * from (");
            strSql.Append("SELECT id,name,parentdept FROM t_department ");
            strSql.Append("start with id='" + parentId + "' connect by prior id = parentdept ) t");
            strSql.Append("  where id!='" + parentId + "'");
            strSql.Append(" union select * from (SELECT id,name,deptid");
            strSql.Append(" FROM t_employer where deptid in(SELECT id FROM t_department start with id='" + parentId + "' connect by prior id = parentdept )) ");
            return Oop.GetDataTable(strSql.ToString());
        }

        /// <summary>
        /// 查询子节点下所有节点(包括部门和人员)
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public DataTable QueryNodeTree2(Employer employee)
        {
            Log.Debug("QueryNodeTree方法参数：");
            var strSql = new StringBuilder();
            strSql.Append("select t.id from t_employer t ");
            strSql.Append("where deptid='" + employee.DeptId + "' ");
            strSql.Append("union select tt.id from t_department tt ");
            strSql.Append("where tt.parentdept='" + employee.DeptId + "'");
            return Oop.GetDataTable(strSql.ToString());
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="bean"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public override DataTable QueryByPage(Employer bean, int page, int rows)
        {
            Log.Debug("Query方法参数：" + bean.ToString());
            var sql = new StringBuilder();
            sql.Append("select * from t_employer where 1=1 ");
            var list = new List<object>();
            var i = 0;
            if (!string.IsNullOrEmpty(bean.Id))
            {
                sql.Append(" and id={" + ++i + "}");
                list.Add(bean.Id);
            }
            if (!string.IsNullOrEmpty(bean.WorkNum))
            {
                sql.Append(" and WorkNum={" + ++i + "}");
                list.Add(bean.WorkNum);
            }
            if (!string.IsNullOrEmpty(bean.Name))
            {
                sql.Append(" and name={" + ++i + "}");
                list.Add(bean.Name);
            }
            if (!string.IsNullOrEmpty(bean.DeptId))
            {
                sql.Append(" and deptid={" + ++i + "}");
                list.Add(bean.DeptId);
            }
            if (!string.IsNullOrEmpty(bean.PhoneNum))
            {
                sql.Append(" and PhoneNum={" + ++i + "}");
                list.Add(bean.PhoneNum);
            }
            if (!string.IsNullOrEmpty(bean.Email))
            {
                sql.Append(" and email={" + ++i + "}");
                list.Add(bean.Email);
            }
            return Oop.GetDataTableByPage(sql.ToString(), page * rows, rows, list.ToArray());
        }

        public override DataTable QueryByPage(Employer bean, int page, int rows, ref int count)
        {
            throw new NotImplementedException();
        }
    }
}

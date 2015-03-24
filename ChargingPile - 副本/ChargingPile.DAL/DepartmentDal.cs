using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ChargingPile.Model;

namespace ChargingPile.DAL
{
    public class DepartmentDal : BaseDal<Department>
    {
        public override bool Exist(Department bean)
        {
            Log.Debug("exist方法");
            var sql = "select * from t_department t where name='" + bean.Name + "' and parentdept='" + bean.ParentDept + "'";
            var dt = Oop.GetDataTable(sql);
            return dt.Rows.Count > 0;
        }

        public bool Exist2(Department bean)
        {
            Log.Debug("exist方法");
            var sql = "select * from t_department t where name='" + bean.Name + "'";
            var dt = Oop.GetDataTable(sql);
            return dt.Rows.Count > 0;
        }

        public bool Exist3(string pid)
        {
            Log.Debug("exist方法");
            var sql = "select * from t_department t where t.parentdept='" + pid + "'";
            var dt = Oop.GetDataTable(sql);
            return dt.Rows.Count > 0;
        }

        public override void Add(Department bean)
        {
            Log.Debug("Add方法参数：" + bean.ToString());
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
            if (!string.IsNullOrEmpty(bean.Name))
            {
                sql1.Append(" name,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.Name);
            }
            if (!string.IsNullOrEmpty(bean.ParentDept))
            {
                sql1.Append(" parentdept,");
                sql2.Append(" {" + i++ + "},");
                list.Add(bean.ParentDept);
            }
            if (sql1.Length > 0)
            {
                sql1 = sql1.Remove(sql1.Length - 1, 1);
                sql2 = sql2.Remove(sql2.Length - 1, 1);
            }

            var sql = "insert into t_department(" + sql1 + ") values(" + sql2 + ")";
            Log.Debug("SQL :" + sql + ",params:" + list.ToString());
            Oop.Execute(sql, list.ToArray());
        }

        public override void Del(Department bean)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 删除人员
        /// </summary>
        /// <param name="id"></param>
        public void DelDepartment(string id)
        {
            Log.Debug("del方法参数：");
            var sql = "delete from t_department where id='" + id + "' or parentdept='" + id + "'";
            Oop.Execute(sql);
        }
        public override void Modify(Department bean)
        {
            Log.Debug("Modify方法参数：" + bean.ToString());
            var sql = "update t_department set";
            var i = 0;
            var dList = new List<object>();
            if (string.IsNullOrEmpty(bean.Name))
            {
                sql += " name={" + i++ + "}";
                dList.Add(bean.Name);
            }
            if (string.IsNullOrEmpty(bean.ParentDept))
            {
                sql += " parentDept={" + i++ + "}";
                dList.Add(bean.ParentDept);
            }
            sql += " where id={" + i++ + "}";
            dList.Add(bean.Id);
            Log.Debug("SQL :" + sql + ",params:" + dList.ToString());
            Oop.Execute(sql, dList.ToArray());
        }

        /// <summary>
        /// 更新部门
        /// </summary>
        /// <param name="bean"></param>
        public void UpdateDepartment(Department bean)
        {
            Log.Debug("更新部门");
            var sql = "update t_department set name='" + bean.Name + "' where id='" + bean.Id + "'";
            Oop.Execute(sql);
        }

        /// <summary>
        /// 查询部门表
        /// </summary>
        /// <param name="bean">部门实体类</param>
        /// <returns></returns>
        public override DataTable Query(Department bean)
        {
            Log.Debug("Query方法参数：" + bean.ToString());
            var sql = new StringBuilder();
            sql.Append("select * from t_department where 1=1 ");
            var list = new List<object>();
            var i = -1;
            if (!string.IsNullOrEmpty(bean.Id))
            {
                sql.Append(" and id={" + ++i + "}");
                list.Add(bean.Id);
            }
            if (!string.IsNullOrEmpty(bean.Name))
            {
                sql.Append(" and name={" + ++i + "}");
                list.Add(bean.Name);
            }
            if (!string.IsNullOrEmpty(bean.ParentDept))
            {
                sql.Append(" and ParentDept={" + ++i + "}");
                list.Add(bean.ParentDept);
            }
            Log.Debug("SQL :" + sql + ",params:" + list.ToString());
            return Oop.GetDataTable(sql.ToString(), list.ToArray());
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

            return Oop.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 查询子节点下所有节点
        /// </summary>
        /// <param name="deptId"></param>
        /// <returns></returns>
        public DataTable QueryNodeTree(string deptId)
        {
            Log.Debug("QueryNodeTree方法参数：");
            var strSql = new StringBuilder();
            strSql.Append("select * from (");
            strSql.Append("SELECT id,name,parentdept FROM t_department ");
            strSql.Append("start with id='" + deptId + "' connect by prior id = parentdept");
            strSql.Append(" ) t where id!='" + deptId + "'");
            return Oop.GetDataTable(strSql.ToString());
        }


        public override DataTable QueryByPage(Department bean, int page, int rows)
        {
            throw new NotImplementedException();
        }

        public override DataTable QueryByPage(Department bean, int page, int rows, ref int count)
        {
            throw new NotImplementedException();
        }


        public DataTable QueryDept(Department bean, int page, int rows, ref int recordcount)
        {
            Log.Debug("QueryNode方法参数：");
            var sql1 = new StringBuilder();
            var sql2 = new StringBuilder();
            var sql = new StringBuilder();
            sql1.Append("select count(*) count from t_department t  ");
            sql2.Append("select * from t_department t  ");
            sql.Append("where parentdept='" + bean.ParentDept + "'");

            sql1.Append(sql);
            var dt = Oop.GetDataTable(sql1.ToString());
            var count = dt.Rows[0]["count"].ToString();
            recordcount = int.Parse(count);

            sql2.Append(sql);
            return Oop.GetDataTable(sql2.ToString());
        }
    }
}

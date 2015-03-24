using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChargingPile.Model
{
    /// <summary>
    /// 部门表
    /// </summary>
    [Serializable]
    public class Department : BaseModel<Department>
    {
        /// <summary>
        /// pk,自增长
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 父部门
        /// </summary>
        public string ParentDept { get; set; }

       

        public override string ToString()
        {
            return "Id:" + this.Id + ",Name:" + this.Name + ",DeptId:" + this.ParentDept;
        }
    }
}

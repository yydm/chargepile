using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChargingPile.Model
{
    /// <summary>
    /// 类SM_ROLE。
    /// </summary>
    [Serializable]
    public class Role : BaseModel<Role>
    {
        /// <summary>
        /// 角色Id
        /// </summary>
        public string RoleId { get; set; }

        /// <summary>
        /// 应用系统Id
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// 角色描述
        /// </summary>
        public string RoleDesc { get; set; }

        /// <summary>
        /// 角色编号
        /// </summary>
        public decimal? RoleNo { get; set; }

        /// <summary>
        /// 岗位级别
        /// </summary>
        public decimal? StaGrade { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateDT { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateDT { get; set; }

        public override string ToString()
        {
            return "RoleId:'" + RoleId + "',AppId:'" + AppId + "',RoleName:'" +
                RoleName + "',RoleDesc:'" + RoleDesc + "',RoleNo:'" + RoleNo +
                "',StaGrade:'" + StaGrade + "',CreateDT:'" + CreateDT + "',UpdateDT:'" + UpdateDT + "'";
        }
    }
}

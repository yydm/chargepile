using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChargingPile.Model
{
    /// <summary>
    /// 类SM_USEROLES。
    /// </summary>
    [Serializable]
    public class UseRoles : BaseModel<UseRoles>
    {
        /// <summary>
        /// 角色Id
        /// </summary>
        public string RoleId { set; get; }

        /// <summary>
        /// 系统登录名
        /// </summary>
        public string LoginName { set; get; }

        /// <summary>
        /// 角色名
        /// </summary>
        public string RoleName { get; set; }

        public override string ToString()
        {
            return "RoleId:'" + RoleId + "',LoginName:'" + LoginName + "',RoleName:'" + RoleName;
        }
    }
}

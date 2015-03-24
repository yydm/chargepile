using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChargingPile.Model
{
    /// <summary>
    /// 人员表
    /// </summary>
    [Serializable]
    public class Employer : BaseModel<Employer>
    {
        public Employer()
        {
        }

        /// <summary>
        /// pk,自增长
        /// </summary>
        public string Id { get; set; }


        /// <summary>
        /// 工号
        /// </summary>
        public string WorkNum { get; set; }

        /// <summary>
        /// 人员名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 所属部门
        /// </summary>
        public string DeptId { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string PhoneNum { get; set; }

        /// <summary>
        /// 电子邮件地址
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 密码，默认：888888
        /// </summary>
        public string Password { get; set; }

        public string DeptName { get; set; }

        public override string ToString()
        {
            return "Id:" + this.Id + ",Name:" + this.Name + ",DeptId:" + this.DeptId + ",Email:" + this.Email;
        }
    }
}

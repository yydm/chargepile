using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChargingPile.Model
{
    public class MenuPower
    {
        public string Id { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        public string MenuId { get; set; }

        /// <summary>
        /// 角色id
        /// </summary>
        public string PowerId { get; set; }

        public override string ToString()
        {
            return "Id:" + this.Id + ",MenuId:" + this.MenuId +
                ",PowerId:" + this.PowerId;
        }
    }
}

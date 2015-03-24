using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChargingPile.Model
{
    /// <summary>
    /// 所有实体类都应该继承此类
    /// </summary>
    public abstract class BaseModel<T>
    {
        /// <summary>
        /// 重写ToString方法，实体类输出格式为：属性1：值1，属性2：值2...
        /// </summary>
        /// <returns></returns>
        public abstract override string ToString();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChargingPile.BLL
{
    public class ZwJsonMessage<T>:ZwMessage<T>
    {
        // 信息状态
        // 0:失败，1:成功, 2:其它
        public int? Status { get; set; }

        // 返回信息
        public string Msg { get; set; }

        //js前台执行方法
        public string JsExecuteMethod { get; set; }

        public override string ToString()
        {
            return "Total:" + base.Total +
                   ",Rows:" + base.Rows +
                   ",Status:" + this.Status +
                   ",Msg:" + this.Msg;
        }
    }
}

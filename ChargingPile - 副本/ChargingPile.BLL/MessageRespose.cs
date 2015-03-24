using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChargingPile.BLL
{
    public class MessageRespose
    {
        public MessageRespose() { }
        public MessageRespose(object success, object error)
        {
            Success = success;
            Error = error;
        }
        public object Success { set; get; }
        public object Error { set; get; }
    }
}

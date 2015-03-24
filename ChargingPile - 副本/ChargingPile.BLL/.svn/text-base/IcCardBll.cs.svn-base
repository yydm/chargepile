using System.Data;
using ChargingPile.DAL;
using ChargingPile.Model;

namespace ChargingPile.BLL
{
    public class IcCardBll
    {
        readonly IcCard _icCard = new IcCard();
        public DataTable QueryCardInfo(CardInfo bean, int page, int rows, ref  int count)
        {
            return _icCard.QueryCardInfo(bean, page, rows, ref count);
        }

        public DataTable QueryCzjl(CardInfo bean, int page, int rows, ref int count)
        {
            return _icCard.QueryCzjl(bean, page, rows, ref count);
        }

        public DataTable QueryGs(CardInfo bean, int page, int rows, ref int count)
        {
            return _icCard.QueryGs(bean, page, rows, ref count);
        }

        public DataTable QueryPsysDic(string dicId)
        {
            return _icCard.QueryPsysDic(dicId);
        }

        public DataTable QueryExp(CardInfo bean, int page, int rows, ref int count)
        {
            return _icCard.QueryExp(bean, page, rows, ref count);
        }

    }
}

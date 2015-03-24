using System.Collections.Generic;

namespace ChargingPile.UI.WEB.Common
{
    public class PageObject<T>
    {
        public int total { get; set; }

        public List<T> rows { get; set; }

        public PageObject()
        { }

        public PageObject(int total, List<T> rows)
        {
            this.total = total;
            this.rows = rows;
        }
    }
}
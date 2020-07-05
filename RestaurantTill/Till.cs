using System.Collections.Generic;
using System.Linq;

namespace RestaurantTill
{
    public class Till
    {
        public readonly IList<TillItem> Items;
        public Till(IList<TillItem> items = null)
        {
            Items = items ?? new List<TillItem>();
        }

       public double TotalCost()
        {
            return Items.Sum(i => i.TillItemType.Cost * i.Quantity);
        }
    }
}

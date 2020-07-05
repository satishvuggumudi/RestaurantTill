using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantTill
{
    public class Main : ITillItemType
    {
        public double Cost => CostOf.Mains;

        public ItemType ItemType => ItemType.Main;
    }
}

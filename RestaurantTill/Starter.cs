namespace RestaurantTill
{
    public class Starter : ITillItemType
    {
        public double Cost => CostOf.Starter;

        public ItemType ItemType => ItemType.Starter;
    }
}

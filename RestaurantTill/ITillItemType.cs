namespace RestaurantTill
{
    public interface ITillItemType
    {
        double Cost { get; }
        ItemType ItemType { get; }
    }
}

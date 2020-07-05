using System;


namespace RestaurantTill
{
    public class TillItem
    {
        public TillItem(ITillItemType tillItemType, int quantity)
        {
            if (tillItemType == null)
            {
                throw new ArgumentNullException(nameof(tillItemType));
            }

            if (quantity <= 0)
            {
                throw new ArgumentException(nameof(quantity));
            }

            TillItemType = tillItemType;
            Quantity = quantity;
        }

        public int Quantity { private set; get; }

        public ITillItemType TillItemType { private set; get; }


        public void IncrementQuantity()
        {
            Quantity++;
        }

        public void DecrementQuantity()
        {
            if(Quantity > 1)
            {
                Quantity--;
            }
            
        }
    }
}

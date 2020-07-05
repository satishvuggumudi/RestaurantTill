using System;
using System.Collections.Generic;
using RestaurantTill;
using Xunit;
using System.Linq;

namespace UnitTests
{
    public class TillTests
    {
        
        [Fact]
        public void ForEmptyTillTotalIsZero()
        {
            var till = new Till();
            var total = till.TotalCost();
            Assert.True(total == 0);
        }

        [Fact]
        public void CanAddItemToTill()
        {
            var till = new Till();
            till.Items.Add(new TillItem(TillItemType.Main(), 1));
            Assert.True(till.Items.Count == 1);
        }

        [Fact]
        public void CanDeleteItemFromTill()
        {
            var items = new List<TillItem>()
            {
                new TillItem(TillItemType.Main(), 1),
                new TillItem(TillItemType.Starter(), 1)
            };
            var till = new Till(items);
            till.Items.RemoveAt(1);
            Assert.True(till.Items.Count == 1);
            Assert.True(till.Items.Count(i => i.TillItemType.ItemType == ItemType.Starter) == 0);
        }

        [Fact]
        public void CanIncrementItemQuantityInTill()
        {
            var items = new List<TillItem>()
            {
                new TillItem(TillItemType.Starter(), 1)
            };
            var till = new Till(items);
            till.Items.First().IncrementQuantity();
            Assert.True(till.Items.First().Quantity == 2);
        }

        [Fact]
        public void CanDecrementItemQuantityInTill()
        {
            var items = new List<TillItem>()
            {
                new TillItem(TillItemType.Starter(), 2)
            };
            var till = new Till(items);
            till.Items.First().DecrementQuantity();
            Assert.True(till.Items.First().Quantity == 1);
        }

        [Fact]
        public void CanNotDecrementItemIfQuantityIsOneInTillIs()
        {
            var items = new List<TillItem>()
            {
                new TillItem(TillItemType.Starter(), 1)
            };
            var till = new Till(items);
            till.Items.First().DecrementQuantity();
            Assert.True(till.Items.First().Quantity == 1);
        }


        [Theory]
        [InlineData(1, 1, 11.40)]
        [InlineData(1, 2, 15.8)]
        [InlineData(2, 1, 18.40)]
        public void GivenTillItemsTheTotalShouldBeCorrect(int mainsQuntity, int startersQuantity, double expectedTotal)
        {
            var items = new List<TillItem>()
            {
                new TillItem(TillItemType.Main(), mainsQuntity),
                new TillItem(TillItemType.Starter(), startersQuantity)
            };
            var till = new Till(items);
            var totalCost = till.TotalCost();
            Assert.Equal(expectedTotal, totalCost);
        }
    }
}

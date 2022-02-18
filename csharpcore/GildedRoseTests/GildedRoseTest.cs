using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        [Fact]
        public void foo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal("foo", Items[0].Name);
        }


        [Fact]
        public void AfterSellDate_test()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "foo", SellIn = 0, Quality = 20 }
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal("foo", Items[0].Name);
            Assert.Equal(18, Items[0].Quality);
        }

        [Fact]
        public void BeforeSellDateNormalItem_test()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "foo", SellIn = 1, Quality = 20 }
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal("foo", Items[0].Name);
            Assert.Equal(19, Items[0].Quality);
        }
    }
}

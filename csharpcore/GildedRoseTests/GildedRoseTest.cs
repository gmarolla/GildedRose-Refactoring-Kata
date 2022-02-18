using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        private void runUpdateQuality(IList<Item> Items)
        {
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
        }
        [Fact]
        public void Aged_Brie_Quality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 } };
            runUpdateQuality(Items);
            Assert.Equal(1, Items[0].Quality);
        }

        [Fact]
        public void Aged_Brie_more50()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 2, Quality = 50 } };
            runUpdateQuality(Items);
            Assert.Equal(50, Items[0].Quality);
        }
        [Fact]
        public void Sulfuras_Never_Lose_Quallity()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 2, Quality = 80 } };
            runUpdateQuality(Items);
            Assert.Equal(80, Items[0].Quality);
        }

        [Fact]
        public void Sulfuras_Never_Sell()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 2, Quality = 80 } };
            runUpdateQuality(Items);
            Assert.Equal(2, Items[0].SellIn);
        }

        [Fact]
        public void Backstage_Pass_LessThen10Days()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 9, Quality = 20 } };
            runUpdateQuality(Items);
            Assert.Equal(22, Items[0].Quality);
        }

        [Fact]
        public void Backstage_Pass_LessThen5Days()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 4, Quality = 20 } };
            runUpdateQuality(Items);
            Assert.Equal(23, Items[0].Quality);
        }

        [Fact]
        public void Backstage_Pass_MoreThen10Days()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 22, Quality = 20 } };
            runUpdateQuality(Items);
            Assert.Equal(21, Items[0].Quality);
        }

        [Fact]
        public void Backstage_Pass_Less0Days()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -1, Quality = 20 } };
            runUpdateQuality(Items);
            Assert.Equal(0, Items[0].Quality);
        }


        [Fact]
        public void Backstage_Pass_QualityMore50()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 20, Quality = 50 } };
            runUpdateQuality(Items);
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        public void NormalItem_BeforeSellDays()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "SAS Legendary", SellIn = 20, Quality = 50 } };
            runUpdateQuality(Items);
            Assert.Equal(49, Items[0].Quality);
            Assert.Equal(19, Items[0].SellIn);
        }

        [Fact]
        public void NormalItem_AfterSellDays()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "SAS Legendary", SellIn = -1, Quality = 50 } };
            runUpdateQuality(Items);
            Assert.Equal(48, Items[0].Quality);
        }

        [Fact]
        public void NeverNegative()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "SAS Legendary", SellIn = -1, Quality = 0 } };
            runUpdateQuality(Items);
            Assert.Equal(0, Items[0].Quality);
        }

        [Fact]
        public void ConjuredDoubleQualityDecrese()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 5, Quality = 10 } };
            runUpdateQuality(Items);
            Assert.Equal(8, Items[0].Quality);
        }
        [Fact]
        public void ConjuredDoubleQualityDecreseWithNegativeSellin()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = -1, Quality = 10 } };
            runUpdateQuality(Items);
            Assert.Equal(6, Items[0].Quality);
        }

    }
}

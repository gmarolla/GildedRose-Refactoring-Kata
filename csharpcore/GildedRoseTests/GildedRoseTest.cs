using Xunit;
using System.Collections.Generic;
using GildedRoseKata;
using GildedRose;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        [Fact]
        public void foo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 0, Quality = 0 } };


            IList<ItemParam> ItemParams = new List<ItemParam>();
            ItemParam itemParam = new ItemParam(new Item { Name = "+5 Dexterity Vest", SellIn = 0, Quality = 0 }, ItemCategory.Standard);
            ItemParams.Add(itemParam);


            GildedRoseQualityService app = new GildedRoseQualityService(ItemParams);
            app.UpdateQuality();
            Assert.Equal("+5 Dexterity Vest", Items[0].Name);
        }
        [Fact]
        public void Standard()
        {

            // GIVEN
            IList<ItemParam> ItemParams = new List<ItemParam>();
            Item item = new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 };
            ItemParam itemParam = new ItemParam(item, ItemCategory.Standard);
            ItemParams.Add(itemParam);

            // WHEN
            GildedRoseQualityService app = new GildedRoseQualityService(ItemParams);
            app.UpdateQuality();
            // THEN
            Assert.Equal(19, ItemParams[0]._Item.Quality);
            Assert.Equal(9, ItemParams[0]._Item.SellIn);
        }
        [Fact]
        public void Legendary()
        {

            // GIVEN
            IList<ItemParam> ItemParams = new List<ItemParam>();
            Item item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 };
            ItemParam itemParam = new ItemParam(item, ItemCategory.Lengendary);
            ItemParams.Add(itemParam);

            // WHEN
            GildedRoseQualityService app = new GildedRoseQualityService(ItemParams);
            app.UpdateQuality();
            // THEN
            Assert.Equal(80, ItemParams[0]._Item.Quality);
            Assert.Equal(0, ItemParams[0]._Item.SellIn);
        }
        [Fact]
        public void AgedBrie()
        {

            // GIVEN
            IList<ItemParam> ItemParams = new List<ItemParam>();
            Item item = new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 };
            ItemParam itemParam = new ItemParam(item, ItemCategory.AgedBrie);
            ItemParams.Add(itemParam);

            // WHEN
            GildedRoseQualityService app = new GildedRoseQualityService(ItemParams);
            app.UpdateQuality();
            // THEN
            Assert.Equal(1, ItemParams[0]._Item.Quality);
            Assert.Equal(1, ItemParams[0]._Item.SellIn);
        }
        [Fact]
        public void Concert_SeelinBefore10()
        {

            // GIVEN
            IList<ItemParam> ItemParams = new List<ItemParam>();
            Item item = new Item { Name= "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 };
            ItemParam itemParam = new ItemParam(item, ItemCategory.Concert);
            ItemParams.Add(itemParam);

            // WHEN
            GildedRoseQualityService app = new GildedRoseQualityService(ItemParams);
            app.UpdateQuality();
            // THEN
            Assert.Equal(19, ItemParams[0]._Item.Quality);
            Assert.Equal(14, ItemParams[0]._Item.SellIn);
        }
        [Fact]
        public void Concert_Sellin9()
        {

            // GIVEN
            IList<ItemParam> ItemParams = new List<ItemParam>();
            Item item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn =9 , Quality = 20 };
            ItemParam itemParam = new ItemParam(item, ItemCategory.Concert);
            ItemParams.Add(itemParam);

            // WHEN
            GildedRoseQualityService app = new GildedRoseQualityService(ItemParams);
            app.UpdateQuality();
            // THEN
            Assert.Equal(18, ItemParams[0]._Item.Quality);
            Assert.Equal(8, ItemParams[0]._Item.SellIn);
        }
        [Fact]
        public void Concert_Sellin3()
        {

            // GIVEN
            IList<ItemParam> ItemParams = new List<ItemParam>();
            Item item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 3, Quality = 20 };
            ItemParam itemParam = new ItemParam(item, ItemCategory.Concert);
            ItemParams.Add(itemParam);

            // WHEN
            GildedRoseQualityService app = new GildedRoseQualityService(ItemParams);
            app.UpdateQuality();
            // THEN
            Assert.Equal(17, ItemParams[0]._Item.Quality);
            Assert.Equal(2, ItemParams[0]._Item.SellIn);
        }
        [Fact]
        public void Concert_SellinZero()
        {

            // GIVEN
            IList<ItemParam> ItemParams = new List<ItemParam>();
            Item item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -1, Quality = 20 };
            ItemParam itemParam = new ItemParam(item, ItemCategory.Concert);
            ItemParams.Add(itemParam);

            // WHEN
            GildedRoseQualityService app = new GildedRoseQualityService(ItemParams);
            app.UpdateQuality();
            // THEN
            Assert.Equal(0, ItemParams[0]._Item.Quality);
            Assert.Equal(-2, ItemParams[0]._Item.SellIn);
        }
        [Fact]
        public void Conjured()
        {

            // GIVEN
            IList<ItemParam> ItemParams = new List<ItemParam>();
            Item item = new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 };
            ItemParam itemParam = new ItemParam(item, ItemCategory.Conjured);
            ItemParams.Add(itemParam);

            // WHEN
            GildedRoseQualityService app = new GildedRoseQualityService(ItemParams);
            app.UpdateQuality();
            // THEN
            Assert.Equal(4, ItemParams[0]._Item.Quality);
            Assert.Equal(2, ItemParams[0]._Item.SellIn);
        }

        [Fact]
        public void Conjured_MinusSellin()
        {
            // GIVEN
            IList<ItemParam> ItemParams = new List<ItemParam>();
            Item item = new Item { Name = "Conjured Mana Cake", SellIn = -1, Quality = 6 };
            ItemParam itemParam = new ItemParam(item, ItemCategory.Conjured);
            ItemParams.Add(itemParam);

            // WHEN
            GildedRoseQualityService app = new GildedRoseQualityService(ItemParams);
            app.UpdateQuality();
            // THEN
            Assert.Equal(2, ItemParams[0]._Item.Quality);
            Assert.Equal(-2, ItemParams[0]._Item.SellIn);
        }
    }
}

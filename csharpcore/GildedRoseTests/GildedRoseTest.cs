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
            // GIVEN

            IList<ItemParam> ItemParams = CreateItemParams("+5 Dexterity Vest", 0, 0, ItemCategory.Standard);

            // WHEN

            GildedRoseQualityService app = new GildedRoseQualityService(ItemParams);
            app.UpdateQuality();
            // THEN

            Assert.Equal("+5 Dexterity Vest", ItemParams[0]._Item.Name);
        }
        [Fact]
        public void Standard()
        {

            // GIVEN
            IList<ItemParam> ItemParams = CreateItemParams("+5 Dexterity Vest", 10, 20, ItemCategory.Standard);

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
            IList<ItemParam> ItemParams = CreateItemParams("Sulfuras, Hand of Ragnaros", 0, 80, ItemCategory.Lengendary);

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
            IList<ItemParam> ItemParams = CreateItemParams("Aged Brie", 2, 0, ItemCategory.AgedBrie);

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
            IList<ItemParam> ItemParams = CreateItemParams("Backstage passes to a TAFKAL80ETC concert", 15, 20, ItemCategory.Concert);

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
            IList<ItemParam> ItemParams = CreateItemParams("Backstage passes to a TAFKAL80ETC concert", 3, 20, ItemCategory.Concert);

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
            IList<ItemParam> ItemParams = CreateItemParams("Backstage passes to a TAFKAL80ETC concert", -1,20, ItemCategory.Concert);

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
            IList<ItemParam> ItemParams = CreateItemParams("Conjured Mana Cake", 3, 6, ItemCategory.Conjured);

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
            IList<ItemParam> ItemParams = CreateItemParams("Conjured Mana Cake", -1, 6, ItemCategory.Conjured);

            // WHEN
            GildedRoseQualityService app = new GildedRoseQualityService(ItemParams);
            app.UpdateQuality();
            // THEN
            Assert.Equal(2, ItemParams[0]._Item.Quality);
            Assert.Equal(-2, ItemParams[0]._Item.SellIn);
        }

        private static IList<ItemParam> CreateItemParams(string name, int sellInValue, int qualityValue, ItemCategory category )
        {
            IList<ItemParam> ItemParams = new List<ItemParam>();
            Item item = new Item { Name = name, SellIn = sellInValue, Quality = qualityValue };
            ItemParam itemParam = new ItemParam(item,category);
            ItemParams.Add(itemParam);
            return ItemParams;
        }
    }
}

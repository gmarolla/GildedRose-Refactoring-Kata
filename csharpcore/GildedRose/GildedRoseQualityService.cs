using GildedRose;
using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRoseQualityService
    {
        public IList<Item> Items;
        public IList<ItemParam> _ItemParams;

        public GildedRoseQualityService(IList<Item> Items)
        {
            this.Items = Items;
            _ItemParams = GetItemParameters(Items);
        }

        private IList<ItemParam> GetItemParameters(IList<Item> items)
        {
            IList<ItemParam> ItemParams = new List<ItemParam>();
            ItemParam itemParam = new ItemParam();

            foreach (Item item in Items)
            {
                switch (item.Name)
                {
                    case "":
                        break;
                    case "Aged Brie":
                        itemParam = new ItemParam(item, ItemCategory.AgedBrie);
                        ItemParams.Add(itemParam);
                        break;
                    case "Sulfuras, Hand of Ragnaros":
                        itemParam = new ItemParam(item, ItemCategory.Lengendary);
                        ItemParams.Add(itemParam);
                        break;
                    case "Backstage passes to a TAFKAL80ETC concert":
                        itemParam = new ItemParam(item, ItemCategory.Concert);
                        ItemParams.Add(itemParam);
                        break;
                    case "Conjured Mana Cake":
                        itemParam = new ItemParam(item, ItemCategory.Conjured);
                        ItemParams.Add(itemParam);
                        break;
                    default:
                        itemParam = new ItemParam(item, ItemCategory.Standard);
                        ItemParams.Add(itemParam);

                        break;
                }
            }

            return ItemParams;
        }

        public GildedRoseQualityService(IList<ItemParam> itemParams)
        {
            _ItemParams = itemParams;
        }
        public void UpdateQuality()
        {

            // update inventaire 
            // List d'item = name, qualité value, sellInValue (nombre de jour restant pour vendre l'article)

            // Pour chaque jours : Standard
            // qualité -1 
            // sellInValue -1
            // Qualité >= 0 && Qualité <= 50
            // sellInValueZero : Si sellInValue == 0 --> qualité -2

            // bool : Quality augmente si sellInValue augmente
            // legendary bool : not sellInValue && Quality cannot decrease 
            // J-10 : augmente quality by 2
            // J-5 : augmente quality by 3
            // J-0 : quality back to zero
            // Conjured : quality decrease twice faster

            for (var i = 0; i < _ItemParams.Count; i++)
            {
                UpdateDependingItemCategory(i);
                DecreaseSellin(_ItemParams[i]._Item);
            }
        }

        private void UpdateDependingItemCategory(int i)
        {
            switch (_ItemParams[i]._ItemCategory)
            {
                case (ItemCategory.Standard):
                    StandardUpdateCurrentItem(_ItemParams[i]._Item);
                    break;
                case (ItemCategory.AgedBrie):
                    AgedBrieUpdateCurrentItem(_ItemParams[i]._Item);

                    break;
                case (ItemCategory.Lengendary):
                    LegendaryUpdateCurrentItem(_ItemParams[i]._Item);
                    break;
                case (ItemCategory.Concert):
                    ConcertUpdateCurrentItem(_ItemParams[i]._Item);
                    break;
                case (ItemCategory.Conjured):
                    ConjuredUpdateCurrentItem(_ItemParams[i]._Item);
                    break;
                default:
                    break;
            }
        }

        private void AgedBrieUpdateCurrentItem(Item item)
        {

            if (item.Quality >= 0 && item.Quality < 50)
            {
                if (item.SellIn == 0)
                {
                    item.Quality = item.Quality;
                }
                else
                {
                    IncreaseQuality(item, 1);
                }
            }
        }

        private void ConcertUpdateCurrentItem(Item item)
        {
            // J-10 : augmente quality by 2
            // J-5 : augmente quality by 3
            // J-0 : quality back to zero
            if (item.Quality > 0 && item.Quality <= 50)
            {
                if (item.SellIn <= 0)
                {
                    item.Quality = 0;
                }
                else if (item.SellIn <= 5)
                {
                    DecreaseQuality(item, 3);
                }
                else if (item.SellIn <= 10)
                {
                    DecreaseQuality(item, 2);
                }
                else
                {
                    DecreaseQuality(item, 1);
                }
            }

        }

        private void LegendaryUpdateCurrentItem(Item item)
        {
            // legendary bool : not sellInValue && Quality cannot decrease 

        }

        private void ConjuredUpdateCurrentItem(Item item)
        {
            // Conjured : quality decrease twice faster

            if (item.Quality > 0 && item.Quality <= 50)
            {

                if (item.SellIn <= 0)
                {
                    if (item.Quality == 1)
                    {
                        DecreaseQuality(item, 1);
                    }
                    else
                    {
                        DecreaseQuality(item, 4);
                    }
                }
                else
                {
                    DecreaseQuality(item, 2);
                }
            }
        }

        private static void DecreaseSellin(Item item)
        {
            if (item.SellIn != 0)
            {
                item.SellIn = item.SellIn - 1;
            }
        }
        private static void DecreaseQuality(Item item, int quantity)
        {
            item.Quality = item.Quality - quantity;
        }
        private static void IncreaseQuality(Item item, int quantity)
        {
            item.Quality = item.Quality + quantity;
        }
        private void StandardUpdateCurrentItem(Item item)
        {
            // Pour chaque jours : Standard

            // qualité -1 
            // sellInValue -1
            // Qualité >= 0 && Qualité <= 50
            // sellInValueZero : Si sellInValue == 0 --> qualité -2
            if (item.Quality > 0 && item.Quality <= 50)
            {
                if (item.SellIn == 0)
                {
                    if (item.Quality == 1)
                    {
                        DecreaseQuality(item, 1);
                    }
                    else
                    {
                        DecreaseQuality(item, 2);
                    }
                }
                else
                {
                    DecreaseQuality(item, 1);
                }
            }
        }
    }
}

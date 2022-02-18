using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {

                if (isNormalItem(i))
                {
                    DecreaseQualityBy1(i);
                }
                else
                {
                    if (Items[i].Quality < 50)
                    {
                        IncreaseQualitBy1(i);

                        if (isBackstagePasses(i))
                        {
                            if (Items[i].SellIn < 11)
                            {
                                IncreaseForQualityLessThanLimit(i);
                            }

                            if (Items[i].SellIn < 6)
                            {
                                IncreaseForQualityLessThanLimit(i);
                            }
                        }
                    }
                }


                DecreaseSellIn(i);

                if (Items[i].SellIn < 0)
                {
                    if (!isAgedBrie(i))
                    {
                        if (!isBackstagePasses(i))
                        {
                            DecreaseQuality(i);
                        }
                        else
                        {
                            Items[i].Quality = Items[i].Quality - Items[i].Quality;
                        }
                    }
                    else
                    {
                        IncreaseForQualityLessThanLimit(i);
                    }
                }
            }
        }

        private void IncreaseForQualityLessThanLimit(int i)
        {
            if (Items[i].Quality < 50)
            {
                IncreaseQualitBy1(i);
            }
        }

        private void IncreaseQualitBy1(int i)
        {
            Items[i].Quality = Items[i].Quality + 1;
        }

        private void DecreaseQuality(int i)
        {
            if (Items[i].Quality > 0)
            {
                DecreaseNotSulfurasHandOfRagnaros(i);
            }
        }

        private void DecreaseNotSulfurasHandOfRagnaros(int i)
        {
            if (!isSulfuras(i))
            {
                DecreaseQualityBy1(i);
            }
        }

        private void DecreaseQualityBy1(int i)
        {
            Items[i].Quality = Items[i].Quality - 1;
        }

        private void DecreaseSellIn(int i)
        {
            if(!isSulfuras(i))
                Items[i].SellIn = Items[i].SellIn - 1;
        }

        private bool isAgedBrie(int i)
        {
            return Items[i].Name == "Aged Brie";
        }
        private bool isBackstagePasses(int i)
        {
            return Items[i].Name == "Backstage passes to a TAFKAL80ETC concert";
        }
        private bool isSulfuras(int i)
        {
            return Items[i].Name == "Sulfuras, Hand of Ragnaros";
        }

        private bool isNormalItem(int i)
        {
            return !isAgedBrie(i) && !isBackstagePasses(i) && !isSulfuras(i);
        }
    }
}

using GildedRoseKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata.ItemMangement
{
    interface IItemManagement
    {
        public void UpdateItem(Item item);
    }
    public class ItemManagement : IItemManagement
    {
        public const int MAXQUALITY = 50;
        public const int MINQUALITY = 0;
        public virtual void UpdateItem(Item item)
        {

        }
        public void DecreesQualityUsingSellIn(Item item)
        {
            if (item.SellIn < 0)
            {
                DecreesQuality(item);
            }
        }

        public void DecreesQuality(Item item)
        {
            if (item.Quality > MINQUALITY)
            {
                item.Quality = item.Quality - 1;
            }
        }

        public void DecreesQuality(Item item, int Moltiplicator)
        {
            if (item.Quality > MINQUALITY)
            {
                item.Quality = item.Quality - Moltiplicator;
            }

            if (item.Quality < MINQUALITY)
            {
                item.Quality = MINQUALITY;
            }
        }

        public void IncreseQuality(Item item)
        {
            if (item.Quality < MAXQUALITY)
            {
                item.Quality = item.Quality + 1;
            }
        }
        public void DecreesSellIn(Item item)
        {
            item.SellIn = item.SellIn - 1;
        }


        public void SetQualityToMin(Item item)
        {
            item.Quality = 0;
        }
    }
}

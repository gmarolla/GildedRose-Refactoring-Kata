using GildedRoseKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata.ItemMangement
{
    public class BackstageItem : ItemManagement
    {
        public override void UpdateItem(Item item)
        {
            if (item.Quality < MAXQUALITY)
            {
                IncreseQuality(item);

                if (item.SellIn < 11)
                {
                    IncreseQuality(item);
                }

                if (item.SellIn < 6)
                {
                    IncreseQuality(item);
                }
            }

            if (item.SellIn < MINQUALITY)
            {
                SetQualityToMin(item);
            }

            DecreesSellIn(item);
        }
    }
}

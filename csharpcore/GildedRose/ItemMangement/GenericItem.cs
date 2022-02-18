using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata.ItemMangement
{
    public class GenericItem : ItemManagement
    {
        public override void UpdateItem(Item item)
        {
            DecreesQuality(item);
            DecreesQualityUsingSellIn(item);
            DecreesSellIn(item);
        }
    }
}
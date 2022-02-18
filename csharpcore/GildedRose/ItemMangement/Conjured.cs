using GildedRoseKata.ItemMangement;

namespace GildedRoseKata.ItemMangement
{
    public class Conjured : ItemManagement
    {
        public override void UpdateItem(Item item)
        {
            DecreesQuality(item, 2);
            DecreesQualityUsingSellIn(item);
            DecreesQualityUsingSellIn(item);
            DecreesSellIn(item);
        }
    }
}
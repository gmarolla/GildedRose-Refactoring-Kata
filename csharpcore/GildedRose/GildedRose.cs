using GildedRoseKata.ItemMangement;
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
            foreach (Item item in Items)
            {
                UpdateItem(item);
            }
        }


        public void UpdateItem(Item item)
        {
            IItemManagement itemMan;
            switch (item.Name)
            {
                case "Backstage passes to a TAFKAL80ETC concert":
                    itemMan = new BackstageItem();
                    break;
                case "Aged Brie":
                    itemMan = new AgedBrie();
                    break;
                case "Sulfuras, Hand of Ragnaros":
                    itemMan = new Sulfuras();
                    break;
                case "Conjured Mana Cake":
                    itemMan = new Conjured();
                    break;
                default:
                    itemMan = new GenericItem();
                    break;
            }

            itemMan.UpdateItem(item);

        }

    }
}

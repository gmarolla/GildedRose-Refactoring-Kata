using GildedRoseKata;

namespace GildedRose
{
    public class ItemParam
    {
        public Item _Item { get; set; }
        public ItemCategory _ItemCategory { get; set; }

        public ItemParam() { }
        public ItemParam(Item item, ItemCategory itemCategory)
        {
            _Item = item;
            _ItemCategory = itemCategory;
        }

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata.ItemMangement
{
    public class AgedBrie : ItemManagement
    {
        public override void UpdateItem(Item item)
        {
            IncreseQuality(item);
            DecreesSellIn(item);
        }
    }
}
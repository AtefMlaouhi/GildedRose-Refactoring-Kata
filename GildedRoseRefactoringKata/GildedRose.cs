using System;
using System.Collections.Generic;

namespace GildedRoseRefactoringKata
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
                if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (Items[i].Quality > 0)
                    {
                        if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                        {
                            this.SetQuality(i, -1);
                        }
                    }
                }
                else
                {
                    if (Items[i].Quality < 50)
                    {
                        this.SetQuality(i, 1);

                        if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (Items[i].SellIn < 11)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    this.SetQuality(i, 1);
                                }
                            }

                            if (Items[i].SellIn < 6)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    this.SetQuality(i, 1);
                                }
                            }
                        }
                    }
                }

                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    this.SetSellIn(i);
                }

                if (Items[i].SellIn < 0)
                {
                    if (Items[i].Name != "Aged Brie")
                    {
                        if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (Items[i].Quality > 0)
                            {
                                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                                {
                                    this.SetQuality(i, -1);
                                }
                            }
                        }
                        else
                        {
                            this.SetQuality(i, -Items[i].Quality);
                        }
                    }
                    else
                    {
                        if (Items[i].Quality < 50)
                        {
                            this.SetQuality(i, 1);
                        }
                    }
                }
            }
        }

        private void SetSellIn(int index)
        {
            Items[index].SellIn--;

        }

        private void SetQuality(int index, int value)
        {
            Items[index].Quality += value;
        }
    }
}

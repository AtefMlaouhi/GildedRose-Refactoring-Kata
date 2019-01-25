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
            bool condition = false;
            for (var i = 0; i < Items.Count; i++)
            {

                condition = Items[i].Name == "Sulfuras, Hand of Ragnaros";
                if (condition)
                {
                    continue;
                }

                condition = Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert";

                if (condition)
                {
                    if (Items[i].Quality > 0)
                    {
                        condition = Items[i].Name != "Sulfuras, Hand of Ragnaros";

                        if (condition)
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
                    }
                }

                condition = Items[i].Name == "Backstage passes to a TAFKAL80ETC concert";

                if (condition)
                {
                    if (Items[i].Quality < 50)
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

                condition = Items[i].Name != "Sulfuras, Hand of Ragnaros";

                if (condition)
                {
                    this.SetSellIn(i);
                }

                if (Items[i].SellIn < 0)
                {
                    condition = Items[i].Name == "Aged Brie";
                    if (condition)
                    {
                        if (Items[i].Quality < 50)
                        {
                            this.SetQuality(i, 1);
                        }
                    }
                }

                if (Items[i].SellIn < 0)
                {
                    condition = Items[i].Name != "Aged Brie";

                    if (condition)
                    {
                        condition = Items[i].Name != "Backstage passes to a TAFKAL80ETC concert";

                        if (condition)
                        {
                            if (Items[i].Quality > 0)
                            {
                                condition = Items[i].Name != "Sulfuras, Hand of Ragnaros";

                                if (condition)
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

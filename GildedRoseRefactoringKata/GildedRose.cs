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
                switch (Items[i].Name)
                {
                    case "Sulfuras, Hand of Ragnaros":
                        {
                            break;
                        }

                    case "Aged Brie":
                        {
                            this.SetSellIn(i);
                            if (Items[i].Quality < 50)
                            {
                                this.SetQuality(i, 1);
                            }
                            if (Items[i].SellIn < 0)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    this.SetQuality(i, 1);
                                }
                            }
                            break;
                        }
                    case "Backstage passes to a TAFKAL80ETC concert":
                        {
                            if (Items[i].Quality < 50)
                            {
                                this.SetQuality(i, 1);
                            }
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

                            this.SetSellIn(i);

                            if (Items[i].SellIn < 0)
                            {
                                Items[i].Quality = 0;
                            }
                            break;
                        }
                    default:
                        {
                            if (Items[i].Quality > 0)
                            {
                                this.SetQuality(i, -1);
                            }

                            this.SetSellIn(i);

                            if (Items[i].SellIn < 0)
                            {
                                if (Items[i].Quality > 0)
                                {

                                    this.SetQuality(i, -1);
                                }
                            }
                            break;
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

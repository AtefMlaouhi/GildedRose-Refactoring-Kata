using System;
using System.Collections.Generic;
using System.Linq;

namespace GildedRoseRefactoringKata
{
    public class GildedRose
    {
        IList<Item> Items;
        private string[] products = { "Sulfuras, Hand of Ragnaros", "Backstage passes to a TAFKAL80ETC concert" };

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            ServiceDelegate serviceDelegate = new ServiceDelegate();
            UpdateQualityClient client = new UpdateQualityClient();

            for (var i = 0; i < Items.Count; i++)
            {
                bool condition = products.Contains(Items[i].Name);
                serviceDelegate.SetItem(Items[i]);

                if (condition)
                {
                    OldMethod(i);
                }
                else
                {
                    if (Items[i].Name == "Aged Brie")
                    {
                        serviceDelegate.SetServiceType(AgedBrieProductService.ServicesType);
                    }
                    else
                    {
                        serviceDelegate.SetServiceType(DefaultProductService.ServicesType);
                    }
                    client.SetUpdateQualityClient(serviceDelegate);
                    serviceDelegate.DoUpdate();
                }
            }
        }


        public void OldMethod(int i)
        {
            switch (Items[i].Name)
            {
                case "Sulfuras, Hand of Ragnaros":
                    {
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
                        break;
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

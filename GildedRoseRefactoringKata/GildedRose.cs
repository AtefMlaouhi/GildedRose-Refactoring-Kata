using System;
using System.Collections.Generic;
using System.Linq;

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
            ServiceDelegate serviceDelegate = new ServiceDelegate();
            UpdateQualityClient client = new UpdateQualityClient();

            for (var i = 0; i < Items.Count; i++)
            {
                serviceDelegate.SetItem(Items[i]);
                if (Items[i].Name == "Aged Brie")
                {
                    serviceDelegate.SetServiceType(AgedBrieProductService.ServicesType);
                }
                
                if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    serviceDelegate.SetServiceType(BackstagePassesProductService.ServicesType);
                }

                if(Items[i].Name == "Sulfuras, Hand of Ragnaros")
                {
                    serviceDelegate.SetServiceType(SulfurasProductService.ServicesType);
                }

                bool condition = Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert" && Items[i].Name != "Sulfuras, Hand of Ragnaros";
                if (condition)
                {
                    serviceDelegate.SetServiceType(DefaultProductService.ServicesType);
                }

                client.SetUpdateQualityClient(serviceDelegate);
                serviceDelegate.DoUpdate();

            }
        }
    }
}

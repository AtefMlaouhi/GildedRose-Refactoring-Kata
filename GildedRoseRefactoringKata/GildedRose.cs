using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace GildedRoseRefactoringKata
{
    public enum Product {
        [Description("Aged Brie")]
        Aged_Brie,
        [Description("Backstage Passes")]
        Backstage_Passes,
        [Description("Sulfuras")]
        Sulfuras
    }

    public class GildedRose
    {
        IList<Item> Items;
        private string[] _products;
        public IList<Product> Products;
        public IList<Type> TypeServices;

        public GildedRose()
        {
        }

        public void SetItems(IList<Item> items)
        {
            this.Items = items;
        }

        public void UpdateQuality()
        {
            ServiceDelegate serviceDelegate = new ServiceDelegate();
            UpdateQualityClient client = new UpdateQualityClient();

            this._products = Products.Select(x => { return x.GetDescription(); }).ToArray();

            for (var i = 0; i < Items.Count; i++)
            {
                serviceDelegate.SetItem(Items[i]);

                serviceDelegate.SetServiceType(this.TypeServices[this.GetIndex(Items[i].Name)]);

                client.SetUpdateQualityClient(serviceDelegate);
                serviceDelegate.DoUpdate();
            }
        }

        private int GetIndex(string nameProduct)
        {
            int index = Array.IndexOf(this._products, this._products.Where(name => nameProduct.ToLower().Contains(name.ToLower())).FirstOrDefault());
            return index == -1 ? 0 : index + 1;
        }
    }
}

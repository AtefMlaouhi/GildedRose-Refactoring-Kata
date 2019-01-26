using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseRefactoringKata
{
    public class BackstagePassesProductService : ProductService, IUpdateQualityServices
    {
        public static Type ServicesType => typeof(BackstagePassesProductService);

        public BackstagePassesProductService(Item product)
        {
            this.Product = product;
        }

        public override void UpdateProductQuality()
        {
            if (Product.Quality < 50)
            {
                this.SetQuality(1);
            }
            if (Product.SellIn < 11)
            {
                if (Product.Quality < 50)
                {
                    this.SetQuality(1);
                }
            }

            if (Product.SellIn < 6)
            {
                if (Product.Quality < 50)
                {
                    this.SetQuality(1);
                }
            }

            this.DecreaseSellIn(-1);

            if (Product.SellIn < 0)
            {
                Product.Quality = 0;
            }
        }
    }
}

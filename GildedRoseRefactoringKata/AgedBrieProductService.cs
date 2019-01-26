using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseRefactoringKata
{
    public class AgedBrieProductService : ProductService, IUpdateQualityServices
    {
        public static Type ServicesType => typeof(AgedBrieProductService);

        public AgedBrieProductService(Item product)
        {
            this.Product = product;
        }

        public void UpdateProductQuality()
        {
            this.DecreaseSellIn(-1);
            if (Product.Quality < 50)
            {
                this.SetQuality(1);
            }
            if (Product.SellIn < 0)
            {
                if (Product.Quality < 50)
                {
                    this.SetQuality(1);
                }
            }
        }
    }
}

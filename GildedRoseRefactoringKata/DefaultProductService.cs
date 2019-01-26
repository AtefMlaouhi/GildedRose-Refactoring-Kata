using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseRefactoringKata
{
    public class DefaultProductService : ProductService, IUpdateQualityServices
    {
        public static Type ServicesType => typeof(DefaultProductService);

        public DefaultProductService(Item product)
        {
            this.Product = product;
        }

        public override void UpdateProductQuality()
        {
            if (this.Product.Quality > 0)
            {
                this.SetQuality(-1);
            }

            this.DecreaseSellIn(-1);

            if (this.Product.SellIn < 0)
            {
                if (this.Product.Quality > 0)
                {

                    this.SetQuality(-1);
                }
            }
        }
    }
}

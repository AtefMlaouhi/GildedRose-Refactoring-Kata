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

        public BackstagePassesProductService(Item product) : base(product)
        {
        }

        public override void UpdateProductQuality()
        {
            SetQualityBasedOnQualityLevel(50, 1, SignSet.inf);

            SetQualityBasedOnSellIn(11, 50, 1, SignSet.inf);
            SetQualityBasedOnSellIn(6, 50, 1, SignSet.inf);

            base.UpdateProductQuality();

            SetQualityBasedOnSellIn(0, Product.Quality, -Product.Quality, SignSet.sup, true);
        }
    }
}

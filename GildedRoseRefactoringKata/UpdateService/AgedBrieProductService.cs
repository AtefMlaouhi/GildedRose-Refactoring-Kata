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

        public AgedBrieProductService(Item product) : base(product)
        {
        }


        public override void UpdateProductQuality()
        {
            base.UpdateProductQuality();
            SetQualityBasedOnQualityLevel(50, 1, SignSet.inf);
            SetQualityBasedOnSellIn(0, 50, 1, SignSet.inf);
        }
    }
}

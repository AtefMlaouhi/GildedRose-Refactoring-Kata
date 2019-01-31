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

        public DefaultProductService(Item product) : base(product)
        {
        }

        public override void UpdateProductQuality()
        {
            SetQualityBasedOnQualityLevel(0, -1, SignSet.sup);
            base.UpdateProductQuality();
            SetQualityBasedOnSellIn(0, 0, -1, SignSet.sup);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseRefactoringKata
{
    public class SulfurasProductService : ProductService, IUpdateQualityServices
    {
        public static Type ServicesType => typeof(SulfurasProductService);

        public SulfurasProductService(Item product)
        {
            this.Product = product;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseRefactoringKata
{
    public abstract class ProductService
    {
        public Item Product { get; set; }


        public virtual void UpdateProductQuality() { }

        protected void DecreaseSellIn(int value)
        {
            Product.SellIn += value;
        }

        protected void SetQuality(int value)
        {
            Product.Quality += value;
        }
    }
}

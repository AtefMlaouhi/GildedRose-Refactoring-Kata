using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseRefactoringKata
{
    public enum SignSet
    {
        sup,
        inf
    }

    public abstract class ProductService
    {
        public Item Product { get; set; }

        public ProductService(Item product)
        {
            this.Product = product;
        }

        public virtual void UpdateProductQuality()
        {
            this.DecreaseSellIn(-1);
        }

        protected void DecreaseSellIn(int value)
        {
            Product.SellIn += value;
        }

        protected void SetQuality(int value)
        {
            Product.Quality += value;
        }

        protected void SetQualityBasedOnSellIn(int SelInResidual, int QualityLevel, int QualityDelta, SignSet signSet, bool withoutQualityChek = false)
        {
            if (this.Product.SellIn < SelInResidual && !withoutQualityChek)
            {
                this.SetQualityBasedOnQualityLevel(QualityLevel, QualityDelta, signSet);
            }

            if(withoutQualityChek)
            {
                if (Product.SellIn < SelInResidual)
                {
                    this.SetQuality(QualityDelta);
                }
            }
        }

        protected void SetQualityBasedOnQualityLevel(int QualityLevel, int QualityDelta, SignSet signSet )
        {

            switch(signSet)
            {
                case SignSet.inf:
                    {
                        if (Product.Quality < QualityLevel)
                        {
                            this.SetQuality(QualityDelta);
                        }
                        break;
                    }
                case SignSet.sup:
                    {
                        if (Product.Quality > QualityLevel)
                        {
                            this.SetQuality(QualityDelta);
                        }
                        break;
                    }
            }
        }
    }
}

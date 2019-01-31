using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace GildedRoseRefactoringKata
{
    [TestFixture]
    public abstract class GildedRoseBaseTests
    {
        protected GildedRose app;

        [SetUp]
        public void SetContext()
        {
            this.app = new GildedRose()
            {
                Products = new List<Product>() { Product.Aged_Brie, Product.Backstage_Passes, Product.Sulfuras },
                TypeServices = new List<Type>() { DefaultProductService.ServicesType, AgedBrieProductService.ServicesType, BackstagePassesProductService.ServicesType, SulfurasProductService.ServicesType }
            };

        }

        [TearDown]
        public void ClearContext()
        {
            this.app = null;
        }
    }
}

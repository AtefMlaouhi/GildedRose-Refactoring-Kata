using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace GildedRoseRefactoringKata
{
    public class Sulfuras_UpdateQuality_Tests : GildedRoseBaseTests
    {
        [Test, Description("Sulfuras")]
        public void When_UpdateQuality_Is_Called_Sulfuras_Quality_Should_Be_Never_Alters()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 } };
            app.SetItems(Items);
            app.UpdateQuality();
            Assert.AreEqual(Items[0].Quality, 80);
            app.UpdateQuality();
            Assert.AreEqual(Items[0].Quality, 80);
        }
    }
}

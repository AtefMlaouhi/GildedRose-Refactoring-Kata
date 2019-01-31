using NUnit.Framework;
using System;
using System.Collections.Generic;
using FluentAssertions;

namespace GildedRoseRefactoringKata
{
    public class BackstagePassesUpdateQualityTests : GildedRoseBaseTests
    {
        [Test, Description("Backstage passes")]
        public void Backstage_Passes_Quality_Should_Be_Increases_By_2_If_SellIn_Equal_10_Or_Less_When_UpdateQuality_Is_Called()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 8, Quality = 10 } };
            app.SetItems(Items);
            app.UpdateQuality();

            Assert.GreaterOrEqual(Items[0].Quality, 12);
            app.UpdateQuality();
            Assert.GreaterOrEqual(Items[0].Quality, 14);
        }

        [Test, Description("Backstage passes")]
        public void Backstage_Passes_Quality_Should_Be_Increases_By_3_If_SellIn_Equal_5_Or_Less_When_UpdateQuality_Is_Called()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 10 } };
            app.SetItems(Items);
            app.UpdateQuality();
            Assert.GreaterOrEqual(Items[0].Quality, 13);
            app.UpdateQuality();
            Assert.GreaterOrEqual(Items[0].Quality, 15);
        }

        [Test, Description("Backstage passes")]
        public void Backstage_Passes_Quality_Should_Be_Equal_0_If_SellIn_Less_than_Zero_When_UpdateQuality_Is_Called()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 1, Quality = 10 } };
            app.SetItems(Items);
            app.UpdateQuality();
            Assert.GreaterOrEqual(Items[0].Quality, 13);
            app.UpdateQuality();
            Assert.GreaterOrEqual(Items[0].Quality, 0);
        }
    }
}

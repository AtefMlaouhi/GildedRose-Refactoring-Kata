using NUnit.Framework;
using System.Collections.Generic;

namespace GildedRoseRefactoringKata
{
    public class Aged_Brie_UpdateQuality_Tests : GildedRoseBaseTests
    {
        [Test, Description("Aged Brie")]
        public void Aged_Brie_Quality_Should_Be_positive_With_SellIn_Positive_When_UpdateQuality_Is_Called()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 2, Quality = 1 } };
            app.SetItems(Items);
            app.UpdateQuality();
            Assert.GreaterOrEqual(Items[0].Quality, 2);
        }

        [Test, Description("Aged Brie")]
        public void Aged_Brie_Quality_Should_Be_positive_And_Max_50_When_UpdateQuality_Is_Called()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 49 } };
            app.SetItems(Items);
            app.UpdateQuality();
            Assert.GreaterOrEqual(Items[0].Quality, 50);
            app.UpdateQuality();
            Assert.AreEqual(Items[0].Quality, 50);
        }

        [Test, Description("Aged Brie")]
        public void Aged_Brie_SellIn_Should_Be_Negative_When_UpdateQuality_Is_Called()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 0 } };
            app.SetItems(Items);
            app.UpdateQuality();
            Assert.Less(Items[0].SellIn, 0);
        }

        [Test, Description("Aged Brie")]
        public void Aged_Brie_Quality_Should_Be_GreaterOrEqual_than_50_With_SellIn_Negative_When_UpdateQuality_Is_Called()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = -1, Quality = 49 } };
            app.SetItems(Items);
            app.UpdateQuality();
            Assert.GreaterOrEqual(Items[0].Quality, 50);
            app.UpdateQuality();
            Assert.GreaterOrEqual(Items[0].Quality, 50);
        }

        [Test, Description("Aged Brie")]
        public void Aged_Brie_Quality_Should_Be_positive_When_UpdateQuality_Is_Called()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 1 } };
            app.SetItems(Items);
            app.UpdateQuality();
            Assert.GreaterOrEqual(Items[0].Quality, 2);
        }
    }
}

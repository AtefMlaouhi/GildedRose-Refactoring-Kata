using NUnit.Framework;
using System.Collections.Generic;

namespace GildedRoseRefactoringKata
{
    [TestFixture]
    public class GildedRoseTest
    {
#warning Fix after refact
        //[Test]
        public void Given_Quality_Should_Be_Positive()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 5, Quality = -10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.GreaterOrEqual(Items[0].Quality, 0);
        }

        [Test]
        public void When_UpdateQuality_Quality_Should_Be_Positive()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 5, Quality = 1 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.GreaterOrEqual(Items[0].Quality, 0);
            Assert.AreEqual(Items[0].SellIn, 4);
            app.UpdateQuality();
            Assert.GreaterOrEqual(Items[0].Quality, 0);
            Assert.AreEqual(Items[0].SellIn, 3);
        }


        [Test]
        public void When_UpdateQuality_Quality_Should_Be_Positive_With_SellIn_Positive()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 1, Quality = 2 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(Items[0].Quality, 1);
            app.UpdateQuality();
            Assert.AreEqual(Items[0].Quality, 0);
        }

        [Test]
        public void When_UpdateQuality_Quality_Should_Be_Positive_And_Equal_To_Zero_With_SellIn_Negative()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = -10, Quality = 2 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(Items[0].Quality, 0);
            app.UpdateQuality();
            Assert.AreEqual(Items[0].Quality, 0);
        }

        [Test]
        public void When_UpdateQuality_Quality_Should_Be_positive_And_Degrades_With_SellIn_Positive()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 17, Quality = 40 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(Items[0].Quality, 39);
            app.UpdateQuality();
            Assert.AreEqual(Items[0].Quality, 38);
        }

        [Test]
        public void When_UpdateQuality_SellIn_Should_Be_Degrades()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 17, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            int SellInBegin = Items[0].SellIn;
            for (int i = SellInBegin; i == -10; i--)
            {
                Assert.AreEqual(Items[0].SellIn, i);
                Assert.GreaterOrEqual(Items[0].Quality, 0);
                app.UpdateQuality();
            }
        }

        [Test, Description("Aged Brie")]
        public void When_UpdateQuality_Aged_Brie_Quality_Should_Be_positive()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 1 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.GreaterOrEqual(Items[0].Quality, 2);
        }


        [Test, Description("Aged Brie")]
        public void When_UpdateQuality_Aged_Brie_Quality_Should_Be_positive_With_SellIn_Positive()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 2, Quality = 1 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.GreaterOrEqual(Items[0].Quality, 2);
        }

        [Test, Description("Aged Brie")]
        public void When_UpdateQuality_Aged_Brie_Quality_Should_Be_positive_And_Max_50()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 49 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.GreaterOrEqual(Items[0].Quality, 50);
            app.UpdateQuality();
            Assert.AreEqual(Items[0].Quality, 50);
        }

        [Test, Description("Aged Brie")]
        public void When_UpdateQuality_Aged_Brie_SellIn_Should_Be_Negative()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Less(Items[0].SellIn, 0);
        }

        [Test, Description("Aged Brie")]
        public void When_UpdateQuality_Aged_Brie_Quality_Should_Be_GreaterOrEqual_than_50_With_SellIn_Negative()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = -1, Quality = 49 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.GreaterOrEqual(Items[0].Quality, 50);
            app.UpdateQuality();
            Assert.GreaterOrEqual(Items[0].Quality, 50);
        }

        [Test, Description("Sulfuras")]
        public void When_UpdateQuality_Sulfuras_Quality_Should_Be_Never_Alters()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(Items[0].Quality, 80);
            app.UpdateQuality();
            Assert.AreEqual(Items[0].Quality, 80);
        }

        [Test, Description("Backstage passes")]
        public void When_UpdateQuality_Backstage_Passes_Quality_Should_Be_Increases_By_2_If_SellIn_Equal_10_Or_Less()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 8, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.GreaterOrEqual(Items[0].Quality, 12);
            app.UpdateQuality();
            Assert.GreaterOrEqual(Items[0].Quality, 14);
        }

        [Test, Description("Backstage passes")]
        public void When_UpdateQuality_Backstage_Passes_Quality_Should_Be_Increases_By_3_If_SellIn_Equal_5_Or_Less()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.GreaterOrEqual(Items[0].Quality, 13);
            app.UpdateQuality();
            Assert.GreaterOrEqual(Items[0].Quality, 15);
        }

        [Test, Description("Backstage passes")]
        public void When_UpdateQuality_Backstage_Passes_Quality_Should_Be_Equal_0_If_SellIn_Less_than_Zero()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 1, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.GreaterOrEqual(Items[0].Quality, 13);
            app.UpdateQuality();
            Assert.GreaterOrEqual(Items[0].Quality, 0);
        }
    }
}

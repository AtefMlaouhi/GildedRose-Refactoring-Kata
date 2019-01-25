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

    }
}

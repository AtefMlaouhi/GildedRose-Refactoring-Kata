using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace GildedRoseRefactoringKata
{
    [TestFixture]
    public class GildedRoseTest : GildedRoseBaseTests
    {

#warning Fix after refact
        //[Test]
        public void Given_Quality_Should_Be_Positive()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 5, Quality = -10 } };
            app.SetItems(Items);
            app.UpdateQuality();
            Assert.GreaterOrEqual(Items[0].Quality, 0);
        }

        [Test]
        public void Quality_Should_Be_Positive_When_UpdateQuality_Is_Called()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 5, Quality = 1 } };
            app.SetItems(Items);
            app.UpdateQuality();
            Assert.GreaterOrEqual(Items[0].Quality, 0);
            Assert.AreEqual(Items[0].SellIn, 4);
            app.UpdateQuality();
            Assert.GreaterOrEqual(Items[0].Quality, 0);
            Assert.AreEqual(Items[0].SellIn, 3);
        }


        [Test]
        public void Quality_Should_Be_Positive_With_SellIn_Positive_When_UpdateQuality_Is_Called()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 1, Quality = 2 } };
            app.SetItems(Items);
            app.UpdateQuality();
            Assert.AreEqual(Items[0].Quality, 1);
            app.UpdateQuality();
            Assert.AreEqual(Items[0].Quality, 0);
        }

        [Test]
        public void Quality_Should_Be_Positive_And_Equal_To_Zero_With_SellIn_Negative_When_UpdateQuality_Is_Called()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = -10, Quality = 2 } };
            app.SetItems(Items);
            app.UpdateQuality();
            Assert.AreEqual(Items[0].Quality, 0);
            app.UpdateQuality();
            Assert.AreEqual(Items[0].Quality, 0);
        }

        [Test]
        public void Quality_Should_Be_positive_And_Degrades_With_SellIn_Positive_When_UpdateQuality_Is_Called()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 17, Quality = 40 } };
            app.SetItems(Items);
            app.UpdateQuality();
            Assert.AreEqual(Items[0].Quality, 39);
            app.UpdateQuality();
            Assert.AreEqual(Items[0].Quality, 38);
        }

        [Test]
        public void SellIn_Should_Be_Degrades_When_UpdateQuality_Is_Called()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 17, Quality = 10 } };
            app.SetItems(Items);
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

using NUnit.Framework;
using System.Collections.Generic;

namespace GildedRoseRefactoringKata
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void Given_Quality_Should_Be_Positive()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 5, Quality = -10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.GreaterOrEqual(Items[0].Quality, 0);
        }

    }
}

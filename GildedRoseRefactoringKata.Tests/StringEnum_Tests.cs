using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;
using FluentAssertions;

namespace GildedRoseRefactoringKata.Tests
{
    [TestFixture]
    public class StringEnumTests
    {

        [Test]
        public void Should_Return_String_When_GetDescription_Is_Called()
        {
            var items = new[] { Product.Aged_Brie, Product.Backstage_Passes, Product.Sulfuras };
            var itemsResult = new List<string>();
            items.ToList().ForEach(x => itemsResult.Add(x.GetDescription()));
            itemsResult.Should().BeOfType(typeof(List<string>)).And.Equal(new List<string>() { "Aged Brie", "Backstage Passes", "Sulfuras" });
        }

        [Test]
        public void Should_Return_Emplty_String_When_GetDescription_Is_Called_With_Object_Not_Enum()
        {
            "This is a Test".GetDescription().Should().BeOfType<string>().And.Equals(string.Empty);
        }
    }
}

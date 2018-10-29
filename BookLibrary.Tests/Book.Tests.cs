using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BookLibrary.Tests
{
    [TestFixture]
    public class BookTests
    {
        Book book = new Book("C# in Depth", "Jon Skeet", "2019", "Manning", "4", "900", "40$");

        [TestCase("G", ExpectedResult = "Book record: Jon Skeet, C# in Depth")]
        [TestCase("short", ExpectedResult = "Book record: C# in Depth")]
        [TestCase("long", ExpectedResult = "Book record: Jon Skeet, C# in Depth, 2019, 'Manning'")]
        [TestCase("year", ExpectedResult = "Book record: Jon Skeet, C# in Depth, 2019")]
        [TestCase("publish", ExpectedResult = "Book record: C# in Depth, 2019, 'Manning'")]
        [TestCase("price", ExpectedResult = "Book record: Jon Skeet, C# in Depth, 40$")]
        [TestCase("pages", ExpectedResult = "Book record: Jon Skeet, C# in Depth, 900")]
        [TestCase("edition", ExpectedResult = "Book record: Jon Skeet, C# in Depth, 4")]
        public string FormatTest(string format)
            => String.Format(CultureInfo.CurrentCulture, "{0:" + format + "}", book);

        [Test]
        public void FormatTest_WithException()
        {
            Assert.Throws<FormatException>(() => String.Format(CultureInfo.CurrentCulture, "{0:e}", book));
        }
    }
}

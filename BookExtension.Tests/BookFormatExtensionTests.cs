using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLibrary;
using NUnit.Framework;

namespace BookExtension.Tests
{
    [TestFixture]
    public class BookFormatExtensionTests
    {
        Book book = new Book("C# in Depth", "Jon Skeet", "2019", "Manning", "4", "900", "40$");
        private IFormatProvider fp = new BookFormatExtension();

        [TestCase("good", ExpectedResult = "Book record: C# in Depth is a very good book")]
        public string FormatExtensionTest(string format)
            => String.Format(fp, "{0:" + format + "}", book);

        [Test]
        public void FormatExtensionTest_WithException()
        {
            Assert.Throws<FormatException>(() => String.Format(CultureInfo.CurrentCulture, "{0:e}", book));
        }
    }
}

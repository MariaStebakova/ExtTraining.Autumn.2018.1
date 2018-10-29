using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class Book: IFormattable
    {
        private string Title;
        private string Author;
        private string Year;
        private string PublishingHous;
        private string Edition;
        private string Pages;
        private string Price;

        public Book(string title, string author, string year, string publishingHous, string edition, string pages,
            string price)
        {
            Title = title;
            Author = author;
            Year = year;
            PublishingHous = publishingHous;
            Edition = edition;
            Pages = pages;
            Price = price;
        }

        public override string ToString()
        {
            return ToString("G", CultureInfo.CurrentCulture);
        }

        public string ToString(string format)
        {
            return ToString(format, CultureInfo.CurrentCulture);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (String.IsNullOrEmpty(format))
                format = "G";
            if (formatProvider == null)
                formatProvider = CultureInfo.CurrentCulture;

            switch (format.ToUpperInvariant())
            {
                case "G":
                    return $"Book record: {Author}, {Title}";
                case "SHORT":
                    return $"Book record: {Title}";
                case "LONG":
                    return $"Book record: {Author}, {Title}, {Year}, '{PublishingHous}'";
                case "YEAR":
                    return $"Book record: {Author}, {Title}, {Year}";
                case "PUBLISH":
                    return $"Book record: {Title}, {Year}, '{PublishingHous}'";
                case "PRICE":
                    return $"Book record: {Author}, {Title}, {Price}";
                case "PAGES":
                    return $"Book record: {Author}, {Title}, {Pages}";
                case "EDITION":
                    return $"Book record: {Author}, {Title}, {Edition}";
                default:
                    throw new FormatException(String.Format("The {0} format string is not supported.", format));
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class Book: IFormattable, IComparable, IEquatable<Book>
    {
        public string Title { get; }
        public string Author { get; }
        public int Year { get; }
        public string PublishingHous { get; }
        public int Edition { get; }
        public int Pages { get; }
        public decimal Price { get; }

        public Book(string title, string author, int year, string publishingHous, int edition, int pages,
            decimal price)
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
                    return $"{Author}, {Title}";
                case "SHORT":
                    return $"{Title}";
                case "LONG":
                    return $"{Author}, {Title}, {Year}, '{PublishingHous}'";
                case "YEAR":
                    return $"{Author}, {Title}, {Year}";
                case "PUBLISH":
                    return $"{Title}, {Year}, '{PublishingHous}'";
                case "PRICE":
                    return $"{Author}, {Title}, {Price.ToString("C", formatProvider)}";
                case "PAGES":
                    return $"{Author}, {Title}, {Pages}";
                case "EDITION":
                    return $"{Author}, {Title}, {Edition}";
                default:
                    throw new FormatException(String.Format("The {0} format string is not supported.", format));
            }
        }

        int IComparable.CompareTo(object obj) => CompareTo((Book) obj);
        
        public int CompareTo(Book other)
        {
            if (this.Equals(other))
                return 0;

            if (other.Price > Price)
                return 1;

            return -1;
        }

        public bool Equals(Book other)
        {
            if (ReferenceEquals(other, this))
                return true;

            if (other == null)
                return false;

            if (other.Title == Title && other.Author == Author && other.Year == Year &&
                other.PublishingHous == PublishingHous
                && other.Edition == Edition && other.Pages == Pages && other.Price == Price)
                return true;

            return false;
        }
    }
}

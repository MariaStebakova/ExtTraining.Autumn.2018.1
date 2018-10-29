using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLibrary;

namespace BookExtension
{
    public class BookFormatExtension : IFormatProvider, ICustomFormatter
    {
        //allows users to chain format provider
        private IFormatProvider parent;

        public BookFormatExtension() : this(CultureInfo.CurrentCulture) { }

        public BookFormatExtension(IFormatProvider parent)
        {
            this.parent = parent;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg.GetType() != typeof(Book))
            {
                try
                {
                    return HandleOtherFormats(format, arg);
                }
                catch (FormatException e)
                {
                    throw new FormatException($"The format of '{format}' is invalid.");
                }
            }

            if (string.IsNullOrWhiteSpace(format) || format.ToUpper(CultureInfo.InvariantCulture) != "GOOD")
            {
                try
                {
                    return HandleOtherFormats(format, arg);
                }
                catch (FormatException e)
                {
                    throw new FormatException($"The format of '{format}' is invalid.");
                }
            }

            string originalString = String.Format(parent, "{0:short}", arg);

            return originalString + " is a very good book";
        }

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            
            return null;
        }

        private string HandleOtherFormats(string format, object arg)
        {
            if (arg is IFormattable)
            {
                return ((IFormattable)arg).ToString(format, CultureInfo.CurrentCulture);
            }
            else if (arg != null)
            {
                return arg.ToString();
            }
            else
            {
                return String.Empty;
            }

        }
    }
}

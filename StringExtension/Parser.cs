using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringExtension
{
    public static class Parser
    {
        public static int ToDecimal(this string source, int @base)
        {
            if (String.IsNullOrEmpty(source))
                throw new ArgumentNullException($"{nameof(source)} can't be equal to null or empty");

            if (@base < 2 || @base > 16)
                throw new ArgumentOutOfRangeException($"{nameof(@base)} must be in range of 2 till 16");


            return ToDecimalValue(source, @base);
        }

        private static int ToDecimalValue(string source, int notation)
        {
            int result = 0;

            source = source.ToUpperInvariant();
            string alphabet = "0123456789ABCDEF";
            try
            {
                foreach (var d in source)
                {
                    int value = alphabet.IndexOf(d);

                    if (value > notation - 1 || value < 0)
                    {
                        throw new ArgumentException($"The {d} is not used in {nameof(notation)} notation.");
                    }

                    int i;

                    if (d < '0' || d > '9')
                        i = d - 'A' + 10;
                    else
                        i = d - '0';

                    result = checked (result * notation + i);
                }
            }
            catch (OverflowException e)
            {
                throw new ArgumentException();
            }

            return result; 
        }


    }
}

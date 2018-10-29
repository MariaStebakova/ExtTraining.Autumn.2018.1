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
            if (source == null)
                throw new ArgumentNullException($"{nameof(source)} can't be equal to null");

            if (@base < 2 || @base > 16)
                throw new ArgumentOutOfRangeException($"{nameof(@base)} must be in range of 2 till 16");

            if (@base == 10)
                return Int32.Parse(source);

            if (source.Length >= sizeof(int)*8)
                throw new ArgumentException($"Too big {nameof(source)}");

            char[] digits = { '0', '1', '2', '3', '4', '5', '6', '7', '8' };
            foreach (var d in source)
            {
                if (@base < 9 && char.IsLetter(d))
                    throw new ArgumentException($"{nameof(source)} is unappropriate string for the base of {nameof(@base)}");

                for (int i = 1; i <= 8; i++)
                    if (@base == i + 1 && d > digits[i])
                        throw new ArgumentException($"{nameof(source)} is unappropriate string for the base of {nameof(@base)}");
            }

            int result = ToDecimalValue(source, @base);

            if (result == -1)
                throw new ArgumentException($"Too big {nameof(source)}");

            return result;
        }

        private static int ToDecimalValue(string source, int notation)
        {
            int result = 0;

            try
            {
                checked
                {
                    foreach (var d in source)
                    {
                        int i;

                        if (d < '0' || d > '9')
                            i = char.ToUpper(d) - 'A' + 10;
                        else
                            i = d - '0';

                        result = result * notation + i;
                    }
                }
                
            }
            catch (OverflowException e)
            {
                return -1;
            }
            

            return result;
        }


    }
}

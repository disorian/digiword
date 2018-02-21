using DigiWord.Business.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiWord.Business.Extensions
{
    /// <summary>
    /// Extention methods
    /// </summary>
    public static class NumberConverterExtension
    {
        /// <summary>
        /// Extends System.UInt64 and returns the textual representation of its value
        /// </summary>
        /// <param name="number">The number to be converted to text</param>
        /// <returns>A steing holds the textual representation of the given number</returns>
        public static string ToText(this ulong number)
        {
            NumberConverter converter = new NumberConverter();

            string convertedNumber = converter.Convert(number);

            return convertedNumber;
        }
    }
}

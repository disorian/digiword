using DigiWord.Business.Extensions;
using DigiWord.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Math;

namespace DigiWord.Business
{
    /// <summary>
    /// Converter component
    /// </summary>
    public class ConverterComponent
    {
        /// <summary>
        /// Processes a number detail and converts the number to its textual representation
        /// </summary>
        /// <param name="numberDetail"></param>
        /// <returns></returns>
        public NumberDetail ProccesNumber(NumberDetail numberDetail)
        {
            if (numberDetail.Number < 0)
                throw new ArgumentException("The number should be positive.");

            ulong integer = (ulong)Truncate(numberDetail.Number); // extracts the integer part of the numebr
            ulong decimals = (ulong)((numberDetail.Number - integer) * 100); // extracts the decimals of the number and converts it to integer

            // generates a text for the response
            // format: [integer] dollar(s) and [decimals] cent(s)
            numberDetail.ConvertedNumber =
                ($"{integer.ToText()} dollar{(integer > 1 ? "s" : "")}" +
                 $"{(decimals > 0 ? $" and {decimals.ToText()} cent{(decimals > 1 ? "s" : "")}" : "")}");

            return numberDetail;
        }
    }
}

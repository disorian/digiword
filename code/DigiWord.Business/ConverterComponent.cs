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
        public NumberDetail ProccesNumber(NumberDetail numberDetail)
        {
            ulong integer = (ulong)Truncate(numberDetail.Number); // extracts the integer part of the numebr
            ulong decimals = (ulong)((numberDetail.Number - integer) * 100); // extracts the decimals of the number and converts it to integer

            numberDetail.ConvertedNumber =
                ($"{integer.ToText()} dollar{(integer > 1 ? "s" : "")}" +
                 $"{(decimals > 0 ? $" and {decimals.ToText()} cent{(decimals > 1 ? "s" : "")}" : "")}");

            return numberDetail;
        }
    }
}

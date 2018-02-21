using DigiWord.Business.Common;
using NUnit.Framework;
using System;

namespace DigiWord.Business.Test
{
    [TestFixture]
    public class NumberConverterTest
    {
        [TestCase(0ul, "zero")]
        [TestCase(1ul, "one")]
        [TestCase(10ul, "ten" )]
        [TestCase(12ul, "twelve")]
        [TestCase(100ul, "one hundred")]
        [TestCase(101ul, "one hundred and one")]
        [TestCase(301ul, "three hundred and one")]
        [TestCase(1_890ul, "one thousand and eight hundred and ninety")]
        [TestCase(100_001ul, "one hundred thousand and one")]
        [TestCase(101_001_101ul, "one hundred and one million and one thousand and one hundred and one")]
        [TestCase(999_999_999ul, "nine hundred and ninety-nine million and nine hundred and ninety-nine thousand and nine hundred and ninety-nine")]
        [TestCase(100_000_000_001ul, "one hundred billion and one")]
        [TestCase(1_928_374_655ul, "one billion and nine hundred and twenty-eight million and three hundred and seventy-four thousand and six hundred and fifty-five")]
        [TestCase(12_124_128_782ul, "twelve billion and one hundred and twenty-four million and one hundred and twenty-eight thousand and seven hundred and eighty-two")]
        [TestCase(18_446_744_073_709_551_615ul, "eighteen quintillion and four hundred and forty-six quadrillion and seven hundred and forty-four trillion and seventy-three billion and seven hundred and nine million and five hundred and fifty-one thousand and six hundred and fifteen")]
        public void ConvertTest(ulong number, string expected)
        {
            var bc = new NumberConverter();

            var actual = bc.Convert(number);

            TestContext.Out.WriteLine($"{number} : {actual}");

            Assert.AreEqual(expected, actual);
        }

        [TestCase(0, "")]
        [TestCase(1, "one")]
        [TestCase(12, "twelve")]
        [TestCase(25, "twenty-five")]
        [TestCase(201, "two hundred and one")]
        [TestCase(112, "one hundred and twelve")]
        [TestCase(465, "four hundred and sixty-five")]
        public void ConvertGroupTest(int number, string expected)
        {
            var bc = new ConverterWrapper();

            var actual = bc.ConvertGroupWrapper(number);

            TestContext.Out.WriteLine($"{number} : {actual}");

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1000)]
        [TestCase(-1)]
        public void ConvertGroupTest_InvalidGroupNumber_ThrowArgumentException(int number)
        {
            var bc = new ConverterWrapper();

            var exception = Assert.Throws<ArgumentException>(() => bc.ConvertGroupWrapper(number));
            Assert.AreEqual("A group should be positive and it cannot be more than 999", exception.Message);
        }
    }

    public class ConverterWrapper : NumberConverter
    {
        public string ConvertGroupWrapper(int number) => base.ConvertGroup(number);
    }
}

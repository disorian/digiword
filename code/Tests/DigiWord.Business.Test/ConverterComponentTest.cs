using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigiWord.Entities;
using NUnit;
using NUnit.Framework;

namespace DigiWord.Business.Test
{
    [TestFixture]
    public class ConverterComponentTest
    {
        [TestCase(1, "one dollar")]
        [TestCase(12, "twelve dollars")]
        [TestCase(1.01, "one dollar and one cent")]
        [TestCase(25.20, "twenty-five dollars and twenty cents")]
        [TestCase(1_000_000_001.11, "one billion and one dollars and eleven cents")]
        [TestCase(123.43, "one hundred and twenty-three dollars and forty-three cents")]
        public void ProccesNumberTest(decimal number, string expected)
        {
            var numberDetail = new NumberDetail
            {
                Name = "Behnam Karimi",
                Number = number
            };

            var bc = new ConverterComponent();
            var result = bc.ProccesNumber(numberDetail);

            TestContext.Out.WriteLine(numberDetail.ToString());

            Assert.AreNotEqual(numberDetail.Id, Guid.Empty);
            Assert.AreEqual(numberDetail.DateCreated.Date, DateTime.UtcNow.Date);
            Assert.IsFalse(string.IsNullOrWhiteSpace(numberDetail.ConvertedNumber));
            Assert.IsFalse(string.IsNullOrWhiteSpace(numberDetail.Name));
            Assert.AreEqual(expected, numberDetail.ConvertedNumber);
        }

        [Test]
        public void ProcessNumber_NegativeNumber_ReturnException()
        {
            var numberDetail = new NumberDetail
            {
                Name = "Behnam Karimi",
                Number = -100.12m
            };

            var bc = new ConverterComponent();

            var exception = Assert.Throws<ArgumentException>(() => bc.ProccesNumber(numberDetail));
            Assert.AreEqual("The number should be positive.", exception.Message);
        }
    }
}

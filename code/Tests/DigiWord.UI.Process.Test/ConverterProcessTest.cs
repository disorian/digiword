using DigiWord.UI.Process.ViewModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiWord.UI.Process.Test
{
    [TestFixture]
    public class ConverterProcessTest
    {
        [Test]
        public void ConvertNumebrDetailTest()
        {
            var process = new ConverterProcess();
            var detail = new NumberDetailViewModel
            {
                Name = "Behnam Karimi",
                Number = 101.11m
            };

            var result = process.ConvertNumebrDetail(detail);

            TestContext.Out.WriteLine(result.ToString());

            Assert.IsNotNull(result);
            Assert.AreEqual(detail.Name, result.Name);
            Assert.AreEqual(detail.Number, result.Number);
            Assert.AreEqual("one hundred and one dollars and eleven cents", result.ConvertedNumber);
            Assert.AreEqual(DateTime.UtcNow.Date, result.DateCreated.Date);
            Assert.AreNotEqual(Guid.Empty, result.Id);
        }

        [Test]
        public void ConvertNumebrDetail_NegativeValue_ShoudReturnException()
        {
            var process = new ConverterProcess();
            var detail = new NumberDetailViewModel
            {
                Name = "Behnam Karimi",
                Number = -101.11m
            };

            Assert.Throws<ApplicationException>(() => process.ConvertNumebrDetail(detail));
        }
    }
}

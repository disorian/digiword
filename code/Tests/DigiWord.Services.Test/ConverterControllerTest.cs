using DigiWord.Entities;
using DigiWord.Services.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace DigiWord.Services.Test
{
    [TestFixture]
    public class ConverterControllerTest
    {
        private ConverterController _converterController;

        [SetUp]
        public void Init()
        {
            AutoMapperConfiguration.RegisterMapping();

            _converterController = new ConverterController();

            // setup service with default request and configuration
            _converterController.Request = new HttpRequestMessage();
            _converterController.Request.SetConfiguration(new HttpConfiguration());
        }

        [Test]
        public void ConvertServiceTest()
        {
            var numberDetali = new NumberDetailRequest
            {
                Name = "Behnam karimi",
                Number = 3324.39m
            };

            var result = _converterController.Convert(numberDetali) as HttpResponseMessage;

            result.EnsureSuccessStatusCode();

            var resultContent = result.Content.ReadAsAsync<NumberDetail>().GetAwaiter().GetResult();

            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.IsNotNull(resultContent);
            Assert.AreEqual(numberDetali.Name, resultContent.Name);
            Assert.AreEqual(numberDetali.Number, resultContent.Number);
            Assert.AreEqual("three thousand and three hundred and twenty-four dollars and thirty-nine cents", resultContent.ConvertedNumber);
            Assert.AreEqual(DateTime.UtcNow.Date, resultContent.DateCreated.Date);
            Assert.AreNotEqual(Guid.Empty, resultContent.Id);
        }
    }
}

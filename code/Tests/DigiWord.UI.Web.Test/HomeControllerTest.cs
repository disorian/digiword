using DigiWord.Entities;
using DigiWord.UI.Process.ViewModels;
using DigiWord.UI.Web.Controllers;
using NUnit.Framework;
using System;
using System.Linq;
using System.Web.Mvc;

namespace DigiWord.UI.Web.Test
{
    [TestFixture]
    public class HomeControllerTest
    {
        [Test]
        public void IndexGetTest()
        {
            var controller = new HomeController();

            var result = controller.Index() as ViewResult;

            Assert.AreEqual("Index", result.ViewName);
        }

        [Test]
        public void AboutGetTest()
        {
            var controller = new HomeController();

            var result = controller.About() as ViewResult;

            Assert.AreEqual("About", result.ViewName);
        }

        [Test]
        public void IndexPostTest()
        {
            var controller = new HomeController();
            var detail = new NumberDetailViewModel
            {
                Name = "Behnam",
                Number = 201.10m
            };

            var view = controller.Index(detail) as ViewResult;
            var result = (NumberDetail)view.ViewData.Model;

            TestContext.Out.WriteLine(result.ToString());

            Assert.AreEqual("Result", view.ViewName);
            Assert.IsNotNull(result);
            Assert.AreEqual(detail.Name, result.Name);
            Assert.AreEqual(detail.Number, result.Number);
            Assert.AreEqual("two hundred and one dollars and ten cents", result.ConvertedNumber);
            Assert.AreEqual(DateTime.UtcNow.Date, result.DateCreated.Date);
            Assert.AreNotEqual(Guid.Empty, result.Id);
        }

        [Test]
        public void IndexPost_NegativeNumber_ErrorReturns()
        {
            var controller = new HomeController();
            var detail = new NumberDetailViewModel
            {
                Name = "Behnam",
                Number = -201.10m
            };

            var view = controller.Index(detail) as ViewResult;

            Assert.AreEqual("Index", view.ViewName);
            Assert.True(view.ViewData.ModelState.Keys.Contains("Number"));
            Assert.AreEqual("Unable to process the request.", view.ViewData.ModelState["Number"].Errors[0].ErrorMessage);

        }
    }
}

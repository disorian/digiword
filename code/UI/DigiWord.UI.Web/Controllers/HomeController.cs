using DigiWord.Entities;
using DigiWord.UI.Process;
using DigiWord.UI.Process.ViewModels;
using System;
using System.Web.Mvc;

namespace DigiWord.UI.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        public ActionResult Index(NumberDetailViewModel numberDetailViewModel)
        {
            try
            {
                ConverterProcess process = new ConverterProcess();

                NumberDetail result = process.ConvertNumebrDetail(numberDetailViewModel);

                return View("Result", result);
            }
            catch(Exception)
            {
                return View();
            }
        }

        public ActionResult About()
        {
            return View("About");
        }
        
    }
}
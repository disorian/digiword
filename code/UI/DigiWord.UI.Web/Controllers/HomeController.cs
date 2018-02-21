using DigiWord.Entities;
using DigiWord.UI.Process;
using DigiWord.UI.Process.ViewModels;
using System;
using System.Web.Mvc;

namespace DigiWord.UI.Web.Controllers
{
    /// <summary>
    /// Home controller which is the entry point for the UI
    /// </summary>
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

                // calls UI process to converts the number
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
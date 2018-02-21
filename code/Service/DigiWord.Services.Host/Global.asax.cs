using DigiWord.Services.Configurations;
using System.Web.Http;

namespace DigiWord.Services.Host
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutoMapperConfiguration.RegisterMapping();
        }
    }
}

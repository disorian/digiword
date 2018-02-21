using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DigiWord.UI.Process
{
    public class ProcessComponent
    {
        protected static void ConfigureHttpClient(HttpClient client)
        {
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["serviceUrl"]);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}

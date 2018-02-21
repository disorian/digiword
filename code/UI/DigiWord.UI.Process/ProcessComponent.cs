using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;

namespace DigiWord.UI.Process
{
    /// <summary>
    /// Process base class use to configure common configurations on request headers, etc.
    /// </summary>
    public class ProcessComponent
    {
        /// <summary>
        /// Configures HttpClient properties
        /// </summary>
        /// <param name="client">An HttpClient object</param>
        protected static void ConfigureHttpClient(HttpClient client)
        {
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["serviceUrl"]);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}

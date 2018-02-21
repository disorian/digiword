using DigiWord.Entities;
using DigiWord.UI.Process.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;

namespace DigiWord.UI.Process
{
    public class ConverterProcess : ProcessComponent
    {
        public NumberDetail ConvertNumebrDetail(NumberDetailViewModel detail)
        {
            NumberDetail result = null;
            HttpResponseMessage response = null;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    ConfigureHttpClient(client);

                    response = client.PostAsync("api/converter/convert", detail, new JsonMediaTypeFormatter()).Result;

                    response.EnsureSuccessStatusCode();

                    result = response.Content.ReadAsAsync<NumberDetail>().Result;
                }
            }
            catch (Exception)
            {
                throw new ApplicationException(response.ReasonPhrase);
            }

            return result;
        }
    }
}

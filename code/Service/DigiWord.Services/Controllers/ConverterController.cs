using AutoMapper;
using DigiWord.Business;
using DigiWord.Entities;
using DigiWord.Services.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DigiWord.Services
{
    [RoutePrefix("api/converter")]
    public class ConverterController : ApiController
    {
        /// <summary>
        /// Converts a number to its textual representation
        /// </summary>
        /// <param name="request">Number detail requst</param>
        /// <returns>A number detail with converted text.</returns>
        [HttpPost]
        [Route("convert")]
        public HttpResponseMessage Convert(NumberDetailRequest request)
        {
            try
            {
                NumberDetail numberDetail = Mapper.Map<NumberDetailRequest, NumberDetail>(request);

                ConverterComponent converter = new ConverterComponent();

                NumberDetail result = converter.ProccesNumber(numberDetail);

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}

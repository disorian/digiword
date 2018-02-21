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
    /// <summary>
    /// Converter service which provides access to the converter via REST endpoint
    /// </summary>
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
                // maps the reqeust data contract to entity to be passed to business layer
                NumberDetail numberDetail = Mapper.Map<NumberDetailRequest, NumberDetail>(request);

                ConverterComponent converter = new ConverterComponent();

                NumberDetail result = converter.ProccesNumber(numberDetail);

                // creates a response with 200 status code and passes the result.
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}

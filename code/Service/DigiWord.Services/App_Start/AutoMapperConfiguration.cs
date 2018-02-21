using AutoMapper;
using DigiWord.Entities;
using DigiWord.Services.Models;

namespace DigiWord.Services
{
    /// <summary>
    /// Configures automapper which is used to map the service contracts to entities
    /// </summary>
    public static class AutoMapperConfiguration
    {
        /// <summary>
        /// Registers and initialize automapper
        /// </summary>
        public static void RegisterMapping()
        {
            Mapper.Initialize(config =>
                config.CreateMap<NumberDetailRequest, NumberDetail>()
            );
        }
    }
}

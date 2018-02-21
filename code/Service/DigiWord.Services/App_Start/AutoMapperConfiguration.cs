using AutoMapper;
using DigiWord.Entities;
using DigiWord.Services.Models;

namespace DigiWord.Services
{
    public static class AutoMapperConfiguration
    {
        public static void RegisterMapping()
        {
            Mapper.Initialize(config =>
                config.CreateMap<NumberDetailRequest, NumberDetail>()
            );
        }
    }
}

using AutoMapper;
using DigiWord.Entities;
using DigiWord.Services.Contract;

namespace DigiWord.Services.Configurations
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

using AutoMapper;
using LimitsAndTransactionsApi.Models.DTO;
using LimitsAndTransactionsApi.Models.Entity;


namespace LimitsAndTransactionsApi.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //ExchangeRate
            CreateMap<ExchangeRate, ExchangeRateDTO>();
            CreateMap<ExchangeRateDTO, ExchangeRate>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()); 
            //ApiKey
            CreateMap<ApiKey, ApiKeyDTO>();
            CreateMap<ApiKeyDTO,ApiKey>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
           
        }
    }

}

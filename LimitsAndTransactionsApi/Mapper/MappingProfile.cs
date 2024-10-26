using AutoMapper;
using LimitsAndTransactionsApi.Models.DTO;
using LimitsAndTransactionsApi.Models.Entity;


namespace LimitsAndTransactionsApi.Mapper
{    
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ExchangeRate, ExchangeRateDTO>();
            CreateMap<ExchangeRateDTO, ExchangeRate>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()); // Игнорируем Id при маппинге
        }
    }

}

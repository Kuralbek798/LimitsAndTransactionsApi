using AutoMapper;
using LimitsAndTransactionsApi.Context;
using LimitsAndTransactionsApi.Mapper;
using LimitsAndTransactionsApi.Models.DTO;
using LimitsAndTransactionsApi.Utils;
using Microsoft.EntityFrameworkCore;

namespace LimitsAndTransactionsApi.Repositories.ExchangeRateRepository
{
    public class ExchangeRateRepository : IExchangeRateRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public ExchangeRateRepository(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<ExchangeRateDTO?> GetLastExchangeRateAsync(string currencyPair)
        {
            try
            {
                var rate = await _appDbContext.ExchangeRates
                .Where(rate => rate.CurrencyPair == currencyPair)
                .OrderByDescending(rate => rate.DateTimeRate)
                .FirstOrDefaultAsync();

                if (rate != null)
                {
                    return _mapper.Map<ExchangeRateDTO>(rate);
                }
                else {
                    Logger.Warn("No data found");
                    return null;
                }
            }
            catch (Exception e)
            {
                Logger.Error(e, e.Message);
                throw;
            }
        }
    }
}

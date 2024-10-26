using LimitsAndTransactionsApi.Models.DTO;

namespace LimitsAndTransactionsApi.Services
{
    public interface IExchangeRateService
    {
          Task<ExchangeRateDTO> GetCurrencyRate(string currencyPair);
    }
}

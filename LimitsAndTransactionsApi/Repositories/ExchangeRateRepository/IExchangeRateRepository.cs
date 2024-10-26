using LimitsAndTransactionsApi.Models.DTO;

namespace LimitsAndTransactionsApi.Repositories.ExchangeRateRepository
{
    public interface IExchangeRateRepository
    {
        Task<ExchangeRateDTO> GetLastExchangeRateAsync(string currencyPair);
    }
}

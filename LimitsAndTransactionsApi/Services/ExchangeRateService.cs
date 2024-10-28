using LimitsAndTransactionsApi.Models.DTO;
using LimitsAndTransactionsApi.Repositories.ExchangeRateRepository;
using LimitsAndTransactionsApi.Utils;

namespace LimitsAndTransactionsApi.Services
{
    public class ExchangeRateService : IExchangeRateService
    {
        private const string KZT_USD_PAIR = "KZT/USD";
        private const string USD_KZT_PAIR = "USD/KZT";
        private const string VALUES = "values";
        private const string CLOSE = "close";
        private const string DATE_TIME = "datetime";


        private readonly IExchangeRateRepository _exchangeRateRepository;

        public ExchangeRateService(IExchangeRateRepository exchangeRateRepository)
        {
            this._exchangeRateRepository = exchangeRateRepository;
        }

        public async Task<ExchangeRateDTO> GetCurrencyRate(string currencyPair)
        {
            try
            {
                string effectiveCurrencyPair = getEffectiveCurrencyPair(currencyPair);
                DateTime dateNow = DateTime.Now;
                var exchangeRateDTO = await getRateFromDatabase(effectiveCurrencyPair, dateNow);

                if (exchangeRateDTO != null)
                {
                    return exchangeRateDTO;
                }
                else
                {
                    return getRateFromApi(effectiveCurrencyPair, dateNow);
                }
            }
            catch (Exception e)
            {
                Logger.Error(e, e.Message);
                throw new Exception(e.Message);
            }
        }

        private async Task<ExchangeRateDTO?> getRateFromDatabase(string effectiveCurrencyPair, DateTime dateNow)
        {
            try
            {
                var rate = await _exchangeRateRepository.GetLastExchangeRateAsync(effectiveCurrencyPair);
                if (rate != null && dateNow.Date == rate.DateTimeRate.DateTime.Date)
                {
                    Logger.Info($"Exchange rate found in database for currency pair {effectiveCurrencyPair}");
                    return rate;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Logger.Error(e, e.Message);
                throw new Exception(e.Message);
            }
        }

        private ExchangeRateDTO getRateFromApi(string effectiveCurrencyPair, DateTime dateNow)
        {
            throw new NotImplementedException();
        }

        private string getEffectiveCurrencyPair(string currencyPair)
        {
            return string.Equals(KZT_USD_PAIR, currencyPair, StringComparison.OrdinalIgnoreCase) ? USD_KZT_PAIR : currencyPair;
        }

    }
}

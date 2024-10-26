using System;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LimitsAndTransactionsApi.Models.DTO
{

    public class ExchangeRateDTO
    {
        public string CurrencyPair { get; }
        public decimal Rate { get; }
        public decimal Close { get; }
        public DateTimeOffset DateTimeRate { get; }

        [JsonConstructor]
        public ExchangeRateDTO(string currencyPair, decimal rate, decimal close, DateTimeOffset dateTimeRate)
        {
            CurrencyPair = currencyPair;
            Rate = rate;
            Close = close;
            DateTimeRate = dateTimeRate;
        }
        public ExchangeRateDTO() { }
        // Переопределяем метод GetHashCode
        public override int GetHashCode()
        {
            const int PRIME = 31;
            int result = 1;
            result = PRIME * result + (CurrencyPair != null ? CurrencyPair.GetHashCode() : 13);
            result = PRIME * result + Rate.GetHashCode();
            result = PRIME * result + Close.GetHashCode();
            result = PRIME * result + DateTimeRate.GetHashCode();
            

            return result;
        }
        
        // Переопределяем Equals
        public override bool Equals(object obj)
        {
            return obj is ExchangeRateDTO other &&
                   CurrencyPair == other.CurrencyPair &&
                   Rate == other.Rate &&
                   Close == other.Close &&
                   DateTimeRate == other.DateTimeRate;
        }
    }
}



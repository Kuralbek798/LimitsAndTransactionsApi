using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LimitsAndTransactionsApi.Models.Entity
{
    [Table("exchange_rates")]
    public class ExchangeRate
    {

        [Key]
        public Guid Id { get; set; }

        [Column("currency_pair")]
        [Required]
        public string CurrencyPair { get; set; }

        [Column("rate")]
        [Required]
        public decimal Rate { get; set; }

        [Column("close")]
        [Required]
        public decimal Close { get; set; }

        [Column("datetime_rate")]
        [Required]
        public DateTimeOffset DateTimeRate { get; set; }

        public ExchangeRate(Guid id, string currencyPair, decimal rate, decimal close, DateTimeOffset dateTimeRate)
        {
            Id = id;
            CurrencyPair = currencyPair;
            Rate = rate;
            Close = close;
            DateTimeRate = dateTimeRate;
        }
        public ExchangeRate()
        {
            Id = Guid.NewGuid();
        }

        public override string ToString()
        {
            return $"ExchangeRate [Id={Id}, CurrencyPair={CurrencyPair}, Rate={Rate}, Close={Close}, DateTimeRate={DateTimeRate}]";
        }
    }
}

using LimitsAndTransactionsApi.Repositories.ApiKeyRepository;
using LimitsAndTransactionsApi.Utils;
using System.Globalization;

namespace LimitsAndTransactionsApi.Services.HelpersServices
{
    public class ApiKeyService
    {
        private readonly IConfiguration _configuration;

        private readonly string _guidKey;
        private readonly string _serviceIdentity;       
        private readonly string _serviceUrl;

        private readonly IEncryptionDecryptionUtil _encryptionDecryptionUtil;
        private readonly IApiKeyRepository _apiKeyRepository;


        public ApiKeyService(IConfiguration configuration, IApiKeyRepository apiKeyRepository, IEncryptionDecryptionUtil encryptionDecryptionUtil)
        {
            _configuration = configuration;
            _guidKey = _configuration["GuidKey"] ?? throw new ArgumentNullException("GuidKey is not configured.");
            _serviceIdentity = _configuration["TwelveIdentity"] ?? throw new ArgumentNullException("TwelveIdentity is not configured.");
            _serviceUrl = _configuration["TwelveURL"] ?? throw new ArgumentNullException("TwelveURL is not configured.");
            _apiKeyRepository = apiKeyRepository;
            _encryptionDecryptionUtil = encryptionDecryptionUtil;
        }

        public async Task<String> GetDecriptedApiKey(String description) { 

            var encrypteeApiKey = await _apiKeyRepository.GetByDescriptionAsync(description);
            if (encrypteeApiKey != null) {

                return _encryptionDecryptionUtil.GetDecryptedApiKey(_guidKey, encrypteeApiKey.EncryptedApiKey);
           } else {
                throw new NullReferenceException("method GetDecriptedApiKey while trying to obtain EncryptedApiKey received null");
            }
        }
        

        public string BuildUrl(string requestIdentifier, DateTime startDate, DateTime endDate, string apiKey)
        {
            string formatedStartDate = startDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            string formatedEndDate = endDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);

            return string.Format(_serviceUrl, requestIdentifier, formatedStartDate, formatedEndDate, apiKey);
        }

        private DateTimeOffset GetStartOfWeek(DateTimeOffset date)
        {
            //Receiving the biginig of week(monday) on current day
            DayOfWeek dayOfWeek = date.DayOfWeek;

            if (dayOfWeek != DayOfWeek.Monday)
            {
                int daysToSubstract = (int)dayOfWeek - (int)DayOfWeek.Monday;

                return date.AddDays(-daysToSubstract);

            }
            else
            {
                return date;
            }
        }
    }
}

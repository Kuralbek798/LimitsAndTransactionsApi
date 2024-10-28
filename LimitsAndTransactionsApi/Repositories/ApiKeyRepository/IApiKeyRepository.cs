using LimitsAndTransactionsApi.Models.DTO;

namespace LimitsAndTransactionsApi.Repositories.ApiKeyRepository
{
    public interface IApiKeyRepository
    {
        Task<ApiKeyDTO> GetByDescriptionAsync(string description); 
    }
}

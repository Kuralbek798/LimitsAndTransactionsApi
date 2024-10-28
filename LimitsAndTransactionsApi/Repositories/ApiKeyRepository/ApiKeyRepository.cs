using AutoMapper;
using LimitsAndTransactionsApi.Context;
using LimitsAndTransactionsApi.Models.DTO;
using LimitsAndTransactionsApi.Utils;
using Microsoft.EntityFrameworkCore;

namespace LimitsAndTransactionsApi.Repositories.ApiKeyRepository
{
    public class ApiKeyRepository : IApiKeyRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public ApiKeyRepository(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<ApiKeyDTO?> GetByDescriptionAsync(string description)
        {
			try
			{
                var apiKey = await _appDbContext.ApiKeys
                    .Where(apiKey => apiKey.Description == description && apiKey.Active)
                    .FirstOrDefaultAsync();

                if (apiKey != null)
                {
                    return _mapper.Map<ApiKeyDTO>(apiKey);
                }
                else
                {
                    Logger.Warn("No data found");
                    return null;
                }

            }
			catch (Exception e)
			{
                Logger.Error(e, e.Message);
                throw new Exception(e.Message);
			}
        }
    }
}

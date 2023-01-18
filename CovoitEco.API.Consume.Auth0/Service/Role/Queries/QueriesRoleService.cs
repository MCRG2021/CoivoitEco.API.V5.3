using System.Net.Http.Headers;
using CovoitEco.API.Consume.Auth0.Interface.Role.Queries;
using CovoitEco.API.Consume.Auth0.Service.Token;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Polly;
using Polly.Retry;

namespace Camping.API.Consume.Auth0.Service.Role.Queries
{
    public class QueriesRoleService : IQueriesRoleService
    {
        #region Fields

        private readonly HttpClient _client;
        private const int MaxRetries = 3;
        private readonly AsyncRetryPolicy _retrypolicy;
        private readonly IConfiguration _configuration; 

        #endregion

        #region Constructor

        public QueriesRoleService(HttpClient client, IConfiguration config)
        {
            _retrypolicy = Policy.Handle<HttpRequestException>().RetryAsync(MaxRetries);
            _client = client;
            _configuration = config;
        }
        #endregion
        public async Task<List<CovoitEco.API.Consume.Auth0.Models.Role>> GetAllAsync()
        {
            List<CovoitEco.API.Consume.Auth0.Models.Role> ?task = null;
            await _retrypolicy.ExecuteAsync(async () =>
            {
                await GetTokenService.SetTokenToAuthenticationHeaderAsync(_client,_configuration);
                var httpResponse = await _client.GetAsync("https://dev-lmwabwkg.us.auth0.com/api/v2/roles");
                if (!httpResponse.IsSuccessStatusCode)
                {
                    throw new Exception("Cannot access to item api");
                }
                var content = await httpResponse.Content.ReadAsStringAsync(); 
                task = JsonConvert.DeserializeObject<List<CovoitEco.API.Consume.Auth0.Models.Role>>(content);
            });
            return task;
        }
    }
}


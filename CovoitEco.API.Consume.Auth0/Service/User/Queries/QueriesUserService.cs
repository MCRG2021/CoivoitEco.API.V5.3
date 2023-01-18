using System.Net.Http.Headers;
using CovoitEco.API.Consume.Auth0.Interface.User.Queries;
using CovoitEco.API.Consume.Auth0.Models;
using CovoitEco.API.Consume.Auth0.Service.Token;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Polly;
using Polly.Retry;

namespace CovoitEco.API.Consume.Auth0.Service.User.Queries
{
    public class QueriesUserService : IQueriesUserService
    {
        #region Fields

        private readonly HttpClient _client;
        private const int MaxRetries = 3;
        private readonly AsyncRetryPolicy _retrypolicy;
        private readonly IConfiguration _configuration;

        #endregion

        #region Constructor

        public QueriesUserService(HttpClient client, IConfiguration config)
        {
            _retrypolicy = Policy.Handle<HttpRequestException>().RetryAsync(MaxRetries);
            _client = client;
            _configuration = config;
        }
        #endregion

        #region Methods

        public async Task<List<UserResponse>> GetAllAsync(int pageSize, int pageNumber)
        {
            
            List<UserResponse>? task = null;
            await _retrypolicy.ExecuteAsync(async () =>
            {
                await GetTokenService.SetTokenToAuthenticationHeaderAsync(_client, _configuration);
                var httpResponse = await _client.GetAsync("https://dev-lmwabwkg.us.auth0.com/api/v2/users?page=" + pageNumber + "&per_page=" + pageSize);
                if (!httpResponse.IsSuccessStatusCode)
                {
                    throw new Exception("Cannot access to item api");
                }
                var content = await httpResponse.Content.ReadAsStringAsync();
                task = JsonConvert.DeserializeObject<List<UserResponse>>(content);
            });
            return task;
        }

        public async Task<UserInfo> GetUserInfo(string accessToken)
        {
            UserInfo task = null;
            await _retrypolicy.ExecuteAsync(async () =>
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                var httpResponse = await _client.GetAsync("https://dev-lmwabwkg.us.auth0.com/userinfo");
                if (!httpResponse.IsSuccessStatusCode)
                {
                    throw new Exception("Cannot access to item api");
                }
                var content = await httpResponse.Content.ReadAsStringAsync();
                task = JsonConvert.DeserializeObject<UserInfo>(content);
            });
            return task;
        }

        #endregion

    }
}

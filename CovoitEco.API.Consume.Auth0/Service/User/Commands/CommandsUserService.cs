using CovoitEco.API.Consume.Auth0.HttpExtensions;
using CovoitEco.API.Consume.Auth0.Interface.User.Commands;
using CovoitEco.API.Consume.Auth0.Models;
using CovoitEco.API.Consume.Auth0.Service.Token;
using Microsoft.Extensions.Configuration;
using Polly;
using Polly.Retry;

namespace CovoitEco.API.Consume.Auth0.Service.User.Commands
{
    public class CommandsUserService : ICommandsUserService
    {
        #region Fields

        private readonly HttpClient _client;
        private const int MaxRetries = 3;
        private readonly AsyncRetryPolicy _retrypolicy;
        private readonly IConfiguration _configuration;

        #endregion

        #region Constructor

        public CommandsUserService(HttpClient client, IConfiguration config)
        {
            _retrypolicy = Policy.Handle<HttpRequestException>().RetryAsync(MaxRetries);
            _client = client;
            _configuration = config;
        }
        #endregion
        public async Task CreateUser(CovoitEco.API.Consume.Auth0.Models.User user)
        {
            await _retrypolicy.ExecuteAsync(async () =>
            {
                await GetTokenService.SetTokenToAuthenticationHeaderAsync(_client, _configuration);
                var httpResponse = await _client.PostAsJsonAsync<CovoitEco.API.Consume.Auth0.Models.User>("https://dev-lmwabwkg.us.auth0.com/api/v2/users", user);
                if (!httpResponse.IsSuccessStatusCode)
                {
                    throw new Exception("Cannot access to item api");
                }
            });
        }

        public async Task UpdateUser(UserUpdate user, string idUser)
        {

            await _retrypolicy.ExecuteAsync(async () =>
            {
                await GetTokenService.SetTokenToAuthenticationHeaderAsync(_client, _configuration);
                var httpResponse = await _client.PatchAsJsonAsync<UserUpdate>("https://dev-lmwabwkg.us.auth0.com/api/v2/users/" + idUser, user);
                if (!httpResponse.IsSuccessStatusCode)
                {
                    throw new Exception("Cannot access to item api");
                }
            });
        }

        public async Task DeleteUser(string idUser)
        {
            await _retrypolicy.ExecuteAsync(async () =>
            {
                await GetTokenService.SetTokenToAuthenticationHeaderAsync(_client, _configuration);
                var httpResponse = await _client.DeleteAsync("https://dev-lmwabwkg.us.auth0.com/api/v2/users/auth0%7C" + idUser);
                if (!httpResponse.IsSuccessStatusCode)
                {
                    throw new Exception("Cannot access to item api");
                }
            });
        }
    }
}

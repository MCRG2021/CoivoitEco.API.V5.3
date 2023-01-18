using CovoitEco.API.Consume.Auth0.HttpExtensions;
using CovoitEco.API.Consume.Auth0.Interface.Role.Commands;
using CovoitEco.API.Consume.Auth0.Models;
using CovoitEco.API.Consume.Auth0.Service.Token;
using Microsoft.Extensions.Configuration;
using Polly;
using Polly.Retry;

namespace CovoitEco.API.Consume.Auth0.Service.Role.Commands
{
    public class CommandsRoleService : ICommandsRoleService
    {
        #region Fields

        private readonly HttpClient _client;
        private const int MaxRetries = 3;
        private readonly AsyncRetryPolicy _retrypolicy;
        private readonly IConfiguration _configuration;

        #endregion

        #region Constructor

        public CommandsRoleService(HttpClient client, IConfiguration config)
        {
            _retrypolicy = Policy.Handle<HttpRequestException>().RetryAsync(MaxRetries);
            _client = client;
            _configuration = config;
        }
        #endregion

        public async Task AssignRole(UserRole userRole, string idRole)
        {
            await _retrypolicy.ExecuteAsync(async () =>
            {
                await GetTokenService.SetTokenToAuthenticationHeaderAsync(_client, _configuration);
                var httpResponse = await _client.PostAsJsonAsync<UserRole>("https://dev-lmwabwkg.us.auth0.com/api/v2/roles/" + idRole + "/users", userRole);
                if (!httpResponse.IsSuccessStatusCode)
                {
                    throw new Exception("Cannot access to item api");
                }
            });
        }

        public async Task RemoveRole(RemoveRoleUser userRole, string idUser)
        {
            await _retrypolicy.ExecuteAsync(async () =>
            {
                await GetTokenService.SetTokenToAuthenticationHeaderAsync(_client, _configuration);
                var httpResponse = await _client.DeleteAsJsonAsync<RemoveRoleUser>("https://dev-lmwabwkg.us.auth0.com/api/v2/users/auth0%7C" + idUser + "/roles", userRole); 
                if (!httpResponse.IsSuccessStatusCode)
                {
                    throw new Exception("Cannot access to item api");
                }
            });
        }
    }
}

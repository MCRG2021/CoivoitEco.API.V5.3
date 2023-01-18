using System.Net.Http.Headers;
using CovoitEco.API.Consume.Auth0.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace CovoitEco.API.Consume.Auth0.Service.Token
{
    public static class GetTokenService
    {
        private static async Task<TokenResponse> GetTokenAsync(HttpClient client, IConfiguration configuration)
        {
            var response = await client.PostAsync("https://dev-lmwabwkg.us.auth0.com/oauth/token", new FormUrlEncodedContent(
                new Dictionary<string, string>()
                {
                    {"grant_type", configuration["Auth0Management:GrandType"]},
                    {"client_id", configuration["Auth0Management:ClientId"]},
                    {"client_secret", configuration["Auth0Management:ClientSecret"]},
                    {"audience", configuration["Auth0Management:Audience"]}
                }));

            var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var result = string.IsNullOrEmpty(responseContent)
                ? default
                : JsonConvert.DeserializeObject<TokenResponse>(responseContent);
            return result;
        }

        public static async Task SetTokenToAuthenticationHeaderAsync(HttpClient client, IConfiguration configuration)
        {
            var tokenResponse = await GetTokenAsync(client,configuration);
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", tokenResponse?.access_token);
        }
    }
}

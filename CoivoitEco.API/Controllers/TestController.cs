using CovoitEco.API.Consume.Auth0.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoivoitEco.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private IConfiguration _configuration;
        private readonly HttpClient _client;
        public TestController(HttpClient client, IConfiguration config)
        {
            _client = client;
            _configuration = config;
        }

        [HttpPost]
        public async Task<TokenResponse> GetTokenAsync()
        {
            var response = await _client.PostAsync("https://dev-lmwabwkg.us.auth0.com/oauth/token", new FormUrlEncodedContent(
                new Dictionary<string,string>()
            {
                {"grant_type", _configuration["Auth0Management:GrandType"]},
                {"client_id", _configuration["Auth0Management:ClientId"]},
                {"client_secret", _configuration["Auth0Management:ClientSecret"]},
                {"audience", _configuration["Auth0Management:Audience"]}
            }));

            var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var result = string.IsNullOrEmpty(responseContent)
                ? default
                : JsonConvert.DeserializeObject<TokenResponse>(responseContent);
            return result;
        }
    }
}

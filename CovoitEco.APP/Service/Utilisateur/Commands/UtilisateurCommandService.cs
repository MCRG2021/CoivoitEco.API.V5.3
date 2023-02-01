using System.Net.Http.Headers;
using System.Net.Http.Json;
using CovoitEco.APP.Model.Models;
using Polly;
using Polly.Retry;

namespace CovoitEco.APP.Service.Utilisateur.Commands
{
    public class UtilisateurCommandService : IUtilisateurCommandsService
    {
        #region Fields

        private const int MaxRetries = 3;
        private static readonly Random Random = new Random();
        private readonly HttpClient _httpClient;
        private readonly AsyncRetryPolicy _retrypolicy;
        #endregion

        #region Constructor

        public UtilisateurCommandService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _retrypolicy = Policy.Handle<HttpRequestException>().RetryAsync(MaxRetries);
        }

        #endregion

        public async Task CreateUtilisateur(UserFormular formular) // access token
        {
            await _retrypolicy.ExecuteAsync(async () =>
            {
                var postReservation = await _httpClient.PostAsJsonAsync("https://localhost:7197/api/User/CreateUser", formular);
                if (!postReservation.IsSuccessStatusCode)
                    throw new Exception();
            });
        }
    }
}

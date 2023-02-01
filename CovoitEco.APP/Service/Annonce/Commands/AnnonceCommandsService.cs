using System.Net.Http.Headers;
using System.Net.Http.Json;
using CovoitEco.APP.Model.Models;
using Newtonsoft.Json;
using Polly;
using Polly.Retry;

namespace CovoitEco.APP.Service.Annonce.Commands
{
    public class AnnonceCommandsService : IAnnonceCommandsService
    { 
        #region Fields

        private const int MaxRetries = 3;
        private static readonly Random Random = new Random();
        private readonly HttpClient _httpClient;
        private readonly AsyncRetryPolicy _retrypolicy;
        #endregion

        #region Constructor

        public AnnonceCommandsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _retrypolicy = Policy.Handle<HttpRequestException>().RetryAsync(MaxRetries);
        }


        #endregion


        public async Task CreateAnnonce(AnnonceProfileFormular formular)
        {
            await _retrypolicy.ExecuteAsync(async () =>
            {
                var postAnnonce = await _httpClient.PostAsJsonAsync("https://localhost:7197/api/Annonce/CreateAnnonce", formular);
                if (!postAnnonce.IsSuccessStatusCode)
                    throw new Exception();
            });
        }

        public async Task UpdateStatutAnnonce(int idAnn)
        {
            await _retrypolicy.ExecuteAsync(async () =>
            {
                var postAnnonce = await _httpClient.PutAsJsonAsync("https://localhost:7197/api/Annonce/UpdateStatutAnnonce?id=" + idAnn, idAnn);
                if (!postAnnonce.IsSuccessStatusCode)
                    throw new Exception();
            });
        }
    }
}

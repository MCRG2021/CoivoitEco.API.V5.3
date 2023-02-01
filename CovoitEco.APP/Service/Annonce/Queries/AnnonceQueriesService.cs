using System.Net.Http.Headers;
using CoiviteEco.APP.Service.Annonce.Queries;
using CovoitEco.APP.Model.Models;
using Newtonsoft.Json;
using Polly;
using Polly.Retry;

namespace CovoitEco.APP.Service.Annonce.Queries
{
    public class AnnonceQueriesService :  IAnnonceQueriesService
    {
        #region Fields

        private const int MaxRetries = 3;
        private static readonly Random Random = new Random();
        private readonly HttpClient _httpClient;
        private readonly AsyncRetryPolicy<AnnonceProfileVm> _retrypolicy;
        #endregion

        #region Constructor

        public AnnonceQueriesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _retrypolicy = Policy<AnnonceProfileVm>.Handle<HttpRequestException>().RetryAsync(MaxRetries);
        }


        #endregion

        public async Task<AnnonceProfileVm> GetAllAnnonceProfile(int id, string token)
        {
            //var httpResponse = "";

            return await _retrypolicy.ExecuteAsync(async () =>
            {
                var httpResponse = await _httpClient.GetAsync("https://localhost:7197/api/Annonce/GetAllAnnonceProfile?id=" + id);
                if (!httpResponse.IsSuccessStatusCode) throw new Exception();
                var content = await httpResponse.Content.ReadAsStringAsync();
                var annoncesProfile = JsonConvert.DeserializeObject<AnnonceProfileVm>(content);
                return annoncesProfile;
            });
        }

        public async Task<AnnonceProfileVm> GetAnnonceRecherche(DateTime departureDate, string departureCity, string arrivalCity, string token) 
        {
            return await _retrypolicy.ExecuteAsync(async () =>
            {
                var httpResponse = await _httpClient.GetAsync("https://localhost:7197/api/Annonce/GetAnnonceRecherche?departureDate=" + departureDate.Year + "-" + departureDate.Month + "-" + departureDate.Day + "&departureCity=" + departureCity + "&arrivalCity=" + arrivalCity);
                if (!httpResponse.IsSuccessStatusCode) throw new Exception();
                var content = await httpResponse.Content.ReadAsStringAsync();
                var annoncesProfile = JsonConvert.DeserializeObject<AnnonceProfileVm>(content);
                return annoncesProfile;
            });
        }

        public async Task<AnnonceProfileVm> GetAnnonceProfile(int id, string token)
        {
            return await _retrypolicy.ExecuteAsync(async () =>
            {
                var httpResponse = await _httpClient.GetAsync("https://localhost:7197/api/Annonce/GetAnnonceProfile?id=" + id);
                if (!httpResponse.IsSuccessStatusCode) throw new Exception();
                var content = await httpResponse.Content.ReadAsStringAsync();
                var annoncesProfile = JsonConvert.DeserializeObject<AnnonceProfileVm>(content);
                return annoncesProfile;
            });
        }
    }
}

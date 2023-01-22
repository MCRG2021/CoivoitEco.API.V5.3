using System.Net.Http.Headers;
using CoiviteEco.APP.Service.Annonce.Queries;
using CovoitEco.APP.Model.Models;
using Newtonsoft.Json;
using Polly;
using Polly.Retry;

namespace CovoitEco.APP.Service.Vehicule.Queries
{
    public class VehiculeProfileQueries : IVehiculeQueriesService
    {
        #region Fields

        private const int MaxRetries = 3;
        private static readonly Random Random = new Random();
        private readonly HttpClient _httpClient;
        private readonly AsyncRetryPolicy<VehiculeProfileVm> _retrypolicy;
        #endregion

        #region Constructor

        public VehiculeProfileQueries(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _retrypolicy = Policy<VehiculeProfileVm>.Handle<HttpRequestException>().RetryAsync(MaxRetries);
        }

        #endregion

        public async Task<VehiculeProfileVm> GetVehiculeProfile(int id, string token)
        {
            return await _retrypolicy.ExecuteAsync(async () =>
            {
                //if (Random.Next(1, 40) == 1)
                //    throw new HttpRequestException("This is a fake request exception");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var httpResponse = await _httpClient.GetAsync("https://localhost:7197/api/VehiculeProfile/GetVehiculeProfile?id=" + id);
                if (!httpResponse.IsSuccessStatusCode) throw new Exception();
                var content = await httpResponse.Content.ReadAsStringAsync();
                var vehiculeProfile = JsonConvert.DeserializeObject<VehiculeProfileVm>(content);
                return vehiculeProfile;
            });
        }

        public async Task<VehiculeProfileVm> GetAllVehiculeProfile(int id, string token) 
        {
            return await _retrypolicy.ExecuteAsync(async () =>
            {
                //if (Random.Next(1, 40) == 1)
                //    throw new HttpRequestException("This is a fake request exception");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var httpResponse = await _httpClient.GetAsync("https://localhost:7197/api/VehiculeProfile/GetAllVehiculeProfile?id=" + id);
                if (!httpResponse.IsSuccessStatusCode) throw new Exception();
                var content = await httpResponse.Content.ReadAsStringAsync();
                var vehiculeProfile = JsonConvert.DeserializeObject<VehiculeProfileVm>(content);
                return vehiculeProfile;
            });
        }

        public async Task<VehiculeProfileVm> GetVehicule(int id, string token)
        {
            return await _retrypolicy.ExecuteAsync(async () =>
            {
                //if (Random.Next(1, 40) == 1)
                //    throw new HttpRequestException("This is a fake request exception");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var httpResponse = await _httpClient.GetAsync("https://localhost:7197/api/VehiculeProfile/GetVehicule?id=" + id);
                if (!httpResponse.IsSuccessStatusCode) throw new Exception();
                var content = await httpResponse.Content.ReadAsStringAsync();
                var vehiculeProfile = JsonConvert.DeserializeObject<VehiculeProfileVm>(content);
                return vehiculeProfile;
            });
        }
    }
}

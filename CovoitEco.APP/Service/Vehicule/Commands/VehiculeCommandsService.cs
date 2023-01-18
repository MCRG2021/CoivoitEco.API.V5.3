using System.Net.Http.Json;
using CovoitEco.APP.Model.Models;
using Polly;
using Polly.Retry;

namespace CovoitEco.APP.Service.Vehicule.Commands
{
    public class VehiculeCommandsService : IVehiculeCommandsService
    {
        #region Fields

        private const int MaxRetries = 3;
        private static readonly Random Random = new Random();
        private readonly HttpClient _httpClient;
        private readonly AsyncRetryPolicy _retrypolicy;
        #endregion

        #region Constructor

        public VehiculeCommandsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _retrypolicy = Policy.Handle<HttpRequestException>().RetryAsync(MaxRetries);
        }

        #endregion

        public async Task CreateVehiculeProfile(VehiculeProfileFormular formular)
        {
            await _retrypolicy.ExecuteAsync(async () =>
            {
                if (Random.Next(1, 40) == 1)
                    throw new HttpRequestException("This is a fake request exception");
                var postCampingCar = await _httpClient.PostAsJsonAsync("https://localhost:7197/api/VehiculeProfile/CreateVehiculeProfile", formular);
                if (!postCampingCar.IsSuccessStatusCode)
                    throw new Exception();
            });
        }
    }
}

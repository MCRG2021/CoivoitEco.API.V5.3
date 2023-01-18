using Newtonsoft.Json;
using Polly;
using Polly.Retry;

namespace CovoitEco.APP.Service.Facture.Queries
{
    public class FactureQueriesService : IFactureQueriesService
    {
        #region Fields

        private const int MaxRetries = 3;
        private static readonly Random Random = new Random();
        private readonly HttpClient _httpClient;
        private readonly AsyncRetryPolicy _retrypolicy;
        #endregion

        #region Constructor

        public FactureQueriesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _retrypolicy = Policy.Handle<HttpRequestException>().RetryAsync(MaxRetries);
        }

        #endregion
        public async Task<int> GetIdFactureReservation(int idRes) // not tested again
        {
            return await _retrypolicy.ExecuteAsync(async () =>
            {
                if (Random.Next(1, 40) == 1)
                    throw new HttpRequestException("This is a fake request exception");
                var httpResponse = await _httpClient.GetAsync("https://localhost:7197/api/Facture/GetIdFactureReservation?id=" + idRes);
                if (!httpResponse.IsSuccessStatusCode) throw new Exception();
                var content = await httpResponse.Content.ReadAsStringAsync();
                var idReservation = JsonConvert.DeserializeObject<int>(content);
                return idReservation;
            });
        }
    }
}

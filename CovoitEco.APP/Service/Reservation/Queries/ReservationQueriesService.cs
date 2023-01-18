using System.Net.Http.Headers;
using CovoitEco.APP.Model.Models;
using Newtonsoft.Json;
using Polly;
using Polly.Retry;

namespace CovoitEco.APP.Service.Reservation.Queries
{
    public class ReservationQueriesService : IReservationQueriesService
    {
        #region Fields

        private const int MaxRetries = 3;
        private static readonly Random Random = new Random();
        private readonly HttpClient _httpClient;
        private readonly AsyncRetryPolicy _retrypolicy;
        #endregion

        #region Constructor

        public ReservationQueriesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _retrypolicy = Policy.Handle<HttpRequestException>().RetryAsync(MaxRetries);
        }

        #endregion

        public async Task<int> GetIdReservationUserProfile(int idAnn, int idUser)
        {
            return await _retrypolicy.ExecuteAsync(async () =>
            {
                if (Random.Next(1, 40) == 1)
                    throw new HttpRequestException("This is a fake request exception");
                var httpResponse = await _httpClient.GetAsync("https://localhost:7197/api/Reservation/GetIdReservationUserProfile?idAnn=" + idAnn + "&idUser=" + idUser);
                if (!httpResponse.IsSuccessStatusCode) throw new Exception();
                var content = await httpResponse.Content.ReadAsStringAsync();
                var idReservation = JsonConvert.DeserializeObject<int>(content);
                return idReservation;
            });
        }

        public async Task<ReservationUserProfileVm> GetAllReservationUserProfile(int idUser, string token)
        {
            return await _retrypolicy.ExecuteAsync(async () =>
            {
                if (Random.Next(1, 40) == 1)
                    throw new HttpRequestException("This is a fake request exception");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var httpResponse = await _httpClient.GetAsync("https://localhost:7197/api/Reservation/GetAllReservationUserProfile?id=" + idUser);
                if (!httpResponse.IsSuccessStatusCode) throw new Exception();
                var content = await httpResponse.Content.ReadAsStringAsync();
                var idReservation = JsonConvert.DeserializeObject<ReservationUserProfileVm>(content);
                return idReservation;
            });
        }

        public async Task<ReservationUserProfileVm> GetReservationUserProfile(int idRes, string token)
        {
            return await _retrypolicy.ExecuteAsync(async () =>
            {
                if (Random.Next(1, 40) == 1)
                    throw new HttpRequestException("This is a fake request exception");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var httpResponse = await _httpClient.GetAsync("https://localhost:7197/api/Reservation/GetReservationUserProfile?id=" + idRes);
                if (!httpResponse.IsSuccessStatusCode) throw new Exception();
                var content = await httpResponse.Content.ReadAsStringAsync();
                var idReservation = JsonConvert.DeserializeObject<ReservationUserProfileVm>(content);
                return idReservation;
            });
        }

        public async Task<ReservationProfileVm> GetAllReservationProfile(int id)
        {
            return await _retrypolicy.ExecuteAsync(async () =>
            {
                if (Random.Next(1, 40) == 1)
                    throw new HttpRequestException("This is a fake request exception");
                var httpResponse = await _httpClient.GetAsync("https://localhost:7197/api/Reservation/GetAllReservationProfile?id=" + id);
                if (!httpResponse.IsSuccessStatusCode) throw new Exception();
                var content = await httpResponse.Content.ReadAsStringAsync();
                var idReservation = JsonConvert.DeserializeObject<ReservationProfileVm>(content);
                return idReservation;
            });
        }
    }
}

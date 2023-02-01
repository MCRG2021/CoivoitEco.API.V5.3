using System.Net.Http.Headers;
using System.Net.Http.Json;
using CovoitEco.APP.Model.Models;
using Polly;
using Polly.Retry;

namespace CovoitEco.APP.Service.Reservation.Commands
{
    public class ReservationCommandsService : IReservationCommandsService
    {
        #region Fields

        private const int MaxRetries = 3;
        private static readonly Random Random = new Random();
        private readonly HttpClient _httpClient;
        private readonly AsyncRetryPolicy _retrypolicy;
        #endregion

        #region Constructor

        public ReservationCommandsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _retrypolicy = Policy.Handle<HttpRequestException>().RetryAsync(MaxRetries);
        }

        #endregion

        public async Task CreateReservation(ReservationFormular formular)
        {
            await _retrypolicy.ExecuteAsync(async () =>
            {
                var postReservation = await _httpClient.PostAsJsonAsync("https://localhost:7197/api/Reservation/CreateReservation", formular);
                if (!postReservation.IsSuccessStatusCode)
                    throw new Exception();
            });
        }

        public async Task UpdateConfirmePayment(int id)
        {
            await _retrypolicy.ExecuteAsync(async () =>
            {
                var putReservation = await _httpClient.PutAsJsonAsync("https://localhost:7197/api/Reservation/UpdateConfirmePayment?id=" + id, id);
                if (!putReservation.IsSuccessStatusCode)
                    throw new Exception();
            });
        }

        public async Task UpdateAccepterReservation(int id)
        {
            await _retrypolicy.ExecuteAsync(async () =>
            {
                var putReservation = await _httpClient.PutAsJsonAsync("https://localhost:7197/api/Reservation/UpdateAccepterReservation?id=" + id, id);
                if (!putReservation.IsSuccessStatusCode)
                    throw new Exception();
            });
        }

        public async Task UpdateStatutReservation(int id)
        {
            await _retrypolicy.ExecuteAsync(async () =>
            {
                var putReservation = await _httpClient.PutAsJsonAsync("https://localhost:7197/api/Reservation/UpdateStatutReservation?id=" + id, id);
                if (!putReservation.IsSuccessStatusCode)
                    throw new Exception();
            });
        }
    }
}

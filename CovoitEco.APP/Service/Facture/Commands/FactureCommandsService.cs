﻿using System.Net.Http.Headers;
using System.Net.Http.Json;
using Polly;
using Polly.Retry;

namespace CovoitEco.APP.Service.Facture.Commands
{
    public class FactureCommandsService : IFactureCommandsService
    {
        #region Fields

        private const int MaxRetries = 3;
        private static readonly Random Random = new Random();
        private readonly HttpClient _httpClient;
        private readonly AsyncRetryPolicy _retrypolicy;
        #endregion

        #region Constructor

        public FactureCommandsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _retrypolicy = Policy.Handle<HttpRequestException>().RetryAsync(MaxRetries);
        }

        #endregion

        public async Task CreateFacture(int id, string token)
        {
            await _retrypolicy.ExecuteAsync(async () =>
            {
                var postFacture = await _httpClient.PostAsJsonAsync("https://localhost:7197/api/Facture/CreateFacture?id=" + id,id);
                if (!postFacture.IsSuccessStatusCode)
                    throw new Exception();
            });
        }

        public async Task UpdateFacturePayment(int idFact, string token)
        {
            await _retrypolicy.ExecuteAsync(async () =>
            {
                var putFacutrer = await _httpClient.PutAsJsonAsync("https://localhost:7197/api/Facture/UpdateFacturePayment?id=" + idFact, idFact);
                if (!putFacutrer.IsSuccessStatusCode)
                    throw new Exception();
            });
        }
    }
}

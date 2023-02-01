using CovoitEco.APP.Model.Models;
using Microsoft.AspNetCore.Components;

namespace CoiviteEco.APP.Service.Annonce.Queries
{
    public interface IAnnonceQueriesService 
    {
        public Task<AnnonceProfileVm> GetAllAnnonceProfile(int id);

        public Task<AnnonceProfileVm> GetAnnonceRecherche(DateTime departureDate, string departureCity, string arrivalCity);
        public Task<AnnonceProfileVm> GetAnnonceProfile(int id);
    }
}

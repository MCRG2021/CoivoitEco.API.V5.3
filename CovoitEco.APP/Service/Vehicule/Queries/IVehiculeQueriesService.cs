using CovoitEco.APP.Model.Models;

namespace CovoitEco.APP.Service.Vehicule.Queries
{
    public interface IVehiculeQueriesService
    {
        public Task<VehiculeProfileVm> GetVehiculeProfile(int id, string token);
        public Task<VehiculeProfileVm> GetAllVehiculeProfile(int id, string token);
        public Task<VehiculeProfileVm> GetVehicule(int id, string token);
    }
}

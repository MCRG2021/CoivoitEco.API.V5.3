using CovoitEco.APP.Model.Models;

namespace CovoitEco.APP.Service.Vehicule.Queries
{
    public interface IVehiculeQueriesService
    {
        public Task<VehiculeProfileVm> GetVehiculeProfile(int id);
        public Task<VehiculeProfileVm> GetAllVehiculeProfile(int id);
        public Task<VehiculeProfileVm> GetVehicule(int id);
    }
}

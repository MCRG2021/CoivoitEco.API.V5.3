using CovoitEco.APP.Model.Models;

namespace CovoitEco.APP.Service.Vehicule.Commands
{
    public interface IVehiculeCommandsService
    {
        public Task CreateVehiculeProfile(VehiculeProfileFormular formular);
    }
}

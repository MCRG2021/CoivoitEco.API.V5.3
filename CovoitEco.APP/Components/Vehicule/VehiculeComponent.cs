using CovoitEco.APP.Model.Models;
using CovoitEco.APP.Service.Vehicule.Commands;
using CovoitEco.APP.Service.Vehicule.Queries;
using Microsoft.AspNetCore.Components;

namespace CovoitEco.APP.Components.Vehicule
{
    public class VehiculeComponent : BaseComponent
    {
        protected override async Task OnInitializedAsync()
        {
            responseGetVehicule = await vehiculeQueries.GetVehiculeProfile(idUser); // Id user current 
            responseGetAllVehicule = await vehiculeQueries.GetAllVehiculeProfile(idUser);
        }

        protected async Task CreateVehiculeProfile()
        {
             await vehiculeCommands.CreateVehiculeProfile(resquestVehiculeProfileFormular);
        }
    }
}

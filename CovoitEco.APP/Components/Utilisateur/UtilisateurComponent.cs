using CovoitEco.APP.Model.Models;
using CovoitEco.APP.Service.Reservation.Queries;
using CovoitEco.APP.Service.Utilisateur.Queries;
using Microsoft.AspNetCore.Components;

namespace CovoitEco.APP.Components.Utilisateur
{
    public class UtilisateurComponent : BaseComponent
    {
        protected override async Task OnInitializedAsync()
        {
            responseGetUtilisateurProfile = await UtilisateurQueries.GetUtilisateurPofile(idUser);
        }
    }
}

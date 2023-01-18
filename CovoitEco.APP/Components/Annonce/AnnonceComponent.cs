using System.Reflection.Metadata;
using CoiviteEco.APP.Service.Annonce.Queries;
using CovoitEco.APP.Model.Models;
using CovoitEco.APP.Service.Annonce.Commands;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;


namespace CovoitEco.APP.Components.Annonce
{
    public class AnnonceComponent : BaseComponent
    {
        
        /// <summary>
        /// add get id user current
        /// </summary>
        /// <returns></returns>
        //[Authorize]
        protected override async Task OnInitializedAsync()
        {
            await GetAccessToken(); // to initialize accessToken
            await SetIdUser(); // to initialize idUser
            responseAnnonce = await AnnonceQueries.GetAllAnnonceProfile(idUser); // Id user current 
            await UpdateAnnonceStatut(); // Check and update statut annonce
        }

        protected async Task CreateAnnonceProfile()
        {
            await SetIdVehCurrent();
            requestAnnonceProfileFormular.ANN_UTL_Id = idUser; //1 // to recuperate automatically 
            requestAnnonceProfileFormular.ANN_VEH_Id = idVehicule; // to recuperate automatically (always the current veh)
            await AnnonceCommands.CreateAnnonce(requestAnnonceProfileFormular);
        }

        protected async Task UpdateAnnonceStatut()
        {
            foreach (var annonce in responseAnnonce.Lists)
            {
                if (annonce.ANNPR_Statut != "Close" )
                {
                    await AnnonceCommands.UpdateStatutAnnonce(annonce.ANNPR_Id);
                }
            }
        }
    }
}

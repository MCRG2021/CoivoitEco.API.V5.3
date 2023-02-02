
namespace CovoitEco.APP.Components.Annonce
{
    public class AnnonceComponent : BaseComponent
    {
        /// <summary>
        /// add get id user current
        /// </summary>
        /// <returns></returns>
        protected override async Task OnInitializedAsync()
        {
            await Initialized();
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

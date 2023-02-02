
namespace CovoitEco.APP.Components.Annonce
{
    public class RechercheAnnonceComponent : BaseComponent
    {
        protected override async Task OnInitializedAsync()
        {
            responseAnnonce = await AnnonceQueries.GetAnnonceRecherche(requestAnnonceRechercheFormular.departureDate, requestAnnonceRechercheFormular.departureCity, requestAnnonceRechercheFormular.arrivalCity);
        }
    }
}

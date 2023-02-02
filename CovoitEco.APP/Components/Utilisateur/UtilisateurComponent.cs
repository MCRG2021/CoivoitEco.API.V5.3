
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

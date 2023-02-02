
namespace CovoitEco.APP.Components.Utilisateur
{
    public class SignUpUtilisateurComponent : BaseComponent
    {
        protected async Task CreateUtilisateurProfile()
        {
            await UtilisateurCommands.CreateUtilisateur(requestUtilisateurFormular); // accestoken
        }
    }
}

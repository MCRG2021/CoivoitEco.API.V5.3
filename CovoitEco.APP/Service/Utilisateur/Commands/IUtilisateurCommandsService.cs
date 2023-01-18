using CovoitEco.APP.Model.Models;

namespace CovoitEco.APP.Service.Utilisateur.Commands
{
    public interface IUtilisateurCommandsService
    {
        public Task CreateUtilisateur(UserFormular formular, string token);
    }
}

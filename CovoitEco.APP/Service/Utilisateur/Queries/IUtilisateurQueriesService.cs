using CovoitEco.APP.Model.Models;

namespace CovoitEco.APP.Service.Utilisateur.Queries
{
    public interface IUtilisateurQueriesService
    {
        public Task<UserProfileVm> GetUtilisateurPofile(int idUser, string token);
        public Task<int> GetIdUtilisateurPofile(string mail, string token);
        public Task<UserInfo> GetUtilisateurInfo(string token);
    }
}

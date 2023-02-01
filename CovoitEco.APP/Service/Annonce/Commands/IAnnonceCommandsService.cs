using CovoitEco.APP.Model.Models;

namespace CovoitEco.APP.Service.Annonce.Commands
{
    public interface IAnnonceCommandsService
    {
        public Task CreateAnnonce(AnnonceProfileFormular formular);
        public Task UpdateStatutAnnonce(int idAnn);
    }
}

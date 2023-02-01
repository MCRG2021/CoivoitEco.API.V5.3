namespace CovoitEco.APP.Service.Facture.Commands
{
    public interface IFactureCommandsService
    {
        public Task CreateFacture(int id);
        public Task UpdateFacturePayment(int idFact);
    }
}

namespace CovoitEco.APP.Service.Facture.Commands
{
    public interface IFactureCommandsService
    {
        public Task CreateFacture(int id, string token);
        public Task UpdateFacturePayment(int idFact, string token);
    }
}

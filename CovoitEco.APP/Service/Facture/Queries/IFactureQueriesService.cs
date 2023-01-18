namespace CovoitEco.APP.Service.Facture.Queries
{
    public interface IFactureQueriesService
    {
        public Task<int> GetIdFactureReservation(int idRes);
    }
}

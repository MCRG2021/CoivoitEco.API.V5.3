namespace CovoitEco.APP.Components.Annonce
{
    public class GestionAnnonce : BaseComponent
    {
        protected override async Task OnInitializedAsync()
        {
            responseReservationProfile = await ReservationQueries.GetAllReservationProfile(idAnnonce);
            responseGetVehicule = await vehiculeQueries.GetVehicule(idAnnonce);
            responseAnnonce = await AnnonceQueries.GetAnnonceProfile(idAnnonce);
        }

        protected async Task UpdateAccepterReservation(int idRes)
        {
            UpdateIdReservation(idRes); 
            await ReservationCommands.UpdateAccepterReservation(idReservation);
        }

        protected async Task UpdateConfirmePayment(int idRes)
        {
            UpdateIdReservation(idRes);
            await ReservationCommands.UpdateConfirmePayment(idReservation);
        }
    }
}

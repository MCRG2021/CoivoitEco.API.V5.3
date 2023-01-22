namespace CovoitEco.APP.Components.Annonce
{
    public class GestionAnnonce : BaseComponent
    {
        protected override async Task OnInitializedAsync()
        {
            responseReservationProfile = await ReservationQueries.GetAllReservationProfile(idAnnonce, AccessToken);
            responseGetVehicule = await vehiculeQueries.GetVehicule(idAnnonce, AccessToken);
            responseAnnonce = await AnnonceQueries.GetAnnonceProfile(idAnnonce, AccessToken);
        }

        protected async Task UpdateAccepterReservation(int idRes)
        {
            UpdateIdReservation(idRes); 
            await ReservationCommands.UpdateAccepterReservation(idReservation, AccessToken);
        }

        protected async Task UpdateConfirmePayment(int idRes)
        {
            UpdateIdReservation(idRes);
            await ReservationCommands.UpdateConfirmePayment(idReservation, AccessToken);
        }
    }
}


namespace CovoitEco.APP.Components.Reservation
{
    public class ReservationComponent : BaseComponent
    {
        protected override async Task OnInitializedAsync()
        {
            responseGetAllReservationUser = await ReservationQueries.GetAllReservationUserProfile(idUser);
            await UpdateStatutReservation();
        }

        protected async Task UpdateFacturePayment(int id)
        {
            idFacture = await FactureQueries.GetIdFactureReservation(id);
            await FactureCommands.UpdateFacturePayment(idFacture);
        }

        protected async Task UpdateStatutReservation()
        {
            foreach (var reservation in responseGetAllReservationUser.Lists)
            {
                if (reservation.RES_FACT_StatutLibelle == "EnAttente")
                {
                    await ReservationCommands.UpdateStatutReservation(reservation.RES_Id);
                }
            }
        }
    }
}

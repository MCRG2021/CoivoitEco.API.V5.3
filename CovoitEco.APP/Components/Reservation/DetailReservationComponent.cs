
namespace CovoitEco.APP.Components.Reservation
{
    public class DetailReservationComponent : BaseComponent
    {
        protected override async Task OnInitializedAsync()
        {
            responseGetReservationUser = await ReservationQueries.GetReservationUserProfile(idReservation);
        }

    }
}

using CovoitEco.APP.Model.Models;
using CovoitEco.APP.Service.Reservation.Queries;
using Microsoft.AspNetCore.Components;

namespace CovoitEco.APP.Components.Reservation
{
    public class DetailReservationComponent : BaseComponent
    {
        protected override async Task OnInitializedAsync()
        {
            responseGetReservationUser = await ReservationQueries.GetReservationUserProfile(idReservation, AccessToken);
        }

    }
}

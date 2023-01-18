using CovoitEco.APP.Model.Models;

namespace CovoitEco.APP.Service.Reservation.Queries
{
    public interface IReservationQueriesService
    {
        public Task<int> GetIdReservationUserProfile(int idAnn, int idUser);
        public Task<ReservationUserProfileVm> GetAllReservationUserProfile(int idUser, string token);
        public Task<ReservationUserProfileVm> GetReservationUserProfile(int idRes, string token);
        public Task<ReservationProfileVm> GetAllReservationProfile(int id);
    }
}

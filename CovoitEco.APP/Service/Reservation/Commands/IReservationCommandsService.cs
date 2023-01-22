using CovoitEco.APP.Model.Models;

namespace CovoitEco.APP.Service.Reservation.Commands
{
    public interface IReservationCommandsService
    {
        public Task CreateReservation(ReservationFormular formular, string token);
        public Task UpdateConfirmePayment(int id, string token);
        public Task UpdateAccepterReservation(int id, string token);
        public Task UpdateStatutReservation(int id, string token);
    }
}

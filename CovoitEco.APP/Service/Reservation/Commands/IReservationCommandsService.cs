using CovoitEco.APP.Model.Models;

namespace CovoitEco.APP.Service.Reservation.Commands
{
    public interface IReservationCommandsService
    {
        public Task CreateReservation(ReservationFormular formular);
        public Task UpdateConfirmePayment(int id);
        public Task UpdateAccepterReservation(int id);
        public Task UpdateStatutReservation(int id);
    }
}

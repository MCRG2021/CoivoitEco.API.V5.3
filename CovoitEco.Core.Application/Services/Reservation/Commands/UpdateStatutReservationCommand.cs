using CovoitEco.Core.Application.Common.Interfaces;
using MediatR;

namespace CovoitEco.Core.Application.Services.Reservation.Commands
{
    public class UpdateStatutReservationCommand : IRequest<int>
    {
        public int RES_Id { get; set; }
    }

    public class UpdateStatutReservationCommandHandler : IRequestHandler<UpdateStatutReservationCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateStatutReservationCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateStatutReservationCommand request, CancellationToken cancellationToken)
        {

            var reservation = await _context.Reservation.FindAsync(request.RES_Id);

            if (!reservation.Equals(null))
            {
                var annonce = await _context.Annonce.FindAsync(reservation.RES_ANN_Id);

                if (reservation.RES_STATRES_Id == 1 && annonce.ANN_STATANN_Id != 1) //  reservation "EnAttente" and annonce not "Publier"
                {
                    reservation.RES_STATRES_Id = 4; // reservation canceled
                }

            }
            else throw new Exception("No result for the reservation Id");

            await _context.SaveChangesAsync(cancellationToken);

            return request.RES_Id;
        }
    }
}
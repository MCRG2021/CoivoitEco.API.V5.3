using CovoitEco.Core.Application.Common.Interfaces;
using MediatR;

namespace CovoitEco.Core.Application.Services.Annonce.Commands
{
    public class UpdateStatutAnnonceCommand : IRequest<int>
    {
        public int ANN_Id { get; set; }
    }
    public class UpdateStatutAnnonceCommandHandler : IRequestHandler<UpdateStatutAnnonceCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateStatutAnnonceCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateStatutAnnonceCommand request, CancellationToken cancellationToken)
        {
            var annonce = await _context.Annonce.FindAsync(request.ANN_Id);

            if (annonce == null)
            {
                throw new Exception("Annonce not found");
            }

            // to count a number of reservation 
            var reservation = _context.Reservation.Where(item => item.RES_ANN_Id == request.ANN_Id && item.RES_STATRES_Id == 2);

            // "Publier" => "EnCours" 
            if (annonce.ANN_STATANN_Id == 1 && TooLate(annonce.ANN_DateDepart) == true)
            {
                 annonce.ANN_STATANN_Id = 2; // Status "EnCours"
            }

            // "EnCours" => "Close"
            if (annonce.ANN_STATANN_Id == 2 && reservation.Count().Equals(0) && annonce.ANN_DateArrive < DateTime.Now)
            {
                annonce.ANN_STATANN_Id = 3; // Status "Close"
            }

            // transactions  
            await _context.SaveChangesAsync(cancellationToken);

            return request.ANN_Id;
        }

        private bool TooLate(DateTime dateTimeDepart) 
        {
            double minutes = 0;
            if (dateTimeDepart.Date >= DateTime.Now.Date)
            {
                TimeSpan timespan =  dateTimeDepart - DateTime.Now;
                minutes = timespan.TotalMinutes;
                if (minutes >= 15) return false;
            }
            return true;
        }
    }
}

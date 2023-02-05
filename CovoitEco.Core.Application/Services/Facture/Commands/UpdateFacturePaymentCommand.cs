using CovoitEco.Core.Application.Common.Exceptions;
using CovoitEco.Core.Application.Common.Interfaces;
using MediatR;

namespace CovoitEco.Core.Application.Services.Facture.Commands
{
    public class UpdateFacturePaymentCommand : IRequest<int>
    {
        #region Properties

        public int FACT_Id { get; set; }

        #endregion
    }
    public class UpdateFacturePaymentCommandHandler : IRequestHandler<UpdateFacturePaymentCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateFacturePaymentCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateFacturePaymentCommand request, CancellationToken cancellationToken)
        {
            var facture = await _context.Facture.FindAsync(request.FACT_Id);

            var reservation = await _context.Reservation.FindAsync(facture.FACT_RES_Id);

            var annonce =  _context.Annonce.Where(item => item.ANN_Id == reservation.RES_ANN_Id);

            // Test if annonce "EnCours" + journey ended
            if (annonce.First().ANN_STATANN_Id != 2 && annonce.First().ANN_DateArrive > DateTime.Now)
                throw new Exception("You have to wait the end of the journey ");

            if (facture == null)
            {
                throw new NotFoundException(nameof(facture), request.FACT_Id);
            }

            facture.FACT_DatePayment = DateTime.Now;
            facture.FACT_Resolus = true;

            if (reservation == null)
            {
                throw new NotFoundException(nameof(facture), request.FACT_Id);
            }

            await _context.SaveChangesAsync(cancellationToken);

            return facture.FACT_Id;
        }
    }
}

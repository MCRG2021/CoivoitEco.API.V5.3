using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            //reservation.RES_STATRES_Id = 3; // to change when all status established => je le fais dans la partie updateConfirmePayment => ligne a supprimer 

            await _context.SaveChangesAsync(cancellationToken);

            return facture.FACT_Id;
        }
    }
}

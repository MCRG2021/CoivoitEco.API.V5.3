using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CovoitEco.Core.Application.Common.Exceptions;
using CovoitEco.Core.Application.Common.Interfaces;
using CovoitEco.Core.Application.Services.Facture.Commands;
using MediatR;

namespace CovoitEco.Core.Application.Services.Annonce.Commands
{
    public class UpdateAnnonceCommand : IRequest<int>
    {
        public int ANN_Id { get; set; }
        public float ANN_Prix { get; set; }
    }
    public class UpdateAnnonceCommandCommandHandler : IRequestHandler<UpdateAnnonceCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateAnnonceCommandCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateAnnonceCommand request, CancellationToken cancellationToken)
        {
            var Annonce = await _context.Annonce.FindAsync(request.ANN_Id);


            if (Annonce == null)
            {
                throw new NotFoundException(nameof(Annonce), request.ANN_Id);
            }

            Annonce.ANN_Prix = request.ANN_Prix;
            

            await _context.SaveChangesAsync(cancellationToken);

            return request.ANN_Id;
        }
    }
}

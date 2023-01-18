using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CovoitEco.Core.Application.Common.Interfaces;
using CovoitEco.Core.Application.Services.VehiculeProfile.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CovoitEco.Core.Application.Services.Facture.Commands
{
    public class CreateFactureCommand : IRequest<int>
    {
        #region Properties

        public int FACT_RES_Id { get; set; }

        #endregion
    }
    public class CreateFactureCommandHandler : IRequestHandler<CreateFactureCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateFactureCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateFactureCommand request, CancellationToken cancellationToken)
        {

            var entity = new Domain.Entities.Facture()
            {
                FACT_Id = 0, // auto increment 
                FACT_DateCreation = DateTime.Now,
                FACT_DatePayment = null,
                FACT_Resolus = false, // by default
                FACT_RES_Id = request.FACT_RES_Id
            };

            _context.Facture.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.FACT_Id;

        }
    }
}

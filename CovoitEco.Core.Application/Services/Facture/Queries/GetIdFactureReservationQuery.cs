using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CovoitEco.Core.Application.Common.Interfaces;
using CovoitEco.Core.Application.DTOs;
using CovoitEco.Core.Application.Services.Reservation.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CovoitEco.Core.Application.Services.Facture.Queries
{
    public class GetIdFactureReservationQuery : IRequest<int>
    {
        public int RES_Id { get; set; }
    }

    public class GetIdFactureReservationQueryHandler : IRequestHandler<GetIdFactureReservationQuery, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;


        public GetIdFactureReservationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Handle(GetIdFactureReservationQuery request, CancellationToken cancellationToken)
        {

            var list = await (
                from f in _context.Facture
                where (f.FACT_RES_Id == request.RES_Id)
                select new FactureReservationDTO()
                {
                    FACT_Id = f.FACT_Id
                }
            ).ToListAsync(cancellationToken);

            return list[0].FACT_Id;

        }
    }
}
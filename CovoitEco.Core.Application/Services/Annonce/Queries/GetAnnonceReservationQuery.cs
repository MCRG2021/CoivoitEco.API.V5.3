using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CovoitEco.Core.Application.Common.Interfaces;
using CovoitEco.Core.Application.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CovoitEco.Core.Application.Services.Annonce.Queries
{
    public class GetAnnonceReservationQuery : IRequest<int>
    {
        public int ANN_Id { get; set; }
    }

    public class GetAnnonceReservationQueryHandler : IRequestHandler<GetAnnonceReservationQuery, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;


        public GetAnnonceReservationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Handle(GetAnnonceReservationQuery request, CancellationToken cancellationToken) 
        {

            var list = await (
                from r in _context.Reservation
                join sr in _context.StatutReservation on r.RES_STATRES_Id equals sr.STATRES_Id
                where (sr.STATRES_Libelle == "EnAttente" && r.RES_ANN_Id == request.ANN_Id)
                select new AnnonceReservationDTO()
                {
                    ANNRES_Id = request.ANN_Id
                }
            ).ToListAsync(cancellationToken);

            return list.Count;
        }
    }
}

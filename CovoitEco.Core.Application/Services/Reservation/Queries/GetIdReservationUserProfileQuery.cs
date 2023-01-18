using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CovoitEco.Core.Application.Common.Interfaces;
using CovoitEco.Core.Application.DTOs;
using CovoitEco.Core.Application.Services.Annonce.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CovoitEco.Core.Application.Services.Reservation.Queries
{
    public class GetIdReservationUserProfileQuery : IRequest<int>
    {
        public int UTL_Id { get; set; }
        public int ANN_Id { get; set; }
    }

    public class GetIdReservationUserQueryHandler : IRequestHandler<GetIdReservationUserProfileQuery, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;


        public GetIdReservationUserQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Handle(GetIdReservationUserProfileQuery request, CancellationToken cancellationToken) 
        {

            var list = await (
                from r in _context.Reservation
                where (r.RES_ANN_Id == request.ANN_Id && r.RES_UTL_Id == request.UTL_Id)
                select new AnnonceReservationDTO()
                {
                    ANNRES_Id = r.RES_Id
                }
            ).ToListAsync(cancellationToken);

            return list[0].ANNRES_Id;
        }
    }
}

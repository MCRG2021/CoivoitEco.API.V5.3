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

namespace CovoitEco.Core.Application.Services.User.Queries
{
    public class GetUserProfileQuery : IRequest<UserProfileVm>
    {
        public int UTL_Id { get; set; }
    }

    public class GetUserProfileQueryHandler : IRequestHandler<GetUserProfileQuery, UserProfileVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;


        public GetUserProfileQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserProfileVm> Handle(GetUserProfileQuery request, CancellationToken cancellationToken)
        {
            return new UserProfileVm()
            {
                Lists = await (
                    from u in _context.Utilisateur
                    where u.UTL_Id == request.UTL_Id
                    select new UserProfileDTO()
                    {
                        UTL_Id = u.UTL_Id,
                        UTL_Nom = u.UTL_Nom,
                        UTL_Prenom = u.UTL_Prenom,
                        UTL_Actif = u.UTL_Actif,
                        UTL_Mail = u.UTL_Mail,
                        UTL_IdAuth0 = u.UTL_IdAuth0
                    }
                ).ToListAsync(cancellationToken)
            };
        }
    }
}
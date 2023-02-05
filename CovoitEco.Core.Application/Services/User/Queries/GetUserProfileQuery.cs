using AutoMapper;
using CovoitEco.Core.Application.Common.Interfaces;
using CovoitEco.Core.Application.DTOs;
using CovoitEco.Core.Application.Filter;
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
            // Check identity user
            var user = await _context.Utilisateur.FindAsync(request.UTL_Id);
            if (user.UTL_Mail != EmailAuthorizationCheck.email) throw new Exception("Bad user");

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
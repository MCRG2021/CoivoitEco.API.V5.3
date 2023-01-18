using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CovoitEco.Core.Application.Common.Interfaces;
using CovoitEco.Core.Application.DTOs;
using CovoitEco.Core.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CovoitEco.Core.Application.Services.User.Queries
{
    public class GetIdUserProfileQuery : IRequest<int>
    {
        public string UTL_Mail { get; set; }
    }
    public class GetIdUserProfileQueryHandler : IRequestHandler<GetIdUserProfileQuery, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;


        public GetIdUserProfileQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Handle(GetIdUserProfileQuery request, CancellationToken cancellationToken)
        {
            var user = _context.Utilisateur.Where(item => item.UTL_Mail == request.UTL_Mail);

            if (user.Count() > 0) return user.First().UTL_Id;
            else throw new Exception("No user detected");
        }
    }
}

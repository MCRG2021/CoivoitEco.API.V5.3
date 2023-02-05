using CovoitEco.API.Consume.Auth0.Interface.Role.Commands;
using CovoitEco.API.Consume.Auth0.Interface.User.Commands;
using CovoitEco.API.Consume.Auth0.Models;
using CovoitEco.Core.Application.Common.Interfaces;
using MediatR;

namespace CovoitEco.Core.Application.Services.User.Commands
{
    public class CreateUserCommand : IRequest<int>
    {
        public string email { get; set; }
        public string family_name { get; set; }
        public string password { get; set; }
        public string username { get; set; }
    }
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly ICommandsRoleService _commandsRoleService;
        private readonly ICommandsUserService _commandsUserService;
        private readonly IApplicationDbContext _context;
        
        public CreateUserCommandHandler(IApplicationDbContext context, ICommandsUserService commandsUserService, ICommandsRoleService commandsRoleService)
        {
            _context = context;
            _commandsUserService = commandsUserService;
            _commandsRoleService = commandsRoleService;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            // Select the Id Auth0
            string user_id = "";
            int counter = _context.Utilisateur.Count();

            if (counter > 0)
            {
                counter += 1;
                user_id = counter.ToString();
            }
            else
            {
                counter += 2;
                user_id = counter.ToString();
            }

            // creation user auth0
            API.Consume.Auth0.Models.User user = new API.Consume.Auth0.Models.User()
            {
                email = request.email,
                family_name = request.family_name,
                name = request.email,
                user_id = user_id,
                password = request.password,
                username = request.username
            };

            user.app_metadata = new AppMetadata();
            user.user_metadata = new UserMetadata();
            user.blocked = false;
            user.email_verified = false;
            user.verify_email = false;
            user.connection = "Username-Password-Authentication";
            user.picture = "https://www.google.co.in/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png";
            user.given_name = "NA";
            user.nickname = "NA";

            await _commandsUserService.CreateUser(user); 

            // assign role 

            API.Consume.Auth0.Models.UserRole idUser = new UserRole()
            {
                users = new List<string>
                {
                    "auth0|" + user_id
                }
            };

            await _commandsRoleService.AssignRole(idUser, "rol_qx5vLjk1bt0nq2vn"); // by default

            // Creation reservation on DB owner

            var entity = new Domain.Entities.Utilisateur
            {
                UTL_Id = 0, // auto increment 
                UTL_Actif = true, // by default
                UTL_Nom = request.family_name,
                UTL_Prenom = request.username,
                UTL_Mail = request.email,
                UTL_IdAuth0 = counter
            };

            _context.Utilisateur.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.UTL_Id;
        }
    }
}

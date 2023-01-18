using CovoitEco.API.Consume.Auth0.Models;

namespace CovoitEco.API.Consume.Auth0.Interface.Role.Commands
{
    public interface ICommandsRoleService
    {
        public Task AssignRole(UserRole userRole,string idRole);
        public Task RemoveRole(RemoveRoleUser userRole, string idUser);
    }
}

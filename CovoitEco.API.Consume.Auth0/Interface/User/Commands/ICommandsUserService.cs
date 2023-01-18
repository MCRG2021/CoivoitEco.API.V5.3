using CovoitEco.API.Consume.Auth0.Models;

namespace CovoitEco.API.Consume.Auth0.Interface.User.Commands
{
    public interface ICommandsUserService
    {
        public Task CreateUser(Models.User user);
        public Task UpdateUser(UserUpdate user, string idUser);
        public Task DeleteUser(string idUser);
    }
}

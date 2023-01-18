using CovoitEco.API.Consume.Auth0.Models;

namespace CovoitEco.API.Consume.Auth0.Interface.User.Queries
{
    public interface IQueriesUserService
    {
        public Task<List<UserResponse>> GetAllAsync(int pageSize, int pageNumber);
        public Task<UserInfo> GetUserInfo (string accessToken);
    }
}

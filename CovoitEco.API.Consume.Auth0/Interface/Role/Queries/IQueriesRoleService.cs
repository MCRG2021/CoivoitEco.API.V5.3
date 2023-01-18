namespace CovoitEco.API.Consume.Auth0.Interface.Role.Queries
{
    public interface IQueriesRoleService
    {
        public Task<List<Models.Role>> GetAllAsync();
       
    }
}

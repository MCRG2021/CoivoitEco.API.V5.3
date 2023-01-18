namespace CovoitEco.API.Consume.Auth0.Models
{
    public class UserRole
    {
        public List<string> users { get; set; }
    }

    public class RemoveRoleUser
    {
        public List<string> roles { get; set; }
    }
}

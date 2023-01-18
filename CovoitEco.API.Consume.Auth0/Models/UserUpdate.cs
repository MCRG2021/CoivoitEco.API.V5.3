namespace CovoitEco.API.Consume.Auth0.Models
{
    public class UserUpdate
    {
        public string given_name { get; set; }
        public string family_name { get; set; }
        public string name { get; set; }
        public string nickname { get; set; }
        public string password { get; set; }
    }
}

namespace CovoitEco.API.Consume.Auth0.Models
{
    public class UserUpdateResponse
    {
        public bool blocked { get; set; }
        public DateTime created_at { get; set; }
        public string email { get; set; }
        public bool email_verified { get; set; }
        public string family_name { get; set; }
        public string given_name { get; set; }
        public List<Identity> identities { get; set; }
        public string name { get; set; }
        public string nickname { get; set; }
        public string picture { get; set; }
        public DateTime updated_at { get; set; }
        public string user_id { get; set; }
        public UserMetadata user_metadata { get; set; }
        public string username { get; set; }
    }
}

namespace CovoitEco.API.Consume.Auth0.Models
{
    public class UserResponse
    {
        public DateTime created_at { get; set; }
        public string email { get; set; }
        public bool email_verified { get; set; }
        public List<Identity> identities { get; set; }
        public string name { get; set; }
        public string nickname { get; set; }
        public string picture { get; set; }
        public DateTime updated_at { get; set; }
        public string user_id { get; set; }
        public UserMetadata user_metadata { get; set; }
        public DateTime last_login { get; set; }
        public string last_ip { get; set; }
        public int logins_count { get; set; }
    }
    public class Identity
    {
        public string connection { get; set; }
        public string provider { get; set; }
        public string user_id { get; set; }
        public bool isSocial { get; set; }
    }
}

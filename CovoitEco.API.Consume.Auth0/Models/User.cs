namespace CovoitEco.API.Consume.Auth0.Models
{
    public class User
    {
        public string email { get; set; }
        //public string phone_number { get; set; }
        public UserMetadata user_metadata { get; set; }
        public bool blocked { get; set; }
        public bool email_verified { get; set; }
        //public bool phone_verified { get; set; }
        public AppMetadata app_metadata { get; set; }
        public string given_name { get; set; }
        public string family_name { get; set; }
        public string name { get; set; }
        public string nickname { get; set; }
        public string picture { get; set; }
        public string user_id { get; set; }
        public string connection { get; set; }
        public string password { get; set; }
        public bool verify_email { get; set; }
        public string username { get; set; }
    }

    public class AppMetadata
    {
    }

    public class UserMetadata
    {
        public int profileCode { get; set; } // test
    }

    public class UserById
    {
        public string user_id { get; set; }
    }
}

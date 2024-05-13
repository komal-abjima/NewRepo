namespace Five9.Models
{
    public class Five9LoginRequest
    {
        public PasswordCredentials passwordCredentials { get; set; }

        public string policy { get; set; }

        public class PasswordCredentials
        {
            public string username { get; set; }
            public string password { get; set; }
        }
    }
}

namespace Trickery.Configuration
{
    public class ConfigurationProperties
    {
        public class Auth
        {
            public const string Method = "Auth:Method";
        }
        public class Auth0
        {
            public const string Audience = "Auth0:Audience";
            public const string Authority = "Auth0:Authority";
        }
        public class DbSettings
        {
            public const string ConnectionString = "DbSettings:ConnectionString";
        }
    }
}

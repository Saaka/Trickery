using Microsoft.Extensions.Configuration;

namespace Trickery.Configuration
{
    public class ApplicationConfiguration : IDbConnectionConfig, IMongoConnectionConfig
    {
        private readonly IConfiguration _config;

        public ApplicationConfiguration(IConfiguration config)
        {
            _config = config;
        }

        private string DbConnectionString => _config[ConfigurationProperties.DbSettings.ConnectionString].ToString();
        private string MongoConnection => _config[ConfigurationProperties.Mongo.ConnectionString].ToString();
        private string MongoDatabase => _config[ConfigurationProperties.Mongo.Database].ToString();


        public string GetConnectionString()
        {
            return DbConnectionString;
        }

        public string GetMongoConnectionString()
        {
            return MongoConnection;
        }

        public string GetMongoDatabase()
        {
            return MongoDatabase;
        }
    }
}

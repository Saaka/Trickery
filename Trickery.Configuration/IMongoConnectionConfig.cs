namespace Trickery.Configuration
{
    public interface IMongoConnectionConfig
    {
        string GetMongoConnectionString();
        string GetMongoDatabase();
    }
}

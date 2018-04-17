using MongoDB.Driver;
using Trickery.Configuration;
using Trickery.Model.Document;

namespace Trickery.DAL.Store.Document
{
    public class TestMessageContext
    {
        private readonly IMongoDatabase _database = null;

        public TestMessageContext(MongoClient client,
            IMongoConnectionConfig _connectionConfig)
        {
            _database = client.GetDatabase(_connectionConfig.GetMongoDatabase());
        }

        public IMongoCollection<TestMessage> TestCollection
        {
            get
            {
                return _database.GetCollection<TestMessage>("Test");
            }
        }
    }
}

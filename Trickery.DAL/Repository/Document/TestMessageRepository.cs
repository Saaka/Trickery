using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trickery.DAL.Store.Document;
using Trickery.Model.Document;

namespace Trickery.DAL.Repository.Document
{
    public interface ITestMessageRepository
    {
        Task<IEnumerable<TestMessage>> GetAll();
        Task<TestMessage> Add(TestMessage item);
        Task ClearCollection();
    }

    public class TestMessageRepository : ITestMessageRepository
    {
        private readonly TestMessageContext context;

        public TestMessageRepository(TestMessageContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<TestMessage>> GetAll()
        {
            return await context.TestCollection
                .Find(x => true)
                .ToListAsync();
        }

        public async Task<TestMessage> Add(TestMessage item)
        {
            await context.TestCollection
                .InsertOneAsync(item);

            return item;
        }

        public async Task ClearCollection()
        {
            await context.TestCollection.DeleteManyAsync(x => true);
        }
    }
}

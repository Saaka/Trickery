using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trickery.DAL.Store.Document;
using Trickery.Model.Document;
using System.Linq;

namespace Trickery.DAL.Repository.Document
{
    public interface ITestMessageRepository
    {
        Task<IEnumerable<TestMessage>> GetAll();
        Task<IEnumerable<TestMessageA>> GetAllMessagesA();
        Task<IEnumerable<TestMessageB>> GetAllMessagesB();
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

        public async Task<IEnumerable<TestMessageA>> GetAllMessagesA()
        {
            var messages = await context.TestCollection
                .OfType<TestMessageA>()
                .Find(x => x.MessageType == Common.Enums.TestMessageType.TypeA)
                .ToListAsync();

            return messages
                .ToList();
        }

        public async Task<IEnumerable<TestMessageB>> GetAllMessagesB()
        {
            var messages = await context.TestCollection
                .OfType<TestMessageB>()
                .Find(x => x.MessageType == Common.Enums.TestMessageType.TypeB)
                .ToListAsync();

            return messages
                .ToList();
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

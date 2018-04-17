using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Trickery.Model.Document
{
    public class TestMessage
    {
        [BsonId]
        public ObjectId SysId { get; set; }
        public Guid Id { get; set; }
        public string Message { get; set; }
        public string UserId { get; set; }
    }
}

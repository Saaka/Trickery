using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using Trickery.Common.Enums;

namespace Trickery.Model.Document
{
    public class TestMessage
    {
        public TestMessage()
        {
            MessageType = TestMessageType.Base;
        }

        [BsonId]
        public ObjectId SysId { get; set; }
        public Guid Id { get; set; }
        public string Message { get; set; }
        public string UserId { get; set; }
        public TestMessageType MessageType { get; set; }
    }
}

using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Api.Model
{
    public class BaseModel
    {
        [BsonId]
        public MongoDB.Bson.ObjectId Id { get; set; } = ObjectId.GenerateNewId();
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
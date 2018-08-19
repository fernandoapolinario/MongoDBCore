using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebAPICoreMongoDb.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRequired]
        public string FistName { get; set; }

        [BsonRequired]
        public string LastName { get; set; }

        public string Document { get; set; }

        public int Age { get; set; }
    }
}

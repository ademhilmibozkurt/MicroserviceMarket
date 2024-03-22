using MongoDB.Bson.Serialization.Attributes;

namespace AccountService.Data.Entities
{
    public class Player
    {
        // mongo db uses string Id
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string FirstName { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string LastName { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string UserName { get; set; }
    }
}

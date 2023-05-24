using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RAS.Services.ProductAPI.Models
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }

        public string Name { get; set; }
    }
}

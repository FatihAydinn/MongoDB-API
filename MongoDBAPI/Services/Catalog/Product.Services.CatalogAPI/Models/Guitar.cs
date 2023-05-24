using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace RAS.Services.ProductAPI.Models
{
    public class Guitar
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [BsonRepresentation(BsonType.Decimal128)]
        public int Price { get; set; }

        public string UserID{ get; set; }

        public string Picture { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CreatedTime  { get; set; }

        public Feature Feature { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryID{ get; set; }

        [BsonIgnore] //veritabanında bir yere sahip olmayacak
        public Category Category { get; set; }
    }
}

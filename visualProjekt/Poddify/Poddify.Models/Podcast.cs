using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Poddify.Models
{
    public class Podcast
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }      
        public string Name { get; set; }
        public string RssUrl { get; set; }
        public List<string> Episodes { get; set; } = new();
    }
}

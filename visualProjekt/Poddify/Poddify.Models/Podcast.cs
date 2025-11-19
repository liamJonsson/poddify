using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Poddify.Models
{
    public class Podcast
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }      
        public string Title { get; set; }
        public string RssUrl { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string? CategoryId { get; set; }

        public List<Episode> Episodes { get; set; } 
    }
}

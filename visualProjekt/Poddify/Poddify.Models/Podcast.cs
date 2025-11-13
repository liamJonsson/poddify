using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Poddify.Models
{
    public class Podcast
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }            // ändrat till PascalCase

        public string Name { get; set; }
        public string RssUrl { get; set; }
        public List<string> Episodes { get; set; } = new();
    }
}

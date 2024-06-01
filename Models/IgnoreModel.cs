using MongoDB.Bson.Serialization.Attributes;

namespace scannerFakeBackend.Models;

public class IgnoreModel
{   
    [BsonIgnore]
    public string? IgnoreProperty { get; set; } = null;
}
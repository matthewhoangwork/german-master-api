using System.Runtime.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class User
{
    [BsonId] [BsonRepresentation(BsonType.ObjectId)]
    public string? _Id;
    
    [BsonElement("id")]
    public int? Id { get; set; }

    [DataMember]
    [BsonElement("name")]
    public string Name { get; set; }
    
    [DataMember]
    [BsonElement("email")]
    public string Email { get; set; }
    
    [DataMember]
    [BsonElement("createdDate")]
    public DateTime? CreatedDate { get; set; }
}
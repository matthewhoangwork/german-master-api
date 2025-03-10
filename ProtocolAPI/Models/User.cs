using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class User
{
    // [BsonId] [BsonRepresentation(BsonType.ObjectId)]
    // public string? _Id;

    [DataMember]
    [BsonElement("id")]
    [BsonId] [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [DataMember]
    [BsonElement("name")]
    [Required]
    public string Name { get; set; }
    
    [DataMember]
    [BsonElement("email")]
    [Required]
    public string Email { get; set; }
    
    [DataMember]
    [BsonElement("createdDate")]
    public DateTime? CreatedDate { get; set; }
}
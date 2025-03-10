using MongoDB.Driver;

namespace ProtocolAPI.Services;

public class MongoDbService
{
    public readonly IMongoCollection<User> UserCollection;

    public MongoDbService(IConfiguration configuration)
    {
        bool isProduction = false;
        string connectionStringStr = isProduction ? "MongoDbConnectionAtlas" : "MongoDbConnectionLocal";
        var connectionString = configuration.GetConnectionString(connectionStringStr);
        var mongoClient = new MongoClient(connectionString);
        var mongoDatabase = mongoClient.GetDatabase("dev");
        UserCollection = mongoDatabase.GetCollection<User>("Users");
    }
}